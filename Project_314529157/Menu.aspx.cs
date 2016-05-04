using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_314529157
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btlog_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmdAdmin = new SqlCommand("spu_login", con);
            cmdAdmin.CommandType = System.Data.CommandType.StoredProcedure;

            cmdAdmin.Parameters.AddWithValue("@username", tbUN.Text);
            cmdAdmin.Parameters.AddWithValue("@usercode", tbUC.Text);
            cmdAdmin.Parameters.AddWithValue("@userpass", EncryptPassword(tbPass.Text));
     
            con.Open();
            //bool login = false;
            using (SqlDataReader reader = cmdAdmin.ExecuteReader())
            {
                if (reader.Read())//HasRows
                { 
                    //login = true;
                    Session["UserName"] = tbUN.Text;
                    Server.Transfer("AdminMenu.aspx");
                }
            }
            con.Close();
            
            SqlCommand cmdUser = new SqlCommand("spu_loginTo", con);
            cmdUser.CommandType = System.Data.CommandType.StoredProcedure;

            cmdUser.Parameters.AddWithValue("@username", tbUN.Text);
            cmdUser.Parameters.AddWithValue("@usercode", tbUC.Text);
            cmdUser.Parameters.AddWithValue("@userpass", EncryptPassword(tbPass.Text));
            string perm;

            con.Open();
            using (SqlDataReader reader = cmdUser.ExecuteReader())
            {
                if (reader.Read())
                {
                    perm = reader.GetSqlInt32(0).ToString();
                    if (perm == "1")
                    {
                        Session["UserName"] = tbUN.Text;
                        Server.Transfer("AdminMenu.aspx");
                    }
                    else if (perm == "2")
                    {
                        Session["UserName"] = tbUN.Text;
                        Server.Transfer("UserMenu.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Problem conection with Data Base  ";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else 
                {
                    lblMessage.Text = "UserName or UserCode or Password are uncorrect !!! ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            con.Close();
        }

        protected void tbUN_TextChanged(object sender, EventArgs e)
        {

        }
        private string EncryptPassword(string pass)
        {
            System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
            String hashed = System.Convert.ToBase64String(sha.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(pass)));
            return hashed.Length > 49 ? hashed.Substring(0, 49) : hashed;
        }
    }
}