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
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        private int _LicenseID;

        public int LicenseID
        {
            get { return ctrlLicenseInfo1.LicenseID; }
        }

        public void DisableFitler()
        {
            gbFitler.Enabled = false;
        }

        public clsLicense SelectedLicenseInfo
        {
            get { return ctrlLicenseInfo1.SelectedLicenseInfo; }
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ctrlLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlLicenseInfo1.LicenseID;
            if (OnLicenseSelected != null)
                // Raise the event with a parameter
                OnLicenseSelected(_LicenseID);
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;
            }

            LoadLicenseInfo(int.Parse(txtLicenseID.Text));
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtLicenseID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtLicenseID, null);
            }
        }
    }
}
