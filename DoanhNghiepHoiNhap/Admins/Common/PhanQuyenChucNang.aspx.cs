using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class PhanQuyenChucNang : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            LoadLang();
            Loadgrd_showTT_ChucNang();
        }

        #region ChucNang

        private void Loadgrd_showTT_ChucNang()
        {
            grd_showTT_ChucNang.DataSource = TT_ChucNangService.TT_ChucNang_GetByTop("50", "", "ThuTu");
            grd_showTT_ChucNang.DataBind();
            for (int i = 0; i < grd_showTT_ChucNang.Items.Count; i++)
            {
                Label lblThuTu = (Label)grd_showTT_ChucNang.Items[i].FindControl("lblThuTu");
                lblThuTu.Text = (i + 1).ToString();
            }
        }

        protected void grd_showTT_ChucNang_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            try
            {
                grd_showTT_ChucNang.CurrentPageIndex = e.NewPageIndex;
                Loadgrd_showTT_ChucNang();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grd_showTT_ChucNang_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string chucnangId = e.CommandArgument.ToString();
                ViewState["chucnangId"] = chucnangId;
                switch (e.CommandName.Trim())
                {
                    case "phanquyen":
                        Loadgrd_showTT_NhomNguoiDung(chucnangId);
                        panelNhomNguoiDung.Visible = true;
                        pn_showTT_ChucNang.Visible = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region NhomNguoiDung

        private void Loadgrd_showTT_NhomNguoiDung(string chucnang)
        {
            try
            {
                grd_showTT_NhomNguoiDung.DataSource = TT_NhomNguoiDungService.TT_NhomNguoiDung_GetAllKey();
                grd_showTT_NhomNguoiDung.DataBind();
                for (int i = 0; i < grd_showTT_NhomNguoiDung.Items.Count; i++)
                {
                    DataTable dt = TT_PhanQuyenService.TT_PhanQuyen_GetByTop("1",
                                                                             "Nhom_Id=" +
                                                                             grd_showTT_NhomNguoiDung.Items[i].Cells[1].
                                                                                 Text + " and ChucNang_Id=" + chucnang +
                                                                             "", "");
                    if (dt.Rows.Count == 1)
                    {
                        var cb = (CheckBox)grd_showTT_NhomNguoiDung.Items[i].FindControl("chkSelect0");
                        cb.Checked = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grd_showTT_NhomNguoiDung_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            try
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
                        string tableRowId = grd_showTT_NhomNguoiDung.ClientID + "_row" + e.Item.ItemIndex;
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
            catch (Exception)
            {
                throw;
            }
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                TT_PhanQuyenService.TT_PhanQuyen_Delete(ViewState["chucnangId"].ToString());
                for (int i = 0; i < grd_showTT_NhomNguoiDung.Items.Count; i++)
                {
                    var cb = (CheckBox)grd_showTT_NhomNguoiDung.Items[i].FindControl("chkSelect0");
                    if (cb.Checked)
                        TT_PhanQuyenService.TT_PhanQuyen_Insert(grd_showTT_NhomNguoiDung.Items[i].Cells[1].Text,
                                                                ViewState["chucnangId"].ToString());
                }
                WebMsgBox.Show("Gán nhóm thành công!");
                pn_showTT_ChucNang.Visible = true;
                panelNhomNguoiDung.Visible = false;
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            panelNhomNguoiDung.Visible = false;
            pn_showTT_ChucNang.Visible = true;
        }

        #endregion

        public string GetTenChucNangLang(string vi, string en)
        {
            if (Session["lang"].ToString() == "vi") return vi;
            return en;
        }

        private void LoadLang()
        {
            if (Session["lang"] == null)
                Session["lang"] = "1";
            if (Session["lang"].ToString() == "1")
            {
                ltrChonNhom.Text = "Chọn nhóm người dùng";
                lbtUpdate_NhomNguoiDung.Text = "Cập nhật";
                lbtCancel.Text = "Hủy bỏ";
            }
            else
            {
                ltrChonNhom.Text = "Select group user";
                lbtUpdate_NhomNguoiDung.Text = "Update";
                lbtCancel.Text = "Cancel";
            }
        }
    }
}