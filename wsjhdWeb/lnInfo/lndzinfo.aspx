<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lndzinfo.aspx.cs" Inherits="NewInfoWeb.lnInfo.lndzinfo" %>

<!DOCTYPE >
<html>
<head>
    <meta charset="UTF-8">
    <title>刘若英 我敢 济南演唱会</title>
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
      
        .s1 { top: 0; left: 0; position: relative; background: url(img/ln/8.jpg); background-size: 100% 100%; overflow: hidden; }
            .s1 img, .s2 img { position: absolute; width: 100%; height: 100%; }
        .s1_1 { position: absolute; width: 100%; text-align: center; font-family: 'Microsoft YaHei'; font-size: 18px; color: #b78e5a;    bottom: 38%; }
        .stname { color: white; }
        .s1_3 { width: 40% !important; height: auto !important; left: 30%; bottom: 3%; }
        .s1_2 { width: 40% !important; height: auto !important; left: 30%; bottom: 13%; }
        .s1_4 { position: absolute; color: white; text-align: center; width: 100%; bottom: 25%; font-size: 1.3rem; }
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
    <script src="js/thelper.js" type="text/javascript"></script>
    <header class="app-header">
        <a href="javascript:void(0);" class="u-globalAudio z-play">
            <audio src="" loop="" src="" id="ttnb" autoplay="" preload type="audio/mpeg">
            </audio>
        </a>
    </header>

    <div class="s1">
        <div class="s1_1">
            你的好友<span class="stname"><%=stnickname %></span>
            正在呼唤小伙伴<br />
            快来帮TA赢取刘若英演唱会门票！
       
        </div>
        <div class="s1_4"><%=stnickname %>现在的勇气数:<span class="stords"><%=stords %></span></div>
        <img src="img/ln/btnbm.png" class="s1_2" />
        <img src="img/ln/btncy.png" class="s1_3" />
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
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/lnInfo/img/ln/fxs.jpg";
        dataForWeixin.title = "我正在帮忙TA参加免费领取刘若英 我敢 济南演唱会，快来帮TA吧！";
        dataForWeixin.desc = "山东鲁能7号助力刘若英 我敢 济南演唱会";
        dataForWeixin.async = true;
        dataForWeixin.url = "http://wsjhb.tencenthouse.com/lnInfo/lndzinfo.aspx?tid=<%=curtid%>";
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
        document.body.addEventListener('touchmove', function (evt) {
            //In this case, the default behavior is scrolling the body, which
            //would result in an overflow.  Since we don't want that, we preventDefault.
            if (!evt._isScroller) {
                evt.preventDefault()
            }
        })
        var sourceArr = ['img/ln/8.jpg', 'img/xy/4.1.png', 'img/ln/btncy.png', 'img/ln/btnbm.png'];
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                gid('loading_per').innerHTML = Math.floor(count / total * 100) + "%";
                //alert('加载中...（'+count/total*100+'%）');
            }, onComplete: function (time) {
                gid("loading").parentNode.removeChild(gid("loading"));
                //var myVideo = document.getElementById("ttnb");
                //LoadAud(myVideo, "img/4.mp3");
                $(".s1,.biggz,.imggz,.bigjx,.imgjx,.bg,.addinfo,.s2,.bigfx,.divph").css({ width: ww, height: hh });
                //setTimeout(function () {
                //    $(".load").fadeOut("slow", function () {
                //        $(".s1").fadeIn("slow");
                //    });

                //}, 5000);
                $(".s1_3").tap(function () {
                    window.location.href = "lnychindex.aspx";
                });
                $(".s1_2").tap(function () {
                    $(".bg").show();
                    changhits();
                    $(".bg").hide();
                });
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
            window.overlay1 = new mo.Overlay({
                content: "勇气助力中，请稍后...",
                valign: 'top',
                offset: [0, 10]
            });
            $.post("Operation.ashx", { type: "HDlnOtherZan", tmpid: $("#hidid").val(), curXYDZAre: $("#hid4").val(), curXYDZAreTid: $("#hid5").val() }, function (result) {
                overlay1.close();
                //alert(result);
                if (result.ist == "0") {
                    showDialog('网络错误，请重试');
                    // 显示消息
                    return false;
                } else if (result.ist == "1") {
                    $(".stords").text(result.ismsgs);
                    showDialog("勇气助力成功！", "success");
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
                    showDialog('您已帮助ta勇气助力成功,不能贪心！');
                    return false;
                }
                //if (result.ist == "1") {
                //    //vt.attr("src", "img/xy/sl.png");

                //} else {
                //    showDialog(result.ismsgs, "alert")
                //}
            }, "json");
        }

    </script>
</body>
</html>
