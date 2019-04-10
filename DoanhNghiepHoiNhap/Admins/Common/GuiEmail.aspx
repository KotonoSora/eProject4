<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Common/Common.Master" AutoEventWireup="true"
    CodeBehind="GuiEmail.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.GuiEmail" %>
<%@ Import Namespace="DoanhNghiepHoiNhap.Languages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <%=Lang.Show("send")%> email
    </div>
    <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
        cellpadding="0" width="100%" border="0">
        <tr>
            <td width="150" class="name_fild_row">
                <%=Lang.Show("scope")%> :
            </td>
            <td>
                <asp:DropDownList ID="ddlPhamVi" CssClass="textbox" Height="30px" Width="300px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPhamVi_SelectedIndexChanged">
                    <asp:ListItem Value="1" Text="Toàn bộ khách hàng" />
                    <asp:ListItem Value="2" Text="Lựa chọn khách hàng" />
                </asp:DropDownList>
                <asp:DataGrid ID="dgvLienHe" Visible="false" runat="server" AutoGenerateColumns="False" CssClass="tableview"
                        CellPadding="4" ForeColor="#333333" Width="300px">
                        <AlternatingItemStyle BackColor="White" />
                        <Columns> 
                            <asp:TemplateColumn ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" Checked="true" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="tdCenter"></ItemStyle>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label Text='<%#(Eval("Mail").ToString())%>' ID="txtEmail" runat="server" />
                                </ItemTemplate>
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
        <tr>
            <td width="150" class="name_fild_row">
                <%=Lang.Show("title")%> :
            </td>
            <td>
                <asp:TextBox ID="txtTieuDe" CssClass="textbox" Width="600px" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="150" class="name_fild_row">
                <%=Lang.Show("content")%> :
            </td>
            <td>
                <asp:TextBox ID="txtNoiDung" TextMode="MultiLine" Width="600px" Height="200px" CssClass="textbox" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="150" class="name_fild_row">
               &nbsp;
            </td>
            <td>
                <asp:Button ID="btnGui" CssClass="button" OnClick="btnGui_Click" Text="Send" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
