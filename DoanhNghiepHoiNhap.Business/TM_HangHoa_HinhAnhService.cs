using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TM_HangHoa_HinhAnhService
    {
        public static void TM_HangHoa_HinhAnh_Insert(string HinhAnh, string MoTa, string ThuTu, string HangHoa)
        {
            TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_Insert(HinhAnh, MoTa, ThuTu, HangHoa);
        }

        public static void TM_HangHoa_HinhAnh_Update(string Id, string HinhAnh, string MoTa, string ThuTu,
                                                     string HangHoa)
        {
            TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_Update(Id, HinhAnh, MoTa, ThuTu, HangHoa);
        }

        public static void TM_HangHoa_HinhAnh_Delete(string Id)
        {
            TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_Delete(Id);
        }

        public static DataTable TM_HangHoa_HinhAnh_GetAll()
        {
            return TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_GetAll();
        }

        public static DataTable TM_HangHoa_HinhAnh_GetAllKey()
        {
            return TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_GetAllKey();
        }

        public static DataTable TM_HangHoa_HinhAnh_SearchColumn(string Str, string Value, string Tk)
        {
            return TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_SearchColumn(Str, Value, Tk);
        }

        public static DataTable TM_HangHoa_HinhAnh_GetById(string Id)
        {
            return TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_GetById(Id);
        }

        public static DataTable TM_HangHoa_HinhAnh_GetByTop(string Top, string Where, string Order)
        {
            return TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_GetByTop(Top, Where, Order);
        }

        public static DataTable TM_HangHoa_HinhAnh_GetByForeignKey(string HangHoa)
        {
            return TM_HangHoa_HinhAnhController.TM_HangHoa_HinhAnh_GetByForeignKey(HangHoa);
        }
    }
}