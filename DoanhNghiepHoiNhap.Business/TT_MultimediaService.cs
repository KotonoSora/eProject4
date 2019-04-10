using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_MultimediaService
    {
        public static void TT_Multimedia_Insert(string TieuDe, string MoTa, string NoiDung, string Loai, string LuotXem,
                                                string AnhDaiDien)
        {
            TT_MultimediaController.TT_Multimedia_Insert(TieuDe, MoTa, NoiDung, Loai, LuotXem, AnhDaiDien);
        }

        public static void TT_Multimedia_Update(string Id, string TieuDe, string MoTa, string NoiDung, string Loai, string LuotXem,
                                                string AnhDaiDien)
        {
            TT_MultimediaController.TT_Multimedia_Update(Id, TieuDe, MoTa, NoiDung, Loai,LuotXem, AnhDaiDien );
        }

        public static void TT_Multimedia_Delete(string Id)
        {
            TT_MultimediaController.TT_Multimedia_Delete(Id);
        }

        public static DataTable TT_Multimedia_GetAll()
        {
            return TT_MultimediaController.TT_Multimedia_GetAll();
        }

        public static DataTable TT_Multimedia_GetAllKey()
        {
            return TT_MultimediaController.TT_Multimedia_GetAllKey();
        }

        public static DataTable TT_Multimedia_SearchColumn(string Str, string Value, string Tk)
        {
            return TT_MultimediaController.TT_Multimedia_SearchColumn(Str, Value, Tk);
        }

        public static DataTable TT_Multimedia_GetById(string Id)
        {
            return TT_MultimediaController.TT_Multimedia_GetById(Id);
        }

        public static DataTable TT_Multimedia_GetById_ThanhNV(string Id)
        {
            return TT_MultimediaController.TT_Multimedia_GetById_ThanhNV(Id);
        }

        public static DataTable TT_Multimedia_GetByTop(string Top, string Where, string Order)
        {
            Where = SqlDataProvider.FilterSqlInjection(Where);
            return TT_MultimediaController.TT_Multimedia_GetByTop(Top, Where, Order);
        }
    }
}