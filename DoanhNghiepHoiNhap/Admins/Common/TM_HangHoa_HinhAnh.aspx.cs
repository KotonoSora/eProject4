using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;

namespace DoanhNghiepHoiNhap.Admins
{
    /// <summary>
    /// Created By:
    /// Created Date:
    /// Edit By:
    /// Edit Date:
    /// Description:
    /// </summary>
    public partial class TM_HangHoa_HinhAnh : Page
    {
        #region Private Variable

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                    Response.Redirect("~/Admins/TM/TM_HangHoa.aspx");
                Loadgrd_showTM_HangHoa_HinhAnh(); 
                Insert.Checked = false;  
                ltrSanPham.Text = TM_HangHoaService.TM_HangHoa_GetById(Request.QueryString["id"]).Rows[0]["TenSP"].ToString();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pn_showTM_HangHoa_HinhAnh.Visible = false;
            pn_updateTM_HangHoa_HinhAnh.Visible = true;
            Insert.Checked = true;
            txtImgUrl.Text = "";
            imgHinhAnh.ImageUrl = "";
            txtMoTa.Text = "";
            txtThuTu.Text = ""; 
        } 

        protected void LbtCancel_Click(object sender, EventArgs e)
        {
            pn_showTM_HangHoa_HinhAnh.Visible = true;
            pn_updateTM_HangHoa_HinhAnh.Visible = false; 
            lblerrorMoTa.Text = "";
            lblerrorThuTu.Text = ""; 
        }

        protected void LbtUpdate_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            bool kt = true;
            bool ktP = true; 
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
                    TM_HangHoa_HinhAnhService.TM_HangHoa_HinhAnh_Insert(txtImgUrl.Text, txtMoTa.Text, txtThuTu.Text,Request.QueryString["id"]);
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
                    TM_HangHoa_HinhAnhService.TM_HangHoa_HinhAnh_Update(ViewState["Id"].ToString(), txtImgUrl.Text,
                                                                        txtMoTa.Text, txtThuTu.Text, Request.QueryString["id"]);
                }
                catch
                {
                    WebMsgBox.Show("Lỗi :");
                    return;
                }
            }
            Loadgrd_showTM_HangHoa_HinhAnh();
            pn_showTM_HangHoa_HinhAnh.Visible = true;
            pn_updateTM_HangHoa_HinhAnh.Visible = false;
        }

        protected void grd_showTM_HangHoa_HinhAnh_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string[] strViewState = e.CommandArgument.ToString().Split(',');
            ViewState["Id"] = strViewState[0];
            switch (e.CommandName.Trim())
            {
                case "Edit":
                    Insert.Checked = false;
                    DataTable dt = TM_HangHoa_HinhAnhService.TM_HangHoa_HinhAnh_GetById(ViewState["Id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtImgUrl.Text = dt.Rows[0]["HinhAnh"].ToString();
                        imgHinhAnh.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();
                        txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                        txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString(); 
                    }
                    dt.Clear();
                    pn_showTM_HangHoa_HinhAnh.Visible = false;
                    pn_updateTM_HangHoa_HinhAnh.Visible = true;
                    break;
                case "Delete":
                    TM_HangHoa_HinhAnhService.TM_HangHoa_HinhAnh_Delete(ViewState["Id"].ToString());
                    Loadgrd_showTM_HangHoa_HinhAnh();
                    break;
                default:
                    break;
            }
        }

        protected void grd_showTM_HangHoa_HinhAnh_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grd_showTM_HangHoa_HinhAnh.ClientID + "_row" + e.Item.ItemIndex;
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

        #endregion

        #region Methods 

        private void Loadgrd_showTM_HangHoa_HinhAnh()
        {
            grd_showTM_HangHoa_HinhAnh.DataSource = TM_HangHoa_HinhAnhService.TM_HangHoa_HinhAnh_GetByTop("", "HangHoa="+Request.QueryString["id"], "Id desc");
            grd_showTM_HangHoa_HinhAnh.DataBind();
        }

        protected void grd_showTM_HangHoa_HinhAnh_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grd_showTM_HangHoa_HinhAnh.CurrentPageIndex = e.NewPageIndex;
            Loadgrd_showTM_HangHoa_HinhAnh();
        } 

        #endregion

        #region Validate 

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