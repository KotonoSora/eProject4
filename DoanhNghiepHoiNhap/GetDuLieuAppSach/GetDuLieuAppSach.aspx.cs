using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Data;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoanhNghiepHoiNhap.GetDuLieuAppSach
{
    public partial class GetDuLieuAppSach : System.Web.UI.Page
    {
        //D:\WebSites\Web_sachvui\admin\UserFiles

        string localPath = @"D:\WebSites\Web_sachvui\admin\UserFiles"; // Lay duong dan vat ly cua sever
        string localPath_thum = @"D:\WebSites\Web_sachvui\admin\UserFiles\_thumbs\Images";


        //string localPath = @"E:\CODE DỰ LIỆU WEBSITE\8.Admin_App_SachVui\v.10\admin\DoanhNghiepHoiNhap\UserFiles"; // Lay duong dan vat ly cua sever
        //string localPath_thum = @"E:\CODE DỰ LIỆU WEBSITE\8.Admin_App_SachVui\v.10\admin\DoanhNghiepHoiNhap\UserFiles\_thumbs\Images";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //localPath = Server.MapPath(@"\UserFiles");
                //localPath_thum = Server.MapPath(@"\UserFiles\_thumbs\Images");
                //Server.MapPath("")
            }
        }



        private HtmlDocument get_doc_html(string url)
        {
            HtmlDocument document = new HtmlDocument();

            HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(url);
            getRequest.CookieContainer = new CookieContainer();
            getRequest.Method = WebRequestMethods.Http.Post;
            getRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
            getRequest.AllowWriteStreamBuffering = true;
            getRequest.ProtocolVersion = HttpVersion.Version11;
            getRequest.AllowAutoRedirect = true;
            getRequest.ContentType = "application/x-www-form-urlencoded";

            Stream newStream = getRequest.GetRequestStream(); //open connection
            newStream.Close();

            HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                string sourceCode = sr.ReadToEnd().ToString();

                document.LoadHtml(sourceCode);
            }

            return document;
        }



        private void _test(string msg)
        {
            TextBox1.Text = msg;
            Literal1.Text = msg;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Lấy tổng list các link thể loại sách + id 


            //Lay tong list cac link quyen sach

            //List<string> Tong_Link_QuyenSach = new List<string>();
            //int getpaeg = Get_Page(TextBox2.Text);
            //string view_qs = "";
            //for (int i = 1; i <= getpaeg; i++)
            //{
            //    string getlink = TextBox2.Text + "/" + i;
            //    List<string> listcon = Get_LinkQuyenSach(getlink);

            //    for (int j = 0; j < listcon.Count; j++)
            //    {
            //        string item_qs = listcon[j];
            //        Tong_Link_QuyenSach.Add(item_qs);
            //        view_qs += item_qs;
            //    }
            //}



            //// Lay tong list cac link chuong trong 1 quyen sach

            //List<string> Tong_link_chuong = new List<string>();
            //// số trang = Get_Page_Chuong(Nhập đường dẫn link)
            //int getpage_chuong = Get_Page_Chuong(TextBox2.Text);
            //string getlink_chuong = ""; // Hiện link + / + số phần tử trang
            //string item_chuong = ""; // item phần tử con của chương 
            //string view = "";
            //for (int i = 1; i <= getpage_chuong; i++) // bắt đầu từ phần tử thứ 1 vì luôn luôn là trang 1.
            //{
            //    getlink_chuong = TextBox2.Text + "/" + i;
            //    List<string> listcon_chuong = GetLinkChuong(getlink_chuong);

            //    for (int j = 0; j < listcon_chuong.Count; j++)
            //    {
            //        item_chuong = listcon_chuong[j];
            //        Tong_link_chuong.Add(item_chuong);
            //        view += item_chuong; // cho nó hiện toàn bộ đường link theo chương để lấy các chi tiết nội dung trong đó. 
            //    }
            //}




            //GetChiTietTrongChuong(TextBox2.Text);


            //_test(view); // để test
            string view = GetTheLoaiSach(TextBox2.Text);
            _test(view);
            // GetPdf(TextBox2.Text);
            // GetChiTietTrongChuong(TextBox2.Text);
        }


        // Hàm này tìm đc tên link + id của Thể loại sách để tý nữa dùng cho thằng quyển sách .
        private string GetTheLoaiSach(string link_tl)
        {
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(link_tl);
            var content = doc1.DocumentNode.SelectSingleNode("//ul[@class='center-block row']");
            string tenloaisach = "";
            try
            {
                var content_tl = content.SelectNodes("//li[@class='cat-item col-xs-12 col-md-4 col-sm-6']/a");

                string linkurl_loaisach = "";
                //for (int i = 0; i < content_tl.Count; i++) // Muốn test cho list Count = 1

                if (content_tl != null && content_tl.Count > 0) // kiểm tra nếu tiêu đề tồn tại thì 
                {
                    // int i = content_tl.Count - 1; i > content_tl.Count - 2; i-- //=== kiểm tra phần tử thể loại sách cuối cùng .
                    // i dang là phần tử 13  ; và i lớn hơn phần tử 15 thì nó sẽ lấy từ 14 đến 15
                    // muốn chạy quyển sách nào thì thay i = số đó vô.
                    for (int i = 0; i < content_tl.Count; i++)//content_tl.Count
                    {
                        linkurl_loaisach = content_tl[i].Attributes["href"].Value.ToString();
                        tenloaisach = content_tl[i].InnerHtml.ToString();
                        int c_c = tenloaisach.IndexOf("</span>") + 7;
                        tenloaisach = tenloaisach.Substring(c_c).Trim();

                        // Check khi chạy Upadte
                        if (!is_Tontaitheloaisach(tenloaisach)) // nếu không tồn tại thì thêm mới
                        {
                            try
                            {
                                TH_TheLoaiSachService.TH_TheLoaiSach_Insert(tenloaisach, tenloaisach, "1");
                                // Lấy danh sách quyển sách
                                List<string> Tong_Link_QuyenSach = new List<string>();
                                int getpaeg = Get_Page(linkurl_loaisach);
                                string view_qs = "";
                                for (int i_quyensach = 1; i_quyensach <= getpaeg; i_quyensach++) // Muốn test cho list Count = 1 
                                {
                                    string getlink = linkurl_loaisach + "/" + i_quyensach;
                                    List<string> listcon = Get_LinkQuyenSach(getlink);

                                    for (int j_quyensach = 0; j_quyensach < listcon.Count; j_quyensach++) //listcon.Count
                                    {
                                        string item_qs = listcon[j_quyensach];
                                        Tong_Link_QuyenSach.Add(item_qs);
                                        //view_qs += item_qs;
                                        GetChiTiet(item_qs, tenloaisach);
                                    }
                                }
                            }
                            catch (Exception) { }

                        }
                        else
                        {
                            try
                            {
                                List<string> Tong_Link_QuyenSach = new List<string>();
                                int getpaeg = Get_Page(linkurl_loaisach);
                                string view_qs = "";
                                for (int i_quyensach = 1; i_quyensach <= getpaeg; i_quyensach++) // Muốn test cho list Count = 1 
                                {
                                    string getlink = linkurl_loaisach + "/" + i_quyensach;
                                    List<string> listcon = Get_LinkQuyenSach(getlink);

                                    for (int j_quyensach = 0; j_quyensach < listcon.Count; j_quyensach++)
                                    {
                                        string item_qs = listcon[j_quyensach];
                                        Tong_Link_QuyenSach.Add(item_qs);
                                        //view_qs += item_qs;
                                        GetChiTiet(item_qs, tenloaisach);
                                    }
                                }

                            }
                            catch (Exception) { }

                        }
                        // Kết thúc Check khi chạy Upadte

                    }

                }
                else
                { }

                content_tl.Clear();
                content.RemoveAll();
            }
            catch (Exception)
            { }

            return tenloaisach;
        }

        // Hàm lấy phần tử id cuối cùng của thể loại sách.
        public string GetIdLoaiSach()
        {
            try
            {
                var dt = TH_TheLoaiSachService.TH_TheLoaiSach_GetByTop("1", "", "Id desc");

                string ten = dt.Rows[0]["Id"].ToString();

                return ten;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetTenTheLoaiSach()
        {
            try
            {
                var dt = TH_TheLoaiSachService.TH_TheLoaiSach_GetByTop("", "", "Id desc");

                string ten = dt.Rows[0]["TenTheLoaiSach"].ToString();

                return ten;
            }
            catch (Exception)
            {
                return "";
            }
        }

        // Lấy chi tiết của từng Chương 
        private void GetChiTietTrongChuong(string url_chitiettrongchuong, string tensach)
        {
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(url_chitiettrongchuong);

            var content = doc1.DocumentNode.SelectSingleNode("//div[@class='doc-online']");
            var content_kt_img = content.SelectNodes("//img");
            int kt_ = 1;
            string Tieude_quyensach = "";
            string TieuDe = "";
            string NoiDung = "";
            string NgayCapNhat = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy hh:mm:ss");
            string url_img_chap = "";
            var content_tieude = content.SelectNodes("//h3[@class='text-center']/small/a[@class='link-tap']");
            TieuDe = content_tieude[0].Attributes["href"].Value.ToString();
            TieuDe = content_tieude[0].InnerHtml;


            //kt chuong ton tai
            if (!is_Tontaichuong(TieuDe))
            {
                var content_noidung = content.SelectNodes("//p");
                if (content_noidung != null)
                {
                    NoiDung = System.Net.WebUtility.HtmlDecode(content_noidung[0].InnerHtml.ToString().Trim());
                }

                // Kiểm tra có phải là Truyện tranh hay Truyện chữ
                if (content_kt_img != null && content_kt_img.Count > 0) // nếu là ảnh thì thực hiện các bước sau
                {
                    kt_ = 1;
                    try
                    {
                        //string str_hinhanhdaidien = "";
                        for (int dfa = 0; dfa < content_kt_img.Count; dfa++) // content_kt_img.Count
                        {
                            string linkurl_chap = content_kt_img[dfa].Attributes["src"].Value.ToString().Replace("200x200", "800x400");//745x510

                            //    //save anh nhe
                            string[] l_tenanh = linkurl_chap.Split('/');
                            string s_ten_anh_chap = l_tenanh.Last().Trim();

                            // Đưa link hình ảnh đại diện để đưa lên sever Công thức : 
                            //SQL sever + (đường dẫn link) \UserFiles\image\AnhDaiDienQuyenSach\ + tên .jpg ;
                            // Ở đây tạo 1 hàm để gọi tên đặt cho folder ảnh mà mình lưu
                            string name_quyensach = GetNameQuyenSach();
                            url_img_chap = @"\UserFiles\image\" + NameToTag(name_quyensach) + "\\" + s_ten_anh_chap;

                            //save image ok
                            string https = "https://sachvui.com";
                            bool isExists = linkurl_chap.Contains(@"https://");
                            try
                            {
                                if (isExists == true) // kiểm tra đúng sai hàm bool của biến isExists nếu linkurl có chuỗi ký tự giống với @"https://" thì xóa link http
                                { SaveImage_Chuong(linkurl_chap, s_ten_anh_chap, NameToTag(name_quyensach)); }
                                else // ngược lại nếu hàm bool sai thì gắng thêm link http
                                { SaveImage_Chuong(https + linkurl_chap, s_ten_anh_chap, NameToTag(name_quyensach)); }
                            }
                            catch (Exception ex)
                            { }

                            NoiDung = NoiDung.Replace(linkurl_chap, url_img_chap);
                        }

                    }
                    catch (Exception)
                    { }

                }
                else
                { // còn nếu 
                    kt_ = 2;
                }

                NoiDung = NoiDung.Replace("sachvui.com", " "); // xoa bo cac phan tu co chu sachvui 

                string get_IdQuyensach = GetIdQuyenSach_ByName(tensach);

                TH_ChuongService.TH_Chuong_Insert(get_IdQuyensach, TieuDe, NoiDung, "0", "1", NgayCapNhat);
            }
            else
            {
                //o lam gi

            }


            //var content_tdquyensach = content.SelectNodes("//h3[@class='text-center']/a");
            //Tieude_quyensach = content_tieude[0].InnerHtml;
            // _test(kt_.ToString() + "\n" + RemoveVietnamese(TieuDe.ToString().Trim()) + "\n" + NoiDung + "\n" + NgayCapNhat + "\n" + url_img_chap);

            content.RemoveAll();
            // _test(NoiDung);
        }

        // Hàm lấy phần tử id cuối cùng của Quyển Sách.
        public string GetIdQuyenSach()
        {
            try
            {
                var dt = TH_QuyenSachService.TH_QuyenSach_GetByTop("1", "", "Id desc");
                string ten = dt.Rows[0]["Id"].ToString();
                return ten;
            }
            catch (Exception)
            { return ""; }
        }

        // Lấy tên quyển sách để làm folder lưu ảnh 
        public string GetNameQuyenSach()
        {
            try
            {
                var dt = TH_QuyenSachService.TH_QuyenSach_GetByTop("1", "", "Id desc");
                string ten = dt.Rows[0]["TieuDe_QuyenSach"].ToString();
                return ten;
            }
            catch (Exception)
            { return ""; }
        }


        // Kiểm tra tổng số trang trong quyển sách. 
        private int Get_Page(string url_page)
        {
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(url_page);

            var content = doc1.DocumentNode.SelectSingleNode("//div[@class='col-xs-12']");
            var content_page = content.SelectNodes("//ul[@class='pagination pagination-sm']/li/a");
            string str_content_page = "";
            int sotrang = 1;
            try
            {
                if (content_page != null && content_page.Count > 0)
                {
                    if (content_page.Count > 4) // số phần tử hiện trong lần đầu tiên của trang.
                    {
                        for (int i = 0; i < content_page.Count; i++)
                        {
                            str_content_page += content_page[i].InnerHtml;
                            string[] th1_page = str_content_page.Split(';');
                            str_content_page = th1_page.Last().Trim();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < content_page.Count - 1; i++) // lấy phần từ cuối của số trang  
                        {
                            str_content_page += content_page[i].InnerHtml;
                            str_content_page = str_content_page.Substring(str_content_page.Length - 1).ToString();
                        }
                    }

                    sotrang = int.Parse(str_content_page); // ép kiểu về int số trang.

                }else{
                    sotrang = 1; // ép kiểu về int số trang.
                }

            }catch (Exception) { }

            content_page.Clear();
            content.RemoveAll();

            return sotrang;
        }

        // Lấy List quyển sách trong trang đầu
        private List<string> Get_LinkQuyenSach(string url_link)
        {
            List<string> list_qs = new List<string>();

            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(url_link);

            var content = doc1.DocumentNode.SelectSingleNode("//div[@class='panel panel-primary']");
            var content_1 = content.SelectNodes("//div[@class='panel-body']/div[@class='col-xs-6 col-md-3 col-sm-3 ebook']/h5[@class='tieude text-center']/a");

            // Tìm đc trang thứ nhất 
            for (int i_itemkind = 0; i_itemkind < content_1.Count; i_itemkind++)
            {
                string linkurl = content_1[i_itemkind].Attributes["href"].Value.ToString();
                list_qs.Add(linkurl);
            }

            content_1.Clear();
            content.RemoveAll();

            return list_qs;
        }

        // Lấy dữ liệu nội dung trong 1 quyển sách
        public void GetChiTiet(string link_chitiet, string ten_loaisach)
        {
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(link_chitiet);
            // Select Link cha

            try
            {
                var content = doc1.DocumentNode.SelectSingleNode("//div[@class='panel panel-primary']");
                // Select link con lấy tiêu đề
                var content_tieude = content.SelectNodes("//h1[@class='ebook_title text-primary']");
                string tieude = "";

                tieude = content_tieude[0].InnerHtml;

                var content_tacgia = content.SelectNodes("//h5[@class='']");
                string tacgia = "";

                tacgia = content_tacgia[0].InnerHtml;

                var content_mota = content.SelectNodes("//div[@class='gioi_thieu_sach text-justify']");
                string mota = "";

                for (int i = 0; i < content_mota.Count; i++)
                {
                    mota = System.Net.WebUtility.HtmlDecode(content_mota[i].InnerHtml.ToString().Trim());
                }

                string NgayCapNhat = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy hh:mm:ss");

                var kt_truyen = content.SelectNodes("//div[@id='list-chapter']");
                int Id_TheLoaiChuong = 1;

                if (!is_Tontaiquyensach(tieude))
                {

                    //Kiểm tra truyện đọc hay pdf Id_TheLoaiChuong

                    if (kt_truyen != null && kt_truyen.Count > 0)
                    {
                        Id_TheLoaiChuong = 1; // Loai truyện đọc

                        string image_view = GetHinhAnhDaiDien(link_chitiet);

                        string get_IdLoaisach = GetIdTheLoaiSach_ByName(ten_loaisach);

                        TH_QuyenSachService.TH_QuyenSach_Insert(tieude.ToString(), tacgia.ToString(), mota.ToString(), "0", get_IdLoaisach, "0", image_view.ToString(), Id_TheLoaiChuong.ToString(), NgayCapNhat.ToString());

                        // Lấy tổng số chương .
                        List<string> Tong_link_chuong = new List<string>();
                        // số trang = Get_Page_Chuong(Nhập đường dẫn link)
                        int getpage_chuong = Get_Page_Chuong(link_chitiet);
                        string getlink_chuong = ""; // Hiện link + / + số phần tử trang
                        string item_chuong = ""; // item phần tử con của chương 
                        for (int i = 1; i <= getpage_chuong; i++) // bắt đầu từ phần tử thứ 1 vì luôn luôn là trang 1.getpage_chuong
                        {
                            getlink_chuong = link_chitiet + "/" + i;
                            List<string> listcon_chuong = GetLinkChuong(getlink_chuong);

                            for (int j = 0; j < listcon_chuong.Count; j++)
                            {
                                item_chuong = listcon_chuong[j];
                                Tong_link_chuong.Add(item_chuong);
                                //view += item_chuong; // cho nó hiện toàn bộ đường link theo chương để lấy các chi tiết nội dung trong đó. 
                                // Gọi đến hàm chi tiết chương.
                                GetChiTietTrongChuong(item_chuong, tieude);
                            }
                        }

                    }
                    else
                    {
                        Id_TheLoaiChuong = 2; // Truyện Pdf

                        string image_view = GetHinhAnhDaiDien(link_chitiet);

                        string get_IdLoaisach = GetIdLoaiSach();

                        TH_QuyenSachService.TH_QuyenSach_Insert(tieude.ToString(), tacgia.ToString(), mota.ToString(), "0", get_IdLoaisach, "0", image_view.ToString(), Id_TheLoaiChuong.ToString(), NgayCapNhat.ToString());

                        string link_view_pdf = GetPdf(link_chitiet);

                        string get_IdQuyenSach = GetIdQuyenSach();

                        TH_ChuongPDFService.TH_ChuongPDF_Insert(get_IdQuyenSach, "", link_view_pdf, "0", "1", NgayCapNhat);
                    }
                }
                else
                { // ton tai quyen sach 

                    if (kt_truyen != null && kt_truyen.Count > 0)
                    {
                        Id_TheLoaiChuong = 1; // Loai truyện đọc

                        // Lấy tổng số chương .
                        List<string> Tong_link_chuong = new List<string>();
                        // số trang = Get_Page_Chuong(Nhập đường dẫn link)
                        int getpage_chuong = Get_Page_Chuong(link_chitiet);
                        string getlink_chuong = ""; // Hiện link + / + số phần tử trang
                        string item_chuong = ""; // item phần tử con của chương 
                        for (int i = 1; i <= getpage_chuong; i++) // bắt đầu từ phần tử thứ 1 vì luôn luôn là trang 1.
                        {
                            getlink_chuong = link_chitiet + "/" + i;
                            List<string> listcon_chuong = GetLinkChuong(getlink_chuong);

                            for (int j = 0; j < listcon_chuong.Count; j++)
                            {
                                item_chuong = listcon_chuong[j];
                                Tong_link_chuong.Add(item_chuong);
                                //view += item_chuong; // cho nó hiện toàn bộ đường link theo chương để lấy các chi tiết nội dung trong đó. 
                                // Gọi đến hàm chi tiết chương.
                                GetChiTietTrongChuong(item_chuong, tieude);
                            }
                        }

                    }
                    else
                    {
                        //Id_TheLoaiChuong = 2; // Truyện Pdf

                        //string image_view = GetHinhAnhDaiDien(link_chitiet);

                        //string get_IdLoaisach = GetIdLoaiSach();

                        //TH_QuyenSachService.TH_QuyenSach_Insert(tieude.ToString(), tacgia.ToString(), mota.ToString(), "0", get_IdLoaisach, "0", image_view.ToString(), Id_TheLoaiChuong.ToString(), NgayCapNhat.ToString());

                        //string link_view_pdf = GetPdf(link_chitiet);

                        //string get_IdQuyenSach = GetIdQuyenSach();

                        //TH_ChuongPDFService.TH_ChuongPDF_Insert(get_IdQuyenSach, "", link_view_pdf, "0", "1", NgayCapNhat);
                    }


                }

                content.RemoveAll();
            }
            catch (Exception)
            { }

            // Lấy tổng số chương .
            //List<string> Tong_link_chuong = new List<string>();
            //// số trang = Get_Page_Chuong(Nhập đường dẫn link)
            //int getpage_chuong = Get_Page_Chuong(link_chitiet);
            //string getlink_chuong = ""; // Hiện link + / + số phần tử trang
            //string item_chuong = ""; // item phần tử con của chương 
            //for (int i = 1; i <= 1; i++) // bắt đầu từ phần tử thứ 1 vì luôn luôn là trang 1.
            //{
            //    getlink_chuong = link_chitiet + "/" + i;
            //    List<string> listcon_chuong = GetLinkChuong(getlink_chuong);

            //    for (int j = 0; j < 1; j++)
            //    {
            //        item_chuong = listcon_chuong[j];
            //        Tong_link_chuong.Add(item_chuong);
            //        //view += item_chuong; // cho nó hiện toàn bộ đường link theo chương để lấy các chi tiết nội dung trong đó. 

            //        // Gọi đến hàm chi tiết chương.
            //        GetChiTietTrongChuong(item_chuong);
            //    }
            //}       
            //_test(tieude + "\n" + tacgia + "\n" + mota + "\n" + Id_TheLoaiChuong + "\n" + image_view);
        }



        // Lấy Danh Sách Chương 
        private List<string> GetLinkChuong(string url_getlinkchuong)
        {
            List<string> list_chuong = new List<string>();
            try
            {
                HtmlDocument doc1 = doc1 = new HtmlDocument();
                doc1 = get_doc_html(url_getlinkchuong);

                var content = doc1.DocumentNode.SelectSingleNode("//div[@class='panel panel-primary']");
                var content_1 = content.SelectNodes("//div[@id='list-chapter']/li/a");

                // Tìm đc trang thứ nhất 
                for (int i_itemkind = 0; i_itemkind < content_1.Count; i_itemkind++)
                {
                    string linkurl = content_1[i_itemkind].Attributes["href"].Value.ToString();
                    list_chuong.Add(linkurl);
                }
                content_1.Clear();
                content.RemoveAll();
            }
            catch (Exception)
            { }

            return list_chuong;
        }

        // Kiểm tra tổng số trang trong chi tiết quyển sách theo Chương.
        private int Get_Page_Chuong(string url_page)
        {
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(url_page);
            string str_content_page = "";
            int page_chuong = 1;

            var content = doc1.DocumentNode.SelectSingleNode("//div[@class='ebook_row']");
            var content_page_chuong = content.SelectNodes("//ul[@class='pagination pagination-sm']/li/a");


            if (content_page_chuong != null)
            {
                if (content_page_chuong.Count > 6)
                {
                    for (int i = 0; i < content_page_chuong.Count; i++)
                    {
                        str_content_page += content_page_chuong[i].InnerHtml;
                        string[] th1_page = str_content_page.Split(';');
                        str_content_page = th1_page.Last().Trim();
                    }
                }
                else
                {
                    for (int i = 0; i < content_page_chuong.Count - 1; i++)
                    {
                        str_content_page += content_page_chuong[i].InnerHtml;
                        str_content_page = str_content_page.Substring(str_content_page.Length - 1).ToString();
                    }
                }
                page_chuong = int.Parse(str_content_page);
            }

            content.RemoveAll();

            // _test(str_content_page);

            return page_chuong;
        }

        // Lấy hình ảnh đại diện
        private string GetHinhAnhDaiDien(string url_image)
        {
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(url_image);
            string url_img = "";
            var content = doc1.DocumentNode.SelectSingleNode("//div[@class='col-md-4 cover']");
            var content_image = content.SelectNodes("//img[@class='img-thumbnail']");
            try
            {
                //string str_hinhanhdaidien = "";
                for (int dfa = 0; dfa < content_image.Count; dfa++)
                {
                    string linkurl = content_image[dfa].Attributes["src"].Value.ToString().Replace("200x200", "800x400");//745x510

                    //    //save anh nhe
                    string[] l_tenanh = linkurl.Split('/');

                    // Cat chuoi duong dan chi lay ten cham duoi jpg
                    //string s_ten_anh_daidien = System.Net.WebUtility.HtmlDecode(l_tenanh.Last().Trim()).Replace("png", "jpg");
                    string s_ten_anh_daidien = l_tenanh.Last().Trim();

                    // Đưa link hình ảnh đại diện để đưa lên sever Công thức : 
                    //SQL sever + (đường dẫn link) \UserFiles\image\AnhDaiDienQuyenSach\ + tên .jpg ;
                    url_img = @"\UserFiles\image\AnhDaiDienQuyenSach\" + s_ten_anh_daidien;

                    //save image ok
                    string https = "https://sachvui.com";
                    bool isExists = linkurl.Contains(@"https://");
                    try
                    {
                        if (isExists == true) // kiểm tra đúng sai hàm bool của biến isExists nếu linkurl có chuỗi ký tự giống với @"https://" thì xóa link http
                        {
                            SaveImages(linkurl, s_ten_anh_daidien, "");
                        }
                        else // ngược lại nếu hàm bool sai thì gắng thêm link http
                        {
                            SaveImages(https + linkurl, s_ten_anh_daidien, "");
                        }
                    }
                    catch (Exception ex)
                    { }
                }
            }
            catch (Exception)
            { }

            content_image.Clear();
            content.RemoveAll();

            return url_img;
        }

        // Code lưu ảnh đại diện của quyển sách
        public void SaveImages(string url, string nameImages, string imagedaidien)
        {

            try
            {
                // string localPath = @"E:\File Lay Du Lieu\UserFiles"; // Lay duong dan vat ly cua sever
                //string localFilename_mau = localPath + @"\Mau\" + nameImages; // đường dẫn lưu file vào thư mục Mẫu

                //string[] namefile = nameImages.Split('.');

                //string get_namefile = namefile.First().Trim();

                string localFilename = localPath + @"\image\AnhDaiDienQuyenSach\" + nameImages; // đường dẫn cuối cùng để lưu file hình ảnh .

                string localFilename_thumb = localPath_thum + @"\AnhDaiDienQuyenSach\" + nameImages; // phần này đúng lưu vào thư mục Thumb

                //nameImages;
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }

                //if (!Directory.Exists(localPath + @"\Mau"))
                //{
                //    Directory.CreateDirectory(localPath + @"\Mau");
                //}

                if (!Directory.Exists(localPath_thum))
                {
                    Directory.CreateDirectory(localPath_thum);
                }

                using (WebClient client = new WebClient())
                {
                    //luu anhmau
                    client.DownloadFile(url, localFilename);
                    client.Dispose();
                    //dongdau
                    //dongdauanh(@"E:\File Lay Du Lieu\GetDataBatDongSan\Get_Data\Images\logodau1.png", localFilename_mau, localFilename);

                    //client.DownloadFile(url, localFilename);

                    Bitmap bmp = CreateThumbnail(localFilename, 100, 100);
                    bmp.Save(localFilename_thumb);
                }
            }
            catch (Exception)
            {
            }
        }

        // Code tạo ảnh bitmap Thumbnail
        public static Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
        {
            System.Drawing.Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it
                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();
            }
            catch
            {
                return null;
            }

            return bmpOut;
        }


        // Hàm lưu ảnh trong chap truyện 
        public void SaveImage_Chuong(string url, string nameImages, string tenquyensach)
        {
            try
            {

                string localFilename = localPath + @"\image\" + tenquyensach + "\\" + nameImages; // đường dẫn cuối cùng để lưu file hình ảnh .

                string localFilename_thumb = localPath_thum + "\\" + tenquyensach + "\\" + nameImages; // phần này đúng lưu vào thư mục Thumb

                //nameImages;
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }

                if (!Directory.Exists(localPath + @"\image\" + tenquyensach))
                {
                    Directory.CreateDirectory(localPath + @"\image\" + tenquyensach);
                }

                if (!Directory.Exists(localPath_thum))
                {
                    Directory.CreateDirectory(localPath_thum);
                }

                if (!Directory.Exists(localPath_thum + "\\" + tenquyensach))
                {
                    Directory.CreateDirectory(localPath_thum + "\\" + tenquyensach);
                }

                using (WebClient client = new WebClient())
                {
                    //luu anhmau
                    client.DownloadFile(url, localFilename);
                    client.Dispose();
                    //dongdau
                    //dongdauanh(@"E:\File Lay Du Lieu\GetDataBatDongSan\Get_Data\Images\logodau1.png", localFilename_mau, localFilename);

                    //client.DownloadFile(url, localFilename);

                    Bitmap bmp = CreateThumbnail(localFilename, 100, 100);
                    bmp.Save(localFilename_thumb);
                }
            }
            catch (Exception)
            { }
        }


        // Hàm bỏ dấu tiếng việt và thêm dấu- để tạo folder
        public static string NameToTag(string strName)
        {
            string strReturn = "";
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            strReturn = Regex.Replace(strName, "[^\\w\\s]", string.Empty).Replace(" ", "-").ToLower();
            string strFormD = strReturn.Normalize(NormalizationForm.FormD);
            return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
        }

        //Kiêtm tra tồn tại tin
        private bool is_Tontaitheloaisach(string tentheloaisach)
        {
            //ton tai = true
            // ko ton tai = false

            var dt = TH_TheLoaiSachService.TH_TheLoaiSach_GetByTop("", "TenTheLoaiSach like N'" + tentheloaisach + "'", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }

        }

        private bool is_Tontaiquyensach(string tenquyensach)
        {
            //ton tai = true
            // ko ton tai = false

            var dt = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "TieuDe_QuyenSach like N'" + tenquyensach + "'", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }

        }

        private bool is_Tontaichuong(string tenchuong)
        {
            //ton tai = true
            // ko ton tai = false

            var dt = TH_ChuongService.TH_Chuong_GetByTop("", "TieuDe like N'" + tenchuong + "'", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }

        }

        // Ham lay id theo ten sach
        private string GetIdQuyenSach_ByName(string TenSach)
        {
            var dt = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "TieuDe_QuyenSach like N'" + TenSach + "'", "");

            string id_dt = dt.Rows[0]["Id"].ToString();

            return id_dt;
        }

        // Ham lay id theo the loai sach
        private string GetIdTheLoaiSach_ByName(string TenTheLoaiSach)
        {
            var dt = TH_TheLoaiSachService.TH_TheLoaiSach_GetByTop("", "TenTheLoaiSach like N'" + TenTheLoaiSach + "'", "");

            string id_dt = dt.Rows[0]["Id"].ToString();

            return id_dt;
        }


        // Hàm lấy và lưu file ảnh Pdf
        private string GetPdf(string url_pdf)
        {
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(url_pdf);
            string url_img_pdf = "";
            var content = doc1.DocumentNode.SelectSingleNode("//div[@class='row thong_tin_ebook']");

            try
            {
                var content_image = content.SelectNodes("//a[@class='btn btn-danger']");

                if (content_image != null && content_image.Count > 0)
                {
                    //string str_hinhanhdaidien = "";
                    for (int dfa = 0; dfa < content_image.Count; dfa++)
                    {
                        string linkurl_pdf = content_image[dfa].Attributes["href"].Value.ToString().Replace(".pdf", ".pdf");//745x510

                        //    //save anh nhe
                        string[] l_tenpdf = linkurl_pdf.Split('/');

                        // Cat chuoi duong dan chi lay ten cham duoi jpg
                        string s_ten_anh_daidien = l_tenpdf.Last().Trim();


                        // Đưa link hình ảnh đại diện để đưa lên sever Công thức : 
                        //SQL sever + (đường dẫn link) \UserFiles\image\AnhDaiDienQuyenSach\ + tên .jpg ;
                        url_img_pdf = @"\UserFiles\files\" + s_ten_anh_daidien + ".pdf";

                        //save image ok
                        string https = "https://sachvui.com";
                        bool isExists = linkurl_pdf.Contains(@"https://");
                        try
                        {
                            if (isExists == true) // kiểm tra đúng sai hàm bool của biến isExists nếu linkurl có chuỗi ký tự giống với @"https://" thì xóa link http
                            {
                                SaveImage_PDF(linkurl_pdf, s_ten_anh_daidien);
                            }
                            else // ngược lại nếu hàm bool sai thì gắng thêm link http
                            {
                                SaveImage_PDF(https + linkurl_pdf, s_ten_anh_daidien);
                            }
                        }
                        catch (Exception ex)
                        { }
                    }

                    content_image.Clear();
                }
                else
                {
                    url_img_pdf = GetEPUB(url_pdf);
                }


            }
            catch (Exception)
            { }


            content.RemoveAll();

            //_test(url_img_pdf);
            return url_img_pdf;
        }

        public void SaveImage_PDF(string url, string nameImages)
        {
            try
            {

                string localFilename = localPath + @"\files\" + nameImages + ".pdf"; // đường dẫn cuối cùng để lưu file hình ảnh .

                //nameImages;
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }

                using (WebClient client = new WebClient())
                {
                    //luu anhmau
                    client.DownloadFile(url, localFilename);
                    client.Dispose();

                    //dongdau
                    //dongdauanh(@"E:\File Lay Du Lieu\GetDataBatDongSan\Get_Data\Images\logodau1.png", localFilename_mau, localFilename);

                    //client.DownloadFile(url, localFilename);

                    //Bitmap bmp = CreateThumbnail(localFilename, 100, 100);
                    //bmp.Save(localFilename_thumb);
                }
            }
            catch (Exception)
            { }
        }


        // Hàm lấy và lưu file ảnh Epub
        private string GetEPUB(string url_epub)
        {
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(url_epub);
            string url_img_url_epub = "";
            var content = doc1.DocumentNode.SelectSingleNode("//div[@class='row thong_tin_ebook']");

            try
            {
                var content_image = content.SelectNodes("//a[@class='btn btn-primary']");
                //string str_hinhanhdaidien = "";
                for (int dfa = 0; dfa < content_image.Count; dfa++)
                {
                    string linkurl_pdf = content_image[dfa].Attributes["href"].Value.ToString().Replace(".epub", ".epub");//745x510

                    //    //save anh nhe
                    string[] l_tenpdf = linkurl_pdf.Split('/');

                    // Cat chuoi duong dan chi lay ten cham duoi jpg
                    string s_ten_anh_daidien = l_tenpdf.Last().Trim();


                    // Đưa link hình ảnh đại diện để đưa lên sever Công thức : 
                    //SQL sever + (đường dẫn link) \UserFiles\image\AnhDaiDienQuyenSach\ + tên .jpg ;
                    url_img_url_epub = @"\UserFiles\files\" + s_ten_anh_daidien + ".epub";

                    //save image ok
                    string https = "https://sachvui.com";
                    bool isExists = linkurl_pdf.Contains(@"https://");
                    try
                    {
                        if (isExists == true) // kiểm tra đúng sai hàm bool của biến isExists nếu linkurl có chuỗi ký tự giống với @"https://" thì xóa link http
                        {
                            SaveImage_EPUB(linkurl_pdf, s_ten_anh_daidien);
                        }
                        else // ngược lại nếu hàm bool sai thì gắng thêm link http
                        {
                            SaveImage_EPUB(https + linkurl_pdf, s_ten_anh_daidien);
                        }
                    }
                    catch (Exception ex)
                    { }
                }

                content_image.Clear();
            }
            catch (Exception)
            { }


            content.RemoveAll();

            //_test(url_img_pdf);
            return url_img_url_epub;
        }

        public void SaveImage_EPUB(string url, string nameImages)
        {
            try
            {

                string localFilename = localPath + @"\files\" + nameImages + ".epub"; // đường dẫn cuối cùng để lưu file hình ảnh .

                //nameImages;
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }

                using (WebClient client = new WebClient())
                {
                    //luu anhmau
                    client.DownloadFile(url, localFilename);
                    client.Dispose();

                    //dongdau
                    //dongdauanh(@"E:\File Lay Du Lieu\GetDataBatDongSan\Get_Data\Images\logodau1.png", localFilename_mau, localFilename);

                    //client.DownloadFile(url, localFilename);

                    //Bitmap bmp = CreateThumbnail(localFilename, 100, 100);
                    //bmp.Save(localFilename_thumb);
                }
            }
            catch (Exception)
            { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}