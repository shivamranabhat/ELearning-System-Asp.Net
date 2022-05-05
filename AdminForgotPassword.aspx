<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLogin.Master" AutoEventWireup="true" CodeBehind="AdminForgotPassword.aspx.cs" Inherits="ELearning.WebForm31" %>
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
                    <asp:RegularExpressionValidator ID="RegularExpressionValidor1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter a valid Email" ForeColor="#3399FF" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
              </div>
              <div class="box-card">
                <span class="information"> Password</span>
                <asp:Textbox runat="server" ID="txtPassword" type="password" placeholder="Enter your New password" required />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is Required"  ControlToValidate="txtpassword" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                   
              </div>
                 <div class="box-card">
                <span class="information"> Confirm Password</span>
                <asp:Textbox runat="server" ID="txtconfpass" type="password" placeholder="Re-Enter your New password" required />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPassword" ControlToCompare="txtconfpass" ErrorMessage="Password doesn't match" ForeColor="#3399FF"></asp:CompareValidator>
              </div>
            </div>
            <div class="button">
              <asp:button id="logbtn" runat="server" type="submit" text="Reset" class="button" OnClick="resetbtn_Click" />
            </div>
             <br />
              <div class="container-signin">
              <p>Login<a href="AdminLogin.aspx" style="text-decoration: none;"> Now!! </a></p>
            </div>
          </form>
        </div>
</asp:Content>
