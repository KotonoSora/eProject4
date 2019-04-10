using System;
using System.Data;
using System.Web.UI; 
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Languages;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class TT_CauHinhChung : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["lang"] == null) Session["lang"] = "1";
                lbtUpdate_CauHinhChung.Text = Lang.Show("update");
                lbtCancel.Text = Lang.Show("cancel");

                DataTable dt = TT_CauHinhChungService.TT_CauHinhChung_GetById(Session["lang"].ToString());
                if (dt.Rows.Count==0) return;

                txtLogo.Text = dt.Rows[0]["Logo"].ToString();
                imgLogo.ImageUrl = dt.Rows[0]["Logo"].ToString();
                txtImgUrl.Text = dt.Rows[0]["Banner"].ToString();
                imgHinhAnh.ImageUrl = dt.Rows[0]["Banner"].ToString();
                fckFooter.Value = dt.Rows[0]["Footer"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                txtKeyword.Text = dt.Rows[0]["Keyword"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPassword.Text = dt.Rows[0]["Password"].ToString();
                fckThongTinLienHe.Value= dt.Rows[0]["ThongTinLienHe"].ToString();
                txtFacebook.Text = dt.Rows[0]["Banner_Mobile"].ToString();
                txtTieuDe.Text = dt.Rows[0]["Footer_Mobile"].ToString();

                txtGooglePlus.Text = dt.Rows[0]["GooglePlus"].ToString();
                txtTwitter.Text = dt.Rows[0]["Twitter"].ToString();
                txtYoutube.Text = dt.Rows[0]["Youtube"].ToString();

                fckThongTinLienHe2.Value = dt.Rows[0]["ThongTinLienHe2"].ToString();
                fckThongTinLienHe3.Value = dt.Rows[0]["ThongTinLienHe3"].ToString();
                txtBanDo.Text = dt.Rows[0]["BanDo"].ToString();

                txtSDT.Text = dt.Rows[0]["Sdt"].ToString();
                txtMotaGmail.Text = dt.Rows[0]["MoTaGmail"].ToString();
                txtMotaCall.Text = dt.Rows[0]["MoTaSdt"].ToString();
                txtMotaTweet.Text = dt.Rows[0]["MoTaTweet"].ToString();
                fckMotavisit.Value = dt.Rows[0]["MoTaVisitus"].ToString();
            }
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            string id = Session["lang"].ToString() == "1" ? "1" : "2";
            TT_CauHinhChungService.TT_CauHinhChung_Update(id, txtLogo.Text, txtImgUrl.Text, fckFooter.Value, txtDescription.Text, 
                txtKeyword.Text, txtEmail.Text, txtPassword.Text, "0", "1", "1", fckThongTinLienHe.Value, "1", txtFacebook.Text, 
                txtTieuDe.Text, txtGooglePlus.Text, txtTwitter.Text, txtYoutube.Text , fckThongTinLienHe2.Value , fckThongTinLienHe3.Value,
                txtBanDo.Text, txtSDT.Text, txtMotaGmail.Text, txtMotaCall.Text, txtMotaTweet.Text, fckMotavisit.Value);
            WebMsgBox.Show(Lang.Show("updatesuccess"));
        } 
    }
}