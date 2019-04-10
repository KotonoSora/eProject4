using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Languages;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class TT_QuangCao : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLang();
                LoadgrdShowTtQuangCao();
                Insert.Checked = false;
                LoadDdlViTri(); 
            }
        }

        public string ReturnTrangThai(string s)
        {
            return s == "1" ? Lang.Show("show") : Lang.Show("hide");
        }

        private void LoadgrdShowTtQuangCao()
        {
            if (ddlSViTri.SelectedIndex == 0)
            {
                grd_showTT_QuangCao.DataSource = TT_QuangCaoService.TT_QuangCao_GetAllKey();
                grd_showTT_QuangCao.DataBind();
            }
            else
            {
                grd_showTT_QuangCao.DataSource = TT_QuangCaoService.TT_QuangCao_GetByForeignKey(ddlSViTri.SelectedValue);
                grd_showTT_QuangCao.DataBind();
            }

            for (int i = 0; i < grd_showTT_QuangCao.Items.Count; i++)
            {
                Label lblThuTu = (Label)grd_showTT_QuangCao.Items[i].FindControl("lblThuTu");
                lblThuTu.Text = (i + 1).ToString();
            } 
        }

        protected void btnCapNhatThuTu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grd_showTT_QuangCao.Items.Count; i++)
            {
                var lb = (Label)grd_showTT_QuangCao.Items[i].FindControl("lIDbIDl");
                var tb = (TextBox)grd_showTT_QuangCao.Items[i].FindControl("txtThuTu");
                CommonService.UpdateValue("TT_QuangCao", "ThuTu=" + tb.Text, "Id=" + lb.Text);
            }
            WebMsgBox.Show(Lang.Show("updatesuccess"));
        } 

        protected void grd_showTT_QuangCao_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_QuangCao.CurrentPageIndex = e.NewPageIndex;
            LoadgrdShowTtQuangCao();
        }

        private void LoadDdlViTri()
        {
            DataTable dt = TT_ViTriService.TT_ViTri_GetAll();
            ddlUViTri.Items.Clear();
            ddlSViTri.Items.Clear();
            ddlSViTri.Items.Add(new ListItem("---" + Lang.Show("selectposition") + "---", ""));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlUViTri.Items.Add(new ListItem(dt.Rows[i]["TenViTri"].ToString(), dt.Rows[i]["ID"].ToString()));
                ddlSViTri.Items.Add(new ListItem(dt.Rows[i]["TenViTri"].ToString(), dt.Rows[i]["ID"].ToString()));
            }
            ddlSViTri.DataBind();
            ddlUViTri.DataBind();
            dt.Clear();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        { 
            pn_showTT_QuangCao.Visible = false;
            pn_updateTT_QuangCao.Visible = true;
            Insert.Checked = true;
            txtTenQuangCao.Text = "";
            txtMoTa.Text = "";
            imgHinhAnh.ImageUrl = "";
            txtLink.Text = "";
            txtThuTu.Text = "";
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_QuangCao.Visible = true;
            pn_updateTT_QuangCao.Visible = false;
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            if (Insert.Checked)
            {
                try
                {
                    TT_QuangCaoService.TT_QuangCao_Insert(txtTenQuangCao.Text, txtImgUrl.Text, txtLink.Text, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(),
                                                          ddlUViTri.SelectedValue, txtMoTa.Text, "", "", txtThuTu.Text, ddlTrangThai.SelectedValue);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            else
            {
                try
                {
                    TT_QuangCaoService.TT_QuangCao_Update(ViewState["ID"].ToString(), txtTenQuangCao.Text,txtImgUrl.Text, txtLink.Text,
                                                          DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(),
                                                          ddlUViTri.SelectedValue, txtMoTa.Text, "", "", txtThuTu.Text, ddlTrangThai.SelectedValue);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            LoadgrdShowTtQuangCao();
            pn_showTT_QuangCao.Visible = true;
            pn_updateTT_QuangCao.Visible = false;
        } 

        protected void grd_showTT_QuangCao_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["ID"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit": 
                    Insert.Checked = false;
                    DataTable dt = TT_QuangCaoService.TT_QuangCao_GetById(ViewState["ID"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTenQuangCao.Text = dt.Rows[0]["TenQuangCao"].ToString();
                        imgHinhAnh.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();
                        txtImgUrl.Text = dt.Rows[0]["HinhAnh"].ToString();
                        txtLink.Text = dt.Rows[0]["Link"].ToString();
                        ddlUViTri.SelectedValue = dt.Rows[0]["ViTri"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                        ddlTrangThai.SelectedValue = dt.Rows[0]["TrangThai"].ToString();
                        txtMoTa.Text = dt.Rows[0]["Mail"].ToString(); 
                    }
                    dt.Clear();
                    pn_showTT_QuangCao.Visible = false;
                    pn_updateTT_QuangCao.Visible = true;
                    break;
                case "Delete": 
                    TT_QuangCaoService.TT_QuangCao_Delete(ViewState["ID"].ToString());
                    LoadgrdShowTtQuangCao();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTT_QuangCao_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTT_QuangCao.ClientID + "_row" + e.Item.ItemIndex;
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

        protected void btnShowAllData_Click(object sender, EventArgs e)
        {
            LoadgrdShowTtQuangCao();
        }

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTT_QuangCao.Text.Trim() == "") return;
            grd_showTT_QuangCao.CurrentPageIndex = 0;
            grd_showTT_QuangCao.DataSource = TT_QuangCaoService.TT_QuangCao_GetByTop("", "TenQuangCao like N'%"+txtSTT_QuangCao.Text+"%'", "");
            grd_showTT_QuangCao.DataBind();
            for (int i = 0; i < grd_showTT_QuangCao.Items.Count; i++)
            {
                Label lblThuTu = (Label)grd_showTT_QuangCao.Items[i].FindControl("lblThuTu");
                lblThuTu.Text = (i + 1).ToString();
            } 
        }

        protected void SearchByForeignKey(object sender, EventArgs e)
        {
            grd_showTT_QuangCao.DataSource = TT_QuangCaoService.TT_QuangCao_GetByForeignKey(ddlSViTri.SelectedValue);
            grd_showTT_QuangCao.DataBind();
            for (int i = 0; i < grd_showTT_QuangCao.Items.Count; i++)
            {
                Label lblThuTu = (Label)grd_showTT_QuangCao.Items[i].FindControl("lblThuTu");
                lblThuTu.Text = (i + 1).ToString();
            } 
        }

        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "vi";
            btnSearchColumn.Text = Lang.Show("search");
            lbtUpdate.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem.Text = Lang.Show("add");
            btnShowAllData.Text = Lang.Show("showall");
            btnCapNhatThuTu.Text = Lang.Show("updateord");
            ddlTrangThai.Items.Clear();
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("show"), "1"));
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("hide"), "0"));
        }
    }
}