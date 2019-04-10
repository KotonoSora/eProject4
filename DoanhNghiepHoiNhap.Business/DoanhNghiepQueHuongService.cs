using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
    public class DoanhNghiepQueHuongService
    {
        public static void DoanhNghiepQueHuong_Insert(string Ten, string Logo, string GioiThieu, string GiamDoc, string DiaChi, string DienThoai, string Email, string ThuTu)
        {
            DoanhNghiepQueHuongController.DoanhNghiepQueHuong_Insert(Ten, Logo, GioiThieu, GiamDoc, DiaChi, DienThoai, Email, ThuTu);
        }
        public static void DoanhNghiepQueHuong_Update(string Id, string Ten, string Logo, string GioiThieu, string GiamDoc, string DiaChi, string DienThoai, string Email, string ThuTu)
        {
            DoanhNghiepQueHuongController.DoanhNghiepQueHuong_Update(Id, Ten, Logo, GioiThieu, GiamDoc, DiaChi, DienThoai, Email, ThuTu);
        }
        public static void DoanhNghiepQueHuong_Delete(string Id)
        {
            DoanhNghiepQueHuongController.DoanhNghiepQueHuong_Delete(Id);
        }
        public static DataTable DoanhNghiepQueHuong_GetAll()
        {
            return DoanhNghiepQueHuongController.DoanhNghiepQueHuong_GetAll();
        }
        public static DataTable DoanhNghiepQueHuong_GetAllKey()
        {
            return DoanhNghiepQueHuongController.DoanhNghiepQueHuong_GetAllKey();
        }
        public static DataTable DoanhNghiepQueHuong_SearchColumn(string Str, string Value, string Tk)
        {
            return DoanhNghiepQueHuongController.DoanhNghiepQueHuong_SearchColumn(Str, Value, Tk);
        }
        public static DataTable DoanhNghiepQueHuong_GetById(string Id)
        {
            return DoanhNghiepQueHuongController.DoanhNghiepQueHuong_GetById(Id);
        }
        public static DataTable DoanhNghiepQueHuong_GetByTop(string Top, string Where, string Order)
        {
            return DoanhNghiepQueHuongController.DoanhNghiepQueHuong_GetByTop(Top, Where, Order);
        }
    }
}