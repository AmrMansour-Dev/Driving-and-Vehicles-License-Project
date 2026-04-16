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
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        int _LDLAppID = -1;

        clsLocalDrivingLicenseApplication _LDLApplication;
        public frmIssueDrivingLicenseFirstTime(int LDLAppID)
        {
            _LDLAppID = LDLAppID;
            InitializeComponent();
        }

        private void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfo(_LDLAppID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LDLAppID);

            clsDriver Driver = clsDriver.FindByPersonID(_LDLApplication.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = _LDLApplication.ApplicantPersonID;
                Driver.CreatedByUserID = clsGlobal.LoggedInUser.UserID;

                Driver.Save();
            }
            
            clsLicense License = new clsLicense();

            License.ApplicationID = _LDLApplication.ApplicationID;
            License.DriverID = Driver.DriverID;
            License.LicenseClass = _LDLApplication.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(_LDLApplication.LicenseClassInfo.DefaultValidityLength);
            License.Notes = txtNotes.Text.Trim();
            License.PaidFees = _LDLApplication.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = clsGlobal.LoggedInUser.UserID;

            if(License.Save())
            {
                _LDLApplication.UpdateStatusToComplete();

                MessageBox.Show($"License Issued Successfully With ID = {License.LicenseID}");
            }
            else
            {
                MessageBox.Show("License is Not Issued", "Failed");
            }
        }
    }
}
