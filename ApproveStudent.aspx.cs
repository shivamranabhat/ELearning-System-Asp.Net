using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ELearning
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayRecords();
                
            }

        }
        protected void displayRecords()
        {


            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Booking  ", sqlCon);            
                sqlDa.Fill(dtbl);     
            }
            if (dtbl.Rows.Count > 0)
            {
                gridview1.DataSource = dtbl;
                gridview1.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gridview1.DataSource = dtbl;
                gridview1.DataBind();
                gridview1.Rows[0].Cells.Clear();
                gridview1.Rows[0].Cells.Add(new TableCell());
                gridview1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gridview1.Rows[0].Cells[0].Text = "No Data Found ..!";
                gridview1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString);
            foreach (GridViewRow gr in gridview1.Rows)
            {
                string sqlquery = "INSERT INTO [dbo].[Students] VALUES (@Name,@Email,@Phone,@Enroll_Date,@Course_Title,@UserType)";
                SqlCommand sqlcom = new SqlCommand(sqlquery, con);
                sqlcom.Parameters.AddWithValue("@Name", gr.Cells[1].Text);
                sqlcom.Parameters.AddWithValue("@Email", gr.Cells[2].Text);
                sqlcom.Parameters.AddWithValue("@Phone", gr.Cells[3].Text);
                sqlcom.Parameters.AddWithValue("@Enroll_Date", gr.Cells[4].Text);
                sqlcom.Parameters.AddWithValue("@Course_Title", gr.Cells[5].Text);
                sqlcom.Parameters.AddWithValue("@UserType", gr.Cells[11].Text);

                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(conString))
                    {
                        sqlCon.Open();
                        string query = "DELETE FROM Booking WHERE ID = @ID";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(gridview1.DataKeys[gr.RowIndex].Value.ToString()));
                        sqlCmd.ExecuteNonQuery();
                        displayRecords();
                        lblSuccessMessage.Text = "Student approved successfully";
                    }
                }
                catch (Exception ex)
                {
                    lblSuccessMessage.Text = "";
                }
                con.Open();
                sqlcom.ExecuteNonQuery();
                con.Close();


            }
        }
       

        protected void gridview1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(conString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Booking WHERE ID = @ID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    displayRecords();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = ex.Message;
            }
        }
    }
}