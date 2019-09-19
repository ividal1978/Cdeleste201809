<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Escaparate.aspx.cs" Inherits="WebApplication1.Escaparate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link href="Imagenes/pino-animado-png-1.ico"  rel="icon"/>
            <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
   <link href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/baguettebox.js/1.8.1/baguetteBox.min.css">
    <link rel="stylesheet" href="Scripts/gallery-grid.css">

    <form id="Propiedades" runat="server">
        <div style="padding-top:05px;">
         
        <hr style="background-color:darkolivegreen; height:15px; " />
        <hr style="background-color:darkgoldenrod; height:4px;" />
        <asp:Label ID="LbPropiedad" runat="server" CssClass="Titulo" Font-Size="XX-Large" Text="Propiedad"></asp:Label>
            <br />
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4">
                    <div class="rcorners1" style="color:saddlebrown; font-family:'Trebuchet MS'; font-size:large; background-color:burlywood;  text-align:center; align-items:center;" >
                        &nbsp;&nbsp;<asp:Label ID="LbDireccion" runat="server" ></asp:Label>
                    </div>
                    <div >
                       <asp:Image  ID="ImgReferencia" runat="server" CssClass="rcorners2 rounded-4"  ImageUrl="~/Imagenes/Slider_Main/1.JPG"  Width="90%"/>
                    </div>
                      <<div class="rcorners2" style="color:saddlebrown; font-family:'Trebuchet MS'; font-size:large; background-color:burlywood;" >
                           <asp:Label ID="lbDescripcion" runat="server" ></asp:Label>
                     </div>
                </div>
                <div class="col-lg-5">
                    <div class="table table-hover rcorners2" style="color:saddlebrown; font-family:'Trebuchet MS'; font-size:large; background-color:burlywood;">
                        <asp:Repeater ID="rptDescripcion" runat="server" >
                            <ItemTemplate >
                                <i class="far fa-check-circle"></i> 
                                <asp:Label ID="lblSubject" style="padding:2px; " runat="server" Font-Size="Large" CssClass="table-hover" Text='<%#Eval("Descripcion") %>' />
                                <br /> <br />
                         
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
                <div class="col-lg-3">
                    <asp:Button ID="btmDisponibilidad" runat="server" CssClass="btn btn-outline-warning" Text="Disponibilidad" OnClick="btmDisponibilidad_Click" />
                    <br />
                    <br />
                    <asp:Button ID="BtnFaqs" runat="server" CssClass="btn btn-outline-warning" Text="Preguntas Frecuentes" />
                    <br />
                    <br />
                    <input type="button" value="Galeria de Fotos" onClick="document.getElementById('Galeria').scrollIntoView();"  class="btn btn-outline-warning" title="Galeria" >
            </div>
        </div>
        <div class="container-fluid" id="Galeria">
           <div class="tz-gallery">

            <div class="row">
                <div class="col-sm-6 col-md-4">
                    <a class="lightbox"  ID="Link1" runat="server" href="../imagenes/Ejemplo/park.jpg">
                      <%--  <img src="../imagenes/Ejemplo/park.jpg" alt="Park">--%>
                        <asp:Image ID="Img1" runat="server" />
                    </a>
                </div>
                <div class="col-sm-6 col-md-4">
                    <a class="lightbox"  ID="Link2" runat="server" href="../imagenes/Ejemplo/bridge.jpg">
                       <%-- <img src="../imagenes/Ejemplo/bridge.jpg" alt="Bridge">--%>
                        <asp:Image ID="Img2" runat="server" />
                    </a>
                </div>
                <div class="col-sm-12 col-md-4">
                    <a class="lightbox" Id="Link3" runat="server" href="../imagenes/Ejemplo/tunnel.jpg">
                        <asp:Image ID="Img3" runat="server" />
                        <%--<img src="../imagenes/Ejemplo/tunnel.jpg" alt="Tunnel">--%>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4">
                    <a class="lightbox" Id="Link4" runat="server" href="../imagenes/Ejemplo/coast.jpg">
                        <asp:Image ID="Img4" runat="server" />
                        <%--<img src="../imagenes/Ejemplo/coast.jpg" alt="Coast">--%>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4">
                    <a class="lightbox" Id="Link5" runat="server" href="../imagenes/Ejemplo/rails.jpg">
                        <%--<img src="../imagenes/Ejemplo/rails.jpg" alt="Rails">--%>
                        <asp:Image ID="Img5" runat="server" />
                    </a>
                </div>
                <div class="col-sm-6 col-md-4">
                    <a class="lightbox" Id="Link6"  runat="server" href="../imagenes/Ejemplo/traffic.jpg">
                        <asp:Image ID="Img6" runat="server" />
                        <%--<img src="../imagenes/Ejemplo/traffic.jpg" alt="Traffic">--%>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4">
                    <a class="lightbox" id="Link7" runat="server" href="../imagenes/Ejemplo/rocks.jpg">
                        <asp:Image ID="Img7" runat="server" />
                        <%--<img src="../imagenes/Ejemplo/rocks.jpg" alt="Rocks">--%>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4">
                    <a class="lightbox" Id="Link8" runat="server"  href ="../imagenes/Ejemplo/benches.jpg">
                        <asp:Image ID="Img8" runat="server" />
                        <%--<img src="../imagenes/Ejemplo/benches.jpg" alt="Benches">--%>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4">
                    <a class="lightbox" id="Link9"  runat="server" href="../imagenes/Ejemplo/sky.jpg">
                        <asp:Image ID="Img9" runat="server" />
                        <%--<img src="../imagenes/Ejemplo/sky.jpg" alt="Sky">--%>
                    </a>
                </div>
            </div>

        </div>

    </div>
            <asp:HiddenField id="hdnId" runat="server" />
</form>
<script src="https://cdnjs.cloudflare.com/ajax/libs/baguettebox.js/1.8.1/baguetteBox.min.js"></script>
<script>
    baguetteBox.run('.tz-gallery');
</script>
</asp:Content>
