using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Languages;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class TT_Menu : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLang();
                if (Session["lang"] == null) Session["lang"] = "1";
                LoadgrdShowTtMenu();
                LoadDdlSearch();
                Insert.Checked = false;
            }
        }
         
        public string GetNameStyle(string name, string cha)
        {
            return cha == "-1" ? "<b style='color:blue;'>"+name+"</b>" : name;
        }

        public string ReturnMenuCha(string s)
        {
            if (s == "-1") return "Menu gốc";
            return "Con của "+TT_MenuService.TT_Menu_GetById(s).Rows[0]["Ten"];
        } 

        public string ReturnHienThi(string s)
        {
            if (s == "1") return Lang.Show("menutren");
            if (s == "2") return Lang.Show("menuduoi");
            if (s == "3") return Lang.Show("menutrenduoi");
            return "<b style='color:red;'>" + Lang.Show("hide") + "</b>";
        }

        public string ReturnNgonNgu(string s)
        {
            return TT_NgonNguService.TT_NgonNgu_GetById(s).Rows[0]["Ten"].ToString();
        }  


        protected string GetTenNhomTin(string ten)
        {
            string noi = "";
            while (ten[0] == ' ')
            {
                noi += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                ten = ten.Remove(0, 1);
            }
            return noi;
        }

        protected void btnCapNhatThuTu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grd_showTT_Menu.Items.Count; i++)
            {
                var lb = (Label)grd_showTT_Menu.Items[i].FindControl("lIDbIDl");
                var tb = (TextBox)grd_showTT_Menu.Items[i].FindControl("txtThuTu");
                CommonService.UpdateValue("TT_Menu", "ThuTu=" + tb.Text, "Id=" + lb.Text);
            }
            WebMsgBox.Show(Lang.Show("updatesuccess"));

        }

        #region LoadGridViewMenu
        
        private void LoadgrdShowTtMenu()
        {
            var dt = TT_MenuService.TT_Menu_GetByTop("100", "NgonNgu='" + Session["lang"] + "'", "ThuTu");
            ViewState["dtGrdMenuBd"] = dt;
            ViewState["dtGrdMenuLoad"] = dt.Clone();

            LoadGrdMenu("", "-1");

            grd_showTT_Menu.DataSource = (DataTable)ViewState["dtGrdMenuLoad"];
            grd_showTT_Menu.DataBind();

            for (int i = 0; i < grd_showTT_Menu.Items.Count; i++)
            {
                Label lblThuTu = (Label)grd_showTT_Menu.Items[i].FindControl("lblThuTu");
                lblThuTu.Text = (i + 1).ToString();
            } 
        }

        private void LoadGrdMenu(string noi,string cha)
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
                    row["Link"] = dt.Rows[i]["Link"];
                    row["Cha"] = dt.Rows[i]["Cha"];
                    row["ThuTu"] = dt.Rows[i]["ThuTu"];
                    row["HienThi"] = dt.Rows[i]["HienThi"];
                    row["NgonNgu"] = dt.Rows[i]["NgonNgu"];
                    row["Loai"] = dt.Rows[i]["Loai"];

                    dt1.Rows.Add(row);
                    ViewState["dtGrdMenuLoad"] = dt1;
                    LoadGrdMenu(noi, dt.Rows[i]["Id"].ToString());
                }
            }
            noi.Remove(0, 30);
        }

        #endregion

        #region LoadDdlNhomTin

        private void LoadDdlNhomTin()
        {
            DataTable dtRoot = TT_NhomTinService.TT_NhomTin_GetByTop("20", "NgonNgu='" + Session["lang"] + "' and Cha=-1", "ThuTu");
            ddlNhomTin.Items.Clear();
            ddlNhomTin.Items.Add(new ListItem("---" + Lang.Show("selectgroupnew") + "---", ""));
            for (int i = 0; i < dtRoot.Rows.Count; i++)
            {
                ddlNhomTin.Items.Add(new ListItem(dtRoot.Rows[i]["Ten"].ToString(), dtRoot.Rows[i]["Id"].ToString()));
                DataTable dtChild = TT_NhomTinService.TT_NhomTin_GetByTop("20", "Cha=" + dtRoot.Rows[i]["Id"], "ThuTu");
                for (int j = 0; j < dtChild.Rows.Count; j++)
                {
                    ddlNhomTin.Items.Add(new ListItem("---"+dtChild.Rows[j]["Ten"], dtChild.Rows[j]["Id"].ToString()));
                }
            }
        }


        #endregion

        #region LoadDdlLevel

        private void LoadDdlMenu()
        {
            DataTable dt = TT_MenuService.TT_Menu_GetByTop("20", "NgonNgu='" + Session["lang"] + "' and Cha=-1", "ThuTu");
            ddlMenu.Items.Clear();
            ddlMenu.Items.Add(new ListItem("---" + Lang.Show("rootmenu") + "---", "-1"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlMenu.Items.Add(new ListItem(dt.Rows[i]["Ten"].ToString(), dt.Rows[i]["Id"].ToString()));
            }
        }

        #endregion

        protected void grd_showTT_Menu_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_Menu.CurrentPageIndex = e.NewPageIndex;
            LoadgrdShowTtMenu();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        { 
            pn_showTT_Menu.Visible = false;
            pn_updateTT_Menu.Visible = true;
            Insert.Checked = true;
            txtTen.Text = "";
            txtLink.Text = "http://";
            txtThuTu.Text = "";
            LoadDdlMenu();
            fckChiTiet.Value = "";
        } 

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_Menu.Visible = true;
            pn_updateTT_Menu.Visible = false;
            lblerrorTen.Text = "";
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
            ktP = KtThuTu();
            if (kt)
                kt = ktP;
            #endregion
            string lang = "";
            if (Session["lang"].Equals("2"))
            {
                string news = "/news/";
                lang = "en" + news;
            }
            else
            {
                string tintuc = "/tin-tuc/";
                lang = "vi" + tintuc;
            }

            //string news = "";
            //if (Session["news"].Equals("2"))
            //{
            //    lang = "news";
            //}
            //else
            //{
            //    lang = "tin-tuc";
            //}

            string link;
            if (ddlLinkType.SelectedValue == "1")
                link = txtLink.Text;
            else if (ddlLinkType.SelectedValue == "2")
            {
                //if (ddlNhomTin.SelectedIndex == 0)
                //{
                //    WebMsgBox.Show(Lang.Show("errorselectgroupnew"));
                //    return;
                //}

                //DataTable dt = TT_NhomTinService.TT_NhomTin_GetById(ddlNhomTin.SelectedValue);
                ////link = "/" + StringClass.NameToTag(dt.Rows[0]["Ten"].ToString()) + ".html";
                //link = "/" + lang + "/" + StringClass.NameToTag(dt.Rows[0]["Ten"].ToString());
                if (ddlNhomTin.SelectedIndex == 0)
                {
                    WebMsgBox.Show("Bạn chưa chọn nhóm tin");
                    return;
                }
                DataTable dt = TT_NhomTinService.TT_NhomTin_GetById(ddlNhomTin.SelectedValue);
                link = "/" + lang + StringClass.NameToTag(dt.Rows[0]["Ten"].ToString()) + "-a" + ddlNhomTin.SelectedValue;
            }
            else link = "";
            if (Insert.Checked)
            {

                if (!kt) return;
                try
                {
                    TT_MenuService.TT_Menu_Insert(txtTen.Text, link, ddlMenu.SelectedValue, txtThuTu.Text, ddlHienThi.SelectedValue,
                                                  Session["lang"].ToString(), ddlLinkType.SelectedValue, fckChiTiet.Value);
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
                    TT_MenuService.TT_Menu_Update(ViewState["Id"].ToString(), txtTen.Text, link, ddlMenu.SelectedValue,
                                                  txtThuTu.Text, ddlHienThi.SelectedValue, Session["lang"].ToString(), ddlLinkType.SelectedValue, fckChiTiet.Value);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            LoadgrdShowTtMenu();
            pn_showTT_Menu.Visible = true;
            pn_updateTT_Menu.Visible = false;
        }

        protected void grd_showTT_Menu_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            ViewState["Id"] = e.CommandArgument.ToString();
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    LoadDdlMenu();
                    DataTable dt = TT_MenuService.TT_Menu_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTen.Text = dt.Rows[0]["Ten"].ToString();
                        txtLink.Text = dt.Rows[0]["Link"].ToString();
                        ddlMenu.SelectedValue = dt.Rows[0]["Cha"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                        ddlHienThi.SelectedValue = dt.Rows[0]["HienThi"].ToString();
                        fckChiTiet.Value = dt.Rows[0]["ChiTiet"].ToString();
                        ddlLinkType.SelectedValue = dt.Rows[0]["Loai"].ToString();

                        if (ddlLinkType.SelectedValue == "1")
                        {
                            txtLink.Visible = true;
                            ddlNhomTin.Visible = false;
                            fckChiTiet.Visible = false;
                        }
                        else if (ddlLinkType.SelectedValue == "2")
                        {
                            txtLink.Visible = false;
                            ddlNhomTin.Visible = true;
                            fckChiTiet.Visible = false;
                            LoadDdlNhomTin();
                        }
                        else
                        {
                            txtLink.Visible = false;
                            ddlNhomTin.Visible = false;
                            fckChiTiet.Visible = true;
                        }
                    }

                    dt.Clear();
                    pn_showTT_Menu.Visible = false;
                    pn_updateTT_Menu.Visible = true;
                    break;
                case "Delete":
                    TT_MenuService.TT_Menu_Delete(ViewState["Id"].ToString());
                    LoadgrdShowTtMenu();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTT_Menu_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                        string tableRowId = grd_showTT_Menu.ClientID + "_row" + e.Item.ItemIndex;
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

        private void LoadDdlSearch()
        {
            ddlSColumnTT_Menu.Items.Add(new ListItem("%Like%", "3"));
            ddlSearchColumn.Items.Add(new ListItem("Tên menu", "Ten*nvarchar"));
            ddlSearchColumn.DataBind();
            ddlSColumnTT_Menu.DataBind();
        }

        protected void btnShowAllData_Click(object sender, EventArgs e)
        {
            LoadgrdShowTtMenu();
        }

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTT_Menu.Text.Trim() == "") return;
            grd_showTT_Menu.CurrentPageIndex = 0;
            //grd_showTT_Menu.DataSource = TT_MenuService.TT_Menu_SearchColumn(txtSTT_Menu.Text.Trim(),
            //                                                                 ddlSearchColumn.SelectedValue,
            //                                                                 ddlSColumnTT_Menu.SelectedValue);
            grd_showTT_Menu.DataSource = TT_MenuService.TT_Menu_GetByTop("", "NgonNgu='" + Session["lang"] + "' and Ten like N'%" + txtSTT_Menu.Text + "%'", "");
            grd_showTT_Menu.DataBind();
        }

        #region[Function Test]

        private bool KtTen()
        {
            if (string.IsNullOrEmpty(txtTen.Text.Trim()))
            {
                lblerrorTen.Text = Lang.Show("notbeempty").ToString();//notbeempty
                return false;
            }
            lblerrorTen.Text = "";
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
                    lblerrorThuTu.Text = Lang.Show("isinteger").ToString();
                    return false;
                }
            lblerrorThuTu.Text = "";
            return true;
        }
          
         
        #endregion

        protected void ddlLinkType_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (ddlLinkType.SelectedValue == "1")
            {
                txtLink.Visible = true;
                ddlNhomTin.Visible = false;
                fckChiTiet.Visible = false;
            }
            else if (ddlLinkType.SelectedValue=="2")
            {
                txtLink.Visible = false;
                ddlNhomTin.Visible = true;
                fckChiTiet.Visible = false;
                LoadDdlNhomTin();
            }
            else
            {
                txtLink.Visible = false;
                ddlNhomTin.Visible = false;
                fckChiTiet.Visible = true;
            }
        }

        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "1";
            btnSearchColumn_Menu.Text = Lang.Show("search");
            btnShowAllData_Menu.Text = Lang.Show("showall");
            btnCapNhatThuTu.Text = Lang.Show("updateord");
            lbtUpdate_Menu.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem_Menu.Text = Lang.Show("add");
            ddlLinkType.Items.Clear();
            ddlLinkType.Items.Add(new ListItem(Lang.Show("menuloai1"), "1"));
            ddlLinkType.Items.Add(new ListItem(Lang.Show("menuloai2"), "2"));
            ddlLinkType.Items.Add(new ListItem(Lang.Show("menuloai3"), "3"));
            ddlLinkType.Items.Add(new ListItem(Lang.Show("menuloai4"), "4"));

            ddlHienThi.Items.Clear();
            ddlHienThi.Items.Add(new ListItem(Lang.Show("menutren"), "1"));
            ddlHienThi.Items.Add(new ListItem(Lang.Show("menuduoi"), "2"));
            ddlHienThi.Items.Add(new ListItem(Lang.Show("menutrenduoi"), "3"));
            ddlHienThi.Items.Add(new ListItem(Lang.Show("hide"), "0"));

            //ddlPage.Items.Clear();
            //ddlPage.Items.Add(new ListItem(Lang.Show("news"), "/" + Session["lang"] + "/news"));
            //ddlPage.Items.Add(new ListItem(Lang.Show("sitemap"), "/" + Session["lang"] + "/sitemap"));
            //ddlPage.Items.Add(new ListItem("Rss", "/" + Session["lang"] + "/rss"));
            //ddlPage.Items.Add(new ListItem(Lang.Show("product"), "/" + Session["lang"] + "/product"));
            //ddlPage.Items.Add(new ListItem("Video", "/" + Session["lang"] + "/video"));
            //ddlPage.Items.Add(new ListItem(Lang.Show("contact"), "/" + Session["lang"] + "/contacts"));
            //ddlPage.Items.Add(new ListItem(Lang.Show("companyhistory"), "/" + Session["lang"] + "/milestones"));
            //ddlPage.Items.Add(new ListItem(Lang.Show("thongdiep").ToLower(), "/" + Session["lang"] + "/message"));
            //ddlPage.Items.Add(new ListItem("FAQs", "/" + Session["lang"] + "/faqs"));

        }
    }
}