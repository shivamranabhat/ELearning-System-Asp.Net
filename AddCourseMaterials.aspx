<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer.Master" AutoEventWireup="true" CodeBehind="AddCourseMaterials.aspx.cs" Inherits="ELearning.WebForm29" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/AddAssignment.css" rel="stylesheet">
    <style>
        .container-x {
            position:absolute;
            top:130px;
            height:10vh;
            left:30%;
            padding: 10px;
            width: 40%;
            text-align: center;
            border-radius: 25px 25px 25px 25px;
            background:  #0A2558;
            color: white;
            font-size: 30px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="sales-boxes">
        <div class="recent-sales box">
           <div class="sales-details">
               <div class="container-x">
                    <h1>Course Materials</h1>
                   </div>
              </div>
          </div>
        </div>
       <div class="container" >
    <div class="center" style="height:80vh">
        
        <div class="content">
          <form id="form1" runat="server">
            <div class="user-information">
              <div class="box-card">
                   
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="lblMessage" runat="server" ForeColor="#3399FF"></asp:Label>
                   
                <span class="information">Chapter</span>
                <asp:Textbox runat="server"  ID="txtChapter" type="text" placeholder="Enter Chapter Name" required />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Chapter Name is Required"  ControlToValidate="txtChapter" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
             
                <div class="box-card">
                <span class="information"> Slides</span>
                <asp:FileUpload ID="FileUpload1" runat="server" />

              </div>
                <div class="box-card">
                <span class="information"> Tutorials</span>
                <asp:FileUpload ID="FileUpload2" runat="server" />

              </div>
            </div>
            <div class="button">
              <asp:button id="Uploadbtn" runat="server" type="submit" text="Upload" class="button" OnClick="Uploadbtn_Click"   />
            </div>
              <br />
            
          </form>
        </div>
    </div>
    
  </div>
</asp:Content>
