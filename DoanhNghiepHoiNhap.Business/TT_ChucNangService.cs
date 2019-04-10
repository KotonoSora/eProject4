using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_ChucNangService
    {
        public static void TT_ChucNang_Insert(string TenChucNang, string MoTa, string Trang_Id)
        {
            TT_ChucNangController.TT_ChucNang_Insert(TenChucNang, MoTa, Trang_Id);
        }

        public static void TT_ChucNang_Update(string ID, string TenChucNang, string MoTa, string Trang_Id)
        {
            TT_ChucNangController.TT_ChucNang_Update(ID, TenChucNang, MoTa, Trang_Id);
        }

        public static void TT_ChucNang_Delete(string ID)
        {
            TT_ChucNangController.TT_ChucNang_Delete(ID);
        }

        public static DataTable TT_ChucNang_GetAll()
        {
            return TT_ChucNangController.TT_ChucNang_GetAll();
        }

        public static DataTable TT_ChucNang_GetAllKey()
        {
            return TT_ChucNangController.TT_ChucNang_GetAllKey();
        }

        public static DataTable TT_ChucNang_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_ChucNang].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_ChucNang].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_ChucNang].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_ChucNang].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_ChucNangController.TT_ChucNang_SearchColumn(s);
        }

        public static DataTable TT_ChucNang_GetById(string ID)
        {
            return TT_ChucNangController.TT_ChucNang_GetById(ID);
        }

        public static DataTable TT_ChucNang_GetByTop(string Top, string Where, string Order)
        {
            return TT_ChucNangController.TT_ChucNang_GetByTop(Top, Where, Order);
        }

        public static DataTable TT_ChucNang_GetByForeignKey(string Trang_Id)
        {
            string str = "";
            if (!string.IsNullOrEmpty(Trang_Id))
                str += " and [TT_ChucNang].[Trang_Id]=" + Trang_Id + " ";
            return TT_ChucNangController.TT_ChucNang_GetByForeignKey(str);
        }
    }
}