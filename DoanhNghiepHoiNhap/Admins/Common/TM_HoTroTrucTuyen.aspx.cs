using System;
using System.Data;
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
    public partial class TM_HoTroTrucTuyen : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLang();
                Loadgrd_showTM_HoTroTrucTuyen();
                Insert.Checked = false;
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTM_HoTroTrucTuyen.Visible = false;
            pn_updateTM_HoTroTrucTuyen.Visible = true;
            Insert.Checked = true;
            txtNickname.Text = "";
            txtMoTa.Text = ""; 
            txtThuTu.Text = "";
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTM_HoTroTrucTuyen.Visible = true;
            pn_updateTM_HoTroTrucTuyen.Visible = false;
            lblerrorNickname.Text = "";
            lblerrorMoTa.Text = ""; 
            lblerrorThuTu.Text = "";
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtNickname();
            if (kt)
                kt = ktP;
            ktP = KtMoTa();
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
                    TM_HoTroTrucTuyenService.TM_HoTroTrucTuyen_Insert(txtNickname.Text, txtMoTa.Text, ddlLoai.SelectedValue,txtThuTu.Text);
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
                    TM_HoTroTrucTuyenService.TM_HoTroTrucTuyen_Update(ViewState["Id"].ToString(), txtNickname.Text,txtMoTa.Text, ddlLoai.SelectedValue, txtThuTu.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTM_HoTroTrucTuyen();
            pn_showTM_HoTroTrucTuyen.Visible = true;
            pn_updateTM_HoTroTrucTuyen.Visible = false;
        }

        protected void grd_showTM_HoTroTrucTuyen_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TM_HoTroTrucTuyenService.TM_HoTroTrucTuyen_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtNickname.Text = dt.Rows[0]["Nickname"].ToString();
                        txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                        ddlLoai.SelectedValue= dt.Rows[0]["Loai"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                    }
                    dt.Clear();
                    pn_showTM_HoTroTrucTuyen.Visible = false;
                    pn_updateTM_HoTroTrucTuyen.Visible = true;
                    break;
                case "Delete":
                    TM_HoTroTrucTuyenService.TM_HoTroTrucTuyen_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTM_HoTroTrucTuyen();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTM_HoTroTrucTuyen_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTM_HoTroTrucTuyen.ClientID + "_row" + e.Item.ItemIndex;
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

        #endregion

        #region Methods 

        private void Loadgrd_showTM_HoTroTrucTuyen()
        {
            grd_showTM_HoTroTrucTuyen.DataSource = TM_HoTroTrucTuyenService.TM_HoTroTrucTuyen_GetAllKey();
            grd_showTM_HoTroTrucTuyen.DataBind();
        }

        protected void grd_showTM_HoTroTrucTuyen_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTM_HoTroTrucTuyen.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTM_HoTroTrucTuyen();
        }

        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "1";
            lbtUpdate.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem.Text = Lang.Show("add");
        }

        #endregion

        #region Validate

        private bool KtNickname()
        {
            lblerrorNickname.Text = "";
            return true;
        }

        private bool KtMoTa()
        {
            lblerrorMoTa.Text = "";
            return true;
        } 

        private bool KtThuTu()
        {
            if (!string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                try
                {
                    long so = long.Parse(txtThuTu.Text);
                }
                catch
                {
                    lblerrorThuTu.Text = Lang.Show("isinteger");
                    return false;
                }
            lblerrorThuTu.Text = "";
            return true;
        }

        #endregion
    }
}