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
    public partial class AccountList : ManageBasePage
    {
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["refresh"]) && !string.IsNullOrEmpty(Request.QueryString["rId"]))
                {
                    //PdmCollection.Instance.RebuildPdm();
                    jsHint.toUrl("权限分配完毕！", "AccountList.aspx");
                }

                // 处理删除操作
                if (!string.IsNullOrEmpty(Request.QueryString["del"]) && WebUtil.IsDigit(Request.QueryString["del"]))
                {
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        int tmpid = int.Parse(Request.QueryString["del"]);
                        IList<AccountUnionPage> xList = db.AccountUnionPage.Where(a => a.AccountID == tmpid).ToList();
                        if (xList.Count > 0)
                        {
                            foreach (var a in xList)
                            {
                                db.AccountUnionPage.DeleteObject(a);
                                db.SaveChanges();
                            }
                        }
                        var model = db.SysAccount.Where(s => s.AccountID == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            db.SysAccount.DeleteObject(model);
                            db.SaveChanges();
                        }
                        jsHint.toUrl("删除成功！", "AccountList.aspx");
                        //MaintenanceService.Instance.DeleteAccountById(int.Parse(Request.QueryString["del"]));
                    }
                }
                using (WXDBEntities db = new WXDBEntities())
                {
                    // 进行数据绑定
                    List<SysAccount> list = db.SysAccount.ToList();
                    WebUtil.CtrlToList<SysAccount>(rptAccount, list);
                }
            }
            ((maintenancemaster)this.Master).txtTitle = "帐号管理";
        }
    }
}