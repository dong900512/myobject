using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WX.Utils;
using WXEF;
using PopedomAuditService;
using NewInfoWeb.Appcode;
using System.Web.Configuration;

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
        try
        {
            if (string.IsNullOrEmpty(loginname) || UserId < 0)
            {
                Response.Write("<script language='javascript'>window.alert('非法登陆系统!');location.href='" + ResolveUrl("~/") + "manage/admin_login.aspx';</script>");
                Response.End();
            }
        }
        catch (Exception ex)
        {
            //jsHint.Alert(ex.Message);
            //Response.Write("<script language='javascript'>window.alert('异常登陆系统1!');location.href='" + ResolveUrl("~/") + "manage/admin_login.aspx';</script>");
            //Response.End();
        }
        base.OnInit(e);
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

            if (CookieHelper.ISNull(WebConfigurationManager.AppSettings["ManageDomain"]) && CookieHelper.ISNullCurVal(WebConfigurationManager.AppSettings["ManageDomain"], "userid"))
            {
                returnUserId = Convert.ToInt32(CookieHelper.Read(WebConfigurationManager.AppSettings["ManageDomain"], "userid"));
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
            if (CookieHelper.ISNull(WebConfigurationManager.AppSettings["ManageDomain"]) && CookieHelper.ISNullCurVal(WebConfigurationManager.AppSettings["ManageDomain"], "loginname"))
            {
                returnUsername = CookieHelper.Read(WebConfigurationManager.AppSettings["ManageDomain"], "loginname");
            }
            return returnUsername;
        }
    }

    /// <summary>
    /// 获取权限ID
    /// </summary>
    public int GetDutyId
    {
        get
        {
            int returnUserId = -1;
            try
            {
                if (CookieHelper.ISNull(WebConfigurationManager.AppSettings["ManageDomain"]) && CookieHelper.ISNullCurVal(WebConfigurationManager.AppSettings["ManageDomain"], "DutyId"))
                {
                    returnUserId = Convert.ToInt32(CookieHelper.Read(WebConfigurationManager.AppSettings["ManageDomain"], "DutyId"));
                }

            }
            catch (Exception)
            {
                Response.Write("<script language='javascript'>window.alert('异常登陆系统2!');location.href='" + ResolveUrl("~/") + "manage/admin_login.aspx';</script>");
                Response.End();
            }
            return returnUserId;
        }
    }

    /// <summary>
    /// 获取当前管理员城市编码
    /// </summary>
    public string CityNo
    {
        get
        {
            string cityPNoinfo = string.Empty;
            if (CookieHelper.ISNull(WebConfigurationManager.AppSettings["ManageDomain"]) && CookieHelper.ISNullCurVal(WebConfigurationManager.AppSettings["ManageDomain"], "CityNo"))
            {
                cityPNoinfo = CookieHelper.Read(WebConfigurationManager.AppSettings["ManageDomain"], "CityNo");
            }
            return cityPNoinfo;
        }
    }

    /// <summary>
    /// 获取项目ID
    /// </summary>
    public string ProjiectNo
    {
        get
        {
            string projectNoinfo = string.Empty;
            if (CookieHelper.ISNull(WebConfigurationManager.AppSettings["ManageDomain"]) && CookieHelper.ISNullCurVal(WebConfigurationManager.AppSettings["ManageDomain"], "ProjectNo"))
            {
                projectNoinfo = CookieHelper.Read(WebConfigurationManager.AppSettings["ManageDomain"], "ProjectNo");
            }
            return projectNoinfo;
        }
    }
    #endregion
}