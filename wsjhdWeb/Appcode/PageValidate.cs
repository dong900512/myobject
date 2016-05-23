using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


/// <summary>
/// 页面数据校验类
/// </summary>
public class PageValidate
{
    private static Regex RegNumber = new Regex("^[0-9]+$");
    private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
    private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
    private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
    private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
    private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");

    /****************2011-9-15增加验证手机和电话******************/
    private static Regex RegMobilePhone = new Regex("\\d{11}");
    private static Regex RegPhone = new Regex("((\\d{11})|^((\\d{7,8})|(\\d{4}|\\d{3})-(\\d{7,8})|(\\d{4}|\\d{3})-(\\d{7,8})-(\\d{4}|\\d{3}|\\d{2}|\\d{1})|(\\d{7,8})-(\\d{4}|\\d{3}|\\d{2}|\\d{1}))$)");
    
    /****************2011-9-15增加验证手机和电话*******************/

    public PageValidate()
    {
    }

    #region 电话手机
    /// <summary>
    /// 验证是否合法的电话号码
    /// </summary>
    /// <param name="phone">号码</param>
    /// <param name="regtext">自定义正则表达式</param>
    /// <returns>验证结果</returns>
    public static bool CheckPhone(string phone, string regtext)
    {
        if (!string.IsNullOrEmpty(regtext))
        {
            return RegPhone.Match(phone).Success;
        }
        else
        {
            Regex regp = new Regex(regtext);
            return regp.Match(phone).Success;
        }
    }

    /// <summary>
    /// 验证是否合法的手机号码
    /// </summary>
    /// <param name="mphone">号码</param>
    /// <param name="regtext">自定义正则表达式</param>
    /// <returns>验证结果</returns>
    public static bool CheckMobilePhone(string mphone, string regtext)
    {
        if (!string.IsNullOrEmpty(regtext))
        {
            return RegMobilePhone.Match(mphone).Success;
        }
        else
        {
            Regex regp = new Regex(regtext);
            return regp.Match(mphone).Success;
        }
    }

    #endregion

    #region 数字字符串检查

    /// <summary>
    /// 检查Request查询字符串的键值，是否是数字，最大长度限制
    /// </summary>
    /// <param name="req">Request</param>
    /// <param name="inputKey">Request的键值</param>
    /// <param name="maxLen">最大长度</param>
    /// <returns>返回Request查询字符串</returns>
    public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
    {
        string retVal = string.Empty;
        if (inputKey != null && inputKey != string.Empty)
        {
            retVal = req.QueryString[inputKey];
            if (null == retVal)
                retVal = req.Form[inputKey];
            if (null != retVal)
            {
                retVal = SqlText(retVal, maxLen);
                if (!IsNumber(retVal))
                    retVal = string.Empty;
            }
        }
        if (retVal == null)
            retVal = string.Empty;
        return retVal;
    }
    /// <summary>
    /// 是否数字字符串
    /// </summary>
    /// <param name="inputData">输入字符串</param>
    /// <returns></returns>
    public static bool IsNumber(string inputData)
    {
        Match m = RegNumber.Match(inputData);
        return m.Success;
    }

    /// <summary>
    /// 检查是否含有：@、insert、delete、update、;、"
    /// </summary>
    /// <param name="inputData"></param>
    /// <returns>有 false</returns>
    public static bool ContainSenstiveCode(string inputData)
    {
        try
        {
            if (inputData.Replace(" ", "") == "")
                return true;
            else if (inputData.Contains("@") || inputData.ToLower().Contains("update") || inputData.Contains(";") || inputData.Contains("\"") || inputData.ToLower().Contains("insert") || inputData.ToLower().Contains("delete"))
                return false;
            else
                return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    /// 是否数字字符串 可带正负号
    /// </summary>
    /// <param name="inputData">输入字符串</param>
    /// <returns></returns>
    public static bool IsNumberSign(string inputData)
    {
        Match m = RegNumberSign.Match(inputData);
        return m.Success;
    }

    /// <summary>
    /// 去掉敏感的字符
    /// </summary>
    /// <param name="inputstr"></param>
    /// <returns></returns>
    public static string RemoveSensitiveString(string inputstr)
    {
        if (string.IsNullOrEmpty(inputstr))
            return "";
        else
        {
            return inputstr.Replace(" ", "").Replace("|", "").Replace("@", "").Replace(";", "").Replace("&", "").Replace("%", "");
        }
    }

    /// <summary>
    /// 去掉一些字符
    /// </summary>
    /// <param name="inputstr"></param>
    /// <returns></returns>
    public static string ReplaceSomeStr(string inputstr)
    {
        if (string.IsNullOrEmpty(inputstr))
            return inputstr;

        return inputstr.Replace("@", "").Replace("|", "").Replace(";", "").Replace("%", "").Replace("!", "").Replace("#", "").Replace("&", "").Replace("*", "");
    }

    /// <summary>
    /// 去掉敏感的字符
    /// </summary>
    /// <param name="inputstr"></param>
    /// <returns></returns>
    public static string RemoveSensitiveStringNotEmail(string inputstr)
    {
        if (string.IsNullOrEmpty(inputstr))
            return "";
        else
        {
            return inputstr.Replace(" ", "").Replace("|", "").Replace(";", "").Replace("&", "").Replace("%", "").Replace("_", "").Replace(",", "");
        }
    }


    /// <summary>
    /// 是否是浮点数
    /// </summary>
    /// <param name="inputData">输入字符串</param>
    /// <returns></returns>
    public static bool IsDecimal(string inputData)
    {
        Match m = RegDecimal.Match(inputData);
        return m.Success;
    }
    /// <summary>
    /// 是否是浮点数 可带正负号
    /// </summary>
    /// <param name="inputData">输入字符串</param>
    /// <returns></returns>
    public static bool IsDecimalSign(string inputData)
    {
        Match m = RegDecimalSign.Match(inputData);
        return m.Success;
    }

    #endregion

    #region 中文检测

    /// <summary>
    /// 检测是否有中文字符
    /// </summary>
    /// <param name="inputData"></param>
    /// <returns></returns>
    public static bool IsHasCHZN(string inputData)
    {
        Match m = RegCHZN.Match(inputData);
        return m.Success;
    }

    #endregion

    #region 邮件地址
    /// <summary>
    /// 是否是浮点数 可带正负号
    /// </summary>
    /// <param name="inputData">输入字符串</param>
    /// <returns></returns>
    public static bool IsEmail(string inputData)
    {
        Match m = RegEmail.Match(inputData);
        return m.Success;
    }

    #endregion

    #region 其他

    /// <summary>
    /// 检查字符串最大长度，返回指定长度的串
    /// </summary>
    /// <param name="sqlInput">输入字符串</param>
    /// <param name="maxLength">最大长度</param>
    /// <returns></returns>			
    public static string SqlText(string sqlInput, int maxLength)
    {
        if (sqlInput != null && sqlInput != string.Empty)
        {
            sqlInput = sqlInput.Trim();
            if (sqlInput.Length > maxLength)//按最大长度截取字符串
                sqlInput = sqlInput.Substring(0, maxLength);
        }
        return sqlInput;
    }


    /// <summary>
    /// 字符串编码
    /// </summary>
    /// <param name="inputData"></param>
    /// <returns></returns>
    public static string HtmlEncode(string inputData)
    {
        return HttpUtility.HtmlEncode(inputData);
    }
    /// <summary>
    /// 设置Label显示Encode的字符串
    /// </summary>
    /// <param name="lbl"></param>
    /// <param name="txtInput"></param>
    public static void SetLabel(Label lbl, string txtInput)
    {
        lbl.Text = HtmlEncode(txtInput);
    }
    public static void SetLabel(Label lbl, object inputObj)
    {
        SetLabel(lbl, inputObj.ToString());
    }

    #endregion

    #region 文新车信息数据库
    /// <summary>
    /// 文新车信息表的名字
    /// </summary>
    public static string GetWinXinTableName
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["wenxinTable"].ToString();
        }
    }

    /// <summary>
    /// 返回文新车信息表的主键
    /// </summary>
    public static string GetPrimaryKeyName
    {
        get
        {
            return "id";
        }
    }

    /// <summary>
    /// 厢式  0为空 1单厢  2两厢  3两厢半 4三厢
    /// </summary>
    public static string[] BoxTypeList
    {
        get
        {
            return new string[] { "" + "单厢", "两厢", "两厢半", "三厢" };
        }
    }

    /// <summary>
    /// 变速方式  0手动 1自动 2手/自一体
    /// </summary>
    public static string[] ChangeSpeedMethod
    {
        get
        {
            return new string[] { "手动", "自动", "手/自一体" };
        }
    }

    /// <summary>
    /// 返回东昌代理的厂商的列表
    /// </summary>
    public static string[] DcFactoryList
    {
        get
        {
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["dcfactory"]))
            {
                string[] factorylist = System.Configuration.ConfigurationManager.AppSettings["dcfactory"].ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                return factorylist;
            }
            return null;
        }
    }

    /// <summary>
    /// 返回东昌代理的品牌的列表
    /// </summary>
    public static string[] DcBrandList
    {
        get
        {
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["dcbrand"]))
            {
                string[] brandlist = System.Configuration.ConfigurationManager.AppSettings["dcbrand"].ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                return brandlist;
            }
            return null;
        }
    }

    /// <summary>
    /// 碳减排链接地址
    /// </summary>
    public static string JianPaiUrl
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["jianpai"];
        }
    }

    /// <summary>
    /// 页面底部友情链接的数量
    /// </summary>
    public static string FlinkNum
    {
        get { return System.Configuration.ConfigurationManager.AppSettings["flinknum"]; }
    }
    #endregion
}
