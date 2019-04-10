using System; 
using System.Data; 
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                btnDoiMK.Text = Languages.Lang.Show("changepassword");
        }

        protected void btnDoiMK_Click(object sender, EventArgs e)
        {
            DataTable dt = TM_ThanhVienService.TM_ThanhVien_GetById(Session["userid"].ToString());
            if (SqlDataProvider.Encrypt(txtOldPassword.Text, true) != dt.Rows[0]["MatKhau"].ToString())
            {
                WebMsgBox.Show(Languages.Lang.Show("oldpasswordfalse"));
                return;
            }
            if (txtNewpassword.Text != txtReNewPassword.Text)
            {
                WebMsgBox.Show(Languages.Lang.Show("newpasswordfalse"));
                return;
            }
            try
            {
                CommonService.UpdateValue("TM_ThanhVien",
                "MatKhau='" + SqlDataProvider.Encrypt(txtNewpassword.Text, true) + "'",
                "TenDangNhap='" + Session["Username"] + "'");
                WebMsgBox.Show(Languages.Lang.Show("updatesuccess"));
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}