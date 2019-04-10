using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TM_NhomHangHoaController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TM_NhomHangHoa_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TM_NhomHangHoa_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_NhomHangHoa_GetAll()
        {
            cmd = new SqlCommand("sp_TM_NhomHangHoa_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TM_NhomHangHoa_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TM_NhomHangHoa_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TM_NhomHangHoa_Insert(string TenNhom, string MoTa, string HinhAnh, string ThuTu,
                                                 string Parent, string CapBac, string TrangThai, string TuKhoa, string NgonNgu)
        {
            cmd = new SqlCommand("sp_TM_NhomHangHoa_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenNhom", TenNhom);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@Parent", Parent);
            cmd.Parameters.Add("@CapBac", CapBac);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@TuKhoa", TuKhoa);
            cmd.Parameters.Add("@NgonNgu" ,NgonNgu);
            ExeCuteNonquery(cmd);
        }

        public static void TM_NhomHangHoa_Update(string Id, string TenNhom, string MoTa, string HinhAnh, string ThuTu,
                                                 string Parent, string CapBac, string TrangThai, string TuKhoa, string NgonNgu)
        {
            cmd = new SqlCommand("sp_TM_NhomHangHoa_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@TenNhom", TenNhom);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@Parent", Parent);
            cmd.Parameters.Add("@CapBac", CapBac);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@TuKhoa", TuKhoa);
            cmd.Parameters.Add("@NgonNgu", NgonNgu);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_NhomHangHoa_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TM_NhomHangHoa_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TM_NhomHangHoa_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TM_NhomHangHoa_GetByForeignKey", GetConnect());
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
                            s = " and [TM_NhomHangHoa].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TM_NhomHangHoa].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TM_NhomHangHoa].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TM_NhomHangHoa].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        #region[TM_NhomHangHoa_GetAllKey]

        public static DataTable TM_NhomHangHoa_GetAllKey()
        {
            cmd = new SqlCommand("sp_TM_NhomHangHoa_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}