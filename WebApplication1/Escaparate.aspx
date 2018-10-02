<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Escaparate.aspx.cs" Inherits="WebApplication1.Escaparate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link href="Imagenes/pino-animado-png-1.ico"  rel="icon"/>
            <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
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

</asp:Content>
