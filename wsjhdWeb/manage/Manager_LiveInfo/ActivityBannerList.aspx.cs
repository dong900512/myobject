﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.Manager_LiveInfo
{
    public partial class ActivityBannerList : System.Web.UI.Page
    {
        protected int count = 0;
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
                BindRepeater();
            }
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
                IQueryable<AResource> carlist = db.AResource.Where(s => s.Extend.Equals("0")).OrderBy(s => s.ArticleID).ThenBy(o => o.RId);


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