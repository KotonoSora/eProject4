using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
    public class TH_TheLoaiSachService
    {
        public static void TH_TheLoaiSach_Insert(string TenTheLoaiSach, string Note_text, string Note_int)
        {
            TH_TheLoaiSachController.TH_TheLoaiSach_Insert(TenTheLoaiSach, Note_text, Note_int);
        }
        public static void TH_TheLoaiSach_Update(string Id, string TenTheLoaiSach, string Note_text, string Note_int)
        {
            TH_TheLoaiSachController.TH_TheLoaiSach_Update(Id, TenTheLoaiSach, Note_text, Note_int);
        }
        public static void TH_TheLoaiSach_Delete(string Id)
        {
            TH_TheLoaiSachController.TH_TheLoaiSach_Delete(Id);
        }
        public static DataTable TH_TheLoaiSach_GetAll()
        {
            return TH_TheLoaiSachController.TH_TheLoaiSach_GetAll();
        }
        public static DataTable TH_TheLoaiSach_GetAllKey()
        {
            return TH_TheLoaiSachController.TH_TheLoaiSach_GetAllKey();
        }
        public static DataTable TH_TheLoaiSach_SearchColumn(string Str, string Value, string Tk)
        {
            return TH_TheLoaiSachController.TH_TheLoaiSach_SearchColumn(Str, Value, Tk);
        }
        public static DataTable TH_TheLoaiSach_GetById(string Id)
        {
            return TH_TheLoaiSachController.TH_TheLoaiSach_GetById(Id);
        }
        public static DataTable TH_TheLoaiSach_GetByTop(string Top, string Where, string Order)
        {
            return TH_TheLoaiSachController.TH_TheLoaiSach_GetByTop(Top, Where, Order);
        }
    }
}