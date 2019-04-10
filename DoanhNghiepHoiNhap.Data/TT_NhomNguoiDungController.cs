using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_NhomNguoiDungController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_NhomNguoiDung_Delete(string ID)
        {
            cmd = new SqlCommand("sp_TT_NhomNguoiDung_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_NhomNguoiDung_GetAll()
        {
            cmd = new SqlCommand("sp_TT_NhomNguoiDung_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_NhomNguoiDung_GetById(string ID)
        {
            cmd = new SqlCommand("sp_TT_NhomNguoiDung_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            return GetTable(cmd);
        }

        public static void TT_NhomNguoiDung_Insert(string TenNhom, string MoTa)
        {
            cmd = new SqlCommand("sp_TT_NhomNguoiDung_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenNhom", TenNhom);
            cmd.Parameters.Add("@MoTa", MoTa);
            ExeCuteNonquery(cmd);
        }

        public static void TT_NhomNguoiDung_Update(string ID, string TenNhom, string MoTa)
        {
            cmd = new SqlCommand("sp_TT_NhomNguoiDung_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            cmd.Parameters.Add("@TenNhom", TenNhom);
            cmd.Parameters.Add("@MoTa", MoTa);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_NhomNguoiDung_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_NhomNguoiDung_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_NhomNguoiDung_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_NhomNguoiDung_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        #region[TT_NhomNguoiDung_GetAllKey]

        public static DataTable TT_NhomNguoiDung_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_NhomNguoiDung_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}