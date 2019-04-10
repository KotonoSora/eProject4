
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
    public partial class TH_LoaiChuong : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showTH_LoaiChuong();
                LoadDdlSearch();
                Session["folder"] = "TH_LoaiChuong";
                Insert.Checked = false;
                if (!Directory.Exists(Server.MapPath("~/Images/TH_LoaiChuong")))
                    Directory.CreateDirectory(Server.MapPath("~/Images/TH_LoaiChuong"));
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTH_LoaiChuong.Visible = false;
            pn_updateTH_LoaiChuong.Visible = true;
            Insert.Checked = true; Session["upload"] = "";
            txtLoaiChuong.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showTH_LoaiChuong.Items.Count; i++)
                {
                    item = grd_showTH_LoaiChuong.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label)item.FindControl("lIDbIDl");
                            var str = lbl.Text.Split(','); try
                            {
                                TH_LoaiChuongService.TH_LoaiChuong_Delete(str[0]);
                            }
                            catch { }
                        }
                    }
                }
                grd_showTH_LoaiChuong.CurrentPageIndex = 0;
                Loadgrd_showTH_LoaiChuong();
            }
            catch { }
        }
        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTH_LoaiChuong.Visible = true;
            pn_updateTH_LoaiChuong.Visible = false;
            lblerrorLoaiChuong.Text = "";
        }
        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            var kt = true;
            var ktP = true;
            ktP = KtLoaiChuong();
            if (kt)
                kt = ktP;
            #endregion
            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TH_LoaiChuongService.TH_LoaiChuong_Insert(txtLoaiChuong.Text);
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
                    TH_LoaiChuongService.TH_LoaiChuong_Update(ViewState["Id"].ToString(), txtLoaiChuong.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTH_LoaiChuong();
            pn_showTH_LoaiChuong.Visible = true;
            pn_updateTH_LoaiChuong.Visible = false;
        }
        protected void grd_showTH_LoaiChuong_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            var strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false; var dt = TH_LoaiChuongService.TH_LoaiChuong_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtLoaiChuong.Text = dt.Rows[0]["LoaiChuong"].ToString();
                    }
                    dt.Clear();
                    pn_showTH_LoaiChuong.Visible = false;
                    pn_updateTH_LoaiChuong.Visible = true;
                    break;
                case "Delete":
                    TH_LoaiChuongService.TH_LoaiChuong_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTH_LoaiChuong(); break;
                default:
                    break;
            }
        }

        protected void grd_showTH_LoaiChuong_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTH_LoaiChuong.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
            Loadgrd_showTH_LoaiChuong();
        }
        #endregion

        #region Methods

        private void LoadDdlSearch()
        {
            ddlSColumnTH_LoaiChuong.Items.Add(new ListItem("=", "1"));
            ddlSColumnTH_LoaiChuong.Items.Add(new ListItem("Like%", "2"));
            ddlSColumnTH_LoaiChuong.Items.Add(new ListItem("%Like%", "3"));
            ddlSearchColumn.Items.Add(new ListItem("Id - ", "Id*int"));
            ddlSearchColumn.Items.Add(new ListItem("LoaiChuong - ", "LoaiChuong*nvarchar"));
            ddlSearchColumn.DataBind();
            ddlSColumnTH_LoaiChuong.DataBind();
        }
        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTH_LoaiChuong.Text.Trim() == "") return;
            grd_showTH_LoaiChuong.DataSource = TH_LoaiChuongService.TH_LoaiChuong_SearchColumn(txtSTH_LoaiChuong.Text.Trim(), ddlSearchColumn.SelectedValue, ddlSColumnTH_LoaiChuong.SelectedValue);
            grd_showTH_LoaiChuong.DataBind();

        }
        private void Loadgrd_showTH_LoaiChuong()
        {
            grd_showTH_LoaiChuong.DataSource = TH_LoaiChuongService.TH_LoaiChuong_GetAllKey();
            grd_showTH_LoaiChuong.DataBind();

        }
        protected void grd_showTH_LoaiChuong_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTH_LoaiChuong.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTH_LoaiChuong();
        }
        #endregion

        #region Validate
        private bool KtLoaiChuong()
        {
            lblerrorLoaiChuong.Text = "";
            return true;
        }
        #endregion

    }
}