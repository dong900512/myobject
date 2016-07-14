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
using Dos.Common;
namespace NewInfoWeb.manage.Manager_Role
{
    public partial class sys_Module_Add : ManageBasePage
    {
        public string nodeText = DNTRequest.GetString("nodeText");//文本值
        public string nodeValue = DNTRequest.GetString("nodeValue");//0为模块，1为子节点
        public string nodeID = DNTRequest.GetString("nodeID");//模块和子节点ID
        protected string iszjd = DNTRequest.GetString("iszcd");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            lbTitle.InnerText = nodeText;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Dos.Model.Manager_Role model = null;
            if (string.IsNullOrEmpty(nodeID) || nodeID == "0" || string.IsNullOrEmpty(iszjd) || iszjd == "0")
            {//根目录传过来的值
                model = new Dos.Model.Manager_Role();
                model.AddUser = loginname;
                model.AddTime = DateTime.Now;
                model.Status = 0;
                model.Orders = 0;
                model.PagePath = "";
                model.Remark = "";
                model.Name = "";
            }
            else
            {//修改
                var tmpid = Convert.ToInt32(nodeID);
                model = DbSession.Default.From<Dos.Model.Manager_Role>().Where(s => s.Id.Equals(tmpid) && s.Status.Equals(0)).ToFirstDefault();
            }
            model.MenuText = txt_MenuNameC.Value.Trim();
            model.Orders = string.IsNullOrEmpty(txt_MenuOrder.Value.Trim()) ? 0 : Convert.ToInt32(txt_MenuOrder.Value.Trim());
            model.MenuPath = txt_MenuUrl.Value.Trim();
            model.UpdateTime = DateTime.Now;
            model.UpdateUser = loginname;
            model.ParentId = (string.IsNullOrEmpty(nodeID) || nodeID == "0") ? 0 : Convert.ToInt32(nodeID);
            int result = 0;
            if (Convert.ToInt32(nodeValue) >= 0)
            {
                try
                {
                    //数据
                    int ts = DbSession.Default.Insert<Dos.Model.Manager_Role>(model);
                    Logger.Default.Info("新增数据成功");
                    BindData();
                    ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作成功!');parent.window.document.getElementById('leftFrame').src = 'sys_Module_Menu.aspx'", true);
                }
                catch (Exception ex)
                {
                    string Details = "出错！！！方法：" + ex.TargetSite + ",异常消息：" + ex.Message + ",出错的应用程序或对象名称：" + ex.Source;

                    Logger.Default.Info("新增数据失败", Details);
                    ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作失败,请重新操作!');", true);
                }
            }

        }
    }
}
