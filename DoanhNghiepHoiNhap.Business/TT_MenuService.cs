using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_MenuService
    {
        public static void TT_Menu_Insert(string Ten, string Link, string Cha, string ThuTu, string HienThi,
                                          string NgonNgu, string Loai, string ChiTiet)
        {
            TT_MenuController.TT_Menu_Insert(Ten, Link, Cha, ThuTu, HienThi, NgonNgu, Loai, ChiTiet);
        }

        public static void TT_Menu_Update(string Id, string Ten, string Link, string Cha, string ThuTu, string HienThi,
                                          string NgonNgu, string Loai, string ChiTiet)
        {
            TT_MenuController.TT_Menu_Update(Id, Ten, Link, Cha, ThuTu, HienThi, NgonNgu, Loai, ChiTiet);
        }

        public static void TT_Menu_Delete(string Id)
        {
            TT_MenuController.TT_Menu_Delete(Id);
        }

        public static DataTable TT_Menu_GetAll()
        {
            return TT_MenuController.TT_Menu_GetAll();
        }

        public static DataTable TT_Menu_GetAllKey()
        {
            return TT_MenuController.TT_Menu_GetAllKey();
        }

        public static DataTable TT_Menu_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_Menu].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_Menu].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_Menu].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_Menu].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_MenuController.TT_Menu_SearchColumn(s);
        }

        public static DataTable TT_Menu_GetById(string Id)
        {
            return TT_MenuController.TT_Menu_GetById(Id);
        }

        public static DataTable TT_Menu_GetByTop(string Top, string Where, string Order)
        {
            return TT_MenuController.TT_Menu_GetByTop(Top, Where, Order);
        }
    }
}