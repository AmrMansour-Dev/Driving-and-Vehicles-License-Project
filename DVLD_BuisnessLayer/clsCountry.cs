using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BuisnessLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry FindCountryByID(int CountryID)
        {
            string CountryName = "";
            if(clsCountryDataAccess.GetCountryInfoByID(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);

            }
            else
            {
                return null;
            }
        }

        public static clsCountry FindCountrybyName(string CountryName)
        {
            int CountryID = 0;
            if (clsCountryDataAccess.GetCountryInfoByName(CountryName, ref CountryID))
            {
                return new clsCountry(CountryID, CountryName);

            }
            else
            {
                return null;
            }
        }
        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }
    }
}
