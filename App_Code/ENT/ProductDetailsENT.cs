using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductDetailsENT
/// </summary>
/// 
namespace ParamDecor.ENT
{
    public class ProductDetailsENT
    {
        #region Contructor
        public ProductDetailsENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Contructor

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

        #region ProductID
        protected SqlInt32 _ProductID;

        public SqlInt32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }
        #endregion ProductDetailsID

        #region Size
        protected SqlString _Size;

        public SqlString Size
        {
            get
            {
                return _Size;
            }
            set
            {
                _Size = value;
            }
        }
        #endregion Size

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
    }
}