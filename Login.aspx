<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ELearning.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <!-- Header Start -->
<div class="container-fluid bg-primary py-5 mb-5 page-header">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-10 text-center">
                <h1 class="display-3 text-white animated slideInDown">Login</h1>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb justify-content-center">
                        <li class="breadcrumb-item"><a class="text-white" href="#">Home</a></li>
                        <li class="breadcrumb-item"><a class="text-white" href="#">Pages</a></li>
                        <li class="breadcrumb-item text-white active" aria-current="page">Login</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</div>
<!-- Header End -->
<div class="container" style="height:70vh;">
    <div class="center">
        <div class="text-center">
            <h6 class="section-title bg-white text-center text-primary px-3">Login</h6>
            <h1 class="mb-5">Fill up the form</h1>
        </div>
        <div class="content">
          <form id="form1" runat="server">
            <div class="user-information">
              <div class="box-card">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server" ForeColor="#3399FF"></asp:Label>
                <span class="information">Email</span>
                <asp:Textbox runat="server"  ID="txtEmail" type="text" placeholder="Enter your Email" required />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email is Required"  ControlToValidate="txtEmail" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
              <div class="box-card">
                <span class="information"> Password</span>
                <asp:Textbox runat="server" ID="txtpassword" type="password" placeholder="Enter your password" required />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is Required"  ControlToValidate="txtpassword" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
            </div>
            <div class="button">
              <asp:button id="logbtn" runat="server" type="submit" text="Login" class="button" OnClick="logbtn_Click" />
            </div>
              <br />
            <div class="container-signin">
              <p>Don't Have an account?<a href="Register.aspx" style="text-decoration: none;"> Register Here!! </a></p>
            </div>
              <br />
               <div class="container-signin">
              <p>Forgot Password?<a href="ForgotPassword.aspx" style="text-decoration: none;"> Click Here!! </a></p>
            </div>
          </form>
        </div>
    </div>
    
  </div>
</asp:Content>
