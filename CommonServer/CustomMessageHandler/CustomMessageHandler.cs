using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Configuration;
using Senparc.Weixin.MP.Agent;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Helpers;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using WX.Utils;
using WXEF;
using Senparc.Weixin.MP.AdvancedAPIs;
using System.Text.RegularExpressions;
namespace Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler
{
    public partial class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        /*
         * 重要提示：v1.5起，MessageHandler提供了一个DefaultResponseMessage的抽象方法，
         * DefaultResponseMessage必须在子类中重写，用于返回没有处理过的消息类型（也可以用于默认消息，如帮助信息等）；
         * 其中所有原OnXX的抽象方法已经都改为虚方法，可以不必每个都重写。若不重写，默认返回DefaultResponseMessage方法中的结果。
         */


#if DEBUG
        string agentUrl = "http://localhost:12222/App/Weixin/4";
        string agentToken = "27C455F496044A87";
        string wiweihiKey = "CNadjJuWzyX5bz5Gn+/XoyqiqMa5DjXQ";
#else
        //下面的Url和Token可以用其他平台的消息，或者到www.weiweihi.com注册微信用户，将自动在“微信营销工具”下得到
        private string agentUrl = WebConfigurationManager.AppSettings["WeixinAgentUrl"];//这里使用了www.weiweihi.com微信自动托管平台
        private string agentToken = WebConfigurationManager.AppSettings["WeixinAgentToken"];//Token
        private string wiweihiKey = WebConfigurationManager.AppSettings["WeixinAgentWeiweihiKey"];//WeiweihiKey专门用于对接www.Weiweihi.com平台，获取方式见：http://www.weiweihi.com/ApiDocuments/Item/25#51
#endif

        private string appId = WebConfigurationManager.AppSettings["WeixinAppId"];
        private string appSecret = WebConfigurationManager.AppSettings["WeixinAppSecret"];

        public CustomMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            //比如MessageHandler<MessageContext>.GlobalWeixinContext.ExpireMinutes = 3。
            WeixinContext.ExpireMinutes = 3;
        }

        public override void OnExecuting()
        {
            //测试MessageContext.StorageData
            if (CurrentMessageContext.StorageData == null)
            {
                CurrentMessageContext.StorageData = 0;
            }
            base.OnExecuting();
        }

        public override void OnExecuted()
        {
            base.OnExecuted();
            CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        }

        /// <summary>
        /// 处理文字请求
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            //TODO:这里的逻辑可以交给Service处理具体信息，参考OnLocationRequest方法或/Service/LocationSercice.cs

            //方法一（v0.1），此方法调用太过繁琐，已过时（但仍是所有方法的核心基础），建议使用方法二到四
            //var responseMessage =
            //    ResponseMessageBase.CreateFromRequestMessage(RequestMessage, ResponseMsgType.Text) as
            //    ResponseMessageText;

            //方法二（v0.4）
            //var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(RequestMessage);

            //方法三（v0.4），扩展方法，需要using Senparc.Weixin.MP.Helpers;
            //var responseMessage = RequestMessage.CreateResponseMessage<ResponseMessageText>();

            //方法四（v0.6+），仅适合在HandlerMessage内部使用，本质上是对方法三的封装
            //注意：下面泛型ResponseMessageText即返回给客户端的类型，可以根据自己的需要填写ResponseMessageNews等不同类型。
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();

            if (requestMessage.Content == null)
            {
                return responseMessage;
            }
            //else if (requestMessage.Content == "约束")
            //{
            //    responseMessage.Content =
            //        "<a href=\"http://weixin.senparc.com/FilterTest/\">点击这里</a>进行客户端约束测试（地址：http://weixin.senparc.com/FilterTest/）。";
            //}
            //else if (requestMessage.Content == "托管" || requestMessage.Content == "代理")
            //{
            //    //开始用代理托管，把请求转到其他服务器上去，然后拿回结果
            //    //甚至也可以将所有请求在DefaultResponseMessage()中托管到外部。

            //    DateTime dt1 = DateTime.Now; //计时开始

            //    var responseXml = MessageAgent.RequestXml(this, agentUrl, agentToken, RequestDocument.ToString());
            //    //获取返回的XML
            //    //上面的方法也可以使用扩展方法：this.RequestResponseMessage(this,agentUrl, agentToken, RequestDocument.ToString());

            //    /* 如果有WeiweihiKey，可以直接使用下面的这个MessageAgent.RequestWeiweihiXml()方法。
            //     * WeiweihiKey专门用于对接www.weiweihi.com平台，获取方式见：http://www.weiweihi.com/ApiDocuments/Item/25#51
            //     */
            //    //var responseXml = MessageAgent.RequestWeiweihiXml(weiweihiKey, RequestDocument.ToString());//获取Weiweihi返回的XML

            //    DateTime dt2 = DateTime.Now; //计时结束

            //    //转成实体。
            //    /* 如果要写成一行，可以直接用：
            //     * responseMessage = MessageAgent.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
            //     * 或
            //     * 
            //     */
            //    responseMessage = responseXml.CreateResponseMessage() as ResponseMessageText;

            //    responseMessage.Content += string.Format("\r\n\r\n代理过程总耗时：{0}毫秒", (dt2 - dt1).Milliseconds);
            //}
            //else if (requestMessage.Content == "测试" || requestMessage.Content == "退出")
            //{
            //    /* 
            //    * 这是一个特殊的过程，此请求通常来自于微微嗨（http://www.weiweihi.com）的“盛派网络小助手”应用请求（http://www.weiweihi.com/User/App/Detail/1），
            //    * 用于演示微微嗨应用商店的处理过程，由于微微嗨的应用内部可以单独设置对话过期时间，所以这里通常不需要考虑对话状态，只要做最简单的响应。
            //    */
            //    if (requestMessage.Content == "测试")
            //    {
            //        //进入APP测试
            //        responseMessage.Content = "您已经进入【盛派网络小助手】的测试程序，请发送任意信息进行测试。发送文字【退出】退出测试对话。10分钟内无任何交互将自动退出应用对话状态。";
            //    }
            //    else
            //    {
            //        //退出APP测试
            //        responseMessage.Content = "您已经退出【盛派网络小助手】的测试程序。";
            //    }
            //}
            else
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var tmp = db.WXKewWords.Where(s => s.Type == 1).Where(s => s.Title.Equals(requestMessage.Content)).FirstOrDefault();
                    if (tmp != null)
                    {
                        responseMessage.Content = tmp.Description;
                        return responseMessage;
                    }
                    else
                    {
                        //if (requestMessage.Content.Equals("1"))
                        //{
                        //    var strongResponseMessage = base.CreateResponseMessage<ResponseMessageNews>();
                        //    strongResponseMessage.Articles.Add(new Senparc.Weixin.MP.Entities.Article()
                        //    {
                        //        Title = "恒大地产  中国地产十强  精品地产领导者",
                        //        Description = "恒大地产  中国地产十强  精品地产领导者",
                        //        PicUrl = "http://hdyjw.tencenthouse.com/images/st.png",
                        //        Url = "http://mp.weixin.qq.com/s?__biz=MzAxNzMyODgyMQ==&mid=209370458&idx=1&sn=97d8836a68e75be78ba34e3839b6ec21#rd"
                        //    });
                        //    return strongResponseMessage;
                        responseMessage.Content = "你好，感谢您关注东郊罗兰  !";
                        return responseMessage;
                    }
                }
            }
        }

        ///// <summary>
        ///// 处理位置请求
        ///// </summary>
        ///// <param name="requestMessage"></param>
        ///// <returns></returns>
        //public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        //{
        //    IResponseMessageBase reponseMessage = null;
        //    return reponseMessage;
        //}

        /// <summary>
        /// 处理图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
           var  reponseMessage = base.CreateResponseMessage<ResponseMessageText>();
           reponseMessage.Content = "";
            return reponseMessage;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        //{
        //    IResponseMessageBase reponseMessage = null;
        //    return reponseMessage;
        //}
        ///// <summary>
        ///// 处理视频请求
        ///// </summary>
        ///// <param name="requestMessage"></param>
        ///// <returns></returns>
        //public override IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
        //{
        //    IResponseMessageBase reponseMessage = null;
        //    return reponseMessage;
        //}

        ///// <summary>
        ///// 处理链接消息请求
        ///// </summary>
        ///// <param name="requestMessage"></param>
        ///// <returns></returns>
        //public override IResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage)
        //{
        //    IResponseMessageBase reponseMessage = null;
        //    return reponseMessage;
        //}

        /// <summary>
        /// 处理事件请求（这个方法一般不用重写，这里仅作为示例出现。除非需要在判断具体Event类型以外对Event信息进行统一操作
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //public override IResponseMessageBase OnEventRequest(IRequestMessageEventBase requestMessage)
        //{
        //    var eventResponseMessage = base.OnEventRequest(requestMessage);//对于Event下属分类的重写方法，见：CustomerMessageHandler_Events.cs
        //    //TODO: 对Event信息进行统一操作
        //    return eventResponseMessage;
        //}

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            //var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            //responseMessage.Content = "";
            return null;
        }
    }
}
