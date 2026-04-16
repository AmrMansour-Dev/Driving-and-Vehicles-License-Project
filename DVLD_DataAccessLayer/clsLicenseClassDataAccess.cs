using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassDataAccess
    {
        public static DataTable GetAllLicenseClassess()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select * from LicenseClasses order by LicenseClassID ASC";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    DT.Load(Reader);
                }

                Reader.Close();
            }
            catch
            {

            }

            finally
            {
                Connection.Close();
            }
            return DT;
        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge,
            byte DefaultValidityLength, float ClassFees)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE LicenseClasses
                        SET ClassName = @ClassName
                       ,ClassDescription = @ClassDescription
                       ,MinimumAllowedAge = @MinimumAllowedAge
                       ,DefaultValidityLength = @DefaultValidityLength
                       ,ClassFees = @ClassFees
                        WHERE LicenseClassID = @LicenseClassID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("ClassName", ClassName);
            Command.Parameters.AddWithValue("ClassDescription", ClassDescription);
            Command.Parameters.AddWithValue("MinimumAllowedAge", MinimumAllowedAge);
            Command.Parameters.AddWithValue("DefaultValidityLength", DefaultValidityLength);
            Command.Parameters.AddWithValue("ClassFees", ClassFees);



            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);

        }


        public static int AddNewLicenseClass(string ClassName, string ClassDescription, byte MinimumAllowedAge,
            byte DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO LicenseClasses(ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                           VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ClassName", ClassName);
            Command.Parameters.AddWithValue("ClassDescription", ClassDescription);
            Command.Parameters.AddWithValue("MinimumAllowedAge", MinimumAllowedAge);
            Command.Parameters.AddWithValue("DefaultValidityLength", DefaultValidityLength);
            Command.Parameters.AddWithValue("ClassFees", ClassFees);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    LicenseClassID = ID;
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return LicenseClassID;
        }


        public static bool FindLicenseClassByID(int LicenseClassID, ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge,
         ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    ClassName = (string)Reader["ClassName"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinimumAllowedAge = (byte)(Reader["MinimumAllowedAge"]);
                    DefaultValidityLength = (byte)(Reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle((Reader["ClassFees"]));

                }
                else
                {
                    IsFound = false;
                }

                Reader.Close();
            }

            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;


        }

        public static bool FindLicenseClassByClassName(string ClassName, ref int LicenseClassID, ref string ClassDescription, ref byte MinimumAllowedAge,
        ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    ClassName = (string)Reader["ClassName"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinimumAllowedAge = (byte)(Reader["MinimumAllowedAge"]);
                    DefaultValidityLength = (byte)(Reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle((Reader["ClassFees"]));

                }
                else
                {
                    IsFound = false;
                }

                Reader.Close();
            }

            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;


        }
    }
}
