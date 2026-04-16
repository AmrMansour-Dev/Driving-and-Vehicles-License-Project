using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD_Project
{
    public partial class ctrlBasicApplicationInfo : UserControl
    {
        clsApplication _Application;
        public ctrlBasicApplicationInfo()
        {
            InitializeComponent();
        }

        private void _ResetLicenseApplicationInfo()
        {
            lblID.Text = "--";
            lblstatus.Text = "--";
            lblFees.Text = "--";
            lblType.Text = "--";
            lblApplicant.Text = "--";
            lblDate.Text = "--";
            lblstatus.Text = "--";
            lblCreatedBy.Text = "--";
            LLViewPersonInfo.Enabled = false;
        }

        private void _FillLicenseApplicationInfo()
        {
            lblID.Text = _Application.ApplicationID.ToString();
            lblstatus.Text = _Application.StatusString;
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicant.Text = _Application.GetFullApplicantName;
            lblDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _Application.UserInfo.UserName;
            LLViewPersonInfo.Enabled = true;
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplicationByID(ApplicationID);

            if (_Application == null)
            {
                _ResetLicenseApplicationInfo();
                MessageBox.Show($"No Application Info With AppID ={ApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLicenseApplicationInfo();

        }

        private void LLViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_Application.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
