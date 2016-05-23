using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;
using System.Collections.Generic;
using WXEF;

/// <summary>
/// DeleteValidate 的摘要说明
/// </summary>
public class DeleteValidate
{
    public DeleteValidate()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static bool ValidateDeleteForm(string pageName)
    {
        using (WXDBEntities db = new WXDBEntities())
        {
            int accountID =new DeleteValidate().ThisUserId;
            IList<PageItem> pagelist = db.PageItem.Where(p => p.Url == pageName).ToList();
            if (pagelist.Count == 0)
                return false;

            int pageitemid = pagelist[0].ItemID;
            IList<AccountUnionPage> aplist = db.AccountUnionPage.Where(a => a.AccountID == accountID && a.ItemID == pageitemid).ToList();
            if (aplist.Count == 1)
                return true;
            else
                return false;
        }
    }
    public int ThisUserId
    {
        get
        {
            int returnUserId = -1;
            if (HttpContext.Current.Request.Cookies["luzhumanageDomain"] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["luzhumanageDomain"]["userid"]))
            {
                returnUserId = int.Parse(HttpContext.Current.Request.Cookies["luzhumanageDomain"]["userid"]);
            }
            return returnUserId;
        }
    }
}

