<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_ChuongQuyenSachKinhTe.aspx.cs" Inherits="DoanhNghiepHoiNhap.api.View_ChuongQuyenSachKinhTe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        html, body, div, span, p, a, img, b, i, ul, li, form, table, tbody, tr, td {
            margin: 0;
            padding: 0;
            border: 0;
            outline: 0;
            font-size: 15px;
            font-family: Tahoma;
            vertical-align: baseline;
            /*background: transparent;*/
            background: #f3eded4d;
            line-height: 150%;
        }

        #wraper {
            padding: 10px;
        }

            #wraper img {
                width: 100%;
            }

        .classfull {
            padding-top: 35px;
            text-align: justify;
        }

        .class_text {
            text-align: center;
            position: fixed;
            opacity: .75;
            filter: alpha(opacity=75);
            -moz-opacity: 0.75;
            z-index: 100;
            top: 0px;
            line-height: 35px;
            height: 35px;
            width: 100%;
            left: 0px;
            background: #dddcdc;
        }

        .title_in {
            color: #ff0000;
            font-size: 1.2em;
            padding: 1px;
            text-transform: uppercase;
        }

        .classfull table tr td {
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wraper" class="">
            <div class="title_in classfull class_text">
                <asp:Label ID="Label2" runat="server" Text="" Font-Size="9px" Font-Italic="true"></asp:Label>
            </div>
            <div class="classfull">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
