using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Business;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class TT_ChucNang : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showTT_ChucNang();
                Insert.Checked = false;
            }
        }

        private void Loadgrd_showTT_ChucNang()
        {
            grd_showTT_ChucNang.DataSource = TT_ChucNangService.TT_ChucNang_GetAll();

            grd_showTT_ChucNang.DataBind();
        }

        protected void grd_showTT_ChucNang_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_ChucNang.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTT_ChucNang();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        { 
            pn_showTT_ChucNang.Visible = false;
            pn_updateTT_ChucNang.Visible = true;
            Insert.Checked = true;
            txtTenChucNang.Text = "";
            txtMoTa.Text = ""; 
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        { 
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showTT_ChucNang.Items.Count; i++)
                {
                    item = grd_showTT_ChucNang.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox) item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label) item.FindControl("lIDbIDl");
                            string[] str = lbl.Text.Split(',');
                            try
                            {
                                TT_ChucNangService.TT_ChucNang_Delete(str[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                grd_showTT_ChucNang.CurrentPageIndex = 0;
                Loadgrd_showTT_ChucNang();
            }
            catch
            {
            }
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_ChucNang.Visible = true;
            pn_updateTT_ChucNang.Visible = false;
            lblerrorTenChucNang.Text = "";
            lblerrorMoTa.Text = ""; 
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtTenChucNang();
            if (kt)
                kt = ktP;

            #endregion

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TT_ChucNangService.TT_ChucNang_Insert(txtTenChucNang.Text, txtMoTa.Text, txtThuTu.Text);
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
                    TT_ChucNangService.TT_ChucNang_Update(ViewState["ID"].ToString(), txtTenChucNang.Text, txtMoTa.Text,txtThuTu.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            } 
            Loadgrd_showTT_ChucNang();
            pn_showTT_ChucNang.Visible = true;
            pn_updateTT_ChucNang.Visible = false;
        }

        protected void grd_showTT_ChucNang_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["ID"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TT_ChucNangService.TT_ChucNang_GetById(ViewState["ID"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTenChucNang.Text = dt.Rows[0]["TenChucNang"].ToString();
                        txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                    }
                    dt.Clear();
                    pn_showTT_ChucNang.Visible = false;
                    pn_updateTT_ChucNang.Visible = true;
                    break;
                case "Delete": 
                    TT_ChucNangService.TT_ChucNang_Delete(ViewState["ID"].ToString());
                    Loadgrd_showTT_ChucNang();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTT_ChucNang_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTT_ChucNang.ClientID + "_row" + e.Item.ItemIndex;
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

        private bool KtTenChucNang()
        {
            if (string.IsNullOrEmpty(txtTenChucNang.Text.Trim()))
            {
                lblerrorTenChucNang.Text = "Tên chức năng không được để trống";
                return false;
            }
            lblerrorTenChucNang.Text = "";
            return true;
        } 

        #endregion
    }
}