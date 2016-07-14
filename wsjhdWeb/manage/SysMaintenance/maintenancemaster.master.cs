using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewInfoWeb.manage.SysMaintenance
{
    public partial class maintenancemaster : System.Web.UI.MasterPage
    {
        private int trnum;
        public int trNum
        {
            set { trnum = value; }
            get { return trnum; }
        }

        public string txtTitle
        {
            set { ltlTitle.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.syshead1.trNum = this.trNum;

        }
    }
}