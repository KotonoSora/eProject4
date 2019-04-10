using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_PhanQuyenService
    {
        public static void TT_PhanQuyen_Insert(string Nhom_Id, string ChucNang_Id)
        {
            TT_PhanQuyenController.TT_PhanQuyen_Insert(Nhom_Id, ChucNang_Id);
        }

        public static void TT_PhanQuyen_Update(string ID, string Nhom_Id, string ChucNang_Id)
        {
            TT_PhanQuyenController.TT_PhanQuyen_Update(ID, Nhom_Id, ChucNang_Id);
        }

        public static void TT_PhanQuyen_Delete(string ID)
        {
            TT_PhanQuyenController.TT_PhanQuyen_Delete(ID);
        }

        public static DataTable TT_PhanQuyen_GetAll()
        {
            return TT_PhanQuyenController.TT_PhanQuyen_GetAll();
        }

        public static DataTable TT_PhanQuyen_GetAllKey()
        {
            return TT_PhanQuyenController.TT_PhanQuyen_GetAllKey();
        }

        public static DataTable TT_PhanQuyen_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_PhanQuyen].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_PhanQuyen].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_PhanQuyen].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_PhanQuyen].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_PhanQuyenController.TT_PhanQuyen_SearchColumn(s);
        }

        public static DataTable TT_PhanQuyen_GetById(string ID)
        {
            return TT_PhanQuyenController.TT_PhanQuyen_GetById(ID);
        }

        public static DataTable TT_PhanQuyen_GetByTop(string Top, string Where, string Order)
        {
            return TT_PhanQuyenController.TT_PhanQuyen_GetByTop(Top, Where, Order);
        }

        public static DataTable TT_PhanQuyen_GetByForeignKey(string Nhom_Id, string ChucNang_Id)
        {
            string str = "";
            if (!string.IsNullOrEmpty(Nhom_Id))
                str += " and [TT_PhanQuyen].[Nhom_Id]=" + Nhom_Id + " ";
            if (!string.IsNullOrEmpty(ChucNang_Id))
                str += " and [TT_PhanQuyen].[ChucNang_Id]=" + ChucNang_Id + " ";
            return TT_PhanQuyenController.TT_PhanQuyen_GetByForeignKey(str);
        }
    }
}