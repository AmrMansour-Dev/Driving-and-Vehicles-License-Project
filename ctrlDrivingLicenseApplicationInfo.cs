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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _LDLApplication;

        int _ApplicationID;

        int _LicenseID;
        public clsLocalDrivingLicenseApplication _SelectedApplication {  get { return _LDLApplication; } }

        public int ApplicationID { get { return _ApplicationID; } } 

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _ResetLicenseApplicationInfo()
        {
            lblDrivingLicenseAppID.Text = "--";
            lblAppliedFor.Text = "--";
            LLShowLicenseInfo.Enabled = false;
            lblPassedTests.Text = "0/3";
        }

        private void _FillLicenseApplicationInfo()
        {
            lblDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = _LDLApplication.LicenseClassInfo.ClassName;
            _LicenseID = _LDLApplication.GetActiveLicenseIDByPersonID();

            LLShowLicenseInfo.Enabled = (_LicenseID != -1);
            lblPassedTests.Text = $"{_LDLApplication.GetPassedTestsCount().ToString()}/3";
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(ApplicationID);

            if(_LDLApplication == null)
            {
                _ResetLicenseApplicationInfo();
                MessageBox.Show($"No Driving License Application Info With LDLAppID ={ApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLicenseApplicationInfo();
            ctrlBasicApplicationInfo1.LoadApplicationInfo(_LDLApplication.ApplicationID);

        }

        private void LLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicenseID = _LDLApplication.GetActiveLicenseIDByPersonID();

            frmShowLicense frm = new frmShowLicense(LicenseID);
            frm.ShowDialog();
        }
    }
}
