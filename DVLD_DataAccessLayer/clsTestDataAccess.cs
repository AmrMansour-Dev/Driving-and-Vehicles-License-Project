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
    public class clsTestDataAccess
    {
        public static DataTable GetAllTests()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * from Tests";

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


        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Tests
                        SET TestAppointmentID = @TestAppointmentID
                       ,TestResult = @TestResult
                       ,Notes = @Notes
                       ,CreatedByUserID = @CreatedByUserID
                        WHERE TestID = @TestID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("TestID", TestID);
            Command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("TestResult", TestResult);
            if (Notes != "")
            {
                Command.Parameters.AddWithValue("Notes", Notes);
            }
            else
            {
                Command.Parameters.AddWithValue("Notes", System.DBNull.Value);

            }
            Command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);





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

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Tests(TestAppointmentID, TestResult, Notes, CreatedByUserID) 
                             VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);

							 Update TestAppointments
							 Set IsLocked = 1 
							 Where TestAppointmentID = @TestAppointmentID
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("TestResult", TestResult);
            if (Notes != "")
            {
                Command.Parameters.AddWithValue("Notes", Notes);
            }
            else
            {
                Command.Parameters.AddWithValue("Notes", System.DBNull.Value);

            }
            Command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TestID = ID;
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return TestID;
        }


        public static bool FindTestByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Tests WHERE TestID = @TestID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestID = (int)Reader["TestID"];
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult = (bool)Reader["TestResult"];
                    if (Reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }

                    else
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

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


        public static bool DoesAttendTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT DoesAttendTest = 1
                  FROM     Tests INNER JOIN
                  TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
				  where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

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

        //public static bool DoesPassTestType(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        //{
        //    bool IsFound = false;

        //    SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string Query = @"SELECT Tests.TestID, Tests.TestAppointmentID, Tests.TestResult, Tests.Notes, Tests.CreatedByUserID
        //                     FROM     Tests INNER JOIN
        //                     TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
        //         Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID";

        //    SqlCommand Command = new SqlCommand(Query, Connection);

        //    Command.Parameters.AddWithValue("@TestID", TestID);

        //    try
        //    {
        //        Connection.Open();
        //        SqlDataReader Reader = Command.ExecuteReader();
        //        if (Reader.Read())
        //        {
        //            IsFound = true;
        //            TestID = (int)Reader["TestID"];
        //            TestAppointmentID = (int)Reader["TestAppointmentID"];
        //            TestResult = (bool)Reader["TestResult"];
        //            Notes = (string)Reader["Notes"];
        //            CreatedByUserID = (int)Reader["CreatedByUserID"];

        //        }
        //        else
        //        {
        //            IsFound = false;
        //        }

        //        Reader.Close();
        //    }

        //    catch
        //    {
        //        IsFound = false;
        //    }
        //    finally
        //    {
        //        Connection.Close();
        //    }
        //    return IsFound;


        //}



        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            int PassedTestsCount = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT Count (TestAppointments.TestTypeID) as PassedTestCount
                   FROM   TestAppointments INNER JOIN Tests
                  ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
				  Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestResult = 1;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    PassedTestsCount = ID;
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return PassedTestsCount;
        }


    }
}
