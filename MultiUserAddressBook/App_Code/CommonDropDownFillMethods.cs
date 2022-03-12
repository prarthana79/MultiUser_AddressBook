using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public static class CommonDropDownFillMethods
{
    #region Fill DropDownList ContactCategory
    public static void FillDropDownListContactCategory(CheckBoxList ddl)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region ContactCategory
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd3 = objConn.CreateCommand();
            objCmd3.CommandType = CommandType.StoredProcedure;
            objCmd3.CommandText = "PR_ContactCategory_SelectForDropDownListByUserID";
            if (HttpContext.Current.Session["UserID"] != null)
                objCmd3.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR3 = objCmd3.ExecuteReader();

            if (objSDR3.HasRows)
            {
                ddl.DataSource = objSDR3;
                ddl.DataValueField = "ContactCategoryID";
                ddl.DataTextField = "ContactCategoryName";
                ddl.DataBind();
            }

            //ddl.Items.Insert(0, new ListItem("Select Contact Category", "-1"));
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Read the value and set the controls
            #endregion ContactCategory
        }
        catch (Exception ex)
        {
            //lblText.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill DropDownList ContactCategory

    #region Fill DropDownList Country
    public static void FillDropDownListCountry(DropDownList ddl)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Country
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownListByUserID";
            if (HttpContext.Current.Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "CountryID";
                ddl.DataTextField = "CountryName";
                ddl.DataBind();
            }
            else
            {
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem("Select Country", "-1"));
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Read the value and set the controls
            #endregion Country
        }
        catch (Exception ex)
        {
            //lblText.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill DropDownList Country

    #region Fill DropDownList BloodGroup
    public static void FillDropDownListBloodGroup(DropDownList ddl, DropDownList ddlState, DropDownList ddlCity)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region BloodGroup
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd4 = objConn.CreateCommand();
            objCmd4.CommandType = CommandType.StoredProcedure;
            objCmd4.CommandText = "PR_BloodGroupSelectDropDownList";
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR4 = objCmd4.ExecuteReader();

            if (objSDR4.HasRows)
            {
                ddl.DataSource = objSDR4;
                ddl.DataValueField = "BloodGroupID";
                ddl.DataTextField = "BloodGroupName";
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem("Select Blood Group", "-1"));
            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Read the value and set the controls
            #endregion BloodGroup
        }
        catch (Exception ex)
        {
            //lblText.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill DropDownList BloodGroup
    
    #region Fill DropDown List State
    public static void FillDropDownListState(DropDownList ddl, DropDownList ddlCity, DropDownList ddlCountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            ddl.Items.Clear();
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
            SqlInt32 strCountryID = SqlInt32.Null;
            if (ddlCountryID.SelectedIndex > 0)
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            #region State
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd1 = objConn.CreateCommand();
            objCmd1.CommandType = CommandType.StoredProcedure;
            objCmd1.CommandText = "PR_State_SelectForDropDownListUserIDCountryID";
            if (HttpContext.Current.Session["UserID"] != null)
                objCmd1.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
            objCmd1.Parameters.AddWithValue("@CountryID", strCountryID);
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR1 = objCmd1.ExecuteReader();

            if (objSDR1.HasRows)
            {
                ddl.DataSource = objSDR1;
                ddl.DataValueField = "StateID";
                ddl.DataTextField = "StateName";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Read the value and set the controls
        }
        catch (Exception ex)
        {
            //lblText.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        #endregion State
    }
    #endregion Fill DropDown List State
    
    #region Fill DropDown List State
    public static void FillDropDownListState(DropDownList ddl, DropDownList ddlCountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            ddl.Items.Clear();
            
            SqlInt32 strCountryID = SqlInt32.Null;
            if (ddlCountryID.SelectedIndex > 0)
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            #region State
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd1 = objConn.CreateCommand();
            objCmd1.CommandType = CommandType.StoredProcedure;
            objCmd1.CommandText = "PR_State_SelectForDropDownListUserIDCountryID";
            if (HttpContext.Current.Session["UserID"] != null)
                objCmd1.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
            objCmd1.Parameters.AddWithValue("@CountryID", strCountryID);
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR1 = objCmd1.ExecuteReader();

            if (objSDR1.HasRows)
            {
                ddl.DataSource = objSDR1;
                ddl.DataValueField = "StateID";
                ddl.DataTextField = "StateName";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Read the value and set the controls
        }
        catch (Exception ex)
        {
            //lblText.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        #endregion State
    }
    #endregion Fill DropDown List State
    
    #region Fill DropDown List City
    public static void FillDropDownListCity(DropDownList ddl, DropDownList ddlState)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            ddl.Items.Clear();
            SqlInt32 strStateID = SqlInt32.Null;
            if (ddlState.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlState.SelectedValue);
            #region City
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd2 = objConn.CreateCommand();
            objCmd2.CommandType = CommandType.StoredProcedure;
            objCmd2.CommandText = "PR_City_SelectForDropDownListByUserIDStateID";
            if (HttpContext.Current.Session["UserID"] != null)
                objCmd2.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
            objCmd2.Parameters.AddWithValue("@StateID", strStateID);
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR2 = objCmd2.ExecuteReader();

            if (objSDR2.HasRows)
            {
                ddl.DataSource = objSDR2;
                ddl.DataValueField = "CityID";
                ddl.DataTextField = "CityName";
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Read the value and set the controls
            #endregion City

        }
        catch (Exception ex)
        {
            //lblText.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill DropDown List City
}