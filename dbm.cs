using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERU_Lib
{
    public class dbm
    {
        static SqlConnection conn = getConnection();
        public static SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public static string adminLogin(string username,string password)
        {
            SqlCommand cmd = new SqlCommand("select userID from users where username='" + username + "' and password='" + password + "' and auth=1", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string userID = null;
                while (reader.Read())
                {
                    userID=reader["userID"].ToString();
                }
                conn.Close();
                return userID;
            }
            else
            {
                conn.Close();
                return null;
            }
        }

        public static string userLogin(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("select userID from users where username='" + username + "' and password='" + password + "' and auth=0", conn);
            conn.Close();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string userID = null;
                while (reader.Read())
                {
                    userID = reader["userID"].ToString();
                }
                conn.Close();
                return userID;
            }
            else
            {
                conn.Close();
                return null;
            }
        }

        public static Boolean userCheck(string username)
        {
            SqlCommand cmd = new SqlCommand("select userID from users where username='" + username + "' and auth=0", conn);
            conn.Close();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }


        public static Boolean itemCheck(int itemID)
        {
            SqlCommand cmd = new SqlCommand("select * from item where itemID='" + itemID + "' and available=0", conn);
            conn.Close();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        public static DataTable getCategory()
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select * from category", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable getTable()
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select * from tables", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable getBooks(int catID)
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select * from item where catID='"+catID+"'", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable getBooks2(int catID)
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select * from item where catID='" + catID + "' and available=1", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static string getWriter(int itemID)
        {
            string writer = "";
            SqlCommand komutNesnesi = new SqlCommand("select * from item where itemID='" + itemID + "'", conn);
            conn.Open();
            SqlDataReader reader = komutNesnesi.ExecuteReader();
            while (reader.Read())
            {
               writer=reader["writer"].ToString();
            }
            conn.Close();
            return writer;
        }

        public static string getFullName(int userID)
        {
            string name = "";
            string surname = "";
            SqlCommand komutNesnesi = new SqlCommand("select * from users where userID='" + userID + "' and auth=0", conn);
            conn.Open();
            SqlDataReader reader = komutNesnesi.ExecuteReader();
            while (reader.Read())
            {
                name = reader["name"].ToString();
                surname = reader["surname"].ToString();
            }
            conn.Close();
            return name + " " + surname;
        }

        public static void register(string username,string password,string name,string surname,int age,string address,int auth)
        {
            SqlCommand komutNesnesi = new SqlCommand("insert into users(username,password,name,surname,age,address,auth) values('"+username+"','"+password+"','"+name+"','"+surname+"','"+age+"','"+address+"','"+auth+"')", conn);
            conn.Open();
            komutNesnesi.ExecuteNonQuery();
            conn.Close();
        }

        public static DataTable itemHistoryUser(int userID)
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select *,CONVERT(varchar,DATEADD(DAY,30,[item-history].getDate),104) as giveDate,CONVERT(varchar,[item-history].getDate,104) as getDay from [item-history] inner join item on item.itemID=[item-history].itemID inner join category on item.catID=category.catID where [item-history].userID='" + userID+"'", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable itemHistoryUser2()
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select *,CONVERT(varchar,DATEADD(DAY,30,[item-history].getDate),104) as giveDate,CONVERT(varchar,[item-history].getDate,104) as getDay from [item-history] inner join item on item.itemID=[item-history].itemID inner join category on item.catID=category.catID order by [item-history].getDate DESC", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable itemHistoryAdmin()
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select *,CONVERT(varchar,DATEADD(DAY,30,[item-history].getDate),104) as giveDate,CONVERT(varchar,[item-history].getDate,104) as getDay from [item-history] inner join item on item.itemID=[item-history].itemID inner join category on item.catID=category.catID inner join users on [item-history].userID=users.userID where item.available=0 and [item-history].historyID IN(select MAX([item-history].historyID) from [item-history] group by userID)", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable itemHistoryAdmin2(string username)
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select *,CONVERT(varchar,DATEADD(DAY,30,[item-history].getDate),104) as giveDate,CONVERT(varchar,[item-history].getDate,104) as getDay from [item-history] inner join item on item.itemID=[item-history].itemID inner join category on item.catID=category.catID inner join users on [item-history].userID=users.userID where item.available=0 and [item-history].historyID IN(select MAX([item-history].historyID) from [item-history] inner join users on users.userID=[item-history].userID where users.username like '%" + username+"%' group by [item-history].userID)", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static void getItem(int itemID, int userID, DateTime getDate)
        {
            SqlCommand komutNesnesi = new SqlCommand("insert into [item-history](itemID,userID,[getDate]) values('" + itemID + "','" + userID + "',CONVERT(datetime,'" + getDate.Date + "',104))", conn);
            conn.Open();
            komutNesnesi.ExecuteNonQuery();
            conn.Close();

            SqlCommand komutNesnesi2 = new SqlCommand("update item set available=0 where itemID='" + itemID + "'", conn);
            conn.Open();
            komutNesnesi2.ExecuteNonQuery();
            conn.Close();
        }

        public static void updateItemStatus(int itemID)
        {
            SqlCommand komutNesnesi2 = new SqlCommand("update item set available=1 where itemID='" + itemID + "'", conn);
            conn.Open();
            komutNesnesi2.ExecuteNonQuery();
            conn.Close();
        }

        public static DataTable showTables()
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select * from tables order by tables", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable showAppoUser(int userID)
        {
            DataTable dt = new DataTable();
            SqlCommand komutNesnesi = new SqlCommand("select *,CONVERT(varchar,DATEADD(DAY,30,date),104) as customDate from appointment where userID='" + userID+"' order by appoID DESC", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            return dt;
        }

        public static Boolean tableCheck(int userID,DateTime date,int time,string tables)
        {
            DataTable dt = new DataTable();
            Boolean tableC = false;
            SqlCommand komutNesnesi = new SqlCommand("select * from appointment where userID='"+userID+ "' and date=CONVERT(datetime,'" + date.Date + "',104) and timePeriod='"+time+"' and tableName='"+tables+"'", conn);
            conn.Open();
            SqlDataReader reader = komutNesnesi.ExecuteReader();
            if (reader.HasRows)
            {
                tableC=true;
            }
            conn.Close();
            return tableC;
        }
        public static void tableAppo(int userID,DateTime date,int time,string tableName)
        {
            SqlCommand komutNesnesi = new SqlCommand("insert into appointment(userID,date,timePeriod,tableName) values('" + userID + "',CONVERT(datetime,'" + date.Date + "',104),'"+time+"','"+tableName+"')", conn);
            conn.Open();
            komutNesnesi.ExecuteNonQuery();
            conn.Close();
        }

    }
}