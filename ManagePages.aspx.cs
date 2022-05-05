﻿using System;
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
    public partial class WebForm34 : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM  Courses  ", sqlCon);             
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

        protected void gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {

                    using (SqlConnection sqlCon = new SqlConnection(constring))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Courses (Course_Name,Course_Heading,Lecturer_Name,Lecturer_Email,Class_Duration,Lecture_Hours) VALUES (@Course_Name,@Course_Heading,@Lecturer_Name,@Lecturer_Email,@Class_Duration,@Lecture_Hours)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Course_Name", (gridview1.FooterRow.FindControl("txtCNameFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Course_Heading", (gridview1.FooterRow.FindControl("txtCHeadingFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Lecturer_Name", (gridview1.FooterRow.FindControl("txtLectNameFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Lecturer_Email", (gridview1.FooterRow.FindControl("txtLectEmailFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Class_Duration", (gridview1.FooterRow.FindControl("txtClsDurationFtr") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Lecture_Hours", (gridview1.FooterRow.FindControl("txtLectHrsFtr") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        displayRecords();
                        lblSuccessMessage.Text = "Added Successfully";
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

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(constring))
                {
                    sqlCon.Open();
                    string query = "UPDATE Courses SET Course_Name=@Course_Name,Course_Heading =@Course_Heading,Lecturer_Name=@Lecturer_Name,Lecturer_Email=@Lecturer_Email,Class_Duration=@Class_Duration,Lecture_Hours=@Lecture_Hours WHERE Course_Name=@Course_Name";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Course_Name", (gridview1.Rows[e.RowIndex].FindControl("txtCName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Course_Heading", (gridview1.Rows[e.RowIndex].FindControl("txtCHeading") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Lecturer_Name", (gridview1.Rows[e.RowIndex].FindControl("txtLectName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Lecturer_Email", (gridview1.Rows[e.RowIndex].FindControl("txtLectEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Class_Duration", (gridview1.Rows[e.RowIndex].FindControl("txtClsDuration") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Lecture_Hours", (gridview1.Rows[e.RowIndex].FindControl("txtLectHrs") as TextBox).Text.Trim());
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

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(constring))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Courses WHERE ID = @ID";
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