using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_BuisnessLayer;
using DVLD_Project.Properties;

namespace DVLD_Project
{
    public partial class ctrlInternationalDriverInfo : UserControl
    {
        clsInternationalLicense _InternationalLicense;

        int _InternationalLicenseID;
        public ctrlInternationalDriverInfo()
        {
            InitializeComponent();
        }

        private void LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.GenderString == "Male")
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.Load(ImagePath);
                }
                else
                {
                    MessageBox.Show("Error Loading Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        void FillInfo()
        {
            lblFullName.Text = _InternationalLicense.GetFullApplicantName;
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString(); 
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo.ToString();
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateofBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            lblGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.GenderString;
            LoadPersonImage();
        }
        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;

            _InternationalLicense = clsInternationalLicense.FindInternationalLicensebyID(InternationalLicenseID);


            if (_InternationalLicense == null)
            {
                MessageBox.Show("No International License For This ID !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            FillInfo();

        }
    }
}
