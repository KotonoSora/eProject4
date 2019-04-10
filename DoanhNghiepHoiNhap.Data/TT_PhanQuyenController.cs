using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_PhanQuyenController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_PhanQuyen_Delete(string ID)
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChucNang_Id", ID);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_PhanQuyen_GetAll()
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_PhanQuyen_GetById(string ID)
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            return GetTable(cmd);
        }

        public static void TT_PhanQuyen_Insert(string Nhom_Id, string ChucNang_Id)
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nhom_Id", Nhom_Id);
            cmd.Parameters.Add("@ChucNang_Id", ChucNang_Id);
            ExeCuteNonquery(cmd);
        }

        public static void TT_PhanQuyen_Update(string ID, string Nhom_Id, string ChucNang_Id)
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", ID);
            cmd.Parameters.Add("@Nhom_Id", Nhom_Id);
            cmd.Parameters.Add("@ChucNang_Id", ChucNang_Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_PhanQuyen_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_PhanQuyen_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TT_PhanQuyen_GetByForeignKey(string str)
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", str);
            return GetTable(cmd);
        }

        #region[TT_PhanQuyen_GetAllKey]

        public static DataTable TT_PhanQuyen_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_PhanQuyen_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}