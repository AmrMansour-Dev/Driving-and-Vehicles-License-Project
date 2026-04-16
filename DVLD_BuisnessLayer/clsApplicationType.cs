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
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationTypesFees { get; set; }

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        }
        public enum enMode { AddNew = 0, Update = 1 };

        enMode _Mode = enMode.AddNew;

        clsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationTypesFees = 0;
            _Mode = enMode.AddNew;
        }

        clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationTypesFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypesFees = ApplicationTypesFees;
            _Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }

        private bool _UpdateApplicationTypesTitleAndOrFees()
        {
            return clsApplicationTypesDataAccess.UpdateApplicationTypesTitleAndOrFees(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationTypesFees);
        }

        private bool _AddNewApplicationType()
        {
            this.ApplicationTypeID = clsApplicationTypesDataAccess.AddNewApplicationType(this.ApplicationTypeTitle,this.ApplicationTypesFees);

            return (this.ApplicationTypeID != -1);
        }

        public static clsApplicationType FindApplicationTypeByID(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            float ApplicationTypesFees = 1;

            if (clsApplicationTypesDataAccess.FindApplicationTypeByID(ApplicationTypeID,ref ApplicationTypeTitle,ref ApplicationTypesFees))
            {
                return new clsApplicationType(ApplicationTypeID,ApplicationTypeTitle,ApplicationTypesFees);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewApplicationType())
                    {
                        _Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    case enMode.Update:

                    return _UpdateApplicationTypesTitleAndOrFees();
            }
            return false;
        }

    }
}
