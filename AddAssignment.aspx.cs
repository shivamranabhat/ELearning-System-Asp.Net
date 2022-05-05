using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ELearning
{
    public partial class WebForm26 : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtHINDate.Text = "";
                txtHODate.Text = "";
            }
        }

        protected void Uploadbtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileType = FileUpload1.PostedFile.ContentType;
                string CrsName = string.Format("{0}", Session["Course_Name"]);
                using (Stream fs = FileUpload1.PostedFile.InputStream)
                {

                    using (BinaryReader br = new BinaryReader(fs))

                    {

                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        string constr = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;

                        using (SqlConnection con = new SqlConnection(constr))

                        {

                            string query = "insert into Assignment values (@Subject_Name, @Hand_In, @Hand_Out, @FileName,@FileType,@Question)";

                            using (SqlCommand cmd = new SqlCommand(query))

                            {

                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Subject_Name", CrsName);
                                cmd.Parameters.AddWithValue("@Hand_In", txtHINDate.Text);
                                cmd.Parameters.AddWithValue("@Hand_Out", txtHODate.Text);
                                cmd.Parameters.AddWithValue("@FileName", filename);
                                cmd.Parameters.AddWithValue("@FileType", fileType);
                                cmd.Parameters.AddWithValue("@Question", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                lblMessage.Text = "Assignment added successfully";
                                txtHINDate.Text = "";
                                txtHODate.Text = "";
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