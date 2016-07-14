<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="NewInfoWeb.manage.top" %>

<!DOCTYPE html>
<html>
<head>
    <title>上海微事后台管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/public.css" />
    <style>
        .tit_logo { height: auto; }
    </style>
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function logout() {
            if (confirm("您确定要退出系统吗？"))
                top.location = "LoginOut.aspx";
            return false;
        }
    </script>
</head>
<body>
    <div class="topsystem">
        <div class="systemimg">
            <span>
                <img src="images/welcomeimg.png" class="welcomeimg" /></span> <span>
                    <img src="images/txfc_logo.png" class="tit_logo" /></span>
        </div>
        <div class="backstage">
            管理系统
        </div>
        <div class="user_right">
            <div class="userimg">
                <img src="images/userimg.png" width="48" height="46" />
            </div>
            <div class="usertxt">
                <small>欢迎,</small><%=UserName%>
            </div>
            <div class="exitimg">
                <img src="images/exitimg.png" width="48" height="46" /><a href="#" target="_self"
                    onclick="logout();" style="color: #FFF">退出</a>
            </div>
        </div>
    </div>
</body>
</html>
