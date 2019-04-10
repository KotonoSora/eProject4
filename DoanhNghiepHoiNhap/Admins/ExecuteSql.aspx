<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="ExecuteSql.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.ExecuteSql" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Height="300px" TextMode="MultiLine" 
        Width="600px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Thực thi" />
        <br /><br />
    <asp:GridView runat="server" ID="grvData" Width="100%" >
    </asp:GridView>
</asp:Content>
