using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class CommonService
    {
        public static void InsertValue(string table, string prop, string value)
        {
            CommonControler.InsertValue(table, prop, value);
        }

        public static void UpdateValue(string table, string value, string where)
        {
            CommonControler.UpdateValue(table, value, where);
        }

        public static DataTable TinTuc_NhomTin_GetByTop(string Top, string Where, string Order)
        {
            return CommonControler.TinTuc_NhomTin_GetByTop(Top, Where, Order);
        }
    }
}