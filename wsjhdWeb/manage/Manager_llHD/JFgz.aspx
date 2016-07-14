<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JFgz.aspx.cs" Inherits="NewInfoWeb.manage.Manager_llHD.JFgz"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册协议</title>
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
            window.editor = K.create('#txtcontent', { uploadJson: '/manage/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '/manage/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: true, afterBlur: function () { this.sync(); }
            });

        });
        function checkedJS() {

            var content = $.trim($("#txtcontent").val());


            if (content == "" || content == null) {
                alert("请填写内容信息");
                $("#txtcontent").focus();
                return false;
            }
            return true;
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
            <span>积分规则</span></div>
        <div>
            <div class="add_infor" style="height: 450px;">
                <ul>
                    <li class="infor_txt">规则详情：&nbsp;<font style="color: red">*</font></li>
                    <li>
                        <div class="infot_input" style="width: 700px; height: 470px;">
                            <textarea id="txtcontent" runat="server" cols="50" rows="5" style="width: 680px;
                                height: 470px;"></textarea></div>
                    </li>
                </ul>
            </div>
            <div style="clear: both; margin-top: 50px;">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <div class="affirmimg">
                    <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    <asp:ImageButton ImageUrl="../images/affirmimg.png" ID="btn_click" runat="server"
                        Width="94" OnClientClick="return checkedJS();" OnClick="btn_click_Click" />
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
