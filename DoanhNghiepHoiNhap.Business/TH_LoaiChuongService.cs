using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
public class TH_LoaiChuongService
{
	public static void TH_LoaiChuong_Insert(  string LoaiChuong)
	{
 TH_LoaiChuongController.TH_LoaiChuong_Insert(  LoaiChuong);
}
	public static void TH_LoaiChuong_Update(  string Id, string LoaiChuong)
	{
 TH_LoaiChuongController.TH_LoaiChuong_Update(  Id, LoaiChuong);
}
	public static void TH_LoaiChuong_Delete(  string Id)
	{
TH_LoaiChuongController.TH_LoaiChuong_Delete(  Id);
	}
	public static DataTable TH_LoaiChuong_GetAll()
	{
return TH_LoaiChuongController.TH_LoaiChuong_GetAll();
}
	public static DataTable TH_LoaiChuong_GetAllKey()
	{
return TH_LoaiChuongController.TH_LoaiChuong_GetAllKey();
}
	public static DataTable TH_LoaiChuong_SearchColumn(string Str,string Value,string Tk)
	{
return TH_LoaiChuongController.TH_LoaiChuong_SearchColumn( Str, Value, Tk);
}
	public static DataTable TH_LoaiChuong_GetById(  string Id)
	{
return TH_LoaiChuongController.TH_LoaiChuong_GetById(  Id);
	}
	public static DataTable TH_LoaiChuong_GetByTop(string Top, string Where, string Order)
	{
return TH_LoaiChuongController.TH_LoaiChuong_GetByTop(Top, Where, Order);
}
}
}