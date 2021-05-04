using ParamDecor.DAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartBAL
/// </summary>
namespace ParamDecor.BAL
{
    public class CartBAL
    {
        #region Constructor
        public CartBAL()
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
        public Boolean Insert(CartENT entCart)
        {
            CartDAL dalCart = new CartDAL();
            if (dalCart.Insert(entCart))
            {
                return true;
            }
            else
            {
                Message = dalCart.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CartENT entCart, SqlInt32 CartID, SqlInt32 UserID)
        {
            CartDAL dalCart = new CartDAL();
            if (dalCart.Update(entCart, CartID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalCart.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CartID, SqlInt32 UserID)
        {
            CartDAL dalCart = new CartDAL();
            if (dalCart.Delete(CartID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalCart.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectALL Operation
        public DataTable SelectALL(SqlInt32 UserID)
        {
            CartDAL dalCart = new CartDAL();
            return dalCart.SelectALL(UserID);
        }
        #endregion SelectALL Operation

        #region SelectByPK Operation
        public CartENT SelectByPK(SqlInt32 CartID, SqlInt32 UserID)
        {
            CartDAL dalCart = new CartDAL();
            return dalCart.SelectByPK(CartID, UserID);
        }
        #endregion SelectByPK Operation

        #endregion Select Operation
    }
}