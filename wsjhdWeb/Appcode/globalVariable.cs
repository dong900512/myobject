using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

using PopedomAuditService;

/// <summary>
/// globalVariable 的摘要说明
/// </summary>
public class globalVariables
{
    static globalVariables()
    {
        cursiteroot = InitVariables();
        fileserver = PdmConfiguration.FileServer;
    }

    private static string cursiteroot = "";
    private static string fileserver = "";

    public static string curSiteRoot
    {
        get
        {
            return cursiteroot;
        }
    }

    public static string curUri
    {
        get { return HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.OriginalString); }
    }

    private static string InitVariables()
    {
        //int len = 0;
        //string curAppPath = "";
        //try
        //{
        //    curAppPath = HttpContext.Current.Request.Url.AbsoluteUri;

        //    if (HttpContext.Current.Request.ApplicationPath != "/")
        //    {
        //        len = HttpContext.Current.Request.ApplicationPath.Length + 1;
        //        return curAppPath.Substring(0, curAppPath.IndexOf(HttpContext.Current.Request.ApplicationPath) + len);
        //    }
        //    else
        //    {
        //        len = HttpContext.Current.Request.Url.PathAndQuery.Length + 1;
        //        return curAppPath.Substring(0, curAppPath.LastIndexOf(HttpContext.Current.Request.Url.PathAndQuery)) + "/";
        //    }
        //}
        //catch (Exception) { return "~/"; }
        return "/";
    }

    public static string fileServer
    {
        get { return PdmConfiguration.Settings("FileServer") + "/" + PdmConfiguration.Settings("FileServerPath") + "/"; }
    }

    /// <summary>
    /// 返回文件上传的外层目录名
    /// </summary>
    public static string FileDir
    {
        get { return PdmConfiguration.FileDir; }
    }

    public static string SysDirString
    {
        get { return FileDir + PdmConfiguration.Settings("SysDir"); }
    }

    /// <summary>
    /// 后台管理的名称
    /// </summary>
    public static string ManageAddress
    {
        get { return PdmConfiguration.Settings("WebAddress"); }
    }

    /// <summary>
    /// 4S中心代码 1花木 2御桥 3 苏州
    /// </summary>
    public static string WebCode
    {
        get { return PdmConfiguration.Settings("WebCode"); }
    }

    /// <summary>
    /// 车系图片保存路径
    /// </summary>
    public static string SeriesImgPath
    {
        get { return FileDir + PdmConfiguration.Settings("SeriesImg") + "\\"; }
    }

    /// <summary>
    /// 车型图保存路径
    /// </summary>
    public static string CarImgPath
    {
        get { return FileDir + PdmConfiguration.Settings("CarImg") + "\\"; }
    }

    /// <summary>
    /// 配件图片保存路径
    /// </summary>
    public static string FitImgPath
    {
        get { return FileDir + PdmConfiguration.Settings("FitImg") + "\\"; }
    }

    /// <summary>
    /// 二手车信息
    /// </summary>
    public static string SecondPath
    {
        get { return FileDir + PdmConfiguration.Settings("Second") + "\\"; }
    }

    /// <summary>
    /// 新闻图片
    /// </summary>
    public static string NewsImgPath
    {
        get { return FileDir + PdmConfiguration.Settings("NewsImg") + "\\"; }
    }

    /// <summary>
    /// 新闻图片URL
    /// </summary>
    public static string NewsImgServer {

        get { return fileServer + PdmConfiguration.Settings("NewsImg") + "/"; }

    }


    /// <summary>
    /// 活动图片路径
    /// </summary>
    public static string ActiveImgPath
    {
        get { return FileDir + PdmConfiguration.Settings("ActiveImg") + "\\"; }
    }

    /// <summary>
    /// 服务明星 全景展示
    /// </summary>
    public static string IndexImgPath
    {
        get { return FileDir + PdmConfiguration.Settings("IndexImg") + "\\"; }
    }

    /// <summary>
    /// 视频路径
    /// </summary>
    public static string VideosPath
    {
        get { return FileDir + PdmConfiguration.Settings("Videos") + "\\"; }
    }

    /// <summary>
    /// 竞拍xml文件夹路径
    /// </summary>
    public static string Auctionxmlpath
    {
        get { return PdmConfiguration.Settings("auctionxmlpath"); }
    }

    /// <summary>
    /// 滚动颜色
    /// </summary>
    public static string ScrollColorXml
    {
        get { return PdmConfiguration.Settings("ScrollColorXml"); }
    }

    /// <summary>
    /// 是否启用后台验证
    /// </summary>
    public static string PopedomAudit
    {
        get { return PdmConfiguration.Settings("PopedomAudit"); }
    }

    /// <summary>
    /// 寄卖二手车图片Url
    /// </summary>
    public static string SellOldCarUrl
    {
        get { return PdmConfiguration.Settings("SellOldCarUrl"); }
    }
}
