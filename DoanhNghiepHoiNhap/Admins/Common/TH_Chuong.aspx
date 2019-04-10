<%@ Page Title="Quản trị TH_Chuong" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="TH_Chuong.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TH_Chuong" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">Quản trị Chương Chữ </div>
    <asp:Panel ID="pn_showTH_Chuong" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>Tên Quyển Sách :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlsQuyenSach" runat="server"
                                    CssClass="textbox" Height="30px" Width="550px" AutoPostBack="True" OnSelectedIndexChanged="SearchByForeignKey">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                                <%--<asp:TextBox ID="txtSTH_Chuong" runat="server" Width="400px"></asp:TextBox>--%>
                                <%--<asp:DropDownList ID="ddlSColumnTH_Chuong" runat="server" Width="70px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlSearchColumn" runat="server" Width="150px"></asp:DropDownList>--%>
                                <%--<asp:Button ID="btnSearchColumn" runat="server" Text="Tìm kiếm" CssClass="button" OnClick="btnSearchColumn_Click" />--%>
                                <asp:Button ID="btnShowAllData" runat="server" Text="Hiện tất cả" CssClass="button" OnClick="btnShowAllData_Click" />
                            </td>
                        </tr>
                        <%--<tr></tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="&nbsp;&nbsp;Thêm mới" OnClick="btnThem_Click" /><asp:Button ID="btnXoa" runat="server" CssClass="btnXoa" Text="Xóa" OnClick="btnXoa_Click" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" />
                </td>
            </tr>
            <tr>
                <td height="6" style="text-align: center">
                    <asp:DataGrid ID="grd_showTH_Chuong" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" ForeColor="#333333" OnItemCommand="grd_showTH_Chuong_ItemCommand" OnItemDataBound="grd_showTH_Chuong_ItemDataBound" OnPageIndexChanged="grd_showTH_Chuong_PageIndexChanged" PageSize="20" Width="100%">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="20px">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                                <ItemStyle CssClass="tdCenter" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="false">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lIDbIDl" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tiêu Đề Quyển Sách" ItemStyle-Height="20px">
                                <ItemTemplate>
                                    <%#GetQuyenSach(Eval("Id_QuyenSach").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tiêu Đề Chương">
                                <ItemTemplate>
                                    <%#(Eval("TieuDe").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <%--<asp:TemplateColumn HeaderText="Nội Dung">
                                <ItemTemplate>
                                    <%#(Eval("NoiDung").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>--%>
                            <asp:TemplateColumn HeaderText="Ngày cập nhật">
                                <ItemTemplate>
                                    <%#DoanhNghiepHoiNhap.Common.DateTimeClass.ConvertDateTime(Eval("NgayCapNhat").ToString(),"dd/MM/yyyy hh:mm:ss") %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <%--<asp:TemplateColumn HeaderText="">
                                <ItemTemplate>
                                    <%#(Eval("Note_text").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate>
                                    <%#(Eval("Note_int").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>--%>

                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                <HeaderTemplate>
                                    Chức năng
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Edit" CssClass="edit" ToolTip="Sửa">&nbsp;</asp:LinkButton>
                                    |<asp:LinkButton ID="lbt2" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" ToolTip="Xóa bỏ">&nbsp;</asp:LinkButton>
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
    <asp:Panel ID="pn_updateTH_Chuong" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="" cellpadding="0" width="100%" border="0" cellspacing="20">
            <tr>
                <td width="150" height="10"></td>
                <td height="10"></td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Tên Quyển Sách
:
                </td>
                <td>
                    <asp:DropDownList CssClass="textbox" ID="ddlQuyenSach" runat="server" Width="560px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Tiêu Đề Chương
:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTieuDe" runat="server" Width="550px" Height="20px"></asp:TextBox>
                    <asp:Label ID="lblerrorTieuDe" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Nội Dung
:
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckNoiDung" runat="server" BasePath="~/" Height="600px"></FCKeditorV2:FCKeditor>
                    <asp:Label ID="lblerrorNoiDung" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>

            <%-- <tr>
                <td width="150" class="name_fild_row">&nbsp;
:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtNote_text" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorNote_text" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;
:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtNote_int" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorNote_int" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>--%>
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
