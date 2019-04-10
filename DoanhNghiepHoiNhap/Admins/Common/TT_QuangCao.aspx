<%@ Page Title="Quản trị " Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TT_QuangCao.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TT_QuangCao" %>

<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Common" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
        <%=Lang.Show("advertise")%>
    </div>
    <asp:Panel ID="pn_showTT_QuangCao" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="name_fild_row">
                                <%=Lang.Show("position")%>:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSViTri" runat="server" Width="307px" height="30px" OnSelectedIndexChanged="SearchByForeignKey"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:Button ID="btnShowAllData" CssClass="button" runat="server" OnClick="btnShowAllData_Click" 
                                    Text="Hiện tất cả" />
                            </td>
                        </tr>
                        <tr>
                            <td class="name_fild_row">
                                <%=Lang.Show("keyword")%>:
                            </td>
                            <td>
                                <asp:TextBox CssClass="textbox" ID="txtSTT_QuangCao" runat="server" Width="300px"></asp:TextBox>
                                <asp:Button ID="btnSearchColumn" Width="95px" CssClass="button" runat="server" OnClick="btnSearchColumn_Click" 
                                    Text="Tìm kiếm" />
                                <asp:Button ID="btnCapNhatThuTu" runat="server" CssClass="button" 
                                    Text="Cập nhật thứ tự" 
                                    OnClientClick="return confirm(&quot;Bạn có muốn cập nhật không?&quot;)" 
                                    onclick="btnCapNhatThuTu_Click" />
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
                    <asp:DataGrid ID="grd_showTT_QuangCao" runat="server" AutoGenerateColumns="False" CssClass="tableview"
                        CellPadding="4" ForeColor="#333333" Width="100%"
                        OnItemCommand="grd_showTT_QuangCao_ItemCommand" OnItemDataBound="grd_showTT_QuangCao_ItemDataBound">
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
                                <HeaderTemplate><%=Lang.Show("title") %></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("TenQuangCao").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                             <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("description") %></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("Mail").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate><%=Lang.Show("image") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="grdImgHinhAnh" runat="server" ImageUrl='<%#Eval("HinhAnh") %>' Width="80px"
                                        Height="60px" AlternateText="img" />
                                </ItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("position") %></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("TT_ViTriTenViTri").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("order") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox runat="server" style="text-align: center;" ID="txtThuTu" Width="50px" Text='<%#(Eval("ThuTu").ToString())%>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("status") %></HeaderTemplate>
                                <ItemTemplate>
                                    <%#ReturnTrangThai(Eval("TrangThai").ToString())%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate><%=Lang.Show("function") %></HeaderTemplate>
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
                        <HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <PagerStyle BackColor="#F3F8FE" ForeColor="Blue" HorizontalAlign="Center" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pn_updateTT_QuangCao" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%"
            border="0">
            <tr>
                <td width="150" height="10">
                </td>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row"><%=Lang.Show("title") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTenQuangCao" runat="server" Width="800px"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtTenQuangCao" ValidationGroup="update" CssClass="require" runat="server" ErrorMessage="(*)" />
                </td>
            </tr>

             <tr>
                <td width="150" class="name_fild_row"><%=Lang.Show("description") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMoTa" runat="server" Width="800px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtMoTa" ValidationGroup="update" CssClass="require" runat="server" ErrorMessage="(*)" />
                </td>
            </tr>

            <tr>
                <td width="150" class="name_fild_row"><%=Lang.Show("image") %>:
                </td>
                <td>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="update" ControlToValidate="txtImgUrl" CssClass="require" runat="server" ErrorMessage="(*)" />
                    <input class="button" type="button" id="btnSelectImg" value="Chọn ..." />&nbsp;
                    <asp:Image ID="imgHinhAnh" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">Link:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtLink" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtLink" ValidationGroup="update" CssClass="require" runat="server" ErrorMessage="(*)" />
                </td>
            </tr> 
            <tr>
                <td width="150" class="name_fild_row">
                    
                    <asp:Label ID="lblUViTri" Text="Vị trí" runat="server"><%=Lang.Show("position") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="textbox" ID="ddlUViTri" runat="server" 
                        Width="300px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row"><%=Lang.Show("order") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtThuTu" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtThuTu" ValidationGroup="update" CssClass="require" runat="server" ErrorMessage="(*)" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    
                    <asp:Label ID="lblUTrangThai" Text="Trang thái" runat="server"><%=Lang.Show("status") %>:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTrangThai" runat="server" Width="200px" CssClass="textbox">
                        <asp:ListItem Value="1">Hiển thị</asp:ListItem>
                        <asp:ListItem Value="0">Ẩn</asp:ListItem>
                    </asp:DropDownList>
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
                    &nbsp;<asp:LinkButton ValidationGroup="update" ID="lbtUpdate" CssClass="update" runat="server" OnClick="LbtUpdate_Click">Cập nhật</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click">Trở lại</asp:LinkButton><asp:CheckBox
                        ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
            <tr>
                <td width="150">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
