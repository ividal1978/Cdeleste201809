<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Noticias_ABM.aspx.cs" Inherits="WebApplication1.Noticias_ABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
              <script src="Scripts/jquery-3.0.0.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
            <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid" style="margin-top:100px;">
    <div class="row">
        <div class="col-2">
            <asp:Label ID="lbFechaPagina" runat="server" Forecolor="Tan" Font-Size="Large" Text="Fecha:"></asp:Label>
        </div>
        <div class="col-8" style="text-align:center;">
            <asp:Label ID="lbTituloPagina" runat="server" ForeColor="Tan" Font-Size="X-Large" Text="Modulo de Noticias"></asp:Label>
        </div>
        <div class="col-2">
            <asp:Label ID="lbUsuario" runat="server" ForeColor="Tan" Font-Size="Large" Text="Usuario:"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            Tabla de novedades
        </div>
        <div class="col-lg-6">
            Propiedades de novedades
        </div>
    </div>
</div>
</asp:Content>
