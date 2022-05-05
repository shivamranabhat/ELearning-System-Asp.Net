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
    public partial class WebForm12 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Email"] == null) 
            {
                Response.Redirect("Login.aspx");
            }
            this.txtEmail.Text = string.Format("{0}", Session["Email"]);
            txtenrolldate.Text = DateTime.Now.ToString();
            txtUserType.Text = "Student";

        }
       
        protected void paybtn_Click(object sender, EventArgs e)
        {

            int rowsAffected = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
            try
            {
                con.Open();
                string querySelect = "select count(*) from Students where Email = '" + txtEmail.Text + "'";
                SqlCommand cmdCheckUser = new SqlCommand(querySelect, con);
                int check = Convert.ToInt32(cmdCheckUser.ExecuteScalar().ToString());
                if (check > 0)
                {
                    txtName.Text = "";
                    txtNum.Text = "";
                    txtTitle.Text = "";
                    txtHldrName.Text = "";
                    txtCardNumber.Text = "";
                    txtExpMonth.Text = "";
                    txtExpYear.Text = "";
                    txtCVV.Text = "";
                    lblMessage.Text = " Users should complete a enrolled course first";
                }
                else
                {
                    string ins = "insert into [Booking](Name,Email,Phone,Date,Course_Code,Course_Title,CardHolder_Name,Card_Number,Exp_Month,Exp_Year, CVV,UserType) values('" + txtName.Text + "','" + txtEmail.Text + "','" + txtNum.Text + "','" + txtenrolldate.Text + "','" + txtCode.Text + "','" + txtTitle.Text + "','" + txtHldrName.Text + "','" + txtCardNumber.Text + "','" + txtExpMonth.Text + "','" + txtExpYear.Text + "','" + txtCVV.Text + "','" + txtUserType.Text + "')";
                    SqlCommand cmdInsert = new SqlCommand(ins, con);
                    rowsAffected = cmdInsert.ExecuteNonQuery();
                    lblMessage.Text = " Enroll Successfully. Please Wait Until Admin Approved.";
                    txtName.Text = "";
                    txtNum.Text = "";
                    txtTitle.Text = "";
                    txtHldrName.Text = "";
                    txtCardNumber.Text = "";
                    txtExpMonth.Text = "";
                    txtExpYear.Text = "";
                    txtCVV.Text = "";
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