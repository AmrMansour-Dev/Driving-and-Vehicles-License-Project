using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsUserDataAccess
    {

        public static int AddNewUser( int PersonID,string UserName, string Password, byte IsActive)
        {
            int UserID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Users(PersonID,UserName,Password,IsActive) VALUES (@PersonID,@UserName,@Password,@IsActive);
                             Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("UserName", UserName);
            Command.Parameters.AddWithValue("Password", Password);
            Command.Parameters.AddWithValue("IsActive", IsActive);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    UserID = ID;
                }
            }
            catch 
            {

            }
            finally
            {
                Connection.Close();
            }

            return UserID;
        }


        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, byte IsActive)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Users SET UserName = @UserName,Password = @Password,IsActive = @IsActive
                            WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("UserID", UserID);
            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("UserName", UserName);
            Command.Parameters.AddWithValue("Password", Password);
            Command.Parameters.AddWithValue("IsActive", IsActive);

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
                Connection.Close() ;
            }

            return (RowsAffected > 0);

        }


        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM Users
                              WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("UserID", UserID);

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

        public static bool FindUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref byte IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = Convert.ToByte(Reader["IsActive"]);

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

        public static bool FindUserByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref byte IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    UserID = (int)Reader["UserID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = Convert.ToByte(Reader["IsActive"]);

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

        public static bool FindUserByUserNameAndPassword(ref int PersonID, ref int UserID, string UserName, string Password, ref byte IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Select * from Users where Users.UserName = @UserName and Users.Password = @Password";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    UserID = (int)Reader["UserID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = Convert.ToByte(Reader["IsActive"]);

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

        public static bool IsUserExists(int UserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT IsFound = 1 FROM Users WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool IsPersonHasUser(int PersonID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT People.FirstName
                             FROM     Users INNER JOIN
                             People ON Users.PersonID = People.PersonID 
				             Where People.PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

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


        public static DataTable GetAllUsers()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT Users.UserID, Users.PersonID, People.FirstName + ' ' + People.SecondName + ' '
                             + People.ThirdName + ' ' + People.LastName as FullName, Users.UserName, Users.IsActive
                             FROM Users INNER JOIN
                             People ON Users.PersonID = People.PersonID";

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
    }
}
