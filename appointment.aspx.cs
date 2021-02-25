using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib
{
    public partial class appointment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["userID"]) > 0)
            {
                if (!Page.IsPostBack)
                {
                    fullname.Text = dbm.getFullName(Convert.ToInt32(Session["userID"]));
                    selectedTable.Text = "";
                    getTable.Text = "";
                    Calendar1.SelectedDate = DateTime.Now.Date;
                    selectedTable.Visible = false;
                    Repeater1.DataSource = dbm.showTables();
                    Repeater1.DataBind();

                    Repeater2.DataSource = dbm.showAppoUser(Convert.ToInt32(Session["userID"]));
                    Repeater2.DataBind();
                }
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

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DateTime date = Calendar1.SelectedDate;
            int userID = Convert.ToInt32(Session["userID"]);
            int timeID = Convert.ToInt32(times.SelectedValue);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RepeaterItem item = e.Item;
                Button tableBtn = item.FindControl("table") as Button;
                string tableName = tableBtn.Text;

                if (dbm.tableCheck(userID, date,timeID,tableName) == true)
                {
                    tableBtn.CssClass = "btn btn-secondary p";
                    tableBtn.Enabled = false;
                }
                else
                {
                    tableBtn.Enabled = true;
                    tableBtn.CssClass = "btn btn-primary p";
                }
            }
        }

        protected void OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Click")
            {
                RepeaterItem item = e.Item;
                Button tableBtn = item.FindControl("table") as Button;
                string tableName = tableBtn.Text;

                if (tableBtn.Enabled)
                {
                    selectedTable.Visible = true;
                    selectedTable.Text = "Seçtiğiniz Masa : " + tableName;
                    getTable.Text = tableName;
                }
            }
        }

        protected void OnCalendarChanged(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate < DateTime.Now.Date)
            {
                labelShowHide(Label3);
                Calendar1.SelectedDate = DateTime.Now.Date;
            }
            Repeater1.DataSource = dbm.showTables();
            Repeater1.DataBind();
            selectedTable.Visible = false;
            selectedTable.Text = "";
            getTable.Text = "";
        }

        protected void OnTimesChanged(object sender, EventArgs e)
        {
            Repeater1.DataSource = dbm.showTables();
            Repeater1.DataBind();
            selectedTable.Visible = false;
            selectedTable.Text = "";
            getTable.Text = "";
        }

        protected void labelShowHide(Label labelName)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + labelName.ClientID + "').style.display='block'\",100)</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + labelName.ClientID + "').style.display='none'\",2000)</script>");
        }

        protected void getAppo(object sender, EventArgs e)
        {
            DateTime date = Calendar1.SelectedDate;
            int userID = Convert.ToInt32(Session["userID"]);
            int timeID = Convert.ToInt32(times.SelectedValue);
            if (getTable.Text != "")
            {
                if (dbm.tableCheck(userID, date, timeID, getTable.Text) == false)
                {
                    dbm.tableAppo(userID, date, timeID, getTable.Text);
                    labelShowHide(Label2);
                    Repeater1.DataSource = dbm.showTables();
                    Repeater1.DataBind();
                    selectedTable.Visible = false;
                    selectedTable.Text = "";
                    getTable.Text = "";
                    Repeater2.DataSource = dbm.showAppoUser(Convert.ToInt32(Session["userID"]));
                    Repeater2.DataBind();
                }
                else
                {
                    labelShowHide(Label1);
                    Repeater1.DataSource = dbm.showTables();
                    Repeater1.DataBind();
                    selectedTable.Visible = false;
                    selectedTable.Text = "";
                    getTable.Text = "";
                }
            }
            else
            {
                labelShowHide(Label4);
            }
        }
    }
}