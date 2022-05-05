using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace ELearning
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C7SFIMU\SQLEXPRESS;Initial Catalog=eLearning;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayCourses();
                
            }

           
        }
       
        public void displayCourses()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C7SFIMU\SQLEXPRESS;Initial Catalog=eLearning;Integrated Security=True"))
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