using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace NewInfoWeb.manage
{
    public partial class img : System.Web.UI.Page
    {
        private int codeLen = 4;
        // 图片清晰度
        private int fineness = 96;
        // 图片宽度
        private int imgWidth = 48;
        // 图片高度
        private int imgHeight = 18;
        // 字体家族名称
        private string fontFamily = "Times New Roman";
        // 字体大小
        private int fontSize = 12;
        // 字体样式
        private int fontStyle = 1;
        // 绘制起始坐标 X
        private int posX = 5;
        // 绘制起始坐标 Y
        private int posY = 0;
        // 图片背景色
        private Color pbgColor = Color.FromArgb(236, 245, 252);
        // 字体颜色
        private Brush fontBrushe = Brushes.Firebrick;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(Request.QueryString["ctype"]))
            //    libUtil.Instance.GenerateNums();
            //else
            //    libUtil.Instance.GenerateNums(Request.QueryString["ctype"]);
            GenerateNums("CZJDWXCheckCode");
        }



        /// <summary>
        /// 产生包含验证数字的图片并将数字保存在 Session 之中 
        /// </summary>
        public void GenerateNums()
        {
            GenerateNums("confirm");
        }

        //----------------------------------------------------------
        // 创建随机验证码
        //----------------------------------------------------------
        private string CreateValidateCode(string sessionkey)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9";
            char[] sp = (",").ToCharArray();
            string[] VcArray = Vchar.Split(sp);
            string VNum = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < codeLen; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(9);
                if (temp != -1 && temp == t)
                {
                    return CreateValidateCode(sessionkey);
                }
                temp = t;
                VNum += VcArray[t];
            }
            // 保存验证码//
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(sessionkey, VNum));
            //HttpContext.Current.Session[sessionkey] = VNum;
            return VNum;
        }

        //------------------------------------------------------------
        // 为图片设置干扰点
        //------------------------------------------------------------
        private void DisturbBitmap(Bitmap bitmap)
        {
            // 通过随机数生成
            Random random = new Random();

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    if (random.Next(100) <= this.fineness)
                        bitmap.SetPixel(i, j, pbgColor);
                }
            }
        }

        //------------------------------------------------------------
        // 绘制验证码图片
        //------------------------------------------------------------
        private void DrawValidateCode(Bitmap bitmap, string validateCode)
        {
            // 获取绘制器对象
            Graphics g = Graphics.FromImage(bitmap);

            // 设置绘制字体
            Font font = new Font(fontFamily, fontSize, GetFontStyle());

            // 绘制验证码图像
            g.DrawString(validateCode, font, fontBrushe, posX, posY);
        }

        //------------------------------------------------------------
        // 换算验证码字体样式：1 粗体 2 斜体 3 粗斜体，默认为普通字体
        //------------------------------------------------------------
        private FontStyle GetFontStyle()
        {
            if (fontStyle == 1)
                return FontStyle.Bold;
            else if (fontStyle == 2)
                return FontStyle.Italic;
            else if (fontStyle == 3)
                return FontStyle.Bold | FontStyle.Italic;
            else
                return FontStyle.Regular;
        }


        public void GenerateNums(string sessionkey)
        {
            string validateCode = CreateValidateCode(sessionkey);

            // 生成BITMAP图像
            Bitmap bitmap = new Bitmap(imgWidth, imgHeight);

            // 给图像设置干扰
            DisturbBitmap(bitmap);

            // 绘制验证码图像
            DrawValidateCode(bitmap, validateCode);

            // 保存验证码图像，等待输出
            bitmap.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Gif);
        }
    }
}