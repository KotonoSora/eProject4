using System; 

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] == null) Response.Redirect("~/Admins/login.aspx");
                Response.Redirect("/Admins/Common/Default.aspx");
            }
        }
    }
}