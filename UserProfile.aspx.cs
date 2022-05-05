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
    public partial class WebForm20 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet da = new DataSet();
            if ( Session["FName"] != null && Session["LName"] != null && Session["Phone"] != null && Session["Address"] != null && Session["Email"] != null && Session["Password"] != null)
            {
                this.txtFName.Text = string.Format("{0}", Session["FName"]);
                this.txtLName.Text = string.Format("{0}", Session["LName"]);
                this.txtPhone.Text = string.Format("{0}", Session["Phone"]);
                this.txtAddress.Text = string.Format("{0}", Session["Address"]);
                this.txtEmail.Text = string.Format("{0}", Session["Email"]);
                this.txtPassword.Text = string.Format("{0}", Session["Password"]);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
                

            con.Open();
        }

        protected void UpdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE dbo.Users  SET First_Name = @FName ,Last_Name = @LName,Phone = @Phone,Address = @Address,Email = @Email,Password = @Password  where ID  = @ID", con))
                    {
                        cmd.Parameters.AddWithValue("@FName", txtFName.Text);
                        cmd.Parameters.AddWithValue("@LName", txtLName.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@ID", Session["ID"]);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Updated Successfully";

                    }
                    con.Close();
                }

            }
            catch(Exception ex)
            {
                lblMessage.Text = "Error!!! Please try again";
            }
           
        }
        protected void LogBtn_Click(object sender, EventArgs e)
        {
            Session["FName"] = null;
            Session["LName"] = null;
            Session["Phone"] = null;
            Session["Address"] = null;
            Session["Email"] = null;
            Session["Password"] = null;
            Response.Redirect("Login.aspx");

        }
    }
}