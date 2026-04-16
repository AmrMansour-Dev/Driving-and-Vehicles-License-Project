using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsTestType
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        public enum enMode { AddNew = 0, Update = 1 };

        enMode _Mode = enMode.AddNew;

        clsTestType()
        {
            this.TestTypeID = enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
            _Mode = enMode.AddNew;
        }

        clsTestType(enTestType TestTypeID, string TestTypeTitle,  string TestTypeDescription, float TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            _Mode = enMode.Update;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }

        private bool _UpdateTestTypesTitleAndOrFees()
        {
            return clsTestTypesDataAccess.UpdateTestTypesTitleAndOrFees((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription,this.TestTypeFees);
        }

        private bool _AddNewTestType()
        {
            this.TestTypeID = (enTestType)clsTestTypesDataAccess.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeTitle != "");
        }

        public static clsTestType FindTestTypeByID(enTestType TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            float TestTypeFees = 1;

            if (clsTestTypesDataAccess.FindTestTypeByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
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
                    if (_AddNewTestType())
                    {
                        _Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateTestTypesTitleAndOrFees();
            }
            return false;
        }
    }
}
