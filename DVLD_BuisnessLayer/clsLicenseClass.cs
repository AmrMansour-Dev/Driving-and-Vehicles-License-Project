using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public enum enMode { AddNew = 0, Update = 1 };

        enMode _Mode = enMode.AddNew;

         clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;
            _Mode = enMode.AddNew;
        }

        clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            _Mode = enMode.Update;
        }

        public static DataTable GetAllLicenseClassess()
        {
            return clsLicenseClassDataAccess.GetAllLicenseClassess();
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassDataAccess.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength,this.ClassFees);
        }

        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassDataAccess.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength,this.ClassFees);

            return (this.LicenseClassID != -1);
        }

        public static clsLicenseClass FindLicenseClassByID(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 1;
            byte DefaultValidityLength = 1;
            float ClassFees = 1;


            if (clsLicenseClassDataAccess.FindLicenseClassByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge,
               ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }

        public static clsLicenseClass FindLicenseClassByClassName(string ClassName)
        {
            int LicenseClassID = 0;
            string ClassDescription = "";
            byte MinimumAllowedAge = 1;
            byte DefaultValidityLength = 1;
            float ClassFees = 1;


            if (clsLicenseClassDataAccess.FindLicenseClassByClassName(ClassName, ref LicenseClassID, ref ClassDescription, ref MinimumAllowedAge,
               ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {
                        _Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateLicenseClass();
            }
            return false;
        }
    }
}
