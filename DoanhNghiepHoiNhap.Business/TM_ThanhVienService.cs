using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TM_ThanhVienService
    {
        public static void TM_ThanhVien_Insert(string TenDangNhap, string MatKhau, string HoTen, string Email,
                                               string SoDT, string DiaChi, string GhiChu, string HinhAnh,
                                               string GioiTinh, string NgaySinh, string Yahoo, string Skype,
                                               string KeyActive, string TrangThai,string NhomNguoiDung)
        {
            TM_ThanhVienController.TM_ThanhVien_Insert(TenDangNhap, MatKhau, HoTen, Email, SoDT, DiaChi,  GhiChu,
                                                       HinhAnh, GioiTinh, NgaySinh, Yahoo, Skype, KeyActive, TrangThai, NhomNguoiDung);
        }

        public static void TM_ThanhVien_Update(string Id, string TenDangNhap, string HoTen, string Email,
                                               string SoDT, string DiaChi,string GhiChu, string HinhAnh,
                                               string GioiTinh, string NgaySinh, string Yahoo, string Skype, string TrangThai,string NhomNguoiDung)
        {
            TM_ThanhVienController.TM_ThanhVien_Update(Id, TenDangNhap, HoTen, Email, SoDT, DiaChi, 
                                                       GhiChu, HinhAnh, GioiTinh, NgaySinh, Yahoo, Skype, TrangThai,NhomNguoiDung);
        }

        public static void TM_ThanhVien_Delete(string Id)
        {
            TM_ThanhVienController.TM_ThanhVien_Delete(Id);
        }

        public static DataTable TM_THANHVIEN_CheckLogin(string username, string password)
        {
            return TM_ThanhVienController.TM_THANHVIEN_CheckLogin(username, password);
        }

        public static DataTable TM_ThanhVien_GetAll()
        {
            return TM_ThanhVienController.TM_ThanhVien_GetAll();
        }

        public static DataTable TM_ThanhVien_GetAllKey()
        {
            return TM_ThanhVienController.TM_ThanhVien_GetAllKey();
        }

        public static DataTable TM_ThanhVien_SearchColumn(string Str, string Value, string Tk)
        {
            return TM_ThanhVienController.TM_ThanhVien_SearchColumn(Str, Value, Tk);
        }

        public static DataTable TM_ThanhVien_GetById(string Id)
        {
            return TM_ThanhVienController.TM_ThanhVien_GetById(Id);
        }

        public static DataTable TM_ThanhVien_GetByTop(string Top, string Where, string Order)
        {
            return TM_ThanhVienController.TM_ThanhVien_GetByTop(Top, Where, Order);
        }

        public static DataTable TM_ThanhVien_GetByForeignKey(string TinhTP)
        {
            return TM_ThanhVienController.TM_ThanhVien_GetByForeignKey(TinhTP);
        }
    }
}