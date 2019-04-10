using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class TT_NhomNguoiDung : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showTT_NhomNguoiDung();
                LoadDdlSearch(); 
                Insert.Checked = false; 
            }
        }

        private void Loadgrd_showTT_NhomNguoiDung()
        {
            grd_showTT_NhomNguoiDung.DataSource = TT_NhomNguoiDungService.TT_NhomNguoiDung_GetAllKey();
            grd_showTT_NhomNguoiDung.DataBind();
        }

        protected void grd_showTT_NhomNguoiDung_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_NhomNguoiDung.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTT_NhomNguoiDung();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        { 
            pn_showTT_NhomNguoiDung.Visible = false;
            pn_updateTT_NhomNguoiDung.Visible = true;
            Insert.Checked = true;
            Session["upload"] = "";
            txtTenNhom.Text = "";
            txtMoTa.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        { 
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showTT_NhomNguoiDung.Items.Count; i++)
                {
                    item = grd_showTT_NhomNguoiDung.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox) item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label) item.FindControl("lIDbIDl");
                            string[] str = lbl.Text.Split(',');
                            try
                            {
                                TT_NhomNguoiDungService.TT_NhomNguoiDung_Delete(str[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                grd_showTT_NhomNguoiDung.CurrentPageIndex = 0;
                Loadgrd_showTT_NhomNguoiDung();
            }
            catch
            {
            }
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_NhomNguoiDung.Visible = true;
            pn_updateTT_NhomNguoiDung.Visible = false;
            lblerrorTenNhom.Text = "";
            lblerrorMoTa.Text = "";
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = KtTenNhom();

            #endregion

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TT_NhomNguoiDungService.TT_NhomNguoiDung_Insert(txtTenNhom.Text, txtMoTa.Text);
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
                    TT_NhomNguoiDungService.TT_NhomNguoiDung_Update(ViewState["ID"].ToString(), txtTenNhom.Text,
                                                                    txtMoTa.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTT_NhomNguoiDung();
            pn_showTT_NhomNguoiDung.Visible = true;
            pn_updateTT_NhomNguoiDung.Visible = false;
        }

        protected void grd_showTT_NhomNguoiDung_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["ID"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    //if (!Permition.CheckPermition(Session["pageid"].ToString(), Session["Role"].ToString(), "2"))
                    //{
                    //    WebMsgBox.Show("Bạn không đủ quyền!");
                    //    return;
                    //}
                    Insert.Checked = false;
                    DataTable dt = TT_NhomNguoiDungService.TT_NhomNguoiDung_GetById(ViewState["ID"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTenNhom.Text = dt.Rows[0]["TenNhom"].ToString();
                        txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                    }
                    dt.Clear();
                    pn_showTT_NhomNguoiDung.Visible = false;
                    pn_updateTT_NhomNguoiDung.Visible = true;
                    break;
                case "Delete":
                    try
                    {
                        TT_NhomNguoiDungService.TT_NhomNguoiDung_Delete(ViewState["ID"].ToString());
                        Loadgrd_showTT_NhomNguoiDung();
                    }
                    catch (Exception)
                    {
                        WebMsgBox.Show("Không thể xóa nhóm này!");
                    }
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTT_NhomNguoiDung_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTT_NhomNguoiDung.ClientID + "_row" + e.Item.ItemIndex;
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

        private void LoadDdlSearch()
        {
            ddlSColumnTT_NhomNguoiDung.Items.Add(new ListItem("=", "1"));
            ddlSColumnTT_NhomNguoiDung.Items.Add(new ListItem("Like%", "2"));
            ddlSColumnTT_NhomNguoiDung.Items.Add(new ListItem("%Like%", "3"));
            ddlSearchColumn.Items.Add(new ListItem("Tên nhóm", "TenNhom*nvarchar"));
            ddlSearchColumn.Items.Add(new ListItem("Mô tả", "MoTa*nvarchar"));
            ddlSearchColumn.DataBind();
            ddlSColumnTT_NhomNguoiDung.DataBind();
        }

        protected void btnShowAllData_Click(object sender, EventArgs e)
        {
            Loadgrd_showTT_NhomNguoiDung();
        }

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTT_NhomNguoiDung.Text.Trim() == "") return;
            grd_showTT_NhomNguoiDung.DataSource =
                TT_NhomNguoiDungService.TT_NhomNguoiDung_SearchColumn(txtSTT_NhomNguoiDung.Text.Trim(),
                                                                      ddlSearchColumn.SelectedValue,
                                                                      ddlSColumnTT_NhomNguoiDung.SelectedValue);
            grd_showTT_NhomNguoiDung.DataBind();
        }

        #region[Function Test]

        private bool KtTenNhom()
        {
            if (string.IsNullOrEmpty(txtTenNhom.Text.Trim()))
            {
                lblerrorTenNhom.Text = "Tên nhóm không được để trống";
                return false;
            }
            lblerrorTenNhom.Text = "";
            return true;
        }

        #endregion
    }
}