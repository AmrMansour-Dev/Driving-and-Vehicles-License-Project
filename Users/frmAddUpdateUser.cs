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
    public partial class frmAddUpdateUser : Form
    {
        clsUser _User;

        int _UserID;

        enum enMode { Addnew = 0, Update = 1 };

        enMode _Mode;

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

            if(_UserID == -1)
            {
                _Mode = enMode.Addnew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.Addnew)
            {
                _User = new clsUser();
                btnSave.Enabled = false;
                tpLoginInfo.Enabled = false;
                return;
            }

            _User = clsUser.FindByUserID(_UserID);

            lblTitle.Text = "Update User";

            ctrlPersonInformationWithFilter1.FilterByGroupBoxDisable();

            ctrlPersonInformationWithFilter1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName.ToString();
            txtPassword.Text = _User.Password.ToString();
            txtConfirmPassword.Text = _User.Password.ToString();
            cbIsActive.Checked = _User.IsActive !=0;


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }


            if (ctrlPersonInformationWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Please Select a Person","Selection",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ctrlPersonInformationWithFilter1.TxtSearchBoxFocus();
            }
            else
            {
                if(clsUser.IsPersonHasUser(ctrlPersonInformationWithFilter1.PersonID))
                {
                    MessageBox.Show("This Person Has Already a User, Choose Another one.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    ctrlPersonInformationWithFilter1.TxtSearchBoxFocus();
                }
                else
                {
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                }
            }




        }

        private void btnSave_Click(object sender, EventArgs e)
        {



            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.PersonID = ctrlPersonInformationWithFilter1.PersonID;
            if(cbIsActive.Checked )
            {
                _User.IsActive = 1;
            }
            else
            {
                _User.IsActive = 0;
            }

            if(_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                lblTitle.Text = "Update User";
                MessageBox.Show("Data Saved Successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Data Saving Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "UserName Can Not Be Blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "This Field Is Required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password Must Match!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
