using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class ThongKeTruyCapController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void ThongKeTruyCap_Insert(string Date, string Num)
        {
            cmd = new SqlCommand("sp_ThongKeTruyCap_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", Date);
            cmd.Parameters.Add("@Num", Num);
            ExeCuteNonquery(cmd);
        }

        public static DataTable ThongKeTruyCap_GetByDate(string Date)
        {
            cmd = new SqlCommand("sp_ThongKeTruyCap_GetByDate", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", Date);
            return GetTable(cmd);
        }

        public static DataTable ThongKeTruyCap_GetByTuNgayDenNgay(string TuNgay, string DenNgay)
        {
            cmd = new SqlCommand("sp_ThongKeTruyCap_GetByTuNgayDenNgay", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TuNgay", TuNgay);
            cmd.Parameters.Add("@DenNgay", DenNgay);
            return GetTable(cmd);
        }

        public static void ThongKeTruyCap_UpdateDate(string Date)
        {
            cmd = new SqlCommand("sp_ThongKeTruyCap_UpdateDate", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", Date);
            ExeCuteNonquery(cmd);
        }
    }
}