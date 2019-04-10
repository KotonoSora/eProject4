using System.Data;
using System.Data.SqlClient;

namespace DoanhNghiepHoiNhap.Data
{
    public class TM_HangHoaController : SqlDataProvider
    {
        private static SqlCommand cmd;

        public static void TM_HangHoa_Delete(string Id)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_Delete", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_HangHoa_GetAll()
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetAll", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_GetById(string Id)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetById", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_Insert(string MaSP, string TenSP,string MoTa, 
                                             string NguoiTao, string TrangThai, string NhomHangHoa,
                                             string Keyword, string Description, string BaoHanh, string DanhGia, string KhuyenMai, string BanChay)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_Insert", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaSP", MaSP);
            cmd.Parameters.Add("@TenSP", TenSP); 
            cmd.Parameters.Add("@MoTa", MoTa); 
            cmd.Parameters.Add("@NguoiTao", NguoiTao);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@NhomHangHoa", NhomHangHoa);
            cmd.Parameters.Add("@SoLuong", "0");
            cmd.Parameters.Add("@Keyword", Keyword);
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@BaoHanh", BaoHanh);
            cmd.Parameters.Add("@DanhGia", DanhGia);
            cmd.Parameters.Add("@KhuyenMai", KhuyenMai);
            cmd.Parameters.Add("@BanChay", BanChay);
            return GetTable(cmd);
        }

        public static void TM_HangHoa_Update(string Id, string MaSP, string TenSP,string MoTa,
                                             string TrangThai, string NhomHangHoa, string Keyword, string Description, string BaoHanh, string DanhGia, string KhuyenMai, string BanChay)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_Update", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", Id);
            cmd.Parameters.Add("@MaSP", MaSP);
            cmd.Parameters.Add("@TenSP", TenSP);
            cmd.Parameters.Add("@MoTa", MoTa);
            cmd.Parameters.Add("@TrangThai", TrangThai);
            cmd.Parameters.Add("@NhomHangHoa", NhomHangHoa);
            cmd.Parameters.Add("@SoLuong", "0");
            cmd.Parameters.Add("@Keyword", Keyword);
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@BaoHanh", BaoHanh);
            cmd.Parameters.Add("@DanhGia", DanhGia);
            cmd.Parameters.Add("@KhuyenMai", KhuyenMai);
            cmd.Parameters.Add("@BanChay", BanChay);
            ExeCuteNonquery(cmd);
        }

        public static DataTable TM_HangHoa_GetByTop(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetByTop", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_GetByTop_GianHang(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetByTop_GianHang", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_GetByTop_PhieuNhap(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetByTop_PhieuNhap", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_GetByTop_PhieuXuat(string Top, string Where, string Order)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetByTop_PhieuXuat", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Top", Top);
            cmd.Parameters.Add("@Where", Where);
            cmd.Parameters.Add("@Order", Order);
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_SearchColumn(string str, string value, string tk)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetByForeignKey", GetConnect());
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
                            s = " and [TM_HangHoa].[" + s1[0] + "]=N'" + str + "'";
                            break;
                        case "2":
                            s = " and [TM_HangHoa].[" + s1[0] + "] like N'" + str + "%'";
                            break;
                        case "3":
                            s = " and [TM_HangHoa].[" + s1[0] + "] like N'%" + str + "%'";
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
                    s = " and [TM_HangHoa].[" + s1[0] + "]=" + str + "";
                    break;
            }
            cmd.Parameters.Add("@dk", s);
            return GetTable(cmd);
        }

        public static DataTable TM_HangHoa_GetByForeignKey(string NhomHangHoa, string DonViTinh)
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetByForeignKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            string str = "";
            if (!string.IsNullOrEmpty(NhomHangHoa))
                str += " and [TM_HangHoa].[NhomHangHoa]=" + NhomHangHoa + " ";
            if (!string.IsNullOrEmpty(DonViTinh))
                str += " and [TM_HangHoa].[DonViTinh]=" + DonViTinh + " ";
            cmd.Parameters.Add("@dk", str);
            return GetTable(cmd);
        }

        #region[TM_HangHoa_GetAllKey]

        public static DataTable TM_HangHoa_GetAllKey()
        {
            cmd = new SqlCommand("sp_TM_HangHoa_GetAllKey", GetConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            return GetTable(cmd);
        }

        #endregion
    }
}