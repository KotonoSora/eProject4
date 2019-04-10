using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
    public class TH_ChuongService
    {
        public static void TH_Chuong_Insert(string Id_QuyenSach, string TieuDe, string NoiDung, string Note_text, string Note_int, string NgayCapNhat)
        {
            TH_ChuongController.TH_Chuong_Insert(Id_QuyenSach, TieuDe, NoiDung, Note_text, Note_int, NgayCapNhat);
        }
        public static void TH_Chuong_Update(string Id, string Id_QuyenSach, string TieuDe, string NoiDung, string Note_text, string Note_int, string NgayCapNhat)
        {
            TH_ChuongController.TH_Chuong_Update(Id, Id_QuyenSach, TieuDe, NoiDung, Note_text, Note_int, NgayCapNhat);
        }
        public static void TH_Chuong_Delete(string Id)
        {
            TH_ChuongController.TH_Chuong_Delete(Id);
        }
        public static DataTable TH_Chuong_GetAll()
        {
            return TH_ChuongController.TH_Chuong_GetAll();
        }
        public static DataTable TH_Chuong_GetAllKey()
        {
            return TH_ChuongController.TH_Chuong_GetAllKey();
        }
        public static DataTable TH_Chuong_SearchColumn(string Str, string Value, string Tk)
        {
            return TH_ChuongController.TH_Chuong_SearchColumn(Str, Value, Tk);
        }
        public static DataTable TH_Chuong_GetById(string Id)
        {
            return TH_ChuongController.TH_Chuong_GetById(Id);
        }
        public static DataTable TH_Chuong_GetByTop(string Top, string Where, string Order)
        {
            return TH_ChuongController.TH_Chuong_GetByTop(Top, Where, Order);
        }
        // TT_Chuong_Paging
        public static DataTable TT_Chuong_Paging(string NumberPage, string Where, string Order)
        {
            return TH_ChuongController.TT_Chuong_Paging(NumberPage, Where, Order);
        }

        // TT_Chuong_Paging_InfoChuong
        public static DataTable TT_Chuong_Paging_InfoChuong(string NumberPage, string Where, string Order)
        {
            return TH_ChuongController.TT_Chuong_Paging_InfoChuong(NumberPage, Where, Order);
        }
    }
}