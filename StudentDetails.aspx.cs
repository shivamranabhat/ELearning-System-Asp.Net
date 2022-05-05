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
    public partial class WebForm22 : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Students", sqlCon);
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
        protected void gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(constring))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Students (Name,Email,Phone,Enroll_Date,Course_Title,UserType) VALUES (@Name,@Email,@Phone,@Enroll_Date,@Course_Title,@UserType)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Name", (gridview1.FooterRow.FindControl("txtNameFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (gridview1.FooterRow.FindControl("txtLNameFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Phone", (gridview1.FooterRow.FindControl("txtPhoneFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Enroll_Date", (gridview1.FooterRow.FindControl("txtEmailFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Course_Title", (gridview1.FooterRow.FindControl("txtPasswordFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@UserType", (gridview1.FooterRow.FindControl("txtUserTypeFtr") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        displayRecords();

                    }
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

        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            displayRecords();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                string query = "UPDATE Students SET Name=@Name,Email=@Email,Phone=@Phone,Enroll_Date=@Enroll_Date,Course_Title=@Course_Title,UserType=@UserType WHERE ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Name", (gridview1.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", (gridview1.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Phone", (gridview1.Rows[e.RowIndex].FindControl("txtPhone") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Enroll_Date", (gridview1.Rows[e.RowIndex].FindControl("txtDate") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Course_Title", (gridview1.Rows[e.RowIndex].FindControl("txtTitle") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@UserType", (gridview1.Rows[e.RowIndex].FindControl("txtUserType") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gridview1.EditIndex = -1;
                displayRecords();
                lblSuccessMessage.Text = "Selected Record Updated";

            }


        }

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(constring))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Students WHERE ID = @ID";
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
    }
}