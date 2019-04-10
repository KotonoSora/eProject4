using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanhNghiepHoiNhap.api
{
    /// <summary>
    /// Summary description for get_InfoChuongPDF
    /// </summary>
    public class get_InfoChuongPDF : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Id_quyensachPDF = context.Request.Params["id_quyensachpdf"].ToString();
            //string page = "1";//context.Request.Params["page"].ToString();

            context.Response.ContentType = "text/plain";

            context.Response.Write(StringClass._get_infoChuongPDF(Id_quyensachPDF));
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