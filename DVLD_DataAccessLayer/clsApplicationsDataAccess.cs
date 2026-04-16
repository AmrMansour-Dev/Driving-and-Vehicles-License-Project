using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsApplicationsDataAccess
    {
        public static DataTable GetAllApplications()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select * from Applications order by ApplicationID ASC";

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

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Applications
                        SET ApplicantPersonID = @ApplicantPersonID
                       ,ApplicationDate = @ApplicationDate
                       ,ApplicationTypeID = @ApplicationTypeID
                       ,ApplicationStatus = @ApplicationStatus
                       ,LastStatusDate = @LastStatusDate
                       ,PaidFees = @PaidFees
                       ,CreatedByUserID = @CreatedByUserID
                        WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("PaidFees", PaidFees);
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

        public static bool UpdateApplicationStatus(int ApplicationID, byte ApplicationStatus)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Applications
                        SET ApplicationStatus = @ApplicationStatus
                        ,LastStatusDate = @LastStatusDate
                        WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);





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


        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Applications(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                           VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("PaidFees", PaidFees);
            Command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);



            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    ApplicationID = ID;
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;
        }


        public static bool FindBaseApplicationByID(int ApplicationID,ref int ApplicantPersonID,ref DateTime ApplicationDate,ref int ApplicationTypeID,
            ref byte ApplicationStatus,ref DateTime LastStatusDate,ref float PaidFees,ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)Reader["ApplicationID"];
                    ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationTypeID = (int)(Reader["ApplicationTypeID"]);
                    ApplicationStatus = (byte)(Reader["ApplicationStatus"]);
                    LastStatusDate = (DateTime)(Reader["LastStatusDate"]);
                    PaidFees = Convert.ToSingle((Reader["PaidFees"]));
                    CreatedByUserID = (int)(Reader["CreatedByUserID"]);


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

        public static bool CancelApplication(int ApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Applications
                        SET ApplicationStatus = 2,
                        LastStatusDate = GETDATE()
                        WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);

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

        public static bool Delete(int ApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Delete From Applications Where ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);

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

    }
}
