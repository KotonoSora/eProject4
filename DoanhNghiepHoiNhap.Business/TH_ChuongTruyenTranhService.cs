using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
    public class TH_ChuongTruyenTranhService
    {
        public static void TH_ChuongTruyenTranh_Insert(string Id_QuyenSach, string TenChuong, string Note_text, string Note_int, string NgayCapNhat)
        {
            TH_ChuongTruyenTranhController.TH_ChuongTruyenTranh_Insert(Id_QuyenSach, TenChuong, Note_text, Note_int, NgayCapNhat);
        }
        public static void TH_ChuongTruyenTranh_Update(string Id, string Id_QuyenSach, string TenChuong, string Note_text, string Note_int, string NgayCapNhat)
        {
            TH_ChuongTruyenTranhController.TH_ChuongTruyenTranh_Update(Id, Id_QuyenSach, TenChuong, Note_text, Note_int, NgayCapNhat);
        }
        public static void TH_ChuongTruyenTranh_Delete(string Id)
        {
            TH_ChuongTruyenTranhController.TH_ChuongTruyenTranh_Delete(Id);
        }
        public static DataTable TH_ChuongTruyenTranh_GetAll()
        {
            return TH_ChuongTruyenTranhController.TH_ChuongTruyenTranh_GetAll();
        }
        public static DataTable TH_ChuongTruyenTranh_GetAllKey()
        {
            return TH_ChuongTruyenTranhController.TH_ChuongTruyenTranh_GetAllKey();
        }
        public static DataTable TH_ChuongTruyenTranh_SearchColumn(string Str, string Value, string Tk)
        {
            return TH_ChuongTruyenTranhController.TH_ChuongTruyenTranh_SearchColumn(Str, Value, Tk);
        }
        public static DataTable TH_ChuongTruyenTranh_GetById(string Id)
        {
            return TH_ChuongTruyenTranhController.TH_ChuongTruyenTranh_GetById(Id);
        }
        public static DataTable TH_ChuongTruyenTranh_GetByTop(string Top, string Where, string Order)
        {
            return TH_ChuongTruyenTranhController.TH_ChuongTruyenTranh_GetByTop(Top, Where, Order);
        }
    }
}