using ParamDecor.DAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddressBAL
/// </summary>
/// 
namespace ParamDecor.BAL
{
    public class AddressBAL
    {
        #region Constructor
        public AddressBAL()
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
            AddressDAL dalAddress = new AddressDAL();
            if (dalAddress.Insert(entAddress))
            {
                return true;
            }
            else
            {
                Message = dalAddress.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(AddressENT entAddress, SqlInt32 AddressID, SqlInt32 UserID)
        {
            AddressDAL dalAddress = new AddressDAL();
            if (dalAddress.Update(entAddress, AddressID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalAddress.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 AddressID, SqlInt32 UserID)
        {
            AddressDAL dalAddress = new AddressDAL();
            if (dalAddress.Delete(AddressID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalAddress.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectALL Operation
        public DataTable SelectALL(SqlInt32 UserID)
        {
            AddressDAL dalAddress = new AddressDAL();
            return dalAddress.SelectALL(UserID);
        }
        #endregion SelectALL Operation

        #region SelectByPK Operation
        public AddressENT SelectByPK(SqlInt32 AddressID, SqlInt32 UserID)
        {
            AddressDAL dalAddress = new AddressDAL();
            return dalAddress.SelectByPK(AddressID, UserID);
        }
        #endregion SelectByPK Operation

        #region GetAddressIDByUserID
        public AddressENT GetAddressIDByUserID(SqlInt32 UserID)
        {
            AddressDAL dalAddress = new AddressDAL();
            return dalAddress.GetAddressIDByUserID(UserID);
        }
        #endregion GetAddressIDByUserID

        #endregion Select Operation
    }
}