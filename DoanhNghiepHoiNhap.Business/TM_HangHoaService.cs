using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TM_HangHoaService
    {
        public static DataTable TM_HangHoa_Insert(string MaSP, string TenSP, string MoTa, 
                                             string NguoiTao, string TrangThai, string NhomHangHoa,
                                             string Keyword, string Description, string BaoHanh, string DanhGia, string KhuyenMai, string BanChay)
        {
            return TM_HangHoaController.TM_HangHoa_Insert(MaSP, TenSP, MoTa, NguoiTao, TrangThai,NhomHangHoa, Keyword, Description, BaoHanh, DanhGia, KhuyenMai, BanChay);
        }

        public static void TM_HangHoa_Update(string Id, string MaSP, string TenSP,string MoTa,
                                             string TrangThai, string NhomHangHoa, string Keyword, string Description, string BaoHanh, string DanhGia, string KhuyenMai, string BanChay)
        {
            TM_HangHoaController.TM_HangHoa_Update(Id, MaSP, TenSP, MoTa, TrangThai, NhomHangHoa, Keyword, Description, BaoHanh, DanhGia, KhuyenMai, BanChay);
        }

        public static void TM_HangHoa_Delete(string Id)
        {
            TM_HangHoaController.TM_HangHoa_Delete(Id);
        }

        public static DataTable TM_HangHoa_GetAll()
        {
            return TM_HangHoaController.TM_HangHoa_GetAll();
        }

        public static DataTable TM_HangHoa_GetAllKey()
        {
            return TM_HangHoaController.TM_HangHoa_GetAllKey();
        }

        public static DataTable TM_HangHoa_SearchColumn(string Str, string Value, string Tk)
        {
            return TM_HangHoaController.TM_HangHoa_SearchColumn(Str, Value, Tk);
        }

        public static DataTable TM_HangHoa_GetById(string Id)
        {
            return TM_HangHoaController.TM_HangHoa_GetById(Id);
        }

        public static DataTable TM_HangHoa_GetByTop(string Top, string Where, string Order)
        {
            return TM_HangHoaController.TM_HangHoa_GetByTop(Top, Where, Order);
        }

        public static DataTable TM_HangHoa_GetByTop_GianHang(string Top, string Where, string Order)
        {
            return TM_HangHoaController.TM_HangHoa_GetByTop_GianHang(Top, Where, Order);
        }

        public static DataTable TM_HangHoa_GetByTop_PhieuNhap(string Top, string Where, string Order)
        {
            return TM_HangHoaController.TM_HangHoa_GetByTop_PhieuNhap(Top, Where, Order);
        }

        public static DataTable TM_HangHoa_GetByTop_PhieuXuat(string Top, string Where, string Order)
        {
            return TM_HangHoaController.TM_HangHoa_GetByTop_PhieuXuat(Top, Where, Order);
        }

        public static DataTable TM_HangHoa_GetByForeignKey(string NhomHangHoa, string DonViTinh)
        {
            return TM_HangHoaController.TM_HangHoa_GetByForeignKey(NhomHangHoa, DonViTinh);
        }
    }
}