<%@ Page Title="Danh mục nhóm sản phẩm" Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TM_NhomHangHoa.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TM_NhomHangHoa" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>
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
        <%=Lang.Show("groupproduct")%>
    </div>
    <asp:Panel ID="pn_showTM_NhomHangHoa" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox CssClass="textbox" ID="txtSTM_NhomHangHoa" runat="server" Width="300px"></asp:TextBox> 
                                <asp:Button ID="btnSearchColumn" runat="server" Text="Tìm kiếm" CssClass="button"
                                    OnClick="btnSearchColumn_Click" /> 
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text=""
                        OnClick="btnThem_Click" /> 
                </td>
            </tr>
            <tr>
                <td height="6">
                    <div style="padding:10px;font-size:16px;font-weight:bold;">
                    <asp:Literal ID="ltrLink" runat="server" />
                    </div>
                    <asp:DataGrid ID="grd_showTM_NhomHangHoa" runat="server" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" 
                        ForeColor="#333333" OnItemCommand="grd_showTM_NhomHangHoa_ItemCommand" 
                        OnItemDataBound="grd_showTM_NhomHangHoa_ItemDataBound"
                        Width="100%">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns> 
                            <asp:TemplateColumn >
                                <HeaderTemplate>
                                    <%=Lang.Show("name") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#CreateLink(Eval("Id").ToString(), Eval("TenNhom").ToString(), Eval("CapBac").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn >
                                <HeaderTemplate>
                                    <%=Lang.Show("description") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("MoTa").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate>
                                    <%=Lang.Show("keyword") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("TuKhoa").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thứ tự">
                                <HeaderTemplate>
                                    <%=Lang.Show("order") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("ThuTu").ToString())%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("status") %></HeaderTemplate>
                                <ItemTemplate>
                                    <%#GetStatus(Eval("TrangThai").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                <HeaderTemplate>
                                    <%=Lang.Show("function") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("Id")%>' 
                                        CommandName="Edit" CssClass="edit" ToolTip="Sửa">&nbsp;</asp:LinkButton>
                                    |<asp:LinkButton ID="lbt2" runat="server" CommandArgument='<%#Eval("Id")%>' 
                                        CommandName="Delete" CssClass="delete" 
                                        OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)" 
                                        ToolTip="Xóa bỏ">&nbsp;</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateColumn>
                        </Columns>
                        <EditItemStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <PagerStyle CssClass="pagination" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pn_updateTM_NhomHangHoa" runat="server" Visible="False" Width="100%">
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
                    &nbsp; <%=Lang.Show("name") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTenNhom" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTenNhom" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("image") %>:
                </td>
                <td>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <input class="button" type="button" id="btnSelectImg" value="..." />&nbsp;
                    <asp:Image ID="imgHinhAnh" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("keyword") %> (SEO):
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTuKhoa" runat="server" TextMode="MultiLine" Height="50px" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("description") %> (SEO):
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMoTa" runat="server" TextMode="MultiLine" Height="50px" Width="300px"></asp:TextBox>
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
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("status") %>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlTrangThai" Width="300px" runat="server">
                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="LbtUpdate_Click"></asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click"></asp:LinkButton><asp:CheckBox
                        ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
