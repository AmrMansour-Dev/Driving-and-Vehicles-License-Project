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

namespace DVLD_Project
{
    public partial class ctrlPersonInformation : UserControl
    {
        clsPerson _Person;
        int _PersonID = -1;
        public ctrlPersonInformation()
        {
            InitializeComponent();
        }
        
        public int PersonID { get { return _PersonID; } }

        public clsPerson SelectedPersonInfo 
        { 
            get { return _Person; } 
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show($"No Person With PersonID ={PersonID}", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.FindByNationalNo(NationalNo);

            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show($"No Person With NationalNo ={NationalNo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        void _HandleImage()
        {
            if(_Person.Gendor == 0)
            {
                pictureBox1.Image = Properties.Resources.Male_512;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.Female_512;
            }

            if(_Person.ImagePath != "")
            {
                if(File.Exists(_Person.ImagePath))
                {
                    pictureBox1.ImageLocation = _Person.ImagePath;
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void _ResetPersonInfo()
        {
            llEditPersonInfo.Enabled = false;
            _PersonID = -1;
            lblPersonID.Text = "-";
            lblNationalNo.Text = "-";
            lblName.Text = "-";
            lblGendor.Text = "-";
            lblEmail.Text = "-";
            lblPhone.Text = "-";
            lblDateOfBirth.Text = "-";
            lblCountry.Text = "-";
            lblAddress.Text = "-";
            pictureBox1.Image = Properties.Resources.Male_512;
        
        }

        void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FirstName + " " + _Person.SecondName;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateofBirth.ToShortDateString();
            lblCountry.Text = clsCountry.FindCountryByID(_Person.NationalityCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            _HandleImage();
        }
        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
            //_RefreshPeopleList();
        }
    }
}
