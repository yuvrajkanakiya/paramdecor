using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductDetailsDAL
/// </summary>
/// 
namespace ParamDecor.DAL
{
    public class ProductDetailsDAL : DatabaseConfig
    {
        #region Contructor
        public ProductDetailsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Contructor

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
        public Boolean Insert(ProductDetailsENT entProductDetails)
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
                        objCmd.CommandText = "PR_ProductDetails_Insert";
                        objCmd.Parameters.Add("@ProductDetailsID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@productID", SqlDbType.Int).Value = entProductDetails.ProductID;
                        objCmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = entProductDetails.Size;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entProductDetails.UserID;
                        #endregion prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@ProductDetailsID"] != null)
                            entProductDetails.ProductDetailsID = Convert.ToInt32(objCmd.Parameters["@ProductDetailsID"].Value);

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch(Exception ex)
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
        public Boolean Update(ProductDetailsENT entProductDetails)
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
                        objCmd.CommandText = "PR_ProductDetails_Update";
                        objCmd.Parameters.AddWithValue("@ProductDetailsID", entProductDetails.ProductDetailsID);
                        objCmd.Parameters.AddWithValue("@productID", entProductDetails.ProductID);
                        objCmd.Parameters.AddWithValue("@Size", entProductDetails.Size);
                        objCmd.Parameters.AddWithValue("@UserID", entProductDetails.UserID);
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
        public Boolean Delete(SqlInt32 ProductDetailsID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_ProductDetails_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ProductDetailsID", ProductDetailsID);
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

        #region Select Operation

        #region SelectALL Operation
        public DataTable SelectALL(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_ProductDetails_SelectALL";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion prepare Command

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
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
        #endregion SelectALL Operation

        #region SelectByPK Operation
        public ProductDetailsENT SelectByPK(SqlInt32 ProductDetailsID)
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
                        objCmd.CommandText = "PR_ProductDetails_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ProductDetailsID", ProductDetailsID);
                        #endregion prepare Command

                        #region ReadData and Set Controls
                        ProductDetailsENT entProductDetails = new ProductDetailsENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ProductDetailsID"].Equals(DBNull.Value))
                                    entProductDetails.ProductDetailsID = Convert.ToInt32(objSDR["ProductDetailsID"]);

                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                    entProductDetails.ProductID = Convert.ToInt32(objSDR["ProductID"]);

                                if (!objSDR["Size"].Equals(DBNull.Value))
                                    entProductDetails.Size = Convert.ToString(objSDR["Size"]);
                            }
                        }
                        return entProductDetails;
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
        #endregion SelectByPK Operation

        #endregion Select Operation
    }
}