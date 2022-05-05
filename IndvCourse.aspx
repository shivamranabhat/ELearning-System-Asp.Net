<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="IndvCourse.aspx.cs" Inherits="ELearning.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
      <form runat="server"> 
        <!-- Header Start -->
    <div class="container-fluid bg-primary py-5 mb-5 page-header">
        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-lg-10 text-center">
                    <h1 class="display-3 text-white animated slideInDown">My Courses</h1>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb justify-content-center">
                            <li class="breadcrumb-item"><a class="text-white" href="#">Home</a></li>
                            <li class="breadcrumb-item"><a class="text-white" href="#">Courses</a></li>
                            <li class="breadcrumb-item text-white active" aria-current="page">My Courses</li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>
    <!-- Header End -->


    <!-- Service Start -->
 <div class="container-xxl py-5" id="service">
        <div class="container">
            <div class="row g-4">
                <div class="col-lg-3 col-sm-6 wow fadeInUp" data-wow-delay="0.1s">
                    <div class="service-item text-center pt-3">
                        <div class="p-4">
                            <i class="fa fa-3x fa-graduation-cap text-primary mb-4"></i>
                            <h5 class="mb-3">Skilled Instructors</h5>
                            <p>We have world best programmers as an instructors</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6 wow fadeInUp" data-wow-delay="0.3s">
                    <div class="service-item text-center pt-3">
                        <div class="p-4">
                            <i class="fa fa-3x fa-globe text-primary mb-4"></i>
                            <h5 class="mb-3">Online Classes</h5>
                            <p>We also provide online classes via microsoft teams</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6 wow fadeInUp" data-wow-delay="0.5s">
                    <div class="service-item text-center pt-3">
                        <div class="p-4">
                            <i class="fa fa-3x fa-home text-primary mb-4"></i>
                            <h5 class="mb-3">Home Projects</h5>
                            <p>Home assignment is given to increase your skills</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6 wow fadeInUp" data-wow-delay="0.7s">
                    <div class="service-item text-center pt-3">
                        <div class="p-4">
                            <i class="fa fa-3x fa-book-open text-primary mb-4"></i>
                            <h5 class="mb-3">Book Library</h5>
                            <p>We provide you the account of paid online library</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Service End -->


    <!-- About Start -->
    <div class="container-xxl py-5">
        <div class="container">
            <div class="row g-5">
                <div class="col-lg-6 wow fadeInUp" data-wow-delay="0.1s" style="min-height: 400px;">
                    <div class="position-relative h-100">
                       
                         <asp:DataList ID="DataList2" runat="server" >
                              <ItemTemplate>
                                   <img class="img-fluid position-absolute w-100 h-100"  src="img/<%#Eval("File")%>" alt="Course-Image" style="object-fit: cover;"/>
                              </ItemTemplate>

                         </asp:DataList>
                    </div>
                </div>
                <div class="col-lg-6 wow fadeInUp" data-wow-delay="0.3s">
                    <h6 class="section-title bg-white text-start text-primary pe-3"> <asp:Label ID="lblCrsName" runat="server"></asp:Label></h6>
                    <h1 class="mb-4"> <asp:Label ID="lblHeading" runat="server"></asp:Label> </h1>
                    <p class="mb-4"> We provide best courses to our students. In every programming language is a computer language programmers use to develop software programs, scripts, or other sets of instructions for computers to execute.Thousands of different programming languages have been created, and more are being created every year. Many programming languages are written in an imperative form.</p>
                    <p class="mb-4"> Different set of rules that converts strings, or graphical program elements in the case of visual programming languages, to various kinds of machine code output. We teach different kind of computer language, and are used in computer programming to implement algorithms.</p>
                    <div class="row gy-2 gx-4 mb-4">
                        <div class="col-sm-6">
                            <p class="mb-0"><i class="fa fa-arrow-right text-primary me-2"></i>Lecturer Name:<asp:Label ID="lblInsName" runat="server"></asp:Label></p>
                        </div>
                        <div class="col-sm-6">
                            <p class="mb-0"><i class="fa fa-arrow-right text-primary me-2"></i> Email:<asp:Label ID="lblEmail" runat="server"></asp:Label> </p>
                        </div>
                        <div class="col-sm-6">
                            <p class="mb-0"><i class="fa fa-arrow-right text-primary me-2"></i>Class Duration/Day:<asp:Label ID="lblClassHrs" runat="server"></asp:Label></p>
                        </div>
                        <div class="col-sm-6">
                            <p class="mb-0"><i class="fa fa-arrow-right text-primary me-2"></i>Course Hours:<asp:Label ID="lblLectHrs" runat="server"></asp:Label></p>
                        </div>
                    </div>
                    <a class="btn btn-primary py-3 px-5 mt-2" href="">Read More</a>
                </div>
            </div>
        </div>
    </div>
       <div class="text-center">
        <h6 class="section-title bg-white text-center text-primary px-3">Weekly</h6>
      <h1 class="mb-5">Class Schedule </h1>
    </div>

              <asp:Repeater ID="r1" runat="server">
                    <HeaderTemplate>
                        <table class="table" >
                            <thead >
                                <tr>
                                    <th scope="col">Day</th>
                                    <th scope="col">From</th>         
                                    <th scope="col">To</th>  
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="content">
                            <td><%#Eval("Days") %> </td>
                            <td><%#Eval("Starts")%> </td>
                            <td><%#Eval("Ends")%> </td>

                        </tr>

                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                       
                    
                </asp:Repeater>
    <!-- Courses End -->
    
   
         <div class="container-xxl py-5" >
        <div class="container">
            <div class="text-center wow fadeInUp" data-wow-delay="0.1s">
                <h6 class="section-title bg-white text-center text-primary px-3">Assignment</h6>
                <h1 class="mb-5">Available Assignment</h1>
            </div>    
            <div class="row g-4">
                <div class="col-lg-4 col-md-6 wow fadeInUp" data-wow-delay="0.1s" style="width:100%;">
                    <div class="course-item bg-light justify-content-center"style="width:70%; position:relative;left:20%;">
                        <div class="position-relative overflow-hidden" >
                            <div class="card" >
                             <asp:DataList ID="DataList1" runat="server" >  
                             <ItemTemplate>  
                            <div class="img-container" style="text-align:center">
                            <img class="img-fluid"  style="width:50%;"  src="img/Assignment.jfif" alt="">
                           </div>
                            <div class="w-100 d-flex justify-content-center position-absolute bottom-0 start-0 mb-4">                           
                            </div>
                        </div>
                        <div class="text-center p-4 pb-0">
                            <h3 class="mb-4" style="font-size:30px"> Assignment</h3>
                            <div class="mb-3">
                                <small class="fa fa-star text-primary"></small>
                                <small class="fa fa-star text-primary"></small>
                                <small class="fa fa-star text-primary"></small>
                                <small class="fa fa-star text-primary"></small>
                                <small class="fa fa-star text-primary"></small>
                                <small>(123)</small>
                            </div>
                        </div>
                        <div class="d-flex border-top">
                            <small class="flex-fill text-center border-end py-2" style="font-size:20px"><i class="fas fa-hourglass-start text-primary me-2"></i><%#Eval("Hand_In")%></small>
                            <small class="flex-fill text-center border-end py-2"style="font-size:20px"><i class="fa fa-hourglass-end text-primary me-2"></i><%#Eval("Hand_Out")%></small>
                            <small class="flex-fill text-center py-2"style="font-size:20px"><i class="fas fa-download text-primary me-2"></i><asp:LinkButton ID="lnkDownload" Text="Download" OnClick="lnkDownload_Click" runat="server" CommandArgument='<%# Eval("ID") %>'> </asp:LinkButton></small>
                        </div>
                                 
                     </ItemTemplate>                             
                   </asp:DataList>
                    </div>
                 </div>
                            
                </div>      
        
            </div>
           </div>
         </div>
       </div>


  <!-- Assignment section Starts -->

        <div class="container" style="margin-top:100px; height:70vh">
        <div class="text-center wow fadeInUp" data-wow-delay="0.1s">
            <h6 class="section-title bg-white text-center text-primary px-3">Submit</h6>
            <h1 class="mb-5">Assignment</h1>
        </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblMessage" runat="server" ForeColor="#33CCFF"></asp:Label>
      <div class="row" style="text-align:center;margin-left:250px ">
        <div class="col-sm-6">
            <div class="card" style="width:50rem;">
              <div class="card-body" style=" box-shadow:inset 0 -3em 3em rgba(0,0,0,0.1), 0 0  0 2px rgb(255,255,255), 0.3em 0.3em 1em rgba(0,0,0,0.3);">
                <h5 class="card-title"><asp:Label ID="lblSub" runat="server"></asp:Label></h5>
                <p class="card-text">Click here to choose file and submit your assignments</p>
                  <asp:FileUpload ID="FileUpload1" style="color:black" runat="server"/><br /> <br />
                 <asp:Button ID="uplbtn" runat="server" Text="Upload" class="btn btn-primary" style="border-radius: 5px 5px 5px 5px; width:100px;" OnClick="uplbtn_Click" ></asp:Button><br /> <br />
              <blockquote class="blockquote mb-0">
              <footer class="blockquote-footer">Feedback: <cite title="Source Title"><asp:Label ID="lblfeedback" runat="server" ForeColor="#0099ff"></asp:Label></cite></footer> <asp:TextBox ID="txtFeedback" runat="server" style="display:none"></asp:TextBox>
            </blockquote>
              </div>
            </div>
          </div>
      </div>
 </div>
          <!-- Assignment section End -->
         
          <!-- Chapter section Starts -->
         <div class="text-center">
        <h6 class="section-title bg-white text-center text-primary px-3">Course</h6>
      <h1 class="mb-5"> Materials</h1>
    </div>
         <asp:GridView ID="gridview2" class="table" runat="server" AutoGenerateColumns="False"  DataKeyNames="ID" 
                ShowHeaderWhenEmpty="True"


                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"    Height="152px"  style="width:100%; text-align: center">
               
                <Columns>
                    <asp:TemplateField HeaderText="Chapter">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Chapter") %>' runat="server" />
                        </ItemTemplate>   
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Slides">
                        <ItemTemplate>
                            <i class="fas fa-download text-primary me-2"></i>
                            <asp:LinkButton ID="lnkDownload1" Text="Download" OnClick="lnkDownload1_Click" runat="server" CommandArgument='<%# Eval("ID") %>'> </asp:LinkButton>
                        </ItemTemplate>     
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Tutorials">
                        <ItemTemplate>
                            <i class="fas fa-download text-primary me-2"></i>
                            <asp:LinkButton ID="lnkDownload2" Text="Download" OnClick="lnkDownload2_Click" runat="server" CommandArgument='<%# Eval("ID") %>'> </asp:LinkButton>
                        </ItemTemplate>     
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
          <!-- Chapter section End -->
        </form>
</asp:Content>
