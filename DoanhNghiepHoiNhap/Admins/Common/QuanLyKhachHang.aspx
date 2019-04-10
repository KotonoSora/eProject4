<%@ Page Title="Quản lý khách hàng" Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="QuanLyKhachHang.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.QuanLyKhachHang" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Common" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
         <%=Lang.Show("customermanagement")%>
        <%--Quản lý liên hệ--%>
    </div>
    <asp:Panel ID="pn_showTT_LienHe" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <asp:Button CssClass="button" OnClick="txtGuiEmail_Click" ID="txtGuiEmail" runat="server" Text =" Send Mail " />
                </td>
            </tr>
            <tr>
                <td height="6">
                    <asp:DataGrid ID="grd_showTT_LienHe" runat="server" AutoGenerateColumns="False" CssClass="tableview"
                        CellPadding="4" ForeColor="#333333" Width="100%"  
                         OnItemCommand="grd_showTT_LienHe_ItemCommand" >
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateColumn>
                               <ItemTemplate>
                                    <%#(Eval("TieuDe").ToString())%>
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblTieuDe" runat="server" Text='Liên hệ công ty V-starscraft'></asp:Label><%--<%#(Eval("TieuDe").ToString())%>--%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                          
                            <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("sentdate")%></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblNgayGui" runat="server" Text='<%#DateTimeClass.ConvertDateTime(Eval("NgayGui").ToString(),"dd/MM/yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                              <asp:TemplateColumn>
                                <HeaderTemplate><%=Lang.Show("sentby")%></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblNguoiGui" runat="server" Text='<%#(Eval("NguoiGui").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                             <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("company")%></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblCongTy" runat="server" Text='<%#(Eval("CongTy").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="grdLblMail" runat="server" Text='<%#(Eval("Mail").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <%--<asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("phone")%></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblSoDienThoai" runat="server" Text='<%#(Eval("SoDienThoai").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>--%>
                           
                            <asp:TemplateColumn >
                                <HeaderTemplate><%=Lang.Show("status")%></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="grdLblTrangThai" runat="server" Text='<%#ReturnTrangThai(Eval("TrangThai").ToString())%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate><%=Lang.Show("function") %></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="Edit"
                                        CssClass="edit" ToolTip="...">&nbsp;</asp:LinkButton>|<asp:LinkButton ID="lbt2" runat="server"
                                            CommandArgument='<%#Eval("ID")%>' CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Bạn có muốn xóa không?&quot;)"
                                            ToolTip="....">&nbsp;</asp:LinkButton>
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
    <asp:Panel ID="pn_updateTT_LienHe" runat="server" Visible="False" Width="100%">
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
                    &nbsp;
                    <asp:Label ID="lblUTieuDe" Text="Tiêu đề" runat="server"><%=Lang.Show("title") %>:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTieuDe" CssClass="textbox" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUNoiDung" Text="Nội dung" runat="server"><%=Lang.Show("content") %>:</asp:Label>
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckNoiDung" runat="server" BasePath="~/" 
                        ToolbarSet="Basic">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUNguoiGui" Text="Người gửi" runat="server"><%=Lang.Show("sentby") %>:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNguoiGui" CssClass="textbox" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUCongTy" Text="Công ty" runat="server"><%=Lang.Show("company") %>:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCongTy" CssClass="textbox" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUMail" Text="Email:" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMail" CssClass="textbox" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUNgayGui" Text="Ngày gửi" runat="server"><%=Lang.Show("sentdate") %>:</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="textbox" ID="txtNgayGui" Width="150px"></asp:TextBox>
                    
                </td>
            </tr>
          
            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;
                    <asp:Label ID="lblUSoDienThoai" Text="Số điện thoại" runat="server"><%=Lang.Show("phone") %>:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSoDienThoai" CssClass="textbox" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back" OnClick="LbtCancel_Click">Trở lại</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>