using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib.admin
{
    public partial class admin_item : System.Web.UI.Page
    {
        static SqlConnection conn = getConnection();
        public static SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["adminID"]) > 0)
            {
                Repeater1.DataSource = dbm.itemHistoryUser2();
                Repeater1.DataBind();
            }
            else
            {
                Response.Redirect("admin-login.aspx");
            }


            if (!Page.IsPostBack)
            {
                DataTable category = dbm.getCategory();

                if (category.Rows.Count == 0)
                {
                    Response.Redirect("admin.aspx");
                }

                DropDownList1.DataSource = category;
                DropDownList1.DataTextField = "cat";
                DropDownList1.DataValueField = "catID";
                DropDownList1.DataBind();

                DataTable books = dbm.getBooks(Convert.ToInt32(DropDownList1.SelectedValue));
                books.Rows.Add(-1, "Kitap eklemek için seçiniz.");

                DropDownList2.DataSource = books;
                DropDownList2.DataTextField = "item";
                DropDownList2.DataValueField = "itemID";
                DropDownList2.DataBind();

                if (DropDownList2.SelectedValue.ToString() == "-1")
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    update.Visible = false;
                    add.Visible = true;
                }
                else
                {
                    TextBox1.Text = DropDownList2.SelectedItem.Text;
                    TextBox2.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
                    update.Visible = true;
                    add.Visible = false;
                }
            }
        }


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable books = dbm.getBooks(Convert.ToInt32(DropDownList1.SelectedValue));
            books.Rows.Add(-1, "Kitap eklemek için seçiniz.");

            DropDownList2.DataSource = books;
            DropDownList2.DataTextField = "item";
            DropDownList2.DataValueField = "itemID";
            DropDownList2.DataBind();

            if (DropDownList2.SelectedValue.ToString() == "-1")
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                update.Visible = false;
                add.Visible = true;
            }
            else
            {
                TextBox1.Text = DropDownList2.SelectedItem.Text;
                TextBox2.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
                update.Visible = true;
                add.Visible = false;
            }
        }

        protected void OnSelectedIndexChanged2(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue.ToString() == "-1")
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                update.Visible = false;
                add.Visible = true;
            }
            else
            {
                TextBox1.Text = DropDownList2.SelectedItem.Text;
                TextBox2.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
                update.Visible = true;
                add.Visible = false;
            }
        }

        protected void addBtn(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
            {
                SqlCommand cmd2 = new SqlCommand("select * from item where item='" + TextBox1.Text + "' and writer='" + TextBox2.Text + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.HasRows)
                {
                    conn.Close();
                    labelShowHide(Label1);
                }
                else
                {
                    conn.Close();
                    SqlCommand cmd = new SqlCommand("insert into item(item,catID,writer,available) values('" + TextBox1.Text + "','" + Convert.ToInt32(DropDownList1.SelectedValue) + "','" + TextBox2.Text + "',1)", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    labelShowHide(Label2);

                    DataTable books = dbm.getBooks(Convert.ToInt32(DropDownList1.SelectedValue));
                    books.Rows.Add(-1, "Kitap eklemek için seçiniz.");

                    DropDownList2.DataSource = books;
                    DropDownList2.DataTextField = "item";
                    DropDownList2.DataValueField = "itemID";
                    DropDownList2.DataBind();

                    if (DropDownList2.SelectedValue.ToString() == "-1")
                    {
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        update.Visible = false;
                        add.Visible = true;
                    }
                    else
                    {
                        TextBox1.Text = DropDownList2.SelectedItem.Text;
                        TextBox2.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
                        update.Visible = true;
                        add.Visible = false;
                    }
                }
            }
            else
            {
                labelShowHide(Label5);
            }
        }

        protected void updateBtn(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text)) 
            { 
                SqlCommand cmd2 = new SqlCommand("select * from item where item='" + TextBox1.Text + "' and writer='"+TextBox2.Text+"'", conn);
                conn.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.HasRows)
                {
                    conn.Close();
                    labelShowHide(Label1);
                }
                else
                {
                    conn.Close();
                    SqlCommand cmd = new SqlCommand("update item set item='" + TextBox1.Text + "',writer='"+TextBox2.Text+"' where itemID='" + Convert.ToInt32(DropDownList2.SelectedValue) + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    labelShowHide(Label3);

                    DataTable books = dbm.getBooks(Convert.ToInt32(DropDownList1.SelectedValue));
                    books.Rows.Add(-1, "Kitap eklemek için seçiniz.");

                    DropDownList2.DataSource = books;
                    DropDownList2.DataTextField = "item";
                    DropDownList2.DataValueField = "itemID";
                    DropDownList2.DataBind();

                    if (DropDownList2.SelectedValue.ToString() == "-1")
                    {
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        update.Visible = false;
                        add.Visible = true;
                    }
                    else
                    {
                        TextBox1.Text = DropDownList2.SelectedItem.Text;
                        TextBox2.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
                        update.Visible = true;
                        add.Visible = false;
                    }
                }
            }
            else
            {
                labelShowHide(Label5);
            }
        }

        protected void deleteBtn(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from item where itemID='" + Convert.ToInt32(DropDownList2.SelectedValue) + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            labelShowHide(Label4);

            DataTable books = dbm.getBooks(Convert.ToInt32(DropDownList1.SelectedValue));
            books.Rows.Add(-1, "Kitap eklemek için seçiniz.");

            DropDownList2.DataSource = books;
            DropDownList2.DataTextField = "item";
            DropDownList2.DataValueField = "itemID";
            DropDownList2.DataBind();

            if (DropDownList2.SelectedValue.ToString() == "-1")
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                update.Visible = false;
                add.Visible = true;
            }
            else
            {
                TextBox1.Text = DropDownList2.SelectedItem.Text;
                TextBox2.Text = dbm.getWriter(Convert.ToInt32(DropDownList2.SelectedValue));
                update.Visible = true;
                add.Visible = false;
            }
        }

        protected void labelShowHide(Label labelName)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + labelName.ClientID + "').style.display='block'\",100)</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + labelName.ClientID + "').style.display='none'\",2000)</script>");
        }
    }
}