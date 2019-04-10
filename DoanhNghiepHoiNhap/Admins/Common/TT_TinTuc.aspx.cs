using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Languages;

namespace DoanhNghiepHoiNhap.Admins
{
    /// <summary>
    /// Created By:
    /// Created Date:
    /// Edit By:
    /// Edit Date:
    /// Description:
    /// </summary>
    public partial class TT_TinTuc : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLang();
                Loadgrd_showTT_TinTuc();
                Insert.Checked = false;
                LoadDdlNhomTin();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTT_TinTuc.Visible = false;
            pn_updateTT_TinTuc.Visible = true;
            Insert.Checked = true;
            txtTieuDe.Text = "";
            txtTieuDe2.Text = "";
            txtTomTat.Text = "";
            txtTomTat2.Text = "";
            fckNoiDung.Value = "";
            imgHinhAnh.ImageUrl = "";
            txtDescription.Text = "";
            txtKeyword.Text = "";
            txtImgUrl.Text = "";
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_TinTuc.Visible = true;
            pn_updateTT_TinTuc.Visible = false;
            lblerrorTieuDe.Text = "";
            lblerrorTieuDe2.Text = "";
            lblerrorTomTat.Text = "";
            lblerrorTomTat2.Text = "";
            lblerrorNoiDung.Text = "";
            lblerrorDescription.Text = "";
            lblerrorKeyword.Text = "";
            lblerrorNhomTin.Text = "";
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtTieuDe();
            if (kt)
                kt = ktP;
            ktP = KtTieuDe2();
            if (kt)
                kt = ktP;
            ktP = KtTomTat();
            if (kt)
                kt = ktP;
            ktP = KtTomTat2();
            if (kt)
                kt = ktP;
            ktP = KtNoiDung();
            if (kt)
                kt = ktP;
            ktP = KtDescription();
            if (kt)
                kt = ktP;
            ktP = KtKeyword();
            if (kt)
                kt = ktP;
            ktP = KtNhomTin();
            if (kt)
                kt = ktP;

            #endregion
            if (txtImgUrl.Text.Trim() == "") txtImgUrl.Text = "/Pic/no-image.jpg";
            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TT_TinTucService.TT_TinTuc_Insert(txtTieuDe.Text, txtTieuDe2.Text, txtTomTat.Text, txtTomTat2.Text,
                                                      fckNoiDung.Value, StringClass.NameToTag(txtTieuDe.Text), txtImgUrl.Text,
                                                      Session["Username"].ToString(), txtDescription.Text,
                                                      txtKeyword.Text, ddlTrangThai.SelectedValue, ddlUNhomTin.SelectedValue);
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
                    TT_TinTucService.TT_TinTuc_Update(ViewState["Id"].ToString(), txtTieuDe.Text, txtTieuDe2.Text,
                                                      txtTomTat.Text, txtTomTat2.Text, fckNoiDung.Value, StringClass.NameToTag(txtTieuDe.Text),
                                                      txtImgUrl.Text, txtDescription.Text,
                                                      txtKeyword.Text, ddlTrangThai.SelectedValue, ddlUNhomTin.SelectedValue);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTT_TinTuc();
            pn_showTT_TinTuc.Visible = true;
            pn_updateTT_TinTuc.Visible = false;
        }

        protected void grd_showTT_TinTuc_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TT_TinTucService.TT_TinTuc_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTieuDe.Text = dt.Rows[0]["TieuDe"].ToString();
                        txtTieuDe2.Text = dt.Rows[0]["TieuDe2"].ToString();
                        txtTomTat.Text = dt.Rows[0]["TomTat"].ToString();
                        txtTomTat2.Text = dt.Rows[0]["TomTat2"].ToString();
                        fckNoiDung.Value = dt.Rows[0]["NoiDung"].ToString();
                        imgHinhAnh.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();
                        txtImgUrl.Text = dt.Rows[0]["HinhAnh"].ToString();
                        txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        txtKeyword.Text = dt.Rows[0]["Keyword"].ToString();
                        ddlTrangThai.SelectedValue = dt.Rows[0]["TrangThai"].ToString();
                        ddlUNhomTin.SelectedValue = dt.Rows[0]["NhomTin"].ToString();
                    }
                    dt.Clear();
                    pn_showTT_TinTuc.Visible = false;
                    pn_updateTT_TinTuc.Visible = true;
                    break;
                case "Delete":
                    TT_TinTucService.TT_TinTuc_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTT_TinTuc();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTT_TinTuc_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll");
                    if ((checkBox != null))
                    {
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grd_showTT_TinTuc.ClientID + "_row" + e.Item.ItemIndex;
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut",
                                              "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex + ")");
                        ((CheckBox)checkBox).Attributes.Add("onClick",
                                                             "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex +
                                                             ")");
                    }
                }
            }
        }

        protected void btnShowAllData_Click(object sender, EventArgs e)
        {
            Loadgrd_showTT_TinTuc();
        }

        protected void SearchByForeignKey(object sender, EventArgs e)
        {
            grd_showTT_TinTuc.DataSource = TT_TinTucService.TT_TinTuc_GetByForeignKey(ddlSNhomTin.SelectedValue);

            grd_showTT_TinTuc.DataBind();
        }

        #endregion

        #region Methods

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTT_TinTuc.Text.Trim() == "") return;
            String str = "(";
            DataTable dt = TT_NhomTinService.TT_NhomTin_GetByTop("", "HienThi!=0 and NgonNgu='" + Session["lang"] + "'", "ThuTu");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i < (dt.Rows.Count - 1))
                {
                    str += "(NhomTin =" + dt.Rows[i]["Id"].ToString() + ") or  ";
                }
                else
                {
                    str += "(NhomTin =" + dt.Rows[i]["Id"].ToString() + "))";
                }
            }

            grd_showTT_TinTuc.DataSource = TT_TinTucService.TT_TinTuc_GetByTop("", str + " and (TieuDe like N'%" + txtSTT_TinTuc.Text + "%' or TieuDe2 like N'%" + txtSTT_TinTuc.Text + "%')", "Id desc");
            grd_showTT_TinTuc.DataBind();
        }

        private void Loadgrd_showTT_TinTuc()
        {
            String str = "";
            DataTable dt = TT_NhomTinService.TT_NhomTin_GetByTop("", "HienThi!=0 and NgonNgu='" + Session["lang"] + "'", "ThuTu");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i < (dt.Rows.Count - 1))
                {
                    str += "(NhomTin =" + dt.Rows[i]["Id"].ToString() + ") or  ";
                }
                else
                {
                    str += "(NhomTin =" + dt.Rows[i]["Id"].ToString() + ")";
                }
            }

            grd_showTT_TinTuc.DataSource = TT_TinTucService.TT_TinTuc_GetByTop("", str, "Id DESC");
            grd_showTT_TinTuc.DataBind();
        }

        protected void grd_showTT_TinTuc_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_TinTuc.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTT_TinTuc();
        }

        private void LoadDdlNhomTin()
        {
            // DataTable dt = TT_NhomTinService.TT_NhomTin_GetAll();
            ddlUNhomTin.Items.Clear();
            ddlSNhomTin.Items.Clear();
            ddlUNhomTin.Items.Add(new ListItem("====" + Lang.Show("selectgroupnew") + "====", ""));
            ddlSNhomTin.Items.Add(new ListItem("====" + Lang.Show("selectgroupnew") + "====", ""));


            DataTable dtnhoncha = TT_NhomTinService.TT_NhomTin_GetByTop("", "HienThi!=0 and NgonNgu='" + Session["lang"] + "' and Cha = '-1'", "");
            for (int i = 0; i < dtnhoncha.Rows.Count; i++)
            {
                ddlUNhomTin.Items.Add(new ListItem(dtnhoncha.Rows[i]["Ten"].ToString(), dtnhoncha.Rows[i]["Id"].ToString()));
                ddlSNhomTin.Items.Add(new ListItem(dtnhoncha.Rows[i]["Ten"].ToString(), dtnhoncha.Rows[i]["Id"].ToString()));

                try
                {
                    DataTable dtnhontincon = TT_NhomTinService.TT_NhomTin_GetByTop("", "HienThi!=0 and NgonNgu='" + Session["lang"] + "' and Cha = " + dtnhoncha.Rows[i]["Id"].ToString(), "");
                    if (dtnhontincon.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtnhontincon.Rows.Count; j++)
                        {
                            ddlUNhomTin.Items.Add(new ListItem("------"+dtnhontincon.Rows[j]["Ten"].ToString(), dtnhontincon.Rows[j]["Id"].ToString()));
                            ddlSNhomTin.Items.Add(new ListItem("------"+dtnhontincon.Rows[j]["Ten"].ToString(), dtnhontincon.Rows[j]["Id"].ToString()));
                        }
                    }
                }
                catch (Exception)
                {
                   
                }
                
            }
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ddlUNhomTin.Items.Add(new ListItem(dt.Rows[i]["Ten"].ToString(), dt.Rows[i]["Id"].ToString()));
            //    ddlSNhomTin.Items.Add(new ListItem(dt.Rows[i]["Ten"].ToString(), dt.Rows[i]["Id"].ToString()));
            //}
            ddlSNhomTin.DataBind();
            ddlUNhomTin.DataBind();
        }

        public string GetTrangThai(string t)
        {
            if (t == "0") return "<b style='color:red;'>" + Lang.Show("hide") + "</b>";
            if (t == "2") return Lang.Show("showhot");
            return Lang.Show("show");
        }

        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "vi";
            btnSearchColumn.Text = Lang.Show("search");
            btnShowAllData.Text = Lang.Show("showall");
            lbtUpdate.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem.Text = Lang.Show("add");
            ddlTrangThai.Items.Clear();
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("show"), "1"));
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("showhot"), "2"));
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("hide"), "0"));
        }

        #endregion

        #region Validate

        private bool KtTieuDe()
        {
            lblerrorTieuDe.Text = "";
            return true;
        }

        private bool KtTieuDe2()
        {
            lblerrorTieuDe2.Text = "";
            return true;
        }

        private bool KtTomTat()
        {
            lblerrorTomTat.Text = "";
            return true;
        }

        private bool KtTomTat2()
        {
            lblerrorTomTat2.Text = "";
            return true;
        }

        private bool KtNoiDung()
        {
            lblerrorNoiDung.Text = "";
            return true;
        }

        private bool KtDescription()
        {
            lblerrorDescription.Text = "";
            return true;
        }

        private bool KtKeyword()
        {
            lblerrorKeyword.Text = "";
            return true;
        }


        private bool KtNhomTin()
        {
            if (ddlUNhomTin.SelectedValue == "")
            {
                lblerrorNhomTin.Text = Lang.Show("errorselectgroupnew");
                return false;
            }
            lblerrorNhomTin.Text = "";
            return true;
        }

        #endregion
    }
}