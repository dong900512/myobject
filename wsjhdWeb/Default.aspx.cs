using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;
namespace NewInfoWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //jsHint.Alert(Convert.ToInt32(WebConn.MembersLevel.YK).ToString());
            CreateMent();
        }
        #region 生成菜单
        public void CreateMent()
        {
            ButtonGroup bg = new ButtonGroup();

            //var subButton1 = new SingleViewButton()
            //{
            //    url = "http://djinfo.tencenthouse.com/holiday/ltindex.html",
            //    name = "东郊罗兰官微"
            //};
            //单击
            var subButton1 = new SubButton()
            {
                name = "楼盘简介"
            };
            var subButton2 = new SubButton()
            {
                name = "互动中心"
            };
            var subButton3 = new SubButton()
            {
                name = "预约看房"
            };
            subButton1.sub_button.Add(new SingleViewButton()
            {
                url = "http://djinfo.tencenthouse.com/holiday/ltindex.html",
                name = "项目简介"
            });
            subButton1.sub_button.Add(new SingleViewButton()
            {
                url = "http://djinfo.tencenthouse.com/holiday/index.htm",
                name = "楼盘属性"
            });
            //subButton1.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://jmys.tencenthouse.com/yqh/djinfo.htm",
            //    name = "微楼书"
            //});
            //subButton1.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://ytx.tencenthouse.com/holiday/huxing.html",
            //    name = "户型展示"
            //});
            //subButton1.sub_button.Add(new SingleClickButton()
            //{
            //    key = "SubClick_sh",
            //    name = "开盘预告"
            //});
            subButton2.sub_button.Add(new SingleViewButton()
            {
                url = "http://zhengrongsh.tencenthouse.com/yqh/djls.htm",
                name = "非凡礼遇"
            });
            subButton2.sub_button.Add(new SingleViewButton()
            {
                url = "http://jmys.tencenthouse.com/yqh/djhd1.htm",
                name = "东郊大事"
            });
            subButton2.sub_button.Add(new SingleViewButton()
            {
                url = "http://djinfo.tencenthouse.com/holiday/newInfo.htm",
                name = "品牌咨询"
            });
            //subButton2.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://djinfo.tencenthouse.com/holiday/NewsActivity.htm",
            //    name = "活动中心"
            //});
            //subButton2.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://djinfo.tencenthouse.com/holiday/video.htm",
            //    name = "影视中心"
            //});
            //subButton2.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://hdyjw.tencenthouse.com/holiday/NewsActivity.htm",
            //    name = "活动预告"
            //});

            //subButton3.sub_button.Add(new SingleClickButton()
            //{
            //    key = "SubClick_sh",
            //    name = "售后服务电话"
            //});
            //subButton3.sub_button.Add(new SingleClickButton()
            //{
            //    key = "SubClick_xs",
            //    name = "客户专线"
            //});
            //subButton3.sub_button.Add(new SingleClickButton()
            //{
            //    key = "SubClick_jt",
            //    name = "交通指引"
            //});
            //subButton3.sub_button.Add(new SingleClickButton()
            //{
            //    key = "SubClick_xm",
            //    name = "项目地址"
            //});
            subButton3.sub_button.Add(new SingleViewButton()
            {
                url = "http://djinfo.tencenthouse.com/holiday/yykf.htm",
                name = "在线预约"
            });
            //subButton3.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://djinfo.tencenthouse.com/holiday/zxkf.htm",
            //    name = "在线咨询"
            //});
            //subButton3.sub_button.Add(new SingleClickButton()
            //{
            //    key = "SubClickRoot_Customer",
            //    name = "智能客服"
            //});
            //subButton1.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://hdyjw.tencenthouse.com/holiday/ls.htm",
            //    name = "微楼书"
            //});
            //subButton1.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://hddj.tencenthouse.com/yqh/info1.htm",
            //    name = "9A精装"
            //});

            //subButton1.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://hddj.tencenthouse.com/holiday/picwall.aspx",
            //    name = "楼盘相册"
            //});
            //subButton1.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://hdyjw.tencenthouse.com/holiday/huxing.html",
            //    name = "户型欣赏"
            //});
            //subButton1.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://hdyjw.tencenthouse.com/sample/product02_os.html",
            //    name = "联系我们"
            //});
            //subButton1.sub_button.Add(new SingleClickButton()
            //{
            //    key = "SubClickRoot_Customer",
            //    name = "智能客服"
            //});
            bg.button.Add(subButton1);
            //二级菜单
            //var subButton2 = new SubButton()
            //{
            //    name = "互动专区"
            //};
            //subButton2.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://hdyjw.tencenthouse.com/holiday/kfinfo.htm",
            //    name = "看房有礼"
            //});
            //subButton2.sub_button.Add(new SingleViewButton()
            //{
            //    url = "http://hdyjw.tencenthouse.com/holiday/NewsActivity.htm",
            //    name = "活动专区"
            //});
            bg.button.Add(subButton2);
            bg.button.Add(subButton3);
            var result = CommonApi.CreateMenu(WXhelper.Instance.CurrenToken(), bg);
        }
        #endregion
    }
}
