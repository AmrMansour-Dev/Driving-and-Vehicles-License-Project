using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsApplicationTypesDataAccess
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT ApplicationTypeID as ID, ApplicationTypeTitle as Title, ApplicationFees as Fees
                                    FROM ApplicationTypes";

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

        public static bool UpdateApplicationTypesTitleAndOrFees(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationFees)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE ApplicationTypes
                        SET ApplicationTypeTitle = @ApplicationTypeTitle
                       ,ApplicationFees = @ApplicationFees
                        WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("ApplicationFees", ApplicationFees);

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

        public static int AddNewApplicationType(string ApplicationTypeTitle, float ApplicationFees)
        {
            int ApplicationTypeID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO ApplicationTypes(ApplicationTypeTitle,ApplicationFees) VALUES (@ApplicationTypeTitle,@ApplicationFees);
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("ApplicationFees", ApplicationFees);
            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    ApplicationTypeID = ID;
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return ApplicationTypeID;
        }
        public static bool FindApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    ApplicationTypeTitle = (string)Reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToSingle(Reader["ApplicationFees"]);


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
