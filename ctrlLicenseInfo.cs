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
using System.IO;
using DVLD_Project.Properties;

namespace DVLD_Project
{
    public partial class ctrlLicenseInfo : UserControl
    {
        int _LicenseID = -1;
        clsLicense _License;
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return _License; } }

        private void LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.GenderString == "Male")
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.Load(ImagePath);
                }
                else
                {
                    MessageBox.Show("Error Loading Image", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FillLicenseInfo()
        {
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo.ToString();  
            lblGendor.Text = _License.DriverInfo.PersonInfo.GenderString.ToString();
            lblIssueDate.Text = _License.IssueDate.ToShortDateString().ToString();
            lblIssueReason.Text = _License.IssueReason.ToString();
            lblNotes.Text = string.IsNullOrEmpty(_License.Notes) ? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Active" : "Not Active";
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateofBirth.ToShortTimeString().ToString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString().ToString();
            lblIsDetained.Text = _License.IsLicenseDetained() ? "Yes" : "No";
            LoadPersonImage();
        }

        public void LoadInfo (int LicenseID)
        {
            _LicenseID = LicenseID; 

            _License = clsLicense.Find(_LicenseID);

            if(_License == null)
            {
                MessageBox.Show("There is No License With This LicenseID","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            FillLicenseInfo();

        }
        
    }
}
