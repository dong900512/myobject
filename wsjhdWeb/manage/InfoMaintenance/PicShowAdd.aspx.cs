using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class PicShowAdd : ManageBasePage
    {
        public string picTypeid;
        public string curloginname;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                picTypeid = Request.Params["TypeID"];
                curloginname = loginname;
            }
        }
    }
}