<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLogin.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ELearning.WebForm24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
         <form id="form1" runat="server">
            <div class="user-information">
              <div class="box-card">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
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
              <asp:button id="logbtn" runat="server" type="submit" text="Login" class="button" OnClick="logbtn_Click"  />
            </div>
              <br />
             <div class="container-signin">
              <p>Forgot Password?<a href="AdminForgotPassword.aspx" style="text-decoration: none;"> Click Here!! </a></p>
            </div>
             <br />
            <div class="container-signin">
              <p>Don't Have an account?<a href="AdminRegister.aspx" style="text-decoration: none;"> Register Here!! </a></p>
            </div>
          </form>
        </div>
</asp:Content>
