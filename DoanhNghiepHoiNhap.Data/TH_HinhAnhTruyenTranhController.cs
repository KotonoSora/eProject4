using System.Data;
using System.Data.SqlClient;
namespace DoanhNghiepHoiNhap.Data
{

public class TH_HinhAnhTruyenTranhController : SqlDataProvider
{
	private static SqlCommand cmd;
	public static void TH_HinhAnhTruyenTranh_Delete(  string Id)
	{
		cmd = new SqlCommand("sp_TH_HinhAnhTruyenTranh_Delete", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		ExeCuteNonquery(cmd);
	}
	public static DataTable TH_HinhAnhTruyenTranh_GetAll()
	{
		cmd = new SqlCommand("sp_TH_HinhAnhTruyenTranh_GetAll", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		return GetTable(cmd);
	}
#region[TH_HinhAnhTruyenTranh_GetAllKey]
	public static DataTable TH_HinhAnhTruyenTranh_GetAllKey()
	{
		cmd = new SqlCommand("sp_TH_HinhAnhTruyenTranh_GetAllKey", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		return GetTable(cmd);
	}
#endregion
	public static DataTable TH_HinhAnhTruyenTranh_GetById(  string Id)
	{
		cmd = new SqlCommand("sp_TH_HinhAnhTruyenTranh_GetById", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		return GetTable(cmd);
	}
	public static void TH_HinhAnhTruyenTranh_Insert(  string HinhAnh, string Id_ChuongTruyenTranh)
	{
		cmd = new SqlCommand("sp_TH_HinhAnhTruyenTranh_Insert", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@HinhAnh", HinhAnh);
		cmd.Parameters.Add("@Id_ChuongTruyenTranh", Id_ChuongTruyenTranh);
		ExeCuteNonquery(cmd);
	}
	public static void TH_HinhAnhTruyenTranh_Update(  string Id, string HinhAnh, string Id_ChuongTruyenTranh)
	{
		cmd = new SqlCommand("sp_TH_HinhAnhTruyenTranh_Update", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		cmd.Parameters.Add("@HinhAnh", HinhAnh);
		cmd.Parameters.Add("@Id_ChuongTruyenTranh", Id_ChuongTruyenTranh);
		ExeCuteNonquery(cmd);
	}
	public static DataTable TH_HinhAnhTruyenTranh_GetByTop(string Top, string Where, string Order)
	{
		cmd = new SqlCommand("sp_TH_HinhAnhTruyenTranh_GetByTop", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Top", Top);
		cmd.Parameters.Add("@Where", Where);
		cmd.Parameters.Add("@Order", Order);
		return GetTable(cmd);
	}
	public static DataTable TH_HinhAnhTruyenTranh_SearchColumn(string str,string value,string tk)
	{
		cmd = new SqlCommand("sp_TH_HinhAnhTruyenTranh_GetByForeignKey", GetConnect());
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
s = " and [TH_HinhAnhTruyenTranh].[" + s1[0] + "]=N'" + str + "'";
break;
case "2":
s = " and [TH_HinhAnhTruyenTranh].[" + s1[0] + "] like N'" + str + "%'";
break;
case "3":
s = " and [TH_HinhAnhTruyenTranh].[" + s1[0] + "] like N'%" + str + "%'";
break;
}
break;
default:
try{float.Parse(str);}catch{return null;}
s = " and [TH_HinhAnhTruyenTranh].[" + s1[0] + "]=" + str + "";
break;
}
		cmd.Parameters.Add("@dk", s);
		return GetTable(cmd);
	}
}
}