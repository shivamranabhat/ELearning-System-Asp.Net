<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="ELearning.WebForm32" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link rel="stylesheet" href="css/Dashboard.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="height:60vh">
        <!-- home section  -->
        <section class="home">
        
            <div class="content">
                <h3>Hello Admin.<br /> Welcome Back!!!</h3>
                <p>You are provided the authority to manage the entire krypton education system. Explore more to know your authority.</p>
                <a href="#" class="btn">get started</a>
            </div>
        
            <div class="image">
                <img src="img/Admin.svg" alt="">
            </div>
        
        </section>
        
        </div>
</asp:Content>
