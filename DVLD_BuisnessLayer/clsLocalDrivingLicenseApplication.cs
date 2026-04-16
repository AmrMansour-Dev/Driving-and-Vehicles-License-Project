using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode {AddNew = 1, Update = 2 }

        enMode _Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID { get; set; }

        public clsLicenseClass LicenseClassInfo;

        public int LicenseClassID { get; set; }

        public string GetFullApplicantName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;

            _Mode = enMode.AddNew;
        }

        public clsLocalDrivingLicenseApplication( int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID, int ApplicantPersonID, 
            DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID )
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID= LicenseClassID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(LicenseClassID);
            _Mode = enMode.Update;

        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications();
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID,this.ApplicationID,this.LicenseClassID);
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.AddNewLocalDrivingLicenseApplication(this.ApplicationID,this.LicenseClassID);

            return (this.ApplicationID != -1);
        }

        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = 0;
            int LicenseClassID = 0;


            if (clsLocalDrivingLicenseApplicationsDataAccess.FindLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                clsApplication BaseApplication = clsApplication.FindBaseApplicationByID(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID,LicenseClassID,BaseApplication.ApplicantPersonID,
                    BaseApplication.ApplicationDate,BaseApplication.ApplicationTypeID,BaseApplication.ApplicationStatus,BaseApplication.LastStatusDate,BaseApplication.PaidFees,
                    BaseApplication.CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public static bool GetLicenseIDForApplication(int ApplicationID)
        {
            return (clsLocalDrivingLicenseApplicationsDataAccess.GetLicenseIDForApplication(ApplicationID) != -1);
        }

        public int GetPassedTestsCount()
        {
            return clsTest.GetPassedTestsCount(this.LocalDrivingLicenseApplicationID);
        }


        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.IsThereAnActiveScheduledTest((int)TestTypeID, this.LocalDrivingLicenseApplicationID);
        }

        public bool HasPassedTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.HasPassedTestType(this.LocalDrivingLicenseApplicationID,(int)TestTypeID);

        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.HasAttendTestType(this.LocalDrivingLicenseApplicationID,TestTypeID);
        }

        public int CountTotalTestTrialsPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentsDataAccess.CountTotalTestTrialsPerTestType((int)TestTypeID, this.LocalDrivingLicenseApplicationID);
        }
        public bool Save()
        {
            //here we can access the enum directly from class without making it static
            //(specially for enums only) but for properties, functions and variables no we can not

            //then after get the mode we cast the current mode here to the same type of base class.
            base.Mode = (clsApplication.enMode)_Mode;

            if(!base.Save())
            {
                return false;
            }

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        _Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();
            }
            return false;
        }

        public int GetActiveLicenseIDByPersonID()
        {
            return clsLicenseDataAccess.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

        public bool HasIssuedLicense()
        {
            return (GetActiveLicenseIDByPersonID() != -1);
        }

        public bool Delete()
        {
            bool IsLDLAppDeleted = false;
            bool IsBaseAppDeleted = false;

            IsLDLAppDeleted = clsLocalDrivingLicenseApplicationsDataAccess.Delete(this.LocalDrivingLicenseApplicationID);

            if (!IsLDLAppDeleted)
            {
                return false;
            }

            IsBaseAppDeleted = base.Delete(this.ApplicationID);

            return IsBaseAppDeleted;




        }
    }
}
