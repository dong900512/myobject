using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dos.ORM;
using Dos.Model;
using Dos.Common;
using WX.Utils;

namespace NewInfoWeb.wsinfo.ashx
{
    /// <summary>
    /// helperInfo 的摘要说明
    /// </summary>
    public class helperInfo : IHttpHandler
    {

        protected HttpContext _ct;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _ct = context;
            var type = _ct.Request.Form["type"];
            switch (type)
            {
                case "getBanner":
                    GetBannerList();
                    break;

                case "allist":
                    GetALList();
                    break;
            }
        }
        /// <summary>
        /// 得到案例列表信息
        /// </summary>
        private void GetALList()
        {
            int tyid = 0;
            int.TryParse(_ct.Request.Form["typid"], out tyid);
            int page = 0;
            int pagesize = 8;
            int.TryParse(_ct.Request.Form["tmppage"], out page);
            if (page < 1)
                page = 0;
            int.TryParse(_ct.Request.Form["pagesize"], out pagesize);
            int skipsize = page * pagesize;
            int tmpage = page + 1;
            FromSection<Forms> fromsection = DbSession.Default.From<Forms>()
              .Where(s => !s.Status.Equals(2) && s.Type.Equals(tyid))
              .OrderBy(s => s.Orders).OrderByDescending(s => s.AddTime);
            var list = fromsection.Page(pagesize, tmpage).ToList();
            List<object> listDesc = new List<object>();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    listDesc.Add(new
                    {
                        id = item.Id,
                        img = globalVariables.NewsImgServer + item.Income,
                        title = item.Title,
                        desc = item.Remark,
                        url = item.Source
                    });
                }
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = list.Count });
                _ct.Response.Write(jsonstrlist);
            }
            else
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                _ct.Response.Write(jsonstrlist);
            }
        }

        private void GetBannerList()
        {
            FromSection<Forms> fromsection = DbSession.Default.From<Forms>()
            .Where(s => s.Type.Equals(22))
            .OrderBy(s => s.AddTime);
            var list = fromsection.SetCacheTimeOut(5000).ToList();
            List<object> listDesc = new List<object>();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    listDesc.Add(new
                    {
                        id = item.Id,
                        title = item.Title,
                        url = item.Source,
                        img = globalVariables.NewsImgServer + item.Income
                    });
                }
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = list.Count });
                _ct.Response.Write(jsonstrlist);
            }
            else
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                _ct.Response.Write(jsonstrlist);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}