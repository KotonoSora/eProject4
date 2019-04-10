using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanhNghiepHoiNhap.api
{
    /// <summary>
    /// Summary description for get_InfoChuong
    /// </summary>
    public class get_InfoChuong : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Id_chuong = context.Request.Params["id_chuong"].ToString();
            string Id_quyensach = context.Request.Params["id_quyensach"].ToString();

            //string Id_chuong = "6946";
            //string Id_quyensach = "482";

            context.Response.ContentType = "text/plain";

            context.Response.Write(StringClass._get_infoChuong(Id_chuong, Id_quyensach));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}