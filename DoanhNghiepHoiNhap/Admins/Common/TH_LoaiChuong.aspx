<%@ Page Title="Quản trị TH_LoaiChuong" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="TH_LoaiChuong.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TH_LoaiChuong" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">Quản trị Thể Loại Chương </div>
    <asp:Panel ID="pn_showTH_LoaiChuong" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;" cellpadding="0" width="100%" border="0">
            <tr style="display:none">
                <td>
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtSTH_LoaiChuong" runat="server" Width="150px"></asp:TextBox><asp:DropDownList ID="ddlSColumnTH_LoaiChuong" runat="server" Width="70px"></asp:DropDownList><asp:DropDownList ID="ddlSearchColumn" runat="server" Width="150px"></asp:DropDownList><asp:Button ID="btnSearchColumn" runat="server" Text="Tìm kiếm" CssClass="button" OnClick="btnSearchColumn_Click" /><asp:Button ID="btnShowAllData" runat="server" Text="Hiện tất cả" CssClass="button" OnClick="btnShowAllData_Click" /></td>
                        </tr>
                    </table>
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
                    <asp:DataGrid ID="grd_showTH_LoaiChuong" runat="server" AllowPaging="True" CssClass="tableview" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grd_showTH_LoaiChuong_PageIndexChanged" PageSize="10" OnItemCommand="grd_showTH_LoaiChuong_ItemCommand" OnItemDataBound="grd_showTH_LoaiChuong_ItemDataBound">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="tdCenter"></ItemStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="false">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lIDbIDl" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Loại chương">
                                <ItemTemplate>
                                    <%#(Eval("LoaiChuong").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>Chức năng</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Edit" CssClass="edit" ToolTip="Sửa">&nbsp;</asp:LinkButton>|<asp:LinkButton ID="lbt2" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" ToolTip="Xóa bỏ">&nbsp;</asp:LinkButton>
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
    <asp:Panel ID="pn_updateTH_LoaiChuong" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="150" height="10"></td>
                <td height="10"></td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Tên Loại Chương
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtLoaiChuong" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorLoaiChuong" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="150">&nbsp;
</td>
                <td>&nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="LbtUpdate_Click">Cập nhật</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click">Trở lại</asp:LinkButton><asp:CheckBox ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
