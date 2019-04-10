using System.Data;
using System.Data.SqlClient;
namespace DoanhNghiepHoiNhap.Data
{

    public class DoanhNhanThanhDatController : SqlDataProvider
    {
        private static SqlCommand cmd;
        public static void DoanhNhanThanhDat_Delete(string Id)
        {
            cmd = new SqlCommand("sp_DoanhNhanThanhDat_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }
        public static DataTable DoanhNhanThanhDat_GetAll()
        {
            cmd = new SqlCommand("sp_DoanhNhanThanhDat_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }
        #region[DoanhNhanThanhDat_GetAllKey]
        public static DataTable DoanhNhanThanhDat_GetAllKey()
        {
            cmd = new SqlCommand("sp_DoanhNhanThanhDat_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }
        #endregion
        public static DataTable DoanhNhanThanhDat_GetById(string Id)
        {
            cmd = new SqlCommand("sp_DoanhNhanThanhDat_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }
        public static void DoanhNhanThanhDat_Insert(string Ten, string Anh, string GioiThieu, string DiaChi, string DienThoai, string Email, string ThuTu)
        {
            cmd = new SqlCommand("sp_DoanhNhanThanhDat_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@Anh", Anh);
            cmd.Parameters.Add("@GioiThieu", GioiThieu);
            cmd.Parameters.Add("@DiaChi", DiaChi);
            cmd.Parameters.Add("@DienThoai", DienThoai);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            ExeCuteNonquery(cmd);
        }
        public static void DoanhNhanThanhDat_Update(string Id, string Ten, string Anh, string GioiThieu, string DiaChi, string DienThoai, string Email, string ThuTu)
        {
            cmd = new SqlCommand("sp_DoanhNhanThanhDat_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@Anh", Anh);
            cmd.Parameters.Add("@GioiThieu", GioiThieu);
            cmd.Parameters.Add("@DiaChi", DiaChi);
            cmd.Parameters.Add("@DienThoai", DienThoai);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            ExeCuteNonquery(cmd);
        }
        public static DataTable DoanhNhanThanhDat_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_DoanhNhanThanhDat_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }
        public static DataTable DoanhNhanThanhDat_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_DoanhNhanThanhDat_GetByForeignKey", GetConnect());
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
                            s = " and [DoanhNhanThanhDat].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [DoanhNhanThanhDat].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [DoanhNhanThanhDat].[" + s1[0] + "] like N'%" + str + "%'";
                            break;
                    }
                    break;
                default:
                    try { float.Parse(str); }
                    catch { return null; }
                    s = " and [DoanhNhanThanhDat].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }
    }
}