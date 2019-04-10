using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanhNghiepHoiNhap.api
{
    /// <summary>
    /// Summary description for get_ListAllChuong
    /// </summary>
    public class get_ListAllChuong : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //string id_chuong = "961";

            //string page = "2";

            string id_chuong = context.Request.Params["id_chuong"].ToString();

            string page = context.Request.Params["page"].ToString();

            context.Response.ContentType = "text/plain";

            context.Response.Write(StringClass._get_ListAllChuong(id_chuong, page));
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