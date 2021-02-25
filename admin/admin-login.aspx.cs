using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib
{
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logicBtn_Click(object sender, EventArgs e)
        {
            if (dbm.adminLogin(username.Text, password.Text)!=null)
            {
                Session["adminID"] = dbm.adminLogin(username.Text, password.Text);
                Response.Redirect("admin.aspx");
            }
            else
            {
                loginError.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + loginError.ClientID + "').style.visibility='hidden';\",3000)</script>");
            }
        }
    }
}