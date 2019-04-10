using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class TT_NgonNgu : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showTT_NgonNgu();
                LoadDdlSearch();
                Insert.Checked = false;
                if (!Directory.Exists(Server.MapPath("~/Images/TT_NgonNgu")))
                    Directory.CreateDirectory(Server.MapPath("~/Images/TT_NgonNgu"));
            }
        }

        private void Loadgrd_showTT_NgonNgu()
        {
            grd_showTT_NgonNgu.DataSource = TT_NgonNguService.TT_NgonNgu_GetAllKey();
            grd_showTT_NgonNgu.DataBind();
        }

        protected void grd_showTT_NgonNgu_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTT_NgonNgu.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTT_NgonNgu();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTT_NgonNgu.Visible = false;
            pn_updateTT_NgonNgu.Visible = true;
            Insert.Checked = true;
            Session["upload"] = "";
            txtTen.Text = "";
            imgHinhAnh.ImageUrl = "";
            txtThuTu.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showTT_NgonNgu.Items.Count; i++)
                {
                    item = grd_showTT_NgonNgu.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox) item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label) item.FindControl("lIDbIDl");
                            string[] str = lbl.Text.Split(',');
                            try
                            {
                                TT_NgonNguService.TT_NgonNgu_Delete(str[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                grd_showTT_NgonNgu.CurrentPageIndex = 0;
                Loadgrd_showTT_NgonNgu();
            }
            catch
            {
            }
        }

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTT_NgonNgu.Visible = true;
            pn_updateTT_NgonNgu.Visible = false;
            lblerrorTen.Text = "";
            lblerrorHinhAnh.Text = "";
            lblerrorThuTu.Text = "";
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = KtThuTu();
            bool ktP = KtTen();
            if (kt) kt = ktP;
            #endregion

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TT_NgonNguService.TT_NgonNgu_Insert(txtTen.Text, imgHinhAnh.ImageUrl, txtThuTu.Text);
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
                    TT_NgonNguService.TT_NgonNgu_Update(ViewState["Id"].ToString(), txtTen.Text, imgHinhAnh.ImageUrl,
                                                        txtThuTu.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTT_NgonNgu();
            pn_showTT_NgonNgu.Visible = true;
            pn_updateTT_NgonNgu.Visible = false;
        }

        protected void grd_showTT_NgonNgu_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TT_NgonNguService.TT_NgonNgu_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTen.Text = dt.Rows[0]["Ten"].ToString();
                        imgHinhAnh.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                    }
                    dt.Clear();
                    pn_showTT_NgonNgu.Visible = false;
                    pn_updateTT_NgonNgu.Visible = true;
                    break;
                case "Delete":
                    TT_NgonNguService.TT_NgonNgu_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTT_NgonNgu();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTT_NgonNgu_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTT_NgonNgu.ClientID + "_row" + e.Item.ItemIndex;
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
            ddlSColumnTT_NgonNgu.Items.Add(new ListItem("=", "1"));
            ddlSColumnTT_NgonNgu.Items.Add(new ListItem("Like%", "2"));
            ddlSColumnTT_NgonNgu.Items.Add(new ListItem("%Like%", "3"));
            ddlSearchColumn.Items.Add(new ListItem("Tên ngôn ngữ", "Ten*nvarchar"));
            ddlSearchColumn.DataBind();
            ddlSColumnTT_NgonNgu.DataBind();
        }

        protected void btnShowAllData_Click(object sender, EventArgs e)
        {
            Loadgrd_showTT_NgonNgu();
        }

        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTT_NgonNgu.Text.Trim() == "") return;
            grd_showTT_NgonNgu.DataSource = TT_NgonNguService.TT_NgonNgu_SearchColumn(txtSTT_NgonNgu.Text.Trim(),
                                                                                      ddlSearchColumn.SelectedValue,
                                                                                      ddlSColumnTT_NgonNgu.SelectedValue);
            grd_showTT_NgonNgu.DataBind();
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            FileUpload fileUpload = null;
            if (((Button) sender).CommandName == "HinhAnh")
            {
                fileUpload = FileUploadHinhAnh;
            }
            if (fileUpload == null) return;
            HttpPostedFile files = fileUpload.PostedFile;
            if (fileUpload.HasFile == false || files.ContentLength > 500000)
            {
                WebMsgBox.Show("Ảnh không hợp lệ!");
            }
            else
            {
                string _fileExt = Path.GetExtension(fileUpload.FileName);
                if (_fileExt.ToLower() == ".gif" || _fileExt.ToLower() == ".png" || _fileExt.ToLower() == ".bmp" ||
                    _fileExt.ToLower() == ".jpeg" || _fileExt.ToLower() == ".jpg")
                {
                    try
                    {
                        string AdsFile = fileUpload.FileName + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" +
                                         DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" +
                                         DateTime.Now.Second + "_" + DateTime.Now.Millisecond +
                                         Path.GetExtension(fileUpload.FileName);
                        fileUpload.SaveAs(Request.PhysicalApplicationPath + "Images/TT_NgonNgu/" + AdsFile);
                        string imgUrl = "~/Images/TT_NgonNgu/" + AdsFile;
                        if (((Button) sender).CommandName == "HinhAnh")
                        {
                            imgHinhAnh.ImageUrl = imgUrl;
                        }
                    }
                    catch
                    {
                        WebMsgBox.Show("Trùng tên hoặc chưa chọn hình!");
                    }
                }
                else WebMsgBox.Show("Không đúng định dạng ảnh!");
            }
        }

        #region[Function Test]

        private bool KtTen()
        {
            if(string.IsNullOrEmpty(txtTen.Text.Trim()))
            {
                lblerrorTen.Text = "Tên ngôn ngữ không được để trống";
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
                    lblerrorThuTu.Text = "Thứ tự là số nguyên";
                    return false;
                }
            lblerrorThuTu.Text = "";
            return true;
        }

        #endregion
    }
}