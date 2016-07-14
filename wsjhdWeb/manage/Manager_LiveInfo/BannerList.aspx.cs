using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
using NewInfoWeb.Appcode;
namespace NewInfoWeb.manage.Manager_LiveInfo
{
    public partial class BannerList : System.Web.UI.Page
    {
        protected int count = 0;
        protected string stTitle = string.Empty;
        protected int stypid = DNTRequest.RequstInt("typid");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        AResource model = //DbSession.Default.From<Article>().Where(s => s.AritcleID.Equals(tmpid)).ToFirstDefault();
                db.AResource.Where(s => s.RId == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            //model.Attach();
                            db.AResource.DeleteObject(model);
                            //model. = 2;
                            //model.UpdateTime = DateTime.Now;
                            // int ts = DbSession.Default.Update<Article>(model);
                            db.SaveChanges();
                        }
                    }
                }
                hidtype.Value = stypid + "";
                BindRepeater();
            }
            int tmpid1 = Convert.ToInt32(hidtype.Value);
            WebConn.ManageInfoType sex = (WebConn.ManageInfoType)tmpid1;
            string reqStrUrl = string.Empty;
            switch (sex)
            {
                case WebConn.ManageInfoType.半岛住宿:
                    stTitle = WebConn.ManageInfoType.半岛住宿.ToString();
                    //reqStrUrl = "BDZSList.aspx";//"BDMSList.aspx?tid=" + hidtype.Value;
                    break;
                case WebConn.ManageInfoType.富饶特产:
                    stTitle = WebConn.ManageInfoType.富饶特产.ToString();
                    break;
                case WebConn.ManageInfoType.滨海风情餐饮购物街:
                    stTitle = WebConn.ManageInfoType.滨海风情餐饮购物街.ToString();
                    break;
            }
            reqStrUrl = "BDZSList.aspx?tid=" + stypid;
            btn_Back.Attributes.Add("onclick", "window.location.href='" + reqStrUrl + "';return false;");
        }

        private void BindRepeater()
        {
            string tmptypid = hidtype.Value;
            int page = AspNetPager1.CurrentPageIndex;
            if (!this.IsPostBack)
            {
                if (Request["page"] + "" != "")
                    page = int.Parse(Request["page"] + "");
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                //FromSection<Article> fromsection = DbSession.Default.From<Article>()
                //     .Where(s => (!s.Status.Equals(2)) && s.Type.In(1, 2, 3, 4))
                //     .OrderBy(Article._.Orders.Asc, Article._.AritcleID.Asc);
                IQueryable<AResource> carlist = db.AResource.Where(s => s.Extend.Equals(tmptypid)).OrderBy(s => s.ArticleID).ThenBy(o => o.RId);
                var dblist = carlist.ToPagedList(page, AspNetPager1.PageSize);
                //fromsection.ToPagedList(page, AspNetPager1.PageSize);
                AspNetPager1.RecordCount = dblist.TotalItemCount;// fromsection.Count();
                ltlCount.Text = "<b>" + dblist.TotalItemCount + "</b>";
                if (!this.IsPostBack)
                {
                    if (Request["page"] + "" != "")
                    {
                        int temp = int.Parse(Request["page"] + "");
                        AspNetPager1.CurrentPageIndex = temp;
                    }
                }
                WebUtil.CtrlToList<AResource>(rptLoop, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater();
        }

    }
}