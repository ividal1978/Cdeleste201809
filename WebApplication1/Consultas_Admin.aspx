<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Consultas_Admin.aspx.cs" Inherits="WebApplication1.Consultas_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Consultas Admin</title>
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
                                <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                                <asp:ListItem Text="Respondida" Value="Respondida"></asp:ListItem>
                                <asp:ListItem Text="Anulada" Value ="Anulado"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                            <tr>
                                <td colspan="6">&nbsp:</td>
                            </tr>
                        <tr>
                            <td colspan="6">
                            <asp:GridView ID="GvConsultas" runat="server" CssClass="GridNegra"  AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" AllowPaging="True" OnPageIndexChanging="CambioPagina"  PageSize="5"  OnRowDeleting="VerConsulta" >
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="IdComentario"  ControlStyle-Width="8%"/>
                                    <asp:BoundField HeaderText="Nombre"  DataField="Nombre_Persona" ControlStyle-Width="10%"/>
                                    <asp:BoundField HeaderText="Telefono" DataField="Tel_Persona"  ControlStyle-Width="10%"/>
                                    <asp:BoundField HeaderText="Mail" DataField="Mail_Persona"  ControlStyle-Width="15%"/>
                                    <asp:BoundField HeaderText="Consulta"  DataField="Comentario" ControlStyle-Width="22%"/>
                                    <asp:BoundField HeaderText="Estado" DataField="Estado"  ControlStyle-Width="10%"/>
                                    <asp:CommandField DeleteText="Ver" ShowDeleteButton="True"  ControlStyle-Width="10%" ItemStyle-HorizontalAlign="Center"/>
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
                 <div>
                 <asp:Label ID="LbNombreConsulta" runat="server"  CssClass="text-center"  ForeColor="Tan" ToolTip="Nombre y Apellido" Text="Nombre y Apellido"></asp:Label> &nbsp;
                 <asp:Label ID="LbTelefonoConsulta" runat="server" CssClass="text-center" ForeColor="Tan" ToolTip="Teléfono" Text=" 12345+-55"></asp:Label>&nbsp;
                 <asp:Label ID ="LbMailConsulta" runat="server" CssClass="text-center" ForeColor="Tan" ToolTip="E-Mail" Text="nada@tss.com"></asp:Label>&nbsp; 
                 <asp:Label ID ="LbFechaConsulta" runat="server" CssClass="text-center" ForeColor="Tan" ToolTip="Fecha de Alta" text="2019-04-19"></asp:Label>&nbsp;
                 <asp:Label ID="LbPropiedadConsulta" runat="server" CssClass="text-center" ForeColor="Tan" ToolTip="Propiedad"></asp:Label>
              
                 </div>
                 <asp:TextBox ID="TbConsulta" CssClass="rcorners1" runat="server" TextMode="MultiLine" Width="80%"  Height="250px"></asp:TextBox>
             </div>
             <div class="col-lg-6"  style="vertical-align:central;text-align:center;">
                 <asp:Label ID="TituloRespuesta"  runat="server" CssClass="TextoEncabezado" ForeColor="Tan" Text="Respuesta"></asp:Label><br />
                 <asp:Label ID="LbFechaRespuesta" runat="server" CssClass="text-center" ForeColor="Tan" ToolTip="Fecha de Respuesta"></asp:Label><br />
                 <asp:TextBox ID="TbRespuesta" CssClass="rcorners2" runat="server" TextMode="MultiLine" Width="80%" Height="250px"></asp:TextBox> <br />
                 <asp:Button ID="BtnResponder" runat="server" CssClass="btn btn-outline-warning" Text="Responder" OnClick="BtnResponder_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:CheckBox ID="ChkEnviarmail" runat="server" CssClass="input-group-addon btn-outline-warning btn" Text="  Enviar mail con respuesta" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:RadioButtonList ID="RblCambiaPRegunta" runat="server" CssClass="input-group-addon btn-outline-warning btn"    RepeatDirection="Horizontal" ToolTip="Seleecionando aqui puede cambiar el tipo de consulta"> 
                   <asp:ListItem Text="Original" Value="XX" Selected="True" ></asp:ListItem>
                   <asp:ListItem Text="Pregunta Frecuente" Value="PF"></asp:ListItem>
                   <asp:ListItem Text="Pregunta Privada" Value="PP"></asp:ListItem>
               </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="BtnAnular" runat="server" CssClass="btn btn-outline-warning" Text="Anular" OnClick="BtnAnular_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
             </div>
         </div>
         <asp:Label ID="LbMensaje" runat="server" CssClass="text-info text-center "  Font-Size="Large"></asp:Label>
        <asp:HiddenField ID="HdnIdComentario" runat="server"  />           
                 
   </div>   
   </form>
</asp:Content>
