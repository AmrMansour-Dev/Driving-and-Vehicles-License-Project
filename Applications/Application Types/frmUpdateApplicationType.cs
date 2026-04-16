using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;
using DVLD_Classess;

namespace DVLD_Project
{
    public partial class frmUpdateApplicationType : Form
    {
        int _ApplicationTypeID = -1;
        clsApplicationType _ApplicationType;
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            _ApplicationTypeID = ApplicationTypeID; 
            InitializeComponent();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.FindApplicationTypeByID(_ApplicationTypeID);

            if( _ApplicationType != null )
            {
                lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
                txtTitle.Text = _ApplicationType.ApplicationTypeTitle;
                txtFees.Text = _ApplicationType.ApplicationTypesFees.ToString();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not Valid!, Put The Mouse Over The Red Icon(s) To See The Error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _ApplicationType.ApplicationTypeTitle = txtTitle.Text;
            _ApplicationType.ApplicationTypesFees = Convert.ToSingle(txtFees.Text);

            if(_ApplicationType.Save())
            {
                MessageBox.Show("Saved Successfully","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Saving Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                txtTitle.Focus();
                errorProvider1.SetError(txtTitle, "Title Can Not Be Blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees Can Not Be Blank!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }

            if(!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                txtFees.Focus();
                errorProvider1.SetError(txtFees, "Wrong Values!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
