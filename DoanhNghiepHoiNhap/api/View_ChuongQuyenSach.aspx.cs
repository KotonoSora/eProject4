using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap.api
{
    public partial class View_ChuongQuyenSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string sc = Request.Params["id_chuong"].ToString();
                    string qsach = Request.Params["id_qs"].ToString();

                    //string sc = "6963";
                    //string qsach = "482";
                    if (sc != null && qsach != null)
                    {
                        load_dulieu(sc, qsach);
                    }
                }
                catch (Exception)
                {

                }

            }
        }

        public void load_dulieu(string id_chuong , string id_qs)
        {
            var dt = TH_ChuongService.TH_Chuong_GetById(id_chuong);

            string id_chuog = dt.Rows[0]["Id"].ToString();

            var dt_ = TH_ChuongService.TH_Chuong_GetByTop("", "Id = '" + id_chuog + "' and Id_QuyenSach = '" + id_qs + "'", "");

            if (dt_ != null && dt_.Rows.Count > 0)
            {

                string msg = "";

                //Literal1.Text = "<img src='" + dt.Rows[0]["HinhAnhDuAn"].ToString() + "' />";
                //Label1.Text = "<i>" + _get_tenquyensach(dt_.Rows[0]["Id_QuyenSach"].ToString()) + "</i>" + "<br />";

                Label2.Text = dt_.Rows[0]["TieuDe"].ToString() + "<br />";

                Literal1.Text = dt_.Rows[0]["NoiDung"].ToString() + "<br />";

                //msg = Label2.Text + Literal1.Text;
            }
            else
            {
                WebMsgBox.Show("Danh sách chương đã hết !");
            }

        }

        public static string _get_tenquyensach(string id)
        {
            var dt = TH_QuyenSachService.TH_QuyenSach_GetById(id);
            return dt.Rows[0]["TieuDe_QuyenSach"].ToString();
        }

        public static string _get_tenchuong(string id)
        {
            var dt = TH_ChuongService.TH_Chuong_GetById(id);
            return dt.Rows[0]["TieuDe"].ToString();
        }

    }
}