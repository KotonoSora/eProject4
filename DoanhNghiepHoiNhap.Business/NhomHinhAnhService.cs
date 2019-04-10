using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
public class NhomHinhAnhService
{
	public static void NhomHinhAnh_Insert(  string TenNhom, string HinhAnh, string ThuTu)
	{
 NhomHinhAnhController.NhomHinhAnh_Insert(  TenNhom, HinhAnh, ThuTu);
}
	public static void NhomHinhAnh_Update(  string id, string TenNhom, string HinhAnh, string ThuTu)
	{
 NhomHinhAnhController.NhomHinhAnh_Update(  id, TenNhom, HinhAnh, ThuTu);
}
	public static void NhomHinhAnh_Delete(  string id)
	{
NhomHinhAnhController.NhomHinhAnh_Delete(  id);
	}
	public static DataTable NhomHinhAnh_GetAll()
	{
return NhomHinhAnhController.NhomHinhAnh_GetAll();
}
	public static DataTable NhomHinhAnh_GetAllKey()
	{
return NhomHinhAnhController.NhomHinhAnh_GetAllKey();
}
	public static DataTable NhomHinhAnh_SearchColumn(string Str,string Value,string Tk)
	{
return NhomHinhAnhController.NhomHinhAnh_SearchColumn( Str, Value, Tk);
}
	public static DataTable NhomHinhAnh_GetById(  string id)
	{
return NhomHinhAnhController.NhomHinhAnh_GetById(  id);
	}
	public static DataTable NhomHinhAnh_GetByTop(string Top, string Where, string Order)
	{
return NhomHinhAnhController.NhomHinhAnh_GetByTop(Top, Where, Order);
}
}
}