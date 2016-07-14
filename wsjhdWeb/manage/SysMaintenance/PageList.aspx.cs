using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.SysMaintenance
{
    public partial class PageList : ManageBasePage
    {
        protected int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //// 处理删除模块操作
                //if (!string.IsNullOrEmpty(Request.QueryString["delid"]))
                //    MaintenanceService.Instance.DeleteModuleItemById(int.Parse(Request.QueryString["delid"]));


                // 处理删除页面操作 
                if (!string.IsNullOrEmpty(Request.QueryString["delpid"]))
                {
                    int pid = int.Parse(Request.QueryString["delpid"]);
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        PageItem xPageItem = db.PageItem.Where(p => p.ItemID == pid).FirstOrDefault();
                        db.PageItem.DeleteObject(xPageItem);
                        db.SaveChanges();
                    }
                    jsHint.toUrl("删除成功！", "PageList.aspx");
                }

                //// 处理排序操作
                //if (!string.IsNullOrEmpty(Request.QueryString["action"]))
                //{
                //    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                //        MaintenanceService.Instance.ModifyModuleOrdersById(int.Parse(Request.QueryString["id"]), Request.QueryString["action"]);
                //    else if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                //        MaintenanceService.Instance.ModifyPageOrdersById(int.Parse(Request.QueryString["pid"]), Request.QueryString["action"]);
                //}

                // 进行数据绑定
                InitCtrls();
            }

            ((maintenancemaster)this.Master).txtTitle = "页面信息列表";
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void InitCtrls()
        {
            int page = AspNetPager1.CurrentPageIndex;
            if (!this.IsPostBack)
            {
                if (Request["page"] + "" != "")
                    page = int.Parse(Request["page"] + "");
            }

            using (WXDBEntities db = new WXDBEntities())
            {
                var pagelist = db.PageItem.OrderBy(o => o.Orders).ThenByDescending(o => o.ItemID);
                var dblist = pagelist.ToPagedList(page, AspNetPager1.PageSize);

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
                WebUtil.CtrlToIList(rptPage, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            InitCtrls();
        }
    }
}