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
using DVLD_Project.Properties;

namespace DVLD_Project
{
    public partial class ctrlScheduleTest : UserControl
    {
        private enum enMode {AddNew = 0, Update = 1};

        enMode _Mode = enMode.AddNew;
        private enum enCreationMode { FirstTimeTestSchedule = 1 , RetakeTestTimeSchedule = 2};

        enCreationMode _CreationMode = enCreationMode.FirstTimeTestSchedule;

        clsLocalDrivingLicenseApplication _LocalDrivingLicensesApplication;

        int _LocalDrivingLicenseApplicationID;

        clsTestAppointment _TestAppointment;

        int _TestAppointmentID;

        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public clsTestType.enTestType TestTypeID 
        {
            get 
            { 
                return _TestTypeID; 
            }
            set 
            {
                _TestTypeID = value;

                switch( _TestTypeID )
                {
                    case clsTestType.enTestType.VisionTest:
                        pbTestImage.Image = Resources.Vision_512;
                        gbTestType.Text = "Vision Test";
                        break;
                    case clsTestType.enTestType.WrittenTest:
                        pbTestImage.Image = Resources.Written_Test_512;
                        gbTestType.Text = "Vision Test";
                        break;
                    case clsTestType.enTestType.StreetTest:
                        pbTestImage.Image = Resources.driving_test_512;
                        gbTestType.Text = "Vision Test";
                        break;
                }
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public void LoadScheduleTestInfo(int LocalDrivingLicenseApplicationID, int TestAppointmentID)
        {
            if(TestAppointmentID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;

            _LocalDrivingLicensesApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicensesApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if(_LocalDrivingLicensesApplication.DoesAttendTestType(_TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTestTimeSchedule;
            }
            else
            {
                _CreationMode = enCreationMode.FirstTimeTestSchedule;
            }

            if(_CreationMode == enCreationMode.RetakeTestTimeSchedule)
            {
                lblRetakeTestApplicationFees.Text = clsApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.RetakeTest).ApplicationTypesFees.ToString();
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestApplicationID.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeTestApplicationFees.Text = "0";
                lblRetakeTestApplicationID.Text = "N/A";
            }

            lblDLAppID.Text = _LocalDrivingLicensesApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDLClass.Text = _LocalDrivingLicensesApplication.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicensesApplication.GetFullApplicantName;
            lblFees.Text = clsTestType.FindTestTypeByID(_TestTypeID).TestTypeFees.ToString();
            lblTrials.Text = _LocalDrivingLicensesApplication.CountTotalTestTrialsPerTestType(_TestTypeID).ToString();

            if (_Mode == enMode.AddNew)
            {
                dateTimePicker1.MinDate = DateTime.Now;
                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                //Code For TestAppointment : 

                _TestAppointment = clsTestAppointment.FindTestAppointmentByID(_TestAppointmentID);

                if (_TestAppointment == null)
                {
                    MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                }

                if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                {
                    dateTimePicker1.MinDate = DateTime.Now;
                }
                else
                {
                    dateTimePicker1.MinDate = _TestAppointment.AppointmentDate;
                }

                dateTimePicker1.Value = _TestAppointment.AppointmentDate;

                lblFees.Text = _TestAppointment.PaidFees.ToString();

                if (_TestAppointment.RetakeTestApplicationID == -1)
                {
                    lblRetakeTestApplicationFees.Text = "0";
                    lblRetakeTestApplicationID.Text = "N/A";
                }
                else
                {
                    gbRetakeTestInfo.Enabled = true;
                    lblRetakeTestApplicationFees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                    lblRetakeTestApplicationID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                }
            }

            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeTestApplicationFees.Text)).ToString();

            if (_TestAppointment.isLocked)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Person Already Sat For This Test, Appointment Locked!";
                dateTimePicker1.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                lblMessage.Visible = false;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Code to Handle RetakeTest Application :


            if (_CreationMode == enCreationMode.RetakeTestTimeSchedule && _Mode == enMode.AddNew)
            {
                clsApplication NewApplication = new clsApplication();

                NewApplication.ApplicantPersonID = _LocalDrivingLicensesApplication.ApplicantPersonID;
                NewApplication.ApplicationDate = DateTime.Now;
                NewApplication.ApplicationTypeID = (int)clsApplicationType.enApplicationType.RetakeTest;
                NewApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                NewApplication.LastStatusDate = DateTime.Now;
                NewApplication.PaidFees = clsApplicationType.FindApplicationTypeByID((int)clsApplicationType.enApplicationType.RetakeTest).ApplicationTypesFees;
                NewApplication.CreatedByUserID = clsGlobal.LoggedInUser.UserID;

                if(!NewApplication.Save())
                {
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _TestAppointment.RetakeTestApplicationID = NewApplication.ApplicationID;

            }





            //Code to handle and save test appointment
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dateTimePicker1.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.LoggedInUser.UserID;

            if(_TestAppointment.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
