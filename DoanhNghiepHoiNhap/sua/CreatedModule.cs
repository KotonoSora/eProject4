using System;
using System.Data;
using DoanhNghiepHoiNhap.Business;

public class CreatedModule
{
    public string BaiDocNhieu(string NgonNgu)
    {
        string s = "<div id=\"Tindocnhieu\">\n<div class=\"header-module\">\n<div class=\"left-header-module\">\n</div>\n<div class=\"center-header-module\">BÀI ĐỌC NHIỀU NHẤT</div>\n<div class=\"right-header-module\">\n</div>\n</div>";
        s += "<div class=\"content-module\">\n<ul>";
        var dt = CommonService.TinTuc_NhomTin_GetByTop("5", "XetDuyet = 4 And NgonNgu = " + NgonNgu + "", "LuotXem Desc");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string t = dt.Rows[i]["TieuDe"].ToString();
            s += "<li><a title=\"" + dt.Rows[i]["TieuDe"] + "\" href=\"/" + dt.Rows[i]["NhomTin_Tag"] + "/" + dt.Rows[i]["Tag"] + ".aspx\">" + t + "</a></li>";
        }
        s += "</ul></div></div>";
        return s;
    }
    //public string QuangCaoPhai()
    //{
    //    string str = "";

    //    var dt = TT_QuangCaoService.TT_QuangCao_GetByTop("1000", "NgayBatDau < '" + DateTime.Now + "' AND NgayKetThuc > '" + DateTime.Now + "' AND VITRI = 2", "ThuTu");

    //    string s = "";
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        s += "<a href=\"" + dt.Rows[i]["Link"] + "\" target=\"_blank\">";
    //        s += "<img src=\"" + dt.Rows[i]["HinhAnh"].ToString().Remove(0, 1) + "\" alt='" +
    //             dt.Rows[i]["TenQuangCao"] + "' /></a>";
    //    }

    //    str += "<div id=\"SlideShow2\" onmouseover=\"BaoOnMouseHover2()\" onmouseout=\"BaoOnMouseOut2()\">";
    //    str += "<div id=\"IdTruot21\" class=\"Truot2\">";
    //    str += "<div id=\"contentIdTruot21\" class=\"TruotContent2\">";
    //    str += s;
    //    str += " </div>";
    //    str += "  </div>";
    //    str += "  <div id=\"IdTruot22\" class=\"Truot2\">";
    //    str += "    <div id=\"contentIdTruot22\" class=\"TruotContent2\">";
    //    str += s;
    //    str += "   </div>";
    //    str += "   </div>";
    //    str += "    </div>";

    //    return str;

    //}
    public string QuangCaoPhai()
    {
        // chưa where position, fix lại độ rộng, cao
        string s = "<div id=\"QuangCaoPhai\">";
        var dt = TT_QuangCaoService.TT_QuangCao_GetByTop("2", "NgayBatDau < '" + DateTime.Now + "' AND NgayKetThuc > '" + DateTime.Now + "' AND VITRI = 2", "ThuTu");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string t = "<div style=\"width:315px; text-align:center; margin-top:5px;\">";
            string path = dt.Rows[i]["HinhAnh"].ToString();
            path = path.Remove(0, 1);
            if (path.IndexOf(".swf") > 0)
            {
                // fix height, width
                t += "<embed src=\"" + path + "\" height=\"90\" align=\"middle\" width=\"315\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" wmode=\"transparent\" quality=\"high\">";
                //
            }
            else
            {
                // fix height, width
                t += "<a href=\"" + dt.Rows[i]["Link"] + "\" target=\"_blank\"\"><img src='" + path + "' runat='server' style='border:0px' width='315px' height='90px' />";
            }
            t += "</div>";
            s += t;
        }
        s += "</div>";
        return s;
    }
    public string QuangCaoBanner(string nhomtin)
    {
        // chưa where position
        string s = "<div id=\"QuangCaoBanner\">";
        var dt = TT_QuangCaoService.TT_QuangCao_GetByViTri_NhomTin("1", nhomtin);
        if (dt.Rows.Count > 0)
        {
            string t = "<div style=\"width:540px; text-align:center;\">";
            string path = dt.Rows[0]["HinhAnh"].ToString();
            path = path.Remove(0, 1);
            if (path.IndexOf(".swf") > 0)
            {
                // fix height, width
                t += "<embed src=\"" + path + "\" height=\"104\" align=\"middle\" width=\"530\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" wmode=\"transparent\" quality=\"high\">";
            }
            else
            {
                // fix height, width
                t += "<a href=\"" + dt.Rows[0]["Link"] + "\" target=\"_blank\"\"><img src='" + path + "' runat='server' style='border:0px' width='530px' height='104px' />";
            }
            t += "</div></div>";
            return s + t;
        }
        else return "";
    }
    public string Top1TinMoiNhat(string NgonNgu, ref string id)
    {
        //edit truy van, style width height for img
        var dt = TT_TinHotService.TT_TinHot_NhomTin_GetByTop("3", "XetDuyet = 4 And NgonNgu = " + NgonNgu + " AND Loai = 1 AND DATEADD(Hour, TT_TinHot.SoGio, dbo.TT_TinHot.NgayGioBatDau) > GetDate() AND HienTrangChu = 1 AND dbo.TT_TinHot.NgayGioBatDau < GetDate() ", "");
        if (dt.Rows.Count == 0)
        {
            dt = CommonService.TinTuc_NhomTin_GetByTop("3", "XetDuyet = 4 And NgonNgu = " + NgonNgu + "", "ID DESC");
        }
        if (dt.Rows.Count == 0) return "";
        id = "";
        string s = "<div id=\"top1\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            id += dt.Rows[i]["Id"] + ",";
            s += "<div id=\"newtop1\">";
            string path = dt.Rows[i]["HinhAnh"].ToString();
            if (path != "")
                path = path.Remove(0, 1);
            s += "<a href=\"/" + dt.Rows[i]["NhomTin_Tag"] + "/" + dt.Rows[i]["Tag"] +
                 ".aspx\"><img style=\"margin-bottom:5px\" src=\"" + path +
                 "\" width=\"440px\" height=\"215px\"\"></img></a>";
            s += "<h3><a style=\"font-size:25px;font-family:tahoma;\" href=\"/" + dt.Rows[i]["NhomTin_Tag"] + "/" +
                 dt.Rows[i]["Tag"] + ".aspx\">" + dt.Rows[i]["TieuDe"] + "</a></h3>";
            s += "<p style=\"font-size: 16px;font-family:tahoma;color:#231F20;\">" + dt.Rows[i]["TomTat"] + "</p>";
            s += "</div>";
        }
        s += "<div class=\"number_top1\"></div>";
        s += "</div>";
        id = id.Remove(id.Length - 1, 1);
        return s;
    }
    public string Top3TinMoiTiepTheo(string NgonNgu, ref string ids)
    {
        var dt1 = new DataTable();
        var dt = TT_TinHotService.TT_TinHot_NhomTin_GetByTop("3", "XetDuyet = 4 And NgonNgu = " + NgonNgu + " AND Loai != 1 AND DATEADD(Hour, TT_TinHot.SoGio, dbo.TT_TinHot.NgayGioBatDau) > GetDate() AND HienTrangChu = 1 AND dbo.TT_TinHot.NgayGioBatDau < GetDate()", "ThuTu");
        int tt = 3 - dt.Rows.Count;
        if (tt != 0)
        {
            var top1 = TT_TinHotService.TT_TinHot_NhomTin_GetByTop("1", "XetDuyet = 4 And NgonNgu = " + NgonNgu + " AND Loai = 1 AND DATEADD(Hour, TT_TinHot.SoGio, dbo.TT_TinHot.NgayGioBatDau) > GetDate()", "");
            if (top1.Rows.Count == 0)
                dt1 = CommonService.TinTuc_NhomTin_GetByTop(tt.ToString(), "XetDuyet = 4 And NgonNgu = " + NgonNgu + " AND TT_TinTuc.Id <>(SELECT TOP (1) ID FROM TT_TINTUC WHERE XETDUYET = 4 AND NGONNGU =" + NgonNgu + " ORDER BY ID DESC)", "ID DESC");
            else dt1 = CommonService.TinTuc_NhomTin_GetByTop(tt.ToString(), "XetDuyet = 4 And NgonNgu = " + NgonNgu + "", "ID DESC");
        }
        string s = "<div id=\"top3\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ids += dt.Rows[i]["Id"] + ",";
            s += "<div class=\"NewTop3\">";
            s += "<p><a href=\"/" + dt.Rows[i]["NhomTin_Tag"] + "/" + dt.Rows[i]["tag"] + ".aspx\">" + dt.Rows[i]["TieuDe"] + "</a></p>";
            string t = dt.Rows[i]["TomTat"].ToString();
            s += "<p class=\"trichdan\">" + t + "</p>";
            s += "</div>";
        }
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            ids += dt1.Rows[i]["Id"] + ",";
            s += "<div class=\"NewTop3\">";
            s += "<p><a href=\"/" + dt1.Rows[i]["NhomTin_Tag"] + "/" + dt1.Rows[i]["tag"] + ".aspx\">" + dt1.Rows[i]["TieuDe"] + "</a></p>";
            string t = dt1.Rows[i]["TomTat"].ToString();
            s += "<p class=\"trichdan\">" + t + "</p>";
            s += "</div>";
        }
        s += "</div>";
        if (ids.Length > 0) ids = ids.Remove(ids.Length - 1, 1);//Bỏ dấu , cuối cùng
        return s;
    }
    public string Top1TinMoiTiepTheo(string NgonNgu, string loaibo)
    {
        var tag = TT_ThuTuNhomTinService.TT_ThuTuNhomTin_GetByThuTu("1", NgonNgu);
        if (tag.Rows.Count == 0) return "";
        var new1 = CommonService.TinTuc_NhomTin_GetByTop("1", "TT_NhomTin.Tag = '" + tag.Rows[0]["Tag"] + "' AND XETDUYET = 4 AND TT_TinTuc.Id NOT IN(" + loaibo + ")", "TT_TinTuc.Id desc");
        if (new1.Rows.Count == 0) return "";
        string s = "<div id=\"top1tieptheo\">";
        s += "<div class=\"groupnew-name\"><a style=\"color:#616264\" href=\"/" + new1.Rows[0]["NhomTin_Tag"] + ".aspx\">" + new1.Rows[0]["Ten"] + "</a></div>";
        //s += "<a style=\"img-groupnew-home\" href=\"/" + new1.Rows[0]["NhomTin_Tag"] + "/" + new1.Rows[0]["tag"] + ".aspx\">" + new1.Rows[0]["HinhAnh"] + "</a>";
        s += "<h3><a style=\"font-size:14px;\" href=\"/" + new1.Rows[0]["NhomTin_Tag"] + "/" + new1.Rows[0]["tag"] + ".aspx\">" + new1.Rows[0]["tieude"] + "</a></h3>";
        s += "<p class=\"trichdan\">" + new1.Rows[0]["TomTat"] + "</p>";
        s += "</div>";
        return s;
    }
    public string DoanhNghiepTieuBieu()
    {
        string s = "<div id=\"mygallery\" class=\"stepcarousel\"><marquee direction=\"left\" scrolldelay=\"1\" scrollamount=\"2\" onmouseover=\"this.stop()\" onmouseout=\"this.start()\">";
        var dt = TT_DoanhNghiepService.TT_DoanhNghiep_GetByTop("1000", "", "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            // fix height, width
            string path = dt.Rows[i]["Hinhanh"].ToString().Remove(0, 1);
            string t = "<div class='panel'><a href=\"" + dt.Rows[i]["Website"] + "\" target=\"_blank\"\"><img style='width:180px;height:135px;margin:1px;' src='" + path + "' title=\"" + dt.Rows[i]["Ten"] + "\" /></a></div>";
            s += t;
        }
        s += "</marquee></div>";
        return s;
    }
    public string nhomtin_thutu24(string ThuTu, string NgonNgu, string loaibo)
    {
        var tag = TT_ThuTuNhomTinService.TT_ThuTuNhomTin_GetByThuTu(ThuTu, NgonNgu);
        if (tag.Rows.Count == 0) return "";
        string nhomtin_id = tag.Rows[0]["ID"].ToString();
        var child = TT_NhomTinService.TT_NhomTin_GetByTop("1000", "Cha = " + tag.Rows[0]["ID"] + "", "");
        string tinin = nhomtin_id;
        for (int i = 0; i < child.Rows.Count; i++)
        {
            tinin += "," + child.Rows[i]["Id"];
        }
        var tin = CommonService.TinTuc_NhomTin_GetByTop("4", "TT_TinTuc.NhomTin IN (" + tinin + ") AND XETDUYET = 4 AND TT_TinTuc.Id NOT IN(" + loaibo + ")", "TT_TinTuc.ID DESC");
        if (tin.Rows.Count == 0) return "";
        string s = "";
        s += "<div id=\"groupnew" + ThuTu + "\">";
        s += "<a class=\"groupnew-name\" href=\"/" + tag.Rows[0]["Tag"] + ".aspx\" style=\"color:#616264\">" + tag.Rows[0]["Ten"] + "</a>";
        s += " <div class=\"top-groupnew-home\">";
        string path = tin.Rows[0]["HinhAnh"].ToString();
        if (path != "")
            path = path.Remove(0, 1);
        s += "<div class=\"img-groupnew-home\"><a href=\"/" + tin.Rows[0]["NhomTin_Tag"] + "/" + tin.Rows[0]["tag"] + ".aspx\"><image width=\"103px\" height=\"57px\" style=\"margin:1px;\" src=\"" + path + "\"/></a></div>";
        s += "<div class=\"title-groupnew-home\"><a href=\"/" + tin.Rows[0]["NhomTin_Tag"] + "/" + tin.Rows[0]["tag"] + ".aspx\">" + tin.Rows[0]["TieuDe"] + "</a></div>";
        s += "</div><ul class=\"ul-groupnew-home\">";
        for (int j = 1; j < tin.Rows.Count; j++)
        {
            s += "<li><a href=\"/" + tin.Rows[j]["NhomTin_Tag"] + "/" + tin.Rows[j]["tag"] + ".aspx\">" + tin.Rows[j]["TieuDe"] + "</a></li>";
        }
        s += "</ul>";
        s += "</div>";
        return s;

    }
    public string nhomtin_8(string NgonNgu, string loaibo)
    {
        string s = "<div id=\"group8\">";
        var tag = TT_ThuTuNhomTinService.TT_ThuTuNhomTin_GetByThuTu("8", NgonNgu);
        if (tag.Rows.Count == 0) return "";
        string nhomtin_id = tag.Rows[0]["ID"].ToString();
        var child = TT_NhomTinService.TT_NhomTin_GetByTop("1000", "Cha = " + tag.Rows[0]["ID"] + "", "");
        string tinin = nhomtin_id;
        for (int i = 0; i < child.Rows.Count; i++)
        {
            tinin += "," + child.Rows[i]["Id"];
        }
        var tin = CommonService.TinTuc_NhomTin_GetByTop("2", "TT_TinTuc.NhomTin IN (" + tinin + ") AND XETDUYET = 4 AND TT_TinTuc.Id NOT IN(" + loaibo + ")", "TT_TinTuc.Id desc");
        if (tin.Rows.Count == 0) return "";
        s += "<a class=\"groupnew-name\" href=\"/" + tag.Rows[0]["Tag"] + ".aspx\" style=\"color:#616264\">" + tag.Rows[0]["Ten"] + "</a>";
        s += "<div class=\"group-new-chuyende\">";
        string path = tin.Rows[0]["HinhAnh"].ToString();
        if (path != "")
            path = path.Remove(0, 1);
        s += "<a href=\"" + tin.Rows[0]["NhomTin_Tag"] + "/" + tin.Rows[0]["tag"] + ".aspx\"\"><img src=\"" + path + "\" style=\"float:left\" width=\"103px\" height=\"57px\"></a>";
        s += "<div class=\"title-chuyende\"><p><a style=\"font-weight:bold;font-size:13px;\"href=\"" + tin.Rows[0]["NhomTin_Tag"] + "/" + tin.Rows[0]["tag"] + ".aspx\"\">" + tin.Rows[0]["TieuDe"] + "</a></p>";
        if (tin.Rows.Count == 1)
            s += "</div>";
        else
            s += "<p class=\"child2\"><a style=\"font-weight:bold;font-size:13px;\" href=\"" + tin.Rows[1]["NhomTin_Tag"] + "/" + tin.Rows[1]["tag"] + ".aspx\"\">" + tin.Rows[1]["TieuDe"] + "</a></p></div>";
        s += "</div></div>";
        return s;
    }
    public string nhomtin_9(string NgonNgu, string loaibo)
    {
        string s = "<div id=\"group9\">";
        var tag = TT_ThuTuNhomTinService.TT_ThuTuNhomTin_GetByThuTu("9", NgonNgu);
        if (tag.Rows.Count == 0) return "";
        string nhomtin_id = tag.Rows[0]["ID"].ToString();
        var child = TT_NhomTinService.TT_NhomTin_GetByTop("1000", "Cha = " + tag.Rows[0]["ID"] + "", "");
        string tinin = nhomtin_id;
        for (int i = 0; i < child.Rows.Count; i++)
        {
            tinin += "," + child.Rows[i]["Id"];
        }
        var tin = CommonService.TinTuc_NhomTin_GetByTop("3", "TT_TinTuc.NhomTin IN (" + tinin + ") AND XETDUYET = 4 AND TT_TinTuc.Id NOT IN(" + loaibo + ")", "TT_TinTuc.Id desc");
        if (tin.Rows.Count == 0) return "";
        s += "<a class=\"groupnew-name\" href=\"/" + tag.Rows[0]["Tag"] + ".aspx\" style=\"color:#616264\">" + tag.Rows[0]["Ten"] + "</a>";
        s += "<ul>";
        for (int i = 0; i < tin.Rows.Count; i++)
        {
            s += "<li><a style=\"font-weight:bold;font-size:13px;\" title=\"" + tin.Rows[i]["TieuDe"] + "\" href=\"/" + tin.Rows[i]["NhomTin_Tag"] + "/" + tin.Rows[i]["Tag"] + ".aspx\">" + tin.Rows[i]["TieuDe"] + "</a></li>";
        }
        s += "</ul>";
        s += "</div>";
        return s;
    }
    public string nhomtin_10(string NgonNgu, string loaibo)
    {
        string s = "<div id=\"group10\">";
        var tag = TT_ThuTuNhomTinService.TT_ThuTuNhomTin_GetByThuTu("10", NgonNgu);
        if (tag.Rows.Count == 0) return "";
        string nhomtin_id = tag.Rows[0]["ID"].ToString();
        var child = TT_NhomTinService.TT_NhomTin_GetByTop("1000", "Cha = " + tag.Rows[0]["ID"] + "", "");
        string tinin = nhomtin_id;
        for (int i = 0; i < child.Rows.Count; i++)
        {
            tinin += "," + child.Rows[i]["Id"];
        }
        var tin = CommonService.TinTuc_NhomTin_GetByTop("3", "TT_TinTuc.NhomTin IN (" + tinin + ") AND XETDUYET = 4 AND TT_TinTuc.Id NOT IN(" + loaibo + ")", "TT_TinTuc.Id desc");
        if (tin.Rows.Count == 0) return "";
        s += "<a class=\"groupnew-name\" href=\"/" + tag.Rows[0]["Tag"] + ".aspx\" style=\"color:#616264\">" + tag.Rows[0]["Ten"] + "</a>";
        s += "<div class=\"group-new-chuyende\">";
        string path = tin.Rows[0]["HinhAnh"].ToString();
        if (path != "")
            path = path.Remove(0, 1);
        s += "<a href=\"/" + tin.Rows[0]["NhomTin_Tag"] + "/" + tin.Rows[0]["Tag"] + ".aspx\"><img src=\"" + path + "\" style=\"float:left\" width=\"103px\" height=\"57px\"></a>";
        s += "<div class=\"title-group10\">";
        s += "<ul>";
        for (int i = 0; i < tin.Rows.Count; i++)
        {
            string t = tin.Rows[i]["TieuDe"].ToString();
            s += "<li><a title=\"" + tin.Rows[i]["TieuDe"] + "\" style=\"font-size:13px;\" href=\"/" + tin.Rows[i]["NhomTin_Tag"] + "/" + tin.Rows[i]["Tag"] + ".aspx\">" + t + "</a></li>";
        }
        s += "</ul>";
        s += "</div></div></div>";
        return s;
    }
    public string nhomtin_right(string NgonNgu, string loaibo)
    {
        var tag = TT_ThuTuNhomTinService.TT_ThuTuNhomTin_GetByThuTu("5", NgonNgu);
        if (tag.Rows.Count == 0) return "";
        string nhomtin_id = tag.Rows[0]["ID"].ToString();
        var child = TT_NhomTinService.TT_NhomTin_GetByTop("1000", "Cha = " + tag.Rows[0]["ID"] + "", "");
        string tinin = nhomtin_id;
        for (int i = 0; i < child.Rows.Count; i++)
        {
            tinin += "," + child.Rows[i]["Id"];
        }
        var tin = CommonService.TinTuc_NhomTin_GetByTop("4", "TT_TinTuc.NhomTin IN (" + tinin + ") AND XETDUYET = 4 and TT_TinTuc.Id not in(" + loaibo + ")", "TT_TinTuc.Id desc");
        if (tin.Rows.Count == 0) return "";
        string s = "";
        s += "<div id=\"groupnew5\">";
        s += "<a class=\"groupnew-name\" href=\"/" + tag.Rows[0]["Tag"] + ".aspx\" style=\"color:#616264\">" + tag.Rows[0]["Ten"] + "</a>";
        s += " <div class=\"top-groupnew-home\">";
        string path = tin.Rows[0]["HinhAnh"].ToString();
        if (path != "")
            path = path.Remove(0, 1);
        s += "<div style=\"width:320px; height:105px; padding:5px; float:left;\"><a class=\"title-groupnew-5\" href=\"/" + tin.Rows[0]["NhomTin_Tag"] + "/" + tin.Rows[0]["tag"] + ".aspx\"><image width=\"197px\" height=\"105px\" style=\"margin:1px;\" src=\"" + path + "\"/></a></div>";
        s += "<div style=\"width:320px;padding:5px;  float:left;\"><a class=\"title-groupnew-5\" href=\"/" + tin.Rows[0]["NhomTin_Tag"] + "/" + tin.Rows[0]["tag"] + ".aspx\">" + tin.Rows[0]["TieuDe"] + "</a></div>";
        s += "<div style=\"width:320px; padding:5px; float:left; text-align:justify\"><p style=\"font-size:12px;\">" + tin.Rows[0]["TomTat"] + "</p></div>";
        s += "</div><ul class=\"ul-groupnew-home\">";
        for (int j = 1; j < tin.Rows.Count; j++)
        {
            s += "<li><a href=\"/" + tin.Rows[j]["NhomTin_Tag"] + "/" + tin.Rows[j]["tag"] + ".aspx\">" + tin.Rows[j]["TieuDe"] + "</a></li>";
        }
        s += "</ul>";
        s += "</div>";
        return s;
    }
    public string nhomtin_left(string NgonNgu, string loaibo)
    {
        return nhomtin_thutu24("2", NgonNgu, loaibo) + nhomtin_thutu24("3", NgonNgu, loaibo) + nhomtin_thutu24("4", NgonNgu, loaibo);
    }
    public string tigia_new()
    {
        string s = "";
        s += "<div id=\"tabbed_box_1\" class=\"tabbed_box\">";
        s += "<div class=\"tabbed_area\">";
        s += "<ul class=\"tabs\">";
        s += "<li><a href=\"javascript:;\" title=\"content_1\" class=\"tab active\">Tỉ giá</a></li>";
        s += "<li><a href=\"javascript:;\" title=\"content_2\" class=\"tab\">Giá vàng</a></li>";
        s += "</ul>";
        s += "<div style=\"display: block;\" id=\"content_1\" class=\"content\">";
        s += tigia();
        s += "</div>";
        s += "<div style=\"display: none;\" id=\"content_2\" class=\"content\">";
        s += giavang();
        s += "</div></div></div>";
        return s;
    }
    public string tigia()
    {

        #region[Ti gia ngoai te]
        string Url = "http://vietcombank.com.vn/exchangerates/exrateXML.aspx";
        DataSet ds = new DataSet();
        try { ds.ReadXml(Url); }
        catch
        {
            return "";
        }
        if (ds.Tables.Count > 0)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CurrencyCode", typeof(string));
                dt.Columns.Add("Sell", typeof(string));
                DataTable dt1 = new DataTable();
                dt1 = ds.Tables["Exrate"];

                #region[Add row]

                DataRow usd = dt.NewRow();
                usd["CurrencyCode"] = dt1.Rows[17]["CurrencyCode"];
                usd["Sell"] = dt1.Rows[17]["Sell"];
                dt.Rows.Add(usd);

                DataRow gbp = dt.NewRow();
                gbp["CurrencyCode"] = dt1.Rows[5]["CurrencyCode"];
                gbp["Sell"] = dt1.Rows[5]["Sell"];
                dt.Rows.Add(gbp);

                DataRow hkd = dt.NewRow();
                hkd["CurrencyCode"] = dt1.Rows[6]["CurrencyCode"];
                hkd["Sell"] = dt1.Rows[6]["Sell"];
                dt.Rows.Add(hkd);

                DataRow chf = dt.NewRow();
                chf["CurrencyCode"] = dt1.Rows[2]["CurrencyCode"];
                chf["Sell"] = dt1.Rows[2]["Sell"];
                dt.Rows.Add(chf);

                DataRow jpy = dt.NewRow();
                jpy["CurrencyCode"] = dt1.Rows[9]["CurrencyCode"];
                jpy["Sell"] = dt1.Rows[9]["Sell"];
                dt.Rows.Add(jpy);

                DataRow aud = dt.NewRow();
                aud["CurrencyCode"] = dt1.Rows[0]["CurrencyCode"];
                aud["Sell"] = dt1.Rows[0]["Sell"];
                dt.Rows.Add(aud);

                DataRow cad = dt.NewRow();
                cad["CurrencyCode"] = dt1.Rows[1]["CurrencyCode"];
                cad["Sell"] = dt1.Rows[1]["Sell"];
                dt.Rows.Add(cad);

                #endregion

                string s = "<div id=\"tigia\">";
                s += "<div id=\"box-tigia\">";
                s += "<table id=\"tbltigia\" border=\"0px\" cellpadding=\"0\" cellspacing=\"0\">";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    s += "<tr><td class=\"trai\">" + dt.Rows[i]["CurrencyCode"] + "</td><td class=\"phai\">" +
                         dt.Rows[i]["Sell"] + "</td></tr>";
                }
                //s += "<tr><td colspan=\"2\" style=\" font-size: 10px; font-style: italic; text-align: center; color: #919090;\" align=\"center\">(Nguồn: <a target=\"_blank\" href=\"http://www.eximbank.com.vn\"><img src=\"/Pic/logo-EXIM.gif\" style=\"border:0px;vertical-align:middle\"></a>) </td> </tr>";
                s += "<tr><td colspan=\"2\">" + thoitiet() + "</td></tr>";
                s += "</table></div></div>";
                return s;
            }
            catch
            {
                return "";
            }
        }
        #endregion
        return "";
    }
    public string giavang()
    {
        string Url = "http://www.sjc.com.vn/xml/tygiavang.xml";
        DataSet ds = new DataSet();
        ds.ReadXml(Url);
        if (ds != null && ds.Tables.Count > 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("buy", typeof(string));
            dt.Columns.Add("sell", typeof(string));
            dt.Columns.Add("type", typeof(string));

            for (int i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["buy"] = ds.Tables["item"].Rows[i]["buy"].ToString();
                dr["sell"] = ds.Tables["item"].Rows[i]["sell"].ToString();
                dr["type"] = ds.Tables["item"].Rows[i]["type"].ToString();
                dt.Rows.Add(dr);
            }
            string s = "<div id=\"giavang\">";
            s += "<div id=\"box-giavang\">";
            s += "<table id=\"tblgiavang\" border=\"0px\" cellpadding=\"0\" cellspacing=\"0\">";
            s += "<tr style=\"font-weight:bold\"><td class=\"trai-vang\">Loại vàng</td><td class=\"giua-vang\">Mua vào</td><td class=\"phai-vang\">Bán ra</td></tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s += "<tr><td class=\"trai-vang\">" + dt.Rows[i]["type"] + "</td><td class=\"giua-vang\">" + dt.Rows[i]["buy"] + "</td><td class=\"phai-vang\">" + dt.Rows[i]["sell"] + "</td></tr>";
            }
            //s += "<tr><td colspan=\"2\" style=\" font-size: 10px; font-style: italic; text-align: center; color: #919090;\" align=\"center\">(Nguồn: <a target=\"_blank\" href=\"http://www.sjc.com.vn/\"><img width=\"20px\" height=\"20px\" src=\"/Pic/logo-sjc.gif\" style=\"border:0px;vertical-align:middle\"></a>) </td> </tr>";
            s += "<tr><td colspan=\"3\">" + thoitiet() + "</td></tr>";
            s += "</table></div></div>";
            return s;
        }
        return "";
    }
    public string thoitiet()
    {
        string s = "<div id=\"dubaothoitiet\">";
        s += "<div id=\"city\">";
        #region[HaNoi]
        s += "<div id=\"hn\">";
        DataSet dshanoi = new DataSet();
        dshanoi.ReadXml("http://vnexpress.net/ListFile/Weather/hanoi.xml");
        DataTable tbhanoi = dshanoi.Tables[0];
        if (tbhanoi.Rows[0][0].ToString().Trim() != "")
            s += "&nbsp;<img src='http://vnexpress.net/Images/Weather/" +
                tbhanoi.Rows[0][0].ToString().Trim() + "'>";
        if (tbhanoi.Rows[0][1].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/"
                + tbhanoi.Rows[0][1].ToString().Trim() + "'>";
        if (tbhanoi.Rows[0][2].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/" + tbhanoi.Rows[0][2].ToString().Trim() +
                 "'>";
        s += "<img src='http://vnexpress.net/Images/Weather/c.gif'>";
        s += "<div class=\"city1\">";
        s += tbhanoi.Rows[0][6].ToString().Trim();
        s += "</div>";
        dshanoi.Dispose();
        s += "</div>";
        #endregion
        #region[HCM]
        s += "<div id=\"hcm\" style=\"display: none;\">";
        DataSet dshcm = new DataSet();
        dshcm.ReadXml("http://vnexpress.net/ListFile/Weather/hcm.xml");
        DataTable tbhcm = dshcm.Tables[0];
        if (tbhcm.Rows[0][0].ToString().Trim() != "")
            s += "&nbsp;<img src='http://vnexpress.net/Images/Weather/" +
                tbhcm.Rows[0][0].ToString().Trim() + "'>";
        if (tbhcm.Rows[0][1].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/"
                + tbhcm.Rows[0][1].ToString().Trim() + "'>";
        if (tbhcm.Rows[0][2].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/" + tbhcm.Rows[0][2].ToString().Trim() +
                 "'>";
        s += "<img src='http://vnexpress.net/Images/Weather/c.gif'>";
        s += "<div class=\"city1\">";
        s += tbhcm.Rows[0][6].ToString().Trim();
        s += "</div>";
        dshcm.Dispose();
        s += "</div>";
        #endregion
        #region[DaNang]
        s += "<div id=\"dn\" style=\"display: none;\">";
        DataSet dsdn = new DataSet();
        dsdn.ReadXml("http://vnexpress.net/ListFile/Weather/Danang.xml");
        DataTable tbdn = dsdn.Tables[0];
        if (tbdn.Rows[0][0].ToString().Trim() != "")
            s += "&nbsp;<img src='http://vnexpress.net/Images/Weather/" +
                tbdn.Rows[0][0].ToString().Trim() + "'>";
        if (tbdn.Rows[0][1].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/"
                + tbdn.Rows[0][1].ToString().Trim() + "'>";
        if (tbdn.Rows[0][2].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/" + tbdn.Rows[0][2].ToString().Trim() +
                 "'>";

        s += "<img src='http://vnexpress.net/Images/Weather/c.gif'>";
        s += "<div class=\"city1\">";
        s += tbdn.Rows[0][6].ToString().Trim();
        s += "</div>";
        dsdn.Dispose();
        s += "</div>";
        #endregion
        #region[HaiPhong]

        s += "<div id=\"haiphong\" style=\"display: none;\">";
        DataSet dshp = new DataSet();
        dshp.ReadXml("http://vnexpress.net/ListFile/Weather/HaiPhong.xml");
        DataTable tbhp = dshp.Tables[0];
        if (tbhp.Rows[0][0].ToString().Trim() != "")
            s += "&nbsp;<img src='http://vnexpress.net/Images/Weather/" +
                tbhp.Rows[0][0].ToString().Trim() + "'>";
        if (tbhp.Rows[0][1].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/"
                + tbhp.Rows[0][1].ToString().Trim() + "'>";
        if (tbhp.Rows[0][2].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/" + tbhp.Rows[0][2].ToString().Trim() +
                 "'>";
        s += "<img src='http://vnexpress.net/Images/Weather/c.gif'>";
        s += "<div class=\"city1\">";
        s += tbhp.Rows[0][6].ToString().Trim();
        s += "</div>";
        dshp.Dispose();
        s += "</div>";
        #endregion
        #region[NhaTrang]

        s += "<div id=\"nhatrang\" style=\"display: none;\">";
        DataSet dsnhatrang = new DataSet();
        dsnhatrang.ReadXml("http://vnexpress.net/ListFile/Weather/NhaTrang.xml");
        DataTable tbnhatrang = dsnhatrang.Tables[0];
        if (tbnhatrang.Rows[0][0].ToString().Trim() != "")
            s += "&nbsp;<img src='http://vnexpress.net/Images/Weather/" +
                tbnhatrang.Rows[0][0].ToString().Trim() + "'>";
        if (tbnhatrang.Rows[0][1].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/"
                + tbnhatrang.Rows[0][1].ToString().Trim() + "'>";
        if (tbnhatrang.Rows[0][2].ToString().Trim() != "")
            s += "<img src='http://vnexpress.net/Images/Weather/" + tbnhatrang.Rows[0][2].ToString().Trim() +
                 "'>";
        s += "<img src='http://vnexpress.net/Images/Weather/c.gif'>";
        s += "<div class=\"city1\">";
        s += tbnhatrang.Rows[0][6].ToString().Trim();
        s += "</div>";
        dsnhatrang.Dispose();
        s += "</div>";
        #endregion

        s += "</div>";
        s += "<div id=\"weatherselect\">";
        s += " <select style=\"width:60px;\" onchange=\"weather(this.value)\">";
        s += " <option value=\"hn\">Hà Nội</option><option value=\"hcm\">TP. HCM</option><option value=\"dn\">Đà Nẵng</option><option value=\"haiphong\">Hải Phòng</option><option value=\"nhatrang\">Nha Trang</option>";
        s += "</select></div>";

        return s + "</div>";
    }
    public string chuyende()
    {
        DataTable dtCD = CD_HienThiTrangChuService.CD_HienThiTrangChu_GetAll();
        if (dtCD.Rows.Count == 0)
        {
            DataTable dt = CD_ChuyenDeService.CD_ChuyenDe_GetByTop("2", "", "Id desc");
            string s = "<div id=\"chuyende\">";
            s += "<a class=\"groupnew-name\" href=\"/chuyende.aspx\" style=\"color:#616264\">CHUYÊN ĐỀ</a>";
            s += "<div class=\"group-new-chuyende\">";
            s += "<a href=\"/chuyende/" + dt.Rows[0]["id"] + "/" + StringClass.NameToTag(dt.Rows[0]["TieuDe"].ToString()) + ".aspx\">";
            s += "<img src=\"" + dt.Rows[0]["HinhAnh"] + "\" style=\"float:left\" width=\"103px\" height=\"57px\"></a>";
            s += "<div class=\"title-chuyende\"><a style=\"font-weight:bold;font-size:13px;\" href=\"/chuyende/" + dt.Rows[0]["id"] + "/" + StringClass.NameToTag(dt.Rows[0]["TieuDe"].ToString()) + ".aspx\">" + dt.Rows[0]["TieuDe"] + "</a></div>";
            s += "</div>";
            s += "<div class=\"group-new-chuyende\">";
            s += "<a href=\"/chuyende/" + dt.Rows[1]["id"] + "/" + StringClass.NameToTag(dt.Rows[1]["TieuDe"].ToString()) + ".aspx\">";
            s += "<img src=\"" + dt.Rows[1]["HinhAnh"] + "\"  style=\"float:left\" width=\"103px\" height=\"57px\"></a>";
            s += "<div class=\"title-chuyende\"><a style=\"font-weight:bold;font-size:13px;\" href=\"/chuyende/" + dt.Rows[1]["id"] + "/" + StringClass.NameToTag(dt.Rows[1]["TieuDe"].ToString()) + ".aspx\">" + dt.Rows[1]["TieuDe"] + "</a></div>";
            s += "</div></div>";
            return s;

        }
        if (dtCD.Rows.Count == 1)
        {
            DataTable dt = CD_ChuyenDeService.CD_ChuyenDe_GetById(dtCD.Rows[0]["ChuyenDe_Id"].ToString());
            string s = "<div id=\"chuyende\">";
            s += "<a class=\"groupnew-name\" href=\"/chuyende.aspx\" style=\"color:#616264\">CHUYÊN ĐỀ</a>";
            s += "<div class=\"group-new-chuyende\">";
            s += "<a href=\"/chuyende/" + dt.Rows[0]["id"] + "/" + StringClass.NameToTag(dt.Rows[0]["TieuDe"].ToString()) + ".aspx\">";
            s += "<img src=\"" + dt.Rows[0]["HinhAnh"] + "\" style=\"float:left\" width=\"103px\" height=\"57px\"></a>";
            s += "<div class=\"title-chuyende\"><a style=\"font-weight:bold;font-size:13px;\" href=\"/chuyende/" + dt.Rows[0]["id"] + "/" + StringClass.NameToTag(dt.Rows[0]["TieuDe"].ToString()) + ".aspx\">" + dt.Rows[0]["TieuDe"] + "</a></div>";
            s += "</div>";
            s += "<div class=\"box_gioithieu\">" + dtCD.Rows[0]["NoiDung"] + "</div></div>";
            return s;
        }
        if (dtCD.Rows.Count == 2)
        {
            DataTable dt1 = CD_ChuyenDeService.CD_ChuyenDe_GetById(dtCD.Rows[0]["ChuyenDe_Id"].ToString());
            DataTable dt2 = CD_ChuyenDeService.CD_ChuyenDe_GetById(dtCD.Rows[1]["ChuyenDe_Id"].ToString());
            string s = "<div id=\"chuyende\">";
            s += "<a class=\"groupnew-name\" href=\"/chuyende.aspx\" style=\"color:#616264\">CHUYÊN ĐỀ</a>";
            s += "<div class=\"group-new-chuyende\">";
            s += "<a href=\"/chuyende/" + dt1.Rows[0]["id"] + "/" + StringClass.NameToTag(dt1.Rows[0]["TieuDe"].ToString()) + ".aspx\">";
            s += "<img src=\"" + dt1.Rows[0]["HinhAnh"] + "\" style=\"float:left\" width=\"103px\" height=\"57px\"></a>";
            s += "<div class=\"title-chuyende\"><a style=\"font-weight:bold;font-size:13px;\" href=\"/chuyende/" + dt1.Rows[0]["id"] + "/" + StringClass.NameToTag(dt1.Rows[0]["TieuDe"].ToString()) + ".aspx\">" + dt1.Rows[0]["TieuDe"] + "</a></div>";
            s += "</div>";
            s += "<div class=\"group-new-chuyende\">";
            s += "<a href=\"/chuyende/" + dt2.Rows[0]["id"] + "/" + StringClass.NameToTag(dt2.Rows[0]["TieuDe"].ToString()) + ".aspx\">";
            s += "<img src=\"" + dt2.Rows[0]["HinhAnh"] + "\"  style=\"float:left\" width=\"103px\" height=\"57px\"></a>";
            s += "<div class=\"title-chuyende\"><a style=\"font-weight:bold;font-size:13px;\" href=\"/chuyende/" + dt2.Rows[0]["id"] + "/" + StringClass.NameToTag(dt2.Rows[0]["TieuDe"].ToString()) + ".aspx\">" + dt2.Rows[0]["TieuDe"] + "</a></div>";
            s += "</div></div>";
            return s;
        }
        return "";
    }
    public string hotgroupnew()
    {
        string s = "<div id=\"hotgroupnew\">";
        s += "<div id=\"group-hanhlang-phaply\">";
        s += "<a class=\"groupnew-name\" href=\"/chuyen_de.aspx\" style=\"color:#616264\">HÀNH LANG PHÁP LÝ</a>";
        s += "<div class=\"group-new-chuyende\">";
        s += "<img src=\"/Images/TT_TinTuc/small-business-starting.jpg\" style=\"float:left\" width=\"103px\" height=\"57px\">";
        s += "<div class=\"title-chuyende\"><p><a href=\"/doanh_nhan/xay_dung_doi_ngu_doanh_nhan_vung_manh.aspx\">Hành lang pháp lý cho lao động ở nước ngoài</a></p>";
        s += "<p><a href=\"/doanh_nhan/xay_dung_doi_ngu_doanh_nhan_vung_manh.aspx\">Gian lận thanh toán thẻ</a></p>";
        s += "</div>";
        s += "</div>";
        // group giao duc
        s += "<div id=\"giao-duc\">";
        s += "<a class=\"groupnew-name\" href=\"/giao_duc.aspx\" style=\"color:#616264\">GIÁO DỤC</a>";
        s += "<ul>";
        var dt = CommonService.TinTuc_NhomTin_GetByTop("3", "XetDuyet = 4 AND TT_NhomTin.Tag = 'giao_duc'", "ID DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s += "<li><a style=\"font-size:85%\" href=\"/" + dt.Rows[i]["NhomTin_Tag"] + "/" + dt.Rows[i]["Tag"] + ".aspx\">" + dt.Rows[i]["TieuDe"] + "</a></li>";
        }
        s += "</ul>";
        s += "</div>";
        //group suc khoe
        s += "<div id=\"suc-khoe\">";
        s += "<a class=\"groupnew-name\" href=\"/suc_khoe.aspx\" style=\"color:#616264\">SỨC KHỎE</a>";
        var dt1 = CommonService.TinTuc_NhomTin_GetByTop("3", "XetDuyet = 4 AND TT_NhomTin.Tag = 'suc_khoe'", "ID DESC");
        if (dt1.Rows.Count == 0) return "";
        s += "<div class=\"group-new-chuyende\">";
        string path = dt1.Rows[0]["HinhAnh"].ToString();
        if (path != "")
            path = path.Remove(0, 1);
        s += "<img src=\"" + path + "\" style=\"float:left\" width=\"103px\" height=\"57px\">";
        s += "<div class=\"title-suckhoe\">";
        s += "<ul>";
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            string t = dt1.Rows[i]["TieuDe"].ToString();
            if (t.Length > 20)
            {
                int j = 20;
                while (t[j] != ' ')
                {
                    j--;
                }
                t = t.Substring(0, j) + " ...";
            }

            s += "<li><a href=\"/" + dt1.Rows[i]["NhomTin_Tag"] + "/" + dt1.Rows[i]["Tag"] + ".aspx\">" + t + "</a></li>";
        }
        s += "</ul>";
        s += "</div></div></div></div>";
        return s;
    }
    public string Top1TinMoiNhat_Group(string Tag, ref string nhomtin)
    {
        //edit truy van, style width height for img
        var dt = TT_TinHotService.TT_TinHot_NhomTin_GetByTop("1", "XetDuyet = 4 And dbo.TT_NhomTin.Tag = '" + Tag + "' AND Loai = 1  AND DATEADD(Hour, TT_TinHot.SoGio, dbo.TT_TinHot.NgayGioBatDau) > GetDate()", "ThuTu");
        if (dt.Rows.Count == 0)
        {
            dt = CommonService.TinTuc_NhomTin_GetByTop("1", "XetDuyet = 4 And dbo.TT_NhomTin.Tag = '" + Tag + "'", "ID DESC");
        }
        if (dt.Rows.Count == 0) return "";
        nhomtin = dt.Rows[0]["Id"].ToString();
        string s = "<div id=\"top1\"><div id=\"newtop1\">";
        string path = dt.Rows[0]["HinhAnh"].ToString();
        if (path != "")
            path = path.Remove(0, 1);
        s += "<a href=\"/" + dt.Rows[0]["NhomTin_Tag"] + "/" + dt.Rows[0]["Tag"] + ".aspx\"><img style=\"margin-bottom:5px\" src=\"" + path + "\" width=\"450px\" height=\"215px\"\"></img></a>";
        s += "<h3><a style=\"font-size:1.168em;\" href=\"/" + dt.Rows[0]["NhomTin_Tag"] + "/" + dt.Rows[0]["Tag"] + ".aspx\">" + dt.Rows[0]["TieuDe"] + "</a></h3>";
        string t = dt.Rows[0]["TomTat"].ToString();
        s += "<p style=\"font-size: 14px;line-height:1.4em;\">" + t + "</p>";
        s += "</div></div>";
        return s;
    }
    public string Top3TinMoiTiepTheo_Group(string Tag, ref string nhomtin)
    {
        var dt1 = new DataTable();
        var dt = TT_TinHotService.TT_TinHot_NhomTin_GetByTop("3", "XetDuyet = 4 And dbo.TT_NhomTin.Tag = '" + Tag + "' AND Loai != 1  AND DATEADD(Hour, TT_TinHot.SoGio, dbo.TT_TinHot.NgayGioBatDau) > GetDate()", "ThuTu");
        int tt = 3 - dt.Rows.Count;
        if (tt != 0)
        {
            var top1 = TT_TinHotService.TT_TinHot_NhomTin_GetByTop("1", "XetDuyet = 4 And dbo.TT_NhomTin.Tag = '" + Tag + "' AND Loai = 1 AND DATEADD(Hour, TT_TinHot.SoGio, dbo.TT_TinHot.NgayGioBatDau) > GetDate()", "");
            if (top1.Rows.Count == 0)
                dt1 = CommonService.TinTuc_NhomTin_GetByTop(tt.ToString(), "XetDuyet = 4 And dbo.TT_NhomTin.Tag = '" + Tag + "' AND TT_TinTuc.Id <>(SELECT TOP (1) TT_TinTuc.ID FROM TT_TINTUC inner join TT_NhomTin ON TT_TinTuc.NhomTin = TT_NhomTin.ID WHERE XETDUYET = 4 AND TT_NhomTin.Tag = '" + Tag + "' ORDER BY TT_TinTuc.ID DESC)", "ID DESC");
            else
                dt1 = CommonService.TinTuc_NhomTin_GetByTop(tt.ToString(), "XetDuyet = 4 And dbo.TT_NhomTin.Tag = '" + Tag + "'", "ID DESC");
        }
        string s = "<div id=\"top3\">";
        //for 1
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            nhomtin += "," + dt.Rows[i]["ID"];
            s += "<div class=\"NewTop3\">";
            s += "<p><a href=\"/" + dt.Rows[i]["NhomTin_Tag"] + "/" + dt.Rows[i]["tag"] + ".aspx\">" + dt.Rows[i]["TieuDe"] + "</a></p>";
            string t = dt.Rows[i]["TomTat"].ToString();
            s += "<p class=\"trichdan\">" + t + "</p>";
            s += "</div>";
        }
        //for 2
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            nhomtin += "," + dt1.Rows[i]["ID"];
            s += "<div class=\"NewTop3\">";
            s += "<p><a href=\"/" + dt1.Rows[i]["NhomTin_Tag"] + "/" + dt1.Rows[i]["tag"] + ".aspx\">" + dt1.Rows[i]["TieuDe"] + "</a></p>";
            string t = dt1.Rows[i]["TomTat"].ToString();
            s += "<p class=\"trichdan\">" + t + "</p>";
            s += "</div>";
        }
        s += "</div>";
        return s;
    }

}