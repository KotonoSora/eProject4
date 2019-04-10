<%@ Page Title="Quản lý video" Language="C#" validateRequest="false" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TT_Multimedia.aspx.cs" Inherits="MyWebsite.Admins.TT_Multimedia" %>
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
        <%=Lang.Show("photovideo") %>
    </div>
    <asp:Panel ID="pn_showTT_Multimedia" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table> 
                        <tr>
                            <td class="name_fild_row">
                                <%=Lang.Show("keyword") %>: 
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtSTT_Multimedia" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>
                                <asp:Button ID="btnSearchColumn" runat="server" Text="Tìm kiếm" CssClass="button" OnClick="btnSearchColumn_Click" />
                                <asp:DropDownList ID="ddlSColumnTT_Multimedia" runat="server" Visible="False" 
                                    Width="70px">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlSearchColumn" runat="server" Visible="False" 
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="&nbsp;&nbsp;Thêm mới"
                        OnClick="btnThem_Click" /> 
                </td>
            </tr>
            <tr>
                <td height="6">
                    <asp:DataGrid ID="grd_showTT_Multimedia" runat="server" AutoGenerateColumns="False" CssClass="tableview"
                        CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grd_showTT_Multimedia_PageIndexChanged"
                        PageSize="10" OnItemCommand="grd_showTT_Multimedia_ItemCommand" 
                        OnItemDataBound="grd_showTT_Multimedia_ItemDataBound">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns> 
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("title") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblTieuDe" runat="server" Text='<%#(Eval("TieuDe").ToString())%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Video">
                                <ItemTemplate>
                                    <img src='<%#StringClass.GetThumbImageYoutobe(Eval("MoTa").ToString()) %>' style="width:100px;height:70px;" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("description") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblMoTa" runat="server" Text='<%#(Eval("NoiDung").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="false">
                                <HeaderTemplate><%=Lang.Show("numview") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblLuotXem" runat="server" Text='<%#(Eval("LuotXem").ToString())%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="90px" HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate><%=Lang.Show("function") %></HeaderTemplate>
                                <ItemTemplate> 
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="Edit"
                                        CssClass="edit" ToolTip="Sửa">&nbsp;</asp:LinkButton>|
                                    <asp:LinkButton ID="lbt2" runat="server"
                                            CommandArgument='<%#Eval("Id")%>' CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)"
                                            ToolTip="Xóa bỏ">&nbsp;</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateColumn>
                        </Columns>
                        <EditItemStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <PagerStyle  CssClass="pagination" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pn_updateTT_Multimedia" runat="server" Visible="False" Width="100%">
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
                    &nbsp;<%=Lang.Show("title") %>:
                </td>
                <td>
                    <asp:TextBox ID="txtTieuDe" CssClass="textbox" runat="server" Width="600px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    <asp:Label ID="lblerrorTieuDe" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("image") %>:</td>
                <td>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <input class="button" type="button" id="btnSelectImg" value="Chọn ..." />&nbsp;
                    <asp:Image ID="imgHinhAnh" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td class="name_fild_row" width="150">
                    &nbsp;Youtube Url:</td>
                <td>
                    <asp:TextBox ID="txtVideoUrl" runat="server" CssClass="textbox" Width="600px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="name_fild_row" width="150">
                    <%=Lang.Show("content") %>:</td>
                <td> 
                    <%--<asp:TextBox runat="server" TextMode="MultiLine" CssClass="textbox" ID="txtNoiDung" Width="600px" Height="100px" /> --%>
                    <FCKeditorV2:FCKeditor ID="fckNoiDung" runat="server" BasePath="~/" Height="350px" Width="600px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td class="name_fild_row" width="150">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="LbtUpdate_Click">Cập nhật</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click">Trở lại</asp:LinkButton><asp:CheckBox
                        ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
