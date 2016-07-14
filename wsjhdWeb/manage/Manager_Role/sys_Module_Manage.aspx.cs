using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewInfoWeb.Appcode;
using WX.Utils;
using Dos.Model;
using Dos.ORM;
namespace NewInfoWeb.manage.Manager_Role
{
    public partial class sys_Module_Manage : ManageBasePage
    {
        public string nodeText = DNTRequest.GetString("nodeText");//文本值
        public string nodeValue = DNTRequest.GetString("nodeValue");//0为模块，1为子节点
        public string nodeID = DNTRequest.GetString("nodeID");//模块和子节点ID
        public string Url = DNTRequest.GetString("Url");//是否有链接
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            string url = "Manager_Role/sys_Module_Tree.aspx";
            //int AuthId = int.Parse(HttpContext.Current.Request.Cookies["GLadmin"]["AdminLevel"]);
            if (nodeText != "")
            {//防止非法传入
                try
                {
                    var tmpid = Convert.ToInt32(nodeID);
                    var model = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.Status.Equals(0) && s.Id.Equals(tmpid)).ToFirstDefault();
                    if (model.Id > 0)
                    {
                        txt_MenuNameC.Value = model.MenuText;
                        txt_MenuOrder.Value = model.Orders + "";
                        txt_MenuUrl.Value = model.MenuPath;
                    }
                    //DataTable dt = new HouseCenter.BLL.Manager_Role.Manager_Role().SelectData("MenuText,sort,MenuPath,ParentId", "Manager_Role", " and Id=" + nodeID).Tables[0];
                }
                catch (Exception) { }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var tmoid = Convert.ToInt32(nodeID);
            var model = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.Status.Equals(0) && s.Id.Equals(tmoid)).ToFirstDefault();
            if (model.Id > 0)
            {
                model.MenuText = txt_MenuNameC.Value.Trim();
                model.Orders = Convert.ToInt32(txt_MenuOrder.Value.Trim());
                try
                {
                    model.MenuPath = txt_MenuUrl.Value.Trim();
                }
                catch (Exception) { model.MenuPath = ""; }
                model.UpdateUser = loginname;
                model.UpdateTime = DateTime.Now;
                model.Name = "";
                int result = 0;
                if (Convert.ToInt32(nodeValue) > 0)
                {
                    try
                    {
                        model.Attach();
                        int ts = DbSession.Default.Update<Dos.Model.Manager_Role>(model);
                        //db.SaveChanges();
                        BindData();
                        string Details = "Manager_Role  ID为：" + nodeID; ;
                        string type = "修改";
                        string typeName = "模块管理";
                        Logger.Default.Info("修改成功", Details);
                        ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "修改成功", "parent.window.document.getElementById('leftFrame').src = 'sys_Module_Menu.aspx'", true);
                    }
                    catch (Exception ex)
                    {
                        string Details = "出错！！！方法：" + ex.TargetSite + ",异常消息：" + ex.Message + ",出错的应用程序或对象名称：" + ex.Source;
                        string type = "修改";
                        string typeName = "模块管理";
                        Logger.Default.Info("修改失败", Details);
                        ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作失败,请重新操作!');", true);
                    }
                }
            }
            //HouseCenter.Model.Manager_Role.Manager_Role model = new HouseCenter.BLL.Manager_Role.Manager_Role().GetModel(int.Parse(nodeID));
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {

                var tmpid = Convert.ToInt32(nodeID);
                //var tparentid=Convert.ToInt32()
                var tmodel = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.Id.Equals(tmpid)).ToFirstDefault();
                if (tmodel.Id > 0)
                {
                    tmodel.Status = 1;
                    //db.Manager_Role.DeleteObject(tmodel);
                    int ts = DbSession.Default.Update<Dos.Model.Manager_Role>(tmodel);
                    string Details = "表名Manager_Role,删除ID为：" + nodeID + ",模块名称：" + txt_MenuNameC.Value.Trim();
                    string type = "删除";
                    string typeName = "模块管理";
                    Logger.Default.Info("删除成功", Details);
                    ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "parent.location='sys_Module_Tree.aspx'", true);
                }
            }
            catch (Exception ex)
            {
                string Details = "Manager_Role,删除,出错！！！方法：" + ex.TargetSite + ",异常消息：" + ex.Message + ",出错的应用程序或对象名称：" + ex.Source;
                string type = "删除";
                string typeName = "模块管理";
                Logger.Default.Error("删除操作出错", Details);
                ScriptManager.RegisterClientScriptBlock(btnDel, GetType(), "", "alert('操作失败,请重新操作!');", true);
            }
        }

    }
}