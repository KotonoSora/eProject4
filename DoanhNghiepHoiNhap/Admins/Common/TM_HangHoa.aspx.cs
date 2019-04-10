using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Data;
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
    public partial class TM_HangHoa : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Role"] == null) Response.Redirect("~/Admins/login.aspx");
                SetLang();
                Loadgrd_showTM_HangHoa();
                Insert.Checked = false;
                LoadDllNhomHangHoa();
                ckbaddenglish.Checked = false;
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTM_HangHoa.Visible = false;
            pn_updateTM_HangHoa.Visible = true;
            Insert.Checked = true;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            
            fckMoTa.Value = "";
            txtKeyword.Text = "";
            txtDescription.Text = "";
            txtBaoHanh.Text = "...";
            ckbKhuyenMai.Checked = false;
            ckbBanChay.Checked = false;

            ckbaddenglish.Checked = false;
            dllanglish.Visible = false;
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTM_HangHoa.Visible = true;
            pn_updateTM_HangHoa.Visible = false;
            lblerrorMaSP.Text = "";
            lblerrorTenSP.Text = "";

            ckbaddenglish.Checked = false;
            dllanglish.Visible = false;
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtMaSP();
            if (kt)
                kt = ktP;
            ktP = KtTenSP();
            if (kt)
                kt = ktP;
            if (ddlUNhomHangHoa.SelectedIndex == 0)
            {
                WebMsgBox.Show(Lang.Show("selectgroupproduct"));
                return;
            }

            #endregion

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    DataTable dt = TM_HangHoaService.TM_HangHoa_Insert(txtMaSP.Text, txtTenSP.Text, fckMoTa.Value,
                                                                       Session["Username"].ToString(),
                                                                       ddlTrangThai.SelectedValue,
                                                                       ddlUNhomHangHoa.SelectedValue, txtKeyword.Text,
                                                                       txtDescription.Text, txtBaoHanh.Text, ddlDanhGia.SelectedValue, ckbKhuyenMai.Checked?"1":"0",ckbBanChay.Checked?"1":"0");

                    
                    if (ckbaddenglish.Checked == true)
                    {
                        if (dllanglish.SelectedIndex == 0)
                        {
                            WebMsgBox.Show(Lang.Show("selectgroupproduct"));
                        }
                        else
                        {
                            String strt = "E"+txtMaSP.Text;
                            DataTable dt1 = TM_HangHoaService.TM_HangHoa_Insert(strt, txtTenSP.Text, fckMoTa.Value,
                                                                       Session["Username"].ToString(),
                                                                       ddlTrangThai.SelectedValue,
                                                                       dllanglish.SelectedValue, txtKeyword.Text,
                                                                       txtDescription.Text, txtBaoHanh.Text, ddlDanhGia.SelectedValue, ckbKhuyenMai.Checked ? "1" : "0", ckbBanChay.Checked ? "1" : "0");

                        }
                    }
                }
                catch
                {
                    WebMsgBox.Show(Lang.Show("Error"));
                    return;
                }
            }
            else
            {
                if (!kt) return;
                try
                {
                    TM_HangHoaService.TM_HangHoa_Update(ViewState["Id"].ToString(), txtMaSP.Text, txtTenSP.Text,
                                                        fckMoTa.Value, ddlTrangThai.SelectedValue,
                                                        ddlUNhomHangHoa.SelectedValue, txtKeyword.Text,
                                                        txtDescription.Text, txtBaoHanh.Text, ddlDanhGia.SelectedValue, ckbKhuyenMai.Checked ? "1" : "0", ckbBanChay.Checked ? "1" : "0");

                    
                    if (ckbaddenglish.Checked == true)
                    {
                        if (dllanglish.SelectedIndex == 0)
                        {
                            WebMsgBox.Show(Lang.Show("selectgroupproduct"));
                        }
                        else
                        {
                            String strt = "E" + txtMaSP.Text;
                            DataTable dt1 = TM_HangHoaService.TM_HangHoa_Insert(strt, txtTenSP.Text, fckMoTa.Value,
                                                                       Session["Username"].ToString(),
                                                                       ddlTrangThai.SelectedValue,
                                                                       dllanglish.SelectedValue, txtKeyword.Text,
                                                                       txtDescription.Text, txtBaoHanh.Text, ddlDanhGia.SelectedValue, ckbKhuyenMai.Checked ? "1" : "0", ckbBanChay.Checked ? "1" : "0");

                            DataTable dtgettidmax = TM_HangHoaService.TM_HangHoa_GetAll();

                            int max =int.Parse(dtgettidmax.Rows[0]["Id"].ToString());
                            for (int i = 0; i < dtgettidmax.Rows.Count; i++)
                            {
                                if (max < int.Parse(dtgettidmax.Rows[i]["Id"].ToString()))
                                {
                                    max = int.Parse(dtgettidmax.Rows[i]["Id"].ToString());
                                }
                            }

                            DataTable dtrow = TM_HangHoa_HinhAnhService.TM_HangHoa_HinhAnh_GetByTop("", "HangHoa =" + ViewState["Id"].ToString(), "");
                            if (dtrow.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtrow.Rows.Count; i++)
                                {
                                    TM_HangHoa_HinhAnhService.TM_HangHoa_HinhAnh_Insert(dtrow.Rows[i]["HinhAnh"].ToString(), dtrow.Rows[i]["Mota"].ToString(), dtrow.Rows[i]["ThuTu"].ToString(), max.ToString());
                                }
                            }

                        }
                    }
                    
                }
                catch
                {
                    WebMsgBox.Show("Error :");
                    return;
                }
            }


            Loadgrd_showTM_HangHoa();
            pn_showTM_HangHoa.Visible = true;
            pn_updateTM_HangHoa.Visible = false;
            ckbaddenglish.Checked = false;
            dllanglish.Visible = false;
        }

        protected void grd_showTM_HangHoa_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            ViewState["Id"] = e.CommandArgument.ToString();
            switch (e.CommandName.Trim())
            {
                case "khuyenmai":
                    DataTable dtkm = TM_HangHoaService.TM_HangHoa_GetById(ViewState["Id"].ToString());
                    CommonService.UpdateValue("TM_HangHoa",dtkm.Rows[0]["KhuyenMai"].ToString() == "1"? "KhuyenMai=0": "KhuyenMai=1", "Id=" + ViewState["Id"]);
                    Loadgrd_showTM_HangHoa();
                    break;
                case "banchay":
                    DataTable dtbc = TM_HangHoaService.TM_HangHoa_GetById(ViewState["Id"].ToString());
                    CommonService.UpdateValue("TM_HangHoa", dtbc.Rows[0]["BanChay"].ToString() == "1" ? "BanChay=0" : "BanChay=1", "Id=" + ViewState["Id"]);
                    Loadgrd_showTM_HangHoa();
                    break;
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TM_HangHoaService.TM_HangHoa_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtMaSP.Text = dt.Rows[0]["MaSP"].ToString();
                        txtTenSP.Text = dt.Rows[0]["TenSP"].ToString(); 
                        fckMoTa.Value = dt.Rows[0]["MoTa"].ToString();
                        ddlTrangThai.SelectedValue = dt.Rows[0]["TrangThai"].ToString();
                        txtKeyword.Text = dt.Rows[0]["Keyword"].ToString();
                        txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        ddlUNhomHangHoa.SelectedValue = dt.Rows[0]["NhomHangHoa"].ToString();
                        ckbKhuyenMai.Checked = dt.Rows[0]["KhuyenMai"].ToString() == "1" ? true : false;
                        ckbBanChay.Checked = dt.Rows[0]["BanChay"].ToString() == "1" ? true : false;
                        txtBaoHanh.Text = dt.Rows[0]["BaoHanh"].ToString();
                        ddlDanhGia.SelectedValue = dt.Rows[0]["DanhGia"].ToString();
                    }
                    dt.Clear();
                    pn_showTM_HangHoa.Visible = false;
                    pn_updateTM_HangHoa.Visible = true;
                    break;
                case "Delete":
                    SqlDataProvider.ExeCuteNonquery("delete from TM_HangHoa_HinhAnh where HangHoa=" + e.CommandArgument);
                    TM_HangHoaService.TM_HangHoa_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTM_HangHoa();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTM_HangHoa_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTM_HangHoa.ClientID + "_row" + e.Item.ItemIndex;
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
            Loadgrd_showTM_HangHoa();
        }

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            String where = "(";

            DataTable tblnhomhh = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("", "NgonNgu = " + Session["lang"].ToString(), "");
            for (int i = 0; i < tblnhomhh.Rows.Count; i++)
            {
                if (i < (tblnhomhh.Rows.Count - 1))
                {
                    where += " ( NhomHangHoa = " + tblnhomhh.Rows[i]["Id"].ToString() + ") or ";
                }
                else
                {
                    where += " ( NhomHangHoa = " + tblnhomhh.Rows[i]["Id"].ToString() + ") )";
                }

            }
            if (txtSTM_HangHoa.Text.Trim() != "")
            {
                where += " and (MaSP='" + txtSTM_HangHoa.Text + "' or TenSP like N'%" + txtSTM_HangHoa.Text + "%')";
            }
            grd_showTM_HangHoa.CurrentPageIndex = 0;
            grd_showTM_HangHoa.DataSource = TM_HangHoaService.TM_HangHoa_GetByTop("", where, "Id desc");
            grd_showTM_HangHoa.DataBind();
        }

        #endregion

        #region Methods

        private void Loadgrd_showTM_HangHoa()
        {
            String str = "(";

            DataTable tblnhomhh = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("","NgonNgu = "+Session["lang"].ToString(),"");
            for (int i = 0; i < tblnhomhh.Rows.Count; i++)
            {
                if (i<(tblnhomhh.Rows.Count-1))
                {
                    str += " NhomHangHoa = " + tblnhomhh.Rows[i]["Id"].ToString() + " or";
                }
                else
                {
                    str += "  NhomHangHoa = " + tblnhomhh.Rows[i]["Id"].ToString() + " )";
                }
                
            }

            grd_showTM_HangHoa.DataSource = TM_HangHoaService.TM_HangHoa_GetByTop("", str, "Id desc");
            grd_showTM_HangHoa.DataBind();
        }

        protected void grd_showTM_HangHoa_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTM_HangHoa.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTM_HangHoa();
        }

        private void LoadDllNhomHangHoa()
        {
            DataTable dtRoot = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("20", "NgonNgu='" + Session["lang"] + "' and Parent=-1", "ThuTu");
            ddlSNhomHangHoa.Items.Clear();
            ddlUNhomHangHoa.Items.Clear();
            ddlSNhomHangHoa.Items.Add(new ListItem("---" + Lang.Show("selectgroupproduct") + "---", "0"));
            ddlUNhomHangHoa.Items.Add(new ListItem("---" + Lang.Show("selectgroupproduct") + "---", "0"));
            for (int i = 0; i < dtRoot.Rows.Count; i++)
            {
                ddlSNhomHangHoa.Items.Add(new ListItem(dtRoot.Rows[i]["TenNhom"].ToString(),
                                                       dtRoot.Rows[i]["Id"].ToString()));
                ddlUNhomHangHoa.Items.Add(new ListItem(dtRoot.Rows[i]["TenNhom"].ToString(),
                                                       dtRoot.Rows[i]["Id"].ToString()));
                DataTable dtChild = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("20", "Parent=" + dtRoot.Rows[i]["Id"],
                                                                                  "ThuTu");
                for (int j = 0; j < dtChild.Rows.Count; j++)
                {
                    ddlSNhomHangHoa.Items.Add(new ListItem("---" + dtChild.Rows[j]["TenNhom"],
                                                           dtChild.Rows[j]["Id"].ToString()));
                    ddlUNhomHangHoa.Items.Add(new ListItem("---" + dtChild.Rows[j]["TenNhom"],
                                                           dtChild.Rows[j]["Id"].ToString()));
                }
            }
        }

        public string GetImage(string id)
        {
            DataTable dt = TM_HangHoa_HinhAnhService.TM_HangHoa_HinhAnh_GetByTop("1", "HangHoa=" + id, "");
            if (dt.Rows.Count == 0) return "/Pic/no-image.jpg";
            return dt.Rows[0]["HinhAnh"].ToString();
        }

        public string GetCheck(string t )
        {
            return t =="1" ? "/Pic/check.png" : "/Pic/uncheck.png";
        }

        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "vi";
            btnSearchColumn.Text = Lang.Show("search");
            lbtUpdate.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem.Text = Lang.Show("add");
            btnShowAllData.Text = Lang.Show("showall");
            ddlTrangThai.Items.Clear();
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("show"), "1"));
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("hide"), "0"));
        }

        protected void SearchByForeignKey(object sender, EventArgs e)
        {
            if (ddlSNhomHangHoa.SelectedValue.Equals("0"))
            {
                Loadgrd_showTM_HangHoa();
            }
            else
            {
                grd_showTM_HangHoa.DataSource = TM_HangHoaService.TM_HangHoa_GetByTop("", "NhomHangHoa =" + ddlSNhomHangHoa.SelectedValue, "Id desc");

                grd_showTM_HangHoa.DataBind();
            }
           
        }

        protected void loaddllanglish()
        {
            if(Session["lang"].Equals("1")){
                DataTable dt = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("20", "NgonNgu=2 and Parent=-1", "ThuTu");
                dllanglish.Items.Clear();
                dllanglish.Items.Add(new ListItem("---Chọn nhóm sản phẩm tiếng anh---", "0"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dllanglish.Items.Add(new ListItem(dt.Rows[i]["TenNhom"].ToString(), dt.Rows[i]["Id"].ToString()));
                    DataTable dtChild = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("20", "Parent=" + dt.Rows[i]["Id"],
                                                                                  "ThuTu");
                    for (int j = 0; j < dtChild.Rows.Count; j++)
                    {
                        dllanglish.Items.Add(new ListItem("---" + dtChild.Rows[j]["TenNhom"],
                                                               dtChild.Rows[j]["Id"].ToString()));
                    }
                }
            }
            else
            {
                DataTable dt = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("20", "NgonNgu=1 and Parent=-1", "ThuTu");
                dllanglish.Items.Clear();
                dllanglish.Items.Add(new ListItem("---Vietnamese selected product groups---", "0"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dllanglish.Items.Add(new ListItem(dt.Rows[i]["TenNhom"].ToString(), dt.Rows[i]["Id"].ToString()));
                    DataTable dtChild = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("20", "Parent=" + dt.Rows[i]["Id"],
                                                                                  "ThuTu");
                    for (int j = 0; j < dtChild.Rows.Count; j++)
                    {
                        dllanglish.Items.Add(new ListItem("---" + dtChild.Rows[j]["TenNhom"],
                                                               dtChild.Rows[j]["Id"].ToString()));
                    }
                }
            }
        }

        #endregion

        #region Validate

        private bool KtMaSP()
        {
            lblerrorMaSP.Text = "";
            return true;
        }

        private bool KtTenSP()
        {
            lblerrorTenSP.Text = "";
            return true;
        }

        #endregion

        protected void ckbaddenglish_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbaddenglish.Checked)
            {
                dllanglish.Visible = true;
                loaddllanglish();
            }
            else
            {
                dllanglish.Visible = false;
            }
        }
    }
}