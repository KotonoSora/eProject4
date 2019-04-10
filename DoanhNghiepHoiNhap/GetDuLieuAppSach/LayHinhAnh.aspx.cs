using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Get_Data
{
    public partial class LayHinhAnh : System.Web.UI.Page
    {
        //string url_path_local = @"E:\File Lay Du Lieu\Images";//@"D:\WebSites\nudoanhnhan.vn\admin.nudoanhnhan.vn";//path local to folder Userfiles
        //string url_luu_anh = @"E:\File Lay Du Lieu\UserFiles\images";
        string localPath = @"E:\CODE DỰ LIỆU WEBSITE\6.Admin_App_SachVui\v.10\admin\DoanhNghiepHoiNhap\UserFiles"; // Lay duong dan vat ly cua sever
        string localPath_thum = @"E:\CODE DỰ LIỆU WEBSITE\6.Admin_App_SachVui\v.10\admin\DoanhNghiepHoiNhap\UserFiles\_thumbs\Images";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //url_luu_anh = @"E:\File Lay Du Lieu\UserFiles\image";

            int page = 2;
            string msg = "";
            string url_test = "https://batdongsan.com.vn/can-ho-chung-cu";//test du an can ho chung cu

            //get_doc_html
            HtmlDocument doc1 = doc1 = new HtmlDocument();
            doc1 = get_doc_html(TextBox1.Text);

            try
            {
                string str_hinhanhdaidien = "";

                // var thuvienanh = doc1.DocumentNode.SelectSingleNode("//div[@class='list-img']/ul/li/img");
                //var thuvienanh = doc1.DocumentNode.SelectSingleNode("//div[@class='ctv_r']");
                //var v_thuvienanh = thuvienanh.SelectNodes("//div[@id='tab2']/p/img");

                var thuvienanh = doc1.DocumentNode.SelectSingleNode("//div[@class='doc-online']");
                var v_thuvienanh = thuvienanh.SelectNodes("//img[@class='truyen-tranh']");

                //var thuvienanh = doc1.DocumentNode.SelectSingleNode("//div[@id='dvContent']");
                //var v_thuvienanh = thuvienanh.SelectNodes("//img[@class='lazyOwl']");

                //var thuvienanh = doc1.DocumentNode.SelectSingleNode("//div[@id='block-3']");
                //var v_thuvienanh = thuvienanh.SelectNodes("//img[@class='img-responsive']");

                for (int dfa = 0; dfa < v_thuvienanh.Count; dfa++)
                {
                    string linkurl = v_thuvienanh[dfa].Attributes["src"].Value.ToString().Replace("200x200", "800x400");//745x510

                    //    //save anh nhe
                    string[] l_tenanh = linkurl.Split('/');

                    // Cat chuoi duong dan chi lay ten cham duoi jpg
                    //string s_ten_anh_daidien = System.Net.WebUtility.HtmlDecode(l_tenanh.Last().Trim()).Replace("png", "jpg");
                    string s_ten_anh_daidien = l_tenanh.Last().Trim();


                    string linkanh_thaythe = localPath + s_ten_anh_daidien;

                    if (dfa == 0)
                    {
                        str_hinhanhdaidien = linkanh_thaythe;
                    }

                    //save image ok

                    string https = "https://sachvui.com";

                    bool isExists = linkurl.Contains(@"https://");

                    try
                    {
                        if (isExists == true) // kiểm tra đúng sai hàm bool của biến isExists nếu linkurl có chuỗi ký tự giống với @"https://" thì xóa link http
                        {
                            SaveImages(linkurl, s_ten_anh_daidien);
                        }
                        else // ngược lại nếu hàm bool sai thì gắng thêm link http
                        {
                            SaveImages(https + linkurl, s_ten_anh_daidien);
                        }
                    }
                    catch (Exception ex)
                    { }


                    // msg += linkurl + @"<br \>" + linkanh_thaythe;
                }
            }
            catch (Exception)
            { }


        }
        //Luu hình ảnh
        public void SaveImages(string url, string nameImages)
        {

            try
            {
                // string localPath = @"E:\File Lay Du Lieu\UserFiles"; // Lay duong dan vat ly cua sever
                //string localFilename_mau = localPath + @"\Mau\" + nameImages; // đường dẫn lưu file vào thư mục Mẫu

                string localFilename = localPath + @"\image\" + nameImages; // đường dẫn cuối cùng để lưu file hình ảnh .

                string localFilename_thumb = localPath_thum + "\\" + nameImages; // phần này đúng lưu vào thư mục Thumb

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

        //string url_luu_anh = "";

        public void dongdauanh(string url_watermark, string url_anh, string luuanh)
        {
            Bitmap watermark = new Bitmap(url_watermark);
            Bitmap bitmap = new Bitmap(url_anh);

            bitmap = WatermarkImage(bitmap, watermark);


            bitmap = WatermarkImage_right_top(bitmap, watermark);

            bitmap = WatermarkImage_left_top(bitmap, watermark);

            bitmap = WatermarkImage_left_bottom(bitmap, watermark);

            bitmap = WatermarkImage_right_bottom(bitmap, watermark);

            bitmap.Save(luuanh);
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

        public static Bitmap WatermarkImage(Bitmap image, Bitmap watermark)
        {
            using (Graphics imageGraphics = Graphics.FromImage(image))
            {
                watermark.SetResolution(imageGraphics.DpiX, imageGraphics.DpiY);

                int x = (image.Width - watermark.Width) / 2;
                int y = (image.Height - watermark.Height) / 2;

                imageGraphics.DrawImage(watermark, x, y, watermark.Width, watermark.Height);
            }

            return image;
        }

        //right - top
        public static Bitmap WatermarkImage_right_top(Bitmap image, Bitmap watermark)
        {
            using (Graphics imageGraphics = Graphics.FromImage(image))
            {
                watermark.SetResolution(imageGraphics.DpiX, imageGraphics.DpiY);

                int x = image.Width - watermark.Width;
                int y = 0;

                imageGraphics.DrawImage(watermark, x, y, watermark.Width, watermark.Height);
            }

            return image;
        }

        //left - top
        public static Bitmap WatermarkImage_left_top(Bitmap image, Bitmap watermark)
        {
            using (Graphics imageGraphics = Graphics.FromImage(image))
            {
                watermark.SetResolution(imageGraphics.DpiX, imageGraphics.DpiY);

                int x = 0;
                int y = 0;

                imageGraphics.DrawImage(watermark, x, y, watermark.Width, watermark.Height);
            }

            return image;
        }

        //left - bottom
        public static Bitmap WatermarkImage_left_bottom(Bitmap image, Bitmap watermark)
        {
            using (Graphics imageGraphics = Graphics.FromImage(image))
            {
                watermark.SetResolution(imageGraphics.DpiX, imageGraphics.DpiY);

                int x = 0;
                int y = image.Height - watermark.Height;

                imageGraphics.DrawImage(watermark, x, y, watermark.Width, watermark.Height);
            }

            return image;
        }

        //left - bottom
        public static Bitmap WatermarkImage_right_bottom(Bitmap image, Bitmap watermark)
        {
            using (Graphics imageGraphics = Graphics.FromImage(image))
            {
                watermark.SetResolution(imageGraphics.DpiX, imageGraphics.DpiY);

                int x = image.Width - watermark.Width;
                int y = image.Height - watermark.Height;

                imageGraphics.DrawImage(watermark, x, y, watermark.Width, watermark.Height);
            }

            return image;
        }


        private void _test(string msg)
        {
            TextBox2.Text = msg;
            Literal1.Text = msg;
        }


    }
}