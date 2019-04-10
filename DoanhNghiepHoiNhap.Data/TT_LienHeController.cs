using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_LienHeController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_LienHe_Delete(string ID)
        {
            cmd = new SqlCommand("sp_TT_LienHe_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_LienHe_GetAll()
        {
            cmd = new SqlCommand("sp_TT_LienHe_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_LienHe_GetById(string ID)
        {
            cmd = new SqlCommand("sp_TT_LienHe_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            return GetTable(cmd);
        }

        public static void TT_LienHe_Insert(string TieuDe, string NoiDung, string NguoiGui, string NgayGui, string Mail,
                                            string SoDienThoai, string TrangThai, string CongTy, string DiaChi, string LoaiLienHe)
        {
            cmd = new SqlCommand("sp_TT_LienHe_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TieuDe", TieuDe);
            cmd.Parameters.Add("@NoiDung", NoiDung);
            cmd.Parameters.Add("@NguoiGui", NguoiGui);
            cmd.Parameters.Add("@NgayGui", NgayGui);
            cmd.Parameters.Add("@Mail", Mail);
            cmd.Parameters.Add("@SoDienThoai", SoDienThoai);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@CongTy", CongTy);
            cmd.Parameters.Add("@DiaChi", DiaChi);
            cmd.Parameters.Add("@LoaiLienHe", LoaiLienHe);
            ExeCuteNonquery(cmd);
        }

        public static void TT_LienHe_Update(string ID, string TieuDe, string NoiDung, string NguoiGui, string NgayGui,
                                            string Mail, string SoDienThoai, string TrangThai, string CongTy, string DiaChi, string LoaiLienHe)
        {
            cmd = new SqlCommand("sp_TT_LienHe_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            cmd.Parameters.Add("@TieuDe", TieuDe);
            cmd.Parameters.Add("@NoiDung", NoiDung);
            cmd.Parameters.Add("@NguoiGui", NguoiGui);
            cmd.Parameters.Add("@NgayGui", NgayGui);
            cmd.Parameters.Add("@Mail", Mail);
            cmd.Parameters.Add("@SoDienThoai", SoDienThoai);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@CongTy", CongTy);
            cmd.Parameters.Add("@DiaChi", DiaChi);
            cmd.Parameters.Add("@LoaiLienHe", LoaiLienHe);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_LienHe_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_LienHe_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_LienHe_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_LienHe_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        #region[TT_LienHe_GetAllKey]

        public static DataTable TT_LienHe_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_LienHe_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}