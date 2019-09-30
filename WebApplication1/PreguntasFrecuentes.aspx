<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="PreguntasFrecuentes.aspx.cs" Inherits="WebApplication1.PreguntasFrecuentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <form id="FormRespuestas" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-6">
                    <div class="col-xl-6 align-content-center">
                        <div style="align-content:center; align-items:center;" class=" rcorners0" >
                            <div id="dvAccordian" class="panel-group  rcorners0" style="width: 90%; opacity:0.8;">
                                <asp:Repeater ID="rptAccordion" runat="server" >
                                    <ItemTemplate>
                                        <div class="panel panel-default ">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#dvAccordian"
                                                        href="#collapse<%# Container.ItemIndex %>">
                                                        <%# Eval("Comentario") %></h4>
                                                </a> </h4>
                                            </div>
                                            <div id="collapse<%# Container.ItemIndex %>" class="panel-collapse collapse" aria-expanded="false">
                                                <div class="panel-body">
                                                    <p>
                                                        <%# Eval("Respuesta") %>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div>
                                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
                                <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
                                <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xl-1"></div>
                <div class="col-xl-6">
                    <asp:Label ID="LbError"  runat="server" CssClass="alert-danger rcorners0"></asp:Label>
                        </div>
                <div class="col-xl-1"></div>
            </div>
        </div>
    </form>
</asp:Content>
