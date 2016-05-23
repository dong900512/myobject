using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Text;
using System.Collections;

namespace Infiniti.Website
{
    /// <summary>
    /// TextBox 控件
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:TextBox runat=server></{0}:TextBox>")]
    public class TextBox : System.Web.UI.WebControls.WebControl, IPostBackDataHandler
    {
        protected System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1 = new RequiredFieldValidator();
        protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1 = new RegularExpressionValidator();
        protected System.Web.UI.WebControls.RangeValidator rangevalidator = new System.Web.UI.WebControls.RangeValidator();

        public TextBox()
            : base()
        {
            tb.Attributes.Add("onfocus", "this.className='colorfocus';");
            tb.Attributes.Add("onblur", "this.className='colorblur';");

            tb.CssClass = "colorblur";
        }

        public void AddAttributes(string key, string valuestr)
        {
            tb.Attributes.Add(key, valuestr);
        }


        //在属性RequiredFieldType后进行调用
        public void SetValiateControls()
        {
            this.Controls.Add(tb);

            if ((RequiredFieldType != null) && (RequiredFieldType != "") && (RequiredFieldType != "暂无校验"))
            {
                RegularExpressionValidator1.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
                RegularExpressionValidator1.ControlToValidate = tb.ID;
                RegularExpressionValidator1.ForeColor = System.Drawing.Color.Black;


                switch (RequiredFieldType)
                {
                    case "数据校验":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : "^[-]?\\d+[.]?\\d*$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>数字的格式不正确</font>"; break;
                        }
                    case "电子邮箱":
                        {   //RegularExpressionValidator1.ValidationExpression="^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$";
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : (@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                            RegularExpressionValidator1.ErrorMessage = "<font color='red'> 邮箱的格式不正确</font>"; break;
                        }
                    case "移动手机":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : "\\d{11}";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>手机的位数应为11位!</font>"; break;
                        }
                    case "家用电话":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : @"^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>请依 (XXX)XXX-XXXXXXX 格式或 (XXX)XXXX-XXXXXXX 输入电话号码！</font>"; break;
                        }
                    case "身份证号码":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : "^\\d{15}$|^\\d{18}$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>请依15或18位数据的身份证号！</font>"; break;
                        }
                    case "网页地址":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>请输入正确的网址</font>"; break;
                        }
                    case "日期":
                        {   //RegularExpressionValidator1.ValidationExpression="\\d{4}-\\d{1,2}-\\d{1,2}";
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>请输入正确的日期,如:2006-1-1</font>"; break;
                        }
                    case "日期时间":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>请输入正确的日期,如: 2006-1-1 23:59:59</font>"; break;
                        }
                    case "金额":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : "^([0-9]|[0-9].[0-9]{0-2}|[1-9][0-9]*.[0-9]{0,2})$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>请输入正确的金额</font>"; break;
                        }
                    case "IP地址":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>请输入正确的IP地址</font>"; break;
                        }
                    case "IP地址带端口":
                        {
                            RegularExpressionValidator1.ValidationExpression = (this.ValidationExpression != null) ? this.ValidationExpression : @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9]):\d{1,5}?$";
                            RegularExpressionValidator1.ErrorMessage = " <font color='red'>请输入正确的带端口的IP地址</font>"; break;
                        }
                }
                this.Controls.Add(RegularExpressionValidator1);
            }

            switch (CanBeNull)
            {
                case "可为空": { break; }
                case "必填":
                    {
                        RequiredFieldValidator1.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
                        RequiredFieldValidator1.ControlToValidate = tb.ID;
                        RequiredFieldValidator1.ForeColor = System.Drawing.Color.Black;
                        RequiredFieldValidator1.ErrorMessage = "<font color='red'>请务必输入内容!</font>";
                        this.Controls.Add(RequiredFieldValidator1);
                        break;
                    }
                default: { break; }
            }


            this.BorderStyle = BorderStyle.Dotted;
            this.BorderWidth = 1;

        }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string SetFocusButtonID
        {
            get
            {
                object o = ViewState[this.ClientID + "_SetFocusButtonID"];
                return (o == null) ? "" : o.ToString();
            }
            set
            {
                ViewState[this.ClientID + "_SetFocusButtonID"] = value;
                if (value != "")
                {
                    tb.Attributes.Add("onkeydown", "if(event.keyCode==13){document.getElementById('" + value + "').focus();}");
                }
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public override string ID
        {
            get
            {
                return tb.ID;
            }
            set
            {
                tb.ID = value;
            }
        }


        //调控件的最大长度属性
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public int MaxLength
        {
            get
            {
                object o = ViewState["TextBox_MaxLength"];
                if (o != null)
                {
                    int maxlength = Convert.ToInt32(o.ToString());
                    AddAttributes("maxlength", maxlength.ToString());
                    return maxlength;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                ViewState["TextBox_MaxLength"] = value;
                AddAttributes("maxlength", value.ToString());
            }
        }


        //调控件的TextMode属性
        [Bindable(false), Category("Behavior"), DefaultValue(""), TypeConverter(typeof(TextModeFieldTypeControlsConverter)), Description("要滚动的对象。")]
        public string TextMode  //要进行校验的表达式
        {
            get
            {
                return tb.TextMode.ToString();
            }
            set
            {
                if (value == "Password") tb.TextMode = TextBoxMode.Password;
                if (value == "MultiLine")
                {
                    tb.TextMode = TextBoxMode.MultiLine;
                    tb.Attributes.Add("onkeyup", "return isMaxLen(this)");
                }
                if (value == "SingleLine") tb.TextMode = TextBoxMode.SingleLine;
            }
        }

        [Bindable(false), Category("Behavior"), DefaultValue(""), TypeConverter(typeof(RequiredFieldTypeControlsConverter)), Description("要滚动的对象。")]
        public string RequiredFieldType  //要进行校验的表达式
        {
            get
            {
                object o = ViewState["RequiredFieldType"];
                return (o == null) ? "" : o.ToString();
            }
            set
            {
                ViewState["RequiredFieldType"] = value;
                SetValiateControls();
            }
        }


        //是否为空
        [Bindable(false), Category("Behavior"), DefaultValue("可为空"), TypeConverter(typeof(CanBeNullControlsConverter)), Description("要滚动的对象。")]
        public string CanBeNull  //要表达式是否可以为空
        {
            get
            {
                object o = ViewState["CanBeNull"];
                return (o == null) ? "" : o.ToString();
            }
            set
            {
                ViewState["CanBeNull"] = value;
                SetValiateControls();
            }
        }


        //是否进行 ' 号替换
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public bool IsReplaceInvertedComma
        {
            get
            {
                object o = ViewState["IsReplaceInvertedComma"];
                if (o == null || o.ToString().Trim() == "")
                {
                    return true;
                }
                else
                {
                    return o.ToString().ToLower() == "true" ? true : false;
                }
            }
            set
            {
                ViewState["IsReplaceInvertedComma"] = value;
            }
        }


        //不是默认的正则表达式
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string ValidationExpression
        {
            get
            {
                object o = ViewState["ValidationExpression"];
                if (o == null || o.ToString().Trim() == "")
                {
                    return null;
                }
                else
                {
                    return o.ToString().ToLower();
                }
            }
            set
            {
                ViewState["ValidationExpression"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Text
        {
            get
            {

                if (this.RequiredFieldType == "日期")
                {
                    try
                    {
                        return DateTime.Parse(tb.Text).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        return "1900-1-1";
                    }
                }

                if (this.RequiredFieldType == "日期时间")
                {
                    try
                    {
                        return DateTime.Parse(tb.Text).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    catch
                    {
                        return "1900-1-1 00:00:00";
                    }
                }
                else
                {
                    return IsReplaceInvertedComma ? tb.Text.Replace("'", "''").Trim() : tb.Text;
                }
            }
            set
            {
                if (this.RequiredFieldType.IndexOf("日期") >= 0)
                {
                    try
                    {
                        tb.Text = DateTime.Parse(value).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        tb.Text = "";
                    }
                }

                if (this.RequiredFieldType.IndexOf("日期时间") >= 0)
                {
                    try
                    {
                        tb.Text = DateTime.Parse(value).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    catch
                    {
                        tb.Text = "";
                    }
                }
                else
                {
                    tb.Text = value;
                }
            }

        }

        //调控件的高度属性
        [Bindable(false), Category("Appearance"), DefaultValue("")]
        override public Unit Height
        {
            get
            {
                return tb.Height;
            }
            set
            {
                tb.Height = value;
            }
        }

        //调控件的宽度属性
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        override public Unit Width
        {
            get
            {
                return tb.Width;
            }
            set
            {
                tb.Width = value;
            }
        }

        private int _rows = 5;
        //调控件的宽度属性
        [Bindable(true), Category("Appearance"), DefaultValue(1)]
        public int Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }

        private int _cols = 45;
        //调控件的宽度属性
        [Bindable(true), Category("Appearance"), DefaultValue(30)]
        public int Cols
        {
            get
            {
                return _cols;
            }
            set
            {
                _cols = value;
            }
        }


        private int _size = 45;
        //调控件的宽度属性
        [Bindable(true), Category("Appearance"), DefaultValue(30)]
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }


        //调控件的宽度属性
        [Bindable(true), Category("Appearance"), DefaultValue(true)]
        public override bool Enabled
        {
            get
            {
                return tb.Enabled;
            }
            set
            {
                tb.Enabled = value;
            }
        }


        private string _maximumValue = null;

        [Bindable(true), Category("Appearance"), DefaultValue(null)]
        public string MaximumValue
        {
            get
            {
                return _maximumValue;
            }
            set
            {
                _maximumValue = value;
            }
        }

        private string _minimumValue = null;
        [Bindable(true), Category("Appearance"), DefaultValue(null)]
        public string MinimumValue
        {
            get
            {
                return _minimumValue;
            }
            set
            {
                _minimumValue = value;
            }
        }

        /// <summary> 
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            //output.Write(Text);
            if (this.TextMode == "MultiLine")
            {
                output.WriteLine("<script type=\"text/javascript\">");
                output.WriteLine("function isMaxLen(o){");
                output.WriteLine("var nMaxLen=o.getAttribute? parseInt(o.getAttribute(\"maxlength\")):\"\";");
                output.WriteLine(" if(o.getAttribute && o.value.length>nMaxLen){");
                output.WriteLine(" o.value=o.value.substring(0,nMaxLen)");
                output.WriteLine("}}</script>");

                this.AddAttributes("rows", Rows.ToString());
                this.AddAttributes("cols", Cols.ToString());
            }
            else
            {
                if (this.Width.Value.ToString() != "")
                {
                    if (Width.Type.ToString() != "")
                    {
                        this.AddAttributes("SIZE", (Width.Value / 10).ToString() + (Width.Type.ToString() == "Pixel" ? "px" : "%"));
                    }

                    else
                    {
                        this.AddAttributes("SIZE", (Width.Value / 10).ToString() + "px");
                    }
                }

                if (this.Size.ToString() != "")
                {
                    this.AddAttributes("SIZE", this.Size.ToString());
                }
            }

            //当指定了输入框的最小或最大值时,则加入校验范围项
            if (this.MaximumValue != null || this.MinimumValue != null)
            {
                rangevalidator.ControlToValidate = tb.ID;
                rangevalidator.Type = ValidationDataType.Double;
                rangevalidator.ForeColor = System.Drawing.Color.Black;

                if (this.MaximumValue != null && this.MinimumValue != null)
                {
                    rangevalidator.MaximumValue = this.MaximumValue;
                    rangevalidator.MinimumValue = this.MinimumValue;
                    rangevalidator.ErrorMessage = " 当前输入数据应在" + this.MinimumValue + "和" + this.MaximumValue + "之间!";
                }
                else
                {
                    if (this.MaximumValue != null)
                    {
                        rangevalidator.MaximumValue = this.MaximumValue;
                        rangevalidator.ErrorMessage = " 当前输入数据允许最大值为" + this.MaximumValue;
                    }
                    if (this.MinimumValue != null)
                    {
                        rangevalidator.MinimumValue = this.MinimumValue;
                        rangevalidator.ErrorMessage = " 当前输入数据允许最小值为" + this.MinimumValue;
                    }
                }
                rangevalidator.Display = ValidatorDisplay.Static;
                this.Controls.Add(rangevalidator);
            }


            RenderChildren(output);
        }


        #region IPostBackDataHandler 成员



        public void RaisePostDataChangedEvent()
        { }


        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string presentValue = this.tb.Text;
            string postedValue = postCollection[postDataKey];

            if (!presentValue.Equals(postedValue))//如果回发数据不等于原有数据
            {
                this.Text = postedValue;
                this.tb.Text = postedValue;
                return true;
            }
            return false;

        }
        #endregion

    }

    public class RequiredFieldTypeControlsConverter : StringConverter
    {
        public RequiredFieldTypeControlsConverter() { }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ArrayList controlsArray = new ArrayList();
            controlsArray.Add("暂无校验");
            controlsArray.Add("数据校验");
            controlsArray.Add("电子邮箱");
            controlsArray.Add("移动手机");
            controlsArray.Add("家用电话");
            controlsArray.Add("身份证号码");
            controlsArray.Add("网页地址");
            controlsArray.Add("日期");
            controlsArray.Add("日期时间");
            controlsArray.Add("金额");
            controlsArray.Add("IP地址");
            controlsArray.Add("IP地址带端口");
            return new StandardValuesCollection(controlsArray);

        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }


    public class CanBeNullControlsConverter : StringConverter
    {
        public CanBeNullControlsConverter() { }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ArrayList controlsArray = new ArrayList();
            controlsArray.Add("可为空");
            controlsArray.Add("必填");

            return new StandardValuesCollection(controlsArray);

        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }


    public class FormControlsConverter : StringConverter
    {
        public FormControlsConverter()
        {
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ControlCollection Controls = ((Page)context.Container.Components[0]).Controls;
            ArrayList controlsArray = new ArrayList();
            for (int i = 0; i < Controls.Count; i++)
            {
                if ((Controls[i] is HtmlTable
                    || Controls[i] is HtmlForm
                    || Controls[i] is HtmlGenericControl
                    || Controls[i] is HtmlImage
                    || Controls[i] is Label
                    || Controls[i] is DataGrid
                    || Controls[i] is DataList
                    || Controls[i] is Table
                    || Controls[i] is Repeater
                    || Controls[i] is Image
                    || Controls[i] is Panel
                    || Controls[i] is PlaceHolder
                    || Controls[i] is Calendar
                    || Controls[i] is AdRotator
                    || Controls[i] is Xml
                    ))
                {
                    controlsArray.Add(Controls[i].ClientID);
                }
            }
            return new StandardValuesCollection(controlsArray);

        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }


    public class TextModeFieldTypeControlsConverter : StringConverter
    {
        public TextModeFieldTypeControlsConverter()
        {
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ArrayList controlsArray = new ArrayList();
            controlsArray.Add("Password");
            controlsArray.Add("SingleLine");
            controlsArray.Add("MultiLine");

            return new StandardValuesCollection(controlsArray);

        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }
}

