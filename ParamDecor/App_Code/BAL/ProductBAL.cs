using ParamDecor.DAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductBAL
/// </summary>
/// 
namespace ParamDecor.BAL
{
    public class ProductBAL
    {
        #region Constructor
        public ProductBAL()
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
        public Boolean Insert(ProductENT entProduct)
        {
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Insert(entProduct))
            {
                return true;
            }
            else
            {
                Message = dalProduct.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ProductENT entProduct)
        {
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Update(entProduct))
            {
                return true;
            }
            else
            {
                Message = dalProduct.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ProductID)
        {
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Delete(ProductID))
            {
                return true;
            }
            else
            {
                Message = dalProduct.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll Operation
        public DataTable SelectAll()
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectAll();
        }
        #endregion SelectAll Operation

        #region SelectAllCalendar Operation
        public DataTable SelectAllCalendar()
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectAllCalendar();
        }
        #endregion SelectAllCalendar Operation

        #region SelectAllTshirt Operation
        public DataTable SelectAllTshirt()
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectAllTshirt();
        }
        #endregion SelectAllTshirt Operation

        #region SelectAllCanvas Operation
        public DataTable SelectAllCanvas()
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectAllCanvas();
        }
        #endregion SelectAllCanvas Operation

        #region SelectForDropDownList Operation
        public DataTable SelectForDropDownList()
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectForDropDownList();
        }
        #endregion SelectForDropDownList Operation

        #region SelectByPK
        public ProductENT SelectByPK(SqlInt32 ProductID)
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectByPK(ProductID);
        }
        #endregion SelectByPK

        #endregion Select Operation

        #region Repeator Product
        public DataTable RepeatorProduct()
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.RepeatorProduct();
        }
        #endregion Repeator Product
    }
}