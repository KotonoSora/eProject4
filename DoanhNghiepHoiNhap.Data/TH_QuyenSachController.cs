using System.Data;
using System.Data.SqlClient;
namespace DoanhNghiepHoiNhap.Data
{

    public class TH_QuyenSachController : SqlDataProvider
    {
        private static SqlCommand cmd;
        public static void TH_QuyenSach_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }
        public static DataTable TH_QuyenSach_GetAll()
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }
        #region[TH_QuyenSach_GetAllKey]
        public static DataTable TH_QuyenSach_GetAllKey()
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }
        #endregion
        public static DataTable TH_QuyenSach_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }
        public static void TH_QuyenSach_Insert(string TieuDe_QuyenSach, string TacGia, string Mota, string Note, string Id_TheLoaiSach, string Luotxem, string HinhAnh, string Id_TheLoaiChuong, string NgayUp)
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TieuDe_QuyenSach", TieuDe_QuyenSach);
            cmd.Parameters.Add("@TacGia", TacGia);
            cmd.Parameters.Add("@Mota", Mota);
            cmd.Parameters.Add("@Note", Note);
            cmd.Parameters.Add("@Id_TheLoaiSach", Id_TheLoaiSach);
            cmd.Parameters.Add("@Luotxem", Luotxem);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@Id_TheLoaiChuong", Id_TheLoaiChuong);
            cmd.Parameters.Add("@NgayUp", NgayUp);
            ExeCuteNonquery(cmd);
        }
        public static void TH_QuyenSach_Update(string Id, string TieuDe_QuyenSach, string TacGia, string Mota, string Note, string Id_TheLoaiSach, string Luotxem, string HinhAnh, string Id_TheLoaiChuong, string NgayUp)
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@TieuDe_QuyenSach", TieuDe_QuyenSach);
            cmd.Parameters.Add("@TacGia", TacGia);
            cmd.Parameters.Add("@Mota", Mota);
            cmd.Parameters.Add("@Note", Note);
            cmd.Parameters.Add("@Id_TheLoaiSach", Id_TheLoaiSach);
            cmd.Parameters.Add("@Luotxem", Luotxem);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@Id_TheLoaiChuong", Id_TheLoaiChuong);
            cmd.Parameters.Add("@NgayUp", NgayUp);
            ExeCuteNonquery(cmd);
        }

        //sp_TH_QuyenSach_Paging
        public static DataTable TH_QuyenSach_Paging(string NumberPage, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_Paging", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NumberPage", NumberPage);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TH_QuyenSach_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }
        public static DataTable TH_QuyenSach_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TH_QuyenSach_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            var s = "";
            var s1 = value.Split('*');
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
                            s = " and [TH_QuyenSach].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TH_QuyenSach].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TH_QuyenSach].[" + s1[0] + "] like N'%" + str + "%'";
                            break;
                    }
                    break;
                default:
                    try { float.Parse(str); }
                    catch { return null; }
                    s = " and [TH_QuyenSach].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }
    }
}