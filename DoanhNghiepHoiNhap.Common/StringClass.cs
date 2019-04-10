using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

public class StringClass : Page
{
    /// <summary>
    /// Create attribute and funtion for textbox
    /// </summary>
    /// <param name="textBox">Textbox to set client attribute</param>
    /// <param name="Event">Event set for textbox</param>
    /// <param name="Funtion">Value of event - funtion javascript</param>
    /// <param name="ScriptFuntion">String funtion script return</param>
    public static void CreateClientScriptAttributes(TextBox textBox, string Event, string Funtion, string ScriptFuntion)
    {
        textBox.Page.ClientScript.RegisterClientScriptBlock(textBox.GetType(), textBox.ID + "_" + Event, ScriptFuntion);
        textBox.Attributes.Add(Event, Funtion);
    }

    /// <summary>
    /// Create attribute and funtion for textbox
    /// </summary>
    /// <param name="checkBox">CheckBox to set client attribute</param>
    /// <param name="Event">Event set for checkbox</param>
    /// <param name="Funtion">Value of event - funtion javascript</param>
    /// <param name="ScriptFuntion">String funtion script return</param>
    public static void CreateClientScriptAttributes(CheckBox checkBox, string Event, string Funtion,
                                                    string ScriptFuntion)
    {
        checkBox.Page.ClientScript.RegisterClientScriptBlock(checkBox.GetType(), checkBox.ID + "_" + Event,
                                                             ScriptFuntion);
        checkBox.Attributes.Add(Event, Funtion);
    }

    /// <summary>
    /// Ma hoa chuoi ky tu (MD5)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Encrypt(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        var md5 = new MD5CryptoServiceProvider();
        byte[] valueArray = Encoding.ASCII.GetBytes(value);
        valueArray = md5.ComputeHash(valueArray);
        var sb = new StringBuilder();
        for (int i = 0; i < valueArray.Length; i++)
            sb.Append(valueArray[i].ToString("x2").ToLower());
        return sb.ToString();
    }

    /// <summary>
    /// Chuyển dạng dd/MM/yyyy thành MM/dd/yyyy
    /// </summary>
    /// <returns></returns>
    public static string ConvertDateTime(string date)
    {
        string[] d = date.Split('/');
        return d[1] + "/" + d[0] + "/" + d[2];
    }

    /// <summary>
    /// Chuyển dạng dd/MM/yyyy hh:mm:ss tt thành MM/dd/yyyy hh:mm:ss tt
    /// </summary>
    /// <returns></returns>
    public static string ConvertDateTimev2(string date)
    {
        string[] arr = date.Split(' ');
        string[] d = arr[0].Split('/');
        return d[1] + "/" + d[0] + "/" + d[2] + " " + arr[1] + " " + arr[2];
    }

    public static bool CheckValid(string s)
    {
        if (s.Length > 20) return false;
        if (s.Contains("@") || s.Contains(" ") || s.Contains("$") || s.Contains("&") || s.Contains("#"))
            return false;
        return true;
    }

    public static string ShowNameLevel(string Name, string Level)
    {
        int strLevel = (Level.Length / 5);
        string strReturn = "";
        for (int i = 1; i < strLevel; i++)
        {
            strReturn = strReturn + ".....";
        }
        strReturn += Name;
        return strReturn;
    }

    #region Remove Unicode

    public static string RemoveUnicode(string strString)
    {
        var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string strFormD = strString.Normalize(NormalizationForm.FormD);
        return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
    }

    #endregion

    #region Encode

    public static string Encode(string str)
    {
        byte[] encbuff = Encoding.UTF8.GetBytes(str);
        string strtemp = Convert.ToBase64String(encbuff);
        string strtam = "";
        Int32 i = 0, len = strtemp.Length;
        for (i = 3; i <= len; i += 3)
        {
            strtam = strtam + strtemp.Substring(i - 3, 3) + RandomString(1);
        }
        strtam = strtam + strtemp.Substring(i - 3, len - (i - 3));
        return strtam;
    }

    #endregion

    #region Decode

    public static string Decode(string str)
    {
        string strtam = "";
        Int32 i = 0, len = str.Length;
        for (i = 4; i <= len; i += 4)
        {
            strtam = strtam + str.Substring(i - 4, 3);
        }
        strtam = strtam + str.Substring(i - 4, len - (i - 4));
        byte[] decbuff = Convert.FromBase64String(strtam);
        return Encoding.UTF8.GetString(decbuff);
    }

    #endregion

    #region Random String

    public static string RandomString(int size)
    {
        var rnd = new Random();
        string srds = "";
        string[] str = {
                           "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s",
                           "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                           "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5",
                           "6", "7", "8", "9", "0"
                       };
        for (int i = 0; i < size; i++)
        {
            srds = srds + str[rnd.Next(0, 61)];
        }
        return srds;
    }

    #endregion

    #region Name To Tag

    public static string NameToTag(string strName)
    {
        string strReturn = "";
        var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        strReturn = Regex.Replace(strName, "[^\\w\\s]", string.Empty).Replace(" ", "-").ToLower();
        string strFormD = strReturn.Normalize(NormalizationForm.FormD);
        return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
    }

    //Url chi tiết tin
    public static string Url(string Tag, string NhomTin_Tag)
    {
        return "/" + NhomTin_Tag + "/" + Tag + ".html";
    }

    //Remove dấu ~ ở hình ảnh
    public static string Path(string Value)
    {
        if (Value == "") return "";
        return Value.Remove(0, 1);
    }

    #endregion

    public static string GetYouTubeScript(string url, string width, string height)
    {
        //Cắt lấy ID từ chuỗi URL
        string id;
        if (url.Length == 11)
            id = url;
        else
        {
            try
            {
                int vt = url.IndexOf("watch?v=");
                id = url.Substring(vt + 8, 11);
            }
            catch
            {
                id = url;
            }
        }

        string scr = @"<object width='" + width + "' height='" + height + "'> ";

        scr = scr + @"<param name='movie' value='http://www.youtube.com/v/" + id + "'></param> ";

        scr = scr + @"<param name='allowFullScreen' value='true'></param> ";

        scr = scr + @"<param name='allowscriptaccess' value='always'></param> ";

        scr = scr + @"<embed src='http://www.youtube.com/v/" + id + "' ";

        scr = scr + @"type='application/x-shockwave-flash' allowscriptaccess='always'      ";

        scr = scr + @"allowfullscreen='true' width='" + width + "' height='" + height + "'> ";

        scr = scr + @"</embed></object>";

        return scr;

    }

    public static string GetThumbImageYoutobe(string url)
    {
        //Cắt lấy ID từ chuỗi URL
        string id;
        if (url.Length == 11)
            id = url;
        else
        {
            try
            {
                int vt = url.IndexOf("watch?v=");
                id = url.Substring(vt + 8, 11);
            }
            catch
            {
                id = url;
            }
        }
        return "http://img.youtube.com/vi/" + id + "/0.jpg";
    }

    public static string FormatPrice(string price)
    {
        if (price == "0")
        {
            return "0 VNĐ";
        }
        price = price.Replace(".", "");
        price = price.Replace(",", "");
        string tmp = "";
        while (price.Length > 3)
        {
            tmp = "." + price.Substring(price.Length - 3) + tmp;
            price = price.Substring(0, price.Length - 3);
        }
        tmp = price + tmp + " VNĐ";
        return tmp;
    }


    // Code api webview SachVui

    // Load toàn bộ dữ liệu quyển sách thuộc Id_TheLoaiSach và phân trang   
    public static string _get_AllQuyenSach(string id_allquyensach, string page)
    {
        string msg = "";
        //DateTime date_get7ngay = DateTime.Now;
        //DateTime date_Get = date_get7ngay.AddDays(-14);
        //date = "Ngay >= '" + date_Get + "'";
        try
        {
            //var dt = TT_TaoPhieuXuatXangService.TT_TaoPhieuXuatXang_Paging(page, " CuaHang_Id = '" + id_cuahang + "' and TrangThai = 0 and " + date, "");
            var dt = TH_QuyenSachService.TH_QuyenSach_Paging(page, " Id_TheLoaiSach = '" + id_allquyensach + "'", "Id desc");
            if (dt != null)
            {
                //var dt = TT_TaoPhieuXuatXangService.TT_TaoPhieuXuatXang_GetByTop("1000", "CuaHang_Id = " + id_cuahang, "Ngay desc");      
                for (int i = 0 ; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["Id"].ToString();
                    string hinhanh = dt.Rows[i]["HinhAnh"].ToString();
                    string tieude = dt.Rows[i]["TieuDe_QuyenSach"].ToString();
                    // string nvlx = _get_hoten_nguoidung(dt.Rows[i]["NvLx_Id"].ToString());
                    string tacgia = dt.Rows[i]["TacGia"].ToString();
                    string id_loaichuong = dt.Rows[i]["Id_TheLoaiChuong"].ToString();
                    string ngayup = DateTimeClass.ConvertDateTime(dt.Rows[i]["NgayUp"].ToString(), "dd/MM/yyyy") + DateTimeClass.ConvertDateTime(dt.Rows[i]["NgayUp"].ToString(), " hh:mm:ss");
                    if (i == 0)
                    {
                        msg += id + "|" + hinhanh + "|" + tieude + "|" + tacgia + "|" + id_loaichuong + "|" + ngayup;
                    }
                    else
                    {
                        msg += "@" + id + "|" + hinhanh + "|" + tieude + "|" + tacgia + "|" + id_loaichuong + "|" + ngayup;
                    }
                }
            }
        }
        catch (Exception ex)
        { }

        return msg;
    }

    // Lấy thông tin chi tiết dữ liệu trong quyển sách - gồm có chi tiết và list chương. 
    public static string _get_infoQuyenSach(string Id_quyensach, string Id_TheLoaiSach)
    {
        string msg = "";
        try
        {
            var dt = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "Id = '" + Id_quyensach + "' and Id_TheLoaiSach = '" + Id_TheLoaiSach + "'", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                msg = dt.Rows[0]["Id"].ToString() + "@"
                + dt.Rows[0]["HinhAnh"].ToString() + "@"
                + dt.Rows[0]["TieuDe_QuyenSach"].ToString() + "@"
                + dt.Rows[0]["TacGia"].ToString() + "@"
                + dt.Rows[0]["Id_TheLoaiChuong"].ToString() + "@"
                + dt.Rows[0]["Mota"].ToString()
                ;
            }
            else {
                WebMsgBox.Show("Không Có Quyển Sách Thuộc Thể Loại Này!");
            }
        }
        catch (Exception)
        { }
        return msg;
    }

    // Lấy dữ liệu list danh sách TH_Chuong theo id_quyensach - gồm truyện chữ và truyện tranh
    // Tìm chưa ra
    public static string _get_ListAllChuong(string id_chuong, string page)
    {
        string msg = "";

        try
        {
            var dt_qs = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "Id_TheLoaiChuong = 1 and Id_TheLoaiSach = 264", "");
            if (dt_qs != null)
            {
                //var dt = TT_TaoPhieuXuatXangService.TT_TaoPhieuXuatXang_Paging(page, " CuaHang_Id = '" + id_cuahang + "' and TrangThai = 0 and " + date, "");
                var dt = TH_ChuongService.TT_Chuong_Paging(page, " Id_QuyenSach = '" + id_chuong + "'", "Id asc");
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["Id"].ToString(); 
                        string id_qs = dt.Rows[i]["Id_QuyenSach"].ToString();
                        string tieude = dt.Rows[i]["TieuDe"].ToString();
                        if (i == 0)
                        {
                            msg += id + "|" + id_qs + "|" + tieude;
                        }
                        else
                        {
                            msg += "@" + id + "|" + id_qs + "|" + tieude;
                        }
                    }
                }
            }
            else { }
        }
        catch (Exception ex)
        { }

        return msg;
    }

    // Get All Toàn Bộ Id_Chuong Thuộc Id_QuyenSach đó
    public static string _get_ListAllIdChuong(string id_c_quyensach)
    {
        string msg = "";

        try
        {
            var dt_qs = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "Id_TheLoaiChuong = 1 and Id_TheLoaiSach = 264", "");
            if (dt_qs != null)
            {
                var dt = TH_ChuongService.TH_Chuong_GetByTop("", " Id_QuyenSach = '" + id_c_quyensach + "'", "Id asc");
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["Id"].ToString();
                        string id_qs = dt.Rows[i]["Id_QuyenSach"].ToString();
                        if (i == 0)
                        {
                            msg += id ;
                        }
                        else
                        {
                            msg += "@" + id ;
                        }
                    }
                }
            }
            else { }
        }
        catch (Exception ex)
        { }

        return msg;
    }


    // Tìm kiếm theo tên tác giả hoặc tên quyển sách
    public static string _get_timkiem_theotacgiavatenquyensach(string timkiem, string id_TheLoaiSach)
    {
        string msg = "";

        // % tiem trong chuoi dau va cuoi nhan 
        var dt = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "Id_TheLoaiSach = '" + id_TheLoaiSach + "' and (TieuDe_QuyenSach like N'%" + timkiem + "%'" + " or TacGia like N'%" + timkiem + "%'" +")", "Id desc");
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["Id"].ToString();
                string hinhanh = dt.Rows[i]["HinhAnh"].ToString();
                string tieude = dt.Rows[i]["TieuDe_QuyenSach"].ToString();
                // string nvlx = _get_hoten_nguoidung(dt.Rows[i]["NvLx_Id"].ToString());
                string tacgia = dt.Rows[i]["TacGia"].ToString();
                string id_loaichuong = dt.Rows[i]["Id_TheLoaiChuong"].ToString();
                if (i == 0)
                {
                    msg += id + "|" + hinhanh + "|" + tieude + "|" + tacgia + "|" + id_loaichuong;
                }
                else
                {
                    msg += "@" + id + "|" + hinhanh + "|" + tieude + "|" + tacgia + "|" + id_loaichuong;
                }
            }
        }
        return msg;

    }

    // Lấy dữ liệu để nội dung Chuyện Đọc view ra webview 
    public static string _get_infoChuong(string id_chuong, string id_quyensach)
    {
        string msg = "";
        try
        {
            var dt = TH_ChuongService.TH_Chuong_GetByTop("", "Id = '" + id_chuong + "' and Id_QuyenSach = '" + id_quyensach + "'", "Id desc");
            if (dt != null)
            {
                msg = dt.Rows[0]["Id"].ToString() + "@"
                + _get_tenquyensach(dt.Rows[0]["Id_QuyenSach"].ToString()) + "@"
                + dt.Rows[0]["TieuDe"].ToString() + "@"
                + dt.Rows[0]["NoiDung"].ToString()
                ;
            }
            else
            {
                WebMsgBox.Show("Danh sách chương đã hết mời bạn qua quyển mới!");
            }

        }
        catch (Exception)
        { }
        return msg;
    }

    // Lấy dữ liệu để nội dung Chuyện PDF view ra webview 
    public static string _get_infoChuongPDF(string id_quyensachpdf)
    {
        string msg = "";
        try
        {
            var dt = TH_ChuongPDFService.TH_ChuongPDF_GetByTop("", "Id_QuyenSach = '" + id_quyensachpdf + "'", "");

            msg = dt.Rows[0]["Id"].ToString() + "@"
            + dt.Rows[0]["Id_QuyenSach"].ToString() + "@"
            + dt.Rows[0]["LinkBDF"].ToString()
            ;

        }
        catch (Exception)
        { }
        return msg;
    }

    public static string _get_tenquyensach(string id)
    {
        var dt = TH_QuyenSachService.TH_QuyenSach_GetById(id);

        return dt.Rows[0]["TieuDe_QuyenSach"].ToString();
    }

    public static string _get_tenchuong(string id)
    {
        var dt = TH_ChuongService.TH_Chuong_GetById(id);

        return dt.Rows[0]["TieuDe"].ToString();
    }
}