using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanhNghiepHoiNhap.api
{
    /// <summary>
    /// Summary description for get_InfoQuyenSach
    /// </summary>
    public class get_InfoQuyenSach : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string Id_quyensach = context.Request.Params["Id_quyensach"].ToString();

            string Id_TheLoaiSach = context.Request.Params["Id_TheLoaiSach"].ToString();

            //string Id_quyensach = "1210";

            //string Id_TheLoaiSach = "265";


            context.Response.ContentType = "text/plain";

            context.Response.Write(StringClass._get_infoQuyenSach(Id_quyensach, Id_TheLoaiSach));
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