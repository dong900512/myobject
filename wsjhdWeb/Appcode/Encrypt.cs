using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// <summary>
/// Encrypt 的摘要说明
/// </summary>
public class Encrypt
{
    string _QueryStringKey = "abcdefgh";
    string _PassWordKey = "hgfedcba";

    public Encrypt()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region public static string MD5(string number)
    /// <summary>
    /// MD5加密
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string MD5(string number)
    {
        ASCIIEncoding ASCIIenc = new ASCIIEncoding();
        string strReturn = "";
        byte[] ByteSourceText = ASCIIenc.GetBytes(number);
        MD5CryptoServiceProvider Md5Hash = new MD5CryptoServiceProvider();
        byte[] ByteHash = Md5Hash.ComputeHash(ByteSourceText);
        foreach (byte b in ByteHash)
        {
            strReturn += b.ToString("x2");
        }
        return strReturn;
    }
    #endregion


    /// <summary>
    /// 加密URL传输的字符串
    /// </summary>
    /// <param name="QueryString"></param>
    /// <returns></returns>
    #region public string EncryptQueryString(string QueryString)
    public string EncryptQueryString(string QueryString)
    {
        return EncryptEx(QueryString, _QueryStringKey);
    }
    #endregion


    /// <summary>
    /// 解密URL传输的字符串
    /// </summary>
    /// <param name="QueryString"></param>
    /// <returns></returns>
    #region public string DecryptQueryString(string QueryString)
    public string DecryptQueryString(string QueryString)
    {
        return Decrypt(QueryString, _QueryStringKey);
    }
    #endregion


    /// <summary>
    ///加密帐号口令
    /// </summary>
    /// <param name="PassWord"></param>
    /// <returns></returns>
    #region public string EncryptPassWord(string PassWord)
    public string EncryptPassWord(string PassWord)
    {
        return EncryptEx(PassWord, _PassWordKey);
    }
    #endregion


    /// <summary>
    /// 解密帐号口令 
    /// </summary>
    /// <param name="PassWord"></param>
    /// <returns></returns>
    #region public string DecryptPassWord(string PassWord)
    public string DecryptPassWord(string PassWord)
    {
        return Decrypt(PassWord, _PassWordKey);
    }
    #endregion


    /// <summary>
    /// DEC   加密过程  
    /// </summary>
    /// <param name="pToEncrypt"></param>
    /// <param name="sKey"></param>
    /// <returns></returns>
    #region public string EncryptEx(string pToEncrypt, string sKey)
    public string EncryptEx(string pToEncrypt, string sKey)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();     //把字符串放到byte数组中       

        byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
        //byte[]     inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);       

        des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);     //建立加密对象的密钥和偏移量   
        des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);       //原文使用ASCIIEncoding.ASCII方法的GetBytes方法     
        MemoryStream ms = new MemoryStream();           //使得输入密码必须输入英文文本   
        CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();

        StringBuilder ret = new StringBuilder();
        foreach (byte b in ms.ToArray())
        {
            ret.AppendFormat("{0:X2}", b);
        }
        ret.ToString();
        return ret.ToString();
    }
    #endregion


    /// <summary>
    /// DEC   解密过程   
    /// </summary>
    /// <param name="pToDecrypt"></param>
    /// <param name="sKey"></param>
    /// <returns></returns>
    #region public string Decrypt(string pToDecrypt, string sKey)
    public string Decrypt(string pToDecrypt, string sKey)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
        for (int x = 0; x < pToDecrypt.Length / 2; x++)
        {
            int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
            inputByteArray[x] = (byte)i;
        }

        des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);     //建立加密对象的密钥和偏移量，此值重要，不能修改       
        des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();

        StringBuilder ret = new StringBuilder();     //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象       

        return System.Text.Encoding.Default.GetString(ms.ToArray());
    }
    #endregion


    /// <summary>
    /// 检查己加密的字符串是否与原文相同   
    /// </summary>
    /// <param name="EnString"></param>
    /// <param name="FoString"></param>
    /// <param name="Mode"></param>
    /// <returns></returns>
    #region public bool ValidateString(string EnString, string FoString, int Mode)
    public bool ValidateString(string EnString, string FoString, int Mode)
    {
        switch (Mode)
        {
            default:
            case 1:
                if (Decrypt(EnString, _QueryStringKey) == FoString.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 2:
                if (Decrypt(EnString, _PassWordKey) == FoString.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
    }
    #endregion

}
