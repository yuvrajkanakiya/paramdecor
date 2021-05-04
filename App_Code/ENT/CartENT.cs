using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartENT
/// </summary>
/// 
namespace ParamDecor.ENT
{
    public class CartENT
    {
        #region Contructor
        public CartENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Contructor

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

        #region ProductDetailsID
        protected SqlInt32 _ProductDetailsID;

        public SqlInt32 ProductDetailsID
        {
            get
            {
                return _ProductDetailsID;
            }
            set
            {
                _ProductDetailsID = value;
            }
        }
        #endregion ProductDetailsID

        #region Quantity
        protected SqlInt32 _Quantity;

        public SqlInt32 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }
        #endregion Quantity

    }
}