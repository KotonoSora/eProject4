<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LayHinhAnh.aspx.cs" Inherits="Get_Data.LayHinhAnh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="987px">Nhập Đường dẫn</asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Style="height: 29px" />
        </div>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="326px" Width="944px"></asp:TextBox><br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
