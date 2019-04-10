using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanhNghiepHoiNhap.api
{
    /// <summary>
    /// Summary description for get_AllChuong
    /// </summary>
    public class get_AllChuong : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Id_quyensach = "489";//context.Request.Params["Id_quyensach"].ToString();

            string page = "1";//context.Request.Params["page"].ToString();

            context.Response.ContentType = "text/plain";

            context.Response.Write(StringClass._get_AllChuong(Id_quyensach, page));
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