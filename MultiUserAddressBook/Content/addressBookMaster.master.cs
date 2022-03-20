using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_addressBookMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("/LogIn", true);
        if (!Page.IsPostBack)
        {
            if (Session["DisplayName"] != null)
                lblUserName.Text = "<u>"+Session["DisplayName"] + "!</u>";
        }
    }

    protected void lbtnLogOut_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(2000);
        Session.Clear();
        
        Response.Redirect("/LogIn", true);
    }
}
