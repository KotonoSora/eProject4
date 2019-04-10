using System.Data;
using System.Data.SqlClient;
namespace DoanhNghiepHoiNhap.Data
{

public class HinhAnhQueHuongController : SqlDataProvider
{
	private static SqlCommand cmd;
	public static void HinhAnhQueHuong_Delete(  string Id)
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_Delete", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		ExeCuteNonquery(cmd);
	}
	public static DataTable HinhAnhQueHuong_GetAll()
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_GetAll", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		return GetTable(cmd);
	}
#region[HinhAnhQueHuong_GetAllKey]
	public static DataTable HinhAnhQueHuong_GetAllKey()
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_GetAllKey", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		return GetTable(cmd);
	}
#endregion
	public static DataTable HinhAnhQueHuong_GetById(  string Id)
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_GetById", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		return GetTable(cmd);
	}
	public static void HinhAnhQueHuong_Insert(  string TieuDe, string Mota, string HinhAnh, string ThuTu, string NhomHinhAnh, string NgayTao, string NguoiTao)
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_Insert", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@TieuDe", TieuDe);
		cmd.Parameters.Add("@Mota", Mota);
		cmd.Parameters.Add("@HinhAnh", HinhAnh);
		cmd.Parameters.Add("@ThuTu", ThuTu);
		cmd.Parameters.Add("@NhomHinhAnh", NhomHinhAnh);
		cmd.Parameters.Add("@NgayTao", NgayTao);
		cmd.Parameters.Add("@NguoiTao", NguoiTao);
		ExeCuteNonquery(cmd);
	}
	public static void HinhAnhQueHuong_Update(  string Id, string TieuDe, string Mota, string HinhAnh, string ThuTu, string NhomHinhAnh, string NgayTao, string NguoiTao)
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_Update", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		cmd.Parameters.Add("@TieuDe", TieuDe);
		cmd.Parameters.Add("@Mota", Mota);
		cmd.Parameters.Add("@HinhAnh", HinhAnh);
		cmd.Parameters.Add("@ThuTu", ThuTu);
		cmd.Parameters.Add("@NhomHinhAnh", NhomHinhAnh);
		cmd.Parameters.Add("@NgayTao", NgayTao);
		cmd.Parameters.Add("@NguoiTao", NguoiTao);
		ExeCuteNonquery(cmd);
	}
	public static DataTable HinhAnhQueHuong_GetByTop(string Top, string Where, string Order)
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_GetByTop", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Top", Top);
		cmd.Parameters.Add("@Where", Where);
		cmd.Parameters.Add("@Order", Order);
		return GetTable(cmd);
	}
	public static DataTable HinhAnhQueHuong_SearchColumn(string str,string value,string tk)
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_GetByForeignKey", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
var s="";
var s1=value.Split('*');
switch(s1[1])
{
case "char":
case "nchar":
case "varchar":
case "nvarchar":
case "text":
case "ntext":
switch(tk)
{
case "1":
s = " and [HinhAnhQueHuong].[" + s1[0] + "]=N'" + str + "'";
break;
case "2":
s = " and [HinhAnhQueHuong].[" + s1[0] + "] like N'" + str + "%'";
break;
case "3":
s = " and [HinhAnhQueHuong].[" + s1[0] + "] like N'%" + str + "%'";
break;
}
break;
default:
try{float.Parse(str);}catch{return null;}
s = " and [HinhAnhQueHuong].[" + s1[0] + "]=" + str + "";
break;
}
		cmd.Parameters.Add("@dk", s);
		return GetTable(cmd);
	}
	public static DataTable HinhAnhQueHuong_GetByForeignKey(  string NhomHinhAnh)
	{
		cmd = new SqlCommand("sp_HinhAnhQueHuong_GetByForeignKey", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
var str="";
if(!string.IsNullOrEmpty(NhomHinhAnh))
str+=" and [HinhAnhQueHuong].[NhomHinhAnh]="+NhomHinhAnh+" ";
		cmd.Parameters.Add("@dk", str);
		return GetTable(cmd);
	}
}
}