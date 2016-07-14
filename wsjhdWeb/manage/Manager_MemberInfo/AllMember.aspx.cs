using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.Manager_MemberInfo
{
    public partial class AllMember : ManageBasePage
    {
        public int TotalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        Forms model = db.Forms.Where(s => s.Id.Equals(tmpid)).FirstOrDefault();
                        if (model != null)
                        {
                            db.Forms.DeleteObject(model);
                            db.SaveChanges();
                        }
                    }
                }
                RptBind();
            }
        }

        #region 数据列表绑定
        private void RptBind()
        {
            int page = AspNetPager1.CurrentPageIndex;
            if (!this.IsPostBack)
            {
                if (Request["page"] + "" != "")
                    page = int.Parse(Request["page"] + "");
            }

            using (WXDBEntities db = new WXDBEntities())
            {
                IQueryable<Forms> carlist = db.Forms.Where(s => s.Type.Equals(8)).OrderBy(o => o.AddTime);
                if (!string.IsNullOrEmpty(txtKeywords.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.Name.Contains(txtKeywords.Text));
                }
                var dblist = carlist.ToPagedList(page, AspNetPager1.PageSize);
                AspNetPager1.RecordCount = dblist.TotalItemCount;
                if (!this.IsPostBack)
                {
                    if (Request["page"] + "" != "")
                    {
                        int temp = int.Parse(Request["page"] + "");
                        AspNetPager1.CurrentPageIndex = temp;
                    }
                }
                WebUtil.CtrlToList<Forms>(rptLoop, dblist);
            }
        }
        #endregion
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

            RptBind();
        }
        //查询
        protected void btn_click_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            RptBind();
        }

        /**
       * 格式化HTML文本
       * @param content
       * @return
       */
        public static string html(String content)
        {
            if (content == null) return "";
            String html = content;
            html = html.Replace("'", "&apos;");
            html = html.Replace("\"", "&quot;");
            html = html.Replace("\t", "&nbsp;&nbsp;");// 替换跳格
            //html = StringUtils.replace(html, " ", "&nbsp;");// 替换空格
            html = html.Replace("<", "&lt;");
            html = html.Replace(">", "&gt;");
            return html;
        }
    }
}