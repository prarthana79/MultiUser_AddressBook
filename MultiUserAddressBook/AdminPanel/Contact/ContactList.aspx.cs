using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_Contact : System.Web.UI.Page
{

    #region Event : Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactGridView();
        }
    }
    #endregion Event : Page Load

    #region Fill Data
    private void FillContactGridView()
    {
        
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            #region Open Connection, Declare SqlCommand Objects, Set DDLFilter Values, Execute Reader, Fill Country GV & Close Connection
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;

           
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByUserID]";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                gvContact.DataSource = objSDR;
                gvContact.DataBind();
            }
            else
            {
                gvContact.DataSource = null;
                gvContact.DataBind();
            }
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Open Connection, Declare SqlCommand Objects, Set DDLFilter Values, Execute Reader, Fill Country GV & Close Connection
        }
        catch (Exception ex)
        {
            #region  Display Appropriate Message
            lblText.Text = "<strong>" + ex.Message + "</strong>";
            lblText.ForeColor = System.Drawing.Color.Red;
            #endregion : Display Appropriate Message
        }
        finally
        {
            #region Close Connection
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Close Connection
        }
    }
    #endregion Fill Data

    #region Function : DeleteContact()
    private void DeleteContact(SqlInt32 ContactID)
    {
        #region Establish Connection And Set Connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Establish Connection And Set Connection String

        try
        {
            #region Open Connection, Create SqlCommand & Delete Record
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_DeleteByUserID]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.ExecuteNonQuery();

            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Open Connection, Create SqlCommand & FillGridView

            #region Display Appropriate Msg
            lblText.Text = "<strong>Contact Deleted Successfully</strong>";
            lblText.ForeColor = System.Drawing.Color.ForestGreen;
            
            #endregion Display Appropriate Msg

            #region Fill THe GridView Again After Deleting The Record
            FillContactGridView();
            #endregion Fill THe GridView Again After Deleting The Record
        }
        catch (Exception ex)
        {
            #region Display Appropriate Msg
            lblText.Text = "<strong>" + ex.Message + "</strong>";
            lblText.ForeColor = System.Drawing.Color.Red;
            
            #endregion Display Appropriate Msg
        }
        finally
        {
            #region Close Connection
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Close Connection
        }
    }
    #endregion Function : DeleteContact()

    #region Function : DeleteFile()
    private void DeleteFile(SqlInt32 ContactID)
    {
        String LogicalPath = "";

        #region Establish Connection And Set Connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Establish Connection And Set Connection String

        try
        {
            #region Open Connection, Create SqlCommand & Delete Record
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_GetLogicalPath_ByUserID_ByContactID]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    LogicalPath = objSDR["ContactPhotoPath"].ToString();
                }
            }

            if (objConn.State != ConnectionState.Closed)
                objConn.Close();

            String AbsolutePath = Server.MapPath(LogicalPath);
            FileInfo file = new FileInfo(AbsolutePath);
            lblText.Text = AbsolutePath + "----" + file.Exists;
            
            if (file.Exists)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                file.Delete();
                lblText.Text = "File Deleted";
            }
            else
            {
                lblText.Text = "File Not Found";
            }



            #endregion Open Connection, Create SqlCommand & FillGridView
        }
        catch (Exception ex)
        {
            #region Display Appropriate Msg
            lblText.Text = "<strong>" + ex.Message + "</strong>";
            lblText.ForeColor = System.Drawing.Color.Red;
            #endregion Display Appropriate Msg
        }
        finally
        {
            #region Close Connection
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Close Connection
        }
    }
    #endregion Function : DeleteFile()

    #region Function : DeleteRecordOfContactWiseContactCategory()
    private void DeleteRecordOfContactWiseContactCategory(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            #region Open Connection, Create SqlCommand & Delete Record
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactWiseContactCategory_DeleteByUserID]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.ExecuteNonQuery();
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Open Connection, Create SqlCommand & FillGridView
        }
        catch (Exception ex)
        {
            #region Display Appropriate Msg
            lblText.Text = "<strong>" + ex.Message + "</strong>";
            lblText.ForeColor = System.Drawing.Color.Red;
            #endregion Display Appropriate Msg
        }
        finally
        {
            #region Close Connection
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Close Connection
        }
    }
    #endregion Function : DeleteRecordOfContactWiseContactCategory()


    #region Event : ddlFilter_SelectedIndexChanged()
    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillContactGridView();
    }
    #endregion Event : ddlFilter_SelectedIndexChanged()

    #region Event : gvContact_RowCommand()
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteFile(Convert.ToInt32(e.CommandArgument.ToString().Trim()));   
                DeleteRecordOfContactWiseContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                //Try Deleting The Photo File From Here As CommandArgument Has The ContactID...
            }
        }
    }
    #endregion Event : gvContact_RowCommand()

    #region Bound data

    protected void gvContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[1].Text = "data fetching";
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                String filePath = "";

                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_Contact_SelectByPKUserID]";
                if (Session["UserID"] != null)
                    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                objCmd.Parameters.AddWithValue("@ContactID", e.Row.Cells[2].Text.Trim());
                SqlDataReader objSDR = objCmd.ExecuteReader();
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["contactphotopath"].Equals(DBNull.Value))
                            filePath = objSDR["contactphotopath"].ToString().Trim();
                        break;
                    }
                }

                FileInfo fi = new FileInfo(Server.MapPath(filePath));

                System.Drawing.Image data = System.Drawing.Image.FromFile(Server.MapPath(filePath));
                e.Row.Cells[1].Text = "Size : || " + fi.Length / 1024 + " KB<br />Height : || " + data.Height + " pixels<br />Weight : || " + data.Width + " pixels<br />Type : || " + fi.Extension;
                objSDR.Close();
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
            catch (Exception ex)
            {
                lblText.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }

    }
    #endregion Bound data
}