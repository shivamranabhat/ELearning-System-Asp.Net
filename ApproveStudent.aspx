<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ApproveStudent.aspx.cs" Inherits="ELearning.WebForm14" %>
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
    <form id="form1" runat="server"> 
        <div class="header">
  <h1>Booking Details</h1>
</div>
 <div class="sales-boxes">
        <div class="recent-sales box">
          <div class="sales-details">
              <br />
               
        <div class="col-lg-12">
                    <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"  DataKeyNames="ID"
                 OnRowEditing="gridview1_RowEditing" 
             

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="5px" CellPadding="15" Width="1340px"   style="margin-left:10px; text-align: center" Height="229px" OnRowDeleting="gridview1_RowDeleting1">
                <Columns>
                    
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True"/>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:BoundField DataField="Date" ReadOnly="true" HeaderText="Enroll Date" />
                    <asp:BoundField DataField="Course_Title" HeaderText="Course_Title" />
                    <asp:BoundField DataField="CardHolder_Name" HeaderText="CardHolder Name" />
                    <asp:BoundField DataField="Card_Number" HeaderText="Card Number" />
                    <asp:BoundField DataField="Exp_Month" HeaderText="Exp Month" />
                    <asp:BoundField DataField="Exp_Year" HeaderText="Exp Year" />
                    <asp:BoundField DataField="CVV" HeaderText="CVV" />
                    <asp:BoundField DataField="UserType" HeaderText="UserType" />
                  
                     <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/img/Ok.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="30px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="30px" Height="20px"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
            </asp:GridView>
                </div>
             <br />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="#3399FF" />
            </div>
        </div>
      </div>

   
        </form>
</asp:Content>
