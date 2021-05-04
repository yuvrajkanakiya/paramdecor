using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDAL
/// </summary>
///
namespace ParamDecor.DAL
{
    public class OrderDAL : DatabaseConfig
    {
        #region Constructor
        public OrderDAL()
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
        public Boolean Insert(OrderENT entOrder)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Order_Insert";
                        objCmd.Parameters.Add("@OrderID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entOrder.UserID;
                        objCmd.Parameters.Add("@CartID", SqlDbType.Int).Value = entOrder.CartID;
                        objCmd.Parameters.Add("@AddressID", SqlDbType.Int).Value = entOrder.AddressID;
                        objCmd.Parameters.Add("@Total", SqlDbType.Int).Value = entOrder.Total;
                        #endregion prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@OrderID"] != null)
                            entOrder.OrderID = Convert.ToInt32(objCmd.Parameters["@OrderID"].Value);

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

        #region Update Operation
        public Boolean Update(OrderENT entOrder, SqlInt32 OrderID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Order_Update";
                        objCmd.Parameters.AddWithValue("@OrderID", OrderID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@CartID", entOrder.CartID);
                        objCmd.Parameters.AddWithValue("@AddressID", entOrder.AddressID);
                        objCmd.Parameters.AddWithValue("@Total", entOrder.Total);
                        #endregion prepare Command

                        objCmd.ExecuteNonQuery();

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
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 OrderID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Order_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@OrderID", OrderID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion prepare Command

                        objCmd.ExecuteNonQuery();

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
        #endregion Delete Operation
    }
}