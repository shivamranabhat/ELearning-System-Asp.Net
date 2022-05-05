using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace ELearning
{
    public partial class WebForm24 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void showDetails()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
            con.Open();
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
                string type1 = cmdType1.ExecuteScalar().ToString().Replace(" ", "");
                string type2 = cmdType2.ExecuteScalar().ToString().Replace(" ", "");
                string type3 = cmdType3.ExecuteScalar().ToString().Replace(" ", "");
                string type4 = cmdType4.ExecuteScalar().ToString().Replace(" ", "");
                string type5 = cmdType5.ExecuteScalar().ToString().Replace(" ", "");
                string type6 = cmdType6.ExecuteScalar().ToString().Replace(" ", "");
                Session["FName"] = type1;
                Session["LName"] = type2;
                Session["Phone"] = type3;
                Session["Address"] = type4;
                Session["Email"] = type5;
                Session["Password"] = type6;

                if (type1 == "txtEmail.Text" && type2 == "txtEmail.Text" && type3 == "txtEmail.Text" && type4 == "txtEmail.Text" && type5 == "txtEmail.Text" && type6 == "txtEmail.Text")
                {

                    Response.Redirect("ManageUsers.aspx");
                }

            }
            con.Close();
        }
        protected void logbtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Users where Email = '" + txtEmail.Text + "' and Password = '" + txtpassword.Text + "'", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (count > 0)
            {
                showDetails();
                SqlCommand cmdur = new SqlCommand("select UserType from Users where Email = '" + txtEmail.Text + "'", con);
                string type = cmdur.ExecuteScalar().ToString().Replace(" ", "");
                Session["UserType"] = type;
                if (type == "Admin")
                {

                    Response.Redirect("AdminDashboard.aspx");

                }
                con.Close();
            }
            else
            {

                txtEmail.Text = "";
                txtpassword.Text = "";
                lblMessage.Text = "Incorrect Username/Password.";
            }
            con.Close();
        }
    }
}