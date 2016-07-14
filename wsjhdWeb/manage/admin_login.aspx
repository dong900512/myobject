<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_login.aspx.cs" Inherits="NewInfoWeb.manage.admin_login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>上海微事后台管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/public.css" />
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="lib/DataValid.js"></script>
    <script type="text/javascript" src="lib/VerificationCode.js"></script>
    <style type="text/css">
        .code { font-family: Arial; font-style: italic; color: Black; border: 0; padding: 2px 3px; letter-spacing: 3px; font-weight: bolder; width: 45px; background-color: rgba(0,0,0,0); height: 44px; width: 64px; cursor: pointer; text-align: center; }
        .unchanged { border: 0; }
    </style>
    <script language="javascript" type="text/javascript">
        if (top.location !== self.location) {
            top.location = self.location;
        }
        $(document).ready(function (e) {
            createCode('checkCode'); //加载验证码
            $('.btnlogin').bind('click', function () {
                if ($('#UserName').val() == "") {
                    alert("请输入用户名！");
                    $("#UserName").focus();
                    return false;
                }
                if ($('#Password').val() == "") {
                    alert("请输入密码！");
                    $("#Password").focus();
                    return false;
                }
                //文本框验证
                if (DataValidate()) {
                    var paras = { RqtAction: "login", LoginName: $('#UserName').val(), LoginPassword: $('#Password').val() };
                    $.post("/manage/ashx/Sys_Login.ashx", paras, function (data) {
                        if (data == "Error") {
                            createCode('checkCode'); //加载验证码
                            alert("用户名或密码错误，请重新输入！");
                        }
                        if (data == "success") {
                            window.location.href = "frame.aspx";
                        }
                    }, "text");
                } else {
                    //                    createCode('checkCode'); //加载验证码
                    alert("验证码错误！");
                    $("#ValidateCode").val("");
                    $("#ValidateCode").focus();
                    return false;
                }
            });
            $('.btnreset').bind('click', function () {
                $("#UserName").val("");
                $("#Password").val("");
                $("#ValidateCode").val("");
            });
        });
    </script>
</head>
<body>
    <!-----------------------头部 start--------------------------------------->
    <div class="composing_top">
        <div class="logoimg">
            <img src="images/txfc_logo.png" class="imgwidth" />
        </div>
        <div class="systemtxt">
            <dd class="fontsize1">上海微事</dd>
            <dt class="englishtxt">WESION</dt>
        </div>
    </div>
    <div class="content">
        <div class="import">
            <dd>
                <div class="nameimg">
                    <img src="images/nameimg.png" class="input_nameimg" />
                </div>
            </dd>
            <dt>
                <input value="" name="UserName" id="UserName" class="inputtxt" datavalid="Valid"
                    datatype="Text" errortype="ctl01" maxlength="20" errorinfo="*" type="text" placeholder="请输入您的用户名"></dt>
        </div>
        <div class="import">
            <dd>
                <div class="nameimg">
                    <img src="images/passwordimg.png" class="input_nameimg" />
                </div>
            </dd>
            <dt>
                <input name="Password" id="Password" class="inputtxt" type="password" datavalid="Valid"
                    datatype="Text" errortype="ctl02" errorinfo="*" placeholder="请输入您的密码">
            </dt>
        </div>
        <div class="verify">
            <dd>
                <input name="ValidateCode" id="ValidateCode" datavalid="Valid" datatype="Code" class="verifytxt"
                    type="text" errortype="ctl03" errorinfo="*">
            </dd>
            <dt>
                <div class="verify_yz">
                    <input type="text" onclick="createCode(this.id)" readonly="readonly" id="checkCode"
                        class="unchanged" />
                </div>
                <div class="another">
                    换一张
                </div>
                <div class="btnrefresh" onclick="createCode('checkCode')">
                    <img src="images/refreshimg.png" width="25" height="21" />
                </div>
            </dt>
        </div>
        <div class="buttonimg">
            <div class="btnlogin">
                登 录
            </div>
            <div class="btnreset">
                重 置
            </div>
        </div>
    </div>
    <div class="signtxt">
        Copyright © 2016-2018
    </div>
</body>
</html>
