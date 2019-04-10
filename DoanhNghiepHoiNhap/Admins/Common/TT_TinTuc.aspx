<%@ Page Title="Quản trị tin tức" Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TT_TinTuc.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TT_TinTuc" %>
     
<%@ Import Namespace="DoanhNghiepHoiNhap.Common" %>
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
        <%=Lang.Show("managementnews")%>
    </div>
    <asp:Panel ID="pn_showTT_TinTuc" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                               <%=Lang.Show("newgroup")%>:&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSNhomTin" runat="server" CssClass="textbox" Height="30px" Width="300px" OnSelectedIndexChanged="SearchByForeignKey"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <%=Lang.Show("search") %>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTT_TinTuc" CssClass="textbox" runat="server" Width="300px"></asp:TextBox> 
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
                    <asp:DataGrid ID="grd_showTT_TinTuc" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" 
                        ForeColor="#333333" OnItemCommand="grd_showTT_TinTuc_ItemCommand" 
                        OnItemDataBound="grd_showTT_TinTuc_ItemDataBound" 
                        OnPageIndexChanged="grd_showTT_TinTuc_PageIndexChanged" PageSize="10" 
                        Width="100%">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn Visible="false">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lIDbIDl" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("title") %></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("TieuDe").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("image") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Image runat="server" AlternateText="HinhAnh" 
                                        Height="80px" ImageUrl='<%#Eval("HinhAnh") %>' Width="100px" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("createddate") %></HeaderTemplate>
                                <ItemTemplate>
                                    <%#DateTimeClass.ConvertDateTime(Eval("NgayDang").ToString(),"dd/MM/yyyy") %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("createdby")%></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("NguoiDang").ToString())%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("numview")%></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("LuotXem").ToString())%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("status")%></HeaderTemplate>
                                <ItemTemplate>
                                    <%#GetTrangThai(Eval("TrangThai").ToString())%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                 <HeaderTemplate><%=Lang.Show("status")%></HeaderTemplate>
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
    <asp:Panel ID="pn_updateTT_TinTuc" runat="server" Visible="False" Width="100%">
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
                    &nbsp;  <%=Lang.Show("newgroup") %>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlUNhomTin" runat="server" Width="300px">
                    </asp:DropDownList>
                    <asp:Label ID="lblerrorNhomTin" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("title") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTieuDe" runat="server" Width="600px"></asp:TextBox>
                    <asp:Label ID="lblerrorTieuDe" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("title") %> 2 :
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTieuDe2" runat="server" Width="600px"></asp:TextBox>
                    <asp:Label ID="lblerrorTieuDe2" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("summary")%>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTomTat" runat="server" Width="600px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    <asp:Label ID="lblerrorTomTat" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("summary")%> 2 :
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTomTat2" runat="server" Width="600px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    <asp:Label ID="lblerrorTomTat2" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("content")%>:
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckNoiDung" runat="server" Height="400px" BasePath="~/">
                    </FCKeditorV2:FCKeditor>
                    <asp:Label ID="lblerrorNoiDung" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("image") %>:
                </td>
                <td>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="update" ControlToValidate="txtImgUrl" CssClass="require" runat="server" ErrorMessage="(*)" />
                    <input class="button" type="button" id="btnSelectImg" value="..." />&nbsp;
                    <asp:Image ID="imgHinhAnh" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("description") %> (SEO):
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtDescription" runat="server" Width="600px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <asp:Label ID="lblerrorDescription" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("keyword") %> (SEO):
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtKeyword" runat="server" Width="600px"></asp:TextBox>
                    <asp:Label ID="lblerrorKeyword" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("status") %>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlTrangThai" runat="server" Width="300px">
                       
                    </asp:DropDownList>
                </td>
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
