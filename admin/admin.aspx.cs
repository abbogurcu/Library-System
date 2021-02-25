using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib.admin
{
    public partial class admin : System.Web.UI.Page
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
            }
            else
            {
                Response.Redirect("admin-login.aspx");
            }

            if (!Page.IsPostBack)
            {
                DataTable category = dbm.getCategory();
                category.Rows.Add(-1,"Kategori eklemek için seçiniz.");

                DropDownList1.DataSource = category;
                DropDownList1.DataTextField = "cat";
                DropDownList1.DataValueField = "catID";
                DropDownList1.DataBind();

                if (DropDownList1.SelectedValue.ToString() == "-1")
                {
                    TextBox1.Text = "";
                    update.Visible = false;
                    add.Visible = true;
                }
                else
                {
                    TextBox1.Text = DropDownList1.SelectedItem.Text;
                    update.Visible = true;
                    add.Visible = false;
                }

                DataTable masa = dbm.getTable();
                masa.Rows.Add(-1, "Masa eklemek için seçiniz.");

                DropDownList2.DataSource = masa;
                DropDownList2.DataTextField = "tables";
                DropDownList2.DataValueField = "tablesID";
                DropDownList2.DataBind();
                if (DropDownList2.SelectedValue.ToString() == "-1")
                {
                    TextBox2.Text = "";
                    Div2.Visible = false;
                    Div1.Visible = true;
                }
                else
                {
                    TextBox2.Text = DropDownList2.SelectedItem.Text;
                    Div2.Visible = true;
                    Div1.Visible = false;
                }
            }
        }

        protected void addBtn(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                SqlCommand cmd2 = new SqlCommand("select * from category where cat='" + TextBox1.Text + "'", conn);
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
                    SqlCommand cmd = new SqlCommand("insert into category(cat) values('" + TextBox1.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    labelShowHide(Label2);
                    DataTable category = dbm.getCategory();
                    category.Rows.Add(-1, "Kategori eklemek için seçiniz.");

                    DropDownList1.DataSource = category;
                    DropDownList1.DataTextField = "cat";
                    DropDownList1.DataValueField = "catID";
                    DropDownList1.DataBind();
                    if (DropDownList1.SelectedValue.ToString() == "-1")
                    {
                        TextBox1.Text = "";
                        update.Visible = false;
                        add.Visible = true;
                    }
                    else
                    {
                        TextBox1.Text = DropDownList1.SelectedItem.Text;
                        update.Visible = true;
                        add.Visible = false;
                    }
                }
            }
            else
            {
                labelShowHide(Label10);
            }
        }

        protected void updateBtn(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                SqlCommand cmd2 = new SqlCommand("select * from category where cat='" + TextBox1.Text + "'", conn);
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
                    SqlCommand cmd = new SqlCommand("update category set cat='" + TextBox1.Text + "' where cat='" + DropDownList1.SelectedItem.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    labelShowHide(Label3);
                    DataTable category = dbm.getCategory();
                    category.Rows.Add(-1, "Kategori eklemek için seçiniz.");

                    DropDownList1.DataSource = category;
                    DropDownList1.DataTextField = "cat";
                    DropDownList1.DataValueField = "catID";
                    DropDownList1.DataBind();
                    if (DropDownList1.SelectedValue.ToString() == "-1")
                    {
                        TextBox1.Text = "";
                        update.Visible = false;
                        add.Visible = true;
                    }
                    else
                    {
                        TextBox1.Text = DropDownList1.SelectedItem.Text;
                        update.Visible = true;
                        add.Visible = false;
                    }
                }
            }
            else
            {
                labelShowHide(Label10);
            }
        }

        protected void deleteBtn(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from category where catID='" + Convert.ToInt32(DropDownList1.SelectedValue) + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            labelShowHide(Label4);
            DataTable category = dbm.getCategory();
            category.Rows.Add(-1, "Kategori eklemek için seçiniz.");

            DropDownList1.DataSource = category;
            DropDownList1.DataTextField = "cat";
            DropDownList1.DataValueField = "catID";
            DropDownList1.DataBind();
            if (DropDownList1.SelectedValue.ToString() == "-1")
            {
                TextBox1.Text = "";
                update.Visible = false;
                add.Visible = true;
            }
            else
            {
                TextBox1.Text = DropDownList1.SelectedItem.Text;
                update.Visible = true;
                add.Visible = false;
            }
        }

        protected void labelShowHide(Label labelName)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + labelName.ClientID + "').style.display='block'\",100)</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + labelName.ClientID + "').style.display='none'\",2000)</script>");
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.ToString() == "-1")
            {
                TextBox1.Text = "";
                update.Visible = false;
                add.Visible = true;
            }
            else
            {
                TextBox1.Text = DropDownList1.SelectedItem.Text;
                update.Visible = true;
                add.Visible = false;
            }
        }

        protected void OnSelectedIndexChanged2(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue.ToString() == "-1")
            {
                TextBox2.Text = "";
                Div2.Visible = false;
                Div1.Visible = true;
            }
            else
            {
                TextBox2.Text = DropDownList2.SelectedItem.Text;
                Div2.Visible = true;
                Div1.Visible = false;
            }
        }

        protected void addBtn2(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                SqlCommand cmd2 = new SqlCommand("select * from tables where tables='" + TextBox2.Text + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.HasRows)
                {
                    conn.Close();
                    labelShowHide(Label5);
                }
                else
                {
                    conn.Close();
                    SqlCommand cmd = new SqlCommand("insert into tables(tables) values('" + TextBox2.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    labelShowHide(Label6);
                    DataTable category = dbm.getTable();
                    category.Rows.Add(-1, "Masa eklemek için seçiniz.");

                    DropDownList2.DataSource = category;
                    DropDownList2.DataTextField = "tables";
                    DropDownList2.DataValueField = "tablesID";
                    DropDownList2.DataBind();
                    if (DropDownList2.SelectedValue.ToString() == "-1")
                    {
                        TextBox2.Text = "";
                        Div2.Visible = false;
                        Div1.Visible = true;
                    }
                    else
                    {
                        TextBox2.Text = DropDownList2.SelectedItem.Text;
                        Div2.Visible = true;
                        Div1.Visible = false;
                    }
                }
            }
            else
            {
                labelShowHide(Label9);
            }
        }

        protected void updateBtn2(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox2.Text))
            {
                SqlCommand cmd2 = new SqlCommand("select * from tables where tables='" + TextBox2.Text + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.HasRows)
                {
                    conn.Close();
                    labelShowHide(Label5);
                }
                else
                {
                    conn.Close();
                    SqlCommand cmd = new SqlCommand("update tables set tables='" + TextBox2.Text + "' where tables='" + DropDownList2.SelectedItem.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    labelShowHide(Label7);
                    DataTable category = dbm.getTable();
                    category.Rows.Add(-1, "Masa eklemek için seçiniz.");

                    DropDownList2.DataSource = category;
                    DropDownList2.DataTextField = "tables";
                    DropDownList2.DataValueField = "tablesID";
                    DropDownList2.DataBind();
                    if (DropDownList2.SelectedValue.ToString() == "-1")
                    {
                        TextBox2.Text = "";
                        Div2.Visible = false;
                        Div1.Visible = true;
                    }
                    else
                    {
                        TextBox2.Text = DropDownList2.SelectedItem.Text;
                        Div2.Visible = true;
                        Div1.Visible = false;
                    }
                }
            }
            else
            {
                labelShowHide(Label9);
            }
        }

        protected void deleteBtn2(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from tables where tables='" + TextBox2.Text + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            labelShowHide(Label8);
            DataTable category = dbm.getTable();
            category.Rows.Add(-1, "Masa eklemek için seçiniz.");

            DropDownList2.DataSource = category;
            DropDownList2.DataTextField = "tables";
            DropDownList2.DataValueField = "tablesID";
            DropDownList2.DataBind();
            if (DropDownList2.SelectedValue.ToString() == "-1")
            {
                TextBox2.Text = "";
                Div2.Visible = false;
                Div1.Visible = true;
            }
            else
            {
                TextBox2.Text = DropDownList2.SelectedItem.Text;
                Div2.Visible = true;
                Div1.Visible = false;
            }
        }
    }
}