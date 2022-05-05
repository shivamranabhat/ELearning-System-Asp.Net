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
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayCourses();
            }
        }
        public void displayCourses()
        {
            string constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("select * from AvailableCourse", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                DataList1.DataSource = cmd.ExecuteReader();
                DataList1.DataBind();

            }
        }      
    }   
}
