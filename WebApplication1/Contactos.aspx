<%@ Page Title="Contactos" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="WebApplication1.Contactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Consultas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <script src="Scripts/phone-mask.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/baguettebox.js/1.8.1/baguetteBox.min.css">
    <link rel="stylesheet" href="Scripts/gallery-grid.css">
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <h2 style="color:tan; font-family:'Trebuchet MS';   text-shadow: 2px 2px 5px black;">&nbsp;&nbsp;&nbsp;Contactos</h2> 
    <form id="FormContactos" runat="server">
        <div class="card mb-3" style="max-width: 90%; padding: 2%; margin: 5%; opacity: 0.85; background-color: burlywood; color: saddlebrown; font-family: 'Trebuchet MS'">
            <div class="row no-gutters" style="background-color: transparent;">
                <div class="col-lg-4">
                    <img src="Imagenes/Contactos/IMG_20190721_102308833_HDR.jpg" class="card-img" alt="La casona">
                </div>
                <div class="col-lg-8">
                    <div class="card-body">
                      <%--  <h5 class="card-title Titulo" style="color: blanchedalmond; font-size: x-large;">Contactos</h5>--%>
                        <p class="card-text">Por mas de 35 años en Costa del Este, brindando un exelente servicio. Ante cualquier consulta, duda, reserva comuniquese por siguientes canales: </p>

                        <div class="card " style="width: 97%; background-color: blanchedalmond; border-bottom: solid 2px;">
                            <ul class="list-group list-group-flush" style="background-color: blanchedalmond !important;">
                                <li class="list-group-item"><i class="fa fa-phone-square  fa-2x" style="color: saddlebrown;"></i>&nbsp;&nbsp;&nbsp;Teléfono: +054 011-4256-1541</li>
                                <li class="list-group-item"><i class="far fa-envelope fa-2x" style="color: saddlebrown;"></i>&nbsp;&nbsp;&nbsp;Correo electrónico: <a href="mailto:violetasgyg@gmail.com?Subject=Consulta%20sobre%20Costa%20del%20Este">violetasgyg@gmail.com</a></li>
                                <li class="list-group-item"><i class="fab fa-facebook fa-2x" style="color: saddlebrown;"></i>&nbsp;&nbsp;&nbsp;Facebook: <a href="https://www.facebook.com/Eleg%C3%AD-Costa-del-Este-146505772050939/">Elegí Costa del Este</a></li>
                                <li class="list-group-item"><i class="fas fa-map-signs fa-2x" style="color: saddlebrown;"></i>&nbsp;&nbsp;&nbsp;Direcciones: Geranios y Violestas, Costa del Este, Buenos Aires, Argentina.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
               <div class="mapouter">
                            <div class="gmap_canvas card" >
                                <iframe width="100%" height="500px" id="gmap_canvas" src="https://maps.google.com/maps?q=La%20casona%20costa%20del%20este&t=&z=15&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="2" marginwidth="2"></iframe>
                                <a href="https://www.emojilib.com"></a></div>
                            <style>
                                .mapouter {
                                    position: relative;
                                    text-align: right;
                                    height: 500px;
                                    width: 100%;
                                    margin: 5px;
                                }

                                .gmap_canvas {
                                    overflow: hidden;
                                    background: none !important;
                                    height: 500px;
                                    width: 100%;
                                }
                            </style>
                        </div>
        </div>
    </form>
</asp:Content>
