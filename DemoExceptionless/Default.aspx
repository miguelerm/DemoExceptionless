<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoExceptionless.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            Ambos botones generan una excepci&oacute;n, pero el primero captura la excepci&oacute;n con 
            <code>try catch</code> env&iacute;a informaci&oacute;n adicional a <a href="https://exceptionless.com/">Exceptionless</a> y 
            solo le despliega un mensaje al usuario; el segundo es una excepci&oacute;n no
            controlada y redirecciona al usuario a una p&aacute;gina personalizada de error.
        </p>
        <div>
            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <asp:Button ID="btnHandledException" runat="server" Text="Excepción controlada" OnClick="btnHandledException_Click" /> | 
        <asp:Button ID="btnUnhandledException" runat="server" Text="Excepción NO controlada" OnClick="btnUnhandledException_Click" />
    </div>
    </form>
</body>
</html>
