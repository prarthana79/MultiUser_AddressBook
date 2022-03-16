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
            FillDropDownList();
            ddlCountryID.Focus();
            if (Page.RouteData.Values["CityId"] != null)
            {
                //lblText.Text = "Edit mode | CityID = " + System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["CityId"].ToString()));
                FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["CityId"].ToString()))));
            }

            //else
                //lblText.Text = "Add Mode";
        }
    }
    #endregion Load Event

    #region Fill DropDownList
    protected void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListState(ddlStateID, ddlCountryID);
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID);
    }
    #endregion Fill DropDownList

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        String strErrorMessage = "";
        #endregion Local Variables


        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Server Side Validation
            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += " - Select Country <br />";

            if (ddlStateID.SelectedIndex == 0)
                strErrorMessage += " - Select State <br />";

            if (txtCityName.Text.Trim() == "")
                strErrorMessage += " - Enter City Name <br />";
            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information


            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            if (txtCityName.Text.Trim() != "")
                strCityName = txtCityName.Text.Trim();

            strSTDCode = txtSTDCode.Text.Trim();
            strPinCode = txtPinCode.Text.Trim();
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateId", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["CityId"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@CityID", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["CityId"].ToString().Trim())));
                objCmd.CommandText = "PR_City_UpdateByUserID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/List");
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_City_InsertUserID";
                objCmd.ExecuteNonQuery();
                txtPinCode.Text = "";
                txtSTDCode.Text = "";
                txtCityName.Text = "";
                ddlStateID.SelectedValue = "-1";
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
                lblMessage.Text += "City already exists..";
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

    #region FillControls
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
            objCmd.CommandText = "PR_City_SelectByPKUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CityID", StateID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                        CommonDropDownFillMethods.FillDropDownListState(ddlStateID, ddlCountryID);
                    }
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();

                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
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
        Response.Redirect("~/AdminPanel/City/List", true);
    }
    #endregion Button : Cancel

    #region FillState From CountryID change
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonDropDownFillMethods.FillDropDownListState(ddlStateID,ddlCountryID);
        ddlStateID.Focus();
    }
    #endregion FillState From CountryID change
}