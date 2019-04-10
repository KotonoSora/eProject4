using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TM_HangHoa_HinhAnhController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TM_HangHoa_HinhAnh_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_HangHoa_HinhAnh_GetAll()
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_HinhAnh_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TM_HangHoa_HinhAnh_Insert(string HinhAnh, string MoTa, string ThuTu, string HangHoa)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@HangHoa", HangHoa);
            ExeCuteNonquery(cmd);
        }

        public static void TM_HangHoa_HinhAnh_Update(string Id, string HinhAnh, string MoTa, string ThuTu,
                                                     string HangHoa)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@HangHoa", HangHoa);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_HangHoa_HinhAnh_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_HinhAnh_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_GetByForeignKey", GetConnect());
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
                            s = " and [TM_HangHoa_HinhAnh].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TM_HangHoa_HinhAnh].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TM_HangHoa_HinhAnh].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TM_HangHoa_HinhAnh].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_HinhAnh_GetByForeignKey(string HangHoa)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            string str = "";
            if (!string.IsNullOrEmpty(HangHoa))
                str += " and [TM_HangHoa_HinhAnh].[HangHoa]=" + HangHoa + " ";
            cmd.Parameters.Add("@dk", str);
            return GetTable(cmd);
        }

        #region[TM_HangHoa_HinhAnh_GetAllKey]

        public static DataTable TM_HangHoa_HinhAnh_GetAllKey()
        {
            cmd = new SqlCommand("sp_TM_HangHoa_HinhAnh_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}