<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WebApplication1.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <script src="Scripts/jquery-3.0.0.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
            <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container-fluid"> 
       <div class="row">
            <br />

       Beinvenidos al la intranet
      <div style="height: 382px; margin-top: 75px;">
    <form id="menu" runat="server">
        <asp:Panel ID="panelLogin" runat ="server">
            <table>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lbUsuario" runat="server" Text="Usuario: "></asp:Label></td>
                    <td><asp:TextBox ID="tbUsuario" runat="server" ></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lbPassword" runat="server"  Text="Password: "></asp:Label></td>
                    <td><asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="4">
                         <asp:Button ID="btnLogin" runat="server" Text="Login" />
                    </td>
                </tr>
            </table>

        </asp:Panel>
        <asp:Panel ID="panelMenu" runat="server">
                <table>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </asp:Panel>
    <asp:Button ID="btnInquilinos" runat="server" Text="Inquilinos"  BackColor="White"/>
        </form>
    </div>
  </div>
   </div>
    
 
</asp:Content>
