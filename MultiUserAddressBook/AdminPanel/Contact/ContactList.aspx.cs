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
            FillData();
        }
    }
    #endregion Event : Page Load

    #region Fill Data
    private void FillData()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByUserID";
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
            #endregion Set Connection & Command Object

            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection

        }
        catch (Exception ex)
        {
            #region  Display Appropriate Message
            lblText.Text = ex.Message;
            #endregion : Display Appropriate Message
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

    #region Delete Contact
    private void DeleteContact(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_DeleteByUserID";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            objCmd.ExecuteNonQuery();

            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection

            #region Display Appropriate Message
            lblText.Text = "<strong>Contact Deleted Successfully</strong>";
            #endregion Display Appropriate Message

            #region Fill Data after deleting
            FillData();
            #endregion Fill Data after deleting
        }
        catch (Exception ex)
        {
            #region Display Appropriate Message
            lblText.Text = ex.Message;
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
    #endregion Delete Contact

    #region Delete File
    private void DeleteFile(SqlInt32 ContactID)
    {
        String LogicalPath = "";

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set Connection & Command Object
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
            #endregion Set Connection & Command Object

            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection

            #region Delete from Directory
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
            #endregion Delete from Directory
        }
        catch (Exception ex)
        {
            #region Display Appropriate Message
            lblText.Text = ex.Message;
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
    #endregion Delete File

    #region Delete Contact Wise ContactCategory
    private void DeleteRecordOfContactWiseContactCategory(SqlInt32 ContactID)
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
            objCmd.CommandText = "PR_ContactWiseContactCategory_DeleteByUserID";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.ExecuteNonQuery();
            #endregion Set Connection & Command Object

            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
        catch (Exception ex)
        {
            #region Display Appropriate Message
            lblText.Text = ex.Message;
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
    #endregion Delete Contact Wise ContactCategory

    #region Grid View
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteFile(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                //return;
                DeleteRecordOfContactWiseContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                //Try Deleting The Photo File From Here As CommandArgument Has The ContactID...
            }
        }
    }
    #endregion Grid View

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

                #region Close Connection
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                #endregion Close Connection
            }
            catch (Exception ex)
            {
                #region Display Appropriate Message
                lblText.Text = ex.Message;
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

    }
    #endregion Bound data

}