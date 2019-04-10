using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoanhNghiepHoiNhap.Business;
using DoanhNghiepHoiNhap.Common;
using DoanhNghiepHoiNhap.Data;
using DoanhNghiepHoiNhap.Languages;

namespace DoanhNghiepHoiNhap.Admins
{
    public partial class GuiEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lang"] == null) Session["lang"] = "1";
            //ddlPhamVi.Items.Clear();
            //ddlPhamVi.Items.Add(new ListItem(Lang.Show("allcustomers"),"1"));
            //ddlPhamVi.Items.Add(new ListItem(Lang.Show("choosecus"), "2"));
           
        }

        protected void btnGui_Click(object sender, EventArgs e)
        {
            if (txtTieuDe.Text.Trim()=="" || txtNoiDung.Text.Trim()=="")
            {
                WebMsgBox.Show("Vui lòng nhập tiêu đề và nội dung");
                return;
            }
            if (ddlPhamVi.SelectedValue == "1")
            {
                string email = "";
                DataTable dt = SqlDataProvider.GetTable("select distinct Mail from TT_LienHe");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    email += dt.Rows[0]["Mail"] + ",";
                }
                email = email.Remove(email.Length - 1, 1);
                SendMail(email);
            }
            else
            {
                string email = "";
                for (int i = 0; i < dgvLienHe.Items.Count; i++)
                {
                    CheckBox cb = (CheckBox)dgvLienHe.Items[i].FindControl("chkSelect");
                    if (cb.Checked)
                    {
                        Label lb = (Label)dgvLienHe.Items[i].FindControl("txtEmail");
                        email += lb.Text + ",";
                    }
                }
                email = email.Remove(email.Length - 1, 1);
                SendMail(email);
            }
        }

        protected void ddlPhamVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPhamVi.SelectedValue=="1")
            {
                dgvLienHe.Visible = false;
            }
            else
            {
                dgvLienHe.Visible = true;
                dgvLienHe.DataSource = SqlDataProvider.GetTable("select distinct Mail from TT_LienHe");
                dgvLienHe.DataBind(); 
            }
        }

        public void SendMail(string to)
        {
            DataTable dtconfig = TT_CauHinhChungService.TT_CauHinhChung_GetAll();
            string email = dtconfig.Rows[0]["Email"].ToString();
            string password = dtconfig.Rows[0]["Password"].ToString();
            if (email.Trim()=="" || password.Trim()=="")
            {
                WebMsgBox.Show("Vui lòng cấu hình Email và Password gửi!");
                return;
            }

            var smtpServer = new SmtpClient
                                 {
                                     Credentials = new NetworkCredential(email, password),
                                     Port = 587,
                                     Host = "smtp.gmail.com",
                                     EnableSsl = true
                                 };
            var mail = new MailMessage();
            String[] addr = to.Split(',');
            try
            {
                mail.From = new MailAddress(email, txtTieuDe.Text, Encoding.UTF8);
                Byte i;
                for (i = 0; i < addr.Length; i++)
                    mail.To.Add(addr[i]);
                mail.Subject = txtTieuDe.Text;
                mail.Body = txtNoiDung.Text;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(to);
                smtpServer.Send(mail);

                WebMsgBox.Show("Gửi thành công "+addr.Length +" email");
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}