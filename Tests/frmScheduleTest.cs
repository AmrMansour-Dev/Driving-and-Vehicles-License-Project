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
    public partial class frmScheduleTest : Form
    {
        int _LocalDrivingLicensesApplicationID;

        clsTestType.enTestType _TestTypeID;

        int _TestAppointmentID;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID,clsTestType.enTestType TestTypeID, int TestAppointmetID = -1)
        {
            _TestTypeID = TestTypeID;

            _LocalDrivingLicensesApplicationID = LocalDrivingLicenseApplicationID;

            _TestAppointmentID = TestAppointmetID;

            InitializeComponent();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadScheduleTestInfo(_LocalDrivingLicensesApplicationID,_TestAppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
