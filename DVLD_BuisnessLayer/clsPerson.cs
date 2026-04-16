using System;
using System.Data;
using System.Runtime.CompilerServices;
using DVLD_DataAccessLayer;


namespace DVLD_BuisnessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { 
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public DateTime DateofBirth { get; set; }

        public string GetGendorString(byte Gendor)
        {
            switch (Gendor)
            {
                case 0:
                    return "Male";
                case 1:
                    return "Female";
                default:
                    return "Fsa";
            }
        }

        public string GenderString
        {
            get { return GetGendorString(Gendor); }
        }
        public byte Gendor {  get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }   

        enMode Mode = enMode.AddNew;

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateofBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddNew;
        }
        clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth
            , byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateofBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }

        public static clsPerson Find(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth  = DateTime.Now;
            byte Gendor = 0;
            int NationalityCountryID = 0;

            if(clsPersonDataAccess.GetPersonInfoByID(ID,ref NationalNo,ref FirstName,ref SecondName,ref ThirdName,ref LastName, ref DateOfBirth
                , ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson FindByNationalNo(string NationalNo)
        {
            int ID = 0; string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            int NationalityCountryID = 0;

            if (clsPersonDataAccess.GetPersonInfoByNationalNo(NationalNo, ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth
                , ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllPersons()
        {
            return clsPersonDataAccess.GetAllPeople();
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.DateofBirth, this.Gendor, this.Address,this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonDataAccess.UpdatePerson(this.PersonID,this.NationalNo, this.FirstName,this.SecondName,this.ThirdName,this.LastName,
                this.DateofBirth,this.Gendor, this.Address,this.Phone,this.Email,this.NationalityCountryID,this.ImagePath);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    case enMode.Update:

                    return _UpdatePerson();
            }
            return false;
        }

        
        public static bool Delete(int PersonID)
        {
            //clsPerson P1 = Find(PersonID);
            
            if(clsPersonDataAccess.DeletePerson(PersonID))
            {
                return true;
            }

            return false;
        }
    }
}
