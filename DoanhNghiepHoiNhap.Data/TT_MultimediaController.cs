using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_MultimediaController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_Multimedia_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_Multimedia_GetAll()
        {
            cmd = new SqlCommand("sp_TT_Multimedia_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_Multimedia_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static DataTable TT_Multimedia_GetById_ThanhNV(string Id)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_GetById_ThanhNV", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TT_Multimedia_Insert(string TieuDe, string MoTa, string NoiDung, string Loai, string LuotXem,
                                                string AnhDaiDien)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TieuDe", TieuDe);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@NoiDung", NoiDung);
            cmd.Parameters.Add("@Loai", Loai);
            cmd.Parameters.Add("@LuotXem", LuotXem);
            cmd.Parameters.Add("@AnhDaiDien", AnhDaiDien);
            ExeCuteNonquery(cmd);
        }

        public static void TT_Multimedia_Update(string Id, string TieuDe, string MoTa, string NoiDung, string Loai, string LuotXem,
                                                string AnhDaiDien)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@TieuDe", TieuDe);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@NoiDung", NoiDung);
            cmd.Parameters.Add("@Loai", Loai);
            cmd.Parameters.Add("@LuotXem", LuotXem);
            cmd.Parameters.Add("@AnhDaiDien", AnhDaiDien);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_Multimedia_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_Multimedia_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TT_Multimedia_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            string s = "";
            string[] s1 = value.Split('*');
            switch (s1[1])
            {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    switch (tk)
                    {
                        case "1":
                            s = " and [TT_Multimedia].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_Multimedia].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_Multimedia].[" + s1[0] + "] like N'%" + str + "%'";
                            break;
                    }
                    break;
                default:
                    try
                    {
                        float.Parse(str);
                    }
                    catch
                    {
                        return null;
                    }
                    s = " and [TT_Multimedia].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        #region[TT_Multimedia_GetAllKey]

        public static DataTable TT_Multimedia_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_Multimedia_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}