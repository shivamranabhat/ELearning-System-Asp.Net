using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ELearning
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet da = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logbtn_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Users where Email = '" + txtEmail.Text + "' and Password = '" + txtpassword.Text + "'", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (count > 0)
            {
                
                SqlCommand cmdur = new SqlCommand("select UserType from Users where Email = '" + txtEmail.Text + "'", con);
                string type = cmdur.ExecuteScalar().ToString().Replace(" ", "");
                Session["UserType"] = type;
                if (type == "User")
                {
                    showDetails();
                    Response.Redirect("Home.aspx");
                }
                else if (type == "Admin")
                {
                    
                    Response.Redirect("Admin.aspx");
                }
                else if (type == "Lecturer")
                {
                    showDetails();
                    showTeacherSub();                 
                }

            }
            else
            {
                
                txtEmail.Text = "";
                txtpassword.Text = "";
                lblMessage.Text = "Incorrect Username/Password.";
            }
            con.Close();

        }
        public void showTeacherSub()
        {
            try
            {
                SqlCommand cmdType = new SqlCommand("select Course_Name from Courses where Lecturer_Email = '" + txtEmail.Text + "' ", con);
                string Course = cmdType.ExecuteScalar().ToString().Replace(" ", "");
                Session["Course_Name"] = Course;
                if (Course != null)
                {
                    Response.Redirect("LecturerDashBoard.aspx");
                }
                
            }
            catch (Exception e)
            {               
                Response.Write("<script>alert('Please contact Admin!!!')</script>");
            }
           
        }
       

        public void showDetails()
        {
            SqlCommand cmd = new SqlCommand("select count(*) from Users where Email = '" + txtEmail.Text + "' and Password = '" + txtpassword.Text + "'", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (count > 0)
            {
                SqlCommand cmdType1 = new SqlCommand("select First_Name from Users where Email = '" + txtEmail.Text + "'", con);
                SqlCommand cmdType2 = new SqlCommand("select Last_Name from Users where Email = '" + txtEmail.Text + "'", con);
                SqlCommand cmdType3 = new SqlCommand("select Phone from Users where Email = '" + txtEmail.Text + "'", con);
                SqlCommand cmdType4 = new SqlCommand("select Address from Users where Email = '" + txtEmail.Text + "'", con);
                SqlCommand cmdType5 = new SqlCommand("select Email from Users where Email = '" + txtEmail.Text + "'", con);
                SqlCommand cmdType6 = new SqlCommand("select Password from Users where Email = '" + txtEmail.Text + "'", con);
                SqlCommand cmdType7 = new SqlCommand("select ID from Users where Email = '" + txtEmail.Text + "'", con);
                string type1 = cmdType1.ExecuteScalar().ToString().Replace(" ", "");
                string type2 = cmdType2.ExecuteScalar().ToString().Replace(" ", "");
                string type3 = cmdType3.ExecuteScalar().ToString().Replace(" ", "");
                string type4 = cmdType4.ExecuteScalar().ToString().Replace(" ", "");
                string type5 = cmdType5.ExecuteScalar().ToString().Replace(" ", "");
                string type6 = cmdType6.ExecuteScalar().ToString().Replace(" ", "");
                string type7 = cmdType7.ExecuteScalar().ToString().Replace(" ", "");
                Session["FName"] = type1;
                Session["LName"] = type2;
                Session["Phone"] = type3;
                Session["Address"] = type4;
                Session["Email"] = type5;
                Session["Password"] = type6;
                Session["ID"] = type7;
                if (type1 == "txtEmail.Text" && type2 == "txtEmail.Text" && type3 == "txtEmail.Text" && type4 == "txtEmail.Text" && type5 == "txtEmail.Text" && type6 == "txtEmail.Text" && type7 == "txtEmail.Text")
                {

                    Response.Redirect("Home.aspx");
                }
            }
        }


    }
      
}