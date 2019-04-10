using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_Multimedia_GroupController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_Multimedia_Group_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Group_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_Multimedia_Group_GetAll()
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Group_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_Multimedia_Group_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Group_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TT_Multimedia_Group_Insert(string Ten, string MoTa, string ThuTu)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Group_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            ExeCuteNonquery(cmd);
        }

        public static void TT_Multimedia_Group_Update(string Id, string Ten, string MoTa, string ThuTu)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Group_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_Multimedia_Group_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Group_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }
    }
}