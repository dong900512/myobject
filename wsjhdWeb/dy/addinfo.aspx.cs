using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
namespace NewInfoWeb.dy
{
    public partial class addinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                List<string> namelist = new List<string>();
                namelist.Add("乔偲蔚");
                namelist.Add("周晓俊");
                namelist.Add("周嘉");
                namelist.Add("季优美");
                namelist.Add("赵天云");
                namelist.Add("周晶");
                namelist.Add("邬君雯");
                namelist.Add("沈德虎");
                namelist.Add("程丽娟");
                namelist.Add("王玲");
                namelist.Add("俞康");
                namelist.Add("赵俊翔");
                namelist.Add("胡春阳");
                namelist.Add("罗百江");
                namelist.Add("张拯");
                namelist.Add("孙梦婷");
                namelist.Add("孙苗苗");
                namelist.Add("高文文");
                namelist.Add("孙利侠");
                namelist.Add("华媛");
                namelist.Add("朱小华");
                namelist.Add("卢传娟");
                namelist.Add("周思杰");
                namelist.Add("姜晓霞");
                namelist.Add("郭银全");
                namelist.Add("石智勇");
                for (int i = 0; i < 26; i++)
                {
                    var model = new HdPic()
                    {
                        Name = namelist[i],
                        Status = 0,
                        Orders = 0,
                        PicUrl = "r" + (i + 1) + ".jpg",
                        AddTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        Extend1 = "",
                        Extend2 = "56"
                    };
                    db.HdPic.AddObject(model);
                    db.SaveChanges();
                }
            }
        }
    }
}