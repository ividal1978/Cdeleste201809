<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Lugares.aspx.cs" Inherits="WebApplication1.Lugares" %>

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
    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <h2 style="color: tan; font-family: 'Trebuchet MS'; text-shadow: 2px 2px 5px black;">&nbsp;&nbsp;&nbsp;Lugares</h2>
    <form id="LugaresForm" runat="server">
        <div class="container " style="top: 100px;">

            <div class="row" style="top: 100px;">
                <asp:repeater id="RptLugares" runat="server">
                    <itemtemplate>
                    <div class="media rcorners2" style="color:saddlebrown; font-family:'Trebuchet MS'; font-size:medium; background-color:burlywood; opacity:0.7">
                        <img class="mr-3 col-md-2 rcorner0"   src="/Imagenes/Noticias/<%#Eval("RutaImagen")%>"  alt="...">
                         <div   style="color:saddlebrown;" class="media-body">
                           <h5 class="mt-0" >   <%#Eval("Titulo")%></h5>
                             <%#Eval("Noticia")%>
                             </div>
                        </div>
                 </itemtemplate>
                </asp:repeater>
            </div>

        </div>
    </form>

</asp:Content>
