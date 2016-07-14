using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;
using Dos.ORM;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.Manager_User
{
    public partial class Manager_User_List : System.Web.UI.Page
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
                        IList<AccountUnionPage> xList = db.AccountUnionPage.Where(a => a.AccountID.Equals(tmpid)).ToList();
                        if (xList.Count > 0)
                        {
                            foreach (var a in xList)
                            {
                                db.AccountUnionPage.DeleteObject(a);
                                db.SaveChanges();
                            }
                        }
                        WXEF.SysAccount model = db.SysAccount.Where(s => s.AccountID.Equals(tmpid)).FirstOrDefault();
                        if (model != null)
                        {
                            db.SysAccount.DeleteObject(model);
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
                IQueryable<SysAccount> carlist = db.SysAccount.Where(o => o.Status.Equals(0)).OrderBy(o => o.AccountID);
                if (!string.IsNullOrEmpty(txtKeywords.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.LoginName.Contains(txtKeywords.Text));
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
                WebUtil.CtrlToList<SysAccount>(rpt_dataTable, dblist);
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
            if (DrpTotalCount.SelectedValue == "0")
            {
                AspNetPager1.PageSize = 8;
            }
            else
            {
                AspNetPager1.PageSize = Convert.ToInt32(DrpTotalCount.SelectedValue);
            }
            RptBind();
        }

        //获取角色权限名称
        public string getManager_GroupsName(int id)
        {
            string result = "";
            if (id > 0)
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var model = DbSession.Default.From<Dos.Model.Manager_Groups>().Where(s => s.Id.Equals(id)).ToFirstDefault();
                    if (model.Id > 0)
                    {
                        result = model.Name;
                    }
                    else
                    {
                        result = "未知数据";
                    }
                }
            }
            return result;
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