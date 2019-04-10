using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
public class TH_HinhAnhTruyenTranhService
{
	public static void TH_HinhAnhTruyenTranh_Insert(  string HinhAnh, string Id_ChuongTruyenTranh)
	{
 TH_HinhAnhTruyenTranhController.TH_HinhAnhTruyenTranh_Insert(  HinhAnh, Id_ChuongTruyenTranh);
}
	public static void TH_HinhAnhTruyenTranh_Update(  string Id, string HinhAnh, string Id_ChuongTruyenTranh)
	{
 TH_HinhAnhTruyenTranhController.TH_HinhAnhTruyenTranh_Update(  Id, HinhAnh, Id_ChuongTruyenTranh);
}
	public static void TH_HinhAnhTruyenTranh_Delete(  string Id)
	{
TH_HinhAnhTruyenTranhController.TH_HinhAnhTruyenTranh_Delete(  Id);
	}
	public static DataTable TH_HinhAnhTruyenTranh_GetAll()
	{
return TH_HinhAnhTruyenTranhController.TH_HinhAnhTruyenTranh_GetAll();
}
	public static DataTable TH_HinhAnhTruyenTranh_GetAllKey()
	{
return TH_HinhAnhTruyenTranhController.TH_HinhAnhTruyenTranh_GetAllKey();
}
	public static DataTable TH_HinhAnhTruyenTranh_SearchColumn(string Str,string Value,string Tk)
	{
return TH_HinhAnhTruyenTranhController.TH_HinhAnhTruyenTranh_SearchColumn( Str, Value, Tk);
}
	public static DataTable TH_HinhAnhTruyenTranh_GetById(  string Id)
	{
return TH_HinhAnhTruyenTranhController.TH_HinhAnhTruyenTranh_GetById(  Id);
	}
	public static DataTable TH_HinhAnhTruyenTranh_GetByTop(string Top, string Where, string Order)
	{
return TH_HinhAnhTruyenTranhController.TH_HinhAnhTruyenTranh_GetByTop(Top, Where, Order);
}
}
}