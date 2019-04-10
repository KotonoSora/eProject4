using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_TinTucController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_TinTuc_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TT_TinTuc_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_TinTuc_GetAll()
        {
            cmd = new SqlCommand("sp_TT_TinTuc_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_TinTuc_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TT_TinTuc_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TT_TinTuc_Insert(string TieuDe, string TieuDe2, string TomTat, string TomTat2, string NoiDung,
                                            string Tag, string HinhAnh, string NguoiDang,string Description, string Keyword, string TrangThai, string NhomTin)
        {
            cmd = new SqlCommand("sp_TT_TinTuc_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TieuDe", TieuDe);
            cmd.Parameters.Add("@TieuDe2", TieuDe2);
            cmd.Parameters.Add("@TomTat", TomTat);
            cmd.Parameters.Add("@TomTat2", TomTat2);
            cmd.Parameters.Add("@NoiDung", NoiDung);
            cmd.Parameters.Add("@Tag", Tag);
            cmd.Parameters.Add("@HinhAnh", HinhAnh); 
            cmd.Parameters.Add("@NguoiDang", NguoiDang); 
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@Keyword", Keyword); 
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@NhomTin", NhomTin);
            ExeCuteNonquery(cmd);
        }

        public static void TT_TinTuc_Update(string Id, string TieuDe, string TieuDe2, string TomTat, string TomTat2,
                                            string NoiDung, string Tag, string HinhAnh, string Description, string Keyword,
                                            string TrangThai, string NhomTin)
        {
            cmd = new SqlCommand("sp_TT_TinTuc_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@TieuDe", TieuDe);
            cmd.Parameters.Add("@TieuDe2", TieuDe2);
            cmd.Parameters.Add("@TomTat", TomTat);
            cmd.Parameters.Add("@TomTat2", TomTat2);
            cmd.Parameters.Add("@NoiDung", NoiDung);
            cmd.Parameters.Add("@Tag", Tag);
            cmd.Parameters.Add("@HinhAnh", HinhAnh); 
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@Keyword", Keyword); 
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@NhomTin", NhomTin);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_TinTuc_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_TinTuc_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_TinTuc_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TT_TinTuc_GetByForeignKey", GetConnect());
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
                            s = " and [TT_TinTuc].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TT_TinTuc].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TT_TinTuc].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TT_TinTuc].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TT_TinTuc_GetByForeignKey(string NhomTin)
        {
            cmd = new SqlCommand("sp_TT_TinTuc_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            string str = "";
            if (!string.IsNullOrEmpty(NhomTin))
                str += " and [TT_TinTuc].[NhomTin]=" + NhomTin + " ";
            cmd.Parameters.Add("@dk", str);
            return GetTable(cmd);
        }

        #region[TT_TinTuc_GetAllKey]

        public static DataTable TT_TinTuc_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_TinTuc_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}