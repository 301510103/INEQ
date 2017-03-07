<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema deinventario de Equipos-INEQ</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>       
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" placeholder="email@example.com"></asp:TextBox>
                </td>
                <tr>
                    <td>
                        <asp:Label ID="lblContraseña" runat="server" Text="contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Button ID="btnIniciar" runat="server" Text="Iniciar Sesion" OnClick="btnIniciar_Click" />
                    </td>
                </tr>
            </tr>
        </table>
    </div>
        <div>
            <asp:Label ID="lblresultado" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
