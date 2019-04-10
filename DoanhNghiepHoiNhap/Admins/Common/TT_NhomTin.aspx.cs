using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Languages;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class TT_NhomTin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLang();
                if (Session["lang"] == null)
                    Session["lang"] = "1";
                LoadDdlSearch();
                Insert.Checked = false;
                Loadgrd_showTT_NhomTin();
            }
        }

        private void LoadDdlNhomTin()
        {
            string label;
            if (Session["lang"].ToString() == "1")
                label = "Nhóm tin cấp 1";
            else label = "Root";
            DataTable dtRoot = TT_NhomTinService.TT_NhomTin_GetByTop("20", "NgonNgu='" + Session["lang"] + "' and Cha=-1", "ThuTu");
            ddlNhomTin.Items.Clear();
            ddlNhomTin.Items.Add(new ListItem("---" + label + "---", "-1"));
            for (int i = 0; i < dtRoot.Rows.Count; i++)
            {
                ddlNhomTin.Items.Add(new ListItem(dtRoot.Rows[i]["Ten"].ToString(), dtRoot.Rows[i]["Id"].ToString()));
            }
        }

        #region LoadGridViewNhomTin

        private void Loadgrd_showTT_NhomTin()
        {
            var dt = TT_NhomTinService.TT_NhomTin_GetByTop("100", "NgonNgu='" + Session["lang"] + "'", "ThuTu");
            ViewState["dtGrdMenuBd"] = dt;
            ViewState["dtGrdMenuLoad"] = dt.Clone();

            LoadGrdNhomTin("", "-1");

            grd_showTT_NhomTin.DataSource = (DataTable) ViewState["dtGrdMenuLoad"];
            grd_showTT_NhomTin.DataBind();

            for (int i = 0; i < grd_showTT_NhomTin.Items.Count; i++)
            {
                Label lblThuTu = (Label)grd_showTT_NhomTin.Items[i].FindControl("lblThuTu");
                lblThuTu.Text = (i + 1).ToString();
            } 
        }

        private void LoadGrdNhomTin(string noi, string cha)
        {
            noi += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            var dt = (DataTable)ViewState["dtGrdMenuBd"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Cha"].ToString() == cha)
                {
                    var dt1 = (DataTable)ViewState["dtGrdMenuLoad"];
                    var row = dt1.NewRow();
                    row["Id"] = dt.Rows[i]["Id"];
                    row["Ten"] = noi.Remove(0, 30) + dt.Rows[i]["Ten"];
                    row["Tag"] = dt.Rows[i]["Tag"];
                    row["MoTa"] = dt.Rows[i]["MoTa"];
                    row["Cha"] = dt.Rows[i]["Cha"];
                    row["ThuTu"] = dt.Rows[i]["ThuTu"];
                    row["HienThi"] = dt.Rows[i]["HienThi"];
                    row["NgonNgu"] = dt.Rows[i]["NgonNgu"];

                    dt1.Rows.Add(row);
                    ViewState["dtGrdMenuLoad"] = dt1;
                    LoadGrdNhomTin(noi, dt.Rows[i]["Id"].ToString());
                }
            }
            noi = noi.Remove(0, 30);
        }

        #endregion

        protected void grd_showTT_NhomTin_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_NhomTin.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTT_NhomTin();
        }

        public string GetNameStyle(string name, string cha)
        {
            return cha == "-1" ? "<b style='color:blue;'>" + name + "</b>" : name;
        }

        public string ReturnHienThi(string s)
        {
            if (s == "1") return Lang.Show("show");
            if (s == "2") return Lang.Show("showinfooter");
            return "<span style='color:red;'>" + Lang.Show("hide") + "</span>";
        }

        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "vi";
            btnSearchColumn_NhomTin.Text = Lang.Show("search");
            btnShowAllData_NhomTin.Text = Lang.Show("showall");
            btnCapNhatThuTu.Text = Lang.Show("updateord");
            lbtUpdate_NhomTin.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem_NhomTin.Text = Lang.Show("add");
            ddlHienThi.Items.Clear();
            ddlHienThi.Items.Add(new ListItem(Lang.Show("show"), "1"));
            ddlHienThi.Items.Add(new ListItem(Lang.Show("showinfooter"), "2"));
            ddlHienThi.Items.Add(new ListItem(Lang.Show("hide"), "0"));
        }


        protected void btnCapNhatThuTu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grd_showTT_NhomTin.Items.Count; i++)
            {
                var lb = (Label)grd_showTT_NhomTin.Items[i].FindControl("lIDbIDl");
                var tb = (TextBox)grd_showTT_NhomTin.Items[i].FindControl("txtThuTu");
                CommonService.UpdateValue("TT_NhomTin", "ThuTu=" + tb.Text, "Id=" + lb.Text);
            }
            WebMsgBox.Show(Lang.Show("updatesuccess"));
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTT_NhomTin.Visible = false;
            pn_updateTT_NhomTin.Visible = true;
            Insert.Checked = true;
            txtTen.Text = "";
            txtMoTa.Text = ""; 
            txtThuTu.Text = "";
            LoadDdlNhomTin();
        } 

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_NhomTin.Visible = true;
            pn_updateTT_NhomTin.Visible = false;
            lblerrorTen.Text = ""; 
            lblerrorMoTa.Text = "";
            lblerrorThuTu.Text = "";  
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtTen();
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
                    TT_NhomTinService.TT_NhomTin_Insert(txtTen.Text, StringClass.NameToTag(txtTen.Text), txtMoTa.Text, ddlNhomTin.SelectedValue,
                                                        txtThuTu.Text, ddlHienThi.SelectedValue, Session["lang"].ToString(),"");
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
                    TT_NhomTinService.TT_NhomTin_Update(ViewState["Id"].ToString(), txtTen.Text, StringClass.NameToTag(txtTen.Text),
                                                        txtMoTa.Text, ddlNhomTin.SelectedValue, txtThuTu.Text, ddlHienThi.SelectedValue, Session["lang"].ToString(), "");
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTT_NhomTin();
            pn_showTT_NhomTin.Visible = true;
            pn_updateTT_NhomTin.Visible = false;
        }

        protected void grd_showTT_NhomTin_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    LoadDdlNhomTin();
                    DataTable dt = TT_NhomTinService.TT_NhomTin_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTen.Text = dt.Rows[0]["Ten"].ToString(); 
                        txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                        ddlNhomTin.SelectedValue = dt.Rows[0]["Cha"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                        ddlHienThi.SelectedValue = dt.Rows[0]["HienThi"].ToString();
                    }
                    dt.Clear();

                    pn_showTT_NhomTin.Visible = false;
                    pn_updateTT_NhomTin.Visible = true;
                    break;
                case "Delete":
                    TT_NhomTinService.TT_NhomTin_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTT_NhomTin();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTT_NhomTin_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTT_NhomTin.ClientID + "_row" + e.Item.ItemIndex;
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

        private void LoadDdlSearch()
        { 
            ddlSColumnTT_NhomTin.Items.Add(new ListItem("%Like%", "3"));
            ddlSearchColumn.Items.Add(new ListItem("Tên nhóm tin", "Ten*nvarchar")); 
            ddlSearchColumn.DataBind();
            ddlSColumnTT_NhomTin.DataBind();
        }

        protected void btnShowAllData_Click(object sender, EventArgs e)
        {
            Loadgrd_showTT_NhomTin();
        }

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTT_NhomTin.Text.Trim() == "") return;
            //grd_showTT_NhomTin.DataSource = TT_NhomTinService.TT_NhomTin_SearchColumn(txtSTT_NhomTin.Text.Trim(),
            //                                                                          ddlSearchColumn.SelectedValue,
            //                                                                          ddlSColumnTT_NhomTin.SelectedValue);
            grd_showTT_NhomTin.DataSource = TT_NhomTinService.TT_NhomTin_GetByTop("", "NgonNgu='" + Session["lang"] + "' and Ten like N'%" + txtSTT_NhomTin.Text + "%'", "");
            grd_showTT_NhomTin.DataBind();
        }

        #region[Function Test]

        private bool KtTen()
        {
            if(string.IsNullOrEmpty(txtTen.Text.Trim()))
            {
                lblerrorTen.Text = "Bạn chưa nhập tên nhóm tin";
                return false;
            }
            lblerrorTen.Text = "";
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
                    lblerrorThuTu.Text = "Thứ tự là số nguyên";
                    return false;
                }
            lblerrorThuTu.Text = "";
            return true;
        }  

        #endregion 
    }
}