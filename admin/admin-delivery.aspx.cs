using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib.admin
{
    public partial class admin_delivery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToInt32(Session["adminID"]) > 0)
                {
                    if (dbm.itemHistoryAdmin().Rows.Count > 0)
                    {
                        tableBookEmpty.Visible = false;
                        tableBook.Visible = true;
                        Repeater1.DataSource = dbm.itemHistoryAdmin();
                        Repeater1.DataBind();
                    }
                    else
                    {
                        tableBook.Visible = false;
                        tableBookEmpty.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("admin-login.aspx");
                }
            }
        }

        protected void OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                dbm.updateItemStatus(Convert.ToInt32(e.CommandArgument));

                if (dbm.itemHistoryAdmin().Rows.Count > 0)
                {
                    tableBookEmpty.Visible = false;
                    tableBook.Visible = true;
                    Repeater1.DataSource = dbm.itemHistoryAdmin();
                    Repeater1.DataBind();
                }
                else
                {
                    tableBook.Visible = false;
                    tableBookEmpty.Visible = true;
                }
            }
        }

        protected void OnTextChanged(object sender, EventArgs e)
        {
            if (dbm.itemHistoryAdmin2(username.Text).Rows.Count > 0)
            {
                tableBookEmpty.Visible = false;
                tableBook.Visible = true;
                Repeater1.DataSource = dbm.itemHistoryAdmin2(username.Text);
                Repeater1.DataBind();
            }
            else
            {
                tableBook.Visible = false;
                tableBookEmpty.Visible = true;
            }
        }
    }
}