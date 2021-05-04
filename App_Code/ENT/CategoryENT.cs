using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
/// 
namespace ParamDecor.ENT
{
    public class CategoryENT
    {
        #region Constructor
        public CategoryENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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

        #region CategoryName
        protected SqlString _CategoryName;

        public SqlString CategoryName
        {
            get
            {
                return _CategoryName;
            }
            set
            {
                _CategoryName = value;
            }
        }
        #endregion CategoryName
    }
}