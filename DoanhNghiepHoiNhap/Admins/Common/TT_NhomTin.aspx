<%@ Page Title="Quản trị nhóm tin tức" Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TT_NhomTin.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TT_NhomTin" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <%=Lang.Show("newgroup")%>
    </div>
    <asp:Panel ID="pn_showTT_NhomTin" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox CssClass="textbox" ID="txtSTT_NhomTin" runat="server" Width="300px"></asp:TextBox>
                                <asp:Button ID="btnSearchColumn_NhomTin" runat="server" 
                                    CssClass="button" OnClick="btnSearchColumn_Click" Text="Tìm kiếm" />&nbsp;
                                <asp:Button ID="btnShowAllData_NhomTin" runat="server" 
                                    CssClass="button" OnClick="btnShowAllData_Click" Text="Hiện tất cả" />&nbsp;
                                <asp:Button ID="btnCapNhatThuTu" runat="server" CssClass="button" 
                                    Text="Cập nhật thứ tự" 
                                    OnClientClick="return confirm(&quot;Bạn có muốn cập nhật không?&quot;)" 
                                    onclick="btnCapNhatThuTu_Click" />
                                <asp:DropDownList ID="ddlSColumnTT_NhomTin" runat="server" Visible="False">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlSearchColumn" runat="server" Visible="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem_NhomTin" runat="server" CssClass="btnthem" Text="Thêm mới"
                        OnClick="btnThem_Click" />
                </td>
            </tr>
            <tr>
                <td height="6">
                    <asp:DataGrid ID="grd_showTT_NhomTin" runat="server" AutoGenerateColumns="False" CssClass="tableview"
                        CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grd_showTT_NhomTin_PageIndexChanged"
                        OnItemCommand="grd_showTT_NhomTin_ItemCommand" OnItemDataBound="grd_showTT_NhomTin_ItemDataBound">
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
                                    <asp:Label ID="lIDbIDl" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                
                                <HeaderTemplate><%=Lang.Show("serial") %></HeaderTemplate> 
                                <ItemTemplate>
                                    <asp:Label ID="lblThuTu" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("name") %></HeaderTemplate> 
                                <ItemTemplate>
                                    <%#GetNameStyle(Eval("Ten").ToString(), Eval("Cha").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <%--<asp:TemplateColumn HeaderText="Tag">
                                <ItemTemplate>
                                    <%#(Eval("Tag").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>--%>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("description") %></HeaderTemplate> 
                                <ItemTemplate>
                                    <%#(Eval("MoTa").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("order") %></HeaderTemplate> 
                                <ItemTemplate>
                                    <asp:TextBox runat="server" style="text-align: center;" ID="txtThuTu" Width="50px" Text='<%#(Eval("ThuTu").ToString())%>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("show") %></HeaderTemplate> 
                                <ItemTemplate>
                                    <%#ReturnHienThi(Eval("HienThi").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate><%=Lang.Show("function") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Edit"
                                        CssClass="edit" ToolTip="">&nbsp;</asp:LinkButton>|<asp:LinkButton ID="lbt2" runat="server"
                                            CommandArgument='<%#Eval("Id")%>' CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)"
                                            ToolTip="">&nbsp;</asp:LinkButton>
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
    <asp:Panel ID="pn_updateTT_NhomTin" runat="server" Visible="False" Width="100%">
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
                    <asp:Label ID="lblUTen" Text="Tên nhóm tin" runat="server"><%=Lang.Show("name") %>:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTen" CssClass="textbox" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTen" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUMoTa" Text="Mô tả" runat="server"><%=Lang.Show("description") %>:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMoTa" CssClass="textbox" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorMoTa" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUCha" Text="Nhóm tin cha" runat="server"><%=Lang.Show("level") %>:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlNhomTin" Width="300px" CssClass="textbox">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUThuTu" Text="Thứ tự" runat="server"><%=Lang.Show("order") %>:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtThuTu" CssClass="textbox" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorThuTu" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUHienThi" Text="Hiển thị" runat="server"><%=Lang.Show("show") %>:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlHienThi" CssClass="textbox" runat="server" Width="300px">
                        <asp:ListItem Value="1">Hiển thị</asp:ListItem> 
                        <asp:ListItem Value="0">Không</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr> 
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtUpdate_NhomTin" CssClass="update" runat="server" OnClick="LbtUpdate_Click">Cập nhật</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click">Trở lại</asp:LinkButton><asp:CheckBox
                        ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
