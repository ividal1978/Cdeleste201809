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
<div class=" col-lg-3 text-center TextoEncabezado"
        <span>Inquilino:</span>   
                <asp:TextBox ID="TbNombreCmb" runat="server" Width="250px" CssClass="rcorners0" />  
            <cc1:AutoCompleteExtender ID="TbNombreCmb_AutoCompleteExtender"
                runat="server" DelimiterCharacters="" Enabled="True" 
                ServicePath="" 
                TargetControlID="TbNombreCmb"
                ServiceMethod="Sugerencias"
                CompletionInterval="1000" 
                MinimumPrefixLength="3"
                CompletionListCssClass="list-group list-group-item-info " 
                CompletionListItemCssClass= "list-group list-group-item" 
                CompletionListHighlightedItemCssClass="list-group list-group-item-success"
                UseContextKey="True">
            </cc1:AutoCompleteExtender>  
            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    </div>
    <div class="col-lg-3"> <asp:Button ID="BtnNuevo" runat="server" CssClass="btn btn-dark" Text="Nuevo" /></div>
            </div>
        </form>
     
</div>
</asp:Content>
