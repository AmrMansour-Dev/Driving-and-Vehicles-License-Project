using DVLD_BuisnessLayer;
using DVLD_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmListInternationalLicenseApplications : Form
    {
        private DataTable _dtInternationalLicenseApplications;
        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            cbFilterBy.SelectedIndex = 0;

            dgvAllInternationalDrivingLicenseApplications.DataSource = _dtInternationalLicenseApplications;
            lblRecordsNumber.Text = dgvAllInternationalDrivingLicenseApplications.Rows.Count.ToString();

            if (dgvAllInternationalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvAllInternationalDrivingLicenseApplications.Columns[0].HeaderText = "Int.License ID";
                dgvAllInternationalDrivingLicenseApplications.Columns[0].Width = 160;

                dgvAllInternationalDrivingLicenseApplications.Columns[1].HeaderText = "Application ID";
                dgvAllInternationalDrivingLicenseApplications.Columns[1].Width = 150;

                dgvAllInternationalDrivingLicenseApplications.Columns[2].HeaderText = "Driver ID";
                dgvAllInternationalDrivingLicenseApplications.Columns[2].Width = 130;

                dgvAllInternationalDrivingLicenseApplications.Columns[3].HeaderText = "L.License ID";
                dgvAllInternationalDrivingLicenseApplications.Columns[3].Width = 130;

                dgvAllInternationalDrivingLicenseApplications.Columns[4].HeaderText = "Issue Date";
                dgvAllInternationalDrivingLicenseApplications.Columns[4].Width = 180;

                dgvAllInternationalDrivingLicenseApplications.Columns[5].HeaderText = "Expiration Date";
                dgvAllInternationalDrivingLicenseApplications.Columns[5].Width = 180;

                dgvAllInternationalDrivingLicenseApplications.Columns[6].HeaderText = "Is Active";
                dgvAllInternationalDrivingLicenseApplications.Columns[6].Width = 120;

            }
        }

        private void btnAddNewInternationalDrivingLicense_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplications frm = new frmInternationalLicenseApplications();
            frm.ShowDialog();
            //refresh
            frmListInternationalLicenseApplications_Load(null, null);
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvAllInternationalDrivingLicenseApplications.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterByValue.Visible = false;
            }

            else

            {

                txtFilterByValue.Visible = (cbFilterBy.Text != "None");

                if (cbFilterBy.Text == "None")
                {
                    txtFilterByValue.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    txtFilterByValue.Enabled = true;

                txtFilterByValue.Text = "";
                txtFilterByValue.Focus();
            }
        }

        private void txtFilterByValue_TextChanged(object sender, EventArgs e)
        {


            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    }
                    ;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterByValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvAllInternationalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }



            _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterByValue.Text.Trim());

            lblRecordsNumber.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterByValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int DriverID = (int)dgvAllInternationalDrivingLicenseApplications.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            string NationalNo = clsPerson.Find(PersonID).NationalNo;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(NationalNo);
            frm.ShowDialog();


        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvAllInternationalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmInternationalDriverInfo frm = new frmInternationalDriverInfo(InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
