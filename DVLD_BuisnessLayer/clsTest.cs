using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }
        public enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode = enMode.AddNew;

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;
            _Mode = enMode.AddNew;
        }

        public clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.TestAppointmentInfo = clsTestAppointment.FindTestAppointmentByID(TestAppointmentID);
            _Mode = enMode.Update;
        }

        public static DataTable GetAllTests()
        {
            return clsTestDataAccess.GetAllTests();
        }

        private bool _UpdateTest()
        {
            return clsTestDataAccess.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes,
                this.CreatedByUserID);
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestDataAccess.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return (this.TestID != -1);
        }

        public static clsTest FindTestByID(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            if (clsTestDataAccess.FindTestByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes,
               ref CreatedByUserID))
            {
                return new clsTest(TestID,TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            int TestCount = clsTestDataAccess.GetPassedTestsCount(LocalDrivingLicenseApplicationID);

            return TestCount;
        }

        public static bool HasAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestDataAccess.DoesAttendTest(LocalDrivingLicenseApplicationID,(int)TestTypeID);
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        _Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateTest();
            }
            return false;
        }
    }
}
