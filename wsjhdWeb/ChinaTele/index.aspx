<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NewInfoWeb.ChinaTele.index" %>

<!DOCTYPE html>
<html lang="zh-cn">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1">
    <title>中国电信国际业务推介会</title>
    <link href="/zui/css/zui.min.css" rel="stylesheet" />
    <!-- <link href="css/swiper.min.css" rel="stylesheet" type="text/css" />-->
    <!--[if lt IE 9]>
      <script src="/zui/lib/ieonly/html5shiv.js"></script>
      <script src="/zui/lib/ieonly/respond.js"></script>
      <script src="/zui/lib/ieonly/excanvas.js"></script>
    <![endif]-->
    <style>
        body { display: block !important; background-color: black; max-width: 640px; margin: 0 auto; }
        ::-webkit-scrollbar { width: 0px; height: 0px; }
        .btnqd { width: 50%; margin-left: 25%; margin-top: -21%; }
        .s2, .s3 { position: relative; display: none; top: 0; left: 0; }
        .btnfh { margin-top: -12%; width: 50%; margin-left: 25%; }
        .tips1 { position: absolute; width: 100%; text-align: center; top: 49%; color: white; font-size: 1.6rem; font-family: 微软雅黑; }
        .txtyzm { position: absolute; width: 70%; left: 15%; text-align: center; border-radius: 5px; border: 0; top: 60%; height: 40px; line-height: 40px; font-size: 3rem; }
        .btnqr1 { position: absolute; border: none; width: 30%; background-color: #e95513; color: white; height: 45px; top: 80%; font-size: 2.2rem; border-radius: 8px; left: 18%; }
        .btnfh1 { position: absolute; border: none; background-color: #e95513; width: 30%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; top: 80%; right: 18%; }

        .tinfo { position: absolute; text-align: center; width: 80%; left: 10%; top: 55%; color: white; }
        .tname { font-size: 3rem; }
        .tgs { font-size: 2rem; margin-bottom: 7%; }
        .tips2 { color: #b2b2b2; font-size: 1.6rem; margin-bottom: 3%; }
        .yzm { font-size: 2rem; }
        .tips3 { color: #b2b2b2; font-size: 1.6rem; margin-top: 3%; margin-bottom: 5%; }
        .btnqr2 { position: absolute; border: none; width: 30%; background-color: #e95513; color: white; height: 45px; font-size: 2.2rem; border-radius: 8px; left: 15%; margin-bottom: 10%; }
        .btnfh2 { position: absolute; border: none; background-color: #e95513; width: 30%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; right: 15%; }
    </style>
</head>
<body>
    <div id="grid">
        <div class="s1">
            <img src="img/xq/1.jpg" />
            <img src="img/xq/btnqd.jpg" class="btnqd" />
        </div>
        <div class="s2">
            <img src="img/xq/2.jpg" />
            <div class="tips1">
                请输入您的验证码
            </div>
            <input type="tel" class="txtyzm" />
            <button class="btnqr1">确认</button>
            <button class="btnfh1">返回</button>
        </div>
        <div class="s3">
            <img src="img/xq/3.jpg" />
            <div class="tinfo">
                <div class="tname">王某某</div>
                <div class="tgs">中国工商银行</div>
                <div class="tips2">您输入的验证码</div>
                <div class="yzm">7333</div>
                <div class="tips3">
                    感谢您的到来！<br />
                    请确认您的信息是否正确。
                </div>
                <button class="btnqr2">确认</button>
                <button class="btnfh2">重填</button>
            </div>
        </div>
    </div>
</body>
<script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
<script src="http://ossweb-img.qq.com/images/js/motion/dialog.min.js"></script>
<script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
<script src="/js/share.js" type="text/javascript"></script>
<script type="text/javascript">
    dataForWeixin.img = "http://wsjhb.tencenthouse.com/chinatele/img/fxs.jpg";
    dataForWeixin.desc = "中国电信国际业务推介会";
    dataForWeixin.title = "中国电信国际业务推介会";
    dataForWeixin.isWXShare = false;
    //document.body.addEventListener('touchmove', function (evt) {
    //    //In this case, the default behavior is scrolling the body, which
    //    //would result in an overflow.  Since we don't want that, we preventDefault.
    //    if (!evt._isScroller) {
    //        evt.preventDefault()
    //    }
    //});
    $(function () {
        //$(".s1").fadeOut();
        //$(".s3").fadeIn();
        $(".btnqd").on("touchstart", function () {
            gotoTop();
            $(".s1").fadeOut("slow", function () {
                $(".s2").fadeIn();
            });

        });
        $(".btnfh1").tap(function () {
            gotoTop();
            $(".s2").fadeOut("slow", function () {
                $(".s1").fadeIn("10");
            });
        });
        $(".btnfh2").on("touchstart", function (e) {
            gotoTop();
            $(".s3").fadeOut("slow", function () {
                $(".s2").fadeIn("10");
            });
        });
        $(".btnqr2").on("touchstart", function () {
            $.ajax({
                url: "helper.ashx",
                type: "post",
                data: { type: "bcArea", tname: $.trim($(".tname").text()), tcode: $.trim($(".yzm").text()) },
                dataType: "json",
                success: function (data) {
                    alert(data.ist);
                    if (data.ist == "1") {
                        window.location.href = "main.aspx";
                    } else {
                        showDialog("请输入正确的验证码信息", "alert");
                    }
                }
            });
        });
        $(".btnqr1").tap(function () {
            var tpyzm = $.trim($(".txtyzm").val());
            if (tpyzm == "" || tpyzm == null) {
                showDialog("请填写验证码信息", "alert");
                return false;
            }
            $.ajax({
                url: "helper.ashx",
                type: "post",
                data: { type: "isexit", tyzm: tpyzm },
                dataType: "json",
                success: function (data) {
                    if (data.ist == "2") {
                        $(".txtyzm").val("");
                        gotoTop();
                        $(".s2").fadeOut("slow", function () {
                            $(".tname").text(data.name);
                            $(".tgs").text(data.gs);
                            $(".yzm").text(tpyzm);
                            $(".s3").fadeIn("10");
                        });
                    } else {
                        showDialog("请输入正确的验证码信息", "alert");
                    }
                }
            });
        });
    })
    function showDialog(msg, type) {
        window.dia1 = new mo.Dialog({
            content: msg,
            type: type
        });
    }
    function gotoTop(speed, time) {
        speed = speed || 0.1;
        time = time || 16;
        // 滚动条到页面顶部的水平距离
        var x = document.body.scrollLeft;
        // 滚动条到页面顶部的垂直距离
        var y = document.body.scrollTop;
        // 滚动距离 = 目前距离 / 速度, 因为距离原来越小, 速度是大于 1 的数, 所以滚动距离会越来越小
        speed++;
        window.scrollTo(Math.floor(x / speed), Math.floor(y / speed));
        // 如果距离不为零, 继续调用迭代本函数
        if (x > 0 || y > 0) {
            window.setTimeout("gotoTop(" + speed + ", " + time + ")", time);
        }
    }
</script>
</html>
