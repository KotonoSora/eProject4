using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_ChucNangController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_ChucNang_Delete(string ID)
        {
            cmd = new SqlCommand("sp_TT_ChucNang_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_ChucNang_GetAll()
        {
            cmd = new SqlCommand("sp_TT_ChucNang_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_ChucNang_GetById(string ID)
        {
            cmd = new SqlCommand("sp_TT_ChucNang_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            return GetTable(cmd);
        }

        public static void TT_ChucNang_Insert(string TenChucNang, string MoTa, string Trang_Id)
        {
            cmd = new SqlCommand("sp_TT_ChucNang_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenChucNang", TenChucNang);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@Trang_Id", Trang_Id);
            ExeCuteNonquery(cmd);
        }

        public static void TT_ChucNang_Update(string ID, string TenChucNang, string MoTa, string Trang_Id)
        {
            cmd = new SqlCommand("sp_TT_ChucNang_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            cmd.Parameters.Add("@TenChucNang", TenChucNang);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@Trang_Id", Trang_Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_ChucNang_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_ChucNang_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_ChucNang_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_ChucNang_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TT_ChucNang_GetByForeignKey(string str)
        {
            cmd = new SqlCommand("sp_TT_ChucNang_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", str);
            return GetTable(cmd);
        }

        #region[TT_ChucNang_GetAllKey]

        public static DataTable TT_ChucNang_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_ChucNang_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}