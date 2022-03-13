
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

public partial class AdminPanel_loggin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";
        if (txtUserName.Text.Trim() == String.Empty)
            strErrorMessage += "- Enter UserName<br />";
        if (txtPassword.Text.Trim() == String.Empty)
            strErrorMessage += "- Enter Password<br />";
        lblMessage.Text = strErrorMessage;
        #endregion Server Side Validation

        #region Assign the Values
        if (txtUserName.Text.Trim() != "")
            strUserName = txtUserName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            strPassword = txtPassword.Text.Trim();
        #endregion Assign the Values

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUserNamePassword";
            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    
                    break;
                }
                Response.Redirect("/Home", true);
            }
            else
                if(lblMessage.Text.Trim()=="")
                    lblMessage.Text = "- Invalid UserName or Password";
            #endregion Read the value and set the controls
            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
        catch (Exception ex)
        {
            #region Display Appropriate Message
            lblMessage.Text += ex.Message;
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

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("/SignUp", true);
    }
}