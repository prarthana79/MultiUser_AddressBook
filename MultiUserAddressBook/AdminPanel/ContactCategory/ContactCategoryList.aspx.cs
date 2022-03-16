using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            FillData();
    }
    #endregion Load Event

    #region Fill Data
    protected void FillData()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            //System.Threading.Thread.Sleep(3000);
            if (objSDR.HasRows)
            {
                gvContactCategory.DataSource = objSDR;
                gvContactCategory.DataBind();
            }
            else
            {
                gvContactCategory.DataSource = null;
                gvContactCategory.DataBind();
            }
            #endregion Read the value and set the controls
            
            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
        catch (Exception ex)
        {
            #region Display Appropriate Message
            lblText.Text += ex.Message;
            #endregion Display Appropriate Message
        }
        finally
        {
            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
    }
    #endregion Fill Data

    #region Grid View
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            if (e.CommandName == "deleteRecord")
            {
                #region Delete Record
                if (e.CommandArgument != "")
                {
                    DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                }
                #endregion Delete Record
            }
            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
        catch (Exception ex)
        {
            #region Display Appropriate Message
            lblText.Text += ex.Message;
            #endregion Display Appropriate Message
        }
        finally
        {
            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
    }
    #endregion Grid View

    #region Delete ContactCategory
    protected void DeleteContactCategory(SqlInt32 ContactCategoryID)
    {
        
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_DeleteByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());
            #endregion Set Connection & Command Object
            objCmd.ExecuteNonQuery();

            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
            FillData();
            
        }
        catch (Exception ex)
        {
            #region Display Appropriate Message
            lblText.Text += ex.Message;
            #endregion Display Appropriate Message
        }
        finally
        {
            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
            FillData();
        }
    }
    #endregion Delete ContactCategory
}