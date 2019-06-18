<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Reservas_ABM.aspx.cs" Inherits="WebApplication1.Reservas_ABM" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reservas Admin</title>
    <style type="text/css">
        .GridNegra {}
        .GridNegra {}
        .GridNegra {}
        .GridNegra {}
        .GridNegra {}
        .GridNegra {
            height: 162px;
        }
        .GridNegra {}
    </style>
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
          <%--  Panel de busqueda--%>
            <div  class="col-2" style="color:tan;">Propiedad: </div>
            <div class="col-2">
                <asp:DropDownList  ID="DdlPropiedadAlquiler" runat="server" CssClass="rcorners0" >        </asp:DropDownList>
            </div>
            <div class="col-2" style="color:tan;" >Fecha desde:</div>
            <div class="col-2">
                <asp:TextBox ID="TbFechaAlquiler" runat="server" CssClass="rcorners0"></asp:TextBox>
                <cc1:CalendarExtender ID="TbFechaAlquiler_CalendarExtender" runat="server" Enabled="True" TargetControlID="TbFechaAlquiler" CssClass="btn-dark">
                </cc1:CalendarExtender>
            </div>
            <div class="col-4">
                <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-dark" Text="Buscar" OnClick="BtnBuscar_Click" />
            </div>
        </div>
   
        <div class="row text-center" >
            <%--  Tabla de resultados --%>
            <div class="col-2">&nbsp;</div>
            <div class="col-10"> <br />
                <div class="text-left">
                <div class="col-4 text-center"><asp:TextBox ID="TbMes" runat="server" CssClass="rcorners0"  BackColor="#FFFFD5" Enabled="false" style="text-align:center;"  Width="250px"></asp:TextBox></div>

                <DayPilot:DayPilotScheduler ID="DayPilotCalendario" runat="server"  CssClass="rcorners0 text-center" Height="179px"  
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
                    OnEventMove="DayPilotScheduler1_EventMove"  RowHeaderWidth="300" HeaderHeight="25"  EventHeight="25">
   
                 </DayPilot:DayPilotScheduler>
                </div>
                <br />
            <asp:GridView ID="GvReservas" runat="server" CssClass=" GridNegra rcorners0" AutoGenerateColumns="False" EnableModelValidation="True"  OnPageIndexChanging="CambioPagina"   OnRowDeleting="VerReserva" AllowPaging="true">
                <Columns>
                    <asp:BoundField DataField="IdReserva" HeaderText="Id" />
                    <asp:BoundField DataField="Propiedad_Nombre" HeaderText="Propiedad" />
                    <asp:BoundField DataField="Inquilino_Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Inquilino_Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="FDesde" HeaderText="Desde" />
                    <asp:BoundField DataField ="FHasta" HeaderText ="Hasta" />
                    <asp:BoundField DataField ="Estado" HeaderText=" Estado" />
                    <asp:CommandField DeleteText="Ver" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
       </div>
      <hr style="background-color:darkolivegreen; height: 4px; border-bottom-color:darkgoldenrod;border-bottom-width:2px;" />
        <br />
        <asp:Panel ID="PnlDatos" runat="server">
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-8">
                    <div class="form-row">
                        <div class="col-2" style="color: tan;">Fecha Desde:</div>
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
                        <div class="col-2" style="color: tan;">Propiedad:</div>
                        <div class="col-4">
                            <asp:DropDownList ID="DdlPropiedad" runat="server" CssClass="rcorners0"></asp:DropDownList>
                        </div>
                        <div class="col-2" style="color: tan;">Inquilino:</div>
                        <div class="input-group col-4">
                            <asp:TextBox ID="TbInquilino" runat="server" class="form-control rcorners0" placeholder="Inquilino" aria-label="Inquilino" aria-describedby="BtnNuevo"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="TbNombreCmb_AutoCompleteExtender"
                        runat="server" DelimiterCharacters="" Enabled="True"
                        ServicePath=""
                        TargetControlID="TbInquilino"
                        ServiceMethod="Sugerencias"
                        CompletionInterval="1000"
                        MinimumPrefixLength="3"
                        CompletionListCssClass="list-group list-group-item-info "
                        CompletionListItemCssClass="list-group list-group-item"
                        CompletionListHighlightedItemCssClass="list-group list-group-item-success"
                        UseContextKey="True">
                    </cc1:AutoCompleteExtender>
                            <div class="input-group-append">
                                <asp:Button ID="BtnNuevo" runat="server" class="btn btn-outline-warning rcorners0" Text="Nuevo" OnClick="BtnNuevo_Click" />
                            </div>
                        </div>

                    </div>
                    <br />
                    <div class="form-row">
                        <div class="col-2" style="color: tan;">Monto Total:</div>
                        <div class="col-4">
                            <asp:TextBox ID="TbMontoTotal" runat="server" CssClass="rcorners0"></asp:TextBox>
                        </div>
                        <div class="col-2" style="color: tan;">Monto Reserva:</div>
                        <div class="col-4">
                            <asp:TextBox ID="TbMontoReserva" runat="server" CssClass="rcorners0"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="col-2" style="color: tan;">Pago:</div>
                        <div class="col-4">
                            <asp:RadioButtonList ID="RblPago" runat="server" CssClass="form-check-input" RepeatDirection="Horizontal" ForeColor="Tan">
                                <asp:ListItem Text=" Si " Value="S">&nbsp;&nbsp;</asp:ListItem>
                                <asp:ListItem Text=" No " Value="N">&nbsp;&nbsp;</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-2" style="color: tan;">Fecha Pago:</div>
                        <div class="col-4">
                            <asp:TextBox ID="TbFechapago" runat="server" CssClass="rcorners0"></asp:TextBox>
                            <cc1:CalendarExtender ID="TbFechapago_CalendarExtender" runat="server" Enabled="True" TargetControlID="TbFechapago" CssClass="GridNegra">
                            </cc1:CalendarExtender>
                        </div>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="col-2" style="color: tan;">Estado: </div>
                        <div class="col-4">
                            <asp:DropDownList ID="DdlEstados" runat="server" CssClass="rcorners0">
                                <asp:ListItem Text="Reservada" Value="Reserva"></asp:ListItem>
                                <asp:ListItem Text="Anulada" Value="Anulada"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-2" style="color: tan;"></div>
                        <div class="col-4">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-dark" Text="Guardar" OnClick="BtnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-2">
          
            </div>
          <div class="row">
              <div class="col-lg-12 text-center">  
                  <asp:Label ID="LbError" CssClass="alert-danger rcorners0" runat="server"></asp:Label>
                  <asp:HiddenField ID="HndId" runat="server" />
              </div>
          </div>  
        </asp:Panel>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    </form>

</asp:Content>
