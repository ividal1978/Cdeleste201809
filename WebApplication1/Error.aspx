<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebApplication1.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Imagenes/pino-animado-png-1.ico"  rel="icon"/>
            <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <div class="container-fluid">
        <div style="padding-top:45px;">
          <hr style="background-color:darkolivegreen; height:15px; " />
          <hr style="background-color:darkgoldenrod; height:4px;" />
         </div>
        <h1 class="Titulo" >Ha ocurrido un Error</h1>
        <div class="row">
            <div class="col-12  rounded">
                <asp:Label ID="lbRazones" runat="server" CssClass="btn btn-danger" Font-Size="X-Large" Text="Hemos detectado un Error. A la brevedad sera informado y solucionado por nuestro equipo de desarrollo <br /> Disculpe las molestias ocasionadas. <br/><font color='Green'><i class='fas fa-tree' style='color: forestgreen; '></i> www.CdelEste.com.ar</font>"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
