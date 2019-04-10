using System.Data;
using System.Data.SqlClient;
namespace DoanhNghiepHoiNhap.Data
{

public class NhomHinhAnhController : SqlDataProvider
{
	private static SqlCommand cmd;
	public static void NhomHinhAnh_Delete(  string id)
	{
		cmd = new SqlCommand("sp_NhomHinhAnh_Delete", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@id", id);
		ExeCuteNonquery(cmd);
	}
	public static DataTable NhomHinhAnh_GetAll()
	{
		cmd = new SqlCommand("sp_NhomHinhAnh_GetAll", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		return GetTable(cmd);
	}
#region[NhomHinhAnh_GetAllKey]
	public static DataTable NhomHinhAnh_GetAllKey()
	{
		cmd = new SqlCommand("sp_NhomHinhAnh_GetAllKey", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		return GetTable(cmd);
	}
#endregion
	public static DataTable NhomHinhAnh_GetById(  string id)
	{
		cmd = new SqlCommand("sp_NhomHinhAnh_GetById", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@id", id);
		return GetTable(cmd);
	}
	public static void NhomHinhAnh_Insert(  string TenNhom, string HinhAnh, string ThuTu)
	{
		cmd = new SqlCommand("sp_NhomHinhAnh_Insert", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@TenNhom", TenNhom);
		cmd.Parameters.Add("@HinhAnh", HinhAnh);
		cmd.Parameters.Add("@ThuTu", ThuTu);
		ExeCuteNonquery(cmd);
	}
	public static void NhomHinhAnh_Update(  string id, string TenNhom, string HinhAnh, string ThuTu)
	{
		cmd = new SqlCommand("sp_NhomHinhAnh_Update", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@id", id);
		cmd.Parameters.Add("@TenNhom", TenNhom);
		cmd.Parameters.Add("@HinhAnh", HinhAnh);
		cmd.Parameters.Add("@ThuTu", ThuTu);
		ExeCuteNonquery(cmd);
	}
	public static DataTable NhomHinhAnh_GetByTop(string Top, string Where, string Order)
	{
		cmd = new SqlCommand("sp_NhomHinhAnh_GetByTop", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Top", Top);
		cmd.Parameters.Add("@Where", Where);
		cmd.Parameters.Add("@Order", Order);
		return GetTable(cmd);
	}
	public static DataTable NhomHinhAnh_SearchColumn(string str,string value,string tk)
	{
		cmd = new SqlCommand("sp_NhomHinhAnh_GetByForeignKey", GetConnect());
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
s = " and [NhomHinhAnh].[" + s1[0] + "]=N'" + str + "'";
break;
case "2":
s = " and [NhomHinhAnh].[" + s1[0] + "] like N'" + str + "%'";
break;
case "3":
s = " and [NhomHinhAnh].[" + s1[0] + "] like N'%" + str + "%'";
break;
}
break;
default:
try{float.Parse(str);}catch{return null;}
s = " and [NhomHinhAnh].[" + s1[0] + "]=" + str + "";
break;
}
		cmd.Parameters.Add("@dk", s);
		return GetTable(cmd);
	}
}
}