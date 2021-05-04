using ParamDecor.DAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderBAL
/// </summary>
/// 
namespace ParamDecor.BAL
{
    public class OrderBAL
    {
        #region Constructor
        public OrderBAL()
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
            OrderDAL dalOrder = new OrderDAL();
            if (dalOrder.Insert(entOrder))
            {
                return true;
            }
            else
            {
                Message = dalOrder.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(OrderENT entOrder, SqlInt32 OrderID, SqlInt32 UserID)
        {
            OrderDAL dalOrder = new OrderDAL();
            if (dalOrder.Update(entOrder, OrderID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalOrder.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 OrderID, SqlInt32 UserID)
        {
            OrderDAL dalOrder = new OrderDAL();
            if (dalOrder.Delete(OrderID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalOrder.Message;
                return false;
            }
        }
        #endregion Delete Operation
    }
}