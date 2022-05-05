using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace ELearning
{
    public partial class WebForm23 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select count(*) from Users where Email = '" + txtEmail.Text + "'", con);
                int count = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                if (count > 0)
                {

                    using (SqlCommand cmd = new SqlCommand("UPDATE dbo.Users  SET Password = @Password  where Email  = @Email", con))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.ExecuteNonQuery();
                        txtEmail.Text = "";
                        txtPassword.Text = "";
                        txtconfpass.Text = "";
                        lblMessage.Text = "Password has been changed";
                    }
                }
                else
                {
                    lblMessage.Text = "Email doesn't match!!!";
                }
                    
                    con.Close();

            }
        }
    }
}