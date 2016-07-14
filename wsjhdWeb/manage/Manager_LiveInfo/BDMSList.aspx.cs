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
    public partial class BDMSList : System.Web.UI.Page
    {
        public int typid = DNTRequest.RequstInt("tid") == 0 ? 5 : DNTRequest.RequstInt("tid");
        protected int count = 0;
        protected string sttitle = string.Empty;
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
            if (typid != -1)
            {
                WebConn.ManageInfoType sex = (WebConn.ManageInfoType)typid;
                switch (sex)
                {
                    case WebConn.ManageInfoType.半岛美食:
                        sttitle = WebConn.ManageInfoType.半岛美食.ToString();
                        break;
                    case WebConn.ManageInfoType.万宁四诊:
                        sttitle = WebConn.ManageInfoType.万宁四诊.ToString();
                        break;
                    case WebConn.ManageInfoType.其他美食:
                        sttitle = WebConn.ManageInfoType.其他美食.ToString();
                        break;
                    case WebConn.ManageInfoType.特色小吃:
                        sttitle = WebConn.ManageInfoType.特色小吃.ToString();
                        break;
                    case WebConn.ManageInfoType.美食餐厅:
                        sttitle = WebConn.ManageInfoType.美食餐厅.ToString();
                        break;
                }

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
                IQueryable<Article> carlist = db.Article.Where(s => (!s.Status.Equals(2)) && s.Type.Equals(typid)).OrderBy(o => o.Orders).ThenBy(o => o.AritcleID);

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