<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Consultas_Admin.aspx.cs" Inherits="WebApplication1.Consultas_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <link href="Css/CssCdeleste.css" rel="stylesheet" />
    <hr style="background-color:darkolivegreen; height:15px;" />
    <hr style="background-color:darkgoldenrod; height:4px;" />
    <form id="FormConsultas" runat="server">
     <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4"> <asp:Label ID="LbFecha" runat="server" CssClass="TextoEncabezado" ForeColor="Tan"></asp:Label>
                </div>
                <div class="col-lg-4" style="color:tan;">
                    Modulo de Cosultas
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="LbUsuario" runat="server" CssClass="TextoEncabezado" ForeColor="Tan" Text="Usuario:"></asp:Label>
                </div>
                <div class="col-lg-1">
                    <table style="width:100%;">
                        <tr>
                            <td><asp:Label Id="LbTipoConsulta" runat="server"  CssClass="TextoEncabezado" ForeColor="Tan" Text="Tipo de Consulta:" Width="200px"></asp:Label></td>
                            <td><asp:DropDownList Id="DdlTipoConsulta"  CssClass="rcorners1" runat="server" >
                            
                                </asp:DropDownList></td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td><asp:Label Id="LbEstado" runat="server"  CssClass="TextoEncabezado"   Text=" Tipo de Consulta:" ForeColor="Tan" Width="200px"></asp:Label></td>
                            <td><asp:DropDownList Id="DdlEstado" CssClass="rcorners1"  runat="server" Width="200px"  >
                                <asp:ListItem Text="Activa" Value="Ac"></asp:ListItem>
                                <asp:ListItem Text="Respondida" Value="Rs"></asp:ListItem>
                                <asp:ListItem Text="Anulada" Value ="An"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                        <tr>
                            <td colspan="5">
                            <asp:GridView ID="GvConsultas" runat="server" CssClass="rcorners1"  AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" />
                                    <asp:BoundField HeaderText="Nombre" />
                                    <asp:BoundField HeaderText="Telefono" />
                                    <asp:BoundField HeaderText="Mail" />
                                    <asp:BoundField HeaderText="Consulta" />
                                    <asp:BoundField HeaderText="Estado" />
                                    <asp:CommandField EditText="Responder" ShowEditButton="True" />
                                    <asp:CommandField DeleteText="Anular" ShowDeleteButton="True" />
                                </Columns>
                               
                            </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
         <div class="row">
             <div class="col-lg-6" style="vertical-align:central;text-align:center;">
                 <asp:Label ID="TituloConsulta" runat="server" CssClass="TextoEncabezado" ForeColor="Tan" Text="Consulta"></asp:Label><br />
                 <asp:TextBox ID="TbConsulta" CssClass="rcorners1" runat="server" TextMode="MultiLine" Width="80%"  Height="250px"></asp:TextBox>
             </div>
             <div class="col-lg-6"  style="vertical-align:central;text-align:center;">
                 <asp:Label ID="TituloRespuesta"  runat="server" CssClass="TextoEncabezado" ForeColor="Tan" Text="Respuesta"></asp:Label><br />
                 <asp:TextBox ID="TbRespuesta" CssClass="rcorners2" runat="server" TextMode="MultiLine" Width="80%" Height="250px"></asp:TextBox>
             </div>
         </div>
    </div>
   </form>
</asp:Content>
