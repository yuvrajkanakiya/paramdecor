using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddressDAL
/// </summary>
/// 
namespace ParamDecor.DAL
{
    public class AddressDAL : DatabaseConfig
    {
        #region Constructor
        public AddressDAL()
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
        public Boolean Insert(AddressENT entAddress)
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
                        objCmd.CommandText = "PR_Address_Insert";
                        objCmd.Parameters.Add("@AddressID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entAddress.UserID;
                        objCmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = entAddress.FullName;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entAddress.StateID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entAddress.CityID;
                        objCmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = entAddress.Address1;
                        objCmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = entAddress.Address2;
                        objCmd.Parameters.Add("@Postcode", SqlDbType.Int).Value = entAddress.Postcode;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entAddress.MobileNo;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@AddressID"] != null)
                            entAddress.AddressID = Convert.ToInt32(objCmd.Parameters["@AddressID"].Value);

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
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

        #region Update Operation
        public Boolean Update(AddressENT entAddress, SqlInt32 AddressID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Address_Update";
                        objCmd.Parameters.AddWithValue("@AddressID", AddressID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@FullName", entAddress.FullName);
                        objCmd.Parameters.AddWithValue("@StateID", entAddress.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entAddress.CityID);
                        objCmd.Parameters.AddWithValue("@Address1",entAddress.Address1);
                        objCmd.Parameters.AddWithValue("@Address2", entAddress.Address2);
                        objCmd.Parameters.AddWithValue("@Postcode", entAddress.Postcode);
                        objCmd.Parameters.AddWithValue("@MobileNo", entAddress.MobileNo);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
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
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 AddressID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Address_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@AddressID", AddressID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
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
        #endregion Delete Operation

        #region Select Operation

        #region Select All
        public DataTable SelectALL(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Address_SelectALL";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
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
        #endregion Select All

        #region SelectByPK
        public AddressENT SelectByPK(SqlInt32 AddressID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Address_SelectByPK";
                        objCmd.Parameters.AddWithValue("@AddressID", AddressID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        AddressENT entAddress = new AddressENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["AddressID"].Equals(DBNull.Value))
                                    entAddress.AddressID = Convert.ToInt32(objSDR["AddressID"]);

                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entAddress.UserID = Convert.ToInt32(objSDR["UserID"]);

                                if (!objSDR["FullName"].Equals(DBNull.Value))
                                    entAddress.FullName = Convert.ToString(objSDR["FullName"]);

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entAddress.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entAddress.CityID = Convert.ToInt32(objSDR["CityID"]);

                                if (!objSDR["Address1"].Equals(DBNull.Value))
                                    entAddress.Address1 = Convert.ToString(objSDR["Address1"]);

                                if (!objSDR["Address2"].Equals(DBNull.Value))
                                    entAddress.Address2 = Convert.ToString(objSDR["Address2"]);

                                if (!objSDR["Postcode"].Equals(DBNull.Value))
                                    entAddress.Postcode = Convert.ToInt32(objSDR["Postcode"]);

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entAddress.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                            }
                        }
                        return entAddress;
                        #endregion ReadData and Set Controls
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
        #endregion SelectByPK

        #region GetAddressIDByUserID
        public AddressENT GetAddressIDByUserID(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Address_GetAddressIDByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        AddressENT entAddress = new AddressENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["AddressID"].Equals(DBNull.Value))
                                    entAddress.AddressID = Convert.ToInt32(objSDR["AddressID"]);
                            }
                        }
                        return entAddress;
                        #endregion ReadData and Set Controls
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
        #endregion GetAddressIDByUserID

        #endregion Select Operation
    }
}