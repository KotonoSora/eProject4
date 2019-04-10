using System.Data;
using DoanhNghiepHoiNhap.Data;

namespace DoanhNghiepHoiNhap.Business
{
    public class TT_Multimedia_GroupService
    {
        public static void TT_Multimedia_Group_Insert(string Ten, string MoTa, string ThuTu)
        {
            TT_Multimedia_GroupController.TT_Multimedia_Group_Insert(Ten, MoTa, ThuTu);
        }

        public static void TT_Multimedia_Group_Update(string Id, string Ten, string MoTa, string ThuTu)
        {
            TT_Multimedia_GroupController.TT_Multimedia_Group_Update(Id, Ten, MoTa, ThuTu);
        }

        public static void TT_Multimedia_Group_Delete(string Id)
        {
            TT_Multimedia_GroupController.TT_Multimedia_Group_Delete(Id);
        }

        public static DataTable TT_Multimedia_Group_GetAll()
        {
            return TT_Multimedia_GroupController.TT_Multimedia_Group_GetAll();
        }

        public static DataTable TT_Multimedia_Group_GetById(string Id)
        {
            return TT_Multimedia_GroupController.TT_Multimedia_Group_GetById(Id);
        }

        public static DataTable TT_Multimedia_Group_GetByTop(string Top, string Where, string Order)
        {
            return TT_Multimedia_GroupController.TT_Multimedia_Group_GetByTop(Top, Where, Order);
        }
    }
}