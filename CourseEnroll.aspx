<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CourseEnroll.aspx.cs" Inherits="ELearning.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/enroll.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container-fluid bg-primary py-5 mb-5 page-header">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-10 text-center">
                <h1 class="display-3 text-white animated slideInDown">Enroll</h1>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb justify-content-center">
                        <li class="breadcrumb-item"><a class="text-white" href="#">Home</a></li>
                        <li class="breadcrumb-item"><a class="text-white" href="#">Pages</a></li>
                        <li class="breadcrumb-item text-white active" aria-current="page">Enroll Course</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</div>
<!-- Header End -->
<div class="enroll">
    <div class="row">
        <div class="col-75">
          <div class="container">
            <div class="text-center">
                <h6 class="section-title bg-white text-center text-primary px-3">Enroll Course</h6>
                <h1 class="mb-5">Fill up the Details</h1>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server" ForeColor="#3399FF"></asp:Label><br /><br />
            </div>
            <form runat="server">
      
              <div class="row">
                <div class="col-50">
                  <h3>Personal/Course Details</h3>
                  <label for="fname"><i class="fa fa-user"></i> Full Name</label>
                  <asp:Textbox runat="server" ID="txtName" type="text" name="firstname" placeholder="Enter Your Name"/>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is Required"  ControlToValidate="txtName" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  <label for="email"><i class="fa fa-envelope" aria-hidden="true"></i> Email</label>
                  <asp:Textbox runat="server" ID="txtEmail" type="text"  ReadOnly="true" name="email" placeholder="@example.com"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is Required"  ControlToValidate="txtEmail" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidor1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter a valid Email" ForeColor="#3399FF" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ></asp:RegularExpressionValidator>
                  <label for="Phone"><i class="fas fa-phone"></i> Phone</label>
                  <asp:Textbox runat="server" ID="txtNum" type="text"  name="Phone" placeholder="Enter Phone Number"/>  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Phone is Required"  ControlToValidate="txtNum" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                   <label for="date"><i class="fas fa-calendar-alt"></i> Enroll Date</label>
                  <asp:Textbox runat="server" ID="txtenrolldate" ReadOnly="true" type="text"  name="date"/>    
                    <div class="row">
                    <div class="col-50">
                      <label for="code">Course Code</label>
                      <asp:Textbox runat="server" ID="txtCode" type="text" name="code"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Course Code is Required"  ControlToValidate="txtCode" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-50">
                      <label for="zip">Course Title</label>
                      <asp:Textbox runat="server" ID="txtTitle" type="text"  name="zip" placeholder="Enter Course Name"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Course Name is Required"  ControlToValidate="txtTitle" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                </div>
      
                <div class="col-50">
                  <h3>Payment</h3>
                  <label for="Cname">Accepted Cards</label>
                  <div class="icon-container">
                    <i class="fab fa-cc-visa" style="color:navy; font-size:35px;"></i>
                    <i class="fab fa-cc-mastercard"style="color:orange;font-size:35px;"></i>
                    <i class="fab fa-cc-paypal"style="color:blue;font-size:35px"></i>
                      <i class="bi bi-credit-card"style="color:red;font-size:35px"></i>
                  </div>
                  <label for="cname">Cardholder Name</label>
                  <asp:Textbox runat="server" ID="txtHldrName" type="text"  name="cardname" placeholder="Enter Card Holder Name"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Card Holder Name is Required"  ControlToValidate="txtHldrName" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  <label for="ccnum">Card number</label>
                  <asp:Textbox runat="server" ID="txtCardNumber" type="text"  name="cardnumber" placeholder="1111-2222-3333-4444"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Card Number is Required"  ControlToValidate="txtCardNumber" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  <label for="expmonth">Exp Month</label>
                  <asp:Textbox runat="server" ID="txtExpMonth" type="text"  name="expmonth" placeholder="Enter Expiration Month"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Exp Month is Required"  ControlToValidate="txtExpMonth" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                  <div class="row">
                    <div class="col-50">
                      <label for="expyear">Exp Year</label>
                      <asp:Textbox runat="server" ID="txtExpYear" type="text"  name="expyear" placeholder="Enter Expiration Year"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Exp Month is Required"  ControlToValidate="txtExpYear" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-50">
                      <label for="cvv">CVV</label>
                      <asp:Textbox runat="server" ID="txtCVV" type="text"  name="cvv" placeholder="Enter CVV"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="CVV is Required"  ControlToValidate="txtCvv" ForeColor="#3399FF"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                </div>
      
              </div>
              <p>
                <input type="checkbox" required >
                I'm agree to the eLearning <a href="#"style="text-decoration: none;">Terms & Privacy</a><br />
                
                                     
                      <label for="UserType" style="display:none" >UserType</label>
                      <asp:Textbox runat="server" ID="txtUserType" style="display:none" type="text" name="ustype"/>
                    
              </p>
                <asp:button runat="server" id="paybtn" type="submit" text="Pay Now"  class="button" OnClick="paybtn_Click" />
            </form>
          </div>
        </div>
        </div>
    </div>
</asp:Content>
