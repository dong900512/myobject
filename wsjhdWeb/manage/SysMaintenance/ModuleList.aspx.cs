using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;

namespace NewInfoWeb.manage.SysMaintenance
{
    public partial class ModuleList : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // 处理删除模块操作
                if (!string.IsNullOrEmpty(Request.QueryString["delid"]))
                {
                    int mid = int.Parse(Request.QueryString["delid"]);
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        //IList<PageItem> xList = db.PageItem.Where(p => p.ModuleID == mid).ToList();
                        //if (xList.Count > 0)
                        //{
                        //    foreach (var p in xList)
                        //    {
                        //        PageItem xPageItem = p;
                        //        db.PageItem.DeleteObject(xPageItem);
                        //        db.SaveChanges();
                        //    }
                        //}
                        ModuleItem xModuleItem = db.ModuleItem.Where(m => m.ModuleID == mid).FirstOrDefault();
                        db.ModuleItem.DeleteObject(xModuleItem);
                        db.SaveChanges();
                        jsHint.toUrl("删除成功！", "ModuleList.aspx");
                    }
                }


                // 处理删除页面操作 
                if (!string.IsNullOrEmpty(Request.QueryString["delpid"]))
                {
                    int pid = int.Parse(Request.QueryString["delid"]);
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        PageItem xPageItem = db.PageItem.Where(p => p.ItemID == pid).FirstOrDefault();
                        db.PageItem.DeleteObject(xPageItem);
                        db.SaveChanges();
                    }
                    jsHint.toUrl("删除成功！", "ModuleList.aspx");
                }

                // 处理排序操作
                if (!string.IsNullOrEmpty(Request.QueryString["action"]))
                {
                    //if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    //    MaintenanceService.Instance.ModifyModuleOrdersById(int.Parse(Request.QueryString["id"]), Request.QueryString["action"]);
                    //else if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                    //    MaintenanceService.Instance.ModifyPageOrdersById(int.Parse(Request.QueryString["pid"]), Request.QueryString["action"]);
                }

                // 进行数据绑定
                InitCtrls();
            }

            ((maintenancemaster)this.Master).txtTitle = "模块信息列表";
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void InitCtrls()
        {
            //int page = (string.IsNullOrEmpty(Request.QueryString["page"])) ? 1 : int.Parse(Request.QueryString["page"]);
            //int firstnum = (page == 1) ? 0 : ((page - 1) * 3);
            //int firstnum = (page == 1) ? 0 : ((page - 1) * 20 );
            //int recordcount;

            //WebUtil.CtrlToIList(rptModule, MaintenanceService.Instance.GetModuleByPage(firstnum, 20, out recordcount));
            using (WXDBEntities db = new WXDBEntities())
            {
                WebUtil.CtrlToIList(rptModule, db.ModuleItem.ToList());
            }
            //Pager1.RecordCount = recordcount;
            //Pager1.PageSize = 20;
            //Pager1.DestPage = page;
        }

        /// <summary>
        /// 动态的设置页面信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptModule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rpt = (Repeater)e.Item.FindControl("rptPage");
                ModuleItem module = (ModuleItem)e.Item.DataItem;

                List<PageItem> list = new List<PageItem>();
                foreach (PageItem item in module.PageItem)
                    list.Add(item);

                //list.Sort();
                WebUtil.CtrlToList<PageItem>(rpt, list);
            }
        }
    }
}