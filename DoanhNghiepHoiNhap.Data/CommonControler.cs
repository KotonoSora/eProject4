using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class CommonControler : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void InsertValue(string table, string prop, string value)
        {
            cmd = new SqlCommand("InsertValue", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@table", table);
            cmd.Parameters.Add("@prope", prop);
            cmd.Parameters.Add("@value", value);
            ExeCuteNonquery(cmd);
        }

        public static void UpdateValue(string table, string value, string where)
        {
            cmd = new SqlCommand("UpdateValue", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@table", table);
            cmd.Parameters.Add("@value", value);
            cmd.Parameters.Add("@where", where);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TinTuc_NhomTin_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TinTuc_NhomTin_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}