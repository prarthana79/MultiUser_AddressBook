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

        #region Local Variables
        String strErrorMessage = "";
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
            #endregion Insert Record
            //#region reset data
            //lblText.Text = "Data Inserted...!";
            //txtUserName.Text = "";
            //txtPassword.Text = "";
            //txtDisplayName.Text = "";
            //txtEmailID.Text = "";
            //txtMobileNo.Text = "";
            //txtUserName.Focus();
            //#endregion reset data
            System.Threading.Thread.Sleep(2000);
            Response.Redirect("/LogIn", true);


            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
        catch(SqlException sqlEx)
        {
            if(sqlEx.Number == 2627)
            {
                lblMessage.Text = "UserName already exists..";
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/LogIn", true);
    }
}