
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
    public partial class DoanhNhanThanhDat : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrd_showDoanhNhanThanhDat();
                LoadDdlSearch();
                Session["folder"] = "DoanhNhanThanhDat";
                Insert.Checked = false;
                if (!Directory.Exists(Server.MapPath("~/Images/DoanhNhanThanhDat")))
                    Directory.CreateDirectory(Server.MapPath("~/Images/DoanhNhanThanhDat"));
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showDoanhNhanThanhDat.Visible = false;
            pn_updateDoanhNhanThanhDat.Visible = true;
            Insert.Checked = true; Session["upload"] = "";
            txtTen.Text = "";
            txtImgUrl.Text = "";
            fckGioiThieu.Value = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtThuTu.Text = "";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grd_showDoanhNhanThanhDat.Items.Count; i++)
                {
                    item = grd_showDoanhNhanThanhDat.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            var lbl = (Label)item.FindControl("lIDbIDl");
                            var str = lbl.Text.Split(','); try
                            {
                                DoanhNhanThanhDatService.DoanhNhanThanhDat_Delete(str[0]);
                            }
                            catch { }
                        }
                    }
                }
                grd_showDoanhNhanThanhDat.CurrentPageIndex = 0;
                Loadgrd_showDoanhNhanThanhDat();
            }
            catch { }
        }
        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showDoanhNhanThanhDat.Visible = true;
            pn_updateDoanhNhanThanhDat.Visible = false;
            lblerrorTen.Text = "";
            //lblerrorAnh.Text = "";
            //lblerrorGioiThieu.Text = "";
            //lblerrorDiaChi.Text = "";
            //lblerrorDienThoai.Text = "";
            //lblerrorEmail.Text = "";
            lblerrorThuTu.Text = "";
        }
        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            var kt = true;
            var ktP = true;
            ktP = KtTen();
            if (kt)
                kt = ktP;
            //ktP = KtAnh();
            //if (kt)
            //    kt = ktP;
            //ktP = KtGioiThieu();
            //if (kt)
            //    kt = ktP;
            //ktP = KtDiaChi();
            //if (kt)
            //    kt = ktP;
            //ktP = KtDienThoai();
            //if (kt)
            //    kt = ktP;
            //ktP = KtEmail();
            //if (kt)
            //    kt = ktP;
            ktP = KtThuTu();
            if (kt)
                kt = ktP;
            #endregion
            if (Insert.Checked)
            {
                if (!kt) return;
                try
                {
                    DoanhNhanThanhDatService.DoanhNhanThanhDat_Insert(txtTen.Text, txtImgUrl.Text, fckGioiThieu.Value, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, txtThuTu.Text);
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
                    DoanhNhanThanhDatService.DoanhNhanThanhDat_Update(ViewState["Id"].ToString(), txtTen.Text, txtImgUrl.Text, fckGioiThieu.Value, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, txtThuTu.Text);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showDoanhNhanThanhDat();
            pn_showDoanhNhanThanhDat.Visible = true;
            pn_updateDoanhNhanThanhDat.Visible = false;
        }
        protected void grd_showDoanhNhanThanhDat_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            var strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false; var dt = DoanhNhanThanhDatService.DoanhNhanThanhDat_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtTen.Text = dt.Rows[0]["Ten"].ToString();
                        txtImgUrl.Text = dt.Rows[0]["Anh"].ToString();
                        fckGioiThieu.Value = dt.Rows[0]["GioiThieu"].ToString();
                        txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                        txtDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
                        txtEmail.Text = dt.Rows[0]["Email"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                    }
                    dt.Clear();
                    pn_showDoanhNhanThanhDat.Visible = false;
                    pn_updateDoanhNhanThanhDat.Visible = true;
                    break;
                case "Delete":
                    DoanhNhanThanhDatService.DoanhNhanThanhDat_Delete(ViewState["Id"].ToString());
                    Loadgrd_showDoanhNhanThanhDat(); break;
                default:
                    break;
            }
        }

        protected void grd_showDoanhNhanThanhDat_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showDoanhNhanThanhDat.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
            Loadgrd_showDoanhNhanThanhDat();
        }
        #endregion

        #region Methods

        private void LoadDdlSearch()
        {
            //ddlSColumnDoanhNhanThanhDat.Items.Add(new ListItem("=", "1"));
            //ddlSColumnDoanhNhanThanhDat.Items.Add(new ListItem("Like%", "2"));
            //ddlSColumnDoanhNhanThanhDat.Items.Add(new ListItem("%Like%", "3"));
            //ddlSearchColumn.Items.Add(new ListItem("Id - ", "Id*int"));
            //ddlSearchColumn.Items.Add(new ListItem("Ten - ", "Ten*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("Anh - ", "Anh*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("GioiThieu - ", "GioiThieu*ntext"));
            //ddlSearchColumn.Items.Add(new ListItem("DiaChi - ", "DiaChi*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("DienThoai - ", "DienThoai*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("Email - ", "Email*nvarchar"));
            //ddlSearchColumn.Items.Add(new ListItem("ThuTu - ", "ThuTu*int"));
            //ddlSearchColumn.DataBind();
            //ddlSColumnDoanhNhanThanhDat.DataBind();
        }
        protected void btnSearchColumn_Click(object sender, EventArgs e)
        {
            //if (txtSDoanhNhanThanhDat.Text.Trim() == "") return;
            //grd_showDoanhNhanThanhDat.DataSource = DoanhNhanThanhDatService.DoanhNhanThanhDat_SearchColumn(txtSDoanhNhanThanhDat.Text.Trim(), ddlSearchColumn.SelectedValue, ddlSColumnDoanhNhanThanhDat.SelectedValue);
            //grd_showDoanhNhanThanhDat.DataBind();

        }
        private void Loadgrd_showDoanhNhanThanhDat()
        {
            grd_showDoanhNhanThanhDat.DataSource = DoanhNhanThanhDatService.DoanhNhanThanhDat_GetByTop("","","ThuTu");
            grd_showDoanhNhanThanhDat.DataBind();

        }
        protected void grd_showDoanhNhanThanhDat_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showDoanhNhanThanhDat.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showDoanhNhanThanhDat();
        }
        #endregion

        #region Validate
        private bool KtTen()
        {
            lblerrorTen.Text = "";
            return true;
        }
        //private bool KtAnh()
        //{
        //    lblerrorAnh.Text = "";
        //    return true;
        //}
        //private bool KtGioiThieu()
        //{
        //    lblerrorGioiThieu.Text = "";
        //    return true;
        //}
        //private bool KtDiaChi()
        //{
        //    lblerrorDiaChi.Text = "";
        //    return true;
        //}
        //private bool KtDienThoai()
        //{
        //    lblerrorDienThoai.Text = "";
        //    return true;
        //}
        //private bool KtEmail()
        //{
        //    lblerrorEmail.Text = "";
        //    return true;
        //}
        private bool KtThuTu()
        {
            if (!string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                try
                {
                    var so = long.Parse(txtThuTu.Text);
                }
                catch
                {
                    lblerrorThuTu.Text = " là số nguyên";
                    return false;
                }
            lblerrorThuTu.Text = "";
            return true;
        }
        #endregion

    }
}