<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xydzinfo.aspx.cs" Inherits="NewInfoWeb.lnInfo.xydzinfo" %>

<!DOCTYPE >
<html>
<head>
    <meta charset="UTF-8">
    <title>象屿●上海年华</title>
    <meta name="description" content="上海年华" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="renderer" content="webkit">
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <style>
        @-webkit-keyframes run1 {
            0% { background: url(img/xy/b1.png); background-size: 100% 100%; }
            16% { background: url(img/xy/b2.png); background-size: 100% 100%; }
            33% { background: url(img/xy/b3.png); background-size: 100% 100%; }
            49% { background: url(img/xy/b4.png); background-size: 100% 100%; }
            64% { background: url(img/xy/b5.png); background-size: 100% 100%; }
            80% { background: url(img/xy/b6.png); background-size: 100% 100%; }
            100% { background: url(img/xy/b7.png); background-size: 100% 100%; }
        }

        @font-face { font-family: "ces"; src: "css/tt0037m_.ttf"; }

        @-webkit-keyframes ss1 {
            0% { opacity: .4; }
            100% { opacity: 1; }
        }

        @-webkit-keyframes fd1 {
            0% { -webkit-transform: translate3d(0,-10%,0); opacity: 0; }
            100% { -webkit-transform: translate3d(0,0,0); opacity: 1; }
        }

        .u-globalAudio.z-play .icon-music { -webkit-animation: reverseRotataZ 1.2s linear infinite; }
        .m-bg-zoom { -webkit-animation: BgZoom 10s linear infinite; animation: BgZoom 10s linear infinite; -o-animation: BgZoom 10s linear infinite; }
        .u-globalAudio { left: 86%; }
        .app-header { position: fixed; top: 0; z-index: 100; }
        .u-globalAudio .icon-music { width: 30px; height: 30px; background: url(img/xy/util.png); display: block; background-size: 100% 100%; }
        .u-globalAudio.z-play .icon-music { -webkit-animation: reverseRotataZ 1.2s linear infinite; }
        .u-globalAudio { color: #fff; text-decoration: none; font-size: 24px; position: fixed; top: 2%; display: block; z-index: 9999; }
        body { margin: 0; padding: 0; width: 100%; height: 100%; }
        .load { position: relative; width: 100%; height: 100%; background: url(img/xy/bg1.jpg); background-size: 100% 100%; }

        .loading { position: absolute; width: 100%; height: 100%; -webkit-animation: run1 ease-in infinite 4s; }
        .s1 { display: none; top: 0; left: 0; position: relative; background: url(img/xy/4.jpg); background-size: 100% 100%; overflow: hidden; }
            .s1 img, .s2 img { position: absolute; width: 100%; height: 100%; }
        .s1_1 { position: absolute; width: 100%; text-align: center; font-family: 'Microsoft YaHei'; font-size: 18px; color: #b78e5a; top: 3%; }
        .stname { color: white; }
        .s1_3 { width: 60% !important; height: auto !important; left: 20%; bottom: 3%; }
        .s1_2 { width: 60% !important; height: auto !important; left: 20%; bottom: 13%; }
        .biggz, .bigfx, .bigjx { position: absolute; top: 0; left: 0; z-index: 200; display: none; }
        .bg { position: absolute; z-index: 600; top: 0; left: 0; display: none; }
        .btnjx { position: absolute; width: 40%; bottom: 2%; left: 20%; }
        .btnfh { position: absolute; width: 20%; bottom: 2%; right: 20%; }
        .btnfh1 { position: absolute; width: 20%; bottom: 1%; right: 40%; }
        .addinfo { position: absolute; top: 0; left: 0; z-index: 200; display: none; background: url(img/xy/2.jpg); background-size: 100% 100%; }
        .divph { position: absolute; top: 0; left: 0; z-index: 300; background: url(img/xy/phbj.jpg); background-size: 100% 100%; display: none; }
        .itmlist { width: 90%; position: absolute; z-index: 10%; left: 5%; height: 54%; font: 12px/1.5 tahoma, '\5b8b\4f53',sans-serif; overflow-y: auto; -webkit-overflow-scrolling: touch; bottom: 14%; }
            .itmlist dd { width: 100%; -webkit-margin-start: 0px; overflow: hidden; }
                .itmlist dd span:nth-child(1) { float: left; text-align: center; width: 17.3%; color: white; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-family: 'Microsoft YaHei'; margin-top: 10%; }
                .itmlist dd span:nth-child(2) { float: left; text-align: center; width: 28.3%; color: white; font-family: 'Microsoft YaHei'; margin-bottom: 2%; margin-top: 2%; }
                    .itmlist dd span:nth-child(2) img { width: 90%; border-radius: 90%; }
                .itmlist dd span:nth-child(3) { float: left; text-align: center; width: 29.3%; color: white; overflow: hidden; font-family: 'Microsoft YaHei'; margin-top: 10%; max-height: 22%; }
                .itmlist dd span:nth-child(4) { float: left; text-align: center; width: 22.3%; color: white; overflow: hidden; font-family: 'Microsoft YaHei'; margin-top: 10%; }
            .itmlist span:nth-child(4)::after { clear: both; }
        .clearinfo { clear: both; border: 1px dashed white; width: 100%; }
        /*.s1*/
    </style>
</head>
<body>
    <header class="app-header">
        <a href="javascript:void(0);" class="u-globalAudio z-play">
            <audio src="" loop="" src="" id="ttnb" autoplay="" preload type="audio/mpeg">
            </audio>
        </a>
    </header>
    <div class="load">
        <div class="loading"></div>
    </div>
    <div class="s1">
        <img src="img/xy/4.1.png" />
        <div class="s1_1">
            你的好友<span class="stname"><%=stnickname %></span><br />
            正在呼唤小伙伴
        </div>
        <img src="img/xy/btnbm.png" class="s1_2" />
        <img src="img/xy/btncy.png" class="s1_3" />
    </div>
    <div class="biggz">
        <img src="img/xy/gz.jpg" class="imggz" />
        <img src="img/xy/btnjx.png" class="btnjx" />
        <img src="img/xy/btnfh.png" class="btnfh" />
    </div>
    <div class="bigjx">
        <img src="img/xy/jx.jpg" class="imgjx" />
        <img src="img/xy/btnfh.png" class="btnfh1" />
    </div>

    <div class="divph">
        <dl class="itmlist">
        </dl>
        <img src="img/xy/btnfh.png" class="btnfh4" />
    </div>
    <img class="bigfx" src="img/xy/bigfx.png" />
    <div class="bg"></div>
    <div style="display: none;">
        <script src="http://s11.cnzz.com/z_stat.php?id=1254174137&web_id=1254174137" language="JavaScript"></script>
    </div>
    <input type="hidden" id="hidid" value="<%=curtid %>" />
    <input type="hidden" id="hid3" value="0" />
    <input type="hidden" id="hid4" value="<%=curXYDZAre %>" />
    <input type="hidden" id="hid5" value="<%=curXYDZAreTid %>" />
    <script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/loader.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/pc-prompt.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/film.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/dialog.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/overlay.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/slide.v2.0.min.js"></script>
    <script type="text/javascript" src="/Scripts/common.js"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.PCPrompt = new mo.PCPrompt();
        //dataForWeixin.title = "上海年华";
        //dataForWeixin.desc = "上海年华";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/lnInfo/img/xy/fxs.jpg";
        dataForWeixin.title = "我正在帮忙TA参加象屿·上海年华，快乐摘星，免费赢上海迪士尼套票活动，快来帮TA吧！";
        dataForWeixin.desc = "象屿·上海年华";
        dataForWeixin.async = true;
        dataForWeixin.url = "http://wsjhb.tencenthouse.com/lnInfo/xydzinfo.aspx?tid=<%=curtid%>";
        this.flag = !0;
        this.shadeFlag = !1;
        this.shadeFlag1 = !0;
        var pageindex = 0;
        var isget = true;
        var n = 0, a = 0;
        var isflag = 0;
        var countp = 0;
        var ww = $(window).width();
        var hh = $(window).height();
        var ticking = false; // rAF 触发锁
        function onScroll() {
            if (!ticking) {
                requestAnimationFrame(realFunc);
                ticking = true;
            }
        }
        function realFunc() {
            // do something...
            //if (($(".itmlist").scrollTop() + $(".itmlist").height() > $(".itmlist").height() - 40)) {
            if (isget) {
                pageindex++;
                loadinfolist(pageindex);
            }
            //}
            ticking = false;
        }
        var sourceArr = ['img/xy/4.jpg', 'img/xy/4.1.png', 'img/xy/btncy.png', 'img/xy/btnbm.png'];
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                //gid('loading_per').innerHTML = Math.floor(count / total * 100) + "%";
                //alert('加载中...（'+count/total*100+'%）');
            }, onComplete: function (time) {
                // gid("loading").parentNode.removeChild(gid("loading"));
                //var myVideo = document.getElementById("ttnb");
                //LoadAud(myVideo, "img/4.mp3");
                $(".s1,.biggz,.imggz,.bigjx,.imgjx,.bg,.addinfo,.s2,.bigfx,.divph").css({ width: ww, height: hh });
                setTimeout(function () {
                    $(".load").fadeOut("slow", function () {
                        $(".s1").fadeIn("slow");
                    });
                    //$(".load").fadeTo("slow", 0, function () {
                    //    $(".s1").fadeIn(50);
                    //});
                }, 5000);
                $(".s1_3").tap(function () {
                    window.location.href = "xyindex.aspx";
                });
                $(".s1_2").tap(function () {
                    $(".bg").show();
                    changhits();
                    $(".bg").hide();
                });
                $(".btnfh4").tap(function () {
                    $(".divph").fadeOut("slow", function () {
                        ticking = false;
                        pageindex = 0;
                        isget = true;
                        countp = 0;
                        $(".itmlist").scrollTop(0);
                        $(".itmlist").empty();
                    });
                });
                $(".sitem").tap(function () {
                    $(".bg").show();
                    if ($(this).attr("src") == "img/xy/sl.png") {
                        $(".bg").hide();
                    } else {
                        changhits($(this));

                        $(".bg").hide();
                    }
                });
                $(".s1_11,.s2_3").tap(function () {
                    $(".bg").show();
                    loadinfolist(0);
                    setTimeout(function () {
                        $(".divph").show();
                        $(".bg").hide();
                    }, 300);
                });
                $(".s1_10,.s2_2").tap(function () {
                    $(".bg").show();
                    $(".biggz").show();
                    $(".bg").hide();
                });
                $(".btnfh").tap(function () {
                    $(".biggz").hide();
                });
                $(".btnjx").tap(function () {
                    $(".bg").show();
                    $(".bigjx").show();
                    $(".bg").hide();
                });
                $(".btnfh1").tap(function () {
                    $(".bigjx").hide();
                });
                $(".s1_12").tap(function () {
                    $(".bg").show();
                    $(".addinfo").fadeIn();
                    $(".bg").hide();
                });
                $(".s2_4").tap(function () {
                    $(".bg").show();
                    $(".bigfx").fadeIn();
                    $(".bg").hide();
                });
                $(".bigfx").tap(function () {
                    $(".bigfx").fadeOut();
                });
                $(".btnfh2").tap(function () {
                    $(".addinfo").fadeOut();
                });
                $(".itmlist").on("scroll", onScroll, false);
            }
        });
        function LoadAud(obj, aud) {
            if (obj != null && obj.canPlayType && obj.canPlayType("audio/mpeg")) {
                obj.pause();
                obj.src = aud;
                try {
                    obj.currentTime = 0;
                    //alert("456")
                    obj.play();
                } catch (e) {

                }
                obj.play();
                document.addEventListener('WeixinJSBridgeReady', function () {
                    obj.play();
                });
                $audio = $("audio");
                if ($audio.length > 0) {
                    $(".u-globalAudio").addClass("play_yinfu");
                    $audio.parent("a").prepend('<i class="icon-music"></i>');
                }
                $(".u-globalAudio").on("click", function () {
                    $(this).toggleClass("z-play");
                    if ($(this).hasClass("z-play")) {
                        $(this).addClass("play_yinfu");
                        obj.play();
                    } else {
                        $(this).removeClass("play_yinfu");

                        obj.pause();
                    }
                });
            }
        }
        function showDialog(msg, type) {
            window.dia1 = new mo.Dialog({
                content: msg,
                type: type
            });
        }
        function changhits() {
            $.post("Operation.ashx", { type: "HDXYOtherZan", tmpid: $("#hidid").val(), curXYDZAre: $("#hid4").val(), curXYDZAreTid: $("#hid5").val() }, function (result) {
                //alert(result);
                if (result.ist == "0") {
                    showDialog('网络错误，请重试');
                    // 显示消息
                    return false;
                } else if (result.ist == "1") {
                    showDialog("帮他摘取星星成功！", "success");
                    return false;
                } else if (result.ist == "2") {
                    showDialog('请通过正规渠道进行操作');
                    return false;
                }
                else if (result.ist == "3") {
                    showDialog('活动时间已过，请关注公告信息');
                    return false;
                }
                else if (result.ist == "4") {
                    showDialog('网络错误，请重试');
                    return false;
                } else if (result.ist == "5") {
                    showDialog('您已点赞成功,不能重复点赞！');
                    return false;
                }
                //if (result.ist == "1") {
                //    //vt.attr("src", "img/xy/sl.png");

                //} else {
                //    showDialog(result.ismsgs, "alert")
                //}
            }, "json");
        }
        function loadinfolist(page) {
            if (page == 0) {
                $(".itmlist").empty();
            }
            $.post("Operation.ashx", { type: "XYPgList", tmppage: page, pagesize: "10" }, function (result) {
                var listd = "";
                //alert(result.count);
                //alert(result.count);
                if (parseInt(result.count) < 1) {
                    isget = false;
                } else {
                    $.each(result.result, function (i, n) {
                        ++countp;
                        listd += "<dd><span>" + countp + "</span><span><img src=\"" + n.img + "\"/></span><span>" + n.nickname + "</span><span>" + n.nums + "</span><hr class=\"clearinfo\"/></dd>"
                    });
                    $(".itmlist").append(listd);
                    $(".itmlist").scrollTop(0);
                }
            }, "json");
        }
    </script>
</body>
</html>
