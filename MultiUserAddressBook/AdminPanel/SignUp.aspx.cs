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

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String strErrorMessage = "";
        #region Local Variables
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strEmailID = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;

        #endregion Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Server Side Validation
            if (txtUserName.Text.Trim() == "")
                strErrorMessage += "- Enter User Name<br />";
            if (txtPassword.Text.Trim() == "")
                strErrorMessage += "- Enter Password<br />";
            if (txtDisplayName.Text.Trim() == "")
                strErrorMessage += "- Enter Display Name";
            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information
            if (txtUserName.Text.Trim() != "")
                strUserName = txtUserName.Text.Trim();
            if (txtPassword.Text.Trim() != "")
                strPassword = txtPassword.Text.Trim();
            if (txtDisplayName.Text.Trim() != "")
                strDisplayName = txtDisplayName.Text.Trim();
            strEmailID = txtEmailID.Text.Trim();
            strMobileNo = txtMobileNo.Text.Trim();
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
            objCmd.Parameters.AddWithValue("@EmailID", strEmailID);
            objCmd.Parameters.AddWithValue("@MobileNo", strMobileNo);
            #endregion Set Connection & Command Object

            #region Insert Record
            objCmd.CommandText = "PR_User_Insert";
            objCmd.ExecuteNonQuery();
            lblText.Text = "Data Inserted...!";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtDisplayName.Text = "";
            txtEmailID.Text = "";
            txtMobileNo.Text = "";
            txtUserName.Focus();
            #endregion Insert Record
        }
        catch (Exception ex)
        {
            if (ex.Message.Equals ("Violation of UNIQUE KEY constraint 'IX_User'. Cannot insert duplicate key in object 'dbo.User'. The duplicate key value is (" + strUserName.ToString() + "). The statement has been terminated."))
                lblText.Text = "Invalid UserName, Try something New";
            lblText.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/LogIn", true);
    }
}