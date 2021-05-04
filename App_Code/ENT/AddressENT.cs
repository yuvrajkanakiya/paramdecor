using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddressENT
/// </summary>
/// 
namespace ParamDecor.ENT
{
    public class AddressENT
    {
        #region Constructor
        public AddressENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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

        #region FullName
        protected SqlString _FullName;

        public SqlString FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                _FullName = value;
            }
        }
        #endregion FullName

        #region CityID
        protected SqlInt32 _CityID;

        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }
        #endregion CityID

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

        #region Address1
        protected SqlString _Address1;

        public SqlString Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                _Address1 = value;
            }
        }
        #endregion Address1

        #region Address2
        protected SqlString _Address2;

        public SqlString Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                _Address2 = value;
            }
        }
        #endregion Address2

        #region Postcode
        protected SqlInt32 _Postcode;

        public SqlInt32 Postcode
        {
            get
            {
                return _Postcode;
            }
            set
            {
                _Postcode = value;
            }
        }
        #endregion Postcode

        #region MobileNo
        protected SqlString _MobileNo;

        public SqlString MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }
        #endregion MobileNo
    }
}