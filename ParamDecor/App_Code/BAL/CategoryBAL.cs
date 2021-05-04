using ParamDecor.DAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryBAL
/// </summary>
namespace ParamDecor.BAL
{
    public class CategoryBAL
    {
        #region Constructor
        public CategoryBAL()
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
        public Boolean Insert(CategoryENT entCategory)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            if(dalCategory.Insert(entCategory))
            {
                return true;
            }
            else
            {
                Message = dalCategory.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CategoryENT entCategory)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            if (dalCategory.Update(entCategory))
            {
                return true;
            }
            else
            {
                Message = dalCategory.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CategoryID)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            if (dalCategory.Delete(CategoryID))
            {
                return true;
            }
            else
            {
                Message = dalCategory.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region Select All
        public DataTable SelectAll()
        {
            CategoryDAL dalCategory = new CategoryDAL();
            return dalCategory.SelectAll();
        }
        #endregion Select All

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            CategoryDAL dalCategory = new CategoryDAL();
            return dalCategory.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public CategoryENT SelectByPK(SqlInt32 CategoryID)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            return dalCategory.SelectByPK(CategoryID);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}