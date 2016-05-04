using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_314529157
{
    public partial class UserMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string pk = "";

            try
            {
                UserName = Session["UserName"].ToString();
            }
            catch (NullReferenceException)
            {
                Server.Transfer("Menu.aspx");
            }
          
                SqlConnection con = new SqlConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

                SqlCommand cmd = new SqlCommand("spu_userDit", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@un", UserName);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lbPDFNL.Text = reader.GetString(0);
                        lbPDLNL.Text = reader.GetString(1);
                        lbPDID.Text = reader.GetString(2);
                        lbPDEMAILL.Text = reader.GetString(3);
                        lbPDUNL.Text = reader.GetString(4);
                        lbPDUCL.Text = reader.GetString(5);
                        lbPDCAL.Text = reader.GetString(6); //
                        pk = reader.GetSqlInt32(7).ToString();
                    }
                }
                con.Close();
                SqlCommand cmdsum = new SqlCommand("spu_getUserDitailse", con);
                cmdsum.CommandType = System.Data.CommandType.StoredProcedure;
                cmdsum.Parameters.AddWithValue("@pk", pk);

                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter();

                sda.SelectCommand = cmdsum;

                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    lbPDTCL.Text = ds.Tables[0].Rows[0]["CountCourses"].ToString();
                    lbPDTPL.Text = ds.Tables[1].Rows[0]["TotalPrice"].ToString();
                }
                else
                {
                    lbPDTCL.Text = "0";
                    lbPDTPL.Text = "0";
                }
                if (!IsPostBack)
                {
                ddlcn.DataValueField = "PKid";
                ddlcn.DataTextField = "courseName";
                ddlcn.DataMember = "Table3";

                ddlcn.DataSource = ds;
                ddlcn.DataBind();
                ddlcn.Items.Insert(0, new ListItem("Select One", "-1"));

            }
        }

        protected void btPDNUNChange_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_userNameUpdate", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@un", lbPDUNL.Text);
            cmd.Parameters.AddWithValue("@newUn", tbPDNewUserName.Text);
            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Session["UserName"] = tbPDNewUserName.Text;
                Server.Transfer("UserMenu.aspx");
                lblMessage.Text = "User Name changed successfully !!!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else 
            {
                lblMessage.Text = "User name allready exists !!!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            con.Close();
        }

        protected void tbPDNUCChange_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_userCodeUpdate", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@un", lbPDUNL.Text);
            cmd.Parameters.AddWithValue("@newUc", tbPDNewUserCode.Text);
            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Session["UserName"] = lbPDUNL.Text;
                Server.Transfer("UserMenu.aspx");
                lblMessage.Text = "User Code changed successfully !!!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Server Problem !!!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            con.Close();

        }
        
        protected void btPDPasswordChange_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_userPassUpdate", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@un", lbPDUNL.Text);
            cmd.Parameters.AddWithValue("@oldpass", EncryptPassword(tbPDOldPasswors.Text));
            cmd.Parameters.AddWithValue("@newpass", EncryptPassword(tbPDNewPassword.Text));
            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Session["UserName"] = lbPDUNL.Text;
                Server.Transfer("UserMenu.aspx");
                lblMessage.Text = "Password changed successfully !!!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Server Problem !!!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            con.Close();

        }

        private string EncryptPassword(string pass)
        {
            System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
            String hashed = System.Convert.ToBase64String(sha.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(pass)));
            return hashed.Length > 49 ? hashed.Substring(0, 49) : hashed;
        }

        protected void ddlcn_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_getCourseDitail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pk", ddlcn.SelectedValue.ToString());
           // ddlcn.Items.Remove(ddlcn.SelectedItem);

            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    lblPrice.Text = reader.GetSqlInt32(1).ToString();
                    hlnPD.NavigateUrl = "~/Sellabuses/" + reader.GetString(0);
                }
            }
            con.Close();
        }

        protected void lblPDreg_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_setUserCourses", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pk", ddlcn.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@uID", lbPDID.Text);


            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                lblMessage.Text = "Course Add Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Course already exists";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            con.Close();

        }


    }
}