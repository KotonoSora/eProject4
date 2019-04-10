<%@ Page Title="Quản trị TH_QuyenSach" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="TH_QuyenSach.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TH_QuyenSach" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="/ckfinder/ckfinder.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSelectImg").click(function () {
                var finder = new CKFinder();
                finder.selectActionFunction = function (fileUrl) {
                    $('#<%=txtImgUrl.ClientID %>').val(fileUrl);
                    $('#<%=imgHinhAnh.ClientID %>').attr("src", fileUrl);
                };
                finder.popup();
            });
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">Quản trị Quyển Sách </div>
    <asp:Panel ID="pn_showTH_QuyenSach" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>Thể loại sách:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTheLoaiSach" runat="server"
                                    CssClass="textbox" Height="30px" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="SearchByForeignKey">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtSTH_QuyenSach" runat="server" Width="350px"></asp:TextBox>
                                <%--<asp:DropDownList ID="ddlSColumnTH_QuyenSach" runat="server" Width="70px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlSearchColumn" runat="server" Width="150px"></asp:DropDownList>--%>
                                <asp:Button ID="btnSearchColumn" runat="server" Text="Tìm kiếm" CssClass="button" OnClick="btnSearchColumn_Click" />
                                <asp:Button ID="btnShowAllData" runat="server" Text="Hiện tất cả" CssClass="button" OnClick="btnShowAllData_Click" />

                            </td>
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
                <td height="6" style="text-align: center">
                    <asp:DataGrid ID="grd_showTH_QuyenSach" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" ForeColor="#333333" OnItemCommand="grd_showTH_QuyenSach_ItemCommand" OnItemDataBound="grd_showTH_QuyenSach_ItemDataBound" OnPageIndexChanged="grd_showTH_QuyenSach_PageIndexChanged" PageSize="10" Width="100%">
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

                               <asp:TemplateColumn HeaderText="Hình Ảnh">
                                <ItemTemplate>
                                    <%-- <%#(Eval("HinhAnh").ToString())%>--%>
                                    <asp:Image runat="server" AlternateText="HinhAnh" Height="80px" ImageUrl='<%#Eval("HinhAnh") %>' Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="Tiêu Đề">
                                <ItemTemplate>
                                    <%#(Eval("TieuDe_QuyenSach").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tác Giả">
                                <ItemTemplate>
                                    <%#(Eval("TacGia").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <%--<asp:TemplateColumn HeaderText="Mô tả">
                                <ItemTemplate>
                                    <%#(Eval("Mota").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>--%>
                            <%-- <asp:TemplateColumn HeaderText="">
                                <ItemTemplate>
                                    <%#(Eval("Note").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>--%>
                            <asp:TemplateColumn HeaderText="Thể Loại Sách">
                                <ItemTemplate>
                                    <%#GetLoaiSach(Eval("Id_TheLoaiSach").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="Thể loại chương">
                                <ItemTemplate>
                                    <%#GetLoaiChuong(Eval("Id_TheLoaiChuong").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="Lượt Xem">
                                <ItemTemplate>
                                    <%#(Eval("Luotxem").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="Ngày Update">
                                <ItemTemplate>
                                    <%#DoanhNghiepHoiNhap.Common.DateTimeClass.ConvertDateTime(Eval("NgayUp").ToString(),"dd/MM/yyyy hh:mm:ss") %>
                                </ItemTemplate>
                            </asp:TemplateColumn>

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
    <asp:Panel ID="pn_updateTH_QuyenSach" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="" cellpadding="0" width="100%" border="0" cellspacing="20">
            <tr>
                <td width="150" height="10"></td>
                <td height="10"></td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Tiêu Đề
:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTieuDe_QuyenSach" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTieuDe_QuyenSach" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Tác Giả
:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTacGia" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTacGia" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Mô tả
:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMota" runat="server" Width="500px" Height="200px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="lblerrorMota" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <%--<tr>
                <td width="150" class="name_fild_row">&nbsp;
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtNote" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorNote" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>--%>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Thể loại sách
:
                </td>
                <td>

                    <asp:DropDownList CssClass="textbox" Height="30px" ID="ddlUTheLoaiSach" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <td width="150" class="name_fild_row">&nbsp;
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtLuotxem" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorLuotxem" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>--%>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Hình Ảnh
:
                </td>
                <td>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <input class="button" type="button" id="btnSelectImg" value="..." /><br />
                    <asp:Image ID="imgHinhAnh" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;Thể loại chương
:
                </td>
                <td>
                    <asp:DropDownList CssClass="textbox" Width="200px" ID="ddlUTheLoaiChuong" runat="server">
                    </asp:DropDownList>
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
