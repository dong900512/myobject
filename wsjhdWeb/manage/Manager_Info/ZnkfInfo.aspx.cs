using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewInfoWeb.Appcode;
using WXEF;
using WX.Utils;
using System.IO;
namespace NewInfoWeb.manage.Manager_Info
{
    public partial class ZnkfInfo : System.Web.UI.Page
    {
        protected string curimg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitCtrls();
            }
        }
        private void InitCtrls()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var tmp = db.WXKewWords.Where(s => s.Type == 0).FirstOrDefault();
                if (tmp != null)
                {
                    txtsummary.Value = tmp.Description;
                    txttitle.Text = tmp.Title;

                    if (!string.IsNullOrEmpty(tmp.Cover))
                    {
                        hyp.Text = "查看封面信息";
                        curimg = globalVariables.NewsImgServer + tmp.Cover;
                        hyp.NavigateUrl = globalVariables.NewsImgServer + tmp.Cover;
                        slt.Visible = true;
                    }
                    txtms.Value = tmp.Extend;
                    txtlink.Text = tmp.Extend1;
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
            var tsum = txtsummary.Value.Trim();
            var title = txttitle.Text.Trim();
            var tlink = txtlink.Text.Trim();
            if ((tsum == "" || tsum == null) && (title == "" || title == null))
            {
                jsHint.Back("请输入回复内容/图文回复信息");
                return;
            }
            if (title != null && title != "")
            {
                {
                    if (tlink == "" || tlink == null)
                    {
                        jsHint.Back("请输入回复链接地址");
                        return;
                    }
                }
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                var addobj = new WXKewWords();
                addobj = db.WXKewWords.Where(s => s.Type.Equals(0)).FirstOrDefault();
                if (addobj != null)
                {
                    string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 900, 500);
                    if (str.Equals("没有选择上传图片") || str.Equals("图片格式不正确") || str.Equals("没有选择图片"))
                    {

                    }
                    else
                    {
                        addobj.Cover = str;
                    }
                }
                else
                {
                    addobj = new WXKewWords();
                    string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 900, 500);
                    if (str.Equals("没有选择上传图片") || str.Equals("图片格式不正确") || str.Equals("没有选择图片"))
                    {
                    }
                    else
                    {
                        addobj.Cover = str;
                    }
                }
                addobj.Title = txttitle.Text;
                addobj.Description = txtsummary.Value;
                addobj.Extend = txtms.Value;
                addobj.Extend1 = txtlink.Text;
                addobj.Status = 0;
                addobj.AddTime = DateTime.Now;
                addobj.UpdateTime = DateTime.Now;
                addobj.Type = 0;
                if (string.IsNullOrEmpty(hyp.Text))
                {
                    db.WXKewWords.AddObject(addobj);
                }
                curimg = globalVariables.NewsImgServer + addobj.Cover;
                db.SaveChanges();
                jsHint.Alert("关注回复信息操作成功！");
            }

        }
    }
}