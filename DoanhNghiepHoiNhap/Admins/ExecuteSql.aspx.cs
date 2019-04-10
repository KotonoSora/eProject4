using System;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class ExecuteSql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null)
                    if (int.Parse(Session["Role"].ToString()) != 1) Response.Redirect("~/Admins/Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                try
                {
                    string t = TextBox1.Text;
                    t = t.Replace("\r\n\t", " ");
                    t = t.Replace("\t", " ");
                    t = t.Replace("\r", " ");
                    t = t.Replace("\n", "");
                    t = t.Replace("Go", "");
                    t = t.Replace("GO", "");
                    if (t.Substring(0,6)=="select")
                    {
                        grvData.DataSource = SqlDataProvider.GetTable(t);
                        grvData.DataBind();
                    }
                    else
                    {
                        SqlDataProvider.ExeCuteNonquery(t);
                        WebMsgBox.Show("Thực hiện thành công !");
                    }
                }
                catch
                {
                    WebMsgBox.Show("Câu lệnh không đúng !");
                    return;
                }
            }
            else
            {
                WebMsgBox.Show("Nhập câu lệnh cần tạo bảng !");
                return;
            }
        }
    }
}