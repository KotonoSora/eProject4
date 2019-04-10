using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TM_HoTroTrucTuyenService
    {
        public static void TM_HoTroTrucTuyen_Insert(string Nickname, string MoTa, string Loai, string ThuTu)
        {
            TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_Insert(Nickname, MoTa, Loai, ThuTu);
        }

        public static void TM_HoTroTrucTuyen_Update(string Id, string Nickname, string MoTa, string Loai, string ThuTu)
        {
            TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_Update(Id, Nickname, MoTa, Loai, ThuTu);
        }

        public static void TM_HoTroTrucTuyen_Delete(string Id)
        {
            TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_Delete(Id);
        }

        public static DataTable TM_HoTroTrucTuyen_GetAll()
        {
            return TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_GetAll();
        }

        public static DataTable TM_HoTroTrucTuyen_GetAllKey()
        {
            return TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_GetAllKey();
        }

        public static DataTable TM_HoTroTrucTuyen_SearchColumn(string Str, string Value, string Tk)
        {
            return TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_SearchColumn(Str, Value, Tk);
        }

        public static DataTable TM_HoTroTrucTuyen_GetById(string Id)
        {
            return TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_GetById(Id);
        }

        public static DataTable TM_HoTroTrucTuyen_GetByTop(string Top, string Where, string Order)
        {
            return TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_GetByTop(Top, Where, Order);
        }

        public static DataTable TM_HoTroTrucTuyen_GetByForeignKey(string GianHang_Id)
        {
            return TM_HoTroTrucTuyenController.TM_HoTroTrucTuyen_GetByForeignKey(GianHang_Id);
        }
    }
}