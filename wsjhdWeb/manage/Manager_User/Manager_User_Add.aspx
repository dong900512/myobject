<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_User_Add.aspx.cs"
    Inherits="NewInfoWeb.manage.Manager_User.Manager_User_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户管理</title>
    <link href="/manage/css/public.css" rel="stylesheet" type="text/css" />
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <style>
        select { padding-left: 10px; }
    </style>
    <script>
        function checkedJS() {
            var wGroups = $("#drpGroups").val();
            var wUserName = $("#txt_UserName").val().replace(/[ ]/g, "");
            var wPassword = $("#txt_Password").val().replace(/[ ]/g, "");
            var wTwoPassword = $("#txt_TwoPassword").val().replace(/[ ]/g, "");

            if (wGroups == "-1") {
                alert("没有赋予角色权限！");
                $("#drpGroups").focus();
                return false;
            }
            if (wUserName == "") {
                alert("用户名不能为空！")
                $("#txt_UserName").focus();
                return false;
            }
            if (wPassword == "" && wPassword == "******") {
                alert("密码不能为空！")
                $("#txt_Password").focus();
                return false;
            }
            if (wPassword.length < 6) {
                alert("密码不能小于6位！")
                $("#txt_Password").focus();
                return false;
            }
            if ((wPassword != wTwoPassword) && wPassword == "******") {
                alert("前后密码不一致，请确认！");
                $("#txt_TwoPassword").focus();
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
            <span>添加用户</span></div>
        <div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">角色权限&nbsp;<font style="color: red">*</font></li>
                    <li>
                        <asp:DropDownList CssClass="select_one" ID="drpGroups" runat="server" Width="290">
                        </asp:DropDownList>
                    </li>
                    <li class="hint_txt">(用于登录系统,赋予权限)</li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">用户名&nbsp;<font style="color: red">*</font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txt_UserName" runat="server" CssClass="input_txt"></asp:TextBox>
                            <input type="hidden" id="txt_change" value="" runat="server" />
                        </div>
                    </li>
                    <li class="hint_txt">(账号用于登录系统,由字母,数字组成)</li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">密码&nbsp;<font style="color: red">*</font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txt_Password" runat="server" CssClass="input_txt" TextMode="Password"></asp:TextBox></div>
                    </li>
                    <li class="hint_txt">(密码用于登录系统,由字母,数字组成)</li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">确认密码&nbsp;<font style="color: red">*</font></li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txt_TwoPassword" runat="server" CssClass="input_txt" TextMode="Password"></asp:TextBox></div>
                    </li>
                    <li class="hint_txt"></li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">电子邮箱</li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txt_Email" runat="server" CssClass="input_txt" TextMode="Email"></asp:TextBox></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">手机号码</li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txt_Mobile" runat="server" CssClass="input_txt" onkeyup="clearNoNum(this)"
                                MaxLength="11" TextMode="Phone"></asp:TextBox></div>
                    </li>
                </ul>
            </div>
            <div class="add_infor">
                <ul>
                    <li class="infor_txt">真实姓名</li>
                    <li>
                        <div class="infot_input">
                            <asp:TextBox ID="txt_RealName" runat="server" CssClass="input_txt"></asp:TextBox></div>
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
