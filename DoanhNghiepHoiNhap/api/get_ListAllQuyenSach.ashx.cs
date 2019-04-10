using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanhNghiepHoiNhap.api
{
    /// <summary>
    /// Summary description for get_ListAllQuyenSach
    /// </summary>
    public class get_ListAllQuyenSach : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            //string id_allquyensach = "264";

            //string page = "1";

            string id_allquyensach = context.Request.Params["id_allquyensach"].ToString();

            string page = context.Request.Params["page"].ToString();

            context.Response.ContentType = "text/plain";

            context.Response.Write(StringClass._get_AllQuyenSach(id_allquyensach, page));
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