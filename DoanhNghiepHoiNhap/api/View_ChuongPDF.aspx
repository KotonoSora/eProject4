<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_ChuongPDF.aspx.cs" Inherits="DoanhNghiepHoiNhap.api.View_ChuongPDF" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
            font-size: 14px;
            font-family: Tahoma;
            vertical-align: baseline;
            background: transparent;
            line-height: 150%;
        }

        #wraper {
            padding: 10px;
        }

            #wraper img {
                width: 100%;
            }

        .classfull {
            width: 100%;
        }

        .class_text {
            text-align: center;
        }

        .title_in {
            color: #0068b4;
            font-size: 1.5em;
            padding: 20px;
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
            <div class="classfull">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
