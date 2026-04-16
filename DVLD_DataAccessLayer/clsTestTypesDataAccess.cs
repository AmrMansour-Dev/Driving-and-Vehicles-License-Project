using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_DataAccessLayer
{
    public class clsTestTypesDataAccess
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT TestTypeID as ID, TestTypeTitle as Title, TestTypeDescription as Description, TestTypeFees as Fees
                                    FROM TestTypes";

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

        public static bool UpdateTestTypesTitleAndOrFees(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE TestTypes
                        SET TestTypeTitle = @TestTypeTitle
                       ,TestTypeDescription = @TestTypeDescription
                       ,TestTypeFees = @TestTypeFees
                        WHERE TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("TestTypeFees", TestTypeFees);


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

        public static int AddNewTestType(string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            int ApplicationTypeID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO TestTypes(TestTypeTitle, TestTypeDescription, TestTypeFees) VALUES (@TestTypeTitle, @TestTypeDescription, @TestTypeFees);
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("TestTypeFees", TestTypeFees);

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


        public static bool FindTestTypeByID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref float TestTypeFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestTypeID = (int)Reader["TestTypeID"];
                    TestTypeTitle = (string)Reader["TestTypeTitle"];
                    TestTypeDescription = (string)Reader["TestTypeDescription"];
                    TestTypeFees = Convert.ToSingle(Reader["TestTypeFees"]);

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
