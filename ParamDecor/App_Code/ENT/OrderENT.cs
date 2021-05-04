using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderENT
/// </summary>
/// 
namespace ParamDecor.ENT
{
    public class OrderENT
    {
        #region Constructor
        public OrderENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region OrderID
        protected SqlInt32 _OrderID;

        public SqlInt32 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }
        #endregion OrderID

        #region CartID
        protected SqlInt32 _CartID;

        public SqlInt32 CartID
        {
            get
            {
                return _CartID;
            }
            set
            {
                _CartID = value;
            }
        }
        #endregion CartID

        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        #endregion UserID

        #region AddressID
        protected SqlInt32 _AddressID;

        public SqlInt32 AddressID
        {
            get
            {
                return _AddressID;
            }
            set
            {
                _AddressID = value;
            }
        }
        #endregion AddressID

        #region Total
        protected SqlInt32 _Total;

        public SqlInt32 Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
            }
        }
        #endregion Total
    }
}