
using System;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;

using DoanhNghiepHoiNhap.Common;
using System.IO;

namespace DoanhNghiepHoiNhap.Admins
{
/// <summary>
/// Created By:
/// Created Date:
/// Edit By:
/// Edit Date:
/// Description:
/// </summary>
public partial class DoanhNghiepQueHuong : Page
{
#region Private Variable

#endregion

#region Events

protected void Page_Load(object sender, EventArgs e)
{
if (!IsPostBack)
{
Loadgrd_showDoanhNghiepQueHuong();
LoadDdlSearch();
Session["folder"]="DoanhNghiepQueHuong";
Insert.Checked=false;
if (!Directory.Exists(Server.MapPath("~/Images/DoanhNghiepQueHuong")))
Directory.CreateDirectory(Server.MapPath("~/Images/DoanhNghiepQueHuong"));
}
}
protected void btnThem_Click(object sender, EventArgs e)
{
pn_showDoanhNghiepQueHuong.Visible = false;
pn_updateDoanhNghiepQueHuong.Visible = true;
Insert.Checked=true;Session["upload"] = "";
fckTen.Value = "";
fckLogo.Value = "";
fckGioiThieu.Value = "";
fckGiamDoc.Value = "";
fckDiaChi.Value = "";
txtDienThoai.Text = "";
fckEmail.Value = "";
txtThuTu.Text = "";
}

protected void btnXoa_Click(object sender, EventArgs e){
try{
DataGridItem item = default(DataGridItem);
for (int i = 0; i < grd_showDoanhNghiepQueHuong.Items.Count; i++){
item = grd_showDoanhNghiepQueHuong.Items[i];
if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item){
if (((CheckBox)item.FindControl("ChkSelect")).Checked){
var lbl = (Label)item.FindControl("lIDbIDl");
var str = lbl.Text.Split(',');try{
DoanhNghiepQueHuongService.DoanhNghiepQueHuong_Delete(str[0]);}catch{}}}}
grd_showDoanhNghiepQueHuong.CurrentPageIndex = 0;
Loadgrd_showDoanhNghiepQueHuong();}catch{}}
protected void LbtCancel_Click(object sender, EventArgs e)
{
pn_showDoanhNghiepQueHuong.Visible = true;
pn_updateDoanhNghiepQueHuong.Visible = false;
lblerrorTen.Text="";
lblerrorLogo.Text="";
lblerrorGioiThieu.Text="";
lblerrorGiamDoc.Text="";
lblerrorDiaChi.Text="";
lblerrorDienThoai.Text="";
lblerrorEmail.Text="";
lblerrorThuTu.Text="";
}
protected void LbtUpdate_Click(object sender, EventArgs e)
{
#region[TestInput]
var kt=true;
var ktP=true;
ktP = KtTen();
if(kt)
kt=ktP;
ktP = KtLogo();
if(kt)
kt=ktP;
ktP = KtGioiThieu();
if(kt)
kt=ktP;
ktP = KtGiamDoc();
if(kt)
kt=ktP;
ktP = KtDiaChi();
if(kt)
kt=ktP;
ktP = KtDienThoai();
if(kt)
kt=ktP;
ktP = KtEmail();
if(kt)
kt=ktP;
ktP = KtThuTu();
if(kt)
kt=ktP;
#endregion
if(Insert.Checked)
{
if(!kt) return;
try
{
DoanhNghiepQueHuongService.DoanhNghiepQueHuong_Insert(  fckTen.Value, fckLogo.Value, fckGioiThieu.Value, fckGiamDoc.Value, fckDiaChi.Value, txtDienThoai.Text, fckEmail.Value, txtThuTu.Text);
}
catch
{
WebMsgBox.Show("Lỗi :");
return;
}
}
else
{
if(!kt) return;
try
{
DoanhNghiepQueHuongService.DoanhNghiepQueHuong_Update(  ViewState["Id"].ToString(), fckTen.Value, fckLogo.Value, fckGioiThieu.Value, fckGiamDoc.Value, fckDiaChi.Value, txtDienThoai.Text, fckEmail.Value, txtThuTu.Text);
}
catch
{
WebMsgBox.Show("Lỗi :");
return;
}
}
Loadgrd_showDoanhNghiepQueHuong();
pn_showDoanhNghiepQueHuong.Visible = true;
pn_updateDoanhNghiepQueHuong.Visible = false;
}
protected void grd_showDoanhNghiepQueHuong_ItemCommand(object source, DataGridCommandEventArgs e)
{
var strViewState = e.CommandArgument.ToString().Split(',');
ViewState["Id"]=strViewState[0];
switch (e.CommandName.Trim())
{case "Edit":
Insert.Checked = false;var dt = DoanhNghiepQueHuongService.DoanhNghiepQueHuong_GetById(  ViewState["Id"].ToString());
if (dt.Rows.Count > 0)
{
fckTen.Value = dt.Rows[0]["Ten"].ToString();
fckLogo.Value = dt.Rows[0]["Logo"].ToString();
fckGioiThieu.Value = dt.Rows[0]["GioiThieu"].ToString();
fckGiamDoc.Value = dt.Rows[0]["GiamDoc"].ToString();
fckDiaChi.Value = dt.Rows[0]["DiaChi"].ToString();
txtDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
fckEmail.Value = dt.Rows[0]["Email"].ToString();
txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
}
dt.Clear();
pn_showDoanhNghiepQueHuong.Visible = false;
pn_updateDoanhNghiepQueHuong.Visible = true;
break;
case "Delete":
DoanhNghiepQueHuongService.DoanhNghiepQueHuong_Delete(  ViewState["Id"].ToString());
Loadgrd_showDoanhNghiepQueHuong();break;
default:
break;
}
}

protected void grd_showDoanhNghiepQueHuong_ItemDataBound(object sender, DataGridItemEventArgs e)
{
ListItemType itemType = e.Item.ItemType; if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
{
if (itemType == ListItemType.Header){
object checkBox = e.Item.FindControl("chkSelectAll"); if ((checkBox != null)){
((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");}}else{
string tableRowId = grd_showDoanhNghiepQueHuong.ClientID + "_row" + e.Item.ItemIndex.ToString();
e.Item.Attributes.Add("id", tableRowId);
object checkBox = e.Item.FindControl("chkSelect");
if ((checkBox != null)){
e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex + ")");
((CheckBox) checkBox).Attributes.Add("onClick","Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex + ")");}}}}
protected void btnShowAllData_Click(object sender, EventArgs e)
{
Loadgrd_showDoanhNghiepQueHuong();
}
#endregion

#region Methods

private void LoadDdlSearch()
{
ddlSColumnDoanhNghiepQueHuong.Items.Add(new ListItem("=","1"));
ddlSColumnDoanhNghiepQueHuong.Items.Add(new ListItem("Like%","2"));
ddlSColumnDoanhNghiepQueHuong.Items.Add(new ListItem("%Like%","3"));
ddlSearchColumn.Items.Add(new ListItem("Id - ","Id*int"));
ddlSearchColumn.Items.Add(new ListItem("Ten - ","Ten*nvarchar"));
ddlSearchColumn.Items.Add(new ListItem("Logo - ","Logo*nvarchar"));
ddlSearchColumn.Items.Add(new ListItem("GioiThieu - ","GioiThieu*ntext"));
ddlSearchColumn.Items.Add(new ListItem("GiamDoc - ","GiamDoc*nvarchar"));
ddlSearchColumn.Items.Add(new ListItem("DiaChi - ","DiaChi*nvarchar"));
ddlSearchColumn.Items.Add(new ListItem("DienThoai - ","DienThoai*nvarchar"));
ddlSearchColumn.Items.Add(new ListItem("Email - ","Email*nvarchar"));
ddlSearchColumn.Items.Add(new ListItem("ThuTu - ","ThuTu*int"));
ddlSearchColumn.DataBind();
ddlSColumnDoanhNghiepQueHuong.DataBind();
}
protected void btnSearchColumn_Click(object sender, EventArgs e)
{
if(txtSDoanhNghiepQueHuong.Text.Trim()=="")return;
grd_showDoanhNghiepQueHuong.DataSource = DoanhNghiepQueHuongService.DoanhNghiepQueHuong_SearchColumn(txtSDoanhNghiepQueHuong.Text.Trim(),ddlSearchColumn.SelectedValue,ddlSColumnDoanhNghiepQueHuong.SelectedValue);
grd_showDoanhNghiepQueHuong.DataBind();

}
private void Loadgrd_showDoanhNghiepQueHuong()
{
grd_showDoanhNghiepQueHuong.DataSource = DoanhNghiepQueHuongService.DoanhNghiepQueHuong_GetAllKey();
grd_showDoanhNghiepQueHuong.DataBind();

}
protected void grd_showDoanhNghiepQueHuong_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
{
grd_showDoanhNghiepQueHuong.CurrentPageIndex = e.NewPageIndex;
Loadgrd_showDoanhNghiepQueHuong();
}
#endregion

#region Validate
private bool KtTen()
{
lblerrorTen.Text="";
return true;
}
private bool KtLogo()
{
if(string.IsNullOrEmpty(fckLogo.Value.Trim()))
{
lblerrorLogo.Text=" không được để trống";
return false;
}
lblerrorLogo.Text="";
return true;
}
private bool KtGioiThieu()
{
lblerrorGioiThieu.Text="";
return true;
}
private bool KtGiamDoc()
{
lblerrorGiamDoc.Text="";
return true;
}
private bool KtDiaChi()
{
lblerrorDiaChi.Text="";
return true;
}
private bool KtDienThoai()
{
lblerrorDienThoai.Text="";
return true;
}
private bool KtEmail()
{
lblerrorEmail.Text="";
return true;
}
private bool KtThuTu()
{
if(!string.IsNullOrEmpty(txtThuTu.Text.Trim()))
try
{
var so=long.Parse(txtThuTu.Text);
}
catch
{
lblerrorThuTu.Text=" là số nguyên";
 return false;
}
lblerrorThuTu.Text="";
 return true;
}
#endregion

}
}