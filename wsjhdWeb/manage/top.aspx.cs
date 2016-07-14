using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewInfoWeb.manage
{
    public partial class top : ManageBasePage
    {
        public string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserName = loginname;
        }
    }
}