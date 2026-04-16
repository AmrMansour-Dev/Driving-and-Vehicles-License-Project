using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 }

         enMode _Mode = enMode.AddNew;
        public int TestAppointmentID { get; set; }

        public int TestID
        {
            get { return GetTestID(); }
        }
        public clsTestType.enTestType TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isLocked { get; set; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestApplicationInfo { get; set; }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.isLocked = false;
            this.RetakeTestApplicationID = -1;
            _Mode = enMode.AddNew;
        }

        public clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestType, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
           float PaidFees, int CreatedByUserID, bool isLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestType;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.isLocked = isLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestApplicationInfo = clsApplication.FindBaseApplicationByID(RetakeTestApplicationID);
            _Mode = enMode.Update;
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentsDataAccess.GetAllTestAppointments();
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsDataAccess.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                this.PaidFees, this.CreatedByUserID, this.isLocked, this.RetakeTestApplicationID);
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsDataAccess.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                this.PaidFees,this.CreatedByUserID,this.isLocked,this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        public static clsTestAppointment FindTestAppointmentByID(int TestAppointmentID)
        {
            int TestTypeID = 0;
            int LocalDrivingLicenseApplicationID = 0;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = 0;
            bool isLocked = false;
            int RetakeTestApplicationID = -1;

            if (clsTestAppointmentsDataAccess.FindTestAppointmentByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate,
               ref PaidFees,ref CreatedByUserID, ref isLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType) TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, isLocked, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }
        }


        public  DataTable GetLocalDrivingApplicationTestAppointmentPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentsDataAccess.GetLocalDrivingApplicationTestAppointmentPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static DataTable GetLocalDrivingApplicationTestAppointmentPerTestType(int LocalDrivingLicenseApplicationID ,clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentsDataAccess.GetLocalDrivingApplicationTestAppointmentPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public int GetTestID()
        {
            return clsTestAppointmentsDataAccess.GetTestID(this.TestAppointmentID);
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        _Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateTestAppointment();
            }
            return false;
        }
    }
}
