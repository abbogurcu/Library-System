using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib
{
    public partial class item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["userID"]) > 0)
            {
                fullname.Text = dbm.getFullName(Convert.ToInt32(Session["userID"]));
                if (!Page.IsPostBack)
                {
                    DataTable category = dbm.getCategory();

                    DropDownList1.DataSource = category;
                    DropDownList1.DataTextField = "cat";
                    DropDownList1.DataValueField = "catID";
                    DropDownList1.DataBind();

                    DataTable books = dbm.getBooks2(Convert.ToInt32(DropDownList1.SelectedValue));
                    if (books.Rows.Count == 0)
                    {
                        books.Rows.Add(-1, "Bu kategoriye ait kitap bulunmamaktadir.");
                    }

                    DropDownList2.DataSource = books;
                    DropDownList2.DataTextField = "item";
                    DropDownList2.DataValueField = "itemID";
                    DropDownList2.DataBind();

                    if (DropDownList2.SelectedValue.ToString() == "-1")
                    {
                        writerDiv.Visible = false;
                    }
                    else
                    {
                        writerDiv.Visible = true;
                        labelWriter.Text= dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
                    }
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

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable books = dbm.getBooks2(Convert.ToInt32(DropDownList1.SelectedValue));
            if (books.Rows.Count == 0)
            {
                books.Rows.Add(-1, "Bu kategoriye ait kitap bulunmamaktadir.");
            }

            DropDownList2.DataSource = books;
            DropDownList2.DataTextField = "item";
            DropDownList2.DataValueField = "itemID";
            DropDownList2.DataBind();

            if (DropDownList2.SelectedValue.ToString() == "-1")
            {
                writerDiv.Visible = false;
            }
            else
            {
                writerDiv.Visible = true;
                labelWriter.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
            }
        }

        protected void OnSelectedIndexChanged2(object sender, EventArgs e)
        {

            if (DropDownList2.SelectedValue.ToString() == "-1")
            {
                writerDiv.Visible = false;
            }
            else
            {
                writerDiv.Visible = true;
                labelWriter.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
            }
        }

        protected void getItem(object sender, EventArgs e)
        {
            if (dbm.itemCheck(Convert.ToInt32(DropDownList2.SelectedValue))==true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + Label1.ClientID + "').style.display='block'\",100)</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + Label1.ClientID + "').style.display='none'\",2000)</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + Label2.ClientID + "').style.display='block'\",100)</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + Label2.ClientID + "').style.display='none'\",2000)</script>");
                dbm.getItem(Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(Session["userID"]), DateTime.Now.Date);
            }



            DataTable books = dbm.getBooks2(Convert.ToInt32(DropDownList1.SelectedValue));
            if (books.Rows.Count == 0)
            {
                books.Rows.Add(-1, "Bu kategoriye ait kitap bulunmamaktadir.");
            }

            DropDownList2.DataSource = books;
            DropDownList2.DataTextField = "item";
            DropDownList2.DataValueField = "itemID";
            DropDownList2.DataBind();

            if (DropDownList2.SelectedValue.ToString() == "-1")
            {
                writerDiv.Visible = false;
            }
            else
            {
                writerDiv.Visible = true;
                labelWriter.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
            }
        }
    }
}