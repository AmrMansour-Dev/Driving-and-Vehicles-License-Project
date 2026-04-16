using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DVLD_BuisnessLayer;

namespace DVLD_Classess
{
    public class clsGlobal
    {
        public static bool GetUserCredentials(ref string UserName, ref string Password)
        {
            string FilePath = @"C:\Users\Amr Mansour\Desktop\LoginCredits.txt";

            string Line = File.ReadAllText(FilePath);

            string[] Parts = Line.Split(new string[] {"#//#"}, StringSplitOptions.None);

            UserName = Parts[0];
            Password = Parts[1];

            return true;
        }

        public static clsUser LoggedInUser;
    }
}
