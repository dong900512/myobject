using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP;
using System.Web.Configuration;
using System.Xml.Linq;
using Senparc.Weixin.MP.Entities.Request;
using System.IO;
using Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler;
namespace NewInfoWeb
{
    public partial class weixin : System.Web.UI.Page
    {
        private readonly string Token = WebConfigurationManager.AppSettings["APPToken"];//与微信公众账号后台的Token设置保持一致，区分大小写。
        private readonly string EncodingAESKey = WebConfigurationManager.AppSettings["AesKey"];//aeskey
        private readonly string AppId = WebConfigurationManager.AppSettings["AppId"];//appid
        protected void Page_Load(object sender, EventArgs e)
        {
            string signature = Request["signature"];
            string timestamp = Request["timestamp"];
            string nonce = Request["nonce"];
            string echostr = Request["echostr"];

            if (Request.HttpMethod == "GET")
            {
                //get method - 仅在微信后台填写URL验证时触发
                if (CheckSignature.Check(signature, timestamp, nonce, Token))
                {
                    WriteContent(echostr); //返回随机字符串则表示验证通过
                }
                else
                {
                    WriteContent("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token) + "。" +
                                "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
                }
                Response.End();
            }
            else
            {
                //post method - 当有用户想公众账号发送消息时触发
                if (!CheckSignature.Check(signature, timestamp, nonce, Token))
                {
                    WriteContent("参数错误！");
                    return;
                }
                var postModel = new PostModel()
                {
                    Signature = Request.QueryString["signature"],
                    Msg_Signature = Request.QueryString["msg_signature"],
                    Timestamp = Request.QueryString["timestamp"],
                    Nonce = Request.QueryString["nonce"],
                    //以下保密信息不会（不应该）在网络上传播，请注意
                    Token = WebConfigurationManager.AppSettings["APPToken"],
                    EncodingAESKey = WebConfigurationManager.AppSettings["AesKey"],//根据自己后台的设置保持一致
                    AppId = WebConfigurationManager.AppSettings["AppId"]//根据自己后台的设置保持一致
                };

                //v4.2.2之后的版本，可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制
                var maxRecordCount = 2;

                //自定义MessageHandler，对微信请求的详细判断操作都在这里面
                //测试时可开启此记录，帮助跟踪数据

                var messageHandler = new CustomMessageHandler(Request.InputStream, postModel, maxRecordCount);

                try
                {
                    //测试时可开启此记录，帮助跟踪数据
                    messageHandler.RequestDocument.Save(
                        Server.MapPath("~/dll/" + DateTime.Now.Ticks + "_Request_" +
                                       messageHandler.RequestMessage.FromUserName + ".txt"));
                    //执行微信处理过程
                    //if (messageHandler.UsingEcryptMessage)
                    //{
                    //    messageHandler.EcryptRequestDocument.Save(Server.MapPath("~/App_Data/" + DateTime.Now.Ticks + "_Request_Ecrypt_" + messageHandler.RequestMessage.FromUserName + ".txt"));
                    //}
                    // messageHandler.UsingEcryptMessage = true;
                    messageHandler.Execute();
                    //测试时可开启，帮助跟踪数据
                    messageHandler.ResponseDocument.Save(
                        Server.MapPath("~/dll/" + DateTime.Now.Ticks + "_Response_" +
                                       messageHandler.ResponseMessage.ToUserName + ".txt"));
                    if (messageHandler.UsingEcryptMessage)
                    {
                        //记录加密后的响应信息
                        messageHandler.FinalResponseDocument.Save(Server.MapPath("~/dll/" + DateTime.Now.Ticks + "_Response_Final_" + messageHandler.ResponseMessage.ToUserName + ".txt"));
                    }
                    WriteContent(messageHandler.FinalResponseDocument.ToString());
                    return;
                }
                catch (Exception ex)
                {
                    using (TextWriter tw = new StreamWriter(Server.MapPath("~/dll/Error_" + DateTime.Now.Ticks + ".txt")))
                    {
                        tw.WriteLine(ex.Message);
                        tw.WriteLine(ex.InnerException.Message);
                        if (messageHandler.ResponseDocument != null)
                        {
                            tw.WriteLine(messageHandler.ResponseDocument.ToString());
                        }
                        tw.Flush();
                        tw.Close();
                    }
                    WriteContent("");
                }
                finally
                {
                    Response.End();
                }
            }
        }
        //输出信息
        private void WriteContent(string str)
        {
            Response.Output.Write(str);
        }
    }
}