using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewInfoWeb.Appcode;
using Dos.Model;
using Dos.Common;
using WX.Utils;
using Dos.ORM;
namespace NewInfoWeb.manage.Manager_Role
{
    public partial class sys_Module_Menu : ManageBasePage
    {
        public string menu = "{\"button\": [";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                WXMenuData();
            }

        }
        private void LoadData()
        {
            //using (WXDBEntities db = new WXDBEntities())
            //{
            var list = DbSession.Default.From<Dos.Model.Manager_Role>()
                .Where(s => s.ParentId.Equals(0) && s.Status.Equals(0))
                .OrderBy(s => s.Orders).ToList();
            //db.Manager_Role.Where(s => s.ParentId.Equals(0) && s.Status.Equals(0)).OrderBy(s => s.Orders).ToList();

            TreeNode FristNode = new TreeNode();
            FristNode.Text = "根目录";
            FristNode.NavigateUrl = "javascript:editshow('根目录',0,0,'NO')";
            //父节点
            foreach (var item in list)
            {
                var count = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(item.Id) && s.Status.Equals(0)).Count(); /*db.Manager_Role.Where(s => s.ParentId.Equals(item.Id) && s.Status.Equals(0)).Count();*/

                TreeNode node = new TreeNode();
                if (count > 0)
                {    //有子节点
                     //节点名称,节点值(0表示添加，1表示修改),节点ID,是否有链接框
                    node.NavigateUrl = "javascript:editshow('" + item.MenuText + "',1," + item.Id + ",'NO');";
                }
                else
                {//没有字节点
                    node.NavigateUrl = "javascript:editshow('" + item.MenuText + "',1," + item.Id + ",'YES');";
                }

                node.Text = item.MenuText;
                node.Value = item.Id + "";
                FristNode.ChildNodes.Add(node);
                ResolveSubTree(item, node);
            }
            TreeView1.Nodes.Add(FristNode);
            //}
        }
        //子节点
        private void ResolveSubTree(Dos.Model.Manager_Role model, TreeNode treeNode)
        {

            var list = DbSession.Default.From<Dos.Model.Manager_Role>()
            .Where(s => s.ParentId.Equals(model.Id) && s.Status.Equals(0))
            .OrderBy(s => s.Orders).ToList();
            //db.Manager_Role.Where(s => s.ParentId.Equals(model.Id) && s.Status.Equals(0)).OrderBy(s => s.Orders).ToList();
            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    TreeNode node = new TreeNode();
                    var count = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(item.Id) && s.Status.Equals(0)).Count();
                    if (count > 0)
                    {//有子节点
                        node.NavigateUrl = "javascript:editshow('" + item.MenuText + "',1," + item.Id + ",'NO');";
                    }
                    else
                    {//没有字节点
                        node.NavigateUrl = "javascript:editshow('" + item.MenuText + "',1," + item.Id + ",'YES');";
                    }
                    node.Text = item.MenuText;
                    node.Value = item.Id + "";
                    treeNode.ChildNodes.Add(node);
                    ResolveSubTree(item, node);
                    //node.NavigateUrl = "javascript:editshow('" + item.MenuText + "',1," + item.Id + ",'YES','isno');";
                    ////if (dt.Select("ParentId=" + row["Id"].ToString()).Count() > 0)
                    ////{//有子节点
                    ////    node.NavigateUrl = "javascript:editshow('" + row["MenuText"].ToString() + "',1," + row["Id"].ToString() + ",'NO');";
                    ////}
                    ////else
                    ////{//没有字节点

                    ////}
                    //node.Text = item.MenuText;
                    //node.Value = item.Id + "";
                    //treeNode.ChildNodes.Add(node);
                    //ResolveSubTree(row, node, dt);
                }
            }

        }


        private void WXMenuData()
        {

            var list = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(0) && s.Status.Equals(0)).OrderBy(s => s.Orders).ToList();
            foreach (var item in list)
            {
                //取出一级节点
                menu += "{\"name\":\"" + item.MenuText + "\",\"sub_button\":[";
                var list1 = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(item.Id) && s.Status.Equals(0)).ToList();
                foreach (var item1 in list1)
                {
                    var cton = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(item1.Id) && s.Status.Equals(0)).Count();
                    if (cton > 0)
                    {
                        menu += "{\"name\":\"" + item1.MenuText + "\",\"sub_button\":[";
                        WXMenuData_Next(menu, item1.Id);
                    }
                    else
                    {
                        menu += "{\"type\":\"view\",\"name\":\"" + item1.MenuText + "\",\"key\":\"Caron\"},";
                    }
                }
                #region 隐藏
                //for (int j = 0; j < dr1.Length; j++)
                //{

                //if (dt.Select("ParentId=" + dr1[j]["Id"].ToString()).Count() > 0)
                //{//二级节点存在下级节点
                //    menu += "{\"name\":\"" + dr1[j]["MenuText"].ToString() + "\",\"sub_button\":[";
                //    WXMenuData_Next(dt, menu, dr1[j]["Id"].ToString());
                //}
                //else
                //{

                //}
                //}
                #endregion
                menu = menu.Trim(',') + "]},";
            }
            menu = menu.Trim(',') + "]}";
        }

        private void WXMenuData_Next(string wxMenu, int id)
        {

            var list = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(id) && s.Status.Equals(0)).OrderBy(s => s.Orders).ToList();
            foreach (var item in list)
            {
                var cton = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.ParentId.Equals(item.Id) && s.Status.Equals(0)).Count();
                if (cton > 0)
                {
                    //存在下级节点
                    menu += "{\"name\":\"" + item.MenuText + "\",\"sub_button\":[";
                    WXMenuData_Next(menu, item.Id);
                }
                else
                {
                    menu += "{\"type\":\"view\",\"name\":\"" + item.MenuText + "\",\"key\":\"Caron\"},";
                }
            }
            //for (int i = 0; i < dr.Length; i++)
            //{
            //    if (dt.Select("ParentId=" + dr[i]["Id"].ToString()).Count() > 0)
            //    {
            //    }
            //    else
            //    {
            //        menu += "{\"type\":\"view\",\"name\":\"" + dr[i]["MenuText"].ToString() + "\",\"key\":\"Caron\"},";
            //    }
            //}
            menu = menu.Trim(',') + "]},";
        }
    }
}