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
using DVLD_Project.Properties;
using static DVLD_BuisnessLayer.clsTestType;

namespace DVLD_Project
{
    public partial class frmListTestAppointments : Form
    {
        int _LDLApplicationID = 0;
        clsTestType.enTestType _TestTypeID;
        DataTable _dtTestAppointments;
        public frmListTestAppointments(int lDLApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _LDLApplicationID = lDLApplicationID;
            _TestTypeID = TestTypeID;

        }

        private void _RefreshAppointmentsList()
        {

            _dtTestAppointments = clsTestAppointment.GetLocalDrivingApplicationTestAppointmentPerTestType(_LDLApplicationID, _TestTypeID);

            dgvTestAppointmets.DataSource = _dtTestAppointments;

            lblRecordsNumber.Text = dgvTestAppointmets.RowCount.ToString();

        }

        public void LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTitleImage.Image = Properties.Resources.Vision_512;
                    lblTitle.Text = "Vision Test Appointments";
                    break;

                case clsTestType.enTestType.WrittenTest:
                    pbTitleImage.Image = Properties.Resources.Written_Test_512;
                    lblTitle.Text = "Written Test Appointments";

                    break;

                case clsTestType.enTestType.StreetTest:
                    pbTitleImage.Image = Properties.Resources.driving_test_512;
                    lblTitle.Text = "Driving Test Appointments";
                    break;

            }

        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfo(_LDLApplicationID);

            _dtTestAppointments = clsTestAppointment.GetLocalDrivingApplicationTestAppointmentPerTestType(_LDLApplicationID, _TestTypeID);

            dgvTestAppointmets.DataSource = _dtTestAppointments;

            if(dgvTestAppointmets.Rows.Count > 0 )
            {
                dgvTestAppointmets.Columns["TestAppointmentID"].HeaderText = "Appointment ID";
                dgvTestAppointmets.Columns["AppointmentDate"].HeaderText = "Appointment Date";
                dgvTestAppointmets.Columns["PaidFees"].HeaderText = "Paid Fees";
                dgvTestAppointmets.Columns["IsLocked"].HeaderText = "Is Locked";
                dgvTestAppointmets.Columns["AppointmentDate"].Width = 200;
            }

            lblRecordsNumber.Text = dgvTestAppointmets.RowCount.ToString();


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LDLApplicationID);

            if(localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(localDrivingLicenseApplication.HasPassedTestType(_TestTypeID))
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID, _TestTypeID);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointmets.CurrentRow.Cells[0].Value;


            frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID, _TestTypeID, TestAppointmentID);

            frm.ShowDialog();

            _RefreshAppointmentsList();

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointmets.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID,_TestTypeID);
            frm.ShowDialog();
            _RefreshAppointmentsList();
            frmListTestAppointments_Load(null, null);
        }
    }
}
