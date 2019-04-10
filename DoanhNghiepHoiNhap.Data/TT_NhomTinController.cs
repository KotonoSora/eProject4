using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_NhomTinController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_NhomTin_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_NhomTin_GetAll()
        {
            cmd = new SqlCommand("sp_TT_NhomTin_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_NhomTin_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static DataTable TT_NhomTin_GetByNhomTinCungCha(string nhomtincha, string Tag)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_GetByNhomTinCon_CungCha", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nhomtincha", nhomtincha);
            cmd.Parameters.Add("@Tag", Tag);
            return GetTable(cmd);
        }

        public static DataTable TT_NhomTin_GetByNhomTinLienQuan(string nhomtin)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_GetByNhomTinLienQuan", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nhomtin", nhomtin);
            return GetTable(cmd);
        }

        public static void TT_NhomTin_Insert(string Ten, string Tag, string MoTa, string Cha, string ThuTu,
                                             string HienThi, string NgonNgu, string MauSacMobile)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@Tag", Tag);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@Cha", Cha);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@HienThi", HienThi);
            cmd.Parameters.Add("@NgonNgu", NgonNgu);
            cmd.Parameters.Add("@MauSacMobile", MauSacMobile);
            ExeCuteNonquery(cmd);
        }

        public static void TT_NhomTin_Update(string Id, string Ten, string Tag, string MoTa, string Cha, string ThuTu,
                                             string HienThi, string NgonNgu, string MauSacMobile)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@Tag", Tag);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@Cha", Cha);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@HienThi", HienThi);
            cmd.Parameters.Add("@NgonNgu", NgonNgu);
            cmd.Parameters.Add("@MauSacMobile", MauSacMobile);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_NhomTin_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_NhomTin_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TT_NhomTin_GetByUsername(string Username, string role)
        {
            cmd = new SqlCommand("sp_TT_NhomTin_GetByUsername", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", Username);
            cmd.Parameters.Add("@role", role);
            return GetTable(cmd);
        }

        #region[TT_NhomTin_GetAllKey]

        public static DataTable TT_NhomTin_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_NhomTin_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}