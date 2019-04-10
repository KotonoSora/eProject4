
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
    public partial class TH_QuyenSach : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showTH_QuyenSach();
                LoadDllTheLoaiSach();
                LoadDllTheLoaiChuong();
                Session["folder"] = "TH_QuyenSach";
                Insert.Checked = false;
                if (!Directory.Exists(Server.MapPath("~/Images/TH_QuyenSach")))
                    Directory.CreateDirectory(Server.MapPath("~/Images/TH_QuyenSach"));
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTH_QuyenSach.Visible = false;
            pn_updateTH_QuyenSach.Visible = true;
            Insert.Checked = true; Session["upload"] = "";
            txtTieuDe_QuyenSach.Text = "";
            txtTacGia.Text = "";
            txtMota.Text = "";
 //           txtNote.Text = "";
 //           txtId_TheLoaiSach.Text = "";
 //           txtLuotxem.Text = "";
            txtImgUrl.Text = "";
            imgHinhAnh.ImageUrl = "";
//            txtId_TheLoaiChuong.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showTH_QuyenSach.Items.Count; i++)
                {
                    item = grd_showTH_QuyenSach.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label)item.FindControl("lIDbIDl");
                            var str = lbl.Text.Split(','); try
                            {
                                TH_QuyenSachService.TH_QuyenSach_Delete(str[0]);
                            }
                            catch { }
                        }
                    }
                }
                grd_showTH_QuyenSach.CurrentPageIndex = 0;
                Loadgrd_showTH_QuyenSach();
            }
            catch { }
        }
        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTH_QuyenSach.Visible = true;
            pn_updateTH_QuyenSach.Visible = false;
            lblerrorTieuDe_QuyenSach.Text = "";
            lblerrorTacGia.Text = "";
            lblerrorMota.Text = "";

        }
        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            var kt = true;
            var ktP = true;
            ktP = KtTieuDe_QuyenSach();
            if (kt)
                kt = ktP;
            ktP = KtTacGia();
            if (kt)
                kt = ktP;
            ktP = KtMota();
            if (kt)
                kt = ktP;
            ktP = KtNote();
            if (kt)
                kt = ktP;
            ktP = KtId_TheLoaiSach();
            if (kt)
                kt = ktP;
            ktP = KtLuotxem();
            if (kt)
                kt = ktP;
            ktP = KtHinhAnh();
            if (kt)
                kt = ktP;
            ktP = KtId_TheLoaiChuong();
            if (kt)
                kt = ktP;
            #endregion
            if (txtImgUrl.Text.Trim() == "") txtImgUrl.Text = "/Pic/no-image.jpg";

            string ngayupdate = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy hh:mm:ss tt");

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TH_QuyenSachService.TH_QuyenSach_Insert(txtTieuDe_QuyenSach.Text, txtTacGia.Text, txtMota.Text, "", ddlUTheLoaiSach.SelectedValue, "0", txtImgUrl.Text, ddlUTheLoaiChuong.SelectedValue , ngayupdate);
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
                    TH_QuyenSachService.TH_QuyenSach_Update(ViewState["Id"].ToString(), txtTieuDe_QuyenSach.Text, txtTacGia.Text, txtMota.Text, "", ddlUTheLoaiSach.SelectedValue, "0", txtImgUrl.Text, ddlUTheLoaiChuong.SelectedValue, ngayupdate);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTH_QuyenSach();
            pn_showTH_QuyenSach.Visible = true;
            pn_updateTH_QuyenSach.Visible = false;
        }
        protected void grd_showTH_QuyenSach_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            var strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false; var dt = TH_QuyenSachService.TH_QuyenSach_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTieuDe_QuyenSach.Text = dt.Rows[0]["TieuDe_QuyenSach"].ToString();
                        txtTacGia.Text = dt.Rows[0]["TacGia"].ToString();
                        txtMota.Text = dt.Rows[0]["Mota"].ToString();
 //                       txtNote.Text = dt.Rows[0]["Note"].ToString();
                        ddlUTheLoaiSach.SelectedValue = dt.Rows[0]["Id_TheLoaiSach"].ToString();
 //                       txtLuotxem.Text = dt.Rows[0]["Luotxem"].ToString();
                        imgHinhAnh.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();
                        txtImgUrl.Text = dt.Rows[0]["HinhAnh"].ToString();
                        ddlUTheLoaiChuong.SelectedValue = dt.Rows[0]["Id_TheLoaiChuong"].ToString();

                    }
                    dt.Clear();
                    pn_showTH_QuyenSach.Visible = false;
                    pn_updateTH_QuyenSach.Visible = true;
                    break;
                case "Delete":
                    TH_QuyenSachService.TH_QuyenSach_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTH_QuyenSach(); break;
                default:
                    break;
            }
        }

        protected void grd_showTH_QuyenSach_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTH_QuyenSach.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
            Loadgrd_showTH_QuyenSach();
        }
        #endregion

        #region Methods

        //private void LoadDdlSearch()
        //{
        //    ddlSColumnTH_QuyenSach.Items.Add(new ListItem("=", "1"));
        //    ddlSColumnTH_QuyenSach.Items.Add(new ListItem("Like%", "2"));
        //    ddlSColumnTH_QuyenSach.Items.Add(new ListItem("%Like%", "3"));
        //    ddlSearchColumn.Items.Add(new ListItem("Id - ", "Id*int"));
        //    ddlSearchColumn.Items.Add(new ListItem("TieuDe_QuyenSach - ", "TieuDe_QuyenSach*nvarchar"));
        //    ddlSearchColumn.Items.Add(new ListItem("TacGia - ", "TacGia*nvarchar"));
        //    ddlSearchColumn.Items.Add(new ListItem("Mota - ", "Mota*nvarchar"));
        //    ddlSearchColumn.Items.Add(new ListItem("Note - ", "Note*nvarchar"));
        //    ddlSearchColumn.Items.Add(new ListItem("Id_TheLoaiSach - ", "Id_TheLoaiSach*int"));
        //    ddlSearchColumn.Items.Add(new ListItem("Luotxem - ", "Luotxem*int"));
        //    ddlSearchColumn.Items.Add(new ListItem("HinhAnh - ", "HinhAnh*nvarchar"));
        //    ddlSearchColumn.Items.Add(new ListItem("Id_TheLoaiChuong - ", "Id_TheLoaiChuong*int"));
        //    ddlSearchColumn.DataBind();
        //    ddlSColumnTH_QuyenSach.DataBind();
        //}

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            String where = "(";

            DataTable tblloaisach = TH_TheLoaiSachService.TH_TheLoaiSach_GetByTop("", "", "");
            for (int i = 0; i < tblloaisach.Rows.Count; i++)
            {
                if (i < (tblloaisach.Rows.Count - 1))
                {
                    where += " ( Id_TheLoaiSach = " + tblloaisach.Rows[i]["Id"].ToString() + ") or ";
                }
                else
                {
                    where += " ( Id_TheLoaiSach = " + tblloaisach.Rows[i]["Id"].ToString() + ") )";
                }

            }
            // phần này làm sau

            //if (btnSearchColumn.Text.Trim() != "")
            //{
            //    where += " and (TenTheLoaiSach='" + btnSearchColumn.Text + "' or TenTheLoaiSach like N'%" + btnSearchColumn.Text + "%')";
            //}
            grd_showTH_QuyenSach.CurrentPageIndex = 0;
            grd_showTH_QuyenSach.DataSource = TH_QuyenSachService.TH_QuyenSach_GetByTop("", where, "Id desc");

            //if (txtSTH_QuyenSach.Text.Trim() == "") return;
            //grd_showTH_QuyenSach.DataSource = TH_QuyenSachService.TH_QuyenSach_SearchColumn(txtSTH_QuyenSach.Text.Trim(), ddlSearchColumn.SelectedValue, ddlSColumnTH_QuyenSach.SelectedValue);
            grd_showTH_QuyenSach.DataBind();

        }
        private void Loadgrd_showTH_QuyenSach()
        {
            grd_showTH_QuyenSach.DataSource = TH_QuyenSachService.TH_QuyenSach_GetByTop("","","Id desc");
            grd_showTH_QuyenSach.DataBind();

        }
        protected void grd_showTH_QuyenSach_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTH_QuyenSach.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTH_QuyenSach();
        }
        #endregion

        private void LoadDllTheLoaiSach()
        {
            DataTable dtRoot = TH_TheLoaiSachService.TH_TheLoaiSach_GetByTop("100", "", "Id desc");
            ddlTheLoaiSach.Items.Clear();
            ddlUTheLoaiSach.Items.Clear();
            ddlTheLoaiSach.Items.Add(new ListItem("---" + "Thể loại Sách" + "---", "0"));
            ddlUTheLoaiSach.Items.Add(new ListItem("---" + "Thể loại Sách" + "---", "0"));
            for (int i = 0; i < dtRoot.Rows.Count; i++)
            {
                ddlTheLoaiSach.Items.Add(new ListItem(dtRoot.Rows[i]["TenTheLoaiSach"].ToString(),
                                                       dtRoot.Rows[i]["Id"].ToString()));
                ddlUTheLoaiSach.Items.Add(new ListItem(dtRoot.Rows[i]["TenTheLoaiSach"].ToString(),
                                                       dtRoot.Rows[i]["Id"].ToString()));
                //DataTable dtChild = TH_TheLoaiSachService.TH_TheLoaiSach_GetByTop("100", "", "Id desc");
                //for (int j = 0; j < dtChild.Rows.Count; j++)
                //{
                //    ddlTheLoaiSach.Items.Add(new ListItem("---" + dtChild.Rows[j]["TenTheLoaiSach"],
                //                                           dtChild.Rows[j]["Id"].ToString()));
                //    ddlUTheLoaiSach.Items.Add(new ListItem("---" + dtChild.Rows[j]["TenTheLoaiSach"],
                //                                           dtChild.Rows[j]["Id"].ToString()));
                //}
            }
        }

        public void LoadDllTheLoaiChuong()
        {
            ddlUTheLoaiChuong.Items.Clear();
            ddlUTheLoaiChuong.Items.Add(new ListItem("Thể Loại Chương", ""));
            var loaichuong = TH_LoaiChuongService.TH_LoaiChuong_GetAll();

            for (int i = 0; i < loaichuong.Rows.Count; i++)
            {
                ddlUTheLoaiChuong.Items.Add(new ListItem(loaichuong.Rows[i]["LoaiChuong"].ToString(), loaichuong.Rows[i]["Id"].ToString()));
            }

        }

        public string GetLoaiSach(string id)
        {
            try
            {
                var dd_tt = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "Id_TheLoaiSach = " + id, "");
                string id_tench = dd_tt.Rows[0]["Id_TheLoaiSach"].ToString();

                var dt = TH_TheLoaiSachService.TH_TheLoaiSach_GetById(id_tench);

                string ten = dt.Rows[0]["TenTheLoaiSach"].ToString();

                return ten;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetLoaiChuong(string id)
        {
            try
            {
                var dd_tt = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "Id_TheLoaiChuong = " + id, "");
                string id_tench = dd_tt.Rows[0]["Id_TheLoaiChuong"].ToString();

                var dt = TH_LoaiChuongService.TH_LoaiChuong_GetById(id_tench);

                string ten = dt.Rows[0]["LoaiChuong"].ToString();

                return ten;
            }
            catch (Exception)
            {
                return "";
            }
        }




        #region Validate
        private bool KtTieuDe_QuyenSach()
        {
            lblerrorTieuDe_QuyenSach.Text = "";
            return true;
        }
        private bool KtTacGia()
        {
            lblerrorTacGia.Text = "";
            return true;
        }
        private bool KtMota()
        {
            lblerrorMota.Text = "";
            return true;
        }
        private bool KtNote()
        {
           // lblerrorNote.Text = "";
            return true;
        }
        private bool KtId_TheLoaiSach()
        {
            //if (!string.IsNullOrEmpty(txtId_TheLoaiSach.Text.Trim()))
            //    try
            //    {
            //        var so = long.Parse(txtId_TheLoaiSach.Text);
            //    }
            //    catch
            //    {
            //        lblerrorId_TheLoaiSach.Text = " là số nguyên";
            //        return false;
            //    }
            //lblerrorId_TheLoaiSach.Text = "";
            return true;
        }
        private bool KtLuotxem()
        {
            //if (!string.IsNullOrEmpty(txtLuotxem.Text.Trim()))
            //    try
            //    {
            //        var so = long.Parse(txtLuotxem.Text);
            //    }
            //    catch
            //    {
            //        lblerrorLuotxem.Text = " là số nguyên";
            //        return false;
            //    }
            //lblerrorLuotxem.Text = "";
            return true;
        }
        private bool KtHinhAnh()
        {
            //lblerrorHinhAnh.Text = "";
            return true;
        }
        private bool KtId_TheLoaiChuong()
        {
            //if (!string.IsNullOrEmpty(txtId_TheLoaiChuong.Text.Trim()))
            //    try
            //    {
            //        var so = long.Parse(txtId_TheLoaiChuong.Text);
            //    }
            //    catch
            //    {
            //        lblerrorId_TheLoaiChuong.Text = " là số nguyên";
            //        return false;
            //    }
            //lblerrorId_TheLoaiChuong.Text = "";
            return true;
        }
        #endregion

        protected void SearchByForeignKey(object sender, EventArgs e)
        {
            if (ddlTheLoaiSach.SelectedValue.Equals("0"))
            {
                Loadgrd_showTH_QuyenSach();
            }
            else
            {
                grd_showTH_QuyenSach.DataSource = TH_QuyenSachService.TH_QuyenSach_GetByTop("", "Id_TheLoaiSach =" + ddlTheLoaiSach.SelectedValue, "Id desc");

                grd_showTH_QuyenSach.DataBind();
            }
           
        }

    }
}