using ParamDecor.DAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductDetailsBAL
/// </summary>
/// 
namespace ParamDecor.BAL
{
    public class ProductDetailsBAL
    {
        #region Contructor
        public ProductDetailsBAL()
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
            ProductDetailsDAL dalProductDetails = new ProductDetailsDAL();
            if(dalProductDetails.Insert(entProductDetails))
            {
                return true;
            }
            else
            {
                Message = dalProductDetails.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ProductDetailsENT entProductDetails)
        {
            ProductDetailsDAL dalProductDetails = new ProductDetailsDAL();
            if (dalProductDetails.Update(entProductDetails))
            {
                return true;
            }
            else
            {
                Message = dalProductDetails.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ProductDetailsID, SqlInt32 UserID)
        {
            ProductDetailsDAL dalProductDetails = new ProductDetailsDAL();
            if (dalProductDetails.Delete(ProductDetailsID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalProductDetails.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectALL Operation
        public DataTable SelectALL(SqlInt32 UserID)
        {
            ProductDetailsDAL dalProductDetails = new ProductDetailsDAL();
            return dalProductDetails.SelectALL(UserID);
        }
        #endregion SelectALL Operation

        #region SelectByPK Operation
        public ProductDetailsENT SelectByPK(SqlInt32 ProductDetailsID)
        {
            ProductDetailsDAL dalProductDetails = new ProductDetailsDAL();
            return dalProductDetails.SelectByPK(ProductDetailsID);
        }
        #endregion SelectByPK Operation

        #endregion Select Operation
    }
}