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
    public partial class AdminMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) // When page load if user try to conect derectly to AdminUser he will returned to Menu page
        {
            string UserName = "";

            try
            {
                UserName = Session["UserName"].ToString();
            }
            catch (NullReferenceException)
            {
                Server.Transfer("Menu.aspx");
            }
           

        }

        protected void btnAddU_Click(object sender, EventArgs e)// Button Add new User will load panel to add ne user. And will load all areas to ddl from DB.
        {
            btnAddU.Enabled = false;
            btnUdateU.Enabled = true;
            btnCoursesA.Enabled = true;
            pnlam1.Visible = true;
            pnlam2.Visible = false;
            pnlam3.Visible = false;
            lblUserMessage.Text = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Connection string";
                

            SqlCommand cmd = new SqlCommand("spu_getAreas", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            sda.Fill(ds);

            ddlPCA.DataValueField = "PKid";
            ddlPCA.DataTextField = "areas";
            //ddlPCA.DataMember = "areas";

            ddlPCA.DataSource = ds;
            ddlPCA.DataBind();

            ddlPCA.Items.Insert(0, new ListItem("Select One", "-1"));
        }

        protected void btnUdateU_Click(object sender, EventArgs e) //Button Update User will load panel and will load all Users to ddl from DB
        {
            btnUdateU.Enabled = false;
            btnCoursesA.Enabled = true;
            btnAddU.Enabled = true;
            pnlam2.Visible = true;
            pnlam1.Visible = false;
            pnlam3.Visible = false;
            lblUserMessage.Text = "";



            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_getUser", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            sda.Fill(ds);

            ddlUPSelectUser.DataValueField = "PKid";
            ddlUPSelectUser.DataTextField = "name";
            //ddlPCA.DataMember = "areas";

            ddlUPSelectUser.DataSource = ds;
            ddlUPSelectUser.DataBind();

            ddlUPSelectUser.Items.Insert(0, new ListItem("Select One", "-1"));


        }

        protected void btnCoursesA_Click(object sender, EventArgs e) //Button will load Course Activity panel and will load Existing areas , Select Area , Select User to ddls from DB
        {
            btnCoursesA.Enabled = false;
            btnAddU.Enabled = true;
            btnUdateU.Enabled = true;
            pnlam3.Visible = true;
            pnlam2.Visible = false;
            pnlam1.Visible = false;
            lblUserMessage.Text = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_coursesActivity", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            sda.Fill(ds);
            // filling Existing Areas
            ddlACAExistingAreas.DataValueField = "PKid";
            ddlACAExistingAreas.DataTextField = "areas";
            ddlACAExistingAreas.DataMember = "Table";

            ddlACAExistingAreas.DataSource = ds;
            ddlACAExistingAreas.DataBind();

            ddlACAExistingAreas.Items.Insert(0, new ListItem("Select One", "-1"));
            //filing Select Area
            ddlACASelectArea.DataValueField = "PKid";
            ddlACASelectArea.DataTextField = "areas";
            ddlACASelectArea.DataMember = "Table";

            ddlACASelectArea.DataSource = ds;
            ddlACASelectArea.DataBind();

            ddlACASelectArea.Items.Insert(0, new ListItem("Select One", "-1"));
            //filling Select Student
            ddlACASelectStudent.DataValueField = "PKid";
            ddlACASelectStudent.DataTextField = "name";
            ddlACASelectStudent.DataMember = "Table1";

            ddlACASelectStudent.DataSource = ds;
            ddlACASelectStudent.DataBind();

            ddlACASelectStudent.Items.Insert(0, new ListItem("Select One", "-1"));
        }

        protected void btNUAddUser_Click(object sender, EventArgs e) // After press Add User function will check if UserName Exists if yes function will print massege if not function will add new User.
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmdcheck = new SqlCommand("spu_getUserCheck", con);
            cmdcheck.CommandType = System.Data.CommandType.StoredProcedure;

            cmdcheck.Parameters.AddWithValue("@un", tbNUuserName.Text);
            cmdcheck.Parameters.AddWithValue("@pas",tbNUID.Text);

            con.Open();

            using (SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                if (reader.Read())
                {
                    lblUserMessage.Text = "User Exists";
                    lblUserMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    con.Close();
                    SqlCommand cmd = new SqlCommand("spu_newUser", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fn", tbNUFirstName.Text);
                    cmd.Parameters.AddWithValue("@ln", tbNULastName.Text);
                    cmd.Parameters.AddWithValue("@id", tbNUID.Text);
                    cmd.Parameters.AddWithValue("@areas", ddlPCA.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@email", tbNUEmail.Text);
                    cmd.Parameters.AddWithValue("@un", tbNUuserName.Text);
                    cmd.Parameters.AddWithValue("@uc", tblNUusercode.Text);
                    cmd.Parameters.AddWithValue("@pass", EncryptPassword(tbNUPassword.Text));
                    cmd.Parameters.AddWithValue("@perm", rbtWS.SelectedValue);

                    con.Open();
                    int temp = cmd.BeginExecuteXmlReader();
                    if (temp == 1 || temp == 2 ) 
                    {
                        lblUserMessage.Text = "New User Added !!";
                        lblUserMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblUserMessage.Text = "Server problem !!!";
                        lblUserMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }

            con.Close();
        }

        private string EncryptPassword(string pass)
        {
            System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
            String hashed = System.Convert.ToBase64String(sha.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(pass)));
            return hashed.Length > 49 ? hashed.Substring(0, 49) : hashed;
        }

        protected void btNURsetform_Click(object sender, EventArgs e) // Reset form button will cleare all tb's and will reset ddl of areas.
        {
            tbNUFirstName.Text = "";
            tbNULastName.Text = "";
            tbNUID.Text = "";
            ddlPCA.SelectedIndex = -1;
            tbNUEmail.Text = "";
            tbNUuserName.Text = "";
            tblNUusercode.Text = "";
            tbNUPassword.Text = "";
            rbtWS.SelectedIndex = 2;
            lblUserMessage.Text = "";
        }

        protected void ddlUPSelectUser_SelectedIndexChanged(object sender, EventArgs e) // after cheose User function will fill all diteils
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_getDitailse", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pk", ddlUPSelectUser.SelectedValue.ToString());
            ddlUPPCA.Items.Remove(ddlUPPCA.SelectedItem);
            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    tbUPFirstName.Text = reader.GetString(1);
                    tbUPLastName.Text = reader.GetString(2);
                    tbUPID.Text = reader.GetString(3);
                    tbUPEmail.Text = reader.GetString(4);
                    tbUPUserName.Text = reader.GetString(5);
                    tbUPUserCode.Text = reader.GetString(6);
                    tbUPPassword.Text = reader.GetString(7);
                    ddlUPPCA.Items.Insert(0, reader.GetString(8));
                    rbtupStuWork.SelectedValue = reader.GetInt32(9).ToString();
                }
            }
            con.Close();

        }

        protected void btPURsetform_Click(object sender, EventArgs e) //function will reset all tables and refill of Update User 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_getUser", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            sda.Fill(ds);

            ddlUPSelectUser.DataValueField = "PKid";
            ddlUPSelectUser.DataTextField = "name";

            ddlUPSelectUser.DataSource = ds;
            ddlUPSelectUser.DataBind();

            ddlUPSelectUser.Items.Insert(0, new ListItem("Select One", "-1"));

            tbUPFirstName.Text = "";
            tbUPLastName.Text = "";
            tbUPID.Text = "";
            tbUPPassword.Text = "";
            ddlUPPCA.Items.Remove(ddlUPPCA.SelectedItem);
            tbUPEmail.Text = "";
            tbUPUserName.Text = "";
            tbUPUserCode.Text = "";
            rbtupStuWork.SelectedIndex = 2;
            lblUserMessage.Text = "";
        }

        protected void btUPUpdateUser_Click(object sender, EventArgs e) // function will update parameters of conected user
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmd = new SqlCommand("spu_setUpdateUser", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();


            cmd.Parameters.AddWithValue("@fn", tbUPFirstName.Text);
            cmd.Parameters.AddWithValue("@ln", tbUPLastName.Text);
            cmd.Parameters.AddWithValue("@id", tbUPID.Text);
            cmd.Parameters.AddWithValue("@mail", tbUPEmail.Text);
            cmd.Parameters.AddWithValue("@password", EncryptPassword(tbUPPassword.Text));
            cmd.Parameters.AddWithValue("@perm", rbtupStuWork.SelectedValue);


            if (cmd.ExecuteNonQuery() == 1)
            {
                lblUserMessage.Text = "Urer been updated !!";
                lblUserMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblUserMessage.Text = "Usre no been updated !!!";
                lblUserMessage.ForeColor = System.Drawing.Color.Red;
            }
            con.Close();
            ddlUPPCA.Items.Remove(ddlUPPCA.SelectedItem);
            SqlCommand cmdup = new SqlCommand("spu_getUser", con);
            cmdup.CommandType = System.Data.CommandType.StoredProcedure;

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmdup;

            sda.Fill(ds);

            ddlUPSelectUser.DataValueField = "PKid";
            ddlUPSelectUser.DataTextField = "name";
            //ddlPCA.DataMember = "areas";

            ddlUPSelectUser.DataSource = ds;
            ddlUPSelectUser.DataBind();

            ddlUPSelectUser.Items.Insert(0, new ListItem("Select One", "-1"));
        }

        protected void btACAAddCourse_Click(object sender, EventArgs e) //function will check if area exist if no new area will added to data base. after that ddl Area will refreshed
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmdcheck = new SqlCommand("spu_areaCheck", con);
            cmdcheck.CommandType = System.Data.CommandType.StoredProcedure;

            cmdcheck.Parameters.AddWithValue("@ar", tbACANewArea.Text);
            

            con.Open();

            using (SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    lblUserMessage.Text = "Area Exiting";
                    lblUserMessage.ForeColor = System.Drawing.Color.Red;
                    tbACANewArea.Text = "";
                }
                else
                {
                    con.Close();
                    SqlCommand cmd = new SqlCommand("spu_areaInsert", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@area", tbACANewArea.Text);
                    

                    con.Open();

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        lblUserMessage.Text = "Area Added !!";
                        lblUserMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }

            }

            con.Close();
            SqlCommand cmdup = new SqlCommand("spu_getAreas", con);
            cmdup.CommandType = System.Data.CommandType.StoredProcedure;

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmdup;

            sda.Fill(ds);

            ddlACAExistingAreas.DataValueField = "PKid";
            ddlACAExistingAreas.DataTextField = "areas";
            //ddlPCA.DataMember = "areas";

            ddlACAExistingAreas.DataSource = ds;
            ddlACAExistingAreas.DataBind();

            ddlACAExistingAreas.Items.Insert(0, new ListItem("Select One", "-1"));
            tbACANewArea.Text = "";


        }

        protected void ddlACASelectArea_SelectedIndexChanged(object sender, EventArgs e) // function filling ddl Selected Area
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlCommand cmd = new SqlCommand("spu_getCourses", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ar", ddlACASelectArea.SelectedItem.Text);

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            sda.Fill(ds);
            ddlExistingCourses.DataValueField = "PKid";
            ddlExistingCourses.DataValueField = "courseName";

            ddlExistingCourses.DataSource = ds;
            ddlExistingCourses.DataBind();
            ddlExistingCourses.Items.Insert(0, new ListItem("Select One", "-1"));


        }

        protected void btACAAddCourse2_Click(object sender, EventArgs e) //function add new course to data base after check if course no exists.
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlCommand cmdcheck = new SqlCommand("spu_courseCheck", con);
            cmdcheck.CommandType = System.Data.CommandType.StoredProcedure;

            cmdcheck.Parameters.AddWithValue("@cn", tbNewCourse.Text);
            cmdcheck.Parameters.AddWithValue("@ar", ddlACASelectArea.SelectedItem.Text);
            con.Open();

            using (SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    lblUserMessage.Text = "Course Exists";
                    lblUserMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    con.Close();
                    SqlCommand cmd = new SqlCommand("spu_newCourse", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cn", tbNewCourse.Text);
                    cmd.Parameters.AddWithValue("@cp", Convert.ToInt32(tbACACoursePrice.Text));
                    cmd.Parameters.AddWithValue("@syl", fupBrowse.FileName.ToString());
                    cmd.Parameters.AddWithValue("@ar", ddlACASelectArea.SelectedItem.Text);
                    con.Open();

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        fupBrowse.SaveAs(Server.MapPath("~/sellabuses/")+fupBrowse.FileName.ToString());
                        lblUserMessage.Text = "Course Added";
                        lblUserMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblUserMessage.Text = "Error !!!";
                        lblUserMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }

            }

            con.Close();
            tbNewCourse.Text = "";
            tbACACoursePrice.Text = "";
           // tbACACourseSellabus.Text = "";
            SqlCommand cmdre = new SqlCommand("spu_getCourses", con);
            cmdre.CommandType = System.Data.CommandType.StoredProcedure;

            cmdre.Parameters.AddWithValue("@ar", ddlACASelectArea.SelectedItem.Text);

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmdre;

            sda.Fill(ds);
            ddlExistingCourses.DataValueField = "PKid";
            ddlExistingCourses.DataValueField = "courseName";

            ddlExistingCourses.DataSource = ds;
            ddlExistingCourses.DataBind();
            ddlExistingCourses.Items.Insert(0, new ListItem("Select One", "-1"));
            

        }

        protected void ddlACASelectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlCommand cmd = new SqlCommand("spu_getUserDitailse", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            lblCoursesArea.Text = "";
            lblTotalCourses.Text = "";
            lblTotalPrice.Text = "";
            
            cmd.Parameters.AddWithValue("@pk", ddlACASelectStudent.SelectedValue.ToString());

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                lblCoursesArea.Text = ds.Tables[0].Rows[0]["area"].ToString();
                lblTotalCourses.Text = ds.Tables[0].Rows[0]["CountCourses"].ToString();
                lblTotalPrice.Text = ds.Tables[1].Rows[0]["TotalPrice"].ToString();
            }
            else 
            {
                lblCoursesArea.Text = ds.Tables[2].Rows[0]["area"].ToString();
                lblTotalCourses.Text = "0";
                lblTotalPrice.Text = "0";
            }
        }

        protected void tbACACourseSellabus_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlACAExistingAreas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPCA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlExistingCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

            

       
    
}