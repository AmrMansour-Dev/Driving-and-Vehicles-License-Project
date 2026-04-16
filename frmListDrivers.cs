using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD_Project
{
    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();
        }

        DataTable _dtDrivers = clsDriver.GetAllDrivers();

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            dgvAllDrivers.DataSource = _dtDrivers;

            dgvAllDrivers.Columns[0].HeaderText = "Driver ID";
            dgvAllDrivers.Columns[1].HeaderText = "Person ID";
            dgvAllDrivers.Columns[2].HeaderText = "National No.";
            dgvAllDrivers.Columns[3].HeaderText = "Full Name";
            dgvAllDrivers.Columns[3].Width = 200;
            dgvAllDrivers.Columns[4].HeaderText = "Date";
            dgvAllDrivers.Columns[4].Width = 120;
            dgvAllDrivers.Columns[5].HeaderText = "Active Licenses";

            cbFilterBy.SelectedIndex = 0;
            txtFilterByValue.Visible = false;
            lblRecordsNumber.Text = dgvAllDrivers.RowCount.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            switch (cbFilterBy.Text)
            {
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;
                case "DriverID":
                    FilterColumn = "DriverID";
                    break;
                case "NationalNo.":
                    FilterColumn = "NationalNo";
                    break;
                case "FullName":
                    FilterColumn = "FullName";
                    break;
                case "None":
                    FilterColumn = "None";
                    break;

            }

            

            if (cbFilterBy.Text == "None" || txtFilterByValue.Text == "")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvAllDrivers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID" || FilterColumn == "DriverID")
            {
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterByValue.Text.Trim());

            }
            else
            {
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterByValue.Text.Trim());
            }

            lblRecordsNumber.Text = dgvAllDrivers.Rows.Count.ToString();

        }

        private void txtFilterByValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "PersonID" || cbFilterBy.Text == "DriverID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
    
}
