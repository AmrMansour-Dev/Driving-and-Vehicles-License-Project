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
    public partial class frmUpdateTestTypes : Form
    {
        int _TestTypeID = -1;
        clsTestType _TestType;
        public frmUpdateTestTypes(int TestTypeID)
        {
            _TestTypeID = TestTypeID;
            InitializeComponent();
        }

        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.FindTestTypeByID((clsTestType.enTestType)_TestTypeID);

            if (_TestType != null)
            {
                lblID.Text = _TestType.TestTypeID.ToString();
                txtTitle.Text = _TestType.TestTypeTitle;
                txtFees.Text = _TestType.TestTypeFees.ToString();
                txtDescription.Text = _TestType.TestTypeDescription;
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

            _TestType.TestTypeTitle = txtTitle.Text;
            _TestType.TestTypeDescription = txtDescription.Text;
            _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show("Saved Successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                txtTitle.Focus();
                errorProvider1.SetError(txtDescription, "Description Can Not Be Blank!");
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

            if (!clsValidation.IsNumber(txtFees.Text))
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
    }
}
