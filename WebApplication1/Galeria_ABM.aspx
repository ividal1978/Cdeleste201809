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
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
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
                    <td style="width: 65%;">

                        <div class="row" style="top: 100px;">

                            <asp:Repeater ID="rptImages" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-3 col-md-4 col-xs-6 thumb">
                                        <asp:ImageButton runat="server" Width="90%" Height="90%" ID="btnImg" ImageUrl='<%#"~/Imagenes/Galeria/" + DataBinder.Eval(Container.DataItem, "ruta")%>'
                                            OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' />
                                        <a style="color: antiquewhite; text-shadow: 2px 2px 5px black;"><%# DataBinder.Eval(Container.DataItem, "reseña") %> </a>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>

                    </td>
                    <td style="width: 30%; vertical-align: top;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="color: tan;" colspan="3">Id:
                            <asp:Label ID="lbId" runat="server" Style="color: tan;"></asp:Label>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Image runat="server" ID="img" Width="200px" Height="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="color: tan;">Archivo:
                                </td>
                                <td colspan="2">
                                    <asp:FileUpload ID="fUpload" runat="server" CssClass=" rcorners0" Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td style="color: tan;">Nombre:</td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbNombre" runat="server" CssClass="rcorners0" Width="100%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="color: tan;">Comentario:</td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbComentario" runat="server" CssClass="rcorners0" Width="100%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="LbError" runat="server" CssClass=" alert-danger"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-outline-primary" Text="Limpiar" OnClick="btnLimpiar_Click" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-outline-warning" Text="Guardar" OnClick="btnSave_Click" /></td>
                                <td>
                                    <asp:Button ID="btnDelete" runat="server" Text="Borrar" CssClass="btn btn-outline-danger" OnClick="btnDelete_Click" /></td>
                            </tr>
                        </table>
                      
                   <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                    data-toggle="modal" data-target="#modalSobreescribir">
                    Launch demo modal</button>
                </tr>
            </table>
            <asp:HiddenField ID="hdnSelectedRuta" runat="server" Value="" />

            <!-- Modal -->
            <div class="modal fade" id="modalSobreescribir" tabindex="-1" role="dialog" aria-labelledby="modalSobreescribir" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            El Archivo ya existe, ¿ desea sobre escribirlo ?
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="btnSobreEscribir" runat="server" CssClass="btn btn-outline-warning" Text="Sobre Escibir" OnClick ="btnSobreEscribir_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
