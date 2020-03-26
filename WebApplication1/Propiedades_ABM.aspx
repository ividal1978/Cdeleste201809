<%@ Page Title="Gestor de Propiedades" MaintainScrollPositionOnPostback="true"  Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Propiedades_ABM.aspx.cs" Inherits="WebApplication1.Propiedades_ABM"  %>

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
                    <asp:GridView ID="gvPropiedades" runat="server" CssClass="table table-light table-hover rcorners0 "  BackColor="Black" style="opacity:.55;" BorderStyle="None"  runat="server" AutoGenerateColumns="False" AllowPaging="True" GridLines="None" EnableModelValidation="True" OnRowEditing="gvPropiedades_RowEditing"  ForeColor="Tan">
                      
                        <Columns>
                            <asp:BoundField  DataField="IdPropiedades" HeaderText="Id"/>
                            <asp:BoundField  DataField="Nombre" HeaderText="Propiedad"/>
                            <asp:BoundField  DataField="Plazas" HeaderText="Pax"/>
                            <asp:BoundField  DataField="Direccion" HeaderText="Direccion"/>
                            <asp:CommandField ShowEditButton="True"  EditText="Editar">

                            </asp:CommandField>
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
            <div Id="DivConfort" class="row" runat="server">
                <div class="col-lg-6">
                    <asp:GridView runat="server" Id="GvConfort"  CssClass="table table-light table-hover rcorners0 "  BackColor="Tan" AutoGenerateColumns="False" EnableModelValidation="True" OnRowEditing="GvConfort_RowEditing" OnRowDeleting="GvConfort_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="IdConfort" HeaderText="Id" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:CommandField ShowEditButton="True" EditText="Editar" ItemStyle-ForeColor="#660033" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Borrar" ItemStyle-ForeColor="#660033"/>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-lg-6" id="Confort">
                    <table style="width:98%;">
                        <tr>
                            <td><asp:Label ID="LbIDConfortTexto" runat="server"  ForeColor="Tan" Text="ID:"></asp:Label></td>
                            <td><asp:Label ID="LbIdConfort" runat="server" ForeColor="Tan"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="LbDescConfortText" runat="server" ForeColor="Tan" Text="Descripción:"></asp:Label></td>
                            <td ><asp:TextBox ID="TbDescripcionConfort" runat="server" CssClass="rcorners0" Width="98%" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Button ID="BntGuardarConfort" runat="server" CssClass="btn btn-outline-warning" Text="Guardar" OnClick="BntGuardarConfort_Click" /></td>
                            <td style="text-align:right;"><asp:Button ID="BtnNuevoConfort" runat="server" CssClass="btn btn-outline-warning" Text="Nuevo" OnClick="BtnNuevoConfort_Click"  ToolTip="Para Grabar el nuevo item de Confort Presione GUARDAR"/></td>
                        </tr>
                    </table>
                </div>
            </div>
                <p class="alert-warning"> Nota: Para que las imágenes sean lo mas livianas y de calidad, antes de subirlas optimice las mismas en : www.https://tinyjpg.com/ o https://imagecompressor.com/</p>
              </br>
            <div id="DivImagenes" class="row" runat="server">
                <div class="col-lg-6" id="Imagenes">
                   
                    
                    <table>
                        <tr>
                            <td><asp:ImageButton ID="BtnImg1" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg1_Click" Width="200px" Height="200px" ToolTip="Imégen 1" /></td>
                            <td><asp:ImageButton ID="BtnImg2" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg2_Click" Width="200px" Height="200px" ToolTip="Imégen 2"/></td>
                            <td><asp:ImageButton ID="BtnImg3" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg3_Click" Width="200px" Height="200px" ToolTip="Imégen 3"/></td>
                        </tr>                                                                                                          
                        <tr>                                                                      
                            <td><asp:ImageButton ID="BtnImg4" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg4_Click" Width="200px" Height="200px" ToolTip="Imágen 4"/></td>
                            <td><asp:ImageButton ID="BtnImg5" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg5_Click" Width="200px" Height="200px" ToolTip="Imágen 5"/></td>
                            <td><asp:ImageButton ID="BtnImg6" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg6_Click" Width="200px" Height="200px" ToolTip="Imágen 6"/></td>
                        </tr>                                                                                                             
                        <tr>           
                            </br>
                            <td><asp:ImageButton ID="BtnImg7" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg7_Click" Width="200px" Height="200px" ToolTip="Imágen 7"/></td>
                            <td><asp:ImageButton ID="BtnImg8" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg8_Click" Width="200px" Height="200px" ToolTip="Imágen 8"/></td>
                            <td><asp:ImageButton ID="BtnImg9" runat="server" CssClass="BotonImagen rcorners1" OnClick="BtnImg9_Click" Width="200px" Height="200px" ToolTip="Imágen 9"/></td>
                        </tr>                                                                                                                     
                    </table>
                </div>
                <div class="col-lg-6">
                     <div Class="alert-info rcorners1" style="text-align:center;">
                        <asp:Label ID="LbImagenesDesc" runat="server"   Text=" Para cambiar una imagen, seleccionar  la imagen a subir  por el control Browse. </br> Luego , presionar la imágen que desea cambiar." ></asp:Label>
                    </div>
                    </br>
                    <asp:FileUpload ID="FUpload" runat="server" class="btn btn-outline-warning"/> </br>
                   </br>
                    <div class=" rcorners0 alert-danger  alert-primary" style="text-align:center;">
                        <asp:Label ID="LbError" runat="server"  ></asp:Label>
                    </div>
                </div>
            </div>
            </form>
        </div>
</asp:Content>
