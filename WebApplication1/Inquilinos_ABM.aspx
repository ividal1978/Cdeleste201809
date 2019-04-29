<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Inquilinos_ABM.aspx.cs" Inherits="WebApplication1.Inquilinos_ABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <div class="container-fluid" style="margin-top: 10px;">
        <div class="row">
            <div class="col-2">
                <asp:Label ID="lbFechaPagina" runat="server" ForeColor="Tan" Font-Size="Large" Text="Fecha:"></asp:Label>
            </div>
            <div class="col-8" style="text-align: center;">
                <asp:Label ID="lbTituloPagina" runat="server" ForeColor="Tan" Font-Size="X-Large" Text="Modulo de Noticias"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Label ID="lbUsuario" runat="server" ForeColor="Tan" Font-Size="Large" Text="Usuario:"></asp:Label>
            </div>
        </div>
        <form id="formInquilinoABM" runat="server">

        </form>
</asp:Content>
