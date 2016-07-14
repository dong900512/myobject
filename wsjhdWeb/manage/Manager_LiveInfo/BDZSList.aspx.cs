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
    public partial class BDZSList : System.Web.UI.Page
    {
        protected int count = 0;
        protected int typid = DNTRequest.RequstInt("tid");
        protected string stitle = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {

                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        Article model = db.Article.Where(s => s.AritcleID == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            model.Status = 2;
                            //string strsql = "update Article set status=1 where Type=" + model.ID;
                            //db.ExecuteStoreCommand(strsql);
                            //db.ArticleType.DeleteObject(model);
                            db.SaveChanges();
                        }
                    }
                }
                BindRepeater(typid);
            }
            WebConn.ManageInfoType sex = (WebConn.ManageInfoType)typid;
            switch (sex)
            {
                case WebConn.ManageInfoType.半岛住宿:
                    stitle = WebConn.ManageInfoType.半岛住宿.ToString();
                    break;
                case WebConn.ManageInfoType.富饶特产:
                    stitle = WebConn.ManageInfoType.富饶特产.ToString();
                    break;
                case WebConn.ManageInfoType.滨海风情餐饮购物街:
                    stitle = WebConn.ManageInfoType.滨海风情餐饮购物街.ToString();
                    break;
            }
        }

        private void BindRepeater(int typid)
        {
            int page = AspNetPager1.CurrentPageIndex;
            if (!this.IsPostBack)
            {
                if (Request["page"] + "" != "")
                    page = int.Parse(Request["page"] + "");
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                IQueryable<Article> carlist = db.Article.Where(s => (!s.Status.Equals(2)) && s.Type.Equals(typid)).OrderBy(o => o.Orders).ThenByDescending(o => o.AritcleID);

                if (!string.IsNullOrEmpty(txtKeywords.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.Title.Contains(txtKeywords.Text));
                }
                var dblist = carlist.ToPagedList(page, AspNetPager1.PageSize);
                AspNetPager1.RecordCount = dblist.TotalItemCount;
                ltlCount.Text = "<b>" + dblist.TotalItemCount + "</b>";

                if (!this.IsPostBack)
                {
                    if (Request["page"] + "" != "")
                    {
                        int temp = int.Parse(Request["page"] + "");
                        AspNetPager1.CurrentPageIndex = temp;
                    }
                }
                WebUtil.CtrlToList<Article>(rptLoop, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater(typid);
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindRepeater(typid);
        }
    }
}