using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TM_HoTroTrucTuyenController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TM_HoTroTrucTuyen_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_HoTroTrucTuyen_GetAll()
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TM_HoTroTrucTuyen_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TM_HoTroTrucTuyen_Insert(string Nickname, string MoTa, string Loai, string ThuTu)
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nickname", Nickname);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@Loai", Loai);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            ExeCuteNonquery(cmd);
        }

        public static void TM_HoTroTrucTuyen_Update(string Id, string Nickname, string MoTa, string Loai, string ThuTu)
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Nickname", Nickname);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@Loai", Loai);
            cmd.Parameters.Add("@ThuTu", ThuTu);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_HoTroTrucTuyen_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TM_HoTroTrucTuyen_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            string s = "";
            string[] s1 = value.Split('*');
            switch (s1[1])
            {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    switch (tk)
                    {
                        case "1":
                            s = " and [TM_HoTroTrucTuyen].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TM_HoTroTrucTuyen].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TM_HoTroTrucTuyen].[" + s1[0] + "] like N'%" + str + "%'";
                            break;
                    }
                    break;
                default:
                    try
                    {
                        float.Parse(str);
                    }
                    catch
                    {
                        return null;
                    }
                    s = " and [TM_HoTroTrucTuyen].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TM_HoTroTrucTuyen_GetByForeignKey(string GianHang_Id)
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            string str = "";
            if (!string.IsNullOrEmpty(GianHang_Id))
                str += " and [TM_HoTroTrucTuyen].[GianHang_Id]=" + GianHang_Id + " ";
            cmd.Parameters.Add("@dk", str);
            return GetTable(cmd);
        }

        #region[TM_HoTroTrucTuyen_GetAllKey]

        public static DataTable TM_HoTroTrucTuyen_GetAllKey()
        {
            cmd = new SqlCommand("sp_TM_HoTroTrucTuyen_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}