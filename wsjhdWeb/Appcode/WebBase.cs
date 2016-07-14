using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.Web.UI.HtmlControls;

/// <summary>
/// 供 web 层调用的通用方法提供类
/// </summary>
public sealed class WebUtil
{

    /// <summary>
    /// asp.net上传图片并生成缩略图
    /// </summary>
    /// <param name="upImage">HtmlInputFile控件</param>
    /// <param name="sSavePath">保存的路径,些为相对服务器路径的下的文件夹</param>
    /// <param name="sThumbExtension">缩略图的thumb</param>
    /// <param name="intThumbWidth">生成缩略图的宽度</param>
    /// <param name="intThumbHeight">生成缩略图的高度</param>
    /// <returns>缩略图名称</returns>
    public static string UpLoadImage(HtmlInputFile upImage, string sSavePath, string sThumbExtension, int intThumbWidth, int intThumbHeight)
    {
        string sThumbFile = "";
        string sFilename = "";
        if (upImage.PostedFile != null)
        {
            HttpPostedFile myFile = upImage.PostedFile;
            int nFileLen = myFile.ContentLength;
            if (nFileLen == 0)
                return "0";
            //获取upImage选择文件的扩展名
            string extendName = System.IO.Path.GetExtension(myFile.FileName).ToLower();
            //判断是否为图片格式
            if (extendName != ".jpg" && extendName != ".jpge" && extendName != ".gif" && extendName != ".bmp" && extendName != ".png")
                return "0";

            byte[] myData = new Byte[nFileLen];
            myFile.InputStream.Read(myData, 0, nFileLen);
            sFilename = System.IO.Path.GetFileName(myFile.FileName);
            int file_append = 0;
            //检查当前文件夹下是否有同名图片,有则在文件名+1
            while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename)))
            {
                file_append++;
                sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                    + file_append.ToString() + extendName;
            }
            System.IO.FileStream newFile
                = new System.IO.FileStream(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename),
                System.IO.FileMode.Create, System.IO.FileAccess.Write);
            newFile.Write(myData, 0, myData.Length);
            newFile.Close();
            //以上为上传原图
            try
            {
                //原图加载
                using (System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename)))
                {
                    //原图宽度和高度
                    int width = sourceImage.Width;
                    int height = sourceImage.Height;
                    int smallWidth;
                    int smallHeight;
                    //获取第一张绘制图的大小,(比较 原图的宽/缩略图的宽  和 原图的高/缩略图的高)
                    if (((decimal)width) / height <= ((decimal)intThumbWidth) / intThumbHeight)
                    {
                        smallWidth = intThumbWidth;
                        smallHeight = intThumbWidth * height / width;
                    }
                    else
                    {
                        smallWidth = intThumbHeight * width / height;
                        smallHeight = intThumbHeight;
                    }
                    //判断缩略图在当前文件夹下是否同名称文件存在
                    file_append = 0;
                    //sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + extendName;
                    sThumbFile = sThumbExtension + extendName;
                    while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sThumbFile)))
                    {
                        file_append++;
                        //+ System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) +
                        sThumbFile = sThumbExtension + file_append.ToString() + extendName;
                    }
                    //缩略图保存的绝对路径
                    string smallImagePath = System.Web.HttpContext.Current.Server.MapPath(sSavePath) + sThumbFile;
                    //新建一个图板,以最小等比例压缩大小绘制原图
                    using (System.Drawing.Image bitmap = new System.Drawing.Bitmap(smallWidth, smallHeight))
                    {
                        //绘制中间图
                        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                        {
                            //高清,平滑
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.Clear(Color.Black);
                            g.DrawImage(
                            sourceImage,
                            new System.Drawing.Rectangle(0, 0, smallWidth, smallHeight),
                            new System.Drawing.Rectangle(0, 0, width, height),
                            System.Drawing.GraphicsUnit.Pixel
                            );
                        }
                        //新建一个图板,以缩略图大小绘制中间图
                        using (System.Drawing.Image bitmap1 = new System.Drawing.Bitmap(intThumbWidth, intThumbHeight))
                        {
                            //绘制缩略图  http://www.cnblogs.com/sosoft/
                            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap1))
                            {
                                //高清,平滑
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.Clear(Color.Black);
                                int lwidth = (smallWidth - intThumbWidth) / 2;
                                int bheight = (smallHeight - intThumbHeight) / 2;
                                g.DrawImage(bitmap, new Rectangle(0, 0, intThumbWidth, intThumbHeight), lwidth, bheight, intThumbWidth, intThumbHeight, GraphicsUnit.Pixel);
                                g.Dispose();
                                bitmap1.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }
                    }
                }
            }
            catch
            {
                //出错则删除
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename));
                return "0";
            }
            finally
            {
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename));
            }

            //返回缩略图名称
            return sThumbFile;
        }
        return "0";
    }
    /// <summary>
    /// 根据指定长度检查字符串是否符合要求
    /// </summary>
    /// <param name="text">需要检查的字符串</param>
    /// <param name="maxLength">当前允许的最大长度</param>
    /// <returns>符合长度要求的字符串</returns>
    #region public static string InputText(string text, int maxLength)
    public static string InputText(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        if (text.Length > maxLength)
            return text.Substring(0, maxLength);

        return text;
    }
    #endregion
    ///手机号码验证
    public static bool IsHandset(string str_handset)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,5,8]+\d{9}");
    }
    /// <summary>
    /// 返回指定长度的字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    #region public static string Substring(object obj, int len)
    public static string Substring(object obj, int len)
    {
        string str = obj as string;

        if (string.IsNullOrEmpty(str))
            return string.Empty;

        if (str.Length >= len)
            return str.Substring(0, len) + "…";
        else
            return str.Substring(0, str.Length);
    }
    #endregion

    /// <summary>
    /// 判断是否全部为数字
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    #region public static bool IsDigit(object obj)
    public static bool IsDigit(object obj)
    {
        if (null == obj) return false;

        foreach (char ch in obj.ToString())
            if (!char.IsDigit(ch)) return false;

        return true;
    }
    #endregion

    /// <summary>
    /// 返回给定时间距现在时间间隔，单位为年
    /// </summary>
    /// <param name="dt">给定时间</param>
    /// <returns><距现在时间间隔/returns>
    #region public static double YearsByTime(string dt)
    public static double YearsByTime(string dt)
    {
        if (dt != null)
        {
            return Math.Ceiling(((TimeSpan)(DateTime.Now - DateTime.Parse(dt))).Days / 365.0);
        }
        else
            return 0;

    }
    #endregion

    /// <summary>
    /// 调用性别
    /// </summary>
    /// <param name="sex"></param>
    /// <returns></returns>
    #region public static string MemberSex(string sex)
    public static string MemberSex(string sex)
    {
        if (sex == "0")
            return "女";
        else
            return "男";
    }

    #endregion

    /// <summary>
    /// 根据指定长度检查字符串是否符合要求，并去除html字符
    /// </summary>
    /// <param name="text">需要检查的字符串</param>
    /// <param name="maxLength">当前允许的最大长度</param>
    /// <returns>符合长度要求的字符串</returns>
    #region public static string InputTextEx(string text, int maxLength)
    public static string InputTextEx(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        if (text.Length > maxLength)
            return text.Substring(0, maxLength);

        text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
        text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
        text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
        text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
        text = text.Replace("'", "''");

        return text;
    }
    #endregion

    /// <summary>
    /// 将控件绑定到指定集合
    /// </summary>
    /// <typeparam name="T">集合元素类型</typeparam>
    /// <param name="rpt">repeater 参数</param>
    /// <param name="list">集合</param>
    #region public static void CtrlToList<T>(Repeater rpt, List<T> list) where T:  new()
    public static void CtrlToList<T>(Repeater rpt, List<T> list) where T : new()
    {
        rpt.DataSource = list;
        rpt.DataBind();
    }
    #endregion

    /// <summary>
    /// 将控件绑定到指定集合
    /// </summary>
    /// <typeparam name="T">集合元素类型</typeparam>
    /// <param name="rpt">repeater 参数</param>
    /// <param name="list">集合</param>
    #region public static void CtrlToList<T>(Repeater rpt, IList<T> list) where T:  new()
    public static void CtrlToList<T>(Repeater rpt, IList<T> list) where T : new()
    {
        rpt.DataSource = list;
        rpt.DataBind();
    }
    #endregion

    /// <summary>
    /// 将下拉列表绑定到指定集合
    /// </summary>
    /// <typeparam name="T">集合元素类型</typeparam>
    /// <param name="drp">下拉列表</param>
    /// <param name="list">集合</param>
    /// <param name="disMember">显示元素</param>
    /// <param name="valMember">值元素</param>
    #region public static void DrpToList<T>(DropDownList drp, List<T> list, string disMember, string valMember) where T :  new()
    public static void DrpToList<T>(DropDownList drp, List<T> list, string disMember, string valMember) where T : new()
    {
        drp.Items.Clear();

        drp.DataSource = list;
        drp.DataTextField = disMember;
        drp.DataValueField = valMember;

        drp.DataBind();
    }
    #endregion

    /// <summary>
    /// 将下拉列表绑定到指定集合并添加默认项
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="drp"></param>
    /// <param name="list"></param>
    /// <param name="disMember"></param>
    /// <param name="valMember"></param>
    #region  public static void DrpToListEx<T>(DropDownList drp, List<T> list, string disMember, string valMember) where T : new()
    public static void DrpToListEx<T>(DropDownList drp, IList<T> list, string disMember, string valMember) where T : new()
    {
        drp.Items.Clear();

        drp.DataSource = list;
        drp.DataTextField = disMember;
        drp.DataValueField = valMember;

        drp.DataBind();
        AddEmptyItem(drp, "--请选择--", "-1");
    }

    public static void DropToIList<T>(DropDownList drp, IList<T> list, string disMember, string valMember) where T : new()
    {
        drp.Items.Clear();

        drp.DataSource = list;
        drp.DataTextField = disMember;
        drp.DataValueField = valMember;

        drp.DataBind();
    }
    #endregion

    /// <summary>
    /// 将CheckBoxList绑定到指定集合并添加默认项
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="drp"></param>
    /// <param name="list"></param>
    /// <param name="disMember"></param>
    /// <param name="valMember"></param>
    #region  public static void CheckBoxListEx<T>(CheckBoxList cbl, List<T> list, string disMember, string valMember) where T : new()
    public static void CheckBoxListEx<T>(CheckBoxList cbl, IList<T> list, string disMember, string valMember) where T : new()
    {
        cbl.Items.Clear();

        cbl.DataSource = list;
        cbl.DataTextField = disMember;
        cbl.DataValueField = valMember;

        cbl.DataBind();
        //AddEmptyItem(cbl, "--请选择--", "-1");
    }
    #endregion
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="drp"></param>
    /// <param name="list"></param>
    /// <param name="disMember"></param>
    /// <param name="valMember"></param>
    /// <param name="firstSelection">首选项</param>
    #region public static void DrpToListEx<T>(DropDownList drp, List<T> list, string disMember, string valMember) where T : new()
    public static void DrpToListEx<T>(DropDownList drp, IList<T> list, string disMember, string valMember, string firstSelection) where T : new()
    {
        drp.Items.Clear();

        drp.DataSource = list;
        drp.DataTextField = disMember;
        drp.DataValueField = valMember;

        drp.DataBind();
        AddEmptyItem(drp, firstSelection, "-1");
    }
    #endregion

    /// <summary>
    /// 将下拉列表绑定到 IList<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="drp"></param>
    /// <param name="list"></param>
    /// <param name="disMember"></param>
    /// <param name="valMember"></param>
    //#region public static void DrpToListEx<T>(DropDownList drp, IList<T> list, string disMember, string valMember) where T : new()
    //public static void DrpToListEx<T>(DropDownList drp, IList<T> list, string disMember, string valMember) where T : new()
    //{
    //    drp.Items.Clear();

    //    drp.DataSource = list;
    //    drp.DataTextField = disMember;
    //    drp.DataValueField = valMember;

    //    drp.DataBind();
    //    AddEmptyItem(drp, "--请选择--", "-1");
    //}
    //#endregion

    /// <summary>
    /// 向下拉列表框添加新数据
    /// </summary>
    /// <param name="drp">下拉列表框</param>
    /// <param name="strText">文本</param>
    /// <param name="strValue">值</param>
    #region public static void AddEmptyItem(DropDownList drp, string strText, string strValue)
    public static void AddEmptyItem(DropDownList drp, string strText, string strValue)
    {
        drp.Items.Insert(0, new ListItem(strText, strValue));
    }
    #endregion

    /// <summary>
    /// 向cbl添加新数据
    /// </summary>
    /// <param name="drp">cbl</param>
    /// <param name="strText">文本</param>
    /// <param name="strValue">值</param>
    #region public static void AddEmptyItem(cbl drp, string strText, string strValue)
    public static void AddEmptyItem(CheckBoxList cbl, string strText, string strValue)
    {
        cbl.Items.Insert(0, new ListItem(strText, strValue));
    }
    #endregion
    /// <summary>
    /// 将控件绑定到实现 IList 接口的集合
    /// </summary>
    /// <param name="rpt"></param>
    /// <param name="list"></param>
    #region public static void CtrlToIList(Repeater rpt, IList list)
    public static void CtrlToIList(Repeater rpt, IList list)
    {
        rpt.DataSource = list;
        rpt.DataBind();
    }
    #endregion

    /// <summary>
    /// 将 下拉列表绑定到 IList
    /// </summary>
    /// <param name="drp"></param>
    /// <param name="list"></param>
    /// <param name="disMember"></param>
    /// <param name="valMember"></param>
    #region public static void DrpToIList(DropDownList drp, IList list, string disMember, string valMember)
    public static void DrpToIList(DropDownList drp, IList list, string disMember, string valMember)
    {
        drp.Items.Clear();

        drp.DataSource = list;
        drp.DataTextField = disMember;
        drp.DataValueField = valMember;

        drp.DataBind();
    }
    #endregion


    /// <summary>
    /// 将 下拉列表绑定到 IList并提供默认项
    /// </summary>
    /// <param name="drp"></param>
    /// <param name="list"></param>
    /// <param name="disMember"></param>
    /// <param name="valMember"></param>
    #region public static void DrpToIListEx(DropDownList drp, IList list, string disMember, string valMember)
    public static void DrpToIListEx(DropDownList drp, IList list, string disMember, string valMember)
    {
        drp.Items.Clear();

        drp.DataSource = list;
        drp.DataTextField = disMember;
        drp.DataValueField = valMember;

        drp.DataBind();

        AddEmptyItem(drp, "请选择类别", "-1");
    }
    #endregion

    /// <summary>
    /// 将 下拉列表绑定到 IList并选中指定 项
    /// </summary>
    /// <param name="drp"></param>
    /// <param name="list"></param>
    /// <param name="disMember"></param>
    /// <param name="valMember"></param>
    #region public static void DrpToIListEx(DropDownList drp, IList list, string disMember, string valMember, string selVal)
    public static void DrpToIListEx(DropDownList drp, IList list, string disMember, string valMember, string selVal)
    {
        drp.Items.Clear();

        drp.DataSource = list;
        drp.DataTextField = disMember;
        drp.DataValueField = valMember;

        drp.DataBind();

        AddEmptyItem(drp, "--请选择--", "-1");
        drp.SelectedIndex = -1;
        ListItem item = drp.Items.FindByValue(selVal);
        if (item != null)
            item.Selected = true;
    }
    #endregion

    public static void DrpToIListEx(DropDownList drp, IList list, string disMember, string valMember, string selVal, string hintTxt)
    {
        drp.Items.Clear();

        drp.DataSource = list;
        drp.DataTextField = disMember;
        drp.DataValueField = valMember;

        drp.DataBind();

        AddEmptyItem(drp, hintTxt, "-1");
        drp.SelectedIndex = -1;
        ListItem item = drp.Items.FindByValue(selVal);
        if (item != null)
            item.Selected = true;
    }



    /// <summary>
    /// 将普通富文本转化为HTML内容输出
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string OutputText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        text = text.Replace(" ", "&nbsp;");
        text = text.Replace("\r\n", "<br>");

        return text;
    }

    public static string OutputIp(object Ip)
    {
        string ip = Ip as string;

        return ip.Substring(0, ip.LastIndexOf('.')) + ".*";
    }


    /// <summary>
    /// 判断 paramarr 里面是否存在null
    /// </summary>
    /// <param name="paramarr">待检查的可变长度的数组</param>
    /// <returns></returns>
    #region public bool IsValidParams(params object[] paramarr)
    public static bool IsValidParams(params object[] paramarr)
    {
        for (int i = 0; i < paramarr.Length; i++)
        {
            if (string.IsNullOrEmpty(paramarr[i] as string) || !WebUtil.IsDigit(paramarr[i]))
                return false;
        }

        return true;
    }
    #endregion


    /// <summary>
    /// 判断 paramarr为 查询字符串名称的数组里是否存在null
    /// </summary>
    /// <param name="paramarr">查询字符串名称的数组</param>
    /// <returns></returns>
    #region public static bool IsValidParamsEx(params object[] paramarr)
    public static bool IsValidParamsEx(params object[] paramarr)
    {
        for (int i = 0; i < paramarr.Length; i++)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request[paramarr[i] as string]) || !WebUtil.IsDigit(HttpContext.Current.Request[paramarr[i] as string]))
                return false;
        }

        return true;
    }
    #endregion

    /// <summary>
    /// 将CheckBoxList绑定到IList
    /// </summary>
    /// <param name="cbl"></param>
    /// <param name="list"></param>
    /// <param name="disMember"></param>
    /// <param name="valMember"></param>
    #region public static void CblToIList(CheckBoxList cbl, IList list, string disMember, string valMember)
    public static void CblToIList(CheckBoxList cbl, IList list, string disMember, string valMember)
    {
        cbl.Items.Clear();

        cbl.DataSource = list;
        cbl.DataTextField = disMember;
        cbl.DataValueField = valMember;

        cbl.DataBind();

    }

    #endregion

    public static void CblToIList(RadioButtonList cbl, IList list, string disMember, string valMember)
    {
        cbl.Items.Clear();

        cbl.DataSource = list;
        cbl.DataTextField = disMember;
        cbl.DataValueField = valMember;

        cbl.DataBind();

    }


    public static void CblToIList(RadioButtonList cbl, IList list, string disMember, string valMember, object selval)
    {
        cbl.Items.Clear();

        cbl.DataSource = list;
        cbl.DataTextField = disMember;
        cbl.DataValueField = valMember;

        cbl.DataBind();

        cbl.SelectedValue = selval.ToString();

    }

    #region public static void CblToIListEx(CheckBoxList cbl, IList list, string disMember, string valMember, params int[] typeArr)
    public static void CblToIListEx(CheckBoxList cbl, IList list, string disMember, string valMember, IEnumerable typeArr)
    {
        cbl.Items.Clear();

        cbl.DataSource = list;
        cbl.DataTextField = disMember;
        cbl.DataValueField = valMember;

        cbl.DataBind();

        System.Collections.IEnumerator myEnumerator = typeArr.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            ListItem item = cbl.Items.FindByValue(myEnumerator.Current.ToString());
            if (item != null)
                item.Selected = true;
        }

    }
    #endregion

    /// <summary>
    /// 全角转换成半角
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    #region 全角转换成半角
    public static string ToDBC(string input)
    {
        char[] c = input.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == 12288)
            {
                c[i] = (char)32;
                continue;
            }
            if (c[i] > 65280 && c[i] < 65375)
                c[i] = (char)(c[i] - 65248);
        }
        return new string(c);
    }
    #endregion

    public static string DelHTML(string Htmlstring)//将HTML去除
    {
        #region
        //删除脚本

        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

        //删除HTML

        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);


        Htmlstring.Replace("<", "");

        Htmlstring.Replace(">", "");

        Htmlstring.Replace("\r\n", "");

        #endregion


        return Htmlstring;

    }
}



#region calcCountEventHandler Declare

public delegate void calcCountEventHandler(object sender, countEventArgs e);

public class countEventArgs : EventArgs
{
    int count;

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public countEventArgs(int parm)
    {
        count = parm;
    }
}

#endregion
