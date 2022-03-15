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
            txtCountryName.Focus();
            if (Page.RouteData.Values["CountryID"] != null)
            {
                //lblText.Text = "Edit mode | CountryID = " + System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["CountryID"].ToString()));
                FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["CountryID"].ToString()))));
            }

            //else
                //lblText.Text = "Add Mode";
        }
    }
    #endregion Load Event

    #region Fill Controls
    protected void FillControls(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPKUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
                lblMessage.Text = "No data available";
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

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String strErrorMessage = "";
        #region Local Variables
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        #endregion Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Server Side Validation
            if (txtCountryName.Text.Trim() == "")
                strErrorMessage += " - Enter Country Name <br />";
            if (strErrorMessage != "")
            {
                lblMessage.Text += strErrorMessage;
                return;
            }
            #endregion Server Side Validation
            #region Gather Information
            if (txtCountryName.Text.Trim() != "")
            {
                strCountryName = txtCountryName.Text.Trim();
                strCountryCode = txtCountryCode.Text.Trim();
            }
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            #endregion Set Connection & Command Object
            if (Page.RouteData.Values["CountryID"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@CountryID", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["CountryID"].ToString().Trim())));
                objCmd.CommandText = "PR_Country_UpdateByUserID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/List");
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_Country_InsertUserID";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data Inserted...!";
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryName.Focus();
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
                lblMessage.Text += "Country already exists..";
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

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/List", true);
    }
    #endregion Button : Cancel
}