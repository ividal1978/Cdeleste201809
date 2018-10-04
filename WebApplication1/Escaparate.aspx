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


    <div style="padding-top:35px;">
     <br />
    <hr style="background-color:darkolivegreen; height:15px; " />
    <hr style="background-color:darkgoldenrod; height:4px;" />
    <asp:Label ID="LbPropiedad" runat="server" CssClass="Titulo" Font-Size="X-Large" Text="Propiedad"></asp:Label>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-5"></div>
            <div class="col-lg-4"></div>
            <div class="col-lg-3"></div>
        </div>
    </div>
    <div class="container-fluid">
       <div class="tz-gallery">

        <div class="row">
            <div class="col-sm-6 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/park.jpg">
                    <img src="../imagenes/Ejemplo/park.jpg" alt="Park">
                </a>
            </div>
            <div class="col-sm-6 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/bridge.jpg">
                    <img src="../imagenes/Ejemplo/bridge.jpg" alt="Bridge">
                </a>
            </div>
            <div class="col-sm-12 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/tunnel.jpg">
                    <img src="../imagenes/Ejemplo/tunnel.jpg" alt="Tunnel">
                </a>
            </div>
            <div class="col-sm-6 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/coast.jpg">
                    <img src="../imagenes/Ejemplo/coast.jpg" alt="Coast">
                </a>
            </div>
            <div class="col-sm-6 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/rails.jpg">
                    <img src="../imagenes/Ejemplo/rails.jpg" alt="Rails">
                </a>
            </div>
            <div class="col-sm-6 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/traffic.jpg">
                    <img src="../imagenes/Ejemplo/traffic.jpg" alt="Traffic">
                </a>
            </div>
            <div class="col-sm-6 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/rocks.jpg">
                    <img src="../imagenes/Ejemplo/rocks.jpg" alt="Rocks">
                </a>
            </div>
            <div class="col-sm-6 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/benches.jpg">
                    <img src="../imagenes/Ejemplo/benches.jpg" alt="Benches">
                </a>
            </div>
            <div class="col-sm-6 col-md-4">
                <a class="lightbox" href="../imagenes/Ejemplo/sky.jpg">
                    <img src="../imagenes/Ejemplo/sky.jpg" alt="Sky">
                </a>
            </div>
        </div>

    </div>

</div>
<script src="https://cdnjs.cloudflare.com/ajax/libs/baguettebox.js/1.8.1/baguetteBox.min.js"></script>
<script>
    baguetteBox.run('.tz-gallery');
</script>
</asp:Content>
