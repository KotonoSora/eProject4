using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_NhomNguoiDungService
    {
        public static void TT_NhomNguoiDung_Insert(string TenNhom, string MoTa)
        {
            TT_NhomNguoiDungController.TT_NhomNguoiDung_Insert(TenNhom, MoTa);
        }

        public static void TT_NhomNguoiDung_Update(string ID, string TenNhom, string MoTa)
        {
            TT_NhomNguoiDungController.TT_NhomNguoiDung_Update(ID, TenNhom, MoTa);
        }

        public static void TT_NhomNguoiDung_Delete(string ID)
        {
            TT_NhomNguoiDungController.TT_NhomNguoiDung_Delete(ID);
        }

        public static DataTable TT_NhomNguoiDung_GetAll()
        {
            return TT_NhomNguoiDungController.TT_NhomNguoiDung_GetAll();
        }

        public static DataTable TT_NhomNguoiDung_GetAllKey()
        {
            return TT_NhomNguoiDungController.TT_NhomNguoiDung_GetAllKey();
        }

        public static DataTable TT_NhomNguoiDung_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_NhomNguoiDung].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_NhomNguoiDung].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_NhomNguoiDung].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_NhomNguoiDung].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_NhomNguoiDungController.TT_NhomNguoiDung_SearchColumn(s);
        }

        public static DataTable TT_NhomNguoiDung_GetById(string ID)
        {
            return TT_NhomNguoiDungController.TT_NhomNguoiDung_GetById(ID);
        }

        public static DataTable TT_NhomNguoiDung_GetByTop(string Top, string Where, string Order)
        {
            return TT_NhomNguoiDungController.TT_NhomNguoiDung_GetByTop(Top, Where, Order);
        }
    }
}