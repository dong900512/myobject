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
using System.Data.Objects.SqlClient;
namespace NewInfoWeb.manage.Manager_LiveInfo
{
    public partial class BDMSBannerList : System.Web.UI.Page
    {
        protected int count = 0;
        public int typid = DNTRequest.RequstInt("tid") == 0 ? 5 : DNTRequest.RequstInt("tid");
        protected string stTitle = string.Empty;
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

            }
            BindRepeater();
            WebConn.ManageInfoType sex = (WebConn.ManageInfoType)typid;
            switch (sex)
            {
                case WebConn.ManageInfoType.半岛美食:
                    stTitle = WebConn.ManageInfoType.半岛美食.ToString();
                    break;
                case WebConn.ManageInfoType.万宁四诊:
                    stTitle = WebConn.ManageInfoType.万宁四诊.ToString();
                    break;
                case WebConn.ManageInfoType.其他美食:
                    stTitle = WebConn.ManageInfoType.其他美食.ToString();
                    break;
                case WebConn.ManageInfoType.特色小吃:
                    stTitle = WebConn.ManageInfoType.特色小吃.ToString();
                    break;
                case WebConn.ManageInfoType.美食餐厅:
                    stTitle = WebConn.ManageInfoType.美食餐厅.ToString();
                    break;
            }
            string reqStrUrl = "BDMSList.aspx?tid=" + typid;
            //if (Request.UrlReferrer != null)
            //{
            //    reqStrUrl = Request.UrlReferrer.ToString();
            //}
            btn_Back.Attributes.Add("onclick", "window.location.href='" + reqStrUrl + "';return false;");


        }

        private void BindRepeater()
        {
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
                var tmpid = typid + "";
                IQueryable<AResource> carlist = db.AResource.Where(s => s.Extend.Equals(tmpid)).OrderBy(s => s.ArticleID).ThenBy(o => o.RId);

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
        ///// <summary>
        ///// 查询信息
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    BindRepeater();
        //}
    }
}