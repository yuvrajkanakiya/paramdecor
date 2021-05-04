using ParamDecor.DAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBAL
/// </summary>
/// 
namespace ParamDecor.BAL
{
    public class StateBAL
    {
        #region Constructor
        public StateBAL()
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

        #endregion Local Variable

        #region Insert Operation
        public Boolean Insert(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Insert(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Update(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CategoryID)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Delete(CategoryID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region Select All
        public DataTable SelectAll()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll();
        }
        #endregion Select All

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public StateENT SelectByPK(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByPK(StateID);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}