using System; 
using System.Data; 
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class ThongKeTruyCap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = StringClass.ConvertDateTime(DateTime.Now.ToShortDateString());
                TextBox2.Text = StringClass.ConvertDateTime(DateTime.Now.ToShortDateString());
                Label1.Text = Languages.Lang.Show("onlinecount") + ": " + Application["OnlineCount"];
                lblResult.Text = Languages.Lang.Show("totalaccess") + ": " + Application["VisitedCount"];
                Button1.Text = Languages.Lang.Show("show");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = ThongKeTruyCapService.ThongKeTruyCap_GetByTuNgayDenNgay(
                DateTimeClass.ConvertDateTime(StringClass.ConvertDateTime(TextBox1.Text), "yyyy/MM/dd"),
                DateTimeClass.ConvertDateTime(StringClass.ConvertDateTime(TextBox2.Text), "yyyy/MM/dd"));
            int dem = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dem += int.Parse(dt.Rows[i]["Num"].ToString());
            }
            lblResult.Text = Languages.Lang.Show("totalaccess") + ": " + dem;
        }
    }
}