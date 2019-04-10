<%@ Page Title="Quản trị hình ảnh sản phẩm" Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TM_HangHoa_HinhAnh.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TM_HangHoa_HinhAnh" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>
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
    <div class="title">
        <%=Lang.Show("imagepro") %>: 
        <asp:Literal ID="ltrSanPham" runat="server" />
    </div>
    <asp:Panel ID="pn_showTM_HangHoa_HinhAnh" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0"> 
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="&nbsp;&nbsp;Thêm mới"
                        OnClick="btnThem_Click" />
                </td>
            </tr>
            <tr>
                <td height="6">
                    <asp:DataGrid ID="grd_showTM_HangHoa_HinhAnh" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" ForeColor="#333333" OnItemCommand="grd_showTM_HangHoa_HinhAnh_ItemCommand" OnItemDataBound="grd_showTM_HangHoa_HinhAnh_ItemDataBound" Width="100%">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <%=Lang.Show("image") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Image runat="server" ImageUrl='<%#(Eval("HinhAnh").ToString())%>' Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <%=Lang.Show("description") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("MoTa").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <%=Lang.Show("order") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("ThuTu").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                <HeaderTemplate>
                                    <%=Lang.Show("function") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Edit" CssClass="edit" ToolTip="...">&nbsp;</asp:LinkButton>
                                    |<asp:LinkButton ID="lbt2" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" ToolTip="... ">&nbsp;</asp:LinkButton>
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
    <asp:Panel ID="pn_updateTM_HangHoa_HinhAnh" runat="server" Visible="False" Width="100%">
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
                    &nbsp; <%=Lang.Show("image") %>:
                </td>
                <td>
                     <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="update" ControlToValidate="txtImgUrl" CssClass="require" runat="server" ErrorMessage="(*)" />
                    <input class="button" type="button" id="btnSelectImg" value="..." />&nbsp;
                    <asp:Image ID="imgHinhAnh" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("description") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMoTa" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorMoTa" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("order") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtThuTu" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorThuTu" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr> 
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="LbtUpdate_Click"><%=Lang.Show("update") %>:</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click"><%=Lang.Show("back") %>:</asp:LinkButton><asp:CheckBox
                        ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
