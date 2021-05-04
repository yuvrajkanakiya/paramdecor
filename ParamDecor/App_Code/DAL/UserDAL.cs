using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAL
/// </summary>
/// 
namespace ParamDecor.DAL
{
    public class UserDAL : DatabaseConfig
    {
        #region Constructor
        public UserDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Local Variable
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local variable

        #region Insert Operation

        public Boolean Insert(UserENT entUser)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_Insert";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entUser.UserName;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entUser.Email;
                        //objCmd.Parameters.Add("@UserType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = entUser.Password;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@UserID"] != null)
                            entUser.UserID = Convert.ToInt32(objCmd.Parameters["@UserID"].Value);

                        //if (objCmd.Parameters["@UserType"] != null)
                        //    entUser.UserType = Convert.ToString(objCmd.Parameters["@UserType"].Value);

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Insert Operation

        #region Select Operation

        public UserENT SelectByUserPassword(String UserName, String password)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_SelectByUserPassword";
                        objCmd.Parameters.AddWithValue("@UserName", UserName);
                        objCmd.Parameters.AddWithValue("@Password", password);

                        #endregion Prepare command

                        #region Read Data and Set Controls
                        UserENT entUser = new UserENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"]);

                                if (!objSDR["UserName"].Equals(DBNull.Value))
                                    entUser.UserName = Convert.ToString(objSDR["UserName"]);

                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    entUser.Email = Convert.ToString(objSDR["Email"]);

                                if (!objSDR["UserType"].Equals(DBNull.Value))
                                    entUser.UserType = Convert.ToString(objSDR["UserType"]);

                                if (!objSDR["Password"].Equals(DBNull.Value))
                                    entUser.Password = Convert.ToString(objSDR["Password"]);

                            }
                        }
                        return entUser;
                        #endregion Read Data and Set Controls

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Select Operation
    }
}