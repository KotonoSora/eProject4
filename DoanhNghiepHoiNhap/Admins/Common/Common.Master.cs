using System;
using System.Data;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class Common : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null) Response.Redirect("~/Admins/login.aspx");
            if (Session["lang"] == null)
                Session["lang"] = "1";
            if (Session["Username"] != null)
            {
                if (Session["lang"].ToString() == "1")
                {
                    //imgNgonNgu.ImageUrl = "~/Pic/vietnam.png";
                    //lbtChuyenNgonNgu.Text = "Chuyển sang Tiếng Anh";
                    lbthoten.Text = "Xin chào: " + Session["Username"];
                    ltrTitle.Text = "Trang quản trị";
                    lbtthoat.Text = "Đăng Xuất";
                    
                    //ltrHuongDanSuDung.Text = "Hướng dẫn sử dụng";
                }
                else
                {
                   // imgNgonNgu.ImageUrl = "~/Pic/english.png";
                    //lbtChuyenNgonNgu.Text = "Change to Vietnamese";
                    lbthoten.Text = "Welcome: " + Session["Username"];
                    ltrTitle.Text = "Administrator Control Panel";
                    lbtthoat.Text = "Loguot";
                    
                    //ltrHuongDanSuDung.Text = "User Guide";
                }
            }

            if (!IsPostBack)
            {

                //if (Session["Username"] != null)
                //    lbthoten.Text = "Xin chào: " + Session["Username"] + " - " + ReturnRoleName();
                ShowHideControl();
                //Ẩn hiện control 
                if (lbtNguoiDung.Visible == false && lbtPhanQuyenChucNang.Visible == false)
                {
                    pnNguoiDung.Visible = false;
                    pnNguoiDungContent.Visible = false;
                }

                //lbtNhomHangHoa.Visible = false;
                //lbtHangHoa.Visible = false;
                if (lbtNhomHangHoa.Visible == false && lbtHangHoa.Visible == false && lbtLoaiChuong.Visible == false
                    && lbtTheLoaiSach.Visible == false && lbtQuyenSach.Visible == false && lbtChuong.Visible == false
                    //&& lbtChuongPDF.Visible == false && lbtChuongTruyenTranh.Visible == false
                    )
                {
                    pnSanPham.Visible = false;
                    pnSanPhamContent.Visible = false;
                }
                if (lbtDangTin.Visible == false && lbtNhomTin.Visible == false)
                {
                    pnTinTuc.Visible = false;
                    pnTinTucContent.Visible = false;
                }

                if (lbtCauHinhChung.Visible == false && lbtQuanLyMenu.Visible == false  &&
                    lbtQuanLyLienHe.Visible == false && lbtThongKeTruyCap.Visible == false && 
                    lbtQuangCao.Visible == false )
                {
                    pnWebsite.Visible = false;
                    pnWebsiteContent.Visible = false;
                }
            }
        }

        public string ReturnRoleName()
        {
            return TT_NhomNguoiDungService.TT_NhomNguoiDung_GetById(Session["Role"].ToString()).Rows[0]["TenNhom"].ToString();
        }

        protected void lbtthoat_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Admins/Login.aspx");
        }

        private void ShowHideControl()
        {
            try
            {
                DataTable dtChucNang = TT_ChucNangService.TT_ChucNang_GetAll();
                for (int i = 0; i < dtChucNang.Rows.Count; i++)
                {
                    string controlId = dtChucNang.Rows[i]["TenChucNang"].ToString();
                    var control = FindControl(controlId);
                    if (control == null) continue;
                    control.Visible = PhanQuyen(controlId);
                }
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        private bool PhanQuyen(string controlId)
        {
            DataTable dtChucNang = TT_ChucNangService.TT_ChucNang_GetByTop("1", "TenChucNang='" + controlId + "'", "");
            DataTable dt = TT_PhanQuyenService.TT_PhanQuyen_GetByForeignKey(Session["Role"].ToString(), dtChucNang.Rows[0]["Id"].ToString());
            return dt.Rows.Count > 0;
        }

        protected void lbtNguoiDung_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TM_ThanhVien.aspx");
        }

        protected void lbtQuangCao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TT_QuangCao.aspx");
        }

        protected void lbtCauHinhChung_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TT_CauHinhChung.aspx");
        }

        protected void lbtPhanQuyenChucNang_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/PhanQuyenChucNang.aspx");
        }

        protected void lbtQuanLyMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TT_Menu.aspx");
        }

        protected void lbtQuanLyLienHe_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Admins/Common/TT_LienHe.aspx");
            Response.Redirect("~/Admins/Common/QuanLyKhachHang.aspx");
        }

        //protected void lbtQuanLyKhachHang_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Admins/Common/QuanLyKhachHang.aspx");
        //}

        protected void lbtThongKeTruyCap_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/ThongKeTruyCap.aspx");
        }

        protected void lbtNhomTin1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TT_NhomTin.aspx");
        }

        protected void lbtDangTin1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TT_TinTuc.aspx");
        }

        protected void lbtHoTroTrucTuyen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TM_HoTroTrucTuyen.aspx");
        }

        protected void lbtNhomHangHoa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TM_NhomHangHoa.aspx");
        }
        protected void lbtHangHoa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TM_HangHoa.aspx");
        }
        protected void lbtVideo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TT_Multimedia.aspx");
        }

        protected void lbtNhomHinhAnh_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/NhomHinhAnh.aspx");
        }

        // Add Code App Sach Vui 
        protected void lbtLoaiChuong_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TH_LoaiChuong.aspx");
        }

        protected void lbtTheLoaiSach_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TH_TheLoaiSach.aspx");
        }
        protected void lbtQuyenSach_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TH_QuyenSach.aspx");
        }
        protected void lbtChuong_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/TH_Chuong.aspx");
        }
       
        // Kết thúc Add Code


        //protected void lbtDoanhNghiep_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Admins/Common/DoanhNghiepQueHuong.aspx");
        //}

        //protected void lbtDoanhNhan_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Admins/Common/DoanhNhanThanhDat.aspx");
        //}
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("#");
        }

        protected void lbtChuyenNgonNgu_Click(object sender, EventArgs e)
        {
            if (Session["lang"].ToString() == "1")
                Session["lang"] = "2";
            else Session["lang"] = "1";
            Response.Redirect(Request.Url.ToString());
        }
    }
}