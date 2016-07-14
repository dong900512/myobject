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
    /// 获取信息类别信息
    /// </summary>
    public enum ManageInfoType
    {
        活动信息 = 0,
        快递服务 = 1,
        综合便民服务 = 2,
        配套热线半岛商业 = 3,
        配套热线半岛酒店 = 4,
        半岛美食 = 5,
        万宁四诊 = 6,
        其他美食 = 7,
        特色小吃 = 8,
        美食餐厅 = 9,
        高铁 = 10,
        公共交通 = 11,
        车租赁 = 12,
        自驾车租赁 = 13,
        万宁站租车服务 = 14,
        自行车租赁 = 15,
        ucrad租赁 = 16,
        半岛住宿 = 17,
        半岛游玩 = 18,
        游玩类型 = 19,
        富饶特产 = 20,
        滨海风情餐饮购物街 = 21,
        健康管理 = 22,
        用户注册协议 = 23,
        兴趣标签 = 24,
        积分规则 = 25,
        社区公告 = 26,
        报修记录 = 27
    }
    /// <summary>
    /// 轮播Banner信息
    /// </summary>
    public enum AreSourceId
    {
        活动信息 = 0
    }
    /// <summary>
    /// 点赞类别
    /// </summary>
    public enum DzType
    {
        兴趣爱好 = 0
    }

    /// <summary>
    /// Form Type 类别
    /// </summary>
    public enum FormInfoType
    {
        活动信息 = 0,
        便民服务 = 1,
        兴趣爱好 = 2,
        会员信息 = 8
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