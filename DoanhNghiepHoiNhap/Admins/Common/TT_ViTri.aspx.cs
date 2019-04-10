using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class TT_ViTri : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showTT_ViTri();
                Insert.Checked = false;
            }
        }

        private void Loadgrd_showTT_ViTri()
        {
            grd_showTT_ViTri.DataSource = TT_ViTriService.TT_ViTri_GetAllKey();
            grd_showTT_ViTri.DataBind();
        }

        protected void grd_showTT_ViTri_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_ViTri.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTT_ViTri();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTT_ViTri.Visible = false;
            pn_updateTT_ViTri.Visible = true;
            Insert.Checked = true;
            txtTenViTri.Text = "";
            txtMoTa.Text = "";
            txtGia.Text = "";
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_ViTri.Visible = true;
            pn_updateTT_ViTri.Visible = false;
            lblerrorTenViTri.Text = "";
            lblerrorMoTa.Text = "";
            lblerrorGia.Text = "";
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtTenViTri();
            if (kt)
                kt = ktP;
            ktP = KtGia();
            if (kt)
                kt = ktP;

            #endregion

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TT_ViTriService.TT_ViTri_Insert(txtTenViTri.Text, txtMoTa.Text, txtGia.Text);
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
                    TT_ViTriService.TT_ViTri_Update(ViewState["ID"].ToString(), txtTenViTri.Text, txtMoTa.Text,
                                                    txtGia.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTT_ViTri();
            pn_showTT_ViTri.Visible = true;
            pn_updateTT_ViTri.Visible = false;
        }

        protected void grd_showTT_ViTri_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["ID"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TT_ViTriService.TT_ViTri_GetById(ViewState["ID"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTenViTri.Text = dt.Rows[0]["TenViTri"].ToString();
                        txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                        txtGia.Text = dt.Rows[0]["Gia"].ToString();
                    }
                    dt.Clear();
                    pn_showTT_ViTri.Visible = false;
                    pn_updateTT_ViTri.Visible = true;
                    break;
                case "Delete":
                    TT_ViTriService.TT_ViTri_Delete(ViewState["ID"].ToString());
                    Loadgrd_showTT_ViTri();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTT_ViTri_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll");
                    if ((checkBox != null))
                    {
                        ((CheckBox) checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grd_showTT_ViTri.ClientID + "_row" + e.Item.ItemIndex;
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut",
                                              "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex + ")");
                        ((CheckBox) checkBox).Attributes.Add("onClick",
                                                             "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex +
                                                             ")");
                    }
                }
            }
        }

        #region[Function Test]

        private bool KtTenViTri()
        {
            if (string.IsNullOrEmpty(txtTenViTri.Text.Trim()))
            {
                lblerrorTenViTri.Text = "Tên vị trí không được để trống";
                return false;
            }
            lblerrorTenViTri.Text = "";
            return true;
        }

        private bool KtGia()
        {
            if (string.IsNullOrEmpty(txtGia.Text.Trim()))
            {
                lblerrorGia.Text = "Giá tiền quảng cáo không được để trống";
                return false;
            }
            try
            {
                float so = float.Parse(txtGia.Text);
            }
            catch
            {
                lblerrorGia.Text = "Giá tiền quảng cáo là số thực";
                return false;
            }
            lblerrorGia.Text = "";
            return true;
        }

        #endregion
    }
}