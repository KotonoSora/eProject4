using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanhNghiepHoiNhap.api
{
    /// <summary>
    /// Summary description for get_ListIdChuong
    /// </summary>
    public class get_ListIdChuong : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id_c_quyensach = context.Request.Params["id_c_quyensach"].ToString();

            //string id_chuong = "961";

            context.Response.ContentType = "text/plain";

            context.Response.Write(StringClass._get_ListAllIdChuong(id_c_quyensach));
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