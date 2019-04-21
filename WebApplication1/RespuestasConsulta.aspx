<%@ Page Title="Respuestas" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="RespuestasConsulta.aspx.cs" Inherits="WebApplication1.Respuestas" %>
<asp:Content ID="Respuestas" ContentPlaceHolderID="head" runat="server">
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
    <form id="FormRespuestas" runat="server">
     <div  class="container-fluid">
            <div class="row">
                <div class="col-xl-6">
                    <div class ="col-xl-6">           
                  </div>
                    
                    <div class="col-xs-6">
                        <table width="100%" style="color:sandybrown; font-family:'Trebuchet MS';" >
                           
                               <td >
                                    <asp:Label ID="LbNombre" runat="server" Text="Nombre: "  style="color:sandybrown; font-family:'Trebuchet MS';"  ></asp:Label> <br />
                                   <asp:Label ID="LbConsulta" runat="server" Text="Consulta:" style="color:sandybrown; font-family:'Trebuchet MS';"></asp:Label>
                                   <br />
                               </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="TbConsulta" runat="server" style="color:saddlebrown;" CssClass="rcorners1" Width="85%" TextMode="MultiLine" Height="300px" BackColor="White"  ></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-xl-6">
                    <div class="col-xs-6">
                       <table width="100%" style="color:sandybrown; font-family:'Trebuchet MS';" >
                           
                               <td >
                                     <asp:Label ID="LbMotivo" runat="server" Text="Motivo:" style="color:sandybrown; font-family:'Trebuchet MS';"  ></asp:Label><br />
                                     <asp:Label ID="LbRespuesta" runat="server" Text="Respuesta:" style="color:sandybrown; font-family:'Trebuchet MS';" ></asp:Label>
                                   <br />
                               </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="TbRespuesta" runat="server" CssClass="rcorners2" Width="85%" style="color:saddlebrown;"   Height="300px" BackColor="White" ></asp:Label>
                                </td>
                               
                            </tr>
                        </table>
                        <br />
                     
                  </div>
            </div>
         
     </div>  
     </div>
    <div class="row">
        <div class="col-12 text-center">
          <asp:button ID="BtnVolver" runat="server" cssclass="btn btn-dark" text="volver"  Fontsize="large" OnClick="BtnVolver_Click" />
     </div>
    </div>
    </form>
</asp:Content>
