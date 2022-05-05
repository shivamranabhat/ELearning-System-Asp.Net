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
    public partial class Site2 : System.Web.UI.MasterPage
    {
        string constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayUsersNo();
                displayStdnNo();
                displayMessageNo();
                displayBooking();
            }
        }
        public void displayStdnNo()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As Count FROM Students", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {

                        Label1.Text = " " + o.ToString();


                    }
                    con.Close();
                }

            }
        }
        public void displayBooking()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As Count FROM Booking", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        
                        Label2.Text = " " + o.ToString();


                    }
                    con.Close();
                }

            }
        }
        
        public void displayUsersNo()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As Count FROM Users", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        lblRows.Text = " " + o.ToString();
                       
                       


                    }
                    con.Close();
                }

            }
        }
        public void displayMessageNo()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As Count FROM contact", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {

                        Label3.Text = " " + o.ToString();
                    }
                    con.Close();
                }

            }
        }   
    }
}