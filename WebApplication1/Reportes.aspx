﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="WebApplication1.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>Reportes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <script src="Scripts/phone-mask.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700" rel="stylesheet">
     <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/baguettebox.js/1.8.1/baguetteBox.min.css">
    <link rel="stylesheet" href="Scripts/gallery-grid.css">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Css/CssCdeleste.css" rel="stylesheet" />
    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <form id="FromReservasABM" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="LbFecha" runat="server" CssClass="TextoEncabezado" ForeColor="Tan"></asp:Label>
                </div>
                <div class="col-lg-4" style="color: tan;">
                    Modulo de Reportes
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="LbUsuario" runat="server" CssClass="TextoEncabezado" ForeColor="Tan" Text="Usuario:"></asp:Label>
                </div>
            </div>
        </div>
        <div>
         <div class="rcorners1" style="color:saddlebrown; font-family:'Trebuchet MS'; font-size:large; background-color:burlywood;  text-align:center; align-items:center;" >
                        &nbsp;&nbsp;Tipos de Reportes</asp:Label>
        </div>
        <div  style="padding:10px;">
          <asp:Button ID="btnAlquileres" runat="server" CssClass="btn btn-outline-warning"  Text="Alquileres / Reservas"  OnClick="btnAlquileres_Click" /> &nbsp;&nbsp;
           <asp:Button ID="btnInquilinos" runat="server" CssClass="btn btn-outline-warning" Text="Inquilinos" OnClick="btnInquilinos_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnConsultas" runat="server" CssClass="btn btn-outline-warning" Text="Consultas" OnClick="btnConsultas_Click" />&nbsp;&nbsp;
        </div>
        <div>
            <table>
                <tr>
                    <td style="width:70%">
                    
                    </td>
                    <td style="width:20%">
                        <div><asp:Label ID="lgVariables" runat="server" Text="Variables" CssClass="rcorners1"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        </form>
</asp:Content>
