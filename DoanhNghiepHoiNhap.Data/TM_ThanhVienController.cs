using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TM_ThanhVienController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TM_ThanhVien_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_ThanhVien_GetAll()
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TM_ThanhVien_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static DataTable TM_THANHVIEN_CheckLogin(string username, string password)
        {
            cmd = new SqlCommand("sp_TM_THANHVIEN_CheckLogin", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", username);
            cmd.Parameters.Add("@password", password);
            return GetTable(cmd);
        }

        public static void TM_ThanhVien_Insert(string TenDangNhap, string MatKhau, string HoTen, string Email,
                                               string SoDT, string DiaChi, string GhiChu, string HinhAnh,
                                               string GioiTinh, string NgaySinh, string Yahoo, string Skype,
                                               string KeyActive, string TrangThai,string NhomNguoiDung)
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenDangNhap", TenDangNhap);
            cmd.Parameters.Add("@MatKhau", MatKhau);
            cmd.Parameters.Add("@HoTen", HoTen);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@SoDT", SoDT);
            cmd.Parameters.Add("@DiaChi", DiaChi);  
            cmd.Parameters.Add("@GhiChu", GhiChu);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@GioiTinh", GioiTinh);
            cmd.Parameters.Add("@NgaySinh", NgaySinh);
            cmd.Parameters.Add("@Yahoo", Yahoo);
            cmd.Parameters.Add("@Skype", Skype);
            cmd.Parameters.Add("@KeyActive", KeyActive);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@NhomNguoiDung", NhomNguoiDung);
            ExeCuteNonquery(cmd);
        }

        public static void TM_ThanhVien_Update(string Id, string TenDangNhap,  string HoTen, string Email,
                                               string SoDT, string DiaChi, string GhiChu, string HinhAnh,
                                               string GioiTinh, string NgaySinh, string Yahoo, string Skype, string TrangThai,string NhomNguoiDung)
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@TenDangNhap", TenDangNhap); 
            cmd.Parameters.Add("@HoTen", HoTen);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@SoDT", SoDT);
            cmd.Parameters.Add("@DiaChi", DiaChi);  
            cmd.Parameters.Add("@GhiChu", GhiChu);
            cmd.Parameters.Add("@HinhAnh", HinhAnh);
            cmd.Parameters.Add("@GioiTinh", GioiTinh);
            cmd.Parameters.Add("@NgaySinh", NgaySinh);
            cmd.Parameters.Add("@Yahoo", Yahoo);
            cmd.Parameters.Add("@Skype", Skype);
            cmd.Parameters.Add("@TrangThai", TrangThai); 
            cmd.Parameters.Add("@NhomNguoiDung", NhomNguoiDung);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_ThanhVien_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TM_ThanhVien_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_GetByForeignKey", GetConnect());
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
                            s = " and [TM_ThanhVien].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TM_ThanhVien].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TM_ThanhVien].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TM_ThanhVien].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TM_ThanhVien_GetByForeignKey(string TinhTP)
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            string str = "";
            if (!string.IsNullOrEmpty(TinhTP))
                str += " and [TM_ThanhVien].[TinhTP]='" + TinhTP + "' ";
            cmd.Parameters.Add("@dk", str);
            return GetTable(cmd);
        }

        #region[TM_ThanhVien_GetAllKey]

        public static DataTable TM_ThanhVien_GetAllKey()
        {
            cmd = new SqlCommand("sp_TM_ThanhVien_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}