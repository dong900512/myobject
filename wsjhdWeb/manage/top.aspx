<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="NewInfoWeb.manage.top" %>

<!DOCTYPE html>
<html>
<head>
    <title>�Ϻ�΢�º�̨����ϵͳ</title>
    <link rel="stylesheet" type="text/css" href="css/public.css" />
    <style>
        .tit_logo { height: auto; }
    </style>
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function logout() {
            if (confirm("��ȷ��Ҫ�˳�ϵͳ��"))
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
            ����ϵͳ
        </div>
        <div class="user_right">
            <div class="userimg">
                <img src="images/userimg.png" width="48" height="46" />
            </div>
            <div class="usertxt">
                <small>��ӭ,</small><%=UserName%>
            </div>
            <div class="exitimg">
                <img src="images/exitimg.png" width="48" height="46" /><a href="#" target="_self"
                    onclick="logout();" style="color: #FFF">�˳�</a>
            </div>
        </div>
    </div>
</body>
</html>
