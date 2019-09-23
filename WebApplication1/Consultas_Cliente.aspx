<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Consultas_Cliente.aspx.cs" Inherits="WebApplication1.Consultas_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Consultas</title>
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

    <hr style="background-color:darkolivegreen; height:15px;" />
    <hr style="background-color:darkgoldenrod; height:4px;" />
    <form id="FormConsultas" runat="server">
     <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-3 d-flex justify-content-center" style="text-align:center;">
                    <table class="rcorners1" style="color:sandybrown; font-family:'Trebuchet MS'; font-size:large; background-color:transparent; border:none; ">
                        <tr >
                            <td></td>
                            <td><asp:Label ID="LbNombre" runat="server" Text="Nombre"></asp:Label></td>
                            <td><asp:TextBox ID="TbNombre" runat="server" CssClass="rcorners0" Width="350px" placeholder="Nombre"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Label ID="lbEmail" runat="server" Text="E-Mail:" ToolTip="Correo electrónico"></asp:Label></td>
                            <td><asp:TextBox ID="TbEcorreo" runat="server" CssClass="rcorners0" ToolTip="Correo electrónico" Width="350px" placeholder="Correo@Electronico.com"></asp:TextBox></td>
                            <td></td>
                        </tr>
                         <tr>
                            <td></td>
                            <td><asp:Label ID="LbMotivo" runat="server" Text="Motivo:" ToolTip=""></asp:Label></td>
                            <td><asp:DropDownList ID="DdlMotivo" runat="server" CssClass="rcorners0" Width="350" OnSelectedIndexChanged="DdlMotivo_SelectedIndexChanged" AutoPostBack=" true">
                                <asp:ListItem Text="Consulta por Diponibilidad" Value="CD"></asp:ListItem>
                                <asp:ListItem Text="Consulta por Propiedad" Value="CP"></asp:ListItem> 
                                <asp:ListItem Text="Como Reservar" Value="CR"></asp:ListItem>
                                <asp:ListItem Text ="Otras Consultas" Value ="CO"></asp:ListItem>
                                </asp:DropDownList><br />
                                <asp:DropDownList ID="DdlPropiedades" runat="server" CssClass="rcorners0" Width="350px"></asp:DropDownList>
                            </td>

                            <td></td>
                        </tr>
                         <tr>
                            <td></td>
                            <td><asp:Label ID="LbTelefono" runat="server" Text="Teléfono:" ToolTip="No olvide la su caracterisica"></asp:Label></td>
                            <td><asp:TextBox ID="TbTeléfono" runat="server" CssClass="rcorners0 masked-phone"  data-phonemask="+54 (___)____-____" ToolTip="No olvide la su caracterisica" Width="350px"  ></asp:TextBox></td>
                            <td></td>
                        </tr>
                         <tr>
                            <td></td>
                            <td><asp:Label ID="LbConsulta" runat="server" Text="Consulta:" ></asp:Label></td>
                            <td><asp:TextBox ID="TbConsulta" runat="server" CssClass="rcorners0" Width="350px" TextMode="MultiLine" Height="200px" onkeyup="charcountupdate(this.value)" MaxLength="300" placeholder="Su consulta ..."></asp:TextBox></td>
                            <td></td>
                        </tr>
                           <tr>
                            <td></td>
                            <td colspan="2"><span id=charcount></span>
                                <asp:Label ID="LbError" runat="server" CssClass="rcorners0  alert-danger"  Width="100%"></asp:Label>
                            </td>
                            <td></td>
                        </tr> <tr>
                            <td></td>
                            <td colspan="2"><asp:Button ID="BtnEnviar" runat="server" Text="Enviar" CssClass="btn btn-dark" OnClick="BtnEnviar_Click"  /></td>
                            <td></td>
                        </tr>
                    </table>
                  </div>
                </div>
         </form>
         </div>
    <script  type="text/javascript">
        function charcountupdate(str) {
            var lng = str.length;
            var Cantidad = 300 - lng;
            var Texto = document.getElementById("charcount");
            Texto.innerHTML = "Caractéres :" + Cantidad;
            if (Cantidad > 200) {
                Texto.style.color = "lightgreen";
            }
            else {
                if (Cantidad > 100) {
                    Texto.style.color = "yellow";
                    }
                else {
                    if (Cantidad > 50) {
                        Texto.style.color = "Sienna";
                    }
                    else
                        Texto.style.color = "red";
                    }
            }
        }

       
    </script>
</asp:Content>
