using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;

namespace NewInfoWeb.manage.SysMaintenance
{
    public partial class PasswordEdit : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (UserId < 0)
                {
                    jsHint.toUrl(" 参数不合法！", "/manage/admin_login.aspx");
                    return;
                }

                InitCtrls();
            }

            ((maintenancemaster)this.Master).txtTitle = "帐号信息修改";
            btnBack.Attributes.Add("onclick", "window.location.href='AccountList.aspx';return false;");
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void InitCtrls()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                int id = UserId;
                SysAccount xSysAccount = db.SysAccount.Where(a => a.AccountID == id).FirstOrDefault();

                txtLoginName.Text = xSysAccount.LoginName;
                txtMail.Text = xSysAccount.Email;
                txtMobile.Text = xSysAccount.Mobile;
                txtPhone.Text = xSysAccount.Phone;
                txtRealName.Text = xSysAccount.RealName;
            }
        }

        /// <summary>
        /// 保存修改后的帐号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                int id = UserId;
                SysAccount xSysAccount = db.SysAccount.Where(a => a.AccountID == id).FirstOrDefault();

                xSysAccount.LoginName = txtLoginName.Text;

                if (!string.IsNullOrEmpty(txtPass.Text))
                {
                    xSysAccount.Password = Encrypt.MD5(txtPass.Text);
                    xSysAccount.Status = (byte)1;
                }

                xSysAccount.Email = txtMail.Text;
                xSysAccount.Mobile = txtMobile.Text;
                xSysAccount.Phone = txtPhone.Text;
                xSysAccount.RealName = txtRealName.Text;

                db.SaveChanges();
            }
            jsHint.toUrl("帐号信息" + txtLoginName.Text + "修改成功!", "PasswordEdit.aspx");
        }

    }
}