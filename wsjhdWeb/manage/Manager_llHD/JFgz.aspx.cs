using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;
using NewInfoWeb.Appcode;
using System.IO;
namespace NewInfoWeb.manage.Manager_llHD
{
    public partial class JFgz : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowInfo();
            }
        }
        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="p"></param>
        private void ShowInfo()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = db.Article.Where(s => s.Type.Equals(25)).FirstOrDefault();
                if (model != null)
                {
                    hidId.Value = model.AritcleID + "";
                    txtcontent.Value = model.Contents;
                }
            }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_click_Click(object sender, ImageClickEventArgs e)
        {

            if (string.IsNullOrEmpty(txtcontent.Value))
            {
                jsHint.Back("请输入内容信息！");
                return;
            }

            using (WXDBEntities db = new WXDBEntities())
            {
                var addobj = new Article();
                if (hidId.Value.Equals("0"))
                {
                    addobj = new Article();
                    addobj.AddTime = DateTime.Now;
                    addobj.Title = "";
                    addobj.Orders = 0;
                    addobj.Contents = txtcontent.Value; ;
                    addobj.Description = "";
                    addobj.Status = 0;
                    ///关键字
                    addobj.Extend1 = "";
                    addobj.Type = 25;
                    addobj.UpdateTime = DateTime.Now;
                }
                else
                {
                    addobj = db.Article.Where(s => s.Type.Equals(25)).FirstOrDefault();
                    addobj.UpdateTime = DateTime.Now;
                    addobj.Contents = txtcontent.Value;
                }
                //修改人
                addobj.Extend2 = loginname;
                if (hidId.Value.Equals("0"))
                {
                    db.Article.AddObject(addobj);
                }
                db.SaveChanges();
                jsHint.toUrl("积分规则操作成功", "JFgz.aspx");
            }
        }
    }
}