
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
    public partial class TH_Chuong : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDllTenQuyenSach();
                Loadgrd_showTH_Chuong();
                Session["folder"] = "TH_Chuong";
                Insert.Checked = false;
                if (!Directory.Exists(Server.MapPath("~/Images/TH_Chuong")))
                    Directory.CreateDirectory(Server.MapPath("~/Images/TH_Chuong"));
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTH_Chuong.Visible = false;
            pn_updateTH_Chuong.Visible = true;
            Insert.Checked = true; Session["upload"] = "";
            //            txtId_QuyenSach.Text = "";
            txtTieuDe.Text = "";
            fckNoiDung.Value = "";
            //            txtNote_text.Text = "";
            //           txtNote_int.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showTH_Chuong.Items.Count; i++)
                {
                    item = grd_showTH_Chuong.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label)item.FindControl("lIDbIDl");
                            var str = lbl.Text.Split(','); try
                            {
                                TH_ChuongService.TH_Chuong_Delete(str[0]);
                            }
                            catch { }
                        }
                    }
                }
                grd_showTH_Chuong.CurrentPageIndex = 0;
                Loadgrd_showTH_Chuong();
            }
            catch { }
        }
        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTH_Chuong.Visible = true;
            pn_updateTH_Chuong.Visible = false;
            //            lblerrorId_QuyenSach.Text = "";
            lblerrorTieuDe.Text = "";
            lblerrorNoiDung.Text = "";
            //            lblerrorNote_text.Text = "";
            //            lblerrorNote_int.Text = "";
        }
        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            var kt = true;
            var ktP = true;
            ktP = KtId_QuyenSach();
            if (kt)
                kt = ktP;
            ktP = KtTieuDe();
            if (kt)
                kt = ktP;
            ktP = KtNoiDung();
            if (kt)
                kt = ktP;
            ktP = KtNote_text();
            if (kt)
                kt = ktP;
            ktP = KtNote_int();
            if (kt)
                kt = ktP;
            #endregion

            string ngaycapnhat = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy hh:mm:ss tt");

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TH_ChuongService.TH_Chuong_Insert(ddlQuyenSach.SelectedValue, txtTieuDe.Text, fckNoiDung.Value, "0", "1", ngaycapnhat);
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
                    TH_ChuongService.TH_Chuong_Update(ViewState["Id"].ToString(), ddlQuyenSach.SelectedValue, txtTieuDe.Text, fckNoiDung.Value, "", "1", ngaycapnhat);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTH_Chuong();
            pn_showTH_Chuong.Visible = true;
            pn_updateTH_Chuong.Visible = false;
        }
        protected void grd_showTH_Chuong_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            var strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false; var dt = TH_ChuongService.TH_Chuong_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        ddlQuyenSach.SelectedValue = dt.Rows[0]["Id_QuyenSach"].ToString();
                        txtTieuDe.Text = dt.Rows[0]["TieuDe"].ToString();
                        fckNoiDung.Value = dt.Rows[0]["NoiDung"].ToString();
                    }
                    dt.Clear();
                    pn_showTH_Chuong.Visible = false;
                    pn_updateTH_Chuong.Visible = true;
                    break;
                case "Delete":
                    TH_ChuongService.TH_Chuong_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTH_Chuong(); break;
                default:
                    break;
            }
        }

        protected void grd_showTH_Chuong_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTH_Chuong.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
            Loadgrd_showTH_Chuong();
        }
        #endregion

        #region Methods
        private void Loadgrd_showTH_Chuong()
        {
            if (ddlsQuyenSach.SelectedValue.Equals("0"))
            {
                grd_showTH_Chuong.DataSource = TH_ChuongService.TH_Chuong_GetByTop("", "", "Id desc");
                grd_showTH_Chuong.DataBind();
            }
            else
            {
                grd_showTH_Chuong.DataSource = TH_ChuongService.TH_Chuong_GetByTop("", "Id_QuyenSach =" + ddlsQuyenSach.SelectedValue, "Id desc");
                grd_showTH_Chuong.DataBind();
            }

        }
        protected void grd_showTH_Chuong_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTH_Chuong.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTH_Chuong();

        }

        //public void load_QuyenSach()
        //{
        //    ddlQuyenSach.Items.Clear();
        //    ddlQuyenSach.Items.Add(new ListItem("Tên Quyển Sách", ""));
        //    var tenquyensach = TH_QuyenSachService.TH_QuyenSach_GetAll();

        //    for (int i = 0; i < tenquyensach.Rows.Count; i++)
        //    {
        //        ddlQuyenSach.Items.Add(new ListItem(tenquyensach.Rows[i]["TieuDe_QuyenSach"].ToString(), tenquyensach.Rows[i]["Id"].ToString()));
        //    }

        //}

        public string GetQuyenSach(string id)
        {
            try
            {
                var dd_tt = TH_ChuongService.TH_Chuong_GetByTop("", "Id_QuyenSach = " + id, "");
                string id_tench = dd_tt.Rows[0]["Id_QuyenSach"].ToString();

                var dt = TH_QuyenSachService.TH_QuyenSach_GetById(id_tench);

                string ten = dt.Rows[0]["TieuDe_QuyenSach"].ToString();

                return ten;
            }
            catch (Exception)
            {
                return "";
            }
        }

        protected void SearchByForeignKey(object sender, EventArgs e)
        {
            grd_showTH_Chuong.CurrentPageIndex = 0; // chuyen ve trag dau tien .
            Loadgrd_showTH_Chuong();         
        }

        private void LoadDllTenQuyenSach()
        {
            DataTable dtRoot = TH_QuyenSachService.TH_QuyenSach_GetByTop("100", "Id_TheLoaiChuong = 1", "Id desc");
            ddlsQuyenSach.Items.Clear();
            ddlQuyenSach.Items.Clear();
            ddlsQuyenSach.Items.Add(new ListItem("---" + "Tên quyển sách" + "---", "0"));
            ddlQuyenSach.Items.Add(new ListItem("---" + "Tên quyển sách" + "---", "0"));
            for (int i = 0; i < dtRoot.Rows.Count; i++)
            {
                ddlsQuyenSach.Items.Add(new ListItem(dtRoot.Rows[i]["TieuDe_QuyenSach"].ToString(),
                                                       dtRoot.Rows[i]["Id"].ToString()));
                ddlQuyenSach.Items.Add(new ListItem(dtRoot.Rows[i]["TieuDe_QuyenSach"].ToString(),
                                                       dtRoot.Rows[i]["Id"].ToString()));
            }
        }


        #endregion

        #region Validate
        private bool KtId_QuyenSach()
        {
            //if (!string.IsNullOrEmpty(txtId_QuyenSach.Text.Trim()))
            //    try
            //    {
            //        var so = long.Parse(txtId_QuyenSach.Text);
            //    }
            //    catch
            //    {
            //        lblerrorId_QuyenSach.Text = " là số nguyên";
            //        return false;
            //    }
            //lblerrorId_QuyenSach.Text = "";
            return true;
        }
        private bool KtTieuDe()
        {
            lblerrorTieuDe.Text = "";
            return true;
        }
        private bool KtNoiDung()
        {
            lblerrorNoiDung.Text = "";
            return true;
        }
        private bool KtNote_text()
        {
            //blerrorNote_text.Text = "";
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