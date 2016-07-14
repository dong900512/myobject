using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;

namespace NewInfoWeb.manage.SysMaintenance
{
    public partial class AccountAdd : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((NewInfoWeb.manage.SysMaintenance.maintenancemaster)this.Master).txtTitle = "帐号信息增加";
            btnBack.Attributes.Add("onclick", "window.location.href='AccountList.aspx';return false;");

        }


        /// <summary>
        /// 管理员增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var adminlist = db.SysAccount.Where(s => s.LoginName.Contains(txtLoginName.Text)).ToList();
                //IList adminlist = SessionBuilder.Instance.GetSession().CreateCriteria(typeof(SysAccount)).Add(Expression.Eq("LoginName", txtLoginName.Text)).List();

                if (adminlist.Count > 0)
                {
                    jsHint.Back("管理员名重复！");
                    return;
                }

                //IList list = SessionBuilder.Instance.GetSession().CreateCriteria(typeof(MemberInfo)).Add(Expression.Eq("MemberName", txtLoginName.Text)).List();

                //if (list.Count > 0)
                //{
                //    lbPass.Text = "确认继续>>";
                //    ltl_link.Text = string.Format(ltl_link.Text, globalVariables.curSiteRoot, (list[0] as MemberInfo).ID);

                //    lbPass.Visible = true;
                //    ltl_link.Visible = true;
                //    pBtn.Visible = false;

                //    txtPass.Text = txtPass.Text;

                //    return;
                //}

                CreateAccount();
                //CreateMember();

                if (string.IsNullOrEmpty(Request.QueryString["type"]))
                    jsHint.toUrl("帐号信息" + txtLoginName.Text + "增加成功!", "AccountList.aspx");
                else
                    jsHint.toUrl("帐号信息" + txtLoginName.Text + "增加成功!", Request.UrlReferrer.OriginalString);
            }
        }


        /// <summary>
        /// 当存在前台会员信息时候点确认后的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbPass_Click(object sender, EventArgs e)
        {
            CreateAccount();
            //CreateMember();

            if (string.IsNullOrEmpty(Request.QueryString["type"]))
                jsHint.toUrl("帐号信息" + txtLoginName.Text + "增加成功!", "AccountList.aspx");
            else
                jsHint.toUrl("帐号信息" + txtLoginName.Text + "增加成功!", Request.UrlReferrer.OriginalString);
        }

        /// <summary>
        /// 创建会员信息
        /// </summary>
        #region private void CreateMember()
        private void CreateMember()
        {
            //MemberInfo member = new MemberInfo();

            //member.MemberName = txtLoginName.Text;
            //member.MemberPass = txtPass.Text;
            //member.MemberEmail = txtMail.Text;
            //member.HeadPortrait = "demo01.gif";
            //member.PortraitType = (byte)0;
            //member.UserSex = "男";
            //member.Homepage = "";
            //member.BestNums = 0;

            //member.RegTime = DateTime.Now;
            //member.UserBirthday = DateTime.Now;
            //member.PublicMailbox = true;

            //DomainFactory.Instance.GetMemberInfoDomain().Save(member);
        }
        #endregion


        /// <summary>
        /// 创建管理员帐号
        /// </summary>
        #region private void CreateAccount()
        private void CreateAccount()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                SysAccount xSysAccount = new SysAccount();

                xSysAccount.LoginName = txtLoginName.Text;
                xSysAccount.Password = Encrypt.MD5(txtPass.Text);
                xSysAccount.Email = txtMail.Text;
                xSysAccount.Mobile = txtMobile.Text;
                xSysAccount.Phone = txtPhone.Text;

                xSysAccount.LastLoginTime = DateTime.Now;
                xSysAccount.LoginNums = 0;
                xSysAccount.Status = (byte)0;
                xSysAccount.RealName = txtRealName.Text;
                //xSysAccount.OrderPop = "";
                db.SysAccount.AddObject(xSysAccount);
                db.SaveChanges();
                InitAccount(xSysAccount.AccountID);
            }
        }
        #endregion


        private void InitAccount(int Id)
        {
            //jsHint.Alert(Id.ToString());
            //IAccountUnionPageDomain xIAccountUnionPageDomain = DomainFactory.Instance.GetAccountUnionPageDomain();

            //ISysAccountDomain xISysAccountDomain = DomainFactory.Instance.GetSysAccountDomain();
            //IPageItemDomain xIPageItemDomain = DomainFactory.Instance.GetPageItemDomain();

            //AccountUnionPage xAccountUnionPage = new AccountUnionPage(xISysAccountDomain.GetById(Id, false),xIPageItemDomain.GetById(int.Parse(page), false));

            //xAccountUnionPage.Crud = "";

            //xIAccountUnionPageDomain.Save(xAccountUnionPage);
        }
    }
}