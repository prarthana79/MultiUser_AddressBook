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
            ddlCountryID.Focus();
            FillDropDownList();
            if (Page.RouteData.Values["StateId"] != null)
            {
                //lblText.Text = "Edit mode | StateID = " + System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["StateId"].ToString()));
                FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["StateId"].ToString()))));
            }

            //else
                //lblText.Text = "Add Mode";
        }
    }
    #endregion Load Event

    #region Fill DropDown
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID);
    }
    #endregion Fill DropDown

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        #endregion Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        String strErrorMessage = "";
        try
        {
            #region Server Side Validation
            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += " - Select Country <br />";
            if (txtStateName.Text.Trim() == "")
                strErrorMessage += " - Enter State Name <br />";
            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information
            if (ddlCountryID.SelectedIndex > 0)
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            if (txtStateName.Text.Trim() != "")
            {
                strStateName = txtStateName.Text.Trim();
                strStateCode = txtStateCode.Text.Trim();
            }
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryId", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);

            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["StateId"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@StateID", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["StateID"].ToString().Trim())));
                objCmd.CommandText = "PR_State_UpdateByUserID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/List");
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_State_InsertUserID";
                objCmd.ExecuteNonQuery();
                txtStateCode.Text = "";
                txtStateName.Text = "";
                ddlCountryID.SelectedValue = "-1";
                ddlCountryID.Focus();
                lblMessage.Attributes.CssStyle.Add("color", "green");
                lblMessage.Text = "Data Inserted...!";
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
                lblMessage.Text += "State already exists..";
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
    protected void FillControls(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByPKUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    if (!objSDR["StateCode"].Equals(DBNull.Value))
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
                lblText.Text = "No data available";
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
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/List", true);
    }
    #endregion Button : Cancel
}