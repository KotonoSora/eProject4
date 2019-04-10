<%@ Page Title="Quản trị vị trí " Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TT_ViTri.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TT_ViTri" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Quản trị vị trí 
    </div>
    <asp:Panel ID="pn_showTT_ViTri" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <asp:Button ID="btnThem_ViTriQuangCao" runat="server" CssClass="btnthem" Text="Thêm mới"
                        OnClick="btnThem_Click" />
                </td>
            </tr>
            <tr>
                <td height="6">
                    <asp:DataGrid ID="grd_showTT_ViTri" runat="server" AutoGenerateColumns="False" CssClass="tableview"
                        CellPadding="4" ForeColor="#333333" Width="100%" OnItemCommand="grd_showTT_ViTri_ItemCommand" OnItemDataBound="grd_showTT_ViTri_ItemDataBound">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20px">
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
                                    <asp:Label ID="lIDbIDl" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tên vị trí">
                                <ItemTemplate>
                                    <asp:Label ID="grdLblTenViTri" runat="server" Text='<%#(Eval("TenViTri").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Mô tả">
                                <ItemTemplate>
                                    <asp:Label ID="grdLblMoTa" runat="server" Text='<%#(Eval("MoTa").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Giá tiền quảng cáo">
                                <ItemTemplate>
                                    <asp:Label ID="grdLblGia" runat="server" Text='<%#(Eval("Gia").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    Chức năng</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="Edit"
                                        CssClass="edit" ToolTip="Sửa">&nbsp;</asp:LinkButton>|<asp:LinkButton ID="lbt2" runat="server"
                                            CommandArgument='<%#Eval("ID")%>' CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)"
                                            ToolTip="Xóa bỏ">&nbsp;</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateColumn>
                        </Columns>
                        <EditItemStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <PagerStyle BackColor="#F3F8FE" ForeColor="Blue" HorizontalAlign="Center" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pn_updateTT_ViTri" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%"
            border="0">
            <tr>
                <td width="150" height="10">
                </td>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUTenViTri" Text="Tên vị trí" runat="server">Tên vị trí:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTenViTri" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTenViTri" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUMoTa" Text="Mô tả" runat="server">Mô tả:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMoTa" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorMoTa" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUGia" Text="Giá tiền quảng cáo" runat="server">Giá tiền quảng cáo:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGia" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorGia" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtUpdate_ViTriQuangCao" CssClass="update" 
                        runat="server" OnClick="LbtUpdate_Click">Cập nhật</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click">Trở lại</asp:LinkButton><asp:CheckBox
                        ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
