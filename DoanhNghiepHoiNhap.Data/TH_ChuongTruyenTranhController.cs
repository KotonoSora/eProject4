using System.Data;
using System.Data.SqlClient;
namespace DoanhNghiepHoiNhap.Data
{

    public class TH_ChuongTruyenTranhController : SqlDataProvider
    {
        private static SqlCommand cmd;
        public static void TH_ChuongTruyenTranh_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TH_ChuongTruyenTranh_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }
        public static DataTable TH_ChuongTruyenTranh_GetAll()
        {
            cmd = new SqlCommand("sp_TH_ChuongTruyenTranh_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }
        #region[TH_ChuongTruyenTranh_GetAllKey]
        public static DataTable TH_ChuongTruyenTranh_GetAllKey()
        {
            cmd = new SqlCommand("sp_TH_ChuongTruyenTranh_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }
        #endregion
        public static DataTable TH_ChuongTruyenTranh_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TH_ChuongTruyenTranh_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }
        public static void TH_ChuongTruyenTranh_Insert(string Id_QuyenSach, string TenChuong, string Note_text, string Note_int, string NgayCapNhat)
        {
            cmd = new SqlCommand("sp_TH_ChuongTruyenTranh_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id_QuyenSach", Id_QuyenSach);
            cmd.Parameters.Add("@TenChuong", TenChuong);
            cmd.Parameters.Add("@Note_text", Note_text);
            cmd.Parameters.Add("@Note_int", Note_int);
            cmd.Parameters.Add("@NgayCapNhat", NgayCapNhat);
            ExeCuteNonquery(cmd);
        }
        public static void TH_ChuongTruyenTranh_Update(string Id, string Id_QuyenSach, string TenChuong, string Note_text, string Note_int, string NgayCapNhat)
        {
            cmd = new SqlCommand("sp_TH_ChuongTruyenTranh_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Id_QuyenSach", Id_QuyenSach);
            cmd.Parameters.Add("@TenChuong", TenChuong);
            cmd.Parameters.Add("@Note_text", Note_text);
            cmd.Parameters.Add("@Note_int", Note_int);
            cmd.Parameters.Add("@NgayCapNhat", NgayCapNhat);
            ExeCuteNonquery(cmd);
        }
        public static DataTable TH_ChuongTruyenTranh_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TH_ChuongTruyenTranh_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }
        public static DataTable TH_ChuongTruyenTranh_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TH_ChuongTruyenTranh_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            var s = "";
            var s1 = value.Split('*');
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
                            s = " and [TH_ChuongTruyenTranh].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TH_ChuongTruyenTranh].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TH_ChuongTruyenTranh].[" + s1[0] + "] like N'%" + str + "%'";
                            break;
                    }
                    break;
                default:
                    try { float.Parse(str); }
                    catch { return null; }
                    s = " and [TH_ChuongTruyenTranh].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }
    }
}