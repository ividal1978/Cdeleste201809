<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WebApplication1.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <script src="Scripts/jquery-3.0.0.min.js"></script>
         <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <br /> 
       <br />
       <hr style="background-color:darkolivegreen; height:15px;" />
        <hr style="background-color:darkgoldenrod; height:4px;" />
       <div style=" margin-top: 10px;">
        <form id="menu" runat="server">
        <asp:Panel ID="panelLogin" runat ="server">
            <div class="container-fluid">
                <div class="row" style="padding:5px;">
                    <div class="col-2"> </div>
                    <div class="col-6"  >
                        <table style="padding:5px;">
                            <tr >
                                <td style="width:20%;"></td>
                                <td><asp:Label ID="lbUsuario" CssClass="TextoEncabezado" ForeColor="Tan" runat="server"   Text="Usuario: "></asp:Label></td>
                                <td><asp:TextBox  CssClass="form-control" ID="tbUsuario" runat="server"  Width="200px"></asp:TextBox></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="width:20%;"></td>
                                <td><asp:Label ID="lbPassword" runat="server" CssClass="form-control-plaintext" ForeColor="Tan"  Text="Password: "></asp:Label></td>
                                <td><asp:TextBox ID="tbPassword" runat="server"  CssClass="form-control" TextMode="Password" Width="200px"></asp:TextBox></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="width:20%;"></td>
                                <td colspan="3">
                                     <asp:Button ID="btnLogin" runat="server"  CssClass="btn btn-outline-warning" Text="Login" OnClick="btnLogin_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%;"></td>
                                <td colspan="3">
                                   <asp:Label ID="LbError" runat="server" CssClass="text-danger" ></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-2"></div>
               </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="panelMenu" runat="server">
         <div class="container-fluid">
           <div class="row" style="padding:5px;">
                <div class="col-lg-4">
                    <asp:Label ID="lbTituloUsuario" runat="server" ForeColor="Tan" Font-Size="Large" Text="Usuario :"></asp:Label>
                </div>
                <div class="col-lg-4">
                     <asp:Label ID="lbTitulo" runat="server" ForeColor="Tan" Font-Size="Large" Text="Bienvenido al modulo de Administrador"></asp:Label>
                </div>
                  <div class="col-lg-4">
                 <asp:Label ID="lbFecha" runat="server" ForeColor="Tan" Font-Size="Large" Text="Fecha :"></asp:Label>
                </div>
            </div>
            <div class="row" style="padding:5px;">
                <div class="col-lg-4">
                    <asp:Button ID="btnPropiedades" runat="server" CssClass="btn btn-outline-warning btn-dark" Text="Propiedades" OnClick="btnPropiedades_Click" />
                </div>
                <div class="col-lg-4">
                    <asp:Button ID="btnConsultas" runat="server" CssClass="btn btn-outline-warning" Text="Consultas" OnClick="btnConsultas_Click" />
                </div>
                  <div class="col-lg-4">
                    <asp:Button ID="btnNoticias" runat="server" CssClass="btn btn-outline-warning" Text="Noticias y Notas" OnClick="btnNoticias_Click" />
                </div>
            </div>
             <div class="row" style="padding:5px;">
                <div class="col-lg-4">
                    <asp:Button ID="btnInquilinos" runat="server" CssClass="btn btn-outline-warning" Text="Inquilinos" OnClick="btnInquilinos_Click" />
                </div>
                <div class="col-lg-4">
                    <asp:Button ID="btnGaleria" runat="server" CssClass="btn btn-outline-warning" Text="Galeria de Fotos" OnClick="btnGaleria_Click" />
                </div>
                  <div class="col-lg-4">
                    <asp:Button ID="btnReservas" runat="server" CssClass="btn btn-outline-warning" Text="Reservas" OnClick="btnReservas_Click" />
                </div>
                 <div class="col-lg-4">
                     <asp:Button ID="btnReportes" runat="server" CssClass="btn btn-outline-warning" Text="Reportes" OnClick="btnReportes_Click" />
                 </div>
            </div>
         </div>
            <div class="row" style="padding:5px;">
                <div class="col-lg-12">
                    <asp:Button ID="btnCerrarSession" runat="server" CssClass="btn btn-outline-danger" Text="Cerrar Session" OnClick="btnCerrarSession_Click" Width="100%" />
               </div>
            </div>
        </asp:Panel>
   
        </form>
       </div>

    
 
</asp:Content>
