using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;

    /// <summary>
    /// �� web ����õ�ͨ�÷����ṩ��
    /// </summary>
public sealed class WebUtil
{
    /// <summary>
    /// ����ָ�����ȼ���ַ����Ƿ����Ҫ��
    /// </summary>
    /// <param name="text">��Ҫ�����ַ���</param>
    /// <param name="maxLength">��ǰ�������󳤶�</param>
    /// <returns>���ϳ���Ҫ����ַ���</returns>
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
    ///�ֻ�������֤
    public static bool IsHandset(string str_handset)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,5,8]+\d{9}");
    }
    /// <summary>
    /// ����ָ�����ȵ��ַ���
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
            return str.Substring(0, len) + "��";
        else
            return str.Substring(0, str.Length);
    }
    #endregion

    /// <summary>
    /// �ж��Ƿ�ȫ��Ϊ����
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
    /// ���ظ���ʱ�������ʱ��������λΪ��
    /// </summary>
    /// <param name="dt">����ʱ��</param>
    /// <returns><������ʱ����/returns>
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
    /// �����Ա�
    /// </summary>
    /// <param name="sex"></param>
    /// <returns></returns>
    #region public static string MemberSex(string sex)
    public static string MemberSex(string sex)
    {
        if (sex == "0")
            return "Ů";
        else
            return "��";
    }

    #endregion

    /// <summary>
    /// ����ָ�����ȼ���ַ����Ƿ����Ҫ�󣬲�ȥ��html�ַ�
    /// </summary>
    /// <param name="text">��Ҫ�����ַ���</param>
    /// <param name="maxLength">��ǰ�������󳤶�</param>
    /// <returns>���ϳ���Ҫ����ַ���</returns>
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
    /// ���ؼ��󶨵�ָ������
    /// </summary>
    /// <typeparam name="T">����Ԫ������</typeparam>
    /// <param name="rpt">repeater ����</param>
    /// <param name="list">����</param>
    #region public static void CtrlToList<T>(Repeater rpt, List<T> list) where T:  new()
    public static void CtrlToList<T>(Repeater rpt, List<T> list) where T : new()
    {
        rpt.DataSource = list;
        rpt.DataBind();
    }
    #endregion

    /// <summary>
    /// ���ؼ��󶨵�ָ������
    /// </summary>
    /// <typeparam name="T">����Ԫ������</typeparam>
    /// <param name="rpt">repeater ����</param>
    /// <param name="list">����</param>
    #region public static void CtrlToList<T>(Repeater rpt, IList<T> list) where T:  new()
    public static void CtrlToList<T>(Repeater rpt, IList<T> list) where T : new()
    {
        rpt.DataSource = list;
        rpt.DataBind();
    }
    #endregion

    /// <summary>
    /// �������б�󶨵�ָ������
    /// </summary>
    /// <typeparam name="T">����Ԫ������</typeparam>
    /// <param name="drp">�����б�</param>
    /// <param name="list">����</param>
    /// <param name="disMember">��ʾԪ��</param>
    /// <param name="valMember">ֵԪ��</param>
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
    /// �������б�󶨵�ָ�����ϲ����Ĭ����
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
        AddEmptyItem(drp, "--��ѡ��--", "-1");
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
    /// ��CheckBoxList�󶨵�ָ�����ϲ����Ĭ����
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
        //AddEmptyItem(cbl, "--��ѡ��--", "-1");
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
    /// <param name="firstSelection">��ѡ��</param>
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
    /// �������б�󶨵� IList<T>
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
    //    AddEmptyItem(drp, "--��ѡ��--", "-1");
    //}
    //#endregion

    /// <summary>
    /// �������б�����������
    /// </summary>
    /// <param name="drp">�����б��</param>
    /// <param name="strText">�ı�</param>
    /// <param name="strValue">ֵ</param>
    #region public static void AddEmptyItem(DropDownList drp, string strText, string strValue)
    public static void AddEmptyItem(DropDownList drp, string strText, string strValue)
    {
        drp.Items.Insert(0, new ListItem(strText, strValue));
    }
    #endregion

    /// <summary>
    /// ��cbl���������
    /// </summary>
    /// <param name="drp">cbl</param>
    /// <param name="strText">�ı�</param>
    /// <param name="strValue">ֵ</param>
    #region public static void AddEmptyItem(cbl drp, string strText, string strValue)
    public static void AddEmptyItem(CheckBoxList cbl, string strText, string strValue)
    {
        cbl.Items.Insert(0, new ListItem(strText, strValue));
    }
    #endregion
    /// <summary>
    /// ���ؼ��󶨵�ʵ�� IList �ӿڵļ���
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
    /// �� �����б�󶨵� IList
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
    /// �� �����б�󶨵� IList���ṩĬ����
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

        AddEmptyItem(drp, "��ѡ�����", "-1");
    }
    #endregion

    /// <summary>
    /// �� �����б�󶨵� IList��ѡ��ָ�� ��
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

        AddEmptyItem(drp, "--��ѡ��--", "-1");
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
    /// ����ͨ���ı�ת��ΪHTML�������
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
    /// �ж� paramarr �����Ƿ����null
    /// </summary>
    /// <param name="paramarr">�����Ŀɱ䳤�ȵ�����</param>
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
    /// �ж� paramarrΪ ��ѯ�ַ������Ƶ��������Ƿ����null
    /// </summary>
    /// <param name="paramarr">��ѯ�ַ������Ƶ�����</param>
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
    /// ��CheckBoxList�󶨵�IList
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
    /// ȫ��ת���ɰ��
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    #region ȫ��ת���ɰ��
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

    public static string DelHTML(string Htmlstring)//��HTMLȥ��
    {
        #region
        //ɾ���ű�

        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

        //ɾ��HTML

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
