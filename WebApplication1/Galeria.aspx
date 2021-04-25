<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Galeria.aspx.cs" Inherits="WebApplication1.Galeria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <link href="Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>--%>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <!------ Include the above in your HEAD tag ---------->

    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.css" media="screen">
    <script src="//cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.js"></script>
    <br />
    <br />
    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />

    <script class="text" type="text/javascript">
        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: "none",
                closeEffect: "none"
            });

            $(".zoom").hover(function () {

                $(this).addClass('transition');
            }, function () {

                $(this).removeClass('transition');
            });
        });


    </script>
    <!-- Page Content -->
     <h2 style="color:tan; font-family:'Trebuchet MS';   text-shadow: 2px 2px 5px black;">&nbsp;&nbsp;&nbsp;Galeria</h2> 
    <div class="container " style="top: 100px;">

        <div class="row" style="top: 100px;">

            <asp:repeater id="rptImages" runat="server">
                <ItemTemplate>  
                  <div class="col-lg-3 col-md-4 col-xs-6 thumb">
                                    <a href="Imagenes/Galeria/<%#DataBinder.Eval(Container.DataItem,"ruta") %>" class="fancybox" rel="ligthbox">
                                        <img src="Imagenes/Galeria/<%#DataBinder.Eval(Container.DataItem,"ruta") %>" class="zoom img-fluid " alt="">
                                    </a>
                  <a style="color:antiquewhite;  text-shadow: 2px 2px 5px black;"> <%# DataBinder.Eval(Container.DataItem, "reseña") %> </a>
                                </div>
               </ItemTemplate>
              </asp:repeater>

        </div>
    
    </div>
</asp:Content>
