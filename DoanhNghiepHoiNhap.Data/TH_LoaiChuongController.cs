using System.Data;
using System.Data.SqlClient;
namespace DoanhNghiepHoiNhap.Data
{

public class TH_LoaiChuongController : SqlDataProvider
{
	private static SqlCommand cmd;
	public static void TH_LoaiChuong_Delete(  string Id)
	{
		cmd = new SqlCommand("sp_TH_LoaiChuong_Delete", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		ExeCuteNonquery(cmd);
	}
	public static DataTable TH_LoaiChuong_GetAll()
	{
		cmd = new SqlCommand("sp_TH_LoaiChuong_GetAll", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		return GetTable(cmd);
	}
#region[TH_LoaiChuong_GetAllKey]
	public static DataTable TH_LoaiChuong_GetAllKey()
	{
		cmd = new SqlCommand("sp_TH_LoaiChuong_GetAllKey", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		return GetTable(cmd);
	}
#endregion
	public static DataTable TH_LoaiChuong_GetById(  string Id)
	{
		cmd = new SqlCommand("sp_TH_LoaiChuong_GetById", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		return GetTable(cmd);
	}
	public static void TH_LoaiChuong_Insert(  string LoaiChuong)
	{
		cmd = new SqlCommand("sp_TH_LoaiChuong_Insert", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@LoaiChuong", LoaiChuong);
		ExeCuteNonquery(cmd);
	}
	public static void TH_LoaiChuong_Update(  string Id, string LoaiChuong)
	{
		cmd = new SqlCommand("sp_TH_LoaiChuong_Update", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Id", Id);
		cmd.Parameters.Add("@LoaiChuong", LoaiChuong);
		ExeCuteNonquery(cmd);
	}
	public static DataTable TH_LoaiChuong_GetByTop(string Top, string Where, string Order)
	{
		cmd = new SqlCommand("sp_TH_LoaiChuong_GetByTop", GetConnect());
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@Top", Top);
		cmd.Parameters.Add("@Where", Where);
		cmd.Parameters.Add("@Order", Order);
		return GetTable(cmd);
	}
	public static DataTable TH_LoaiChuong_SearchColumn(string str,string value,string tk)
	{
		cmd = new SqlCommand("sp_TH_LoaiChuong_GetByForeignKey", GetConnect());
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
s = " and [TH_LoaiChuong].[" + s1[0] + "]=N'" + str + "'";
break;
case "2":
s = " and [TH_LoaiChuong].[" + s1[0] + "] like N'" + str + "%'";
break;
case "3":
s = " and [TH_LoaiChuong].[" + s1[0] + "] like N'%" + str + "%'";
break;
}
break;
default:
try{float.Parse(str);}catch{return null;}
s = " and [TH_LoaiChuong].[" + s1[0] + "]=" + str + "";
break;
}
		cmd.Parameters.Add("@dk", s);
		return GetTable(cmd);
	}
}
}