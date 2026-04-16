using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode = enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte IsActive { get; set; }

        public clsPerson PersonInfo;

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = 0;
            this.UserName = "";
            this.Password = "";
            this.IsActive = 0;
            _Mode = enMode.AddNew;   
        }

        public clsUser(int UserID, int PersonID, string UserName, string Password, byte IsActive)
        {
            this.UserID=UserID;
            this.PersonID=PersonID;
            this.UserName=UserName;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.Password=Password;
            this.IsActive = IsActive;
            _Mode = enMode.Update;
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = 0; string UserName = ""; string Password = ""; byte IsActive = 0;

            if(clsUserDataAccess.FindUserByID(UserID,ref PersonID, ref UserName,ref Password, ref IsActive))
            {
               return new clsUser(UserID,PersonID,UserName,Password,IsActive);
            }
            else
            {
                return null; 
            }
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = 0; string UserName = ""; string Password = ""; byte IsActive = 0;

            if (clsUserDataAccess.FindUserByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = 0, PersonID = 0; byte IsActive = 0;

            if (clsUserDataAccess.FindUserByUserNameAndPassword(ref PersonID, ref UserID, UserName, Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }
        private  bool _AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserDataAccess.DeleteUser(UserID);
        }

        public static bool IsUserExists(int UserID)
        {
            return clsUserDataAccess.IsUserExists(UserID);
        }

        public static bool IsPersonHasUser(int PersonID)
        {
            return clsUserDataAccess.IsPersonHasUser(PersonID);
        }
        public static DataTable GetUsersList()
        {
            return clsUserDataAccess.GetAllUsers();
        }


        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    case enMode.Update:
                    return _UpdateUser();

            }
            return false;
        }

    }
}
