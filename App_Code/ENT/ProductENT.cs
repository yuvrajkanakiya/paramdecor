using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductENT
/// </summary>
/// 
namespace ParamDecor.ENT
{
    public class ProductENT
    {
        #region Contructor
        public ProductENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Contructor

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
        #endregion ProductID

        #region CategoryID
        protected SqlInt32 _CategoryID;

        public SqlInt32 CategoryID
        {
            get
            {
                return _CategoryID;
            }
            set
            {
                _CategoryID = value;
            }
        }
        #endregion CategoryID

        #region ProductName
        protected SqlString _ProductName;

        public SqlString ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
            }
        }
        #endregion ProductName

        #region Description
        protected SqlString _Description;

        public SqlString Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        #endregion Description

        #region Price
        protected SqlInt32 _Price;

        public SqlInt32 Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
            }
        }
        #endregion Price

        #region ProductImage
        protected SqlString _ProductImage;

        public SqlString ProductImage
        {
            get
            {
                return _ProductImage;
            }
            set
            {
                _ProductImage = value;
            }
        }
        #endregion ProductImage

    }
}