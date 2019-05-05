<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Inquilinos_ABM.aspx.cs" Inherits="WebApplication1.Inquilinos_ABM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
        <div class="row">
            <div class="col-2">
                <asp:Label ID="LbFechaPagina" runat="server" ForeColor="Tan" Font-Size="Large" Text="Fecha:"></asp:Label>
            </div>
            <div class="col-8" style="text-align: center;">
                <asp:Label ID="LbTituloPagina" runat="server" ForeColor="Tan" Font-Size="X-Large" Text="Modulo Inquilinos"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Label ID="LbUsuario" runat="server" ForeColor="Tan" Font-Size="Large" Text="Usuario:"></asp:Label>
            </div>
        </div>
        <form id="formInquilinoABM" runat="server">
            <div class="row">
                <div class=" col-lg-3 text-right TextoEncabezado">
                    <p class="text-right" style="color: tan; font-size: large;">Inquilino:</p>
                </div>
                <div class="col-lg-4" style="text-align: left;">
                    <asp:TextBox ID="TbNombreCmb" runat="server" Width="250px" CssClass="rcorners0"  AutoPostBack="true"  OnTextChanged="TbNombreCmb_TextChanged"/>
                    <cc1:AutoCompleteExtender ID="TbNombreCmb_AutoCompleteExtender"
                        runat="server" DelimiterCharacters="" Enabled="True"
                        ServicePath=""
                        TargetControlID="TbNombreCmb"
                        ServiceMethod="Sugerencias"
                        CompletionInterval="1000"
                        MinimumPrefixLength="3"
                        CompletionListCssClass="list-group list-group-item-info "
                        CompletionListItemCssClass="list-group list-group-item"
                        CompletionListHighlightedItemCssClass="list-group list-group-item-success"
                        UseContextKey="True">
                    </cc1:AutoCompleteExtender>
                    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
                </div>
                <div class="col-lg-3" style="text-align: right;">
                    <asp:Button ID="BtnNuevo" runat="server" CssClass="btn btn-dark" Text="Nuevo" OnClick="BtnNuevo_Click" />
                </div>
            </div>
            <br />
            <asp:HiddenField ID="hdnIdInquilino" runat="server" />
            <asp:Panel ID="PnlDatosInquilino" runat="server">
                <div class="form-row" >
                    <div class="col-lg-6">
                        <label for="TbNombre"  style="color:tan;"><i class="fas fa-user-circle"></i> Nombre</label>
                        <asp:TextBox ID="TbNombre" runat="server" CssClass="form-control rcorners0" Width="90%" placeholder="Nombre"></asp:TextBox>
                    </div>

                    <div class="col-lg-6">
                        <label for="TbApellido" style="color:tan;">Apellido</label>
                        <asp:TextBox ID="TbApellido" runat="server" CssClass="form-control rcorners0" Width="90%" placeholder="Apellido"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="form-row">
                    <div class="col-lg-4">
                        <label for="TbTelefono" style="color:tan;"><i class="fas fa-phone"></i> Teléfono</label>
                        <asp:TextBox ID="TbTelefono" runat="server" CssClass="form-control rcorners0" Width="90%" placeholder="Teléfono" ToolTip=" Cod.Ciudad - Caract -Número"></asp:TextBox>
                    </div>

                    <div class="col-lg-4">
                        <label for="TbCelular" style="color:tan;"><i class="fas fa-mobile-alt"></i> Celular</label>
                        <asp:TextBox ID="TbCelular" runat="server" CssClass="form-control rcorners0" Width="90%" placeholder="Celular" ToolTip=" Cod.Ciudad - Caract -Número"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                         <label for="TbMail" style="color:tan;"><i class="far fa-envelope"></i> Email</label>
                        <asp:TextBox ID="TbMail" runat="server" CssClass="form-control rcorners0" Width="90%" placeholder="E-Mail"></asp:TextBox>
                    </div>
                </div>
                    <br />
                    <div class="form-row">
                        <div class="col-lg-4">
                            <label for="TbObs" style="color:tan;"><i class="fas fa-comment-alt"></i> Observaciones</label>
                            <asp:TextBox ID="TbObs" runat="server" CssClass="form-control rcorners0" Width="90%" placeholder="Observaciones" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="col-lg-4">
                            <label for="TbReside"style="color:tan;" ><i class="fas fa-map-marked-alt"></i> Reside en</label>
                            <asp:TextBox ID="TbReside" runat="server" CssClass="form-control rcorners0" Width="90%" placeholder="Reside en.."></asp:TextBox>
                        </div>
                       
                    </div>
                <br />
                <div  class="form-row">
                     <div class="col-lg-4 offset-lg-8" style="vertical-align:baseline;">
                          
                               <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-dark" Text="Guardar" Width="90%" OnClick="BtnGuardar_Click" />
                        </div>
                </div>
            </asp:Panel>
            <div class="row">
                <div class="col-lg-12 text-center">
                    <asp:Label ID="LbMsg" runat="server" CssClass="text-success " ></asp:Label>
                </div>
            </div>
        </form>

    </div>
</asp:Content>
