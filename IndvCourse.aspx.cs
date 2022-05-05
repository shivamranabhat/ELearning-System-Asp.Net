using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
namespace ELearning
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            showCourse();
            string Course = string.Format("{0}", Session["Course"]);
            SqlCommand cmd = new SqlCommand("SELECT [Course_Name],[Course_Heading],[Lecturer_Name],[Lecturer_Email],[Class_Duration],[Lecture_Hours] FROM [dbo].[Courses] WHERE [Course_Name] = '" + Course + "' ");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            string tempA = " ";
            string tempB = " ";
            string tempC = " ";
            string tempD = " ";
            string tempE = " ";
            string tempF = " ";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tempA += reader["Course_Name"].ToString();
                tempB += reader["Course_Heading"].ToString();
                tempC += reader["Lecturer_Name"].ToString();
                tempD += reader["Lecturer_Email"].ToString();
                tempE += reader["Class_Duration"].ToString();
                tempF += reader["Lecture_Hours"].ToString();
            }
           
            con.Close();
            lblCrsName.Text = tempA;
            lblSub.Text = tempA;
            lblHeading.Text = tempB;
            lblInsName.Text = tempC;
            lblEmail.Text = tempD;
            lblClassHrs.Text = tempE;
            lblLectHrs.Text = tempF;
            tablefill();
            displayRecords();
            showFeedback();
            displayCourseMaterials();
            displayImage();
          
        }
        public void showCourse()
        {
            try
            {
                string Email = string.Format("{0}", Session["Email"]);
                SqlCommand cmdType = new SqlCommand("select Course_Title from Students where Email =  '" + Email + "' ", con);
                string Course = cmdType.ExecuteScalar().ToString().Replace(" ", "");
                Session["Course"] = Course;               
            }
            catch(Exception e)
            {
                Response.Redirect("CourseEnroll.aspx");
            }
                      
        }
        public void displayImage()
        {
            string Course = string.Format("{0}", Session["Course"]);
            string constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("select * from AvailableCourse where  Course_Name= @Course_Name", con);
                cmd.Parameters.AddWithValue("@Course_Name", Course);
                cmd.CommandType = CommandType.Text;
                con.Open();
                DataList2.DataSource = cmd.ExecuteReader();
                DataList2.DataBind();
            }
        }
        public void showFeedback()
        {
            string Email = string.Format("{0}", Session["Email"]);
            SqlCommand cmd = new SqlCommand("SELECT Feedback FROM Student_Assignment WHERE Email= @Email ");
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            string feedback = " ";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                feedback += reader["Feedback"].ToString();
            }
            con.Close();
            lblfeedback.Text = feedback;

        }
        public void displayCourseMaterials()
        {
            string constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                string Course = string.Format("{0}", Session["Course"]);
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Course_Materials WHERE Subject_Name =  '" + Course + "' ", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gridview2.DataSource = dtbl;
                gridview2.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gridview2.DataSource = dtbl;
                gridview2.DataBind();
                gridview2.Rows[0].Cells.Clear();
                gridview2.Rows[0].Cells.Add(new TableCell());
                gridview2.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gridview2.Rows[0].Cells[0].Text = "No Data Found ..!";
                gridview2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        public void tablefill()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Schedule ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();
        }
        public void displayRecords()
        {
            string constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                string Course = string.Format("{0}", Session["Course"]);
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Assignment WHERE Subject_Name = '" + Course + "' ", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                DataList1.DataSource = dtbl;
                DataList1.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                DataList1.DataSource = dtbl;
                DataList1.DataBind();

            }
        }
        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse((sender as LinkButton).CommandArgument);
                byte[] bytes;
                string fileName, fileType;
                string constr = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select FileName, Question, FileType from Assignment where Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", ID);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Question"];
                            fileType = sdr["FileType"].ToString();
                            fileName = sdr["FileName"].ToString();
                        }
                        con.Close();
                    }
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = fileType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch
            {
                Response.Write("<script>alert('No File Found')</script>");
            }

        }

        protected void uplbtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileType = FileUpload1.PostedFile.ContentType;
                string Name = string.Format("{0}", Session["FName"]);
                string Email = string.Format("{0}", Session["Email"]);
                string Course = string.Format("{0}", Session["Course"]);
                using (Stream fs = FileUpload1.PostedFile.InputStream)

                {

                    using (BinaryReader br = new BinaryReader(fs))

                    {

                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        string constr = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;

                        using (SqlConnection con = new SqlConnection(constr))

                        {

                            string query = "insert into Student_Assignment values (@Student_Name,@Email,@Course_Name,@FileName,@FileType,@Answer,@Feedback)";

                            using (SqlCommand cmd = new SqlCommand(query))

                            {

                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Student_Name", Name);
                                cmd.Parameters.AddWithValue("@Email", Email);
                                cmd.Parameters.AddWithValue("@Course_Name", Course);
                                cmd.Parameters.AddWithValue("@FileName", filename);
                                cmd.Parameters.AddWithValue("@FileType", fileType);
                                cmd.Parameters.AddWithValue("@Answer", bytes);
                                cmd.Parameters.AddWithValue("@Feedback", txtFeedback.Text);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                lblMessage.Text = "Your Assignment has been Submitted";
                            }

                        }

                    }

                }
            }
            else
            {
                lblMessage.Text = "Error! Please Try Again";
            }
        }
        protected void lnkDownload2_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse((sender as LinkButton).CommandArgument);
                byte[] bytes;
                string fileName, fileType;
                string constr = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select FileName2, Tutorials, FileType2 from Course_Materials where Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", ID);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Tutorials"];
                            fileType = sdr["FileType2"].ToString();
                            fileName = sdr["FileName2"].ToString();
                        }
                        con.Close();
                    }
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = fileType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }
        protected void lnkDownload1_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse((sender as LinkButton).CommandArgument);
                byte[] bytes;
                string fileName, fileType;
                string constr = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select FileName1, Slides, FileType1 from Course_Materials where Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", ID);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Slides"];
                            fileType = sdr["FileType1"].ToString();
                            fileName = sdr["FileName1"].ToString();
                        }
                        con.Close();
                    }
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = fileType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}