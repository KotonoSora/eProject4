using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TT_CauHinhChungController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TT_CauHinhChung_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TT_CauHinhChung_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_CauHinhChung_GetAll()
        {
            cmd = new SqlCommand("sp_TT_CauHinhChung_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TT_CauHinhChung_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TT_CauHinhChung_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static void TT_CauHinhChung_Insert(string Banner, string Footer, string Description, string Keyword,
                                                  string Email, string Password, string DuyetTuDong)
        {
            cmd = new SqlCommand("sp_TT_CauHinhChung_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Banner", Banner);
            cmd.Parameters.Add("@Footer", Footer);
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@Keyword", Keyword);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@Password", Password);
            cmd.Parameters.Add("@DuyetTuDong", DuyetTuDong);
            ExeCuteNonquery(cmd);
        }

        public static void TT_CauHinhChung_Update(string Id,string Logo, string Banner, string Footer, string Description,
                                                  string Keyword, string Email, string Password, string DuyetTuDong,
                                                  string SoQuangCao, string SoQuangCaoNhomTin, string ThongTinLienHe,                                                 
                                                  string HienThiChuyenDe,
                                                  string Banner_Mobile, string Footer_Mobile, string GooglePlus, string Twitter, string Youtube,
                                                  string ThongTinLienHe2, string ThongTinLienHe3, string BanDo, string Sdt, string MoTaGmail, string MoTaSdt,
                                                  string MoTaTweet, string MoTaVisitus)
        {
            cmd = new SqlCommand("sp_TT_CauHinhChung_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@Logo", Logo);
            cmd.Parameters.Add("@Banner", Banner);
            cmd.Parameters.Add("@Footer", Footer);
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@Keyword", Keyword);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@Password", Password);
            cmd.Parameters.Add("@DuyetTuDong", DuyetTuDong);
            cmd.Parameters.Add("@SoQuangCao", SoQuangCao);
            cmd.Parameters.Add("@SoQuangCaoNhomTin", SoQuangCaoNhomTin);
            cmd.Parameters.Add("@ThongTinLienHe", ThongTinLienHe);
            cmd.Parameters.Add("@HienThiChuyenDe", HienThiChuyenDe);
            cmd.Parameters.Add("@Banner_Mobile", Banner_Mobile);
            cmd.Parameters.Add("@Footer_Mobile", Footer_Mobile);
            cmd.Parameters.Add("@GooglePlus", GooglePlus);
            cmd.Parameters.Add("@Twitter", Twitter);
            cmd.Parameters.Add("@Youtube", Youtube);
            cmd.Parameters.Add("@ThongTinLienHe2", ThongTinLienHe2);
            cmd.Parameters.Add("@ThongTinLienHe3", ThongTinLienHe3);
            cmd.Parameters.Add("@BanDo", BanDo);

            cmd.Parameters.Add("@Sdt", Sdt);
            cmd.Parameters.Add("@MoTaGmail", MoTaGmail);
            cmd.Parameters.Add("@MoTaSdt", MoTaSdt);
            cmd.Parameters.Add("@MoTaTweet", MoTaTweet);
            cmd.Parameters.Add("@MoTaVisitus", MoTaVisitus);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TT_CauHinhChung_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TT_CauHinhChung_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TT_CauHinhChung_SearchColumn(string s)
        {
            cmd = new SqlCommand("sp_TT_CauHinhChung_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        #region[TT_CauHinhChung_GetAllKey]

        public static DataTable TT_CauHinhChung_GetAllKey()
        {
            cmd = new SqlCommand("sp_TT_CauHinhChung_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}