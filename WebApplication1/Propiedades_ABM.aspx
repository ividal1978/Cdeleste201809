<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Propiedades_ABM.aspx.cs" Inherits="WebApplication1.Propiedades_ABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
             <link href="Imagenes/pino-animado-png-1.ico"  rel="icon"/>
            <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
       <div style="padding-top:35px;">
         
        <hr style="background-color:darkolivegreen; height:15px; " />
        <hr style="background-color:darkgoldenrod; height:4px;" />
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-2">
                    <asp:Label ID="lbFechaPagina" runat="server" Forecolor="Tan" Font-Size="Large" Text="Fecha:"></asp:Label>
                </div>
                <div class="col-8" style="text-align:center;">
                    <asp:Label ID="lbTituloPagina" runat="server" ForeColor="Tan" Font-Size="X-Large" Text="Modulo de Propiedades"></asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="lbUsuario" runat="server" ForeColor="Tan" Font-Size="Large" Text="Usuario:"></asp:Label>
                </div>
           </div>
            <form id="Propiedadesfrom" runat="server">
            <div class="row">
                <div class="col-lg-6">
                    <asp:GridView ID="gvPropiedades" runat="server" CssClass="table table-light table-hover rcorners0 "  BackColor="Tan" BorderStyle="None"  runat="server" AutoGenerateColumns="False" AllowPaging="True" GridLines="None" EnableModelValidation="True" OnRowEditing="gvPropiedades_RowEditing" >
                        <AlternatingRowStyle BackColor="#996633" ForeColor="White" />
                        <Columns>
                            <asp:BoundField  DataField="IdPropiedades" HeaderText="Id"/>
                            <asp:BoundField  DataField="Nombre" HeaderText="Propiedad"/>
                            <asp:BoundField  DataField="Plazas" HeaderText="Pax"/>
                            <asp:BoundField  DataField="Direccion" HeaderText="Direccion"/>
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-lg-6" >
                    <table class="table table-borderless" style="color:blanchedalmond;margin-top:0px; border-top:0px;">
                        <tr>
                            <td ><asp:Label ID="IdTitulo" runat="server" Text="IdPropiedad : " ></asp:Label></td>
                            <td><asp:Label ID="lbId" runat="server"></asp:Label></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="LbPropiedad" runat="server"  Text="Propiedad:"></asp:Label></td>
                            <td><asp:TextBox ID="TbPropiedad" runat="server" CssClass="rcorners0" Width="98%"></asp:TextBox></td>
                            <td><asp:Label ID="lbPax" runat="server" Text="Pax: "></asp:Label></td>
                            <td><asp:TextBox Id="TbPax" runat="server" CssClass="rcorners0" Width="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="LbDireccion" runat="server" Text="Direccion: "></asp:Label></td>
                            <td colspan="3"><asp:TextBox ID="TbDireccion" runat="server"  CssClass="rcorners0" Width="98%"></asp:TextBox></td>
                           
                        </tr>
                         <tr>
                            <td><asp:Label ID="lbIntro" runat="server" Text="Introduccion: "></asp:Label></td>
                            <td colspan="3"><asp:TextBox ID="TbIntro" runat="server"  Width="98%" TextMode="MultiLine" MaxLength="299"  CssClass="rcorners0" Height="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-outline-warning" Text="Guardar" /></td>
                            <td><input type="button" value="Confort" onClick="document.getElementById('Confort').scrollIntoView();"  class="btn btn-outline-warning" title="Confort" ></td>
                            <td><input type="button" value="Imagenes" onClick="document.getElementById('Imagenes').scrollIntoView();"  class="btn btn-outline-warning" title="Imagnes" ></td>
                        </tr>
                    </table>

                </div>
            </div>
            <div Id="Confort" class="row">
                <div class="col-lg-6">
                    <asp:GridView runat="server" Id="GvConfort"  CssClass="table table-light table-hover rcorners0 "  BackColor="Tan" AutoGenerateColumns="False" EnableModelValidation="True" OnRowEditing="GvConfort_RowEditing">
                        <Columns>
                            <asp:BoundField DataField="IdConfort" HeaderText="Id" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-lg-6">
                    <table>
                        <tr>
                            <td><asp:Label ID="LbIDConfortTexto" runat="server"  ForeColor="Tan" Text="ID:"></asp:Label></td>
                            <td><asp:Label ID="LbIdConfort" runat="server" ForeColor="Tan"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="LbDescConfortText" runat="server" ForeColor="Tan" Text="Descripción:"></asp:Label></td>
                            <td><asp:TextBox ID="TbDescripcionConfort" runat="server" CssClass="rcorners0" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="align-items:center; text-align:center;"><asp:Button ID="BntGuardarConfort" runat="server" CssClass="btn btn-outline-warning" Text="Guardar" /></td>
                            <td style="align-items:center; text-align:center;"><asp:Button ID="BtnNuevoConfort" runat="server" CssClass="btn btn-outline-warning" Text="Nuevo" OnClick="BtnNuevoConfort_Click" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="Imagenes" class="row">
                <div class="col-lg-6"></div>
                <div class="col-lg-6"></div>
            </div>
            </form>
        </div>
</asp:Content>
