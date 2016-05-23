using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WX.Utils;
using WXEF;
using PopedomAuditService;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class ManageBasePage : System.Web.UI.Page
{
    public ManageBasePage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    #region 处理cookie过期信息
    protected override void OnInit(EventArgs e)
    {


        if (string.IsNullOrEmpty(loginname) || UserId < 0)
        {
            jsHint.toUrl("请登录后进行操作", "/manage/admin_login.aspx");
            //jsHint.Alert("当前登录名:" + loginname);
            //jsHint.Alert("当前登录ID:" + UserId);
            return;
        }
        if (globalVariables.PopedomAudit.ToLower() == "true")
        {
            string filePath = Request.Url.LocalPath.ToLower();
            string fileName = filePath.Substring(filePath.LastIndexOf("/") + 1);

            string tmpUrl = filePath.Substring(0, filePath.LastIndexOf("/"));
            string directoryName = tmpUrl.Substring(tmpUrl.LastIndexOf("/") + 1);

            if (directoryName == "manage" && fileName == "frame.aspx")
            {
                return;
            }

            int uid = UserId;
            using (WXDBEntities db = new WXDBEntities())
            {
                //IList<ModuleItem> moduleItem = BookFairService.Instance.GetTBySample<ModuleItem>(new object[] { Expression.Eq("DefaultUrl", directoryName) });
                IList<ModuleItem> moduleItem = db.ModuleItem.Where(m => m.DefaultUrl.ToLower() == directoryName).ToList();
                if (moduleItem.Count > 0)
                {
                    //IList<PageItem> pageItem = BookFairService.Instance.GetTBySample<PageItem>(new object[] { Expression.Eq("ModuleItemBy.ID", moduleItem[0].ID), Expression.Eq("Url", fileName) });
                    int mid = moduleItem[0].ModuleID;
                    IList<PageItem> pageItem = db.PageItem.Where(p => p.ModuleID == mid && p.Url.ToLower() == fileName).ToList();
                    if (pageItem.Count > 0)
                    {
                        int pid = pageItem[0].ItemID;
                        //IList<AccountUnionPage> aup = BookFairService.Instance.GetTBySample<AccountUnionPage>(new object[] { Expression.Eq("PageItemBy.ID", pageItem[0].ID), Expression.Eq("SysAccountBy.ID", uid) });
                        IList<AccountUnionPage> aup = db.AccountUnionPage.Where(a => a.ItemID == pid && a.AccountID == uid).ToList();
                        if (aup.Count == 0)
                        {
                            jsHint.toUrl("/manage/err.aspx?e=1");
                        }
                    }
                    else
                    {
                        jsHint.toUrl("/manage/err.aspx?e=2");
                    }
                }
                else
                {
                    jsHint.toUrl("/manage/err.aspx?e=3");
                }
            }
        }
    }
    #endregion
    #region 处理cookie信息
    /// <summary>
    /// 获取Cookie中的登陆用户唯一ID
    /// </summary>
    public int UserId
    {
        get
        {
            int returnUserId = -1;

            if (Request.Cookies["hdmdWXmanageDomain"] != null && !string.IsNullOrEmpty(Request.Cookies["hdmdWXmanageDomain"]["userid"]))
            {
                returnUserId = int.Parse(Request.Cookies["hdmdWXmanageDomain"]["userid"]);
            }
            return returnUserId;
        }
    }

    /// <summary>
    /// 获取登录的用户名
    /// </summary>
    public string loginname
    {
        get
        {
            string returnUsername = string.Empty;
            if (Request.Cookies["hdmdWXmanageDomain"] != null && !string.IsNullOrEmpty(Request.Cookies["hdmdWXmanageDomain"]["loginname"]))
            {
                returnUsername = Request.Cookies["hdmdWXmanageDomain"]["loginname"];
            }
            return returnUsername;
        }
    }
    #endregion
}