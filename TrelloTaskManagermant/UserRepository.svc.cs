using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TrelloTaskManagermant
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserRepository" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserRepository.svc or UserRepository.svc.cs at the Solution Explorer and start debugging.
    public class UserRepository : IUserRepository
    {
        public const string GET_USER_REPOSITORY = "ViewUsers";
        public const string INSERT_USER_REPOSITORY = "InsertUsers";
        public const string UPDATE_USER_REPOSITORY = "UpdateUsers";
        public const string DELETE_USER_REPOSITORY = "DeleteUsers";

        private readonly string _strConnection = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
        public string Messages { get; set; }

        /// <summary>
        /// Get userProfile of all the Users
        /// </summary>
        /// <returns></returns>
        public List<Users> GetUserRepository()
        {
            var listUsers = new List<Users>();
            try
            {
                using (var con = new SqlConnection(_strConnection))
                {
                    con.Open();
                    var commandGetUser = new SqlCommand(GET_USER_REPOSITORY, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    var dataAdapter = new SqlDataAdapter(commandGetUser);
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        for (var i = 0; i < dataTable.Rows.Count; i++)
                        {
                            var userInfo = new Users
                            {
                                UserId = Convert.ToInt32(dataTable.Rows[i]["UserId"]),
                                UserName = dataTable.Rows[i]["UserName"].ToString(),
                                Password = dataTable.Rows[i]["Password"].ToString(),
                                Address = dataTable.Rows[i]["Address"].ToString(),
                                PhoneNumber = dataTable.Rows[i]["PhoneNumber"].ToString(),
                                Avarta = dataTable.Rows[i]["Avarta"].ToString()
                            };
                            listUsers.Add(userInfo);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Messages = "Get UserProfile is not successflly" + ex.Message;
            }
            return listUsers;
        }


        /// <summary>
        /// Insert new user 
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public string InsertUserRepository(Users userObj)
        {
            try
            {
                using (var con = new SqlConnection(_strConnection))
                {
                    con.Open();
                    var commandInsert = new SqlCommand(INSERT_USER_REPOSITORY, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    commandInsert.Parameters.AddWithValue("@UserName", userObj.UserName);
                    commandInsert.Parameters.AddWithValue("@Password", userObj.Password);
                    commandInsert.Parameters.AddWithValue("@Address", userObj.Address);
                    commandInsert.Parameters.AddWithValue("@PhoneNumber", userObj.PhoneNumber);
                    commandInsert.Parameters.AddWithValue("@Avarta", userObj.Avarta);
                    var result = commandInsert.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Messages = "Insert" + userObj.UserName + "successflly";
                    }
                    else
                    {
                        Messages = "Insert" + userObj.UserName + "is not successflly";
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Messages = ex.Message;
            }
            return Messages;
        }


        /// <summary>
        /// Delete UserProfile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string DeleteUserRepository(int userId)
        {
            try
            {
                using (var con  = new SqlConnection(_strConnection))
                {
                    con.Open();
                    var commandDeleteUser = new SqlCommand(DELETE_USER_REPOSITORY, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    commandDeleteUser.Parameters.AddWithValue("@UserId", userId);
                    var result = commandDeleteUser.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Messages = " User with " + userId + " Delete successflly";
                    }
                    else
                    {
                        Messages = " User with " + userId + " Delete not successflly";
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Messages = ex.Message;
            }
            return Messages;
        }



        /// <summary>
        /// Update UserProfile for the Users
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public string UpdateUserRepository(Users userObj)
        {
            try
            {
                using (var con = new SqlConnection(_strConnection))
                {
                    con.Open();
                    var commandUpdateUser = new SqlCommand(UPDATE_USER_REPOSITORY, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    commandUpdateUser.Parameters.AddWithValue("@UserId", userObj.UserId);
                    commandUpdateUser.Parameters.AddWithValue("@UserName", userObj.UserName);
                    commandUpdateUser.Parameters.AddWithValue("@Password", userObj.Password);
                    commandUpdateUser.Parameters.AddWithValue("@Address", userObj.Address);
                    commandUpdateUser.Parameters.AddWithValue("@PhoneNumber", userObj.PhoneNumber);
                    commandUpdateUser.Parameters.AddWithValue("@Avarta", userObj.Avarta);
                    var result = commandUpdateUser.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Messages = userObj.UserName + "Update successflly";
                    }
                    else
                    {
                        Messages = userObj.UserName + "Update is not successflly";
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Messages = ex.Message;
            }
            return Messages;
        }
    }
}
