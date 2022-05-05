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
    public partial class WebForm13 : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayRecords();


            }
        }
        void displayRecords()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM AvailableCourse", sqlCon);
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
        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            displayRecords();
        }
        
    

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(constring))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM AvailableCourse WHERE ID = @ID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    displayRecords();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;
            displayRecords();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                string query = "UPDATE AvailableCourse SET Course_Code=@Course_Code,Course_Name= @Course_Name,Course_Price =@Course_Price,Lecturer_Name=@Lecturer_Name,Lecture_Hour=@Lecture_Hour,Status=@Status WHERE ID=@ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Course_Code", (gridview1.Rows[e.RowIndex].FindControl("txtCrCode") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Course_Name", (gridview1.Rows[e.RowIndex].FindControl("txtCrName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Course_Price", (gridview1.Rows[e.RowIndex].FindControl("txtCrPrice") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Lecturer_Name", (gridview1.Rows[e.RowIndex].FindControl("txtLectName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Lecture_Hour", (gridview1.Rows[e.RowIndex].FindControl("txtLectHrs") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Status", (gridview1.Rows[e.RowIndex].FindControl("txtStatus") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gridview1.EditIndex = -1;
                displayRecords();
                lblSuccessMessage.Text = "Selected Record Updated";

            }
        }
    }
}