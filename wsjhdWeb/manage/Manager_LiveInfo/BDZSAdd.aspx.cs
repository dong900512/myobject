﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;
using NewInfoWeb.Appcode;
using System.IO;
namespace NewInfoWeb.manage.Manager_LiveInfo
{
    public partial class BDZSAdd : ManageBasePage
    {
        public int aid = DNTRequest.RequstInt("id");
        public int typid = DNTRequest.RequstInt("typid");
        public string change = DNTRequest.RequstString("change");
        protected string curimg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["change"] == "edit" && aid != -1)
                {
                    ShowInfo(this.aid);
                }
                string reqStrUrl = "BDZSList.aspx?tid=" + typid;
                //if (Request.UrlReferrer != null)
                //{
                //    reqStrUrl = Request.UrlReferrer.ToString();
                //}
                btn_Back.Attributes.Add("onclick", "window.location.href='" + reqStrUrl + "';return false;");
            }
        }
        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="p"></param>
        private void ShowInfo(int p)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = db.Article.Where(s => s.AritcleID.Equals(p)).FirstOrDefault();
                if (model != null)
                {
                    txttitle.Text = model.Title;
                    txtsummary.Text = model.Description;
                    txtcontent.Value = model.Contents;
                    txtOrders.Text = model.Orders.ToString();
                    txtStart.Text = model.AddTime.ToString("yyyy-MM-dd");
                    txtkeyword.Text = model.Extend1;
                    if (!string.IsNullOrEmpty(model.Cover))
                    {
                        hyp.Text = "查看封面信息";
                        curimg = globalVariables.NewsImgServer + model.Cover;
                        hyp.NavigateUrl = globalVariables.NewsImgServer + model.Cover;
                        slt.Visible = true;
                    }
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
            if (string.IsNullOrEmpty(txttitle.Text.Trim()))
            {
                jsHint.Back("请输入标题信息！");
                return;
            }
            if (string.IsNullOrEmpty(txtOrders.Text.Trim()))
            {
                jsHint.Back("请输入排序号！");
                return;
            }
            if (!WebUtil.IsDigit(txtOrders.Text.Trim()))
            {
                jsHint.Back("排序号请输入数字！");
                return;
            }
            if (string.IsNullOrEmpty(txtcontent.Value))
            {
                jsHint.Back("请输入内容信息！");
                return;
            }

            using (WXDBEntities db = new WXDBEntities())
            {
                var addobj = new Article();
                if (aid != -1)
                {
                    addobj = db.Article.Where(s => s.AritcleID == aid).FirstOrDefault();
                    if (addobj != null)
                    {
                        string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 200, 150);
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
                        addobj = new Article();
                        string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 200, 150);
                        if (str.Equals("没有选择上传图片") || str.Equals("图片格式不正确") || str.Equals("没有选择图片"))
                        {
                            jsHint.Back("请选择封面后进行操作!");
                            return;
                        }
                        else
                        {
                            addobj.Cover = str;
                        }
                    }
                }
                var tmpmodel = db.Article.Where(s => s.Title == txttitle.Text && s.Type.Equals(17)).Where(s => s.AritcleID != aid).FirstOrDefault();
                if (tmpmodel != null)
                {
                    jsHint.Back("该标题已存在，请重新输入标题信息");
                    return;
                }
                addobj.Title = txttitle.Text;
                addobj.Orders = string.IsNullOrEmpty(txtOrders.Text) ? 0 : int.Parse(txtOrders.Text);
                addobj.Contents = txtcontent.Value; ;
                addobj.Description = txtsummary.Text;
                addobj.Status = 0;
                ///关键字
                addobj.Extend1 = txtkeyword.Text;
                addobj.Type = typid;
                addobj.UpdateTime = DateTime.Now;
                if (string.IsNullOrEmpty(txtStart.Text))
                {
                    addobj.AddTime = DateTime.Now;
                }
                else
                {
                    addobj.AddTime = Convert.ToDateTime(txtStart.Text);
                }

                //修改人
                addobj.Extend2 = loginname;
                if (string.IsNullOrEmpty(hyp.Text))
                {
                    db.Article.AddObject(addobj);
                }
                db.SaveChanges();
                jsHint.toUrl("信息" + addobj.Title + "操作成功!", "BDZSList.aspx?tid=" + typid);
            }
        }
    }
}