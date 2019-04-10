<%@ Page Title="Quản trị HinhAnhQueHuong" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="HinhAnhQueHuong.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.HinhAnhQueHuong" %>

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
    <div class="title">Hình ảnh
        <asp:Literal ID="ltrAlbum" runat="server" />
    </div>
    <asp:Panel ID="pn_showHinhAnhQueHuong" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="&nbsp;&nbsp;Thêm mới" OnClick="btnThem_Click" /><asp:Button ID="btnXoa" runat="server" CssClass="btnXoa" Text="Xóa" OnClick="btnXoa_Click" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" />
                </td>
            </tr>
            <tr>
                <td height="6">
                    <asp:DataGrid ID="grd_showHinhAnhQueHuong" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" ForeColor="#333333" OnItemCommand="grd_showHinhAnhQueHuong_ItemCommand" OnItemDataBound="grd_showHinhAnhQueHuong_ItemDataBound" OnPageIndexChanged="grd_showHinhAnhQueHuong_PageIndexChanged" PageSize="10" Width="100%">
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
                            <asp:TemplateColumn HeaderText="Tiêu đề">
                                <ItemTemplate>
                                    <%#(Eval("TieuDe").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Mo tả">
                                <ItemTemplate>
                                    <%#(Eval("Mota").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Hình ảnh">
                                <ItemTemplate>
                                    <asp:Image runat="server" ImageUrl='<%#(Eval("HinhAnh").ToString())%>' Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thứ tự">
                                <ItemTemplate>
                                    <%#(Eval("ThuTu").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Ngày tạo">
                                <ItemTemplate>
                                    <%#DoanhNghiepHoiNhap.Common.DateTimeClass.ConvertDateTime(Eval("NgayTao").ToString(),"dd/MM/yyyy") %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Người tạo">
                                <ItemTemplate>
                                    <%#(Eval("NguoiTao").ToString())%>
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
    <asp:Panel ID="pn_updateHinhAnhQueHuong" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="150" height="10"></td>
                <td height="10"></td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Tiêu đề
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTieuDe" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTieuDe" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Mô tả
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMota" runat="server" Width="300px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">&nbsp;
:
</td>
                <td>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="update" ControlToValidate="txtImgUrl" CssClass="require" runat="server" ErrorMessage="(*)" />--%>
                    <input class="button" type="button" id="btnSelectImg" value="..." />&nbsp;
                    <asp:Image ID="imgHinhAnh" runat="server" Width="100px" />

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Thứ tự
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtThuTu" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorThuTu" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Ngày tạo
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" runat="server" ID="txtNgayTao" Width="150px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtNgayTao_CalendarExtender" runat="server" TargetControlID="txtNgayTao"></asp:CalendarExtender>
                    <asp:Label ID="lblerrorNgayTao" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Người tạo
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtNguoiTao" runat="server" Width="200px"></asp:TextBox>

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
