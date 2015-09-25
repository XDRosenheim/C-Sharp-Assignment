using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UsersLibrary
{
    public class UserLibrary
    {
        public List<Users> Users
        {
            get
            {
                List<Users> userses = new List<Users>();
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("allUsers", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Users users = new Users
                        {
                            Username = Convert.ToString(sqlDataReader["Username"]),
                            Passwd = Convert.ToString(sqlDataReader["Passwd"])
                        };
                        userses.Add(users);
                    }
                }
                return userses;
            }
        }
    }
}
