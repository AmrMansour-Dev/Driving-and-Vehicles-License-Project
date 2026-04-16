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
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        int _LDLAppID;
        clsLocalDrivingLicenseApplication _LDLApp;
        public frmLocalDrivingLicenseApplicationInfo(int LDLAppID)
        {
            _LDLAppID = LDLAppID;  
            InitializeComponent();
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            _LDLApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LDLAppID);

            if (_LDLApp == null )
            {
                MessageBox.Show("No Application With This ID !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfo(_LDLAppID);
        }
    }
}
