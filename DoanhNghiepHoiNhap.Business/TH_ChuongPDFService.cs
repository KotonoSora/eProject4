using System.Data;
using DoanhNghiepHoiNhap.Data;
namespace DoanhNghiepHoiNhap.Business
{
public class TH_ChuongPDFService
{
    public static void TH_ChuongPDF_Insert(string Id_QuyenSach, string TieuDe, string LinkBDF, string Note_text, string Note_int, string NgayCapNhat)
	{
        TH_ChuongPDFController.TH_ChuongPDF_Insert(Id_QuyenSach, TieuDe, LinkBDF, Note_text, Note_int, NgayCapNhat);
}
    public static void TH_ChuongPDF_Update(string Id, string Id_QuyenSach, string TieuDe, string LinkBDF, string Note_text, string Note_int, string NgayCapNhat)
	{
        TH_ChuongPDFController.TH_ChuongPDF_Update(Id, Id_QuyenSach, TieuDe, LinkBDF, Note_text, Note_int, NgayCapNhat);
}
	public static void TH_ChuongPDF_Delete(  string Id)
	{
TH_ChuongPDFController.TH_ChuongPDF_Delete(  Id);
	}
	public static DataTable TH_ChuongPDF_GetAll()
	{
return TH_ChuongPDFController.TH_ChuongPDF_GetAll();
}
	public static DataTable TH_ChuongPDF_GetAllKey()
	{
return TH_ChuongPDFController.TH_ChuongPDF_GetAllKey();
}
	public static DataTable TH_ChuongPDF_SearchColumn(string Str,string Value,string Tk)
	{
return TH_ChuongPDFController.TH_ChuongPDF_SearchColumn( Str, Value, Tk);
}
	public static DataTable TH_ChuongPDF_GetById(  string Id)
	{
return TH_ChuongPDFController.TH_ChuongPDF_GetById(  Id);
	}
	public static DataTable TH_ChuongPDF_GetByTop(string Top, string Where, string Order)
	{
return TH_ChuongPDFController.TH_ChuongPDF_GetByTop(Top, Where, Order);
}
}
}