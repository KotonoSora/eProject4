<%@ Page Title="Cấu hình chung hệ thống" Language="C#" MasterPageFile="~/Admins/Common/Common.Master"
    AutoEventWireup="true" CodeBehind="TT_CauHinhChung.aspx.cs" Inherits="DoanhNghiepHoiNhap.Admins.TT_CauHinhChung" %>

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

            $("#btnLogo").click(function () {
                var finder = new CKFinder();
                finder.selectActionFunction = function (fileUrl) {
                    $('#<%=txtLogo.ClientID %>').val(fileUrl);
                    $('#<%=imgLogo.ClientID %>').attr("src", fileUrl);
                };
                finder.popup();
            });
        });
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <%=Lang.Show("generalconfig")%></div>
    <asp:Panel ID="pn_updateTT_CauHinhChung" runat="server" Width="100%">
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
                    &nbsp;Logo:<br/>(<%=Lang.Show("size") %>: 320x240px)
                </td>
                <td>
                    <asp:TextBox ID="txtLogo" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <input class="button" type="button" id="btnLogo" value="..." /><br />
                    <asp:Image ID="imgLogo" runat="server"/>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("image")%> banner:<br/>(<%=Lang.Show("size") %>: 730x240px)
                </td>
                <td>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    <input class="button" type="button" id="btnSelectImg" value="..." /><br />
                    <asp:Image ID="imgHinhAnh" runat="server"/>
                </td>
            </tr> 
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("content")%> Footer:
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckFooter" runat="server" BasePath="~/" Height="400px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("contactinfo")%>:
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckThongTinLienHe" runat="server" BasePath="~/" Height="300px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("contactinfo2")%>:
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckThongTinLienHe2" runat="server" BasePath="~/" Height="300px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("contactinfo3")%>:
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckThongTinLienHe3" runat="server" BasePath="~/" Height="300px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>


            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("title") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTieuDe" runat="server" Width="556px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("description") %> (SEO):
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtDescription" runat="server" Width="556px" Height="50px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("keyword") %> (SEO):
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtKeyword" runat="server" Width="556px" Height="50px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;Email:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("password")%> email:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;Facebook:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtFacebook" runat="server" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <%--/ Mới thêm vào /--%>
            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;Google+:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtGooglePlus" runat="server" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;Twitter:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTwitter" runat="server" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;Youtube:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtYoutube" runat="server" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("Maps") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtBanDo" runat="server" Width="550px"></asp:TextBox>
                </td>
            </tr> 

            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("Sdt") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtSDT" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr> 

            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("gmaildescription") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMotaGmail" runat="server" Width="550px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                </td>
            </tr> 

              <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("calldescription") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMotaCall" runat="server" Width="550px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                </td>
            </tr> 

              <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("tweetsdescription") %>:
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtMotaTweet" runat="server" Width="550px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                </td>
            </tr> 

            <tr style="display:none">
                <td width="150" class="name_fild_row">
                    &nbsp;<%=Lang.Show("descriptionvisit") %>:
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckMotavisit" runat="server" BasePath="~/" Height="200px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr> 

            <tr style="display:none">
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
                    &nbsp;<asp:LinkButton ID="lbtUpdate_CauHinhChung" CssClass="update" 
                        runat="server" OnClick="LbtUpdate_Click">Cập nhật</asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtCancel" runat="server" CssClass="back">Trở lại</asp:LinkButton><asp:CheckBox
                        ID="Insert" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
