using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// MsgHelper 的摘要说明
/// </summary>
public class MsgHelper
{
    public MsgHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static void SetCssStyle(string ctrls, UserControl _this)
    {
        string[] arr = ctrls.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        foreach (string id in arr)
        {
            TextBox txt = _this.FindControl(id) as TextBox ;

            if (null != txt)
            {
                txt.Attributes.Add("onfocus", "this.className='colorfocus';");
                txt.Attributes.Add("onblur", "this.className='colorblur';");
            }
        }
    }

    public static void SetCssStyle(string ctrls, Page _this)
    {
        string[] arr = ctrls.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        foreach (string id in arr)
        {
            TextBox txt = _this.Form.FindControl(id) as TextBox ;

            if (null != txt)
            {
                txt.Attributes.Add("onfocus", "this.className='colorfocus';");
                txt.Attributes.Add("onblur", "this.className='colorblur';");
            }
        }
    }

    public static void SetCssStyle(TextBox[] txtArr)
    {
        foreach (TextBox box in txtArr)
        {
            box.Attributes.Add("onfocus", "this.className='colorfocus';");
            box.Attributes.Add("onblur", "this.className='colorblur';");
        }
    }

    
    public static void SetCssStyle(HtmlTextArea[] txtArr)
    {
        foreach (HtmlTextArea box in txtArr)
        {
            box.Attributes.Add("onfocus", "this.className='colorfocus';");
            box.Attributes.Add("onblur", "this.className='colorblur';");
        }
    }

    public static string GetSex(string strSex)
    {
        return (strSex == "女") ? "0" : "1";
    }

    public static string GetSubscribeMode(object i)
    {
        return (i.ToString() == "1") ? "按金额" : "按时间";
    }

    public static string GetNoteNums(object strNote)
    {
        if (object.Equals(strNote, null))
            return "0";
        else
            return ((int)((strNote.ToString().Length) / 140) + 1).ToString();
    }
}
