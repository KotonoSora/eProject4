using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using IronPdf;

namespace DoanhNghiepHoiNhap.api
{
    public partial class View_ChuongPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //string sc = Request.Params["id_chuong"].ToString();
                    string qsach = Request.Params["id_qs"].ToString();

                    //string sc = "6963";
                    //string qsach = "2717";
                    if (qsach != null)
                    {
                        load_dulieu(qsach);
                    }
                }
                catch (Exception)
                {

                }

            }
        }

        public void load_dulieu(string id_qs)
        {
            var dt = TH_ChuongPDFService.TH_ChuongPDF_GetByTop("", "Id_QuyenSach = '" + id_qs + "'", "");

            if (dt != null && dt.Rows.Count > 0)
            {

                string msg = "";

                //Literal1.Text = "<img src='" + dt.Rows[0]["HinhAnhDuAn"].ToString() + "' />";
                //Label1.Text = "<i>" + _get_tenquyensach(dt_.Rows[0]["Id_QuyenSach"].ToString()) + "</i>" + "<br />";

                //Label2.Text = dt_.Rows[0]["TieuDe"].ToString() + "<br />";

                msg = dt.Rows[0]["LinkBDF"].ToString() + "<br />";

                Literal1.Text = msg;
            }
            else
            {
                WebMsgBox.Show("Danh sách chương đã hết !");
            }

        }
    }
}