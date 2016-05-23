using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

using System.Xml.Linq;
using System.Net;
using WX.Utils;
using WXEF;
using Senparc.Weixin.MP.Agent;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.AdvancedAPIs.User;
namespace Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler
{
    /// <summary>
    /// 自定义MessageHandler
    /// </summary>
    public partial class CustomMessageHandler
    {
        private string GetWelcomeInfo()
        {
            //获取Senparc.Weixin.MP.dll版本信息
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(HttpContext.Current.Server.MapPath("~/bin/Senparc.Weixin.MP.dll"));
            var version = string.Format("{0}.{1}", fileVersionInfo.FileMajorPart, fileVersionInfo.FileMinorPart);
            return string.Format(
@"欢迎关注【Senparc.Weixin.MP 微信公众平台SDK】，当前运行版本：v{0}。
您可以发送【文字】【位置】【图片】【语音】等不同类型的信息，查看不同格式的回复。

您也可以直接点击菜单查看各种类型的回复。

SDK官方地址：http://weixin.senparc.com
源代码及Demo下载地址：https://github.com/JeffreySu/WeiXinMPSDK
Nuget地址：https://www.nuget.org/packages/Senparc.Weixin.MP",
                version);
        }

        public override IResponseMessageBase OnTextOrEventRequest(RequestMessageText requestMessage)
        {
            // 预处理文字或事件类型请求。
            // 这个请求是一个比较特殊的请求，通常用于统一处理来自文字或菜单按钮的同一个执行逻辑，
            // 会在执行OnTextRequest或OnEventRequest之前触发，具有以下一些特征：
            // 1、如果返回null，则继续执行OnTextRequest或OnEventRequest
            // 2、如果返回不为null，则终止执行OnTextRequest或OnEventRequest，返回最终ResponseMessage
            // 3、如果是事件，则会将RequestMessageEvent自动转为RequestMessageText类型，其中RequestMessageText.Content就是RequestMessageEvent.EventKey

            if (requestMessage.Content == "OneClick")
            {
                return null;
            }
            return null;//返回null，则继续执行OnTextRequest或OnEventRequest
        }

        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase reponseMessage = null;
            //菜单点击，需要跟创建菜单时的Key匹配
            switch (requestMessage.EventKey)
            {
                case "OneClick":
                    {
                        ////这个过程实际已经在OnTextOrEventRequest中完成，这里不会执行到。
                        //var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        //reponseMessage = strongResponseMessage;
                        //strongResponseMessage.Content = "您点击了底部按钮。\r\n为了测试微信软件换行bug的应对措施，这里做了一个——\r\n换行";
                    }
                    break;
                case "SubClickRoot_Text":
                    {
                        //var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        //reponseMessage = strongResponseMessage;
                        //strongResponseMessage.Content = "您点击了子菜单按钮。";
                    }
                    break;
                case "SubClickRoot_News":
                    {
                        //var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
                        //reponseMessage = strongResponseMessage;
                        //strongResponseMessage.Articles.Add(new Article()
                        //{
                        //    Title = "您点击了子菜单图文按钮",
                        //    Description = "您点击了子菜单图文按钮，这是一条图文信息。",
                        //    PicUrl = "http://weixin.senparc.com/Images/qrcode.jpg",
                        //    Url = "http://weixin.senparc.com"
                        //});
                    }
                    break;
                case "SubClickRoot_Music":
                    {
                        ////上传缩略图
                        //var accessToken = CommonAPIs.AccessTokenContainer.TryGetToken(appId, appSecret);
                        //var uploadResult = AdvancedAPIs.Media.MediaApi.Upload(accessToken, UploadMediaFileType.thumb,
                        //                                             Server.GetMapPath("~/Images/Logo.jpg"));
                        ////设置音乐信息
                        //var strongResponseMessage = CreateResponseMessage<ResponseMessageMusic>();
                        //reponseMessage = strongResponseMessage;
                        //strongResponseMessage.Music.Title = "天籁之音";
                        //strongResponseMessage.Music.Description = "真的是天籁之音";
                        //strongResponseMessage.Music.MusicUrl = "http://weixin.senparc.com/Content/music1.mp3";
                        //strongResponseMessage.Music.ThumbMediaId = uploadResult.thumb_media_id;
                    }
                    break;
                case "SubClickRoot_Customer":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        using (WXDBEntities db = new WXDBEntities())
                        {
                            var tmp = db.WXKewWords.Where(s => s.Type == 0).FirstOrDefault();
                            if (tmp != null)
                            {
                                strongResponseMessage.Content = tmp.Description;
                            }
                            else
                            {
                                strongResponseMessage.Content = "你好，欢迎关注恒大御景湾 !";
                                //\r\n输入序号快速了解我们\r\n[1]查看项目投资方\r\n[2]查看户型\r\n[3]查看交通,\r\n加入誉天下会，尊享更多优惠！\r\n<a href=\"http://zhengrong.tencenthouse.com/member/registerMember.aspx\">马上加入》》》</a>
                            }
                        }
                    }
                    break;
                case "SubClick_sh":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "开盘时间待定，敬请关注官方微信。";
                    }
                    break;
                case "SubClick_xs":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "销售热线：021-60259333";
                    }
                    break;
                case "SubClick_jt":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "来访动线：\r\n1、地铁11号线，马陆站2号出口（出口前进20米，到阿克苏南路后右转）；\r\n2、市区方向：\r\n（1）您可以就近上中环高架，转S5沪嘉高速至【马陆】出口下，左转至【宝安公路】，然后到【永盛南路】左转，根据我们的道旗指引就到了。\r\n（2）沪翔高速：S6沪翔高速至【永盛路出口】下，至永盛南路向北行驶再右转，根据我们的道旗指引就到了。\r\n3、使用手机【高德导航】，搜索“恒大御景湾”根据指示即可到达";
                    }
                    break;
                case "SubClick_xm":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "项目地址：嘉定区马陆镇【阿克苏南路】与【合作南路】交汇处东50米。";
                    }
                    break;
                case "SubClickRoot_Image":
                    {
                        //上传图片
                        //var accessToken = CommonAPIs.AccessTokenContainer.TryGetToken(appId, appSecret);
                        //var uploadResult = AdvancedAPIs.Media.MediaApi.Upload(accessToken, UploadMediaFileType.image,
                        //                                             Server.GetMapPath("~/Images/Logo.jpg"));
                        ////设置图片信息
                        //var strongResponseMessage = CreateResponseMessage<ResponseMessageImage>();
                        //reponseMessage = strongResponseMessage;
                        //strongResponseMessage.Image.MediaId = uploadResult.media_id;
                        //return null;
                    }
                    break;
                case "SubClickRoot_Agent"://代理消息
                    {
                        //获取返回的XML
                        DateTime dt1 = DateTime.Now;
                        reponseMessage = MessageAgent.RequestResponseMessage(this, agentUrl, agentToken, RequestDocument.ToString());
                        //上面的方法也可以使用扩展方法：this.RequestResponseMessage(this,agentUrl, agentToken, RequestDocument.ToString());

                        DateTime dt2 = DateTime.Now;

                        if (reponseMessage is ResponseMessageNews)
                        {
                            return null;
                        }
                    }
                    break;
                case "Member"://托管代理会员信息
                    {
                        //原始方法为：MessageAgent.RequestXml(this,agentUrl, agentToken, RequestDocument.ToString());//获取返回的XML
                        //return null;
                    }
                    break;
                case "OAuth"://OAuth授权测试
                    {
                        //return null;
                    }
                    break;
                case "Description":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        strongResponseMessage.Content = GetWelcomeInfo();
                        reponseMessage = strongResponseMessage;
                    }
                    break;
                default:
                    {
                        // return null;
                    }
                    break;
            }

            return reponseMessage;
        }

        public override IResponseMessageBase OnEvent_EnterRequest(RequestMessageEvent_Enter requestMessage)
        {
            return null;
        }

        public override IResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
        {
            return null;
        }

        /// <summary>
        /// 扫描关注
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScanRequest(RequestMessageEvent_Scan requestMessage)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = db.QrCodeInfo.Where(s => s.WXOpenid.Equals(requestMessage.FromUserName) && s.QrCodeReslut.Equals(requestMessage.EventKey)).FirstOrDefault();
                if (model != null)
                {

                }
                else
                {
                    model = new QrCodeInfo();
                    try
                    {
                        model.WXOpenid = requestMessage.FromUserName;
                    }
                    catch (Exception)
                    {
                        model.WXOpenid = "";
                    }
                    try
                    {
                        //UserInfoJson us = UserApi.Info(WXhelper.Instance.CurrenToken(), requestMessage.FromUserName);
                        //model.NickName = us.nickname;
                        //model.Extent1 = us.province + "|" + us.city;
                        model.NickName = "";
                        model.Extent1 = "";
                    }
                    catch (Exception)
                    {
                        model.NickName = "";
                        model.Extent1 = "";
                    }
                    try
                    {
                        model.QrCodeReslut = requestMessage.EventKey;
                    }
                    catch (Exception)
                    {
                        model.QrCodeReslut = "1";
                    }
                    model.Status = 0;
                    model.Orders = 0;
                    model.AddTime = DateTime.Now;
                    model.UpdateTime = DateTime.Now;
                    model.Extent2 = "";
                    db.QrCodeInfo.AddObject(model);
                    db.SaveChanges();
                }
            }
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

            using (WXDBEntities db = new WXDBEntities())
            {
                var tmp = db.WXKewWords.Where(s => s.Type == 0).FirstOrDefault();
                if (tmp != null)
                {
                    responseMessage.Content = tmp.Description;
                }
                else
                {
                    responseMessage.Content = "你好，感谢您关注东郊罗兰 !";
                }
            }
            return responseMessage;
        }

        public override IResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage)
        {
            //说明：这条消息只作为接收，下面的responseMessage到达不了客户端，类似OnEvent_UnsubscribeRequest
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您点击了view按钮，将打开网页：" + requestMessage.EventKey;
            return responseMessage;
        }

        public override IResponseMessageBase OnEvent_MassSendJobFinishRequest(RequestMessageEvent_MassSendJobFinish requestMessage)
        {
            return null;
        }

        /// <summary>
        /// 订阅（关注）事件
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            if (requestMessage.EventKey.Contains("qrscene"))
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    string t = requestMessage.EventKey.Replace("qrscene_", "");
                    var model = db.QrCodeInfo.Where(s => s.WXOpenid.Equals(requestMessage.FromUserName) && s.QrCodeReslut.Equals(t)).FirstOrDefault();
                    if (model != null)
                    {

                    }
                    else
                    {
                        model = new QrCodeInfo();
                        try
                        {
                            model.WXOpenid = requestMessage.FromUserName;
                        }
                        catch (Exception)
                        {
                            model.WXOpenid = "";
                        }
                        try
                        {
                            model.NickName = "";
                            model.Extent1 = "";
                            //UserInfoJson us = UserApi.Info(WXhelper.Instance.CurrenToken(), requestMessage.FromUserName);
                            //model.NickName = us.nickname;
                            //model.Extent1 = us.province + "|" + us.city;
                        }
                        catch (Exception)
                        {
                            model.NickName = "";
                            model.Extent1 = "";
                        }
                        try
                        {
                            model.QrCodeReslut = requestMessage.EventKey.Replace("qrscene_", "");
                        }
                        catch (Exception)
                        {
                            model.QrCodeReslut = "1";
                        }
                        model.Status = 0;
                        model.Orders = 0;
                        model.AddTime = DateTime.Now;
                        model.UpdateTime = DateTime.Now;

                        model.Extent2 = "";
                        db.QrCodeInfo.AddObject(model);
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var model = db.QrCodeInfo.Where(s => s.WXOpenid.Equals(requestMessage.FromUserName) && s.QrCodeReslut == "1").FirstOrDefault();
                    if (model != null)
                    {

                    }
                    else
                    {
                        model = new QrCodeInfo();
                        try
                        {
                            model.WXOpenid = requestMessage.FromUserName;
                        }
                        catch (Exception)
                        {
                            model.WXOpenid = "";
                        }
                        try
                        {
                            //UserInfoJson us = UserApi.Info(WXhelper.Instance.CurrenToken(), requestMessage.FromUserName);
                            //model.NickName = us.nickname;
                            //model.Extent1 = us.province + "|" + us.city;
                            model.NickName = "";
                            model.Extent1 = "";
                        }
                        catch (Exception)
                        {
                            model.NickName = "";
                            model.Extent1 = "";
                        }
                        model.QrCodeReslut = "1";
                        model.Status = 0;
                        model.Orders = 0;
                        model.AddTime = DateTime.Now;
                        model.UpdateTime = DateTime.Now;

                        model.Extent2 = "";
                        db.QrCodeInfo.AddObject(model);
                        db.SaveChanges();
                    }
                }
            }
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

            using (WXDBEntities db = new WXDBEntities())
            {
                var tmp = db.WXKewWords.Where(s => s.Type == 0).FirstOrDefault();
                if (tmp != null)
                {
                    responseMessage.Content = tmp.Description;
                }
                else
                {
                    responseMessage.Content = "你好，感谢您关注东郊罗兰 !";
                }
            }
            return responseMessage;
        }

        /// <summary>
        /// 退订
        /// 实际上用户无法收到非订阅账号的消息，所以这里可以随便写。
        /// unsubscribe事件的意义在于及时删除网站应用中已经记录的OpenID绑定，消除冗余数据。并且关注用户流失的情况。
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "有空再来";
            return responseMessage;
        }

        /// <summary>
        /// 事件之扫码推事件(scancode_push)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodePushRequest(RequestMessageEvent_Scancode_Push requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之扫码推事件";
            return responseMessage;
        }

        /// <summary>
        /// 事件之扫码推事件且弹出“消息接收中”提示框(scancode_waitmsg)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodeWaitmsgRequest(RequestMessageEvent_Scancode_Waitmsg requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之扫码推事件且弹出“消息接收中”提示框";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出拍照或者相册发图（pic_photo_or_album）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_PicPhotoOrAlbumRequest(RequestMessageEvent_Pic_Photo_Or_Album requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出拍照或者相册发图";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出系统拍照发图(pic_sysphoto)
        /// 实际测试时发现微信并没有推送RequestMessageEvent_Pic_Sysphoto消息，只能接收到用户在微信中发送的图片消息。
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_PicSysphotoRequest(RequestMessageEvent_Pic_Sysphoto requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出系统拍照发图";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出微信相册发图器(pic_weixin)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_PicWeixinRequest(RequestMessageEvent_Pic_Weixin requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出微信相册发图器";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出地理位置选择器（location_select）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_LocationSelectRequest(RequestMessageEvent_Location_Select requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出地理位置选择器";
            return responseMessage;
        }
    }
}