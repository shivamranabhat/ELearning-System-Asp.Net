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
    public partial class WebForm29 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void Uploadbtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                string filename1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileType1 = FileUpload1.PostedFile.ContentType;
                string filename2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string fileType2 = FileUpload2.PostedFile.ContentType;
                string CrsName = string.Format("{0}", Session["Course_Name"]);

                using (Stream fs1 = FileUpload1.PostedFile.InputStream)
                using (Stream fs2 = FileUpload2.PostedFile.InputStream)

                {

                    using (BinaryReader br1 = new BinaryReader(fs1))
                    using (BinaryReader br2 = new BinaryReader(fs2))
                    {

                        byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);
                        byte[] bytes2 = br2.ReadBytes((Int32)fs2.Length);
                        string constr = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;

                        using (SqlConnection con = new SqlConnection(constr))

                        {

                            string query = "insert into Course_Materials values (@Subject_Name, @Chapter, @FileName1,@FileType1,@Slides,@FileName2,@FileType2,@Tutorials)";

                            using (SqlCommand cmd = new SqlCommand(query))

                            {

                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Subject_Name", CrsName);
                                cmd.Parameters.AddWithValue("@Chapter", txtChapter.Text);
                                cmd.Parameters.AddWithValue("@FileName1", filename1);
                                cmd.Parameters.AddWithValue("@FileType1", fileType1);
                                cmd.Parameters.AddWithValue("@Slides", bytes1);
                                cmd.Parameters.AddWithValue("@FileName2", filename2);
                                cmd.Parameters.AddWithValue("@FileType2", fileType2);
                                cmd.Parameters.AddWithValue("@Tutorials", bytes2);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                lblMessage.Text = "Materials added successfully";
                                txtChapter.Text = "";
                                con.Close();

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
    }
  
}