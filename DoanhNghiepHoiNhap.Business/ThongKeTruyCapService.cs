using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class ThongKeTruyCapService
    {
        public static void ThongKeTruyCap_Insert(string Date, string Num)
        {
            ThongKeTruyCapController.ThongKeTruyCap_Insert(Date, Num);
        }

        public static bool ThongKeTruyCap_GetByDate(string Date)
        {
            return ThongKeTruyCapController.ThongKeTruyCap_GetByDate(Date).Rows.Count > 0;
        }

        public static void ThongKeTruyCap_UpdateDate(string Date)
        {
            ThongKeTruyCapController.ThongKeTruyCap_UpdateDate(Date);
        }

        public static DataTable ThongKeTruyCap_GetByTuNgayDenNgay(string TuNgay, string DenNgay)
        {
            return ThongKeTruyCapController.ThongKeTruyCap_GetByTuNgayDenNgay(TuNgay, DenNgay);
        }
    }
}