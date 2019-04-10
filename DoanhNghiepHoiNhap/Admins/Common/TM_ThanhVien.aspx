<%@ Page Title="Quản trị thành viên" Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TM_ThanhVien.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TM_ThanhVien" %>

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
        <%=Lang.Show("manageuser")%>
    </div>
    <asp:Panel ID="pn_showTM_ThanhVien" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <%=Lang.Show("keyword")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTM_ThanhVien" runat="server" Width="300px" CssClass="textbox"></asp:TextBox> 
                                <asp:Button ID="btnSearchColumn" runat="server" Text="Tìm kiếm" CssClass="button"
                                    OnClick="btnSearchColumn_Click" /><asp:Button ID="btnShowAllData" runat="server"
                                        Text="Hiện tất cả" CssClass="button" OnClick="btnShowAllData_Click" />
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
                    <asp:DataGrid ID="grd_showTM_ThanhVien" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" 
                        ForeColor="#333333" OnItemCommand="grd_showTM_ThanhVien_ItemCommand" 
                        OnItemDataBound="grd_showTM_ThanhVien_ItemDataBound" 
                        OnPageIndexChanged="grd_showTM_ThanhVien_PageIndexChanged" PageSize="10" 
                        Width="100%">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn >
                                <HeaderTemplate>
                                    <%=Lang.Show("username") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("TenDangNhap").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <%=Lang.Show("fullname") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("HoTen").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Chức vụ">
                                <ItemTemplate>
                                    <%#getChucVu(Eval("NhomNguoiDung").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="Email">
                                <ItemTemplate>
                                    <%#(Eval("Email").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate>
                                    <%=Lang.Show("phone") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("SoDT").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate>
                                    <%=Lang.Show("address") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("DiaChi").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Yahoo">
                                <ItemTemplate>
                                    <%#(Eval("Yahoo").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Skype">
                                <ItemTemplate>
                                    <%#(Eval("Skype").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <%=Lang.Show("status") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("TrangThai").ToString()=="1"?Lang.Show("active"):Lang.Show("deactive"))%>
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
                        <ItemStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                        <PagerStyle CssClass="pagination" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pn_updateTM_ThanhVien" runat="server" Visible="False" Width="100%">
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
                    &nbsp; <%=Lang.Show("permission")%>:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlNhomNguoiDung" CssClass="textbox" Height="30px" Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("username") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTenDangNhap" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTenDangNhap" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("password")%>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMatKhau" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorMatKhau" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("fullname")%>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtHoTen" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorHoTen" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; Email:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtEmail" runat="server" Width="300px"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("phone")%>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtSoDT" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("address")%>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtDiaChi" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("notes")%>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtGhiChu" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("image")%>:
                </td>
                <td>
                     <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <input class="button" type="button" id="btnSelectImg" value="..." />&nbsp;
                    <asp:Image ID="imgHinhAnh" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("gender")%>:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlGioiTinh" Width="300px">
                        <asp:ListItem Text="Nam" Value="1" />
                        <asp:ListItem Text="Nữ" Value="0" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; Ngày sinh:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtNgaySinh" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; Yahoo:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtYahoo" runat="server" Width="300px"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; Skype:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtSkype" runat="server" Width="300px"></asp:TextBox> 
                </td>
            </tr> 
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("status")%>:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlKichHoat" Width="300px">
                        <asp:ListItem Text="Kích hoạt" Value="1" />
                        <asp:ListItem Text="Chưa kích hoạt" Value="0" />
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
