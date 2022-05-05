using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace ELearning
{
    public partial class WebForm25 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserType.Text = "Admin";
        }

        protected void RegBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
            try
            {
                con.Open();
                string querySelect = "select count(*) from Users where Email = '" + txtEmail.Text + "'";
                SqlCommand cmdCheckUser = new SqlCommand(querySelect, con);
                int check = Convert.ToInt32(cmdCheckUser.ExecuteScalar().ToString());
                if (check > 0)
                {
                    txtFName.Text = " ";
                    txtLName.Text = " ";
                    txtAddress.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Text = " ";
                    txtPassword.Text = "";
                    lblMessage.Text = " Admin Already Exists";
                }
                else
                {
                    string queryInsert = "insert into Users (First_Name, Last_Name, Address, Phone, Email, Password, UserType) values (@fname,@lname, @addr,@phone, @email,@pass, @usertype) ";
                    SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
                    cmdInsert.Parameters.AddWithValue("@fname", txtFName.Text);
                    cmdInsert.Parameters.AddWithValue("@lname", txtLName.Text);
                    cmdInsert.Parameters.AddWithValue("@addr", txtAddress.Text);
                    cmdInsert.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmdInsert.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdInsert.Parameters.AddWithValue("@pass", txtPassword.Text);
                    cmdInsert.Parameters.AddWithValue("@usertype", txtUserType.Text);
                    cmdInsert.ExecuteNonQuery();
                    lblMessage.Text = " Admin Registered Successfully";
                    Response.Redirect("AdminLogin.aspx");
                    txtFName.Text = " ";
                    txtLName.Text = " ";
                    txtAddress.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Text = " ";
                    txtPassword.Text = "";
                }
                con.Close();

            }
            catch (Exception ex)
            {
                lblMessage.Text = " Error!!! Please try again";
            }

        }
    }
}