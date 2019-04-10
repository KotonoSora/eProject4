using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanhNghiepHoiNhap.api
{
    /// <summary>
    /// Summary description for get_TimKiemQuyenSach
    /// </summary>
    public class get_TimKiemQuyenSach : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string timkiem = context.Request.Params["timkiem"].ToString();

            string id_TheLoaiSach = context.Request.Params["id_TheLoaiSach"].ToString();

            //string timkiem = "anh";

            //string id_TheLoaiSach = "264";

            context.Response.ContentType = "text/plain";

            context.Response.Write(StringClass._get_timkiem_theotacgiavatenquyensach(timkiem, id_TheLoaiSach));
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