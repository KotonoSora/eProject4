using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_NgonNguService
    {
        public static void TT_NgonNgu_Insert(string Ten, string HinhAnh, string ThuTu)
        {
            TT_NgonNguController.TT_NgonNgu_Insert(Ten, HinhAnh, ThuTu);
        }

        public static void TT_NgonNgu_Update(string Id, string Ten, string HinhAnh, string ThuTu)
        {
            TT_NgonNguController.TT_NgonNgu_Update(Id, Ten, HinhAnh, ThuTu);
        }

        public static void TT_NgonNgu_Delete(string Id)
        {
            TT_NgonNguController.TT_NgonNgu_Delete(Id);
        }

        public static DataTable TT_NgonNgu_GetAll()
        {
            return TT_NgonNguController.TT_NgonNgu_GetAll();
        }

        public static DataTable TT_NgonNgu_GetAllKey()
        {
            return TT_NgonNguController.TT_NgonNgu_GetAllKey();
        }

        public static DataTable TT_NgonNgu_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_NgonNgu].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_NgonNgu].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_NgonNgu].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_NgonNgu].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_NgonNguController.TT_NgonNgu_SearchColumn(s);
        }

        public static DataTable TT_NgonNgu_GetById(string Id)
        {
            return TT_NgonNguController.TT_NgonNgu_GetById(Id);
        }

        public static DataTable TT_NgonNgu_GetByTop(string Top, string Where, string Order)
        {
            return TT_NgonNguController.TT_NgonNgu_GetByTop(Top, Where, Order);
        }
    }
}