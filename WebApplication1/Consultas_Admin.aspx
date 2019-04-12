﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Consultas_Admin.aspx.cs" Inherits="WebApplication1.Consultas_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 449px;
        }
    </style>
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
            </div>
    </div>

     <div class="container-fluid">
         <div class="row">
                <div class="col">
                    <table style="width:100%;">
                        <tr>
                            <td><asp:Label Id="LbTipoConsulta" runat="server"  CssClass="TextoEncabezado" ForeColor="Tan" Text="Tipo de Consulta:" Width="200px"></asp:Label></td>
                            <td><asp:DropDownList Id="DdlTipoConsulta"  CssClass="rcorners1" runat="server" OnSelectedIndexChanged="DdlTipoConsulta_SelectedIndexChanged"  AutoPostBack="True">
                            
                                </asp:DropDownList></td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td><asp:Label Id="LbEstado" runat="server"  CssClass="TextoEncabezado"   Text=" Tipo de Consulta:" ForeColor="Tan" Width="200px"></asp:Label></td>
                            <td class="auto-style1"><asp:DropDownList Id="DdlEstado" CssClass="rcorners1"  runat="server" Width="200px" OnSelectedIndexChanged="DdlEstado_SelectedIndexChanged" AutoPostBack="True" >
                                <asp:ListItem Text="Activa" Value="Activa"></asp:ListItem>
                                <asp:ListItem Text="Respondida" Value="Respondida"></asp:ListItem>
                                <asp:ListItem Text="Anulada" Value ="Anulado"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                            <tr>
                                <td colspan="6">&nbsp:</td>
                            </tr>
                        <tr>
                            <td colspan="6">
                            <asp:GridView ID="GvConsultas" runat="server" CssClass="GridNegra"  AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" AllowPaging="True" OnPageIndexChanging="CambioPagina"  PageSize="5"   >
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="IdComentario"  ControlStyle-Width="8%"/>
                                    <asp:BoundField HeaderText="Nombre"  DataField="Nombre_Persona" ControlStyle-Width="10%"/>
                                    <asp:BoundField HeaderText="Telefono" DataField="Tel_Persona"  ControlStyle-Width="10%"/>
                                    <asp:BoundField HeaderText="Mail" DataField="Mail_Persona"  ControlStyle-Width="15%"/>
                                    <asp:BoundField HeaderText="Consulta"  DataField="Comentario" ControlStyle-Width="22%"/>
                                    <asp:BoundField HeaderText="Estado" DataField="Estado"  ControlStyle-Width="10%"/>
                                    <asp:CommandField EditText="Responder" ShowEditButton="True"  ControlStyle-Width="10%"/>
                                    <asp:CommandField DeleteText="Anular" ShowDeleteButton="True"  ControlStyle-Width="10%"/>
                                </Columns>
                               
                            </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
             </div>
      </div>    
     <div class="container-fluid">
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
