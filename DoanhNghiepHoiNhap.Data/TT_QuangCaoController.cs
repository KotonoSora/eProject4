using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_QuangCaoController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_QuangCao_Delete(string ID)
        {
            cmd = new SqlCommand("sp_TT_QuangCao_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_QuangCao_GetAll()
        {
            cmd = new SqlCommand("sp_TT_QuangCao_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_QuangCao_GetById(string ID)
        {
            cmd = new SqlCommand("sp_TT_QuangCao_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            return GetTable(cmd);
        }

        public static DataTable TT_QuangCao_GetByViTri_NhomTin(string vitri, string nhomtin)
        {
            cmd = new SqlCommand("sp_TT_QuangCao_GetByViTri_NhomTin", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@vitri", vitri);
            cmd.Parameters.Add("@nhomtin_id", nhomtin);
            return GetTable(cmd);
        }

        public static void TT_QuangCao_Insert(string TenQuangCao, string HinhAnh, string Link, string NgayBatDau,
                                              string NgayKetThuc, string ViTri, string Mail, string SoDienThoai,
                                              string CongTy, string ThuTu, string TrangThai)
        {
            cmd = new SqlCommand("sp_TT_QuangCao_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenQuangCao", TenQuangCao);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@Link", Link);
            cmd.Parameters.Add("@NgayBatDau", NgayBatDau);
            cmd.Parameters.Add("@NgayKetThuc", NgayKetThuc);
            cmd.Parameters.Add("@ViTri", ViTri);
            cmd.Parameters.Add("@Mail", Mail);
            cmd.Parameters.Add("@SoDienThoai", SoDienThoai);
            cmd.Parameters.Add("@CongTy", CongTy);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            ExeCuteNonquery(cmd);
        }

        public static void TT_QuangCao_Update(string ID, string TenQuangCao, string HinhAnh, string Link,
                                              string NgayBatDau, string NgayKetThuc, string ViTri, string Mail,
                                              string SoDienThoai, string CongTy, string ThuTu, string TrangThai)
        {
            cmd = new SqlCommand("sp_TT_QuangCao_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            cmd.Parameters.Add("@TenQuangCao", TenQuangCao);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@Link", Link);
            cmd.Parameters.Add("@NgayBatDau", NgayBatDau);
            cmd.Parameters.Add("@NgayKetThuc", NgayKetThuc);
            cmd.Parameters.Add("@ViTri", ViTri);
            cmd.Parameters.Add("@Mail", Mail);
            cmd.Parameters.Add("@SoDienThoai", SoDienThoai);
            cmd.Parameters.Add("@CongTy", CongTy);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_QuangCao_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_QuangCao_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_QuangCao_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_QuangCao_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TT_QuangCao_GetByForeignKey(string str)
        {
            cmd = new SqlCommand("sp_TT_QuangCao_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", str);
            return GetTable(cmd);
        }

        #region[TT_QuangCao_GetAllKey]

        public static DataTable TT_QuangCao_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_QuangCao_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}