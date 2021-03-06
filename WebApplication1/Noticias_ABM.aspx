﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Noticias_ABM.aspx.cs" Inherits="WebApplication1.Noticias_ABM" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>

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
        <form id="Noticias" runat="server">
            <div class="row">
                <div class="col-lg-5">
                    <asp:Label ID="lbTituloDescripcion" runat="server" ForeColor="Tan" Text="Tipo de Noticias:" Font-Size="Large"></asp:Label>
                    <asp:DropDownList ID="ddlTipoNoticia" runat="server" CssClass="btn btn-warning dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoNoticia_SelectedIndexChanged">
                        <asp:ListItem Text="Noticia" Value="NOTI" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Portada" Value="PORT"></asp:ListItem>
                        <asp:ListItem Text="Lugares" Value="LUGA"></asp:ListItem>
                        <asp:ListItem Text="Emergencia" Value ="EMER"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <div class="rcorners1">
                        <asp:DataGrid ID="dgNoticias" CssClass="GridNegra" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnEditCommand="Carga1Noticia" OnPageIndexChanged="dgNoticias_PageIndexChanged" OnDeleteCommand="dgNoticias_DeleteCommand" AHeaderStyle-BackColor="#003300" HeaderStyle-ForeColor="#99CC00" HeaderStyle-CssClass="rounded-0">
                            <Columns>
                                <asp:BoundColumn DataField="IdNoticia" HeaderText="Id"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Noticia" HeaderText="Noticia"></asp:BoundColumn>
                                <asp:BoundColumn DataField="RutaImagen" HeaderText="Imagen"></asp:BoundColumn>
                                <asp:EditCommandColumn CancelText="Cancelar" EditText="Editar" UpdateText="Guardar"></asp:EditCommandColumn>

                            </Columns>

                        </asp:DataGrid>
                    </div>
                </div>
                <div class="col-lg-7">
                    <br />
                    <br />
                    <br />
                    <table class="table">
                        <tr>
                            <td>
                                <asp:Label ID="lbId" runat="server" ForeColor="Tan" Font-Size="Large"></asp:Label></td>
                            <td colspan="2">
                                <asp:Label ID="lbFecha" runat="server" ForeColor="Tan" Font-Size="Large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbNoticia" runat="server" ForeColor="Tan" Font-Size="Large" Text="Noticia:"></asp:Label>
                            </td>
                            <td colspan="2">
                                <%--<asp:TextBox ID="tbNoticia" runat="server"  TextMode="MultiLine" ToolTip=" Las noticias no debe tener mas de 200 caracteres"></asp:TextBox>--%>

                                <cc1:Editor ID="tbNoticia" runat="server" Height="500px" Width="100%" CssClass="rcorners0"  BackColor="Wheat" />

                            </td>
                        </tr><tr> 
                            <td>
                                <asp:Image ID="img" runat="server" CssClass="rcorners0" Width="100px" Height="100px" />
                            </td>
                            <td colspan="2">
                                <asp:FileUpload ID="fupdate" runat="server" CssClass="rounded" BackColor="Tan" />
                            </td>
                          
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-outline-warning" Text="Nuevo" OnClick="btnNuevo_Click" />
                            </td>
                            <td  >
                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-outline-warning" Text="Guardar" OnClick="btnGuardar_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-outline-danger" Text ="Borrar" OnClick="btnBorrar_Click"/>
                            </td>
                        </tr>
                        <tr>
                            
                            <td  colspan="2">
                                    <p style="font-family: 'Trebuchet MS'; color: antiquewhite; font-size: medium;"> * Comprima las imagenes en sitios como www.tinyjpg.com  <br /> 
                                    * Las noticias no deben tener mas de 200 caracteres. <br /> 
                                    * El editor es html, y soporta hasta 800 caractéres. (recuerde que los estilos, subrayados y otro&nbsp; decorado adicional, bajan estala cantidad de caractéres disponibles) <br />
                                    * Para ver la el código generado presione el boton [<>] al final del editor.
                                </p>
  
                                <p style=" font-famiy:'Trebuchet MS'; color: antiquewhite; font-size:medium;"> 
                                    Referencias:<br />
                                    <table>
                                        <tr>
                                            <td>tipo Nota:</td>
                                            <td> Ancho</td>
                                            <td>Alto</td>
                                            <td>Peso</td>
                                        </tr>
                                        <tr>
                                            <td>Noticia</td>
                                            <td>150px</td>
                                            <td>150px</td>
                                            <td>100Kb</td>
                                        </tr>
                                        <tr>
                                            <td>Portada</td>
                                            <td>500px</td>
                                            <td>500px</td>
                                            <td> 400Kb</td>
                                        </tr>
                                        <tr>
                                            <td>Lugares</td>
                                            <td>800px</td>
                                            <td>600px</td>
                                            <td>500Kb</td>
                                        </tr>
                                        <tr>
                                            <td>Emergencias</td>
                                            <td>150px</td>
                                            <td>150px</td>
                                            <td>100Kb</td>
                                        </tr>
                                    </table>

                                </p>
                            </td>
                        </tr>
                        

                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbError" runat="server" CssClass="text-danger text-center"></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>
            <cc2:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc2:ToolkitScriptManager>
            <asp:HiddenField ID="hdnImageSelected" runat="server" />

        </form>
    </div>
</asp:Content>
