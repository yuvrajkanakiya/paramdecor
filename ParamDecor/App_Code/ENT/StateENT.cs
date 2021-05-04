using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateENT
/// </summary>
/// 

namespace ParamDecor.ENT
{  
    public class StateENT
    {
        #region Constructor
        public StateENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region StateID
        protected SqlInt32 _StateID;

        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }
        #endregion StateID

        #region StateName
        protected SqlString _StateName;

        public SqlString StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }
        #endregion StateName

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