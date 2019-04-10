<%@ Page Title="Quản trị DoanhNghiepQueHuong" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true" CodeBehind="DoanhNghiepQueHuong.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.DoanhNghiepQueHuong" %>

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
    <div class="title">Quản trị Hội Viên Doanh Nghiệp </div>
    <asp:Panel ID="pn_showDoanhNghiepQueHuong" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="&nbsp;&nbsp;Thêm mới" OnClick="btnThem_Click" /><asp:Button ID="btnXoa" runat="server" CssClass="btnXoa" Text="Xóa" OnClick="btnXoa_Click" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" />
                </td>
            </tr>
            <tr style="text-align:center">
                <td height="6">
                    <asp:DataGrid ID="grd_showDoanhNghiepQueHuong" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" ForeColor="#333333" OnItemCommand="grd_showDoanhNghiepQueHuong_ItemCommand" OnItemDataBound="grd_showDoanhNghiepQueHuong_ItemDataBound" OnPageIndexChanged="grd_showDoanhNghiepQueHuong_PageIndexChanged" PageSize="10" Width="100%">
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
                            <asp:TemplateColumn HeaderText="Tên DN">
                                <ItemTemplate>
                                    <%#(Eval("Ten").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Logo">
                                <ItemTemplate>
                                    <asp:Image runat="server" ImageUrl='<%#(Eval("Logo").ToString())%>' Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Giám đốc">
                                <ItemTemplate>
                                    <%#(Eval("GiamDoc").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Địa chỉ">
                                <ItemTemplate>
                                    <%#(Eval("DiaChi").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Điện Thoại">
                                <ItemTemplate>
                                    <%#(Eval("DienThoai").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thứ tự">
                                <ItemTemplate>
                                    <%#(Eval("ThuTu").ToString())%>
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
    <asp:Panel ID="pn_updateDoanhNghiepQueHuong" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="150" height="10"></td>
                <td height="10"></td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Tên Doanh Nghiệp
:
</td>
                <td>
                    <%--<FCKeditorV2:FCKeditor ID="fckTen" runat="server" BasePath="~/"></FCKeditorV2:FCKeditor>--%>
                    <asp:TextBox CssClass="textbox" ID="txtTen" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTen" runat="server" Text="" ForeColor="Red"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Logo
:
</td>
                <td>
                    <%--<FCKeditorV2:FCKeditor ID="fckLogo" runat="server" BasePath="~/"></FCKeditorV2:FCKeditor>
                    <asp:Label ID="lblerrorLogo" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
                     <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="update" ControlToValidate="txtImgUrl" CssClass="require" runat="server" ErrorMessage="(*)" />--%>
                    <input class="button" type="button" id="btnSelectImg" value="..." />&nbsp;
                    <asp:Image ID="imgHinhAnh" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Giới thiệu
</td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckGioiThieu" runat="server" BasePath="~/"></FCKeditorV2:FCKeditor>
                    <%--<asp:Label ID="lblerrorGioiThieu" runat="server" Text="" ForeColor="Red"></asp:Label>--%>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Giám đốc
:
</td>
                <td>
                    <%--<FCKeditorV2:FCKeditor ID="fckGiamDoc" runat="server" BasePath="~/"></FCKeditorV2:FCKeditor>--%>
                    <asp:TextBox CssClass="textbox" ID="txtGiamDoc" runat="server" Width="300px"></asp:TextBox>
                    <%--<asp:Label ID="lblerrorGiamDoc" runat="server" Text="" ForeColor="Red"></asp:Label>--%>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Địa chỉ
:
</td>
                <td>
                    <%--<FCKeditorV2:FCKeditor ID="fckDiaChi" runat="server" BasePath="~/"></FCKeditorV2:FCKeditor>
                    <asp:Label ID="lblerrorDiaChi" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
                    <asp:TextBox CssClass="textbox" ID="txtDiaChi" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Điện thoại
:
</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtDienThoai" runat="server" Width="300px"></asp:TextBox>
                    <%--<asp:Label ID="lblerrorDienThoai" runat="server" Text="" ForeColor="Red"></asp:Label>--%>

                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Email
:
</td>
                <td>
                    <%--<FCKeditorV2:FCKeditor ID="fckEmail" runat="server" BasePath="~/"></FCKeditorV2:FCKeditor>
                    <asp:Label ID="lblerrorEmail" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
                    <asp:TextBox CssClass="textbox" ID="txtEmail" runat="server" Width="300px"></asp:TextBox>

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
                <td width="150">&nbsp;
</td>
                <td>&nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="LbtUpdate_Click">Cập nhật</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click">Trở lại</asp:LinkButton><asp:CheckBox ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
