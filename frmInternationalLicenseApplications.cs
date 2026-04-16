using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;
using DVLD_Classess;

namespace DVLD_Project
{
    public partial class frmInternationalLicenseApplications : Form
    {
        int _InternationalLicenseID;
        public frmInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            LLshowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            if(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Can Not Issue International License for this License Class","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            int InternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if(InternationalLicenseID != -1)
            {
                MessageBox.Show("Can Not Issue International License as This Driver has already active International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                _InternationalLicenseID = InternationalLicenseID;
                LLshowLicenseInfo.Enabled = true;
                return;
            }

            btnIssue.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.DriverID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);


            InternationalLicense.ApplicantPersonID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypesFees;
            InternationalLicense.ApplicationTypeID = (int)clsApplicationType.enApplicationType.NewInternationalLicense;
            InternationalLicense.CreatedByUserID = clsGlobal.LoggedInUser.UserID;

            if(!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = false;
            ctrlLicenseInfoWithFilter1.DisableFitler();
            LLshowLicenseInfo.Enabled = true;

        }

        private void frmInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblFees.Text = clsApplicationType.FindApplicationTypeByID((int)clsApplicationType.enApplicationType.NewInternationalLicense).ApplicationTypesFees.ToString();
            lblCreatedByUser.Text=  clsGlobal.LoggedInUser.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CausesValidation = false;
            this.Close();
        }

        private void LLshowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NationalNo = clsLicense.Find(ctrlLicenseInfoWithFilter1.LicenseID).DriverInfo.PersonInfo.NationalNo;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(NationalNo);
            frm.ShowDialog();
        }

        private void LLshowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalDriverInfo frm = new frmInternationalDriverInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
