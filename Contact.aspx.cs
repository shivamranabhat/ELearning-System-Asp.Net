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
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            string ins = "insert into [Contact](Name,Email,Subject,Message) values('" + name.Text + "','" + email.Text + "','" + subject.Text + "','" + message.InnerText + "')";
            SqlCommand cmd = new SqlCommand(ins, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Message Sent Successfully')", true);
            name.Text=String.Empty;
            email.Text= String.Empty;
            subject.Text= String.Empty;
            message.InnerText= String.Empty;



        }
    }
}