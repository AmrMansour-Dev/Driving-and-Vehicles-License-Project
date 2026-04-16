using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsInternationalLicense : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;

        public clsDriver DriverInfo;
        public int InternationalLicenseID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
            this.ApplicationID = -1;
            _Mode = enMode.AddNew;

        }

        public clsInternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID,int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            this.ApplicationID =ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID  = InternationalLicenseID;
            this.DriverID= DriverID;
            this.DriverInfo = clsDriver.FindByDriverID(DriverID);
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate=ExpirationDate;
            this.IsActive =IsActive;
            _Mode = enMode.Update;

        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseDataAccess.GetDriverInternationalLicenses(DriverID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseDataAccess.GetAllInternationalLicenses();

        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseDataAccess.UpdateInternationalLicense(this.InternationalLicenseID,this.ApplicationID,this.DriverID,this.IssuedUsingLocalLicenseID,
                this.IssueDate,this.ExpirationDate,this.IsActive,this.CreatedByUserID);
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseDataAccess.AddNewInternationalLicense(this.ApplicationID, this.DriverID,this.IssuedUsingLocalLicenseID,this.IssueDate,
                this.ExpirationDate,this.IsActive,this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        public static clsInternationalLicense FindInternationalLicensebyID(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1; int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true; int CreatedByUserID = 1;


            if (clsInternationalLicenseDataAccess.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate,
                ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                clsApplication BaseApplication = clsApplication.FindBaseApplicationByID(ApplicationID);

                return new clsInternationalLicense(BaseApplication.ApplicationID, BaseApplication.ApplicantPersonID, BaseApplication.ApplicationDate,
                    BaseApplication.ApplicationStatus, BaseApplication.LastStatusDate, BaseApplication.PaidFees, BaseApplication.CreatedByUserID, InternationalLicenseID,
                    DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive);
            }
            else
            {
                return null;
            }


        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseDataAccess.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

        public bool Save()
        {

            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInternationalLicense();

            }

            return false;
        }
    }
}
