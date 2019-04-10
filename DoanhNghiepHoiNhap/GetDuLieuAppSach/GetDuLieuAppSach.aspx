<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetDuLieuAppSach.aspx.cs" Inherits="DoanhNghiepHoiNhap.GetDuLieuAppSach.GetDuLieuAppSach" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:TextBox ID="TextBox2" runat="server" Width="1221px"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Insert Dữ Liệu" OnClick="Button1_Click" Style="height: 29px" />
            <asp:Button ID="Button2" runat="server" Text="Update Dữ Liệu" OnClick="Button2_Click" Style="height: 29px" />
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Number" Width="70px">1</asp:TextBox>Page<br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="326px" Width="944px"></asp:TextBox><br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
