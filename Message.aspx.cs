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
    public partial class WebForm9 : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["AspNetConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayMessages();
                
            }

        }
        protected void displayMessages()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from contact ", sqlCon);
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

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
                using (SqlConnection sqlCon = new SqlConnection(constring))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM contact WHERE Name = @Name";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Name", (gridview1.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    displayMessages();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
           
        }
    }
}