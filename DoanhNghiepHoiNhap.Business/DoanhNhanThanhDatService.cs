using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
    public class DoanhNhanThanhDatService
    {
        public static void DoanhNhanThanhDat_Insert(string Ten, string Anh, string GioiThieu, string DiaChi, string DienThoai, string Email, string ThuTu)
        {
            DoanhNhanThanhDatController.DoanhNhanThanhDat_Insert(Ten, Anh, GioiThieu, DiaChi, DienThoai, Email, ThuTu);
        }
        public static void DoanhNhanThanhDat_Update(string Id, string Ten, string Anh, string GioiThieu, string DiaChi, string DienThoai, string Email, string ThuTu)
        {
            DoanhNhanThanhDatController.DoanhNhanThanhDat_Update(Id, Ten, Anh, GioiThieu, DiaChi, DienThoai, Email, ThuTu);
        }
        public static void DoanhNhanThanhDat_Delete(string Id)
        {
            DoanhNhanThanhDatController.DoanhNhanThanhDat_Delete(Id);
        }
        public static DataTable DoanhNhanThanhDat_GetAll()
        {
            return DoanhNhanThanhDatController.DoanhNhanThanhDat_GetAll();
        }
        public static DataTable DoanhNhanThanhDat_GetAllKey()
        {
            return DoanhNhanThanhDatController.DoanhNhanThanhDat_GetAllKey();
        }
        public static DataTable DoanhNhanThanhDat_SearchColumn(string Str, string Value, string Tk)
        {
            return DoanhNhanThanhDatController.DoanhNhanThanhDat_SearchColumn(Str, Value, Tk);
        }
        public static DataTable DoanhNhanThanhDat_GetById(string Id)
        {
            return DoanhNhanThanhDatController.DoanhNhanThanhDat_GetById(Id);
        }
        public static DataTable DoanhNhanThanhDat_GetByTop(string Top, string Where, string Order)
        {
            return DoanhNhanThanhDatController.DoanhNhanThanhDat_GetByTop(Top, Where, Order);
        }
    }
}