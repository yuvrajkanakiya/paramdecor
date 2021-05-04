using ParamDecor.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
/// 
namespace ParamDecor
{
    public class CommonFillMethods
    {
        #region Constructor
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        public static void FillDropDownListCategory(DropDownList ddl)
        {
            CategoryBAL balCategory = new CategoryBAL();
            ddl.DataSource = balCategory.SelectForDropDownList();
            ddl.DataValueField = "CategoryID";
            ddl.DataTextField = "CategoryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Category", "-1"));
        }

        public static void FillDropDownListProduct(DropDownList ddl)
        {
            ProductBAL balProduct = new ProductBAL();
            ddl.DataSource = balProduct.SelectForDropDownList();
            ddl.DataValueField = "ProductID";
            ddl.DataTextField = "ProductName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Product", "-1"));
        }

        public static void FillDropDownListState(DropDownList ddl)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownList();
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }

        public static void FillDropDownListCityByStateID(DropDownList ddl , SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropDownListCityByStateID(StateID);
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }

        public static void FillDropDownListEmpty(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
    }
}