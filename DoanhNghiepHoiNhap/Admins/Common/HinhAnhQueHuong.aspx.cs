
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
    public partial class HinhAnhQueHuong : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showHinhAnhQueHuong();
                LoadDdlSearch();
                Session["folder"] = "HinhAnhQueHuong";
                Insert.Checked = false;
                if (!Directory.Exists(Server.MapPath("~/Images/HinhAnhQueHuong")))
                    Directory.CreateDirectory(Server.MapPath("~/Images/HinhAnhQueHuong"));
                //LoadDdlNhomHinhAnh();

                //ltrAlbum.Text = NhomHinhAnhService.NhomHinhAnh_GetById(Request.QueryString["id"].ToString()).Rows[0]["TenNhom"].ToString();//TM_HangHoaService.TM_HangHoa_GetById(Request.QueryString["id"]).Rows[0]["TenSP"].ToString();

            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showHinhAnhQueHuong.Visible = false;
            pn_updateHinhAnhQueHuong.Visible = true;
            Insert.Checked = true; Session["upload"] = "";
            txtTieuDe.Text = "";
            txtMota.Text = "";
            txtImgUrl.Text = "";
            txtThuTu.Text = "";
            txtNgayTao.Text = "";
            txtNguoiTao.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showHinhAnhQueHuong.Items.Count; i++)
                {
                    item = grd_showHinhAnhQueHuong.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label)item.FindControl("lIDbIDl");
                            var str = lbl.Text.Split(','); try
                            {
                                HinhAnhQueHuongService.HinhAnhQueHuong_Delete(str[0]);
                            }
                            catch { }
                        }
                    }
                }
                grd_showHinhAnhQueHuong.CurrentPageIndex = 0;
                Loadgrd_showHinhAnhQueHuong();
            }
            catch { }
        }
        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showHinhAnhQueHuong.Visible = true;
            pn_updateHinhAnhQueHuong.Visible = false;
            lblerrorTieuDe.Text = "";
            //lblerrorMota.Text = "";
            //lblerrorHinhAnh.Text = "";
            lblerrorThuTu.Text = "";
            //
            ///lblerrorNgayTao.Text = "";
           // lblerrorNguoiTao.Text = "";
        }
        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            String idnhom = Request.QueryString["id"].ToString();
            #region[TestInput]
            var kt = true;
            var ktP = true;
            ktP = KtTieuDe();
            if (kt)
                kt = ktP;
            ktP = KtMota();
            if (kt)
                kt = ktP;
            ktP = KtHinhAnh();
            if (kt)
                kt = ktP;
            ktP = KtThuTu();
            if (kt)
                kt = ktP;
            ktP = KtNhomHinhAnh();
            if (kt)
                kt = ktP;
            ktP = KtNgayTao();
            if (kt)
                kt = ktP;
            ktP = KtNguoiTao();
            if (kt)
                kt = ktP;
            #endregion
            if (Insert.Checked)
            {
                if (txtNgayTao.Text == "")
                {
                    txtNgayTao.Text = DateTime.Now.ToShortDateString().ToString();
                }
                if (!kt) return;
                try
                {
                    HinhAnhQueHuongService.HinhAnhQueHuong_Insert(txtTieuDe.Text, txtMota.Text, txtImgUrl.Text, txtThuTu.Text,idnhom , DateTimeClass.ConvertDateTime(txtNgayTao.Text, "MM/dd/yyyy"), txtNguoiTao.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            else
            {
                if (!kt) return;
                try
                {
                    HinhAnhQueHuongService.HinhAnhQueHuong_Update(ViewState["Id"].ToString(), txtTieuDe.Text, txtMota.Text, txtImgUrl.Text, txtThuTu.Text, idnhom, DateTimeClass.ConvertDateTime(txtNgayTao.Text, "MM/dd/yyyy"), txtNguoiTao.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showHinhAnhQueHuong();
            pn_showHinhAnhQueHuong.Visible = true;
            pn_updateHinhAnhQueHuong.Visible = false;
        }
        protected void grd_showHinhAnhQueHuong_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            var strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false; var dt = HinhAnhQueHuongService.HinhAnhQueHuong_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTieuDe.Text = dt.Rows[0]["TieuDe"].ToString();
                        txtMota.Text = dt.Rows[0]["Mota"].ToString();
                        txtImgUrl.Text = dt.Rows[0]["HinhAnh"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                        txtNgayTao.Text = dt.Rows[0]["NgayTao"].ToString();
                        txtNguoiTao.Text = dt.Rows[0]["NguoiTao"].ToString();
                    }
                    dt.Clear();
                    pn_showHinhAnhQueHuong.Visible = false;
                    pn_updateHinhAnhQueHuong.Visible = true;
                    break;
                case "Delete":
                    HinhAnhQueHuongService.HinhAnhQueHuong_Delete(ViewState["Id"].ToString());
                    Loadgrd_showHinhAnhQueHuong(); break;
                default:
                    break;
            }
        }

        protected void grd_showHinhAnhQueHuong_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType; if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll"); if ((checkBox != null))
                    {
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grd_showHinhAnhQueHuong.ClientID + "_row" + e.Item.ItemIndex.ToString();
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex + ")");
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex + ")");
                    }
                }
            }
        }
        protected void btnShowAllData_Click(object sender, EventArgs e)
        {
            Loadgrd_showHinhAnhQueHuong();
        }
        protected void SearchByForeignKey(object sender, EventArgs e)
        {
            //grd_showHinhAnhQueHuong.DataSource = HinhAnhQueHuongService.HinhAnhQueHuong_GetByForeignKey(ddlSNhomHinhAnh.SelectedValue);

            //grd_showHinhAnhQueHuong.DataBind();
        }
        #endregion

        #region Methods

        private void LoadDdlSearch()
        {
            //ddlSColumnHinhAnhQueHuong.Items.Add(new ListItem("=", "1"));
            //ddlSColumnHinhAnhQueHuong.Items.Add(new ListItem("Like%", "2"));
            //ddlSColumnHinhAnhQueHuong.Items.Add(new ListItem("%Like%", "3"));
            //ddlSearchColumn.Items.Add(new ListItem("Id - ", "Id*int"));
            //ddlSearchColumn.Items.Add(new ListItem("TieuDe - ", "TieuDe*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("Mota - ", "Mota*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("HinhAnh - ", "HinhAnh*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("ThuTu - ", "ThuTu*int"));
            //ddlSearchColumn.Items.Add(new ListItem("NhomHinhAnh - ", "NhomHinhAnh*int"));
            //ddlSearchColumn.Items.Add(new ListItem("NgayTao - ", "NgayTao*datetime"));
            //ddlSearchColumn.Items.Add(new ListItem("NguoiTao - ", "NguoiTao*nvarchar"));
            //ddlSearchColumn.DataBind();
            //ddlSColumnHinhAnhQueHuong.DataBind();
        }
        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            //if (txtSHinhAnhQueHuong.Text.Trim() == "") return;
            //grd_showHinhAnhQueHuong.DataSource = HinhAnhQueHuongService.HinhAnhQueHuong_SearchColumn(txtSHinhAnhQueHuong.Text.Trim(), ddlSearchColumn.SelectedValue, ddlSColumnHinhAnhQueHuong.SelectedValue);
            //grd_showHinhAnhQueHuong.DataBind();

        }
        private void Loadgrd_showHinhAnhQueHuong()
        {
            try
            {
                string idnhom = Request.QueryString["id"].ToString();
                grd_showHinhAnhQueHuong.DataSource = HinhAnhQueHuongService.HinhAnhQueHuong_GetByTop("","NhomHinhAnh = " + idnhom,"");
                grd_showHinhAnhQueHuong.DataBind();
            }
            catch (Exception)
            {}

        }
        protected void grd_showHinhAnhQueHuong_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showHinhAnhQueHuong.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showHinhAnhQueHuong();
        }
        private void LoadDdlNhomHinhAnh()
        {
            //var dt = NhomHinhAnhService.NhomHinhAnh_GetAll();
            //ddlUNhomHinhAnh.Items.Clear();
            //ddlSNhomHinhAnh.Items.Clear();
            //ddlUNhomHinhAnh.Items.Add(new ListItem("====Chọn ====", ""));
            //ddlSNhomHinhAnh.Items.Add(new ListItem("====Chọn ====", ""));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ddlUNhomHinhAnh.Items.Add(new ListItem(dt.Rows[i]["id"].ToString(), dt.Rows[i]["id"].ToString()));
            //    ddlSNhomHinhAnh.Items.Add(new ListItem(dt.Rows[i]["id"].ToString(), dt.Rows[i]["id"].ToString()));
            //}
            //ddlSNhomHinhAnh.DataBind();
            //ddlUNhomHinhAnh.DataBind(); dt.Clear();
        }
        #endregion

        #region Validate
        private bool KtTieuDe()
        {
            lblerrorTieuDe.Text = "";
            return true;
        }
        private bool KtMota()
        {
            //lblerrorMota.Text = "";
            return true;
        }
        private bool KtHinhAnh()
        {
            //lblerrorHinhAnh.Text = "";
            return true;
        }
        private bool KtThuTu()
        {
            if (!string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                try
                {
                    var so = long.Parse(txtThuTu.Text);
                }
                catch
                {
                    lblerrorThuTu.Text = " là số nguyên";
                    return false;
                }
            lblerrorThuTu.Text = "";
            return true;
        }
        private bool KtNhomHinhAnh()
        {
            //if (ddlUNhomHinhAnh.SelectedValue == "")
            //{
            //    lblerrorNhomHinhAnh.Text = "Bạn phải chọn ";
            //    return false;
            //}
            //lblerrorNhomHinhAnh.Text = "";
            return true;
        }
        private bool KtNgayTao()
        {
            //lblerrorNgayTao.Text == "")
            //{
            //    lblerrorNgayTao.Text = DateTime.Now.ToShortDateString().ToString();
            //}
            return true;
        }
        private bool KtNguoiTao()
        {
            //lblerrorNguoiTao.Text = "";
            return true;
        }
        #endregion

    }
}