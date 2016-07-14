using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using WX.Utils;
using WXEF;
using Dos.Model;
using Dos.ORM;
using System.Data.Objects.SqlClient;
namespace NewInfoWeb.manage
{
    public partial class left : ManageBasePage
    {
        public string str_menu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenu();
            }
        }

        public void BindMenu()
        {
            StringBuilder strHtml = new StringBuilder();
            using (WXDBEntities db = new WXDBEntities())
            {
                var str = GetMenuSetting(GetDutyId);
                var parentlist = DbSession.Default.From<Dos.Model.Manager_Role>().
                    Where(s => s.Id.In(str) && s.ParentId.Equals(0)).OrderBy(s => s.Orders).ToList();
                var str1 = new StringBuilder();
                if (parentlist.Count() > 0)
                {
                    foreach (var item in parentlist)
                    {
                        str1.Append("<li class=\" open in has-list \"><a href=\"#\">" + item.MenuText + "</a>");
                        //str1.Append("name:" + item.MenuText+",");
                        if (IsMenu(item.Id + ""))
                        {
                            //str1.Append("children:[");
                            MenuJosn(item.Id, str1, str);
                            //str1.Append("}");
                        }
                        str1.Append("</li>");
                    }

                }
                //str1.Append("]");
                str_menu = str1.ToString();
            }
        }

        /// <summary>
        /// 返回节点Josn
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public string MenuJosn(int ParentID, StringBuilder strHtml, List<int> dqMenu)
        {
            string mJosn = "";
            //StringBuilder strHtml = new StringBuilder();

            using (WXDBEntities db = new WXDBEntities())
            {
                var rolelist = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(ParentID) && s.Status.Equals(0) &&s.Id.In(dqMenu)).OrderBy(s => s.Orders).ToList
();
                if (rolelist.Count() > 0)
                {
                    strHtml.Append(" <ul>");
                    foreach (var item in rolelist)
                    {
                        //strHtml.Append("<a href=""");
                        //strHtml.Append("children:[");
                        var tmodel1 = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(item.Id) && s.Status.Equals(0) && s.Id.In(dqMenu)).OrderBy(s => s.Orders).ToList
();
                        //strHtml.Append("{");
                        //strHtml.Append("name:" + item.MenuText + ",");
                        if (tmodel1.Count() > 0)
                        {
                            strHtml.Append("<li class=\"has-list\"><a href=\"#\">" + item.MenuText + "</a>");
                            MenuJosn(item.Id, strHtml, dqMenu);
                            strHtml.Append("</li>");
                        }
                        else
                        {
                            strHtml.Append("<li><a href=" + item.MenuPath + " target=\"main\">" + item.MenuText + "</a></li>");
                            //strHtml.Append("name:" + item.MenuText + ",url:" + item.MenuPath);
                            //strHtml.Append();
                        }
                        //strHtml.Append("]");
                    }
                    strHtml.Append("</ul>");
                    //strHtml.Append("<ul>");
                    //string cssindexl = indexl * 30 + "";
                    //foreach (var item in rolelist)
                    //{
                    //    string stwxjosn = "";
                    //    strHtml.Append("<li>");
                    //    if (!IsMenu(item.Id.ToString()))
                    //    {
                    //        strHtml.Append(" <div class='subscript'><a href='" + item.MenuPath + "' target='main'>" + item.MenuText.ToString() + "</a></div></li>");
                    //        continue;
                    //    }
                    //    else
                    //    {

                    //    }
                    //    strHtml.Append("<div class='mainmenu'><i></i><img src='images/no_img01.png' class='fileimg' />");
                    //    strHtml.Append("<span class='colortxt>" + item.MenuPath + "</span><img src='images/no_arrear.png' class='btm_arres' /></div>");
                    //    strHtml.Append("<div class='submenu'>");
                    //    //stwxjosn = MenuJosn(item.Id + "", indexl + 1, dqMenu);
                    //    strHtml.Append(stwxjosn);
                    //    strHtml.Append("</li>");
                    //}
                    //strHtml.Append("</ul>");
                    //mJosn = strHtml.ToString();
                }
                return mJosn;
            }
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="Id">用户对应的权限ID</param>
        /// <returns></returns>
        public List<int> GetMenuSetting(int Id)
        {
            string MenuSetting = "";
            List<int> tlist = new List<int>();
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = DbSession.Default.From<Dos.Model.Manager_Groups>().Where(s => s.Id.Equals(Id) && s.Status.Equals(0)).ToFirstDefault();
                if (model.Id > 0)
                {
                    MenuSetting = model.Role;
                    var tmlist = model.Role.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in tmlist)
                    {
                        tlist.Add(Convert.ToInt32(item));
                    }
                }
            }
            return tlist;
        }

        /// <summary>
        /// 判断该节点是否有子节点
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public bool IsMenu(string ParentID)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var tmpid = Convert.ToInt32(ParentID);
                var model = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(tmpid) && s.Status.Equals(0)).OrderBy(s => s.Orders).ToFirstDefault();
                if (model.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}