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
using DVLD_Classess;

namespace DVLD_Project
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        int _LocalDrivingLicenseApplicationID;

        enum enMode { Addnew = 0, Update = 1 };

        enMode _Mode;

        int _PersonSelected = -1;
        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            if (_LocalDrivingLicenseApplicationID == -1)
            {
                _Mode = enMode.Addnew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private void _FillLicensesClassessInComboBox()
        {
            DataTable DT = clsLicenseClass.GetAllLicenseClassess();

            foreach (DataRow row in DT.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void _FilltpApplicationInfo()
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            cbLicenseClass.SelectedIndex = 0;
            lblCreatedBy.Text = clsGlobal.LoggedInUser.UserName.ToString();
        }
        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _FillLicensesClassessInComboBox();
            _FilltpApplicationInfo();

            if (_Mode == enMode.Addnew)
            {
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                btnSave.Enabled = false;
                tpApplicationInfo.Enabled = false;
                return;
            }

            lblTitle.Text = "Update Local Driving License Application";
            ctrlPersonInformationWithFilter1.FilterByGroupBoxDisable();
            tpApplicationInfo.Enabled = true;
            btnSave.Enabled = true;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonInformationWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblPaidFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(ctrlPersonInformationWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Please Choose a Person!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                tcPersonApplicationInfo.SelectedTab = tcPersonApplicationInfo.TabPages["tpApplicationInfo"];
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.FindLicenseClassByClassName(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = clsLocalDrivingLicenseApplication.GetActiveApplicationIDForLicenseClass(_PersonSelected, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if(ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose Another License Class, The Selected Person Already have an Active Application For the Selected Class with ID = " + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            // hna hnktn code bta3 en l person ykon 3ndo license completed mn nfs l class hnktbo hna b3den lma n3ml l license 

            if(clsLicense.IsPersonHasLicense(ctrlPersonInformationWithFilter1.PersonID,LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = _PersonSelected;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.LoggedInUser.UserID;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblPaidFees.Text);

            if(_LocalDrivingLicenseApplication.Save())
            {
                lblLDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                lblTitle.Text = "Update Local Driver License Application";
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlPersonInformationWithFilter1_OnPersonSelected(int obj)
        {
            _PersonSelected = obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
