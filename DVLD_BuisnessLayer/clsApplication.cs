using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsApplication
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public clsApplicationType ApplicationTypeInfo;

        public clsPerson PersonInfo;

        public clsUser UserInfo;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }


        public enum enMode { AddNew = 1, Update = 2 };

        public enMode Mode = enMode.AddNew;

        public string StatusString
        {
            get
            {
                switch(ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    default:
                        return "Unknown";
                }
            }
        }

        public string GetFullApplicantName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = 0;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindByUserID(CreatedByUserID); 
            this.ApplicationTypeInfo = clsApplicationType.FindApplicationTypeByID(ApplicationTypeID);
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);


            Mode = enMode.Update;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationsDataAccess.GetAllApplications();
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsDataAccess.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsDataAccess.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        public static clsApplication FindBaseApplicationByID(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = 0;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;


            if (clsApplicationsDataAccess.FindBaseApplicationByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
               ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,(enApplicationStatus) ApplicationStatus, LastStatusDate
                    , PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public bool CancelApplication()
        {
            return clsApplicationsDataAccess.CancelApplication(ApplicationID);
        }

        public bool UpdateStatusToComplete()
        {
            return clsApplicationsDataAccess.UpdateApplicationStatus(this.ApplicationID, 3);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateApplication();
            }
            return false;
        }

        public bool Delete(int ApplicationID)
        {


            if (clsApplicationsDataAccess.Delete(ApplicationID))
            {
                return  true;
            }
            return false; 
        }
    }
}
