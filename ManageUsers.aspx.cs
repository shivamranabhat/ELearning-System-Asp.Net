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
    public partial class WebForm7 : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Users where UserType ='User'  ", sqlCon);
                SqlDataAdapter sqlDa1 = new SqlDataAdapter("SELECT * FROM Users where UserType ='Lecturer'  ", sqlCon);
                sqlDa.Fill(dtbl);
                sqlDa1.Fill(dtbl);
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
                        string query = "INSERT INTO Users (First_Name,Last_Name,Address,Phone,Email,Password,UserType) VALUES (@First_Name,@Last_Name,@Address,@Phone,@Email,@Password,@UserType)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@First_Name", (gridview1.FooterRow.FindControl("txtFNameFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Last_Name", (gridview1.FooterRow.FindControl("txtLNameFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Address", (gridview1.FooterRow.FindControl("txtAddressFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Phone", (gridview1.FooterRow.FindControl("txtPhoneFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (gridview1.FooterRow.FindControl("txtEmailFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", (gridview1.FooterRow.FindControl("txtPasswordFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@UserType", (gridview1.FooterRow.FindControl("txtUserTypeFtr") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        displayRecords();
                        lblSuccessMessage.Text = "User Added Successfully";
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

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(constring))
                {
                    sqlCon.Open();
                    string query = "UPDATE Users SET First_Name=@First_Name,Last_Name=@Last_Name,Address=@Address,Phone=@Phone,Email=@Email,Password=@Password,UserType=@UserType WHERE ID = @ID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@First_Name", (gridview1.Rows[e.RowIndex].FindControl("txtFName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Last_Name", (gridview1.Rows[e.RowIndex].FindControl("txtLName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", (gridview1.Rows[e.RowIndex].FindControl("txtAddress") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Phone", (gridview1.Rows[e.RowIndex].FindControl("txtPhone") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (gridview1.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", (gridview1.Rows[e.RowIndex].FindControl("txtPassword") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@UserType", (gridview1.Rows[e.RowIndex].FindControl("txtUserType") as TextBox).Text.Trim());
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

            }


        }

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(constring))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Users WHERE ID = @ID";
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
