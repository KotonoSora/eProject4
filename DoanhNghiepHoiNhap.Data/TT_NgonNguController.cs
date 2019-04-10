using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_NgonNguController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_NgonNgu_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TT_NgonNgu_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_NgonNgu_GetAll()
        {
            cmd = new SqlCommand("sp_TT_NgonNgu_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_NgonNgu_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TT_NgonNgu_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TT_NgonNgu_Insert(string Ten, string HinhAnh, string ThuTu)
        {
            cmd = new SqlCommand("sp_TT_NgonNgu_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            ExeCuteNonquery(cmd);
        }

        public static void TT_NgonNgu_Update(string Id, string Ten, string HinhAnh, string ThuTu)
        {
            cmd = new SqlCommand("sp_TT_NgonNgu_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_NgonNgu_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_NgonNgu_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_NgonNgu_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_NgonNgu_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        #region[TT_NgonNgu_GetAllKey]

        public static DataTable TT_NgonNgu_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_NgonNgu_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}