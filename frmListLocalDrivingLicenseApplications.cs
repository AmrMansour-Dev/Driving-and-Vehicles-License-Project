using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD_Project
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private static DataTable _OriginalLocalDrivingLicenseApplicationsTable = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

        private void _RefreshLocalDrivingLicenseApplicationsList()
        {
            _OriginalLocalDrivingLicenseApplicationsTable = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            dgvAllLocalDrivingLicenseApplications.DataSource = _OriginalLocalDrivingLicenseApplicationsTable;

            lblRecordsNumber.Text = dgvAllLocalDrivingLicenseApplications.RowCount.ToString();
        }
        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _RefreshLocalDrivingLicenseApplicationsList();

            dgvAllLocalDrivingLicenseApplications.Columns["ClassName"].Width = 200;
            dgvAllLocalDrivingLicenseApplications.Columns["FullName"].Width = 250;


            dgvAllLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.AppID";
            dgvAllLocalDrivingLicenseApplications.Columns["ClassName"].HeaderText = "Driving Class";
            dgvAllLocalDrivingLicenseApplications.Columns["PassedTestCount"].HeaderText = "PassedTests";
 



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
            //            L.D.L.AppID
            //NationalNo.
            //FullName
            //Status

            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "NationalNo.":
                    FilterColumn = "NationalNo";
                    break;
                case "FullName":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
            }

            if(cbFilterBy.Text == "None" || txtFilterByValue.Text == "")
            {
                _OriginalLocalDrivingLicenseApplicationsTable.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvAllLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            if(cbFilterBy.Text == "L.D.L.AppID")
            {
                _OriginalLocalDrivingLicenseApplicationsTable.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterByValue.Text);
            }
            else
            {
                _OriginalLocalDrivingLicenseApplicationsTable.DefaultView.RowFilter = string.Format("{0} Like '{1}%'", FilterColumn, txtFilterByValue.Text);

            }

            lblRecordsNumber.Text = dgvAllLocalDrivingLicenseApplications.RowCount.ToString();

        }

        private void txtFilterByValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "L.D.L.AppID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAddNewLocalDrivingLicense_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(-1);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (LDLApp != null)
            {
                if (MessageBox.Show("Are You Sure You Want to Cancel This Application ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (LDLApp.CancelApplication())
                    {
                        MessageBox.Show("Application Cancelled Successfully", "Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Can Not Cancel Application", "Failed");
                    }


                    _RefreshLocalDrivingLicenseApplicationsList();

                }
            }

        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void cmsDGV_Opening(object sender, CancelEventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            int TotalPassedTestsCount = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);


            bool IssuedLicense = LocalDrivingLicenseApplication.HasIssuedLicense();

            showLicenseToolStripMenuItem.Enabled = IssuedLicense;
            editApplicationToolStripMenuItem.Enabled = !IssuedLicense && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            cancelApplicationToolStripMenuItem.Enabled = LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;
            deleteApplicationToolStripMenuItem.Enabled = LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;



            issueDrivingLicenseToolStripMenuItem.Enabled = !IssuedLicense && (TotalPassedTestsCount == 3);



            bool HasPassedVisionTest = LocalDrivingLicenseApplication.HasPassedTestType(clsTestType.enTestType.VisionTest);
            bool HasPassedWrittenTest = LocalDrivingLicenseApplication.HasPassedTestType(clsTestType.enTestType.WrittenTest);
            bool HasPassedStreetTest = LocalDrivingLicenseApplication.HasPassedTestType(clsTestType.enTestType.StreetTest);

            scheduleTestsMenu.Enabled = (!HasPassedVisionTest || !HasPassedWrittenTest || !HasPassedStreetTest && LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (scheduleTestsMenu.Enabled )
            {
                scheduleVisionTestMenuItem.Enabled = !HasPassedVisionTest;
                scheduleWrittenTestMenuItem.Enabled = !HasPassedWrittenTest && HasPassedVisionTest;
                scheduleDrivingTestMenuItem.Enabled = !HasPassedStreetTest && HasPassedVisionTest && HasPassedWrittenTest;
            }
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmIssueDrivingLicenseFirstTime frm = new frmIssueDrivingLicenseFirstTime(LocalDrivingLicenseApplicationID);

            frm.ShowDialog();

            frmListLocalDrivingLicenseApplications_Load(null,null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID).GetActiveLicenseIDByPersonID();
           
            if (LicenseID != -1)
            {
                frmShowLicense frm = new frmShowLicense(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);

            frm.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LDLAppID);

            if (LDLApp != null)
            {
                if (MessageBox.Show($"Are You Sure You Want Delete This Application ?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (LDLApp.Delete())
                    {
                        MessageBox.Show("Application Deleted Successfully", "Successfull");
                    }
                    else
                    {
                        MessageBox.Show("Can Not Delete Application as It Has Data Linked To It", "Failed");

                    }

                }
            }
            else
            {
                MessageBox.Show("No Application With This ID","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            frmListLocalDrivingLicenseApplications_Load(null,null);

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(LDLAppID);

            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells[2].Value.ToString();

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(NationalNo);

            frm.ShowDialog();
        }
    }
}
