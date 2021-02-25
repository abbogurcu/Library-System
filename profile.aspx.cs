using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERU_Lib
{
    public partial class profile : System.Web.UI.Page
    {
        static SqlConnection conn = getConnection();
        public static SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToInt32(Session["userID"]) > 0)
            {
                fullname.Text = dbm.getFullName(Convert.ToInt32(Session["userID"]));
                if (!Page.IsPostBack)
                {
                    getFullProfile(Convert.ToInt32(Session["userID"]));
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

        static string realUsername = "";

        protected void getFullProfile(int userID)
        {
            SqlCommand komutNesnesi = new SqlCommand("select * from users where userID='" + userID + "'", conn);
            conn.Open();
            SqlDataReader reader = komutNesnesi.ExecuteReader();
            while (reader.Read())
            {
                username.Text = reader["username"].ToString();
                realUsername= reader["username"].ToString();
                password.Text = reader["password"].ToString();
                name.Text = reader["name"].ToString();
                surname.Text = reader["surname"].ToString();
                age.SelectedValue = reader["age"].ToString();
                address.Text = reader["username"].ToString();
            }
            conn.Close();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(username.Text) && !string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(surname.Text) && !string.IsNullOrEmpty(address.Text))
            {
                if ((dbm.userCheck(username.Text) != true)||(username.Text==realUsername))
                {
                    fullname.Text = dbm.getFullName(Convert.ToInt32(Session["userID"]));
                    SqlCommand komutNesnesi = new SqlCommand("update users set username='" + username.Text + "',password='" + password.Text + "',name='" + name.Text + "',surname='" + surname.Text + "',age='" + Convert.ToInt32(age.SelectedValue) + "',address='" + address.Text + "' where userID='" + Convert.ToInt32(Session["userID"]) + "'", conn);
                    conn.Open();
                    komutNesnesi.ExecuteNonQuery();
                    conn.Close();
                    getFullProfile(Convert.ToInt32(Session["userID"]));
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + Div1.ClientID + "').style.display='block'\",100)</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + Div1.ClientID + "').style.display='none'\",2000)</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + loginError.ClientID + "').style.display='block'\",100)</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + loginError.ClientID + "').style.display='none'\",2000)</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ShowLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + registerError.ClientID + "').style.display='block'\",100)</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + registerError.ClientID + "').style.display='none'\",2000)</script>");
            }
        }
    }
}