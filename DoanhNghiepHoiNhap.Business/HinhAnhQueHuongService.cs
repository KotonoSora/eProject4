using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
public class HinhAnhQueHuongService
{
	public static void HinhAnhQueHuong_Insert(  string TieuDe, string Mota, string HinhAnh, string ThuTu, string NhomHinhAnh, string NgayTao, string NguoiTao)
	{
 HinhAnhQueHuongController.HinhAnhQueHuong_Insert(  TieuDe, Mota, HinhAnh, ThuTu, NhomHinhAnh, NgayTao, NguoiTao);
}
	public static void HinhAnhQueHuong_Update(  string Id, string TieuDe, string Mota, string HinhAnh, string ThuTu, string NhomHinhAnh, string NgayTao, string NguoiTao)
	{
 HinhAnhQueHuongController.HinhAnhQueHuong_Update(  Id, TieuDe, Mota, HinhAnh, ThuTu, NhomHinhAnh, NgayTao, NguoiTao);
}
	public static void HinhAnhQueHuong_Delete(  string Id)
	{
HinhAnhQueHuongController.HinhAnhQueHuong_Delete(  Id);
	}
	public static DataTable HinhAnhQueHuong_GetAll()
	{
return HinhAnhQueHuongController.HinhAnhQueHuong_GetAll();
}
	public static DataTable HinhAnhQueHuong_GetAllKey()
	{
return HinhAnhQueHuongController.HinhAnhQueHuong_GetAllKey();
}
	public static DataTable HinhAnhQueHuong_SearchColumn(string Str,string Value,string Tk)
	{
return HinhAnhQueHuongController.HinhAnhQueHuong_SearchColumn( Str, Value, Tk);
}
	public static DataTable HinhAnhQueHuong_GetById(  string Id)
	{
return HinhAnhQueHuongController.HinhAnhQueHuong_GetById(  Id);
	}
	public static DataTable HinhAnhQueHuong_GetByTop(string Top, string Where, string Order)
	{
return HinhAnhQueHuongController.HinhAnhQueHuong_GetByTop(Top, Where, Order);
}
	public static DataTable HinhAnhQueHuong_GetByForeignKey(  string NhomHinhAnh)
{
return HinhAnhQueHuongController.HinhAnhQueHuong_GetByForeignKey(  NhomHinhAnh);
}
}
}