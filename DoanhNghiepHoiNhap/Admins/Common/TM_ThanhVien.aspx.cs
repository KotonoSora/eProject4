using System;
using System.Data;
using System.IO;
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
    public partial class TM_ThanhVien : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLang();
                Loadgrd_showTM_ThanhVien(); 
                Insert.Checked = false; 
                LoadDdlNhomNguoiDung();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTM_ThanhVien.Visible = false;
            pn_updateTM_ThanhVien.Visible = true;
            Insert.Checked = true; 
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSoDT.Text = "";
            txtDiaChi.Text = ""; 
            txtGhiChu.Text = "";
            txtImgUrl.Text = "";
            imgHinhAnh.ImageUrl = ""; 
            txtNgaySinh.Text = "";
            txtYahoo.Text = "";
            txtMatKhau.Enabled = true;
            txtSkype.Text = ""; 
        } 

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTM_ThanhVien.Visible = true;
            pn_updateTM_ThanhVien.Visible = false;
            lblerrorTenDangNhap.Text = "";
            lblerrorMatKhau.Text = "";
            lblerrorHoTen.Text = "";  
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = true;
            bool ktP = true;
            ktP = KtTenDangNhap();
            if (kt)
                kt = ktP;
            ktP = KtMatKhau();
            if (kt)
                kt = ktP;
            ktP = KtHoTen();
            if (kt)
                kt = ktP; 
            #endregion

            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    TM_ThanhVienService.TM_ThanhVien_Insert(txtTenDangNhap.Text, SqlDataProvider.Encrypt(txtMatKhau.Text,true), txtHoTen.Text,
                                                            txtEmail.Text, txtSoDT.Text, txtDiaChi.Text,txtGhiChu.Text, txtImgUrl.Text,
                                                            ddlGioiTinh.SelectedValue, txtNgaySinh.Text, txtYahoo.Text,
                                                            txtSkype.Text, "", ddlKichHoat.SelectedValue,ddlNhomNguoiDung.SelectedValue);
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
                    TM_ThanhVienService.TM_ThanhVien_Update(ViewState["Id"].ToString(), txtTenDangNhap.Text,
                                                            txtHoTen.Text, txtEmail.Text, txtSoDT.Text,
                                                            txtDiaChi.Text,  txtGhiChu.Text,
                                                            txtImgUrl.Text, ddlGioiTinh.SelectedValue, txtNgaySinh.Text,
                                                            txtYahoo.Text, txtSkype.Text, ddlKichHoat.SelectedValue, ddlNhomNguoiDung.SelectedValue);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTM_ThanhVien();
            pn_showTM_ThanhVien.Visible = true;
            pn_updateTM_ThanhVien.Visible = false;
        }

        protected void grd_showTM_ThanhVien_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            ViewState["Id"] = e.CommandArgument.ToString();
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TM_ThanhVienService.TM_ThanhVien_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {  
                        txtTenDangNhap.Text = dt.Rows[0]["TenDangNhap"].ToString(); 
                        txtMatKhau.Enabled =false;
                        txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                        txtEmail.Text = dt.Rows[0]["Email"].ToString();
                        txtSoDT.Text = dt.Rows[0]["SoDT"].ToString();
                        txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString(); 
                        txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                        txtImgUrl.Text = dt.Rows[0]["HinhAnh"].ToString();
                        imgHinhAnh.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();
                        ddlGioiTinh.SelectedValue = dt.Rows[0]["GioiTinh"].ToString();
                        txtNgaySinh.Text = dt.Rows[0]["NgaySinh"].ToString();
                        txtYahoo.Text = dt.Rows[0]["Yahoo"].ToString();
                        txtSkype.Text = dt.Rows[0]["Skype"].ToString(); 
                        ddlKichHoat.SelectedValue = dt.Rows[0]["TrangThai"].ToString(); 
                    }
                    dt.Clear();
                    pn_showTM_ThanhVien.Visible = false;
                    pn_updateTM_ThanhVien.Visible = true;
                    break;
                case "Delete":
                    TM_ThanhVienService.TM_ThanhVien_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTM_ThanhVien();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTM_ThanhVien_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTM_ThanhVien.ClientID + "_row" + e.Item.ItemIndex;
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
            Loadgrd_showTM_ThanhVien();
        } 

        #endregion

        #region Methods

        private void SetLang()
        {
            if (Session["lang"] == null) Session["lang"] = "1";
            btnSearchColumn.Text = Lang.Show("search");
            btnShowAllData.Text = Lang.Show("showall");
            lbtUpdate.Text = Lang.Show("update");
            lbtCancel.Text = Lang.Show("cancel");
            btnThem.Text = Lang.Show("add");
            ddlKichHoat.Items.Clear();
            ddlKichHoat.Items.Add(new ListItem(Lang.Show("active"), "1"));
            ddlKichHoat.Items.Add(new ListItem(Lang.Show("deactive"), "0"));
            ddlGioiTinh.Items.Clear();
            ddlGioiTinh.Items.Add(new ListItem(Lang.Show("male"), "1"));
            ddlGioiTinh.Items.Add(new ListItem(Lang.Show("female"), "0"));
        }
         
        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            if (txtSTM_ThanhVien.Text.Trim() == "") return;
            grd_showTM_ThanhVien.CurrentPageIndex = 0;
            grd_showTM_ThanhVien.DataSource = TM_ThanhVienService.TM_ThanhVien_GetByTop("","TenDangNhap<>'topsjsc' and (TenDangNhap='" + txtSTM_ThanhVien.Text + "' or HoTen like N'%" + txtSTM_ThanhVien.Text + "%' or Email='" + txtSTM_ThanhVien.Text + "' or SoDT='" + txtSTM_ThanhVien.Text + "')", "");
            grd_showTM_ThanhVien.DataBind();
        }

        private void Loadgrd_showTM_ThanhVien()
        {
            grd_showTM_ThanhVien.DataSource = TM_ThanhVienService.TM_ThanhVien_GetAllKey();
            grd_showTM_ThanhVien.DataBind();
        }

        protected void grd_showTM_ThanhVien_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTM_ThanhVien.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTM_ThanhVien();
        } 

        private void LoadDdlNhomNguoiDung()
        {
            ddlNhomNguoiDung.DataSource = TT_NhomNguoiDungService.TT_NhomNguoiDung_GetAll();
            ddlNhomNguoiDung.DataTextField = "TenNhom";
            ddlNhomNguoiDung.DataValueField = "ID";
            ddlNhomNguoiDung.DataBind();
        }

        public string getChucVu(string sid)
        {
            var dt = TT_NhomNguoiDungService.TT_NhomNguoiDung_GetById(sid);
            try
            {
                return dt.Rows[0]["TenNhom"].ToString();
            }
            catch (Exception)
            { }
            return "";
        }

        #endregion

        #region Validate

        private bool KtTenDangNhap()
        {
            lblerrorTenDangNhap.Text = "";
            return true;
        }

        private bool KtMatKhau()
        {
            lblerrorMatKhau.Text = "";
            return true;
        }

        private bool KtHoTen()
        {
            lblerrorHoTen.Text = "";
            return true;
        }  
        #endregion 
    }
}