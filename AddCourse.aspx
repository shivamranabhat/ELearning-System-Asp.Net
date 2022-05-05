<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebForm35.aspx.cs" Inherits="ELearning.WebForm35" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/AddCourse.css" rel="stylesheet">
    <style>
        .container-x {
            position:absolute;
            top:250px;
            height:10vh;
            left:35%;
            padding: 10px;
            width: 30%;
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
                    <h1>New Course</h1>
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
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Label ID="lblMessage" runat="server" ForeColor="#3399FF"></asp:Label>
                       <div class="box-card">
                           <span class="information"> Course Name</span>
                    <asp:Textbox runat="server" ID="txtCName" type="Text" placeholder="Enter Course Name" required />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Course Name is Required"  ControlToValidate="txtCName" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  </div>
                       <div class="box-card">
                    <span class="information"> Course Code</span>
                    <asp:Textbox runat="server" ID="txtCode" type="Text" placeholder="Enter Course Name" required />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Course Code is Required"  ControlToValidate="txtCode" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  </div>
                    <span class="information">Course Price</span>
                    <asp:Textbox runat="server"  ID="txtCPrice" type="text" placeholder="Enter Course Price" required />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Course Price is Required"  ControlToValidate="txtCPrice" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  </div>
                  <div class="box-card">
                    <span class="information"> Lecturer Name</span>
                    <asp:Textbox runat="server" ID="txtLName" type="text" placeholder="Enter Lecturer Name" required />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lecturer Name is Required"  ControlToValidate="txtLName" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  </div>
                  <div class="box-card">
                    <span class="information"> Lecturer Hour</span>
                    <asp:Textbox runat="server" ID="txtLectHrs" type="text" placeholder="Enter Lecturer Name" required />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Lecturer Hour is Required"  ControlToValidate="txtLectHrs" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  </div>
                  <div class="box-card">
                    <span class="information"> Status</span>
                    <asp:Textbox runat="server" ID="txtStatus" type="text" placeholder="Enter Lecturer Name" required />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Lecturer Name is Required"  ControlToValidate="txtStatus" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  </div>
                    <div class="box-card">
                    <span class="information"> Course Image</span>
                    <asp:FileUpload ID="FileUpload1" runat="server"  required/>

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
