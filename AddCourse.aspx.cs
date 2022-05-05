using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ELearning
{
    public partial class WebForm35 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Uploadbtn_Click(object sender, EventArgs e)
        {
            String constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(constring);
            if (FileUpload1.HasFile)
            FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "img/" + FileUpload1.FileName);
            string path = FileUpload1.FileName;
            String query = "insert into AvailableCourse values(@Course_Code,@Course_Name,@Course_Price,@Lecturer_Name,@Lecture_Hour,@Status,@File)";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.Parameters.AddWithValue("@Course_Code", txtCode.Text);
            cmd.Parameters.AddWithValue("@Course_Name", txtCName.Text);            
            cmd.Parameters.AddWithValue("@Course_Price", txtCPrice.Text);
            cmd.Parameters.AddWithValue("@Lecturer_Name", txtLName.Text);
            cmd.Parameters.AddWithValue("@Lecture_Hour", txtLectHrs.Text);
            cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
            cmd.Parameters.AddWithValue("@File", path);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage.Text = "Course Added Successfully";
            txtCode.Text = "";
            txtCName.Text = "";
            txtCPrice.Text = "";
            txtLectHrs.Text = "";
            txtLName.Text = "";
            txtStatus.Text = "";
        }


    }
}