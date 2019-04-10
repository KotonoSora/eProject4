using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_ViTriService
    {
        public static void TT_ViTri_Insert(string TenViTri, string MoTa, string Gia)
        {
            TT_ViTriController.TT_ViTri_Insert(TenViTri, MoTa, Gia);
        }

        public static void TT_ViTri_Update(string ID, string TenViTri, string MoTa, string Gia)
        {
            TT_ViTriController.TT_ViTri_Update(ID, TenViTri, MoTa, Gia);
        }

        public static void TT_ViTri_Delete(string ID)
        {
            TT_ViTriController.TT_ViTri_Delete(ID);
        }

        public static DataTable TT_ViTri_GetAll()
        {
            return TT_ViTriController.TT_ViTri_GetAll();
        }

        public static DataTable TT_ViTri_GetAllKey()
        {
            return TT_ViTriController.TT_ViTri_GetAllKey();
        }

        public static DataTable TT_ViTri_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_ViTri].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_ViTri].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_ViTri].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_ViTri].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_ViTriController.TT_ViTri_SearchColumn(s);
        }

        public static DataTable TT_ViTri_GetById(string ID)
        {
            return TT_ViTriController.TT_ViTri_GetById(ID);
        }

        public static DataTable TT_ViTri_GetByTop(string Top, string Where, string Order)
        {
            return TT_ViTriController.TT_ViTri_GetByTop(Top, Where, Order);
        }
    }
}