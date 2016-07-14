<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="NewInfoWeb.manage.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>上海微事后台管理系统</title>
    <link rel="stylesheet" href="css/public.css" type="text/css" />
    <link href="dist/css/zui.min.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 9]>
      <script src="lib/ieonly/html5shiv.js"></script>
      <script src="lib/ieonly/respond.js"></script>
      <script src="lib/ieonly/excanvas.js"></script>
    <![endif]-->
    <script type="text/javascript" src="/js/lib/jquery-1.10.2.min.js"></script>
    <%--   <script type="text/javascript" src="/manage/lib/public.js"></script>--%>
    <script src="dist/js/zui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //alert('<%=str_menu%>');
            //            $('#treeIconsExample').tree('toggle', "");
            //            $('#treeIconsExample').tree({ expand: function () { alert("123"); } });
            //            $('#treeIconsExample').tree('collapse', "");
        })

    </script>
</head>
<body>
    <div>
        <img src="images/topimg.png" width="211" /></div>
    <div class="total">
        <ul class="tree tree-lines tree-chevrons" id="treeIconsExample" data-animate="true"
            data-ride="tree">
            <%=str_menu%>
            <%-- <li class="has-list"><a href="#">水果</a>
                <ul>
                    <li><a href="http://www.baidu.com" target='main'>苹果</a></li>
                    <li class="has-list"><a href="#">热带水果</a>
                        <ul>
                            <li><a href="#">香蕉</a></li>
                            <li><a href="#">芒果</a></li>
                            <li><a href="#">椰子</a></li>
                            <li><a href="#">菠萝</a></li>
                        </ul>
                    </li>
                    <li><a href="#">梨子</a></li>
                    <li><a href="#">草莓</a></li>
                    <li><a href="#">杏</a></li>
                    <li><a href="#">桃子</a></li>
                    <li><a href="#">梅子</a></li>
                </ul>
            </li>
            <li class="has-list"><a href="#">蔬菜</a>
                <ul>
                    <li class="has-list"><a href="#">我的菜</a>
                        <ul>
                            <li><a href="#">青菜</a></li>
                            <li><a href="#">娃娃菜</a></li>
                            <li><a href="#">菠菜</a></li>
                            <li><a href="#">甘蓝</a></li>
                        </ul>
                    </li>
                    <li class="has-list"><a href="#">你的瓜</a>
                        <ul>
                            <li><a href="#">黄瓜</a></li>
                            <li><a href="#">南瓜</a></li>
                            <li><a href="#">丝瓜</a></li>
                            <li><a href="#">苦瓜</a></li>
                            <li><a href="#">木瓜</a></li>
                        </ul>
                    </li>
                    <li><a href="#">白蓝</a></li>
                    <li><a href="#">土豆</a></li>
                    <li><a href="#">茄子</a></li>
                </ul>
            </li>--%>
        </ul>
    </div>
    <div>
        <img src="images/bottomimg.png" width="211" /></div>
</body>
</html>
