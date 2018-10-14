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
            <form id="Propiedadesfrom" runat="server">
            <div class="row">
                <div class="col-6-lg">
                    <asp:GridView ID="gvPropiedades" runat="server" CssClass="table table-light table-hover rcorners0 "  BackColor="Tan" BorderStyle="None"  runat="server" AutoGenerateColumns="False" AllowPaging="True" GridLines="None" ></asp:GridView>
                </div>
                <div class="col-6-lg"></div>
            </div>
            </form>
        </div>
</asp:Content>
