<%@ Page Title="Cdeleste.com.ar :: Reservas" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Reserva_Cliente.aspx.cs" Inherits="WebApplication1.Reserva_Cliente" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reservas</title>
    <style type="text/css">
        .GridNegra {
        }

        .GridNegra {
        }

        .GridNegra {
        }

        .GridNegra {
        }

        .GridNegra {
        }

        .GridNegra {
            height: 162px;
        }

        .GridNegra {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <script src="Scripts/phone-mask.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/baguettebox.js/1.8.1/baguetteBox.min.css">
    <link rel="stylesheet" href="Scripts/gallery-grid.css">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Css/CssCdeleste.css" rel="stylesheet" />
    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <form id="Reservas_ClientesFrm" runat="server">
          <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
        <div class="container-fluid">
            <%-- Encabezado --%>
            <div class="row">
                <div class="row">
                    <div class="col-lg-12">
                        <hr style="background-color: darkolivegreen; height: 2px;" />
                        <br />
                    </div>
                </div>
            </div>
            <div class="row">
                <%--  Panel de busqueda--%>
                <div class="col-md-2" style="color: tan;">Propiedad: </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="DdlPropiedadAlquiler" runat="server" CssClass="rcorners0"></asp:DropDownList>
                </div>
                <div class="col-md-2" style="color: tan;">Fecha desde:</div>
                <div class="col-md-2">
                    <asp:TextBox ID="TbFechaAlquiler" runat="server" CssClass="rcorners0"></asp:TextBox>
                    <cc1:CalendarExtender ID="TbFechaAlquiler_CalendarExtender" runat="server" Enabled="True" TargetControlID="TbFechaAlquiler" CssClass=" btn-dark" TodaysDateFormat="dd MMMM, yyyy">
                    </cc1:CalendarExtender>
                    &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                    
                </div>
                <div class="col-md-4">
                <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-dark" Text="Buscar" OnClick="BtnBuscar_Click" />
                </div>
            </div>
            <div class="row text-center">
                <%--  Tabla de resultados --%>
                <div class="col-2">&nbsp;</div>
                <div class="col-10">
                    <br />
                    <div class="text-left">
                        <div class="col-lg-4 text-center">
                            <asp:TextBox ID="TbMes" runat="server" CssClass="rcorners0" BackColor="#FFFFD5" Enabled="false" Style="text-align: center;" Width="250px"></asp:TextBox></div>

                        <DayPilot:DayPilotScheduler ID="DayPilotCalendario" runat="server" CssClass="rcorners0 text-center" Height="179px"
                            DataStartField="FDesde"
                            DataEndField="FHasta"
                            DataTextField="Propiedad_Nombre"
                            DataIdField="IDPropiedad"
                            DataValueField="IDReserva"
                            DataResourceField="IDPropiedad"
                            CellGroupBy="Month"
                            Scale="Day"
                            CellDuration="1440"
                            Days="31"
                            EventMoveHandling="CallBack"
                            RowHeaderWidth="300" HeaderHeight="25" EventHeight="25"
                            OnEventMove="DayPilotScheduler1_EventMove"
                            OnEventClick="DayPilotCalendar1_EventClick"
                            FreeTimeClickJavaScript="alert('{0}, {1}');" EventClickHandling="PostBack"
                            EventFontSize="10">
                        </DayPilot:DayPilotScheduler>
                    </div>
                    <br />
                </div>
            </div>
            <hr style="background-color: darkolivegreen; height: 4px; border-bottom-color: darkgoldenrod; border-bottom-width: 2px;" />
            <br />
        </div>
        <asp:HiddenField ID="HdnPropiedad" runat="server" Value="" />
    </form>
</asp:Content>
