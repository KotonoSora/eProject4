using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_LienHeService
    {
        public static void TT_LienHe_Insert(string TieuDe, string NoiDung, string NguoiGui, string NgayGui, string Mail,
                                            string SoDienThoai, string TrangThai, string CongTy, string DiaChi, string LoaiLienHe)
        {
            TT_LienHeController.TT_LienHe_Insert(TieuDe, NoiDung, NguoiGui, NgayGui, Mail, SoDienThoai, TrangThai,
                                                 CongTy, DiaChi, LoaiLienHe);
        }

        public static void TT_LienHe_Update(string ID, string TieuDe, string NoiDung, string NguoiGui, string NgayGui,
                                            string Mail, string SoDienThoai, string TrangThai, string CongTy, string DiaChi, string LoaiLienHe)
        {
            TT_LienHeController.TT_LienHe_Update(ID, TieuDe, NoiDung, NguoiGui, NgayGui, Mail, SoDienThoai, TrangThai,
                                                 CongTy, DiaChi, LoaiLienHe);
        }

        public static void TT_LienHe_Delete(string ID)
        {
            TT_LienHeController.TT_LienHe_Delete(ID);
        }

        public static DataTable TT_LienHe_GetAll()
        {
            return TT_LienHeController.TT_LienHe_GetAll();
        }

        public static DataTable TT_LienHe_GetAllKey()
        {
            return TT_LienHeController.TT_LienHe_GetAllKey();
        }

        public static DataTable TT_LienHe_SearchColumn(string str, string value, string tk)
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
                            s = " and [TT_LienHe].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_LienHe].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_LienHe].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_LienHe].[" + s1[0] + "]=" + str + "";
                    break;
            }
            return TT_LienHeController.TT_LienHe_SearchColumn(s);
        }

        public static DataTable TT_LienHe_GetById(string ID)
        {
            return TT_LienHeController.TT_LienHe_GetById(ID);
        }

        public static DataTable TT_LienHe_GetByTop(string Top, string Where, string Order)
        {
            return TT_LienHeController.TT_LienHe_GetByTop(Top, Where, Order);
        }
    }
}