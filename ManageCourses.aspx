<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCourses.aspx.cs" Inherits="ELearning.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .header {
            padding: 10px;
            width: 30%;
            text-align: center;
            border-radius: 0px 25px 25px 0;
            background:  #0A2558;
            color: white;
            font-size: 30px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
   <div class="header">
          <h1>Course Details</h1>
        </div>
        <br />
      <div class="sales-boxes">
        <div class="recent-sales box">
           <div class="sales-details">
               <div class="container">
              <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="ID"
                ShowHeaderWhenEmpty="True"

                OnRowEditing="gridview1_RowEditing" OnRowCancelingEdit="gridview1_RowCancelingEdit"
                OnRowUpdating="gridview1_RowUpdating" OnRowDeleting="gridview1_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="5px" CellPadding="15" Width="1340px" Height="272px"  style="margin-left:10px; text-align: center">
               
                <Columns>
                    <asp:TemplateField HeaderText="Course.ID">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ID") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtID" Text='<%# Eval("ID") %>' runat="server" ReadOnly="true" Width="10px" />
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Course Code">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Course_Code") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCrCode" Text='<%# Eval("Course_Code") %>' runat="server" />
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Course Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Course_Name") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCrName" Text='<%# Eval("Course_Name") %>' runat="server" />
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Course Price">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Course_Price") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCrPrice" Text='<%# Eval("Course_Price") %>' runat="server" />
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Lecturer Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Lecturer_Name") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLectName" Text='<%# Eval("Lecturer_Name") %>' runat="server" />
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Lecture Hours">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Lecture_Hour") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLectHrs" Text='<%# Eval("Lecture_Hour") %>' runat="server" />
                        </EditItemTemplate>
                       
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Status") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStatus" Text='<%# Eval("Status") %>' runat="server" />
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("File") %>' runat="server" />
                        </ItemTemplate>             
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="25px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="25px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/img/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="25px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="25px" Height="20px"/>
                        </EditItemTemplate>
                      
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                   </div>
               <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="#3399FF" />
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
  
        </div>
          </div>

        </div>
         </form>

</asp:Content>
