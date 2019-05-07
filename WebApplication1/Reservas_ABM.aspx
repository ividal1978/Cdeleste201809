<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Reservas_ABM.aspx.cs" Inherits="WebApplication1.Reservas_ABM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reservas Admin</title>
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
    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <form id="FromReservasABM" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="LbFecha" runat="server" CssClass="TextoEncabezado" ForeColor="Tan"></asp:Label>
                </div>
                <div class="col-lg-4" style="color: tan;">
                    Modulo de Reservas
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="LbUsuario" runat="server" CssClass="TextoEncabezado" ForeColor="Tan" Text="Usuario:"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <hr style="background-color: darkolivegreen; height: 2px;" />
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <div class="form-row">
                    <div class="col-2" style="color:tan;" >Fecha Desde:</div>
                    <div class="col-4">
                        <asp:TextBox ID="TbFechaDesde" runat="server" CssClass="rcorners0"></asp:TextBox>
                        <cc1:CalendarExtender ID="TbFechaDesde_CalendarExtender" runat="server" Enabled="True" TargetControlID="TbFechaDesde" CssClass="rcorners0 GridNegra">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="col-2" style="color: tan;">Fecha Hasta:</div>
                    <div class="col-4">
                        <asp:TextBox ID="TbFechaHasta" runat="server" CssClass="rcorners0"></asp:TextBox>
                        <cc1:CalendarExtender ID="TbFechaHasta_CalendarExtener" runat="server" Enabled="True" TargetControlID="TbFechaHasta" CssClass="rcorners0 GridNegra">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <br />
                <div class="form-row">
                    <div class="col-2" style="color:tan;">Propiedad:</div>
                    <div class="col-4" >
                        <asp:DropDownList ID="DdlPropiedad" runat="server" CssClass="rcorners0" ></asp:DropDownList>
                    </div>
                    <div class="col-2" style="color:tan;">Inquilino:</div>
                    <div class= "input-group col-4">
                        <input type="text" class="form-control rcorners0" placeholder="Inquilino" aria-label="Inquilino" aria-describedby="BtnNuevo">
                        <div class="input-group-append">
                        <asp:Button ID="BtnNuevo" runat="server" class="btn btn-outline-warning rcorners0" Text ="Nuevo" OnClick="BtnNuevo_Click" />
                        </div>
                    </div>

                </div>
                <br />
                <div class="form-row">
                    <div class="col-2" style="color:tan;" >Monto Total:</div>
                    <div class="col-4">
                        <asp:TextBox ID="TbMontoTotal" runat="server" CssClass="rcorners0"></asp:TextBox>
                    </div>
                    <div  class="col-2" style="color:tan;"> Monto Reserva:</div>
                    <div class="col-4" >
                        <asp:TextBox ID="TbMontoReserva" runat="server" CssClass="rcorners0"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-lg-2"></div>
        </div>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    </form>
</asp:Content>
