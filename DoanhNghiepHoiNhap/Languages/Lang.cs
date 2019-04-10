using System.Reflection;
using System.Resources;
using System.Web;

namespace DoanhNghiepHoiNhap.Languages
{

    public class Lang
    {
        public static string Show(string key)
        {
            if (HttpContext.Current.Session["lang"] == null)
                HttpContext.Current.Session["lang"] = "1";
            string lang = HttpContext.Current.Session["lang"].ToString();
            ResourceManager rm = lang == "1" ? new ResourceManager("DoanhNghiepHoiNhap.Languages.vietnamese", typeof(Lang).Assembly) : new ResourceManager("DoanhNghiepHoiNhap.Languages.english", Assembly.GetExecutingAssembly());
            return rm.GetString(key);
        }
    } 
}