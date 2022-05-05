<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="ELearning.WebForm20" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="css/Register.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
      <!-- Header Start -->
<div class="container-fluid bg-primary py-5 mb-5 page-header">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-10 text-center">
                <h1 class="display-3 text-white animated slideInDown">User Profile</h1>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb justify-content-center">
                        <li class="breadcrumb-item"><a class="text-white" href="#">Home</a></li>
                        <li class="breadcrumb-item"><a class="text-white" href="#">Pages</a></li>
                        <li class="breadcrumb-item text-white active" aria-current="page">User Profile</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</div>
<!-- Header End -->
<div class="container">
    <div class="center">
        <div class="text-center">
            <h6 class="section-title bg-white text-center text-primary px-3">User Profile</h6>
            <h1 class="mb-5">Details</h1>
        </div>
        <div class="content">
          <form id="form1" runat="server">
            <div class="user-information">
              <div class="box-card">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                  <asp:Label ID="lblMessage" runat="server" ForeColor="#3399FF"></asp:Label>
                   <a runat="server" id="LogBtn" OnClick="LogBtn_Click" href="Login.aspx" style="font-size:30px;margin-left:470px">
                      <span class="glyphicon glyphicon-log-out"></span>
                                  <i class="bi bi-box-arrow-left"></i>
                    </a>
                   <span class="information">First Name</span>
                <asp:Textbox runat="server" ID="txtFName" type="text" placeholder="Enter your Name" required />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is Required"  ControlToValidate="txtFName" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
              <div class="box-card">
                <span class="information">Last Name</span>
                <asp:Textbox runat="server" ID="txtLName" type="text" placeholder="Enter your Last Name" required/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is Required"  ControlToValidate="txtLName" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
              <div class="box-card">
                <span class="information">Phone Number</span>
                <asp:Textbox runat="server" ID="txtPhone" type="text" placeholder="Enter your Number" required/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Phone Number is Required"  ControlToValidate="txtPhone" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
              <div class="box-card">
                <span class="information">Address</span>
                <asp:Textbox runat="server" ID="txtAddress" type="text" placeholder="Enter your Address" required/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Address is Required"  ControlToValidate="txtAddress" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
                <div class="box-card">
                <span class="information">Email</span>
                <asp:Textbox runat="server" ID="txtEmail" type="text" placeholder="Enter your Email" required/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Email is Required"  ControlToValidate="txtEmail" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
              <div class="box-card">
                <span class="information"> Password</span>
                <asp:Textbox runat="server" ID="txtPassword" type="text" placeholder="Enter your Password" required/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Password is Required"  ControlToValidate="txtPassword" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
            </div>
            <p>
                <label for="UserType" style="display:none" >UserType</label>
                      <asp:Textbox runat="server" ID="txtUserType" style="display:none" type="text" name="ustype"/>
            </p>
            
            <div class="button">
              <asp:Button runat="server" ID="UpdBtn" type="submit" value="Update" Text="Update" class="button" OnClick="UpdBtn_Click" />
            </div>
              
             
          </form>
        </div>
    </div>
    
  </div>


</asp:Content>
