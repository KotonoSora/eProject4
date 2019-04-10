using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
    public class TH_QuyenSachService
    {
        public static void TH_QuyenSach_Insert(string TieuDe_QuyenSach, string TacGia, string Mota, string Note, string Id_TheLoaiSach, string Luotxem, string HinhAnh, string Id_TheLoaiChuong, string NgayUp)
        {
            TH_QuyenSachController.TH_QuyenSach_Insert(TieuDe_QuyenSach, TacGia, Mota, Note, Id_TheLoaiSach, Luotxem, HinhAnh, Id_TheLoaiChuong, NgayUp);
        }
        public static void TH_QuyenSach_Update(string Id, string TieuDe_QuyenSach, string TacGia, string Mota, string Note, string Id_TheLoaiSach, string Luotxem, string HinhAnh, string Id_TheLoaiChuong, string NgayUp)
        {
            TH_QuyenSachController.TH_QuyenSach_Update(Id, TieuDe_QuyenSach, TacGia, Mota, Note, Id_TheLoaiSach, Luotxem, HinhAnh, Id_TheLoaiChuong, NgayUp);
        }
        public static void TH_QuyenSach_Delete(string Id)
        {
            TH_QuyenSachController.TH_QuyenSach_Delete(Id);
        }
        public static DataTable TH_QuyenSach_GetAll()
        {
            return TH_QuyenSachController.TH_QuyenSach_GetAll();
        }
        public static DataTable TH_QuyenSach_GetAllKey()
        {
            return TH_QuyenSachController.TH_QuyenSach_GetAllKey();
        }
        public static DataTable TH_QuyenSach_SearchColumn(string Str, string Value, string Tk)
        {
            return TH_QuyenSachController.TH_QuyenSach_SearchColumn(Str, Value, Tk);
        }
        public static DataTable TH_QuyenSach_GetById(string Id)
        {
            return TH_QuyenSachController.TH_QuyenSach_GetById(Id);
        }
        public static DataTable TH_QuyenSach_GetByTop(string Top, string Where, string Order)
        {
            return TH_QuyenSachController.TH_QuyenSach_GetByTop(Top, Where, Order);
        }

        // TT_TaoPhieuXuatXang_Paging
        public static DataTable TH_QuyenSach_Paging(string NumberPage, string Where, string Order)
        {
            return TH_QuyenSachController.TH_QuyenSach_Paging(NumberPage, Where, Order);
        }
    }
}