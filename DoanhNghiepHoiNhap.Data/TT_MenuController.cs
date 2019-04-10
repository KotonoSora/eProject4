using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_MenuController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_Menu_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TT_Menu_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_Menu_GetAll()
        {
            cmd = new SqlCommand("sp_TT_Menu_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_Menu_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TT_Menu_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TT_Menu_Insert(string Ten, string Link, string Cha, string ThuTu, string HienThi,
                                          string NgonNgu, string Loai, string ChiTiet)
        {
            cmd = new SqlCommand("sp_TT_Menu_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@Link", Link);
            cmd.Parameters.Add("@Cha", Cha);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@HienThi", HienThi);
            cmd.Parameters.Add("@NgonNgu", NgonNgu);
            cmd.Parameters.Add("@Loai", Loai);
            cmd.Parameters.Add("@ChiTiet", ChiTiet);
            ExeCuteNonquery(cmd);
        }

        public static void TT_Menu_Update(string Id, string Ten, string Link, string Cha, string ThuTu, string HienThi,
                                          string NgonNgu, string Loai, string ChiTiet)
        {
            cmd = new SqlCommand("sp_TT_Menu_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Ten", Ten);
            cmd.Parameters.Add("@Link", Link);
            cmd.Parameters.Add("@Cha", Cha);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            cmd.Parameters.Add("@HienThi", HienThi);
            cmd.Parameters.Add("@NgonNgu", NgonNgu);
            cmd.Parameters.Add("@Loai", Loai);
            cmd.Parameters.Add("@ChiTiet", ChiTiet);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_Menu_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_Menu_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_Menu_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_Menu_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        #region[TT_Menu_GetAllKey]

        public static DataTable TT_Menu_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_Menu_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}