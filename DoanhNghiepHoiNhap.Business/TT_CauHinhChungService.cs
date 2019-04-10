using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_CauHinhChungService
    {
        public static void TT_CauHinhChung_Insert(string Banner, string Footer, string Description, string Keyword,
                                                  string Email, string Password, string DuyetTuDong)
        {
            TT_CauHinhChungController.TT_CauHinhChung_Insert(Banner, Footer, Description, Keyword, Email, Password,
                                                             DuyetTuDong);
        }

        public static void TT_CauHinhChung_Update(string Id,string Logo, string Banner, string Footer, string Description,
                                                  string Keyword, string Email, string Password, string DuyetTuDong,
                                                  string SoQuangCao, string SoQuangCaoNhomTin, string ThongTinLienHe,                                             
                                                  string HienThiChuyenDe,
                                                  string Banner_Mobile, string Footer_Mobile, string GooglePlus, string Twitter, string Youtube,
                                                  string ThongTinLienHe2, string ThongTinLienHe3, string BanDo, string Sdt,
                                                  string MoTaGmail, string MoTaSdt, string MoTaTweet, string MoTaVisitus)
        {
            TT_CauHinhChungController.TT_CauHinhChung_Update(Id,Logo, Banner, Footer, Description, Keyword, Email, Password,
                                                             DuyetTuDong, SoQuangCao, SoQuangCaoNhomTin, ThongTinLienHe,                                                         
                                                             HienThiChuyenDe,
                                                             Banner_Mobile, Footer_Mobile, GooglePlus, Twitter, Youtube ,
                                                             ThongTinLienHe2, ThongTinLienHe3, BanDo, Sdt, MoTaGmail, MoTaSdt
                                                             , MoTaTweet, MoTaVisitus);
        }

        public static void TT_CauHinhChung_Delete(string Id)
        {
            TT_CauHinhChungController.TT_CauHinhChung_Delete(Id);
        }

        public static DataTable TT_CauHinhChung_GetAll()
        {
            return TT_CauHinhChungController.TT_CauHinhChung_GetAll();
        }

        public static DataTable TT_CauHinhChung_GetAllKey()
        {
            return TT_CauHinhChungController.TT_CauHinhChung_GetAllKey();
        }

        public static DataTable TT_CauHinhChung_SearchColumn(string str, string value, string tk)
        {
            string s = "";
            string[] s1 = value.Split('*');
            switch (s1[1])
            {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    switch (tk)
                    {
                        case "1":
                            s = " and [TT_CauHinhChung].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_CauHinhChung].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_CauHinhChung].[" + s1[0] + "] like N'%" + str + "%'";
                            break;
                    }
                    break;
                default:
                    try
                    {
                        float.Parse(str);
                    }
                    catch
                    {
                        return null;
                    }
                    s = " and [TT_CauHinhChung].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_CauHinhChungController.TT_CauHinhChung_SearchColumn(s);
        }

        public static DataTable TT_CauHinhChung_GetById(string Id)
        {
            return TT_CauHinhChungController.TT_CauHinhChung_GetById(Id);
        }

        public static DataTable TT_CauHinhChung_GetByTop(string Top, string Where, string Order)
        {
            return TT_CauHinhChungController.TT_CauHinhChung_GetByTop(Top, Where, Order);
        }
    }
}