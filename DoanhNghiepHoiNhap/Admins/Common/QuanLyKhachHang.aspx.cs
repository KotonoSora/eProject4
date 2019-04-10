using System;
using System.Data; 
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Languages;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class QuanLyKhachHang : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["lang"] == null) Session["lang"] = "1";
                lbtCancel.Text = Lang.Show("cancel");
               // txtMail.Text = Lang.Show("send") + "Email";
                LoadgrdShowTtLienHe();
            }
        }
        public string ReturnTrangThai(string s)
        {
            return s == "1" ? "<b style='color:blue;'>" + Lang.Show("viewed") + "</b>" : "<b style='color:red;'>" + Lang.Show("unread") + "</b>";
            //return s == "1" ? "<b style='color:blue;'>Đã xem</b>" : "<b style='color:red;'>Chưa xem</b>";
        }

        private void LoadgrdShowTtLienHe()
        {
            grd_showTT_LienHe.DataSource = TT_LienHeService.TT_LienHe_GetByTop("","","Id desc");
            grd_showTT_LienHe.DataBind();
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void grd_showTT_LienHe_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["ID"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    CommonService.UpdateValue("TT_LienHe", "TrangThai=1", "Id=" + ViewState["ID"]);
                    DataTable dt = TT_LienHeService.TT_LienHe_GetById(ViewState["ID"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTieuDe.Text = dt.Rows[0]["TieuDe"].ToString();
                        fckNoiDung.Value = dt.Rows[0]["NoiDung"].ToString();
                        txtNguoiGui.Text = dt.Rows[0]["NguoiGui"].ToString();
                        txtNgayGui.Text = dt.Rows[0]["NgayGui"].ToString();
                        txtMail.Text = dt.Rows[0]["Mail"].ToString();
                        txtSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString(); 
                        txtCongTy.Text = dt.Rows[0]["CongTy"].ToString();
                    }
                    dt.Clear();
                    pn_showTT_LienHe.Visible = false;
                    pn_updateTT_LienHe.Visible = true;
                    break;
                case "Delete": 
                    TT_LienHeService.TT_LienHe_Delete(ViewState["ID"].ToString());
                    LoadgrdShowTtLienHe();
                    break;
                default:
                    break;
            }
        }

        protected void txtGuiEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admins/Common/GuiEmail.aspx");
        }

    }
}