<%@ Page Title="Phân quyền chức năng" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="PhanQuyenChucNang.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.PhanQuyenChucNang" %>

<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <%=Lang.Show("permitionfunction")%>
    </div>
    <asp:Panel ID="pn_showTT_ChucNang" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td height="6">
                    <asp:DataGrid ID="grd_showTT_ChucNang" runat="server" AutoGenerateColumns="False" CssClass="tableview"
                        CellPadding="4" ForeColor="#333333" Width="400px" OnPageIndexChanged="grd_showTT_ChucNang_PageIndexChanged"
                        OnItemCommand="grd_showTT_ChucNang_ItemCommand">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn Visible="false">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lIDbIDl" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="STT">
                                <ItemTemplate>
                                    <asp:Label ID="lblThuTu" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("functionname")%></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblMoTa" runat="server" Text='<%#(Eval("MoTa").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate><%=Lang.Show("function") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("Id")%>'
                                        CommandName="phanquyen" CssClass="phanquyen" ToolTip="Phân quyền"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateColumn>
                        </Columns>
                        <EditItemStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <PagerStyle BackColor="#F3F8FE" ForeColor="Blue" HorizontalAlign="Center" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="panelNhomNguoiDung" runat="server" Visible="false">
        <br />
        <strong>
            <asp:Literal ID="ltrChonNhom" runat="server" />:</strong>
        <asp:DataGrid ID="grd_showTT_NhomNguoiDung" runat="server" AutoGenerateColumns="False" CssClass="tableview"
            CellPadding="4" ForeColor="#333333" Width="500px"
            OnItemDataBound="grd_showTT_NhomNguoiDung_ItemDataBound">
            <AlternatingItemStyle BackColor="White" />
            <Columns>
                <asp:TemplateColumn ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect0" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="tdCenter"></ItemStyle>
                </asp:TemplateColumn>
                <asp:BoundColumn HeaderText="ID" DataField="ID" Visible="false" />
                <%--<asp:BoundColumn  HeaderText="Tên nhóm" DataField="TenNhom" />--%>
                <asp:TemplateColumn>
                    <HeaderTemplate><%=Lang.Show("name")%></HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("TenNhom").ToString()%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <%-- <asp:BoundColumn  HeaderText="Mô tả" DataField="MoTa" />--%>
                <asp:TemplateColumn>
                    <HeaderTemplate><%=Lang.Show("description")%></HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("MoTa").ToString()%>
                    </ItemTemplate>
                </asp:TemplateColumn>

            </Columns>
            <EditItemStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White"
                HorizontalAlign="Center" />
            <ItemStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#F3F8FE" ForeColor="Blue" HorizontalAlign="Center"
                Mode="NumericPages" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtUpdate_NhomNguoiDung" runat="server" CssClass="update"
            OnClick="LbtUpdate_Click"></asp:LinkButton>
        <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back"
            OnClick="LbtCancel_Click"></asp:LinkButton>
        <br />
    </asp:Panel>
</asp:Content>
