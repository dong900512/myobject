<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewInfoWeb.manage.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>上海微事后台管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/public.css" />
    <script type="text/javascript" src="/js/lib/jquery-1.10.2.min.js"></script>
</head>
<body>
    <div class="itempage versions_all">
        <div class="search_total">
            <div class="tit_user">
                系统信息</div>
            <div class="versions">
                <p class="versions_txt">
                    当前版本:4.0</p>
                <p class="versions_txt">
                    最近升级时间:2015/11/11 17:30:20</p>
                <p class="versions_txt curt">
                </p>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //获得当前时间,刻度为一千分一秒
        window.onload = function () {
            showLeftTime();
        }
        function showLeftTime() {
            var now = new Date();
            var year = now.getFullYear();
            var month = parseInt(now.getMonth() + 1) >= 10 ? parseInt(now.getMonth() + 1) : "0" + parseInt(now.getMonth() + 1);
            var day = parseInt(now.getDate()) >= 10 ? now.getDate() : "0" + now.getDate();
            var hours = parseInt(now.getHours()) >= 10 ? now.getHours() : "0" + now.getHours();
            var minutes = parseInt(now.getMinutes()) >= 10 ? now.getMinutes() : "0" + now.getMinutes();
            var seconds = parseInt(now.getSeconds()) >= 10 ? now.getSeconds() : "0" + now.getSeconds();
            var str = year + "/" + month + "/" + day + "  " + hours + ":" + minutes + ":" + seconds;
            $(".curt").html("当前系统时间:" + str);
            //一秒刷新一次显示时间
            var timeID = setTimeout(showLeftTime, 1000);
        }
    </script>
</body>
</html>
