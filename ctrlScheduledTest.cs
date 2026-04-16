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
    public partial class ctrlScheduledTest : UserControl
    {
        int _TestAppointmentID;

        clsTestAppointment _TestAppointmet;

        clsTestType.enTestType _TestTypeID;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        int _LocalDrivingLicenseApplicationID;

        int _TestID = -1;

        public int TestID
        {
            get { return _TestID; }
        }
        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                switch(_TestTypeID)
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

        public void LoadData(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;


            _TestAppointmet = clsTestAppointment.FindTestAppointmentByID(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointmet == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointmet.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointmet.LocalDrivingLicenseApplicationID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDLAppID.Text = _TestAppointmet.LocalDrivingLicenseApplicationID.ToString();
            lblName.Text = _LocalDrivingLicenseApplication.GetFullApplicantName;
            lblDLClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblTrials.Text = _LocalDrivingLicenseApplication.CountTotalTestTrialsPerTestType(_TestTypeID).ToString();
            lblDate.Text = _TestAppointmet.AppointmentDate.ToShortDateString();
            lblFees.Text = _TestAppointmet.PaidFees.ToString();
            lblTestID.Text = _TestAppointmet.TestID == -1 ? "Not Taken Yet" : _TestAppointmet.TestID.ToString();


        }
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }
    }
}
