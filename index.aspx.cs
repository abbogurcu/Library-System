using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["userID"])>0)
            {
                fullname.Text = dbm.getFullName(Convert.ToInt32(Session["userID"]));
                Repeater1.DataSource = dbm.itemHistoryUser(Convert.ToInt32(Session["userID"]));
                Repeater1.DataBind();
            }
            else
            {
                Response.Redirect("login.aspx?redirect");
            }
        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx?logout");
        }
    }
}