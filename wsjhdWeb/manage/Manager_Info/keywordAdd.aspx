<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="keywordAdd.aspx.cs" Inherits="NewInfoWeb.manage.Manager_Info.keywordAdd"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>关注回复管理</title>
    <link href="/manage/css/public.css" rel="stylesheet" type="text/css" />
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/manage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script charset="utf-8" src="/manage/kindeditor-4.1.10/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="/manage/kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
    <style>
        select { padding-left: 10px; }
        textarea { border-radius: 5px; border: 1px solid #CCC6C6; resize: none; padding-left: 5px; line-height: 22px; }
        .c12 { padding-left: 13px; }
        .c12 input { vertical-align: baseline; }
        #upfile { padding-top: 12px; padding-left: 15px; }
        #hyp { float: left; }
        .add_user1 { border: 0px; color: White; display: inline-block; margin-right: 150px; background-color: #297fb8; height: 45px; border-radius: 10px; line-height: 45px; padding: 0 10px 0 10px; }
    </style>
    <script>
        function confirmsuffix(ele) {
            if (ele.value == "") return true;
            var filename = ele.value;
            var exName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();
            if (exName == "JPG" || exName == "GIF" || exName == "PNG" || exName == "BMP")
                return true;
            else {
                alert("上传文件格式只能是:jpg,gif,png,bmp");
                ele.select();
                document.execCommand("delete");
                ele.form.submit();
                return false;
            }
        }
        KindEditor.ready(function (K) {
            window.editor = K.create('#txtsummary', { items: ["source", "link", "unlink"], resizeType: 0, uploadJson: '/manage/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '/manage/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: true, afterBlur: function () { this.sync(); }
            })
        });
        function checkedJS() {
            //            alert(KindEditor.html('#txtsummary'));
            KindEditor.sync('#txtsummary');
            var summsr = $.trim($("#txtsummary").val());
            var title = $.trim($("#txttitle").val());
            var tplink = $.trim($("#txtlink").val());
            var gjc = $.trim($("#txtgjc").val());
            var reg_num = /^[-+]?\d+$/;
            if ((summsr == "" || summsr == null) && (title == "" || title == null)) {
                alert("请输入回复内容/图文回复信息")
                return false;
            }
            if (gjc == "" || gjc == null) {
                alert("请输入关键词信息");
                $("#txtgjc").focus();
                return false;
            }
            if (title != null && title != "") {
                if (tplink == "" || tplink == null) {
                    alert("请填写图文链接地址");
                    $("#txtlink").focus();
                    return false;
                } else {
                    if (IsURL(tplink)) {
                    } else {
                        alert("请填写正确的链接地址");
                        $("#txtlink").focus();
                        return false;
                    }
                }
            }
            return true;

        }
        //网址验证
        function IsURL(str_url) {
            var strRegex = '^((https|http|ftp|rtsp|mms)?://)'
+ '?(([0-9a-z_!~*\'().&=+$%-]+: )?[0-9a-z_!~*\'().&=+$%-]+@)?' //ftp的user@ 
+ '(([0-9]{1,3}.){3}[0-9]{1,3}' // IP形式的URL- 199.194.52.184 
+ '|' // 允许IP和DOMAIN（域名） 
+ '([0-9a-z_!~*\'()-]+.)*' // 域名- www. 
+ '([0-9a-z][0-9a-z-]{0,61})?[0-9a-z].' // 二级域名 
+ '[a-z]{2,6})' // first level domain- .com or .museum 
+ '(:[0-9]{1,4})?' // 端口- :80 
+ '((/?)|' // a slash isn't required if there is no file name 
+ '(/[0-9a-z_!~*\'().;?:@&=+$,%#-]+)+/?)$';
            var re = new RegExp(strRegex);
            //re.test() 
            if (re.test(str_url)) {
                return true;
            } else {
                return false;
            }
        }
        //数字验证
        function clearNoNum(obj) {
            obj.value = obj.value.replace(/[^\d]/g, "");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="add_border">
        <div class="add_txt">
            <span>关注回复管理</span></div>
        <div>
            <%--  <div class="itme_input">
                <a class="add_user1" href="javascript:void('0');" style="cursor: pointer">常规回复</a>
                <a class="add_user1" href="javascript:void('0');" style="cursor: pointer">图文回复</a>
                <br class="clear_both" />
            </div>--%>
            <div class="itme_input">
                <font style="color: red">若填写标题信息，则需要上传封面图片以及填写图文链接<br />若回复内容和标题同时存在则选择图文回复</font>
            </div>
            <div class="add_infor" style="padding-top: 16px; height: 100px;">
                <ul>
                    <li class="infor_txt">回复内容：&nbsp;<font style="color: red"></font></li>
                    <li>
                        <div class="infot_input" style="width: 700px; height: 100px;">
                            <textarea id="txtsummary" runat="server" cols="50" rows="5" style="width: 680px;
                                height: 100px;"></textarea></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor" style="padding-top: 28px;">
                <ul>
                    <li class="infor_txt">回复关键词：&nbsp;<font style="color: red"></font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txtgjc" runat="server" CssClass="input_txt"></asp:TextBox></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor" style="padding-top: 28px;">
                <ul>
                    <li class="infor_txt">回复标题：&nbsp;<font style="color: red"></font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txttitle" runat="server" CssClass="input_txt"></asp:TextBox></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor" id="slt" runat="server" visible="false" style="padding-bottom: 130px;">
                <ul>
                    <li class="infor_txt">缩略图：&nbsp;<font style="color: red"></font></li>
                    <li>
                        <img src="<%=curimg %>" style="width: 30%;" />
                    </li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">封面图片：&nbsp;<font style="color: red"> &nbsp;</font></li>
                    <li>
                        <div class="infot_input">
                            <input id="upfile" runat="server" onchange="return confirmsuffix(this)" type="file" /><font
                                color="red"><asp:HyperLink runat="server" ID="hyp" Visible=false  Target="_blank"/>(900*500)
                    </font></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">回复描述：&nbsp;<font style="color: red"></font></li>
                    <li>
                        <div class="infot_input">
                            <textarea id="txtms" runat="server" cols="50" rows="5" style="width: 680px; height: 100px;"></textarea></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor" style="padding-top: 50px;">
                <ul>
                    <li class="infor_txt">图文链接Url：&nbsp;<font style="color: red"></font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txtlink" runat="server" CssClass="input_txt"></asp:TextBox></div>
                    </li>
                </ul>
            </div>
            <div style="clear: both;">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <div class="affirmimg">
                    <asp:ImageButton ImageUrl="../images/affirmimg.png" ID="btn_click" runat="server"
                        Width="94" OnClientClick="return checkedJS();" OnClick="btn_click_Click" />
                </div>
                <div class="get_back">
                    <asp:ImageButton ID="btn_Back" ImageUrl="../images/get_back.png" runat="server" Width="94" />
                </div>
            </div>
            <br style="clear: both;" />
            <div style="height: 40px;">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
