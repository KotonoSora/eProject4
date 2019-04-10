<%@ Page Title="Quản lý sản phẩm" Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TM_HangHoa.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TM_HangHoa" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <%=Lang.Show("product") %>
    </div>
    <asp:Panel ID="pn_showTM_HangHoa" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                 <%=Lang.Show("groupproduct")%>:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSNhomHangHoa" runat="server"
                                    CssClass="textbox" Height="30px" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="SearchByForeignKey">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=Lang.Show("search") %>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTM_HangHoa" runat="server" Width="300px" 
                                    CssClass="textbox"></asp:TextBox> 
                                <asp:Button ID="btnSearchColumn" runat="server" Text="Tìm kiếm" CssClass="button"
                                    OnClick="btnSearchColumn_Click" />
                                <asp:Button ID="btnShowAllData" runat="server"
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
                    <asp:DataGrid ID="grd_showTM_HangHoa" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="tableview" 
                        ForeColor="#333333" OnItemCommand="grd_showTM_HangHoa_ItemCommand" 
                        OnItemDataBound="grd_showTM_HangHoa_ItemDataBound" 
                        OnPageIndexChanged="grd_showTM_HangHoa_PageIndexChanged" PageSize="10" 
                        Width="100%">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("productid") %></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("MaSP").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("productname")%></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("TenSP").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("image")%></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Image ImageUrl='<%#GetImage(Eval("Id").ToString())%>' Width="90px" Height="90px" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("appraise")%></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("DanhGia").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                 <HeaderTemplate><%=Lang.Show("numview")%></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("LuotXem").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("origin")%></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("BaoHanh").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("establish")%></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl='<%#GetCheck(Eval("KhuyenMai").ToString()) %>' CommandArgument='<%#Eval("Id") %>' CommandName="khuyenmai" runat="server" />&nbsp;<%=Lang.Show("promotional")%><br /><asp:ImageButton ImageUrl='<%#GetCheck(Eval("BanChay").ToString()) %>' CommandArgument='<%#Eval("Id") %>' CommandName="banchay" runat="server" />&nbsp;<%=Lang.Show("selling")%>
                                </ItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("status")%></HeaderTemplate>
                                <ItemTemplate>
                                    <%#(Eval("TrangThai").ToString()=="1" ? Lang.Show("show") : Lang.Show("hide"))%>
                                </ItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                <HeaderTemplate>
                                    <%=Lang.Show("function") %>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <a href='<%#Eval("Id","/Admins/Common/TM_HangHoa_HinhAnh.aspx?id={0}") %>' title="<%=Lang.Show("imagemanage") %>">
                                    <img src="/Pic/image.png"  alt="hinh anh"/></a>&nbsp;|
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("Id")%>' 
                                        CommandName="Edit" CssClass="edit" ToolTip="...">&nbsp;</asp:LinkButton>
                                    |<asp:LinkButton ID="lbt2" runat="server" CommandArgument='<%#Eval("Id")%>' 
                                        CommandName="Delete" CssClass="delete" 
                                        OnClientClick="return confirm(&quot;bạn có muốn xóa không?&quot;)" 
                                        ToolTip="...">&nbsp;</asp:LinkButton>
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
    <asp:Panel ID="pn_updateTM_HangHoa" runat="server" Visible="False" Width="100%">
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
                    &nbsp;<%=Lang.Show("groupproduct") %>:
                </td>
                <td>
                    <asp:DropDownList CssClass="textbox" Height="30px" ID="ddlUNhomHangHoa" runat="server">
                    </asp:DropDownList>
                </td>
            </tr> 
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("productid") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMaSP" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorMaSP" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("productname") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTenSP" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblerrorTenSP" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr> 
            
            <tr>
                <td class="name_fild_row" width="150">&nbsp;<%=Lang.Show("addenglish") %>:</td>
                <td>
                    <asp:CheckBox ID="ckbaddenglish" runat="server" AutoPostBack="True" OnCheckedChanged="ckbaddenglish_CheckedChanged" />&nbsp;<%=Lang.Show("yes") %><br /><asp:DropDownList ID="dllanglish" runat="server" AutoPostBack="false" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="name_fild_row" width="150">&nbsp;<%=Lang.Show("introduction") %>: </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckMoTa" runat="server" BasePath="~/">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("appraise") %>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDanhGia" runat="server" Width="300px">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("warranty") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtBaoHanh" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp; <%=Lang.Show("keyword") %>: (SEO):
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtKeyword" TextMode="MultiLine" Height="50px" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("description") %>(SEO):
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtDescription" TextMode="MultiLine" Height="50px" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("status") %>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlTrangThai" runat="server" Width="300px">
                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                </td>
                <td>
                    <asp:CheckBox  ID="ckbKhuyenMai" runat="server" /> <%=Lang.Show("promotional") %><br />
                    <asp:CheckBox  ID="ckbBanChay" runat="server" /> <%=Lang.Show("selling") %>
                </td>
            </tr>
            
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="LbtUpdate_Click"><%=Lang.Show("update") %></asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click"><%=Lang.Show("back") %></asp:LinkButton><asp:CheckBox
                        ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
