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

public partial class AdminPanel_Home : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //FillData();
        //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
    }

    #endregion Load Event

    #region Fill Data
    //protected void FillData()
    //{
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
    //    try {
    //        #region Set Connection & Command Object
    //        if (objConn.State != System.Data.ConnectionState.Open)
    //            objConn.Open();
    //        SqlCommand objCmd = new SqlCommand();
    //        objCmd.Connection = objConn;
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_UserDataByPK";
    //        #endregion Set Connection & Command Object

    //        #region Read the value and Set the controls
    //        SqlDataReader objSDR = objCmd.ExecuteReader();
    //        if (objSDR.HasRows)
    //        {
    //            gvUser.DataSource = objSDR;
    //            gvUser.DataBind();
    //        }
    //        #endregion Read the value and Set the controls
    //    }
    //    catch (Exception ex)
    //    {
    //        lblText.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Close();
    //    }
    //}
    #endregion Fill Data
}