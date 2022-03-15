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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                //lblText.Text = "Edit mode | ContactCategoryID = " + System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactCategoryID"].ToString()));
                FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactCategoryID"].ToString()))));
            }

            //else
                //lblText.Text = "Add Mode";
        }
    }
    #endregion Load Event

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String strErrorMessage = "";
        #region Local Variables
        SqlString strContactCategoryName = SqlString.Null;
        #endregion Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Server Side Validation
            if (txtContactCategoryName.Text.Trim() == "")
                strErrorMessage += " - Enter Contact Category<br />";
            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information
            if (txtContactCategoryName.Text.Trim() != "")
            {
                strContactCategoryName = txtContactCategoryName.Text.Trim();
            }
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@ContactCategoryID", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactCategoryID"].ToString().Trim())));
                objCmd.CommandText = "PR_ContactCategory_UpdateByUserID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/List");
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_ContactCategory_InsertUserID";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data Inserted...!";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
                #endregion Insert Record
            }
            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
        catch (SqlException sqlEx)
        {
            if (sqlEx.Number == 2627)
            {
                lblMessage.Text += "Contact category already exists..";
            }
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
    #endregion Button : Submit

    #region Fill Controls
    protected void FillControls(SqlInt32 ContactCategoryID)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByPKUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Set Connection & Command Object
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }
                    break;
                }
            }
            else
                lblText.Text = "No data available";
            #endregion Set Connection & Command Object
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
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/List", true);
    }
    #endregion Button : Cancel
}