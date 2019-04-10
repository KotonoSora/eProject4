using System;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Data;

namespace WebDienThoai.Admins
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogon_Click(object sender, EventArgs e)
        {
            var dt = TM_ThanhVienController.TM_THANHVIEN_CheckLogin(txtUsername.Text.Trim(), SqlDataProvider.Encrypt(txtPassword.Text.Trim(), true));
            if (dt.Rows.Count == 0)
            {
                WebMsgBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                return;
            }

            if (dt.Rows[0]["TrangThai"].ToString() == "0")
            {
                WebMsgBox.Show("Tài khoản đã bị khóa");
                return;
            }
            Session["Role"] = dt.Rows[0]["NhomNguoiDung"].ToString();
            Session["Username"] = txtUsername.Text.Trim();
            Session["userid"] = dt.Rows[0]["Id"].ToString();
            Session["lang"] = ddlngonngu.SelectedValue;//ddlNgonNgu.SelectedValue;
            Response.Redirect("~/Admins/Common/Default.aspx");
        }
        protected void btnHuyBo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}