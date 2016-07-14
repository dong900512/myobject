<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WYNoticeAdd.aspx.cs" Inherits="NewInfoWeb.manage.Manager_Wy.WYNoticeAdd"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>公告信息</title>
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
            window.editor = K.create('#txtcontent,#txtsummary', { uploadJson: '/manage/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '/manage/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: true, afterBlur: function () { this.sync(); }
            });
        });
        function checkedJS() {
            var wGroups = $("#drptype").val();
            var title = $.trim($("#txttitle").val());
            var content = $.trim($("#txtcontent").val());
            var torders = $.trim($("#txtOrders").val());
            var reg_num = /^[-+]?\d+$/;

            if (title == "" || title == null) {
                alert("标题不能为空！")
                $("#txttitle").focus();
                return false;
            }
            if (content == "" || content == null) {
                alert("请填写内容信息");
                $("#txtcontent").focus();
                return false;
            }
            if (torders == "" || torders == null) {
                alert("请填写排序号信息");
                $("#txtOrders").focus();
                return false;
            }
            if (!reg_num.test(torders)) {
                alert("排序号请填写数字！");
                $("#txtOrders").focus();
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
            <span>公告信息操作</span></div>
        <div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">添加时间：&nbsp;<font style="color: red"> </font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txtStart" ReadOnly onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                                runat="server" CssClass="input_txt"></asp:TextBox>
                            <input type="hidden" id="txt_change" value="" runat="server" />
                        </div>
                    </li>
                    <li class="hint_txt">(不选择则默认为当前时间)</li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">公告标题：&nbsp;<font style="color: red">*</font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txttitle" runat="server" CssClass="input_txt"></asp:TextBox></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor" style="height: 650px;">
                <ul>
                    <li class="infor_txt">公告内容：&nbsp;<font style="color: red">*</font></li>
                    <li>
                        <div class="infot_input" style="width: 700px; height: 670px;">
                            <textarea id="txtcontent" runat="server" cols="50" rows="5" style="width: 680px;
                                height: 670px;"></textarea></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">排序号：&nbsp;<font style="color: red"></font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txtOrders" runat="server" CssClass="input_txt" Text="0"></asp:TextBox>
                        </div>
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
