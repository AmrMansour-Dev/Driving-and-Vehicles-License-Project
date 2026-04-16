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
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }

        private static DataTable _OriginalPeopleTable = clsPerson.GetAllPersons();

        private  DataTable _dtPeople = _OriginalPeopleTable.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
            "LastName", "GendorCaption", "DateOfBirth", "CountryName", "Phone", "Email");
        


        private void _RefreshPeopleList()
        {
            //dgvAllPeople.DataSource = clsPerson.GetAllPersons();

             _OriginalPeopleTable = clsPerson.GetAllPersons();

            _dtPeople = _OriginalPeopleTable.DefaultView.ToTable(false,"PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
                "LastName", "GendorCaption", "DateOfBirth", "CountryName", "Phone", "Email");

            dgvAllPeople.DataSource = _dtPeople;

            lblRecordsNumber.Text = dgvAllPeople.RowCount.ToString();



        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterByValue.Visible = false;
            _RefreshPeopleList();
            lblRecordsNumber.Text = dgvAllPeople.RowCount.ToString();

        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtFilterByValue.Visible = false;


            }
            else
            {
                txtFilterByValue.Visible = true;
            }

        }

        private void txtFilterByValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;
                case "NationalNo.":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Nationality":
                    FilterColumn = "Nationality";
                    break;
                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "None":
                    FilterColumn = "None";
                    break;

            }

            if(cbFilterBy.Text == "None" || txtFilterByValue.Text == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();
                return;
            }

            if(FilterColumn == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterByValue.Text.Trim());

            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterByValue.Text.Trim());
            }

            lblRecordsNumber.Text = dgvAllPeople.Rows.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterByValue_KeyPress(object sender, KeyPressEventArgs e)
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
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void EdittoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void AddPersontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void DeletetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are You Sure You Want Delete Person [{dgvAllPeople.CurrentRow.Cells[0].Value.ToString()}] ?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(clsPerson.Delete((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully", "Successfull");
                }
                else
                {
                    MessageBox.Show("Can Not Delete Person", "Failed");

                }

            }
            _RefreshPeopleList();



        }

        private void ShowDetailstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void SendEmailtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Ready Yet!","Not Ready",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
