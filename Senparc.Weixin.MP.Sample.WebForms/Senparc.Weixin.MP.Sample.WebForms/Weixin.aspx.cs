using Bll;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.Configuration;

namespace Senparc.Weixin.MP.Sample.WebForms
{

 

    public partial class Weixin : System.Web.UI.Page
    {
        public static readonly string Appid = WebConfigurationManager.AppSettings["WeixinAppId"];
        public static readonly string secret = WebConfigurationManager.AppSettings["WeixinAppSecret"];
        public static readonly string Token = WebConfigurationManager.AppSettings["WeixinToken"];
        //香兰坊用的token也是weixin_xinshui

        protected void Page_Load(object sender, EventArgs e)
        {
            string signature = base.Request["signature"];
            string timestamp = base.Request["timestamp"];
            string nonce = base.Request["nonce"];
            string str = base.Request["echostr"];
            if (base.Request.HttpMethod == "GET")
            {
                if (CheckSignature.Check(signature, timestamp, nonce, Token))
                {
                    this.WriteContent(str);
                }
                else
                {
                    this.WriteContent("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
                }
                base.Response.End();
            }
            else
            {
                Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler.CustomMessageHandler messageHandler;
                if (!CheckSignature.Check(signature, timestamp, nonce, WebConfigurationManager.AppSettings["WeixinToken"]))
                {
                    this.WriteContent("参数错误！");
                }
                else
                {
                    PostModel postModel = new PostModel
                    {
                        Signature = base.Request.QueryString["signature"],
                        Msg_Signature = base.Request.QueryString["msg_signature"],
                        Timestamp = base.Request.QueryString["timestamp"],
                        Nonce = base.Request.QueryString["nonce"],
                        Token = Token,
                        EncodingAESKey = WebConfigurationManager.AppSettings["WeixinEncodingAESKey"],
                        AppId = Appid
                    };
                    int maxRecordCount = 10;
                    messageHandler = new Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler.CustomMessageHandler(base.Request.InputStream, postModel, maxRecordCount);
                    int num2 = 0;
                    try
                    {
                        object[] objArray1 = new object[] { "~/App_Data/", DateTime.Now.Ticks, "_Request_", messageHandler.RequestMessage.FromUserName, ".txt" };
                        //messageHandler.RequestDocument.Save(base.Server.MapPath(string.Concat(objArray1)));
                        if (messageHandler.RequestMessage.MsgType.ToString().ToLower() != "event")
                        {
                            base.Application.Lock();
                            messageHandler.Execute();
                            base.Application.UnLock();
                        }
                        else
                        {
                            IRequestMessageEventBase requestMessage = messageHandler.RequestMessage as IRequestMessageEventBase;
                            if (requestMessage.Event == Event.subscribe)
                            {
                                base.Application.Lock();
                                messageHandler.Execute();
                                base.Application.UnLock();
                            }
                            else
                            {
                                messageHandler.Execute();
                            }
                        }
                        num2 = 6;
                        if (messageHandler.ResponseMessage != null)
                        {
                            object[] objArray2 = new object[] { "~/App_Data/", DateTime.Now.Ticks, "_Response_", messageHandler.ResponseMessage.ToUserName, ".txt" };
                            messageHandler.ResponseDocument.Save(base.Server.MapPath(string.Concat(objArray2)));
                            this.WriteContent(messageHandler.ResponseDocument.ToString());
                        }
                        num2 = 7;
                    }
                    catch (Exception exception)
                    {
                        using (TextWriter writer = new StreamWriter(base.Server.MapPath("~/App_Data/Error_" + DateTime.Now.Ticks + ".txt")))
                        {
                            writer.WriteLine(string.Concat(new object[] { exception.ToString(), "step:", num2, "." }));
                            writer.WriteLine(exception.InnerException.ToString());
                            if (messageHandler.ResponseDocument != null)
                            {
                                writer.WriteLine(messageHandler.ResponseDocument.ToString());
                            }
                            writer.Flush();
                            writer.Close();
                        }
                    }
                    finally
                    {
                        base.Response.End();
                    }
                }
            }
        }
        

        private void WriteContent(string str)
        {
            Response.Output.Write(str);
        }

        /// <summary>
        /// 最简单的Page_Load写法（本方法仅用于演示过程，针对未加密消息，未实际在DEMO演示中使用到）
        /// </summary>
        private void MiniProcess()
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
                    WriteContent("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token));
                }

            }
            else
            {
                //post method - 当有用户想公众账号发送消息时触发
                if (!CheckSignature.Check(signature, timestamp, nonce, Token))
                {
                    WriteContent("参数错误！");
                }

                //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
                var messageHandler = new CustomMessageHandler(Request.InputStream, null);
                //执行微信处理过程
                messageHandler.Execute();
                //输出结果
                WriteContent(messageHandler.ResponseDocument.ToString());
            }
            Response.End();
        }
    }
}