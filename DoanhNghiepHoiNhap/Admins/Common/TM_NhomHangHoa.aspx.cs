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
    public partial class TM_NhomHangHoa : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLang();
                LoadData();
                Insert.Checked = false; 
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTM_NhomHangHoa.Visible = false;
            pn_updateTM_NhomHangHoa.Visible = true;
            Insert.Checked = true; 
            txtTenNhom.Text = "";
            txtMoTa.Text = "";
            txtThuTu.Text = "";
            imgHinhAnh.ImageUrl = "";
            txtImgUrl.Text = "";
            txtTuKhoa.Text = "";
        } 

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTM_NhomHangHoa.Visible = true;
            pn_updateTM_NhomHangHoa.Visible = false;
            lblerrorTenNhom.Text = ""; 
            lblerrorThuTu.Text = "";
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtTenNhom();
            if (kt)
                kt = ktP; 
            ktP = KtThuTu();
            if (kt)
                kt = ktP;

            #endregion

            string capbac, parent;
            string homess = Session["lang"].ToString();
            if (Request.QueryString["id"]==null)
            {
                capbac = "1";
                parent = "-1";
            }
            else
            {
                var dt = TM_NhomHangHoaService.TM_NhomHangHoa_GetById(Request.QueryString["id"]);
                capbac = dt.Rows[0]["Parent"].ToString() == "-1" ? "2" : "3";
                parent = Request.QueryString["id"];
            }

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TM_NhomHangHoaService.TM_NhomHangHoa_Insert(txtTenNhom.Text, txtMoTa.Text, txtImgUrl.Text, txtThuTu.Text, parent, capbac, ddlTrangThai.SelectedValue, txtTuKhoa.Text,homess);
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
                    TM_NhomHangHoaService.TM_NhomHangHoa_Update(ViewState["Id"].ToString(), txtTenNhom.Text, txtMoTa.Text, txtImgUrl.Text, txtThuTu.Text, parent, capbac, ddlTrangThai.SelectedValue, txtTuKhoa.Text,homess);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            LoadData();
            pn_showTM_NhomHangHoa.Visible = true;
            pn_updateTM_NhomHangHoa.Visible = false;
        }

        protected void grd_showTM_NhomHangHoa_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TM_NhomHangHoaService.TM_NhomHangHoa_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTenNhom.Text = dt.Rows[0]["TenNhom"].ToString();
                        txtMoTa.Text = dt.Rows[0]["MoTa"].ToString(); 
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                        ddlTrangThai.SelectedValue = dt.Rows[0]["TrangThai"].ToString();
                        txtImgUrl.Text = dt.Rows[0]["HinhAnh"].ToString();
                        imgHinhAnh.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();
                        txtTuKhoa.Text = dt.Rows[0]["TuKhoa"].ToString();
                    }
                    dt.Clear();
                    pn_showTM_NhomHangHoa.Visible = false;
                    pn_updateTM_NhomHangHoa.Visible = true;
                    break;
                case "Delete":
                    TM_NhomHangHoaService.TM_NhomHangHoa_Delete(ViewState["Id"].ToString());
                    LoadData();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTM_NhomHangHoa_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTM_NhomHangHoa.ClientID + "_row" + e.Item.ItemIndex;
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

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTM_NhomHangHoa.Text.Trim() == "") return;
            grd_showTM_NhomHangHoa.DataSource =
                TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("", "TenNhom like N'%" + txtSTM_NhomHangHoa.Text + "%'", "");
            grd_showTM_NhomHangHoa.DataBind();
        } 

        #endregion

        #region Methods  

        private void LoadData()
        {
            string home = Session["lang"].ToString() == "1" ? "Trang chủ" : "Homepage";
            if (Request.QueryString["id"] == null)
            {
                grd_showTM_NhomHangHoa.DataSource = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("", "CapBac=1 and NgonNgu ="+Session["lang"].ToString(), "ThuTu");
                grd_showTM_NhomHangHoa.DataBind();
                ltrLink.Text = "";
            }
            else
            {

                grd_showTM_NhomHangHoa.DataSource = TM_NhomHangHoaService.TM_NhomHangHoa_GetByTop("", "Parent=" + Request.QueryString["id"]+"and NgonNgu="+Session["lang"].ToString(), "ThuTu");
                grd_showTM_NhomHangHoa.DataBind();

                var dt = TM_NhomHangHoaService.TM_NhomHangHoa_GetById(Request.QueryString["id"]);
                string capbac = dt.Rows[0]["Parent"].ToString() == "-1" ? "2" : "3";
                if (capbac=="2")
                {
                    ltrLink.Text = "<a href='/Admins/Common/TM_NhomHangHoa.aspx'>"+home+"</a>";
                    ltrLink.Text += " >> ";
                    ltrLink.Text += "<a href='/Admins/Common/TM_NhomHangHoa.aspx?id=" + Request.QueryString["id"] + "'>" + dt.Rows[0]["TenNhom"] + "</a>";
                }
            }
        }

        public string CreateLink(string id, string name, string capbac)
        {
            if (capbac=="2")
            {
                return name;
            }
            return "<a href='/Admins/Common/TM_NhomHangHoa.aspx?id="+id+"'>"+name+"</a>";
        }

        public string GetStatus(string t)
        {
            if (t == "0") return Lang.Show("hide");
            if (t == "1") return Lang.Show("show");
            if (t == "2") return Lang.Show("showhomepage"); 
            return "";
        }

        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "1";
            btnSearchColumn.Text = Lang.Show("search");
            lbtUpdate.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem.Text = Lang.Show("add");
            ddlTrangThai.Items.Clear();
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("show"), "1"));
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("hide"), "0"));
            ddlTrangThai.Items.Add(new ListItem(Lang.Show("showhomepage"), "2"));
            //ckbNhomLa.Text = Session["lang"].ToString() == "vi" ? "Là nhóm lá" : "Is group leaves";
        }


        #endregion

        #region Validate

        private bool KtTenNhom()
        {
            lblerrorTenNhom.Text = "";
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
                    lblerrorThuTu.Text = "Thứ tự là số nguyên";
                    return false;
                }
            lblerrorThuTu.Text = "";
            return true;
        }

        #endregion
    }
}