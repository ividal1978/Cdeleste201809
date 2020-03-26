<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Galeria_ABM.aspx.cs" Inherits="WebApplication1.Galeria_ABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <link href="Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <div class="container-fluid" style="margin-top: 10px;">
        <form id="formGaleriaABM" runat="server">
            <div class="row">
                <div class="col-2">
                    <asp:Label ID="LbFechaPagina" runat="server" ForeColor="Tan" Font-Size="Large" Text="Fecha:"></asp:Label>
                </div>
                <div class="col-8" style="text-align: center;">
                    <asp:Label ID="LbTituloPagina" runat="server" ForeColor="Tan" Font-Size="X-Large" Text="Modulo Galeria"></asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="LbUsuario" runat="server" ForeColor="Tan" Font-Size="Large" Text="Usuario:"></asp:Label>
                </div>
            </div>
    

         <table>
        <tr>
            <td style="width: 65%;">Imagenes
            </td>
            <td style="width: 30%;">
                <table style="width: 100%;">
                    <tr>
                        <td style="color:tan;" colspan="2">Id:
                            <asp:Label ID="lbId" runat="server" Style="color: tan;"></asp:Label>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Image runat="server" ID="img" Width="100%" Height="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td style="color: tan;">Archivo:
                        </td>
                        <td>
                            <asp:FileUpload ID="fUpload" runat="server"  CssClass=" rcorners0" Width="100%"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="color: tan;">Nombre:</td>
                        <td>
                            <asp:TextBox ID="tbNombre" runat="server" CssClass="rcorners0" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="color: tan;">Comentario:</td>
                        <td>
                            <asp:TextBox ID="tbComentario" runat="server" CssClass="rcorners0" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-outline-warning" Text="Guardar" /></td>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" Text="Borrar"  CssClass="btn btn-outline-danger"/></td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
         </form> 
    </div>
</asp:Content>
