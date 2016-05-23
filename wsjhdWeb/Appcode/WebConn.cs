using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.TenPayLib;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.Entities;
/// <summary>
///WebConn 的摘要说明
/// </summary>
public class WebConn
{
    public WebConn()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //

    }
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 待支付
        /// </summary>
        Tobepaid = 0,
        /// <summary>
        /// 支付中
        /// </summary>
        Paying = 1,
        /// <summary>
        /// 支付成功
        /// </summary>
        Paied = 2,
        /// <summary>
        /// 支付失败
        /// </summary>
        Failed = 3
    }
    /// <summary>
    /// 会员级别
    /// </summary>
    public enum MembersLevel
    {
        /// <summary>
        /// 普通
        /// </summary>
        PT,
        /// <summary>
        /// 银卡
        /// </summary>
        YK,
        /// <summary>
        /// 金卡
        /// </summary>
        JK,
        /// <summary>
        /// 白金
        /// </summary>
        BJ
    }
    /// <summary>
    /// 积分兑换券
    /// </summary>
    public enum DuQuan
    {
        /// <summary>
        /// 游泳券
        /// </summary>
        YY = 210,
        /// <summary>
        /// 迷你吧抵用券
        /// </summary>
        MN = 300,
        /// <summary>
        /// 下午茶券
        /// </summary>
        XWC = 408,
        /// <summary>
        /// 客房抵用券
        /// </summary>
        KF = 600,
        /// <summary>
        /// 138元自助餐券
        /// </summary>
        ZZ = 828
    }


    private static TenPayInfo _tenPayInfo;

    public static TenPayInfo TenPayInfo
    {
        get
        {
            if (_tenPayInfo == null)
            {
                _tenPayInfo =
                    new TenPayInfo(System.Configuration.ConfigurationManager.AppSettings["WeixinPay_PartnerId"], System.Configuration.ConfigurationManager.AppSettings["WeixinPay_Key"], System.Configuration.ConfigurationManager.AppSettings["WeixinPay_AppId"], System.Configuration.ConfigurationManager.AppSettings["WeixinPay_AppKey"], System.Configuration.ConfigurationManager.AppSettings["WeixinPay_TenpayNotify"]);

                //TenPayInfoCollection.Data[System.Configuration.ConfigurationManager.AppSettings["WeixinPay_PartnerId"]];
            }
            return _tenPayInfo;
        }
    }

    public static bool GetBoolAdinfo(string logininfo)
    {
        return System.Configuration.ConfigurationManager.AppSettings["adinfo"].ToString().Contains(logininfo);
    }
}