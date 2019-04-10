using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_NhomTinService
    {
        public static void TT_NhomTin_Insert(string Ten, string Tag, string MoTa, string Cha, string ThuTu,
                                             string HienThi, string NgonNgu, string MauSacMobile)
        {
            TT_NhomTinController.TT_NhomTin_Insert(Ten, Tag, MoTa, Cha, ThuTu, HienThi, NgonNgu, MauSacMobile);
        }

        public static void TT_NhomTin_Update(string Id, string Ten, string Tag, string MoTa, string Cha, string ThuTu,
                                             string HienThi, string NgonNgu, string MauSacMobile)
        {
            TT_NhomTinController.TT_NhomTin_Update(Id, Ten, Tag, MoTa, Cha, ThuTu, HienThi, NgonNgu, MauSacMobile);
        }

        public static void TT_NhomTin_Delete(string Id)
        {
            TT_NhomTinController.TT_NhomTin_Delete(Id);
        }

        public static DataTable TT_NhomTin_GetAll()
        {
            return TT_NhomTinController.TT_NhomTin_GetAll();
        }

        public static DataTable TT_NhomTin_GetByNhomTinLienQuan(string nhomtin)
        {
            return TT_NhomTinController.TT_NhomTin_GetByNhomTinLienQuan(nhomtin);
        }

        public static DataTable TT_NhomTin_GetByNhomTinCungCha(string nhomtincha, string Tag)
        {
            return TT_NhomTinController.TT_NhomTin_GetByNhomTinCungCha(nhomtincha, Tag);
        }

        public static DataTable TT_NhomTin_GetAllKey()
        {
            return TT_NhomTinController.TT_NhomTin_GetAllKey();
        }

        public static DataTable TT_NhomTin_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_NhomTin].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_NhomTin].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_NhomTin].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_NhomTin].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_NhomTinController.TT_NhomTin_SearchColumn(s);
        }

        public static DataTable TT_NhomTin_GetById(string Id)
        {
            return TT_NhomTinController.TT_NhomTin_GetById(Id);
        }

        public static DataTable TT_NhomTin_GetByTop(string Top, string Where, string Order)
        {
            Where = SqlDataProvider.FilterSqlInjection(Where);
            return TT_NhomTinController.TT_NhomTin_GetByTop(Top, Where, Order);
        }

        public static DataTable TT_NhomTin_GetByUsername(string Username, string role)
        {
            return TT_NhomTinController.TT_NhomTin_GetByUsername(Username, role);
        }
    }
}