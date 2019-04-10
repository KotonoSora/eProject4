using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_QuangCaoService
    {
        public static void TT_QuangCao_Insert(string TenQuangCao, string HinhAnh, string Link, string NgayBatDau,
                                              string NgayKetThuc, string ViTri, string Mail, string SoDienThoai,
                                              string CongTy, string ThuTu, string TrangThai)
        {
            TT_QuangCaoController.TT_QuangCao_Insert(TenQuangCao, HinhAnh, Link, NgayBatDau, NgayKetThuc, ViTri, Mail,
                                                     SoDienThoai, CongTy, ThuTu, TrangThai);
        }

        public static void TT_QuangCao_Update(string ID, string TenQuangCao, string HinhAnh, string Link,
                                              string NgayBatDau, string NgayKetThuc, string ViTri, string Mail,
                                              string SoDienThoai, string CongTy, string ThuTu, string TrangThai)
        {
            TT_QuangCaoController.TT_QuangCao_Update(ID, TenQuangCao, HinhAnh, Link, NgayBatDau, NgayKetThuc, ViTri,
                                                     Mail, SoDienThoai, CongTy, ThuTu, TrangThai);
        }

        public static DataTable TT_QuangCao_GetByViTri_NhomTin(string vitri, string nhomtin)
        {
            return TT_QuangCaoController.TT_QuangCao_GetByViTri_NhomTin(vitri, nhomtin);
        }

        public static void TT_QuangCao_Delete(string ID)
        {
            TT_QuangCaoController.TT_QuangCao_Delete(ID);
        }

        public static DataTable TT_QuangCao_GetAll()
        {
            return TT_QuangCaoController.TT_QuangCao_GetAll();
        }

        public static DataTable TT_QuangCao_GetAllKey()
        {
            return TT_QuangCaoController.TT_QuangCao_GetAllKey();
        }

        public static DataTable TT_QuangCao_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_QuangCao].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_QuangCao].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_QuangCao].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_QuangCao].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_QuangCaoController.TT_QuangCao_SearchColumn(s);
        }

        public static DataTable TT_QuangCao_GetById(string ID)
        {
            return TT_QuangCaoController.TT_QuangCao_GetById(ID);
        }

        public static DataTable TT_QuangCao_GetByTop(string Top, string Where, string Order)
        {
            return TT_QuangCaoController.TT_QuangCao_GetByTop(Top, Where, Order);
        }

        public static DataTable TT_QuangCao_GetByForeignKey(string ViTri)
        {
            string str = "";
            if (!string.IsNullOrEmpty(ViTri))
                str += " and [TT_QuangCao].[ViTri]=" + ViTri + " ";
            return TT_QuangCaoController.TT_QuangCao_GetByForeignKey(str);
        }
    }
}