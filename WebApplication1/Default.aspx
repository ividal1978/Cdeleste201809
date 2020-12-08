<%@ Page Title="www.Cdeleste.com.ar :: Inicio " Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cdeleste.com.ar :: Inicio</title>
            <link href="Imagenes/pino-animado-png-1.ico"  rel="icon"/>
            <link href="Content/bootstrap.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
       <script src="Scripts/jquery-3.0.0.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
            <link href="Scripts/Cdeleste.css" rel="stylesheet" />

    <script>(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v3.0";
    fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));</script>

    <div class="container-fluid" >
        <h1 class="align-content-lg-center"> </h1>
        <hr style="color:darkolivegreen;" />
    </div>  
    <br />
        <hr style="background-color:darkolivegreen; height:15px;" />
        <hr style="background-color:darkgoldenrod; height:4px;" />
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4">
                    <h2 style="color:tan; font-family:'Trebuchet MS';   text-shadow: 2px 2px 5px black;">Bienvenido</h2> 
                    <div class="rcorners2" style="color:saddlebrown; font-family:'Trebuchet MS'; font-size:medium; background-color:burlywood;" >
                       <asp:Label ID="lbPortada" runat="server" ></asp:Label>

                    </div>
                   
                </div>
               
                <div class="col-lg-4">
                   <br />
                    <br /> 
                   <div id="carouselExampleIndicators" class="carousel slide " data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner rcorners1">
                        <div class="carousel-item active">
                            <img class="d-block w-100  " src="Imagenes/Slider_Main/1.JPG" alt="La Casita del Bosque">
                              <div class="carousel-caption d-none d-sm-block">
                                <h6  style="text-shadow: 2px 2px 5px black;">La Casita del Bosque</h6>
                          <%--      <p>...</p>--%>
                            </div>
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100 " src="Imagenes/Slider_Main/2.JPG"  alt="Duplex Girasoles">
                              <div class="carousel-caption d-none d-sm-block">
                                <h6  text-shadow: 2px 2px 5px black;>Duplex Girasoles</h6>
                            <%--    <p>...</p>--%>
                            </div>
                        </div>
                        <div class="carousel-item">
                           <img class="d-block w-100 " src="Imagenes/Slider_Main/3.JPG"  alt="La Casona">
                            <div class="carousel-caption d-none d-sm-block">
                                <h6 style="text-shadow: 2px 2px 5px black;">La Casona</h6>
                               <%-- <p>...</p>--%>
                            </div>
                         </div>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                    </a>
                    </div>
                </div>

                <div class="col-lg-2">
                  <br />
                    <br />
                    <iframe src="//www.facebook.com/plugins/likebox.php?href=http%3A%2F%2Fwww.facebook.com%2Fpages%2FEleg%25C3%25AD-Costa-del-Este%2F146505772050939&amp;width=300&amp;height=200&amp;colorscheme=dark&amp;show_faces=true&amp;border_color&amp;stream=false&amp;header=false" scrolling="no" frameborder="0" style="border-style: none; border-color: White; border-width:thin;" allowtransparency="true" class="rcorners1"></iframe><br>
                    <div style="width: 18rem;  padding-top: 0px;  padding-right: 20px; padding-bottom: 0px;  padding-left: 00px;" class="rcorners1">
                    <div id="TT_FhfALhtBYl4Nn8GK3fuFblp6j6lKT442rd1t1cC5q1j" >El tiempo - Tutiempo.net</div>
                    <script type="text/javascript" src="https://www.tutiempo.net/s-widget/l_FhfALhtBYl4Nn8GK3fuFblp6j6lKT442rd1t1cC5q1j"></script>
                 </div>
                </div>
         </div>
        </div>
        <div class="container-fluid" style="padding-top:20px;">
              <asp:DataList ID="dlNoticias" runat="server" RepeatDirection="Horizontal"   RepeatLayout="Table" >
                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" />
                <ItemTemplate>
          
                   <div class="card mb-3" style="max-width: 540px; background-image:url(Imagenes/Fondos/27.jpg); height:350px; ">
                      <div class="row g-0">
                        <div class="col-md-4" style="padding-top:20px;" >
                          <img  class="rcorners0"width="150px" height="125px" src="/Imagenes/Noticias/<%#Eval("RutaImagen")%>" alt="..."> 
                           <p class="card-text"><meddium  style="color:antiquewhite;  text-shadow: 2px 2px 5px black;"   ><%#Eval("Fecha","{0:dd/MM/yyyy}")%></meddium></p>
                        </div>
                        <div class="col-md-8">
                          <div class="card-body">
                            <p class="card-text rcorners1" style=" opacity:0.75; padding:5px; color:saddlebrown; background-color:beige; text-align:center; text-size-adjust:auto; height:auto;"><%#Eval("Noticia")%></p>
                           
                          </div>
                        </div>
                      </div>
                    </div>
                 </ItemTemplate>

<SeparatorStyle Width="50px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top"></SeparatorStyle>
            </asp:DataList>
                   
                </div>
       
</asp:Content>
