<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="ThongKeTruyCap.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.ThongKeTruyCap" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="title"><%=Lang.Show("statistic")%></div>
<p>
        &nbsp; <%=Lang.Show("datefrom") %>
        <asp:TextBox  CssClass="textbox" Width="100px" ID="TextBox1" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
            DaysModeTitleFormat="dd/MM/yyyy" Enabled="True" Format="dd/MM/yyyy" 
            TargetControlID="TextBox1" TodaysDateFormat="dd/MM/yyyy">
        </asp:CalendarExtender>
        &nbsp;&nbsp; <%=Lang.Show("dateto") %>
        <asp:TextBox CssClass="textbox" Width="100px" ID="TextBox2" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
            DaysModeTitleFormat="dd/MM/yyyy" Enabled="True" Format="dd/MM/yyyy" 
            TargetControlID="TextBox2" TodaysDateFormat="dd/MM/yyyy">
        </asp:CalendarExtender>
&nbsp;
        <asp:Button ID="Button1"  CssClass="button" runat="server" onclick="Button1_Click" 
            Text="Hiện kết quả" />
    </p>
    <div style="padding:5px;">
        <asp:Label ID="lblResult" runat="server" Font-Bold="True" ForeColor="#0033CC"></asp:Label>
    </div>
    <div style="padding:5px;">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#0033CC"></asp:Label>
    </div>
</asp:Content>
