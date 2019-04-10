using System.Data;
using System.Data.SqlClient;
namespace DoanhNghiepHoiNhap.Data
{

    public class TH_ChuongController : SqlDataProvider
    {
        private static SqlCommand cmd;
        public static void TH_Chuong_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TH_Chuong_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }
        public static DataTable TH_Chuong_GetAll()
        {
            cmd = new SqlCommand("sp_TH_Chuong_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }
        #region[TH_Chuong_GetAllKey]
        public static DataTable TH_Chuong_GetAllKey()
        {
            cmd = new SqlCommand("sp_TH_Chuong_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }
        #endregion
        public static DataTable TH_Chuong_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TH_Chuong_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }
        public static void TH_Chuong_Insert(string Id_QuyenSach, string TieuDe, string NoiDung, string Note_text, string Note_int, string NgayCapNhat)
        {
            cmd = new SqlCommand("sp_TH_Chuong_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id_QuyenSach", Id_QuyenSach);
            cmd.Parameters.Add("@TieuDe", TieuDe);
            cmd.Parameters.Add("@NoiDung", NoiDung);
            cmd.Parameters.Add("@Note_text", Note_text);
            cmd.Parameters.Add("@Note_int", Note_int);
            cmd.Parameters.Add("@NgayCapNhat", NgayCapNhat);
            ExeCuteNonquery(cmd);
        }
        public static void TH_Chuong_Update(string Id, string Id_QuyenSach, string TieuDe, string NoiDung, string Note_text, string Note_int, string NgayCapNhat)
        {
            cmd = new SqlCommand("sp_TH_Chuong_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Id_QuyenSach", Id_QuyenSach);
            cmd.Parameters.Add("@TieuDe", TieuDe);
            cmd.Parameters.Add("@NoiDung", NoiDung);
            cmd.Parameters.Add("@Note_text", Note_text);
            cmd.Parameters.Add("@Note_int", Note_int);
            cmd.Parameters.Add("@NgayCapNhat", NgayCapNhat);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TH_Chuong_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TH_Chuong_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        //sp_TT_Chuong_Paging
        public static DataTable TT_Chuong_Paging(string NumberPage, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TH_Chuong_Paging", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NumberPage", NumberPage);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_Chuong_Paging_InfoChuong(string NumberPage, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TH_Chuong_Paging_InfoChuong", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NumberPage", NumberPage);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TH_Chuong_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TH_Chuong_GetByForeignKey", GetConnect());
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
                            s = " and [TH_Chuong].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TH_Chuong].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TH_Chuong].[" + s1[0] + "] like N'%" + str + "%'";
                            break;
                    }
                    break;
                default:
                    try { float.Parse(str); }
                    catch { return null; }
                    s = " and [TH_Chuong].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }
    }
}