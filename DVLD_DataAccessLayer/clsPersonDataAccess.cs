using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsPersonDataAccess
    {
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
            ,ref DateTime DateofBirth, ref byte Gendor, ref string Address,ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    LastName = (string)Reader["LastName"];
                    DateofBirth = (DateTime)Reader["DateofBirth"];
                    Gendor = (byte)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];
                    NationalityCountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                    if (Reader["Email"] != DBNull.Value)
                    {
                        Email = (string)Reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    if (Reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)Reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
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

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
    , ref DateTime DateofBirth, ref byte Gendor, ref string Address,ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    LastName = (string)Reader["LastName"];
                    DateofBirth = (DateTime)Reader["DateofBirth"];
                    Gendor = (byte)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];
                    NationalityCountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                    if (Reader["Email"] != DBNull.Value)
                    {
                        Email = (string)Reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    if (Reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)Reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
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

        public static DataTable GetAllPeople()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT People.PersonID, People.NationalNo,
                          People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, People.Gendor,
                          CASE
                          When People.Gendor = 0 then 'Male'
                          Else 'Female'
                          End as GendorCaption
                          , People.Address, People.Phone, People.Email, People.NationalityCountryID, 
                                            Countries.CountryName, People.ImagePath
                          FROM     People INNER JOIN
                          Countries ON People.NationalityCountryID = Countries.CountryID
				          Order By People.FirstName";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.HasRows)
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

        public static int AddNewPerson( string NationalNo,  string FirstName,  string SecondName,  string ThirdName,  string LastName
            ,  DateTime DateofBirth,  byte Gendor,  string Address,string Phone,  string Email,  int NationalityCountryID,  string ImagePath)
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Insert into People(NationalNo,FirstName,SecondName,ThirdName,LastName,DateofBirth,Gendor,Address,Phone,Email,
NationalityCountryID,ImagePath) Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateofBirth,@Gendor,@Address,@Phone,@Email,
@NationalityCountryID,@ImagePath);
Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query,Connection);

            Command.Parameters.AddWithValue("NationalNo", NationalNo);
            Command.Parameters.AddWithValue("FirstName", FirstName);
            Command.Parameters.AddWithValue("SecondName", SecondName);
            Command.Parameters.AddWithValue("LastName", LastName);
            Command.Parameters.AddWithValue("DateofBirth", DateofBirth);
            Command.Parameters.AddWithValue("Gendor", Gendor);
            Command.Parameters.AddWithValue("Address", Address);
            Command.Parameters.AddWithValue("NationalityCountryID", NationalityCountryID);
            Command.Parameters.AddWithValue("Phone", Phone);


            if (ThirdName != "")
            {
                Command.Parameters.AddWithValue("ThirdName", ThirdName);
            }
            else
            {
                Command.Parameters.AddWithValue("ThirdName", System.DBNull.Value);

            }
            if (Email != "")
            {
                Command.Parameters.AddWithValue("Email", Email);
            }
            else
            {
                Command.Parameters.AddWithValue("Email", System.DBNull.Value);

            }
            if (ImagePath != "")
            {
                Command.Parameters.AddWithValue("ImagePath", ImagePath);
            }
            else
            {
                Command.Parameters.AddWithValue("ImagePath", System.DBNull.Value);

            }

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if(Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }

            }
            catch
            {

            }

            finally
            {
                Connection.Close();
            }
            return PersonID;







        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName
           , DateTime DateofBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update People 
                            Set NationalNo = @NationalNo,
                             FirstName = @FirstName,
                             SecondName = @SecondName,
                             ThirdName = @ThirdName,
                             LastName = @LastName,
                             DateofBirth = @DateofBirth,
                             Gendor = @Gendor,
                             Address = @Address,
                             Phone = @Phone,
                             Email = @Email,
                             NationalityCountryID = @NationalityCountryID,
                             ImagePath = @ImagePath
                            Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("NationalNo", NationalNo);
            Command.Parameters.AddWithValue("FirstName", FirstName);
            Command.Parameters.AddWithValue("SecondName", SecondName);
            Command.Parameters.AddWithValue("LastName", LastName);
            Command.Parameters.AddWithValue("DateofBirth", DateofBirth);
            Command.Parameters.AddWithValue("Gendor", Gendor);
            Command.Parameters.AddWithValue("Address", Address);
            Command.Parameters.AddWithValue("Phone", Phone);
            Command.Parameters.AddWithValue("NationalityCountryID", NationalityCountryID);

            if (ThirdName != "")
            {
                Command.Parameters.AddWithValue("ThirdName", ThirdName);
            }
            else
            {
                Command.Parameters.AddWithValue("ThirdName", System.DBNull.Value);

            }
            if (Email != "")
            {
                Command.Parameters.AddWithValue("Email", Email);
            }
            else
            {
                Command.Parameters.AddWithValue("Email", System.DBNull.Value);

            }
            if (ImagePath != "")
            {
                Command.Parameters.AddWithValue("ImagePath", ImagePath);
            }
            else
            {
                Command.Parameters.AddWithValue("ImagePath", System.DBNull.Value);

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


        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Delete From People Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("PersonID", PersonID);

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
