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

namespace DVLD_Project.People.Controls
{
    public partial class ctrlPersonInformationWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

        public int PersonID
        {
            get { return ctrlPersonInformation1.PersonID; }
        }

        public ctrlPersonInformationWithFilter()
        {
            InitializeComponent();
        }

        public void TxtSearchBoxFocus()
        {
            txtSearchBox.Focus();
        }

        public void FilterByGroupBoxDisable()
        {
            gbFilterBy.Enabled = false;
        }
        private void ctrlPersonInformationWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }



        private void _Search()
        {
            switch(cbFilterBy.Text)
            {
                case "PersonID":
                    if(!string.IsNullOrEmpty(txtSearchBox.Text))
                    {
                        ctrlPersonInformation1.LoadPersonInfo(int.Parse(txtSearchBox.Text));
                    }
                    else
                    {
                        MessageBox.Show("No Number Entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;


                case "NationalNo":
                    ctrlPersonInformation1.LoadPersonInfo(txtSearchBox.Text); 
                    break;

                default:
                    break;
            }

            if(OnPersonSelected != null)
            {
                PersonSelected(ctrlPersonInformation1.PersonID);
            }
        }

        private void _Form2_DataBack(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtSearchBox.Text = PersonID.ToString();
            ctrlPersonInformation1.LoadPersonInfo(PersonID);
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            _Search();
        }

        public void LoadPersonInfo(int PersonID)
        {
            txtSearchBox.Text = PersonID.ToString();
            _Search();
        }

        private void txtSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);

            frm.DataBack += _Form2_DataBack;

            frm.ShowDialog();
        }
    }
}
