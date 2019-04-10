<%@ Page Title="Quản trị NhomHinhAnh" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true" CodeBehind="NhomHinhAnh.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.NhomHinhAnh" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"  %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="title">Quản trị NhomHinhAnh </div>
	<asp:Panel ID="pn_showNhomHinhAnh" runat="server" Width="100%">
		<table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0; " cellpadding="0" width="100%" border="0">
<tr>
<td>
<table><tr><td colspan="2">
<asp:TextBox ID="txtSNhomHinhAnh" runat="server" Width="150px"></asp:TextBox><asp:DropDownList ID="ddlSColumnNhomHinhAnh" runat="server" Width="70px"></asp:DropDownList><asp:DropDownList ID="ddlSearchColumn" runat="server" Width="150px"></asp:DropDownList><asp:Button ID="btnSearchColumn" runat="server" Text="Tìm kiếm" CssClass="button" onclick="btnSearchColumn_Click" /><asp:Button ID="btnShowAllData" runat="server" Text="Hiện tất cả" CssClass="button" onclick="btnShowAllData_Click" /></td></tr></table>
</td>
</tr>
<tr>
<td>
					<asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="&nbsp;&nbsp;Thêm mới" OnClick="btnThem_Click" /><asp:Button ID="btnXoa" runat="server" CssClass="btnXoa" Text="Xóa" OnClick="btnXoa_Click" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" />
				</td>
			</tr>
			<tr>
			</tr>
			<tr>
				<td height="6">
					<asp:DataGrid ID="grd_showNhomHinhAnh" runat="server" AllowPaging="True" CssClass="tableview" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grd_showNhomHinhAnh_PageIndexChanged" PageSize="10" OnItemCommand="grd_showNhomHinhAnh_ItemCommand" OnItemDataBound="grd_showNhomHinhAnh_ItemDataBound"><AlternatingItemStyle BackColor="White" />
						<Columns>
<asp:TemplateColumn ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
<HeaderTemplate>
<asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
</ItemTemplate>
<ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:TemplateColumn Visible="false">
<HeaderTemplate>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lIDbIDl" runat="server" Text='<%#Eval("id")%>'></asp:Label>
</ItemTemplate></asp:TemplateColumn><asp:TemplateColumn HeaderText="">
<ItemTemplate><%#(Eval("TenNhom").ToString())%>
</ItemTemplate>
</asp:TemplateColumn><asp:TemplateColumn HeaderText="">
<ItemTemplate><%#(Eval("ThuTu").ToString())%>
</ItemTemplate>
</asp:TemplateColumn><asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"><HeaderTemplate>Chức năng</HeaderTemplate><ItemTemplate><asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="Edit" CssClass="edit" ToolTip="Sửa">&nbsp;</asp:LinkButton>|<asp:LinkButton ID="lbt2" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" ToolTip="Xóa bỏ">&nbsp;</asp:LinkButton>
</ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="100px" />
</asp:TemplateColumn>
</Columns>
<EditItemStyle BackColor="#2461BF" />
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
<HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
<ItemStyle BackColor="#EFF3FB" />
<PagerStyle CssClass="pagination" Mode="NumericPages" />
<SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
</asp:DataGrid>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pn_updateNhomHinhAnh" runat="server" Visible="False" Width="100%">
<table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
<tr>
<td width="150" height="10"></td>
<td height="10"></td>
</tr>
<tr>
<td width="150" class="name_fild_row">&nbsp;
:
</td>
<td>
<asp:TextBox CssClass="textbox" ID="txtTenNhom" runat="server" Width="300px"></asp:TextBox>
<asp:Label ID="lblerrorTenNhom" runat="server" Text="" ForeColor="Red"></asp:Label>

</td>
</tr>
<tr>
<td width="150" class="name_fild_row">&nbsp;
:
</td>
<td><FCKeditorV2:FCKeditor ID="fckHinhAnh" runat="server" BasePath="~/"></FCKeditorV2:FCKeditor>
<asp:Label ID="lblerrorHinhAnh" runat="server" Text="" ForeColor="Red"></asp:Label>

</td>
</tr>
<tr>
<td width="150" class="name_fild_row">&nbsp;
:
</td>
<td>
<asp:TextBox CssClass="textbox" ID="txtThuTu" runat="server" Width="300px"></asp:TextBox>
<asp:Label ID="lblerrorThuTu" runat="server" Text="" ForeColor="Red"></asp:Label>

</td>
</tr>
<tr>
<td width="150">&nbsp;
</td>
<td>
&nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="LbtUpdate_Click">Cập nhật</asp:LinkButton>&nbsp;&nbsp;
<asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click">Trở lại</asp:LinkButton><asp:CheckBox ID="Insert" runat="server" Visible="false" />
</td>
</tr>
</table>
</asp:Panel>
</asp:Content>