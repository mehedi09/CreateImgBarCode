<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB.aspx.vb" Inherits="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
    <asp:Button ID="btnGenerate" runat="server" Text="Generate" 
        onclick="btnGenerate_Click" />
    <hr />
    <asp:PlaceHolder ID="plBarCode" runat="server" />
    </form>
</body>
</html>
