using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_ViTriController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_ViTri_Delete(string ID)
        {
            cmd = new SqlCommand("sp_TT_ViTri_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_ViTri_GetAll()
        {
            cmd = new SqlCommand("sp_TT_ViTri_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_ViTri_GetById(string ID)
        {
            cmd = new SqlCommand("sp_TT_ViTri_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            return GetTable(cmd);
        }

        public static void TT_ViTri_Insert(string TenViTri, string MoTa, string Gia)
        {
            cmd = new SqlCommand("sp_TT_ViTri_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenViTri", TenViTri);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@Gia", Gia);
            ExeCuteNonquery(cmd);
        }

        public static void TT_ViTri_Update(string ID, string TenViTri, string MoTa, string Gia)
        {
            cmd = new SqlCommand("sp_TT_ViTri_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            cmd.Parameters.Add("@TenViTri", TenViTri);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@Gia", Gia);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_ViTri_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_ViTri_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_ViTri_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_ViTri_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        #region[TT_ViTri_GetAllKey]

        public static DataTable TT_ViTri_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_ViTri_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}