using ParamDecor.DAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBAL
/// </summary>
/// 
namespace ParamDecor.BAL
{
    public class UserBAL
    {
        #region Constructor
        public UserBAL()
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
        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if(dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Select By UserPassword
        public UserENT SelectByUserPassword(String UserName, String password)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserPassword(UserName, password);
        }
        #endregion Select By UserPassword
    }
}