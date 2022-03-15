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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            ddlCountryID.Focus();
            if (Page.RouteData.Values["ContactId"] != null)
            {
                //lblText.Text = "Edit mode | ContactID = " + System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactId"].ToString()));
                FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactId"].ToString()))));
                FillCheckedCBLContactCategoryID(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactId"].ToString()))));
            }
            //else
                //lblText.Text = "Add Mode";
        }
    }
    #endregion Load Event

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListContactCategory(cblContactCategory);
        CommonDropDownFillMethods.FillDropDownListBloodGroup(ddlBloodGroup, ddlStateID, ddlCity);
        CommonDropDownFillMethods.FillDropDownListCity(ddlCity, ddlStateID);
        CommonDropDownFillMethods.FillDropDownListState(ddlStateID, ddlCity, ddlCountryID);
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID);
    }
    #endregion Fill DropDownList

    #region Fill Controls
    protected void FillControls(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByPKUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Read the value and set the controls

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                        CommonDropDownFillMethods.FillDropDownListState(ddlStateID, ddlCity, ddlCountryID);
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                        CommonDropDownFillMethods.FillDropDownListCity(ddlCity, ddlStateID);
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCity.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    //if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    //{
                    //    cblContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    //}
                    if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
                    {
                        ddlBloodGroup.SelectedValue = objSDR["BloodGroupID"].ToString().Trim();
                    }
                    if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                    {
                        fuFile.SaveAs(Server.MapPath(objSDR["ContactPhotoPath"].ToString().Trim()));
                    }
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                    {
                        txtWhatsAppNo.Text = objSDR["WhatsAppNo"].ToString().Trim();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"]).ToString("yyyy-MM-dd");
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (!objSDR["EmailID"].Equals(DBNull.Value))
                    {
                        txtEmailID.Text = objSDR["EmailID"].ToString().Trim();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                    {
                        txtFacebookID.Text = objSDR["FacebookID"].ToString().Trim();
                    }
                    if (!objSDR["LinkedInID"].Equals(DBNull.Value))
                    {
                        txtLinkedInID.Text = objSDR["LinkedInID"].ToString().Trim();
                    }
                    //lblMessage.Text = objSDR["StateID"].ToString().Trim() + " + "+ddlStateID.SelectedValue;

                     //Change Made
                    hfImagePath.Value = objSDR["ContactPhotoPath"].ToString();
                    imgUrl.EnableViewState = true;
                    imgUrl.Height = 90;
                    imgUrl.ImageUrl = objSDR["ContactPhotoPath"].ToString();

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
    #endregion Fill Controls

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";
        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += " - Select Country <br />";
        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += " - Select State <br />";
        if (ddlCity.SelectedIndex == 0)
            strErrorMessage += " - Select City <br />";
        if (cblContactCategory.SelectedItem == null)
            strErrorMessage += " - Select atleast one Contact Category <br />";
        if (ddlBloodGroup.SelectedIndex == 0)
            strErrorMessage += " - Select Blood Group <br />";
        if (txtContactName.Text.Trim() == "")
            strErrorMessage += " - Enter Contact Name <br />";
        if (txtContactNo.Text.Trim() == "")
            strErrorMessage += " - Enter Contact No <br />";
        if (txtEmailID.Text.Trim() == "")
            strErrorMessage += " - Enter EmailID <br />";
        if (txtAddress.Text.Trim() == "")
            strErrorMessage += " - Enter Address <br />";
        if (txtBirthDate.Text.Trim() == "")
            strErrorMessage += " - Enter BirthDate <br />";
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation    

        #region Local Variables
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlDateTime dtBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strFaceBookID = SqlString.Null;
        SqlString strLinkedInID = SqlString.Null;
        SqlInt32 strBloodGroupID = SqlInt32.Null;
        String strContactImg = "";
        #endregion Local Variables

        #region saveFile
        if (fuFile.HasFile)
            {
                // --------------------- Your Code --------------------------
                // string fileExt = System.IO.Path.GetExtension(fuFile.FileName);
                // if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".png")
                // {
                //     String name = fuFile.FileName;
                //     // String _fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + name;
                //     strContactImg = "~/UserContent/" + fuFile.FileName.ToString().Trim();
                //     lblMessage.Text = strContactImg + fuFile.FileName;
                //     //if(!Directory.Exists(Server.MapPath(strContactImg)))
                //     //    Directory.CreateDirectory(Server.MapPath(strContactImg));
                //     fuFile.SaveAs(Server.MapPath(strContactImg));
                //     objCmd.Parameters.AddWithValue("@ContactPhotoPath", strContactImg);
                // }
                // else
                // {
                //     lblMessage.Text = "Please select proper format";
                // }
                // --------------------- Your Code --------------------------

                #region Create FolderPath , AbsolutePath & ContactPhotoPath
                String FolderPath = "~/UserContent/";
                String AbsolutePath = Server.MapPath(FolderPath);
                // Time Stamp Is To Be Given Here
                strContactImg = FolderPath + fuFile.FileName.ToString().Trim();
                #endregion Create FolderPath , AbsolutePath & ContactPhotoPath

                #region Create Directory If Does Not Exists
                if (!Directory.Exists(AbsolutePath))
                {
                    Directory.CreateDirectory(AbsolutePath);
                }
                #endregion Create Directory If Does Not Exists

                #region Save File
                fuFile.SaveAs(AbsolutePath + fuFile.FileName.ToString().Trim());
            //fuFile.PostedFile.InputStream.Dispose();
                #endregion Save File
        }    
        #endregion saveFile
        
        #region Gather Information
        if (ddlCountryID.SelectedIndex > 0)
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        if (ddlStateID.SelectedIndex > 0)
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
        if (ddlCity.SelectedIndex > 0)
            strCityID = Convert.ToInt32(ddlCity.SelectedValue);
        if (cblContactCategory.SelectedIndex > 0)
            strContactCategoryID = Convert.ToInt32(cblContactCategory.SelectedValue);
        if (ddlBloodGroup.SelectedIndex > 0)
            strBloodGroupID = Convert.ToInt32(ddlBloodGroup.SelectedValue);
        if (txtContactName.Text.Trim() != "")
            strContactName = txtContactName.Text.Trim();
        if (txtContactNo.Text.Trim() != "")
            strContactNo = txtContactNo.Text.Trim();
        if (txtEmailID.Text.Trim() != "")
            strEmail = txtEmailID.Text.Trim();
        if (txtAddress.Text.Trim() != "")
            strAddress = txtAddress.Text.Trim();
        if (txtBirthDate.Text.Trim() != "")
            dtBirthDate = DateTime.Parse(txtBirthDate.Text);
        strWhatsAppNo = txtWhatsAppNo.Text.Trim();
        strAge = txtAge.Text.Trim();
        strFaceBookID = txtFacebookID.Text.Trim();
        strLinkedInID = txtLinkedInID.Text.Trim();
        #endregion Gather Information

        if (strAge == "")
        {
            strAge = (DateTime.Now.Year - ((DateTime)dtBirthDate).Year).ToString();
        }

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@BloodGroupID", strBloodGroupID);
            objCmd.Parameters.AddWithValue("@CountryId", strCountryID);
            objCmd.Parameters.AddWithValue("@StateId", strStateID);
            objCmd.Parameters.AddWithValue("@CityId", strCityID);
            
            //Change Here
            if (fuFile.HasFile)
            {
                objCmd.Parameters.AddWithValue("@ContactPhotoPath", strContactImg);
            }
            else
            {
                objCmd.Parameters.AddWithValue("@ContactPhotoPath", hfImagePath.Value);
            }
            //Change Here
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@WhatsAppNo", strWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", dtBirthDate);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@EmailID", strEmail);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@FaceBookID", strFaceBookID);
            objCmd.Parameters.AddWithValue("@LinkedInID", strLinkedInID);


            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["ContactId"] != null)
            {
                #region Update Record

                #region Delete OldPhoto Directory
                if (fuFile.HasFile)
                {
                    DeleteOldPhoto(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactID"].ToString().Trim()))));
                }
                #endregion Delete OldPhoto Directory

                #region Delete ContactCategory
                SqlCommand objCmdCBLDelelete = new SqlCommand();
                objCmdCBLDelelete.Connection = objConn;
                objCmdCBLDelelete.CommandType = CommandType.StoredProcedure;
                objCmdCBLDelelete.CommandText = "PR_ContactWiseContactCategory_DeleteByUserID";
                if (Session["UserID"] != null)
                    objCmdCBLDelelete.Parameters.AddWithValue("@UserID", Session["UserID"]);
                objCmdCBLDelelete.Parameters.AddWithValue("@ContactID", Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactID"].ToString().Trim()))));
                objCmdCBLDelelete.ExecuteNonQuery();
                #endregion Delete ContactCategory

                #region Insert ContactCategory
                foreach (ListItem liContactCategoryID in cblContactCategory.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        #region ContactWiseContactCategory Insert
                        SqlCommand objCmdContactCategory = objConn.CreateCommand();
                        objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_InsertByUserID";
                        if (Session["UserID"] != null)
                            objCmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"]);
                        objCmdContactCategory.Parameters.AddWithValue("@ContactID", Convert.ToInt32(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactID"].ToString().Trim()))));
                        objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value);
                        objCmdContactCategory.ExecuteNonQuery();
                        #endregion ContactWiseContactCategory Insert
                    }
                }
                #endregion Insert ContactCategory

                objCmd.Parameters.AddWithValue("@ContactID", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Page.RouteData.Values["ContactID"].ToString().Trim())));
                objCmd.CommandText = "PR_Contact_UpdateByUserID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/List");

                #endregion Update Record

                #region Close Connection
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                #endregion Close Connection
            }
            else
            {
                #region Insert Record

                #region Validate FileUpload Control
                if (!fuFile.HasFile)
                {
                    strErrorMessage = "<strong>Please Select A Contact Photo</strong>";
                    lblMessage.Text = strErrorMessage;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                #endregion Validate FileUpload Control

                objCmd.CommandText = "PR_Contact_InsertUserID";
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                objCmd.ExecuteNonQuery();

                SqlInt32 ContactID = 0;
                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                #region Insert ContactCategory
                foreach (ListItem liContactCategoryID in cblContactCategory.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        #region ContactWiseContactCategory Insert
                        SqlCommand objCmdContactCategory = objConn.CreateCommand();
                        objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_InsertByUserID";
                        if (Session["UserID"] != null)
                            objCmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"]);
                        objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value);
                        objCmdContactCategory.ExecuteNonQuery();
                        #endregion ContactWiseContactCategory Insert
                    }
                }
                #endregion Insert ContactCategory

                #region Reset Data
                txtContactName.Text = "";
                txtContactNo.Text = "";
                txtWhatsAppNo.Text = "";
                txtBirthDate.Text = "";
                txtEmailID.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtFacebookID.Text = "";
                txtLinkedInID.Text = "";
                ddlCountryID.Focus();
                ddlCountryID.SelectedValue = "-1";
                ddlStateID.SelectedValue = "-1";
                ddlCity.SelectedValue = "-1";
                cblContactCategory.ClearSelection();
                ddlBloodGroup.SelectedValue = "-1";
                #endregion Reset Data

                lblMessage.Text = "Data Inserted...!";

                #endregion Insert Record

                #region Close Connection
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                #endregion Close Connection
            }
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
    #endregion Button : Submit

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/List", true);
    }
    #endregion Button : Cancel

    #region FillState From CountryID change
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonDropDownFillMethods.FillDropDownListState(ddlStateID, ddlCity, ddlCountryID);
        ddlStateID.Focus();
    }
    #endregion FillState From CountryID change

    #region FillCity From StateID change
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonDropDownFillMethods.FillDropDownListCity(ddlCity, ddlStateID);
        ddlCity.Focus();
    }
    #endregion FillCity From StateID change

    #region Delete Old Image
    private void DeleteOldPhoto(SqlInt32 ContactID)
    {
        String oldLogicalPath = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            //lblText.Text = "Hii";
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_GetLogicalPath_ByUserID_ByContactID";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region get LogicalPath
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    oldLogicalPath = objSDR["ContactPhotoPath"].ToString();
                }
            }
            #endregion get LogicalPath

            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection

            #region DeleteFromDirectory
            String AbsolutePath = Server.MapPath(oldLogicalPath);
            FileInfo file = new FileInfo(AbsolutePath);
            if (file.Exists)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                file.Delete();
                lblMessage.Text = "Deleted";
            }
            else
            {
                lblMessage.Text = "File Not Found";
            }
            #endregion DeleteFromDirectory
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
    #endregion Delete Old Image

    #region Fill CheckBoxList Checked Items
    private void FillCheckedCBLContactCategoryID(SqlInt32 ContacttID)
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
            objCmd.CommandText = "PR_ContactWiseContactCategory_SelectByPKUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.Parameters.AddWithValue("@ContactID", ContacttID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    foreach (ListItem li in cblContactCategory.Items)
                    {
                        if (objSDR["ContactCategoryId"].ToString() == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
                return;
            }
            else
            {
                lblMessage.Text = "Nothing available";
            }
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
    #endregion Fill CheckBoxList Checked Items

}