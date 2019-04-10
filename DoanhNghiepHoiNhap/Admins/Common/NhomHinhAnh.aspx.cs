
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
    public partial class NhomHinhAnh : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showNhomHinhAnh();
                LoadDdlSearch();
                Session["folder"] = "NhomHinhAnh";
                Insert.Checked = false;
                if (!Directory.Exists(Server.MapPath("~/Images/NhomHinhAnh")))
                    Directory.CreateDirectory(Server.MapPath("~/Images/NhomHinhAnh"));
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showNhomHinhAnh.Visible = false;
            pn_updateNhomHinhAnh.Visible = true;
            Insert.Checked = true; Session["upload"] = "";
            txtTenNhom.Text = "";
            txtImgUrl.Text = "";
            txtThuTu.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showNhomHinhAnh.Items.Count; i++)
                {
                    item = grd_showNhomHinhAnh.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label)item.FindControl("lIDbIDl");
                            var str = lbl.Text.Split(','); try
                            {
                                NhomHinhAnhService.NhomHinhAnh_Delete(str[0]);
                            }
                            catch { }
                        }
                    }
                }
                grd_showNhomHinhAnh.CurrentPageIndex = 0;
                Loadgrd_showNhomHinhAnh();
            }
            catch { }
        }
        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showNhomHinhAnh.Visible = true;
            pn_updateNhomHinhAnh.Visible = false;
            lblerrorTenNhom.Text = "";
            //lblerrorHinhAnh.Text = "";
            //lblerrorThuTu.Text = "";
        }
        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            var kt = true;
            var ktP = true;
            ktP = KtTenNhom();
            //if (kt)
            //    kt = ktP;
            //ktP = KtHinhAnh();
            if (kt)
                kt = ktP;
            ktP = KtThuTu();
            if (kt)
                kt = ktP;
            #endregion
            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    NhomHinhAnhService.NhomHinhAnh_Insert(txtTenNhom.Text, txtImgUrl.Text, txtThuTu.Text);
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
                    NhomHinhAnhService.NhomHinhAnh_Update(ViewState["id"].ToString(), txtTenNhom.Text, txtImgUrl.Text, txtThuTu.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showNhomHinhAnh();
            pn_showNhomHinhAnh.Visible = true;
            pn_updateNhomHinhAnh.Visible = false;
        }
        protected void grd_showNhomHinhAnh_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            var strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false; var dt = NhomHinhAnhService.NhomHinhAnh_GetById(ViewState["id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTenNhom.Text = dt.Rows[0]["TenNhom"].ToString();
                        txtImgUrl.Text = dt.Rows[0]["HinhAnh"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                    }
                    dt.Clear();
                    pn_showNhomHinhAnh.Visible = false;
                    pn_updateNhomHinhAnh.Visible = true;
                    break;
                case "Delete":
                    NhomHinhAnhService.NhomHinhAnh_Delete(ViewState["id"].ToString());
                    Loadgrd_showNhomHinhAnh(); break;
                default:
                    break;
            }
        }

        protected void grd_showNhomHinhAnh_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showNhomHinhAnh.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
            Loadgrd_showNhomHinhAnh();
        }
        #endregion

        #region Methods

        private void LoadDdlSearch()
        {
            //ddlSColumnNhomHinhAnh.Items.Add(new ListItem("=", "1"));
            //ddlSColumnNhomHinhAnh.Items.Add(new ListItem("Like%", "2"));
            //ddlSColumnNhomHinhAnh.Items.Add(new ListItem("%Like%", "3"));
            //ddlSearchColumn.Items.Add(new ListItem("id - ", "id*int"));
            //ddlSearchColumn.Items.Add(new ListItem("TenNhom - ", "TenNhom*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("HinhAnh - ", "HinhAnh*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("ThuTu - ", "ThuTu*int"));
            //ddlSearchColumn.DataBind();
            //ddlSColumnNhomHinhAnh.DataBind();
        }
        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            //if (txtSNhomHinhAnh.Text.Trim() == "") return;
            //grd_showNhomHinhAnh.DataSource = NhomHinhAnhService.NhomHinhAnh_SearchColumn(txtSNhomHinhAnh.Text.Trim(), ddlSearchColumn.SelectedValue, ddlSColumnNhomHinhAnh.SelectedValue);
            //grd_showNhomHinhAnh.DataBind();

        }
        private void Loadgrd_showNhomHinhAnh()
        {
            grd_showNhomHinhAnh.DataSource = NhomHinhAnhService.NhomHinhAnh_GetAllKey();
            grd_showNhomHinhAnh.DataBind();

        }
        protected void grd_showNhomHinhAnh_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showNhomHinhAnh.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showNhomHinhAnh();
        }
        #endregion

        #region Validate
        private bool KtTenNhom()
        {
            lblerrorTenNhom.Text = "";
            return true;
        }
        //private bool KtHinhAnh()
        //{
        //    lblerrorHinhAnh.Text = "";
        //    return true;
        //}
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
        #endregion

    }
}