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

namespace NewInfoWeb.manage.Manager_Groups
{
    public partial class Manager_Groups_Add : ManageBasePage
    {
        public string strID = "";
        public string Mark = "";
        public Dictionary<string, string> dt_Function = null;//功能表
        public string functionItem = "";//功能权限项
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        private void GetData()
        {
            string AuthItem = DNTRequest.GetString("AuthItem");//权限项
            string AuthID = DNTRequest.GetString("AuthID");//权限ID 
            string Name = DNTRequest.GetString("Name");//角色名称
            string Mark = DNTRequest.GetString("Mark");//说明
            string xmno = DNTRequest.GetString("xmno");
            LoadData(AuthItem);
            txtDutyName.Value = Name;
            txtMark.Value = Mark;
            strID = AuthID;
        }

        private void LoadData(string AuthItem)
        {

            var list = DbSession.Default.From<Dos.Model.Manager_Role>()
            .Where(s => s.Status.Equals(0) && s.ParentId.Equals(0))
            .OrderBy(s => s.Orders).ToList();
            //db.Manager_Role.Where(s => s.Status.Equals(0) && s.ParentId.Equals(0)).OrderBy(s => s.Orders).ToList();
            if (list.Count > 0)
            {
                TreeNode FristNode = new TreeNode();
                FristNode.Text = "权限模块";
                FristNode.NavigateUrl = "0";
                if (AuthItem != "")
                {
                    if (AuthItem != "0,")
                    {
                        FristNode.Checked = true;
                    }
                }
                FristNode.SelectAction = TreeNodeSelectAction.None;
                //父节点
                foreach (var item in list)
                {

                    TreeNode node = new TreeNode();
                    node.Text = item.MenuText;
                    node.Value = item.Id + "";
                    node.NavigateUrl = item.Id + "";
                    string[] str = AuthItem.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var tt in str)
                    {
                        if (tt.Equals(item.Id + ""))
                        {
                            node.Checked = true;
                        }
                    }
                    //if (AuthItem.Contains(item.Id + ","))
                    //{

                    //}
                    node.SelectAction = TreeNodeSelectAction.None;
                    FristNode.ChildNodes.Add(node);
                    ResolveSubTree(item, node, AuthItem);

                }
                TreeView1.Nodes.Add(FristNode);
            }




        }
        //子节点
        private void ResolveSubTree(Dos.Model.Manager_Role model, TreeNode treeNode, string AuthItem)
        {
            //using (WXDBEntities db = new WXDBEntities())
            //{
            var list = DbSession.Default.From<Dos.Model.Manager_Role>()
                .Where(s => s.Status.Equals(0) && s.ParentId.Equals(model.Id))
                .OrderBy(s => s.Orders).ToList();
            // db.Manager_Role.Where(s => s.Status.Equals(0) && s.ParentId.Equals(model.Id)).OrderBy(s => s.Orders).ToList();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    TreeNode node = new TreeNode();
                    node.Text = item.MenuText;
                    node.Value = item.Id + "";
                    node.NavigateUrl = item.Id + "";
                    if (AuthItem.IndexOf(item.Id + "") > -1)
                    {
                        node.Checked = true;
                    }
                    node.SelectAction = TreeNodeSelectAction.None;
                    treeNode.ChildNodes.Add(node);
                    ResolveSubTree(item, node, AuthItem);
                }
            }

        }
    }
}