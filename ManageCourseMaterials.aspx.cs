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
    public partial class WebForm30 : System.Web.UI.Page
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
            string CrsName = string.Format("{0}", Session["Course_Name"]);
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Course_Materials WHERE Subject_Name = '" + CrsName + "' ", sqlCon);
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
                    string query = "DELETE FROM Course_Materials WHERE ID = @ID";
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
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(constring))
                {
                    sqlCon.Open();
                    string query = "UPDATE Course_Materials SET Chapter=@Chapter,FileName1=@FileName1,FIleName2=@FileName2 WHERE ID = @ID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Chapter", (gridview1.Rows[e.RowIndex].FindControl("txtChapter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@FileName1", (gridview1.Rows[e.RowIndex].FindControl("txtFile1") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@FileName2", (gridview1.Rows[e.RowIndex].FindControl("txtFile2") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gridview1.EditIndex = -1;
                    displayRecords();
                    lblSuccessMessage.Text = "Selected Record Updated";

                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}