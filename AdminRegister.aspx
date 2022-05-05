<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLogin.Master" AutoEventWireup="true" CodeBehind="AdminRegister.aspx.cs" Inherits="ELearning.WebForm25" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content" style="height:100vh">
         <form id="form1" runat="server">
            <div class="user-information">
              <div class="box-card">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="lblMessage" runat="server" ForeColor="#3399FF"></asp:Label>
  
               <span class="information">First Name</span>
                <asp:Textbox runat="server" ID="txtFName" type="text" placeholder="Enter your Name" required />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is Required"  ControlToValidate="txtFName" ForeColor="#3399FF"></asp:RequiredFieldValidator>
              </div>
              <div class="box-card">
                <span class="information">Last Name</span>
                <asp:Textbox runat="server" ID="txtLName" type="text" placeholder="Enter your Email" required/>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Email is Required"  ControlToValidate="txtEmail" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidor1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter a valid Email" ForeColor="#3399FF" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ></asp:RegularExpressionValidator>

              </div>
              <div class="box-card">
                <span class="information"> Password</span>
                <asp:Textbox runat="server" ID="txtPassword" type="password" placeholder="Enter your Password" required/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Password is Required"  ControlToValidate="txtPassword" ForeColor="#3399FF"></asp:RequiredFieldValidator>              </div>
            </div>
            <p>
              <input type="checkbox" required>
              I'm agree to the Krypton <a href="#" style="text-decoration: none">Terms & Privacy</a><br />
              
                <label for="UserType" style="display:none" >UserType</label>
                      <asp:Textbox runat="server" ID="txtUserType" style="display:none" type="text" name="ustype"/>
            </p>
            <div class="button">
              <asp:Button runat="server" ID="RegBtn" type="submit" value="Register" Text="Register" class="button" OnClick="RegBtn_Click"/>
            </div>
              <br />
            <div class="container-signin">
              <p>Already have an account?<a href="AdminLogin.aspx" style="text-decoration: none;"> Sign in </a></p>
            </div>
          </form>
        </div>
</asp:Content>
