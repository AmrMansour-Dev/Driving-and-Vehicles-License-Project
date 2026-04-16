using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointmentsDataAccess
    {
        public static DataTable GetAllTestAppointments()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * from TestAppointments";

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


        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
            float PaidFees, int CreatedByUserID, bool isLocked, int RetakeTestApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE TestAppointments
                        SET TestTypeID = @TestTypeID
                       ,LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                       ,AppointmentDate = @AppointmentDate
                       ,PaidFees = @PaidFees
                       ,CreatedByUserID = @CreatedByUserID
                       ,isLocked = @isLocked
                       ,RetakeTestApplicationID = @RetakeTestApplicationID
                        WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("PaidFees", PaidFees);
            Command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("isLocked", isLocked);

            if (RetakeTestApplicationID != -1)
            {
                Command.Parameters.AddWithValue("RetakeTestApplicationID", RetakeTestApplicationID);
            }
            else
            {
                Command.Parameters.AddWithValue("RetakeTestApplicationID", System.DBNull.Value);

            }



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

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
            float PaidFees, int CreatedByUserID, bool isLocked, int RetakeTestApplicationID)
        {
            int TestAppontmentID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO TestAppointments(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, isLocked, RetakeTestApplicationID) 
                             VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @isLocked, @RetakeTestApplicationID);
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("PaidFees", PaidFees);
            Command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("isLocked", isLocked);

            if (RetakeTestApplicationID != -1)
            {
                Command.Parameters.AddWithValue("RetakeTestApplicationID", RetakeTestApplicationID);
            }
            else
            {
                Command.Parameters.AddWithValue("RetakeTestApplicationID", System.DBNull.Value);

            }


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TestAppontmentID = ID;
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return TestAppontmentID;
        }


        public static bool FindTestAppointmentByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate,
            ref float PaidFees, ref int CreatedByUserID, ref bool isLocked, ref int RetakeTestApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestTypeID = (int)Reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    isLocked = (bool)Reader["isLocked"];

                    if (Reader["RetakeTestApplicationID"] == DBNull.Value)
                    {
                        RetakeTestApplicationID = -1;
                    }

                    else
                    {
                        RetakeTestApplicationID = (int)Reader["RetakeTestApplicationID"];
                    }


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

        public static DataTable GetLocalDrivingApplicationTestAppointmentPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select TestAppointmentID, AppointmentDate, PaidFees, IsLocked FROM TestAppointments
                           Where TestTypeID = @TestTypeID AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


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

        public static int CountTotalTestTrialsPerTestType(int TestTypeID, int LocalDrivingLicenseAppID)
        {
            int TotalTrials = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select Count(TestTypeID) AS TotalTrials from TestAppointments
                           Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseAppID and TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("LocalDrivingLicenseAppID", LocalDrivingLicenseAppID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TotalTrials = ID;
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return TotalTrials;
        }

        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select TestID From Tests Where TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);


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

    }
}
