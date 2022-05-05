<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer.Master" AutoEventWireup="true" CodeBehind="LecturerDashboard.aspx.cs" Inherits="ELearning.WebForm33" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="css/LecturerDashboard.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="height:auto">
        <!-- home section  -->
        <section class="home">       
            <div class="content">
                <h3>Hello Lecturer.<br /> Welcome Back!!!</h3>
                <p>You are provided the authority to manage the courses of krypton education system. Explore more to know your authority.</p>
                <a href="#" class="btn" style="text-decoration:none">Get started</a>
            </div>     
            <div class="image">
                <img src="img/Admin.svg" alt="">
            </div>
        </section>
        </div>
</asp:Content>
