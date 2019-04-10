using System;
using System.Web;
using System.Web.Routing;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap
{
    public class Global : HttpApplication
    {
        private void RegisterRouter()
        {
            RouteTable.Routes.MapPageRoute("chuyende1", "chuyende.html", "~/ChuyenDe/cap1.aspx");
            RouteTable.Routes.MapPageRoute("cacbvkhac", "chuyende/cactinkhac/{title}.html", "~/ChuyenDe/cactinkhac.aspx");
            RouteTable.Routes.MapPageRoute("chuyende2", "chuyende/{cdid}/{title}.html", "~/ChuyenDe/cap2.aspx");
            RouteTable.Routes.MapPageRoute("chuyende3", "chuyende/{cdid}/{dmid}/{title}.html", "~/ChuyenDe/cap3.aspx");
            RouteTable.Routes.MapPageRoute("chuyende4", "chuyende/{cdid}/{dmid}/{bvid}/{title}.html", "~/ChuyenDe/cap4.aspx");
            RouteTable.Routes.MapPageRoute("cactinkhac", "cactinkhac/{tag}.html", "~/CacTinCuHon.aspx");
            RouteTable.Routes.MapPageRoute("hinhanh", "multimedia/hinhanh.html", "~/multimedia_list.aspx");
            RouteTable.Routes.MapPageRoute("video", "multimedia/video.html", "~/multimedia_list.aspx");
            RouteTable.Routes.MapPageRoute("tintuc", "tin-tuc.html", "~/tintuc.aspx");
            RouteTable.Routes.MapPageRoute("rss_cate", "rss.html", "~/rsscategory.aspx");
            RouteTable.Routes.MapPageRoute("chuyenmuccon", "chuyenmuc/{tag}.html", "~/chuyenmuccon.aspx");
            RouteTable.Routes.MapPageRoute("chuyenmuc", "{tag}.html", "~/chuyenmuc.aspx");
            RouteTable.Routes.MapPageRoute("rss", "{tag}.rss", "~/rss.aspx");
            RouteTable.Routes.MapPageRoute("cacbaikhac", "cacbaikhac/{tag}.html", "~/CacBaiKhac.aspx");
            RouteTable.Routes.MapPageRoute("cacbaikhac1", "cacbaikhac-chuyenmuc/{tag}.html", "~/CacBaiKhac.aspx");
            
            RouteTable.Routes.MapPageRoute("multimedia", "multimedia/{id}/{title}.html", "~/multimedia.aspx");
            RouteTable.Routes.MapPageRoute("tag", "tag/{value}.html", "~/Tag.aspx");

            RouteTable.Routes.MapPageRoute("hoidap_dangky", "hoidap/dangky.html", "~/HoiDap/DangKy.aspx");
            RouteTable.Routes.MapPageRoute("hoidap", "hoidap/{id}/{title}.html", "~/HoiDap/hoidap.aspx");
            RouteTable.Routes.MapPageRoute("hoidap2", "hoidap/{phanloai}/{idcauhoi}/{title}.html", "~/HoiDap/chitietcauhoi.aspx");

            RouteTable.Routes.MapPageRoute("chitiettin", "{tag}/{tagTin}.html", "~/chitiettin.aspx");
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRouter();
            Application.Add("OnlineCount", 1);
            Application.Add("VisitedCount", 1);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 120;
            bool kt = ThongKeTruyCapService.ThongKeTruyCap_GetByDate(DateTimeClass.ConvertDateTime(
                                                                                   DateTime.Now.ToString(), "MM/dd/yyyy"));
            if (!kt)
                ThongKeTruyCapService.ThongKeTruyCap_Insert(DateTimeClass.ConvertDateTime(DateTime.Now.ToString(), "MM/dd/yyyy"), "1");
            else
                ThongKeTruyCapService.ThongKeTruyCap_UpdateDate(DateTimeClass.ConvertDateTime(DateTime.Now.ToString(), "MM/dd/yyyy"));
            //----------------OnlineCount--------------------------------
            int onlineVisit;
            int visited;
            if (Application["OnlineCount"] == null)
            {
                onlineVisit = 1;
                visited = 1;
            }
            else
            {
                onlineVisit = int.Parse(Application["OnlineCount"].ToString()) + 1;
                visited = int.Parse(Application["VisitedCount"].ToString()) + 1;
            }
            Application.Lock();
            Application["OnlineCount"] = onlineVisit;
            Application["VisitedCount"] = visited;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Response.Redirect("~/Error.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["OnlineCount"] = int.Parse(Application["OnlineCount"].ToString()) - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}