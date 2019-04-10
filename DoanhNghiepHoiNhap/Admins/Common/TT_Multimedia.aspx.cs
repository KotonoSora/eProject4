using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Languages;

namespace MyWebsite.Admins
{
    public partial class TT_Multimedia : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLang();
                Loadgrd_showTT_Multimedia();
                LoadDdlSearch(); 
                Insert.Checked = false;
            }
        }

        private void Loadgrd_showTT_Multimedia()
        {
            grd_showTT_Multimedia.DataSource = TT_MultimediaService.TT_Multimedia_GetAll();
            grd_showTT_Multimedia.DataBind();
        }

        protected void grd_showTT_Multimedia_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_Multimedia.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTT_Multimedia();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTT_Multimedia.Visible = false;
            pn_updateTT_Multimedia.Visible = true;
            Insert.Checked = true;
            txtImgUrl.Text = "";          
            imgHinhAnh.ImageUrl = "";
            txtVideoUrl.Text = "";
            txtTieuDe.Text = "";
            fckNoiDung.Value = "";
        } 

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_Multimedia.Visible = true;
            pn_updateTT_Multimedia.Visible = false;
            lblerrorTieuDe.Text = ""; 
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {   
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtTieuDe();
            if (kt)
                kt = ktP;

            if (txtVideoUrl.Text=="")
            {
                WebMsgBox.Show("Chưa nhập đường dẫn video");
                return;
            } 

            #endregion

            string anhdaidien = txtImgUrl.Text.Trim() == "" ? StringClass.GetThumbImageYoutobe(txtVideoUrl.Text) : txtImgUrl.Text;

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TT_MultimediaService.TT_Multimedia_Insert(txtTieuDe.Text, txtVideoUrl.Text, fckNoiDung.Value, "1", "0", anhdaidien);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            else
            {
                TT_MultimediaService.TT_Multimedia_Update(ViewState["Id"].ToString(), txtTieuDe.Text, txtVideoUrl.Text, fckNoiDung.Value , "1","0", anhdaidien);
            }
            Loadgrd_showTT_Multimedia();
            WebMsgBox.Show("Cập nhật thành công");
            pn_showTT_Multimedia.Visible = true;
            pn_updateTT_Multimedia.Visible = false; 
        }

        protected void grd_showTT_Multimedia_ItemCommand(object source, DataGridCommandEventArgs e)
        { 
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    pn_showTT_Multimedia.Visible = false;
                    pn_updateTT_Multimedia.Visible = true;
                    DataTable dt = TT_MultimediaService.TT_Multimedia_GetById(ViewState["Id"].ToString());
                    txtTieuDe.Text = dt.Rows[0]["TieuDe"].ToString();
                    txtVideoUrl.Text = dt.Rows[0]["MoTa"].ToString();
                    fckNoiDung.Value = dt.Rows[0]["NoiDung"].ToString(); 
                    txtImgUrl.Text = dt.Rows[0]["AnhDaiDien"].ToString();
                    imgHinhAnh.ImageUrl = dt.Rows[0]["AnhDaiDien"].ToString();

                    break;
                case "Delete":
                    //TT_HinhAnhService.TT_HinhAnh_Delete_MultimediaId(ViewState["Id"].ToString());
                    TT_MultimediaService.TT_Multimedia_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTT_Multimedia();
                    break;
                default:
                    break;
            } 
        }

        protected void grd_showTT_Multimedia_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTT_Multimedia.ClientID + "_row" + e.Item.ItemIndex;
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

        private void LoadDdlSearch()
        { 
            ddlSColumnTT_Multimedia.Items.Add(new ListItem("Tìm gần đúng", "3")); 
            ddlSearchColumn.Items.Add(new ListItem("Tiêu đề", "TieuDe*nvarchar"));  
        }

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        { 
            if (txtSTT_Multimedia.Text.Trim() == "") return;
            grd_showTT_Multimedia.DataSource =
                TT_MultimediaService.TT_Multimedia_SearchColumn(txtSTT_Multimedia.Text.Trim(),
                                                                ddlSearchColumn.SelectedValue,
                                                                ddlSColumnTT_Multimedia.SelectedValue);
            grd_showTT_Multimedia.DataBind(); 
        } 

        #region[Function Test]

        private bool KtTieuDe()
        {
            lblerrorTieuDe.Text = "";
            return true;
        }


        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "vi";
            btnSearchColumn.Text = Lang.Show("search");
            lbtUpdate.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem.Text = Lang.Show("add");
            //btnThemNhom.Text = Lang.Show("addgroup");
            //btnXoa.Text = Lang.Show("delete");
            //ddlTrangThai.Items.Clear();
            //ddlTrangThai.Items.Add(new ListItem(Lang.Show("show"), "1"));
           // ddlTrangThai.Items.Add(new ListItem(Lang.Show("showhot"), "2"));
            //ddlTrangThai.Items.Add(new ListItem(Lang.Show("hide"), "0"));
        }

        public string GetStatus(string s)
        {
            if (s == "1") return Lang.Show("show");
            if (s == "2") return Lang.Show("showhot");
            return Lang.Show("hide");
        }

        #endregion

        public string ReturnLoai(string loai)
        {
            return TT_Multimedia_GroupService.TT_Multimedia_Group_GetById(loai).Rows[0]["Ten"].ToString();
        } 
    }
}