using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // USED FOR File Copy from folder to folder
using DVLD_BuisnessLayer;
using DVLD_Classess;

namespace DVLD_Project
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;



        clsPerson _Person;

        int _PersonID;

        enum enMode {AddNew = 0, Update = 1};

        enMode _Mode;

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if(_PersonID == -1)
            {
                _Mode = enMode.AddNew;

            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private void _FillCountriesInComboBox()
        {
            DataTable DT = clsCountry.GetAllCountries();

            foreach(DataRow row in DT.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }

        private void _SetMaximumAge()
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }


        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _FillCountriesInComboBox();

            cbCountries.SelectedIndex = cbCountries.FindString("Egypt");

            _SetMaximumAge();

            rbMale.Checked = true;

            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPerson();
                _Mode = enMode.Update;
                return;
            }

            _Person = clsPerson.Find(_PersonID);

            lblTitle.Text = "Update Person";

            lblPersonIDValue.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateofBirth;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            cbCountries.SelectedIndex = cbCountries.FindString(clsCountry.FindCountryByID(_Person.NationalityCountryID).CountryName);

            if (_Person.Gendor == 0)
            {
                rbMale.Checked = true;

            }
            else
            {
                rbFemale.Checked = true;
            }

            if (_Person.ImagePath != "")
            {
                pbPerson.Load(_Person.ImagePath);
            }

            LLremoveImage.Visible = (_Person.ImagePath != "");
            //LLremoveImage.Visible = (pbPerson.ImageLocation == null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPerson.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {

                    }
                }

                if (pbPerson.ImageLocation != null)
                {
                    string ImageSourceFile = pbPerson.ImageLocation.ToString();

                    if (clsUtility.CopyFileToSpecificFolder(ref ImageSourceFile))
                    {
                        pbPerson.ImageLocation = ImageSourceFile;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }


            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!_HandlePersonImage())
            {
                return;
            }

            int CountryID = clsCountry.FindCountrybyName(cbCountries.Text).CountryID;

            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.DateofBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = CountryID;

            if (rbMale.Checked)
            {
                _Person.Gendor = 0;
            }
            else
            {
                _Person.Gendor = 1;
            }

            _Person.Phone = txtPhone.Text;  
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;

            if(pbPerson.ImageLocation != null)
            {
                _Person.ImagePath = pbPerson.ImageLocation;
            }
            else
            {
                _Person.ImagePath = "";
            }

            if (_Person.Save())
            {
                lblPersonIDValue.Text = _Person.PersonID.ToString();
                lblTitle.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully");
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Data Saving Failed");
            }




        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbPerson.Image = Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbPerson.Image = Properties.Resources.Female_512;
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            DataTable DT = clsPerson.GetAllPersons();

            DataTable NationalNoDT = DT.DefaultView.ToTable(false, "NationalNo");

            foreach(DataRow row in NationalNoDT.Rows)
            {
                if(txtNationalNo.Text.ToUpper() == row["NationalNo"].ToString().ToUpper())
                {
                    e.Cancel = true;
                    txtNationalNo.Focus();
                    errorProvider1.SetError(txtNationalNo,"National Number Is Used For Another Person!");
                    break;
                }
                else
                {
                    e.Cancel= false;
                    errorProvider1.SetError(txtNationalNo, "");
                }
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
                return;
            }
            
            if(!clsValidation.IsValidEmail(txtEmail.Text)) 
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Please enter Valid Email");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
            
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtAddress.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "Please enter the Address");
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");

            }
        }

        private void LLsetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.PNG;*.JPG;*.JPEG";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImageDirectory = openFileDialog1.FileName;
                pbPerson.Load(ImageDirectory);
                LLremoveImage.Visible = true;
            }

        }

        private void LLremoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPerson.ImageLocation = null;

            if(rbFemale.Checked)
            {
                pbPerson.Image = Properties.Resources.Female_512;
            }
            else
            {
                pbPerson.Image = Properties.Resources.Male_512;

            }
            LLremoveImage.Visible = false;
        }
    }
}
