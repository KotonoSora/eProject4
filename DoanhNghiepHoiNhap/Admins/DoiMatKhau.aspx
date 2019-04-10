<%@ Page Title="Đổi mật khẩu" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.DoiMatKhau" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 152px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <h2><%=Lang.Show("changepassword") %></h2></td>
        </tr>
        <tr>
            <td class="style2">
               <%=Lang.Show("passwordold")%></td>
            <td>
                <asp:TextBox ID="txtOldPassword" CssClass="textbox" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <%=Lang.Show("password")%></td>
            <td>
                <asp:TextBox ID="txtNewpassword" CssClass="textbox" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtReNewPassword" ControlToValidate="txtNewpassword" 
                    ErrorMessage="Mật khẩu không khớp" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <%=Lang.Show("confirmpassword")%></td>
            <td>
                <asp:TextBox ID="txtReNewPassword" CssClass="textbox" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button CssClass="button" ID="btnDoiMK"  
                    runat="server" onclick="btnDoiMK_Click" /></td>
        </tr>
    </table>
</asp:Content>