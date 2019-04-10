
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
    public partial class TH_TheLoaiSach : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showTH_TheLoaiSach();
                LoadDdlSearch();
                Session["folder"] = "TH_TheLoaiSach";
                Insert.Checked = false;
                if (!Directory.Exists(Server.MapPath("~/Images/TH_TheLoaiSach")))
                    Directory.CreateDirectory(Server.MapPath("~/Images/TH_TheLoaiSach"));
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTH_TheLoaiSach.Visible = false;
            pn_updateTH_TheLoaiSach.Visible = true;
            Insert.Checked = true; Session["upload"] = "";
            txtTenTheLoaiSach.Text = "";
            txtNote_text.Text = "";
            //txtNote_int.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showTH_TheLoaiSach.Items.Count; i++)
                {
                    item = grd_showTH_TheLoaiSach.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label)item.FindControl("lIDbIDl");
                            var str = lbl.Text.Split(','); try
                            {
                                TH_TheLoaiSachService.TH_TheLoaiSach_Delete(str[0]);
                            }
                            catch { }
                        }
                    }
                }
                grd_showTH_TheLoaiSach.CurrentPageIndex = 0;
                Loadgrd_showTH_TheLoaiSach();
            }
            catch { }
        }
        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTH_TheLoaiSach.Visible = true;
            pn_updateTH_TheLoaiSach.Visible = false;
            lblerrorTenTheLoaiSach.Text = "";
            lblerrorNote_text.Text = "";
            //lblerrorNote_int.Text = "";
        }
        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            var kt = true;
            var ktP = true;
            ktP = KtTenTheLoaiSach();
            if (kt)
                kt = ktP;
            ktP = KtNote_text();
            if (kt)
                kt = ktP;
            ktP = KtNote_int();
            if (kt)
                kt = ktP;
            #endregion
            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TH_TheLoaiSachService.TH_TheLoaiSach_Insert(txtTenTheLoaiSach.Text, txtNote_text.Text, "1");
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
                    TH_TheLoaiSachService.TH_TheLoaiSach_Update(ViewState["Id"].ToString(), txtTenTheLoaiSach.Text, txtNote_text.Text, "1");
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTH_TheLoaiSach();
            pn_showTH_TheLoaiSach.Visible = true;
            pn_updateTH_TheLoaiSach.Visible = false;
        }
        protected void grd_showTH_TheLoaiSach_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            var strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false; var dt = TH_TheLoaiSachService.TH_TheLoaiSach_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTenTheLoaiSach.Text = dt.Rows[0]["TenTheLoaiSach"].ToString();
                        txtNote_text.Text = dt.Rows[0]["Note_text"].ToString();
                        //txtNote_int.Text = dt.Rows[0]["Note_int"].ToString();
                    }
                    dt.Clear();
                    pn_showTH_TheLoaiSach.Visible = false;
                    pn_updateTH_TheLoaiSach.Visible = true;
                    break;
                case "Delete":
                    TH_TheLoaiSachService.TH_TheLoaiSach_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTH_TheLoaiSach(); break;
                default:
                    break;
            }
        }

        protected void grd_showTH_TheLoaiSach_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTH_TheLoaiSach.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
            Loadgrd_showTH_TheLoaiSach();
        }
        #endregion

        #region Methods

        private void LoadDdlSearch()
        {
            ddlSColumnTH_TheLoaiSach.Items.Add(new ListItem("=", "1"));
            ddlSColumnTH_TheLoaiSach.Items.Add(new ListItem("Like%", "2"));
            ddlSColumnTH_TheLoaiSach.Items.Add(new ListItem("%Like%", "3"));
            ddlSearchColumn.Items.Add(new ListItem("Id - ", "Id*int"));
            ddlSearchColumn.Items.Add(new ListItem("TenTheLoaiSach - ", "TenTheLoaiSach*nvarchar"));
            ddlSearchColumn.Items.Add(new ListItem("Note_text - ", "Note_text*nvarchar"));
            ddlSearchColumn.Items.Add(new ListItem("Note_int - ", "Note_int*int"));
            ddlSearchColumn.DataBind();
            ddlSColumnTH_TheLoaiSach.DataBind();
        }
        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTH_TheLoaiSach.Text.Trim() == "") return;
            grd_showTH_TheLoaiSach.DataSource = TH_TheLoaiSachService.TH_TheLoaiSach_SearchColumn(txtSTH_TheLoaiSach.Text.Trim(), ddlSearchColumn.SelectedValue, ddlSColumnTH_TheLoaiSach.SelectedValue);
            grd_showTH_TheLoaiSach.DataBind();

        }
        private void Loadgrd_showTH_TheLoaiSach()
        {
            grd_showTH_TheLoaiSach.DataSource = TH_TheLoaiSachService.TH_TheLoaiSach_GetAllKey();
            grd_showTH_TheLoaiSach.DataBind();

        }
        protected void grd_showTH_TheLoaiSach_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTH_TheLoaiSach.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTH_TheLoaiSach();
        }
        #endregion

        #region Validate
        private bool KtTenTheLoaiSach()
        {
            lblerrorTenTheLoaiSach.Text = "";
            return true;
        }
        private bool KtNote_text()
        {
            lblerrorNote_text.Text = "";
            return true;
        }
        private bool KtNote_int()
        {
            //if (!string.IsNullOrEmpty(txtNote_int.Text.Trim()))
            //    try
            //    {
            //        var so = long.Parse(txtNote_int.Text);
            //    }
            //    catch
            //    {
            //        lblerrorNote_int.Text = " là số nguyên";
            //        return false;
            //    }
            //lblerrorNote_int.Text = "";
            return true;
        }
        #endregion

    }
}