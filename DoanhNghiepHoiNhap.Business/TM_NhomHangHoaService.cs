using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TM_NhomHangHoaService
    {
        public static void TM_NhomHangHoa_Insert(string TenNhom, string MoTa, string HinhAnh, string ThuTu,
                                                 string Parent, string CapBac, string TrangThai, string TuKhoa, string NgonNgu)
        {
            TM_NhomHangHoaController.TM_NhomHangHoa_Insert(TenNhom, MoTa, HinhAnh, ThuTu, Parent, CapBac, TrangThai, TuKhoa , NgonNgu);
        }

        public static void TM_NhomHangHoa_Update(string Id, string TenNhom, string MoTa, string HinhAnh, string ThuTu,
                                                 string Parent, string CapBac, string TrangThai, string TuKhoa , string NgonNgu)
        {
            TM_NhomHangHoaController.TM_NhomHangHoa_Update(Id, TenNhom, MoTa, HinhAnh, ThuTu, Parent, CapBac, TrangThai, TuKhoa , NgonNgu);
        }

        public static void TM_NhomHangHoa_Delete(string Id)
        {
            TM_NhomHangHoaController.TM_NhomHangHoa_Delete(Id);
        }

        public static DataTable TM_NhomHangHoa_GetAll()
        {
            return TM_NhomHangHoaController.TM_NhomHangHoa_GetAll();
        }

        public static DataTable TM_NhomHangHoa_GetAllKey()
        {
            return TM_NhomHangHoaController.TM_NhomHangHoa_GetAllKey();
        }

        public static DataTable TM_NhomHangHoa_SearchColumn(string Str, string Value, string Tk)
        {
            return TM_NhomHangHoaController.TM_NhomHangHoa_SearchColumn(Str, Value, Tk);
        }

        public static DataTable TM_NhomHangHoa_GetById(string Id)
        {
            return TM_NhomHangHoaController.TM_NhomHangHoa_GetById(Id);
        }

        public static DataTable TM_NhomHangHoa_GetByTop(string Top, string Where, string Order)
        {
            return TM_NhomHangHoaController.TM_NhomHangHoa_GetByTop(Top, Where, Order);
        }
    }
}