using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_TinTucService
    {
        public static void TT_TinTuc_Insert(string TieuDe, string TieuDe2, string TomTat, string TomTat2, string NoiDung,
                                            string Tag, string HinhAnh, string NguoiDang,string Description, string Keyword, string TrangThai, string NhomTin)
        {
            TT_TinTucController.TT_TinTuc_Insert(TieuDe, TieuDe2, TomTat, TomTat2, NoiDung, Tag, HinhAnh, 
                                                 NguoiDang,  Description, Keyword,  TrangThai,
                                                 NhomTin);
        }

        public static void TT_TinTuc_Update(string Id, string TieuDe, string TieuDe2, string TomTat, string TomTat2,
                                            string NoiDung, string Tag, string HinhAnh, string Description, string Keyword,
                                            string TrangThai, string NhomTin)
        {
            TT_TinTucController.TT_TinTuc_Update(Id, TieuDe, TieuDe2, TomTat, TomTat2, NoiDung, Tag, HinhAnh,Description, Keyword, TrangThai,NhomTin);
        }

        public static void TT_TinTuc_Delete(string Id)
        {
            TT_TinTucController.TT_TinTuc_Delete(Id);
        }

        public static DataTable TT_TinTuc_GetAll()
        {
            return TT_TinTucController.TT_TinTuc_GetAll();
        }

        public static DataTable TT_TinTuc_GetAllKey()
        {
            return TT_TinTucController.TT_TinTuc_GetAllKey();
        }

        public static DataTable TT_TinTuc_SearchColumn(string Str, string Value, string Tk)
        {
            return TT_TinTucController.TT_TinTuc_SearchColumn(Str, Value, Tk);
        }

        public static DataTable TT_TinTuc_GetById(string Id)
        {
            return TT_TinTucController.TT_TinTuc_GetById(Id);
        }

        public static DataTable TT_TinTuc_GetByTop(string Top, string Where, string Order)
        {
            return TT_TinTucController.TT_TinTuc_GetByTop(Top, Where, Order);
        }

        public static DataTable TT_TinTuc_GetByForeignKey(string NhomTin)
        {
            return TT_TinTucController.TT_TinTuc_GetByForeignKey(NhomTin);
        }
    }
}