using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            if (dbm.userCheck(username.Text) == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel2", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + loginError.ClientID + "').style.display='block';\",100);</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel2", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + loginError.ClientID + "').style.display='none';\",2000);</script>");                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel2", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + loginError.ClientID + "').style.display='none';\",2000);</script>");
            }
            else
            {
                if (!string.IsNullOrEmpty(username.Text) && !string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(surname.Text) && !string.IsNullOrEmpty(address.Text))
                {
                    dbm.register(username.Text, password.Text, name.Text, surname.Text, Convert.ToInt32(age.SelectedValue), address.Text, 0);
                    Session["userID"] = dbm.userLogin(username.Text, password.Text);
                    Response.Redirect("index.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel1", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + registerError.ClientID + "').style.display='block';\",100);</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel1", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + registerError.ClientID + "').style.display='none';\",2000);</script>");
                }
            }
        }
    }
}