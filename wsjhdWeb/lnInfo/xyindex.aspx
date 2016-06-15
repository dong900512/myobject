<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xyindex.aspx.cs" Inherits="NewInfoWeb.lnInfo.xyindex" %>

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

        @-webkit-keyframes run2 {
            0% { background: url(img/xy/b1.9.png); background-size: 100% 100%; }
            100% { background: url(img/xy/b1.10.png); background-size: 100% 100%; }
        }

        @-webkit-keyframes run3 {
            0% { background: url(img/xy/bs.1.png); background-size: 100% 100%; }
            50% { background: url(img/xy/bs.2.png); background-size: 100% 100%; }
            75% { background: url(img/xy/bs.3.png); background-size: 100% 100%; }
            100% { background: url(img/xy/bs.4.png); background-size: 100% 100%; }
        }

        @-webkit-keyframes run4 {
            16% { background: url(img/xy/b1.3.png); background-size: 100% 100%; }
            33% { background: url(img/xy/b1.4.png); background-size: 100% 100%; }
            49% { background: url(img/xy/b1.5.png); background-size: 100% 100%; }
            64% { background: url(img/xy/b1.6.png); background-size: 100% 100%; }
            80% { background: url(img/xy/b1.7.png); background-size: 100% 100%; }
            100% { background: url(img/xy/b1.8.png); background-size: 100% 100%; }
        }

        @-webkit-keyframes arrowtop {
            0% { -webkit-transform: translate3d(0,50%, 0); opacity: 1; }
            100% { -webkit-transform: translate3d(0, 0, 0); opacity: 0; }
        }

        @font-face { font-family: "ces"; src: "css/tt0037m_.ttf"; }

        @-webkit-keyframes ss1 {
            0% { opacity: .4; }
            100% { opacity: 1; }
        }

        @-webkit-keyframes down1 {
            0% { -webkit-transform: translate3d(0,0,0); opacity: 1; }
            100% { -webkit-transform: translate3d(15%,80%,0); opacity: 1; }
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

        .loading { position: absolute; width: 100%; height: 100%; background: url(img/xy/b1.png); background-size: 100% 100%; -webkit-animation: run1 ease-in infinite 4s; }
        .s1 { display: none; top: 0; left: 0; position: relative; background: url(img/xy/1.jpg); background-size: 100% 100%; overflow: hidden; }

            .s1 img, .s2 img { position: absolute; width: 100%; height: 100%; }
        .s1_1 { -webkit-animation: ss1 1s infinite alternate ease both; }
        .s1_2 { -webkit-animation: fd1 1s .3s linear both; }
        .s1_3 { -webkit-animation: fadeIn 1s .6s linear both; }
        .s1_4 { -webkit-animation: zoomIn 1s .9s linear both; }
        .s1_5 { -webkit-animation: bounceInRight 1s 1.2s linear both; }
        .s1_6 { -webkit-animation: bounceInLeft 1s 1.6s linear both; }
        .s1_7 { -webkit-animation: bounceIn 1s 2s linear both; }
        .s1_8 { -webkit-animation: bounceIn 1s 2.3s linear both; }
        .s1_9 { -webkit-animation: fd1 1s 2.6s linear both; }
        .s1_10 { width: 10% !important; right: 3%; z-index: 5; height: auto !important; bottom: 74%; -webkit-animation: fadeInRight 1s 2.8s linear both; }
        .s1_11 { width: 10% !important; z-index: 5; height: auto !important; right: 3%; bottom: 57%; -webkit-animation: fadeInRight 1s 3s linear both; }
        .s1_12 { width: 50% !important; z-index: 5; height: auto !important; left: 25%; bottom: 3%; -webkit-animation: fadeIn 1s 3.3s linear both; }
        .s1_13 { position: absolute; width: 100%; text-align: center; bottom: 16%; color: white; font-size: 15px; font-family: 微软雅黑; -webkit-animation: fadeIn 1s 2.2s linear both; }
        .biggz, .bigjx { position: absolute; top: 0; left: 0; z-index: 200; display: none; }
        .bg { position: absolute; z-index: 600; top: 0; left: 0; display: none; }
        .btnjx { position: absolute; width: 40%; bottom: 2%; left: 20%; }
        .btnfh { position: absolute; width: 20%; bottom: 2%; right: 20%; }
        .btnfh1 { position: absolute; width: 20%; bottom: 1%; right: 40%; }
        .addinfo { position: absolute; top: 0; left: 0; z-index: 200; display: none; background: url(img/xy/2.jpg); background-size: 100% 100%; }
        /*::-webkit-input-placeholder { color: #e73357; }*/
        input { border: 0px; padding-left: 5%; }
        .tname { position: absolute; width: 80%; height: 10%; background: url(img/xy/inpxm.png); background-size: 100% 100%; left: 10%; top: 12%; font-size: 100%; padding-left: 18%; }
        .tphone { position: absolute; width: 80%; height: 10%; background: url(img/xy/intphone.png); background-size: 100% 100%; left: 10%; top: 25%; font-size: 100%; padding-left: 18%; }
        .btnsure { position: absolute; width: 60%; left: 20%; bottom: 17%; }
        .btnfh2, .btnfh4 { position: absolute; width: 20%; left: 40%; bottom: 3%; }

        .s2 { display: none; top: 0; left: 0; position: relative; background: url(img/xy/3.jpg); background-size: 100% 100%; overflow: hidden; }
        .s2_1 { -webkit-animation: ss1 1s infinite alternate linear both; z-index: 1; }
        .s2_2 { width: 10% !important; right: 3%; z-index: 5; height: auto !important; bottom: 74%; }
        .s2_3 { width: 10% !important; z-index: 5; height: auto !important; right: 3%; bottom: 57%; }
        .s2_4 { width: 50% !important; height: auto !important; z-index: 5; bottom: 3%; left: 25%; }
        .bigfx { position: absolute; top: 0; left: 0; z-index: 500; display: none; }
        .s2_5 { position: absolute; width: 100%; text-align: center; color: #b78e5a; font-family: 'Microsoft JhengHei'; font-weight: bold; font-size: 17px; bottom: 20%; }
        .sitem { width: 10% !important; height: auto !important; z-index: 8; }
        .s2_6 { top: 2%; right: 23%; }
        .s2_7 { top: 6%; right: 35%; }
        .s2_8 { top: 8%; right: 46%; }
        .s2_9 { top: 10%; right: 58%; }
        .s2_10 { top: 6%; right: 71%; }
        .s2_11 { top: 14%; left: 10%; }
        .s2_12 { top: 22%; left: 15%; }
        .s2_6_1 { -webkit-animation: down1 2s linear both; }
        .s2_13 { width: 25% !important; height: auto !important; }
        .divph { position: absolute; top: 0; left: 0; z-index: 300; background: url(img/xy/phbj.jpg); background-size: 100% 100%; display: none; }
        .itmlist { width: 90%; position: absolute; z-index: 10%; left: 5%; height: 54%; font: 12px/1.5 tahoma, '\5b8b\4f53',sans-serif; overflow-y: auto; -webkit-overflow-scrolling: touch; bottom: 14%; }
            .itmlist dd { width: 100%; -webkit-margin-start: 0px; overflow: hidden; }
                .itmlist dd span:nth-child(1) { float: left; text-align: center; width: 17.3%; color: white; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-family: 'Microsoft YaHei'; margin-top: 5%; }
                .itmlist dd span:nth-child(2) { float: left; text-align: center; width: 28.3%; color: white; font-family: 'Microsoft YaHei'; margin-bottom: 2%; margin-top: 2%; }
                    .itmlist dd span:nth-child(2) img { width: 50%; border-radius: 50%; }
                .itmlist dd span:nth-child(3) { float: left; text-align: center; width: 29.3%; color: white; overflow: hidden; font-family: 'Microsoft YaHei'; margin-top: 5%; max-height: 22%; }
                .itmlist dd span:nth-child(4) { float: left; text-align: center; width: 22.3%; color: white; overflow: hidden; font-family: 'Microsoft YaHei'; margin-top: 5%; }
            .itmlist span:nth-child(4)::after { clear: both; }
        .clearinfo { clear: both; border: 1px dashed white; width: 100%; }
        .s3 { display: none; top: 0; left: 0; position: relative; background: url(img/xy/5.jpg); background-size: 100% 100%; overflow: hidden; }
            .s3 img { position: absolute; }
        .s3_1 { bottom: 5%; width: 24%; left: 15%; }
        .arraw { display: none; margin: 0 auto; -webkit-animation: arrowtop 1s ease-out infinite; z-index: 150; margin-left: 45%; width: 10%; bottom: 2%; position: absolute; }

        .load img, .load div { width: 100%; height: 100%; position: absolute; }
        .dlx { background: url(img/xy/b1.9.png); background-size: 100% 100%; -webkit-animation: run2 2s ease-in infinite; }
        .star1 { background: url(img/xy/bs.1.png); background-size: 100% 100%; -webkit-animation: run3 4s ease-in infinite; }
        .l1_1 { -webkit-animation: fd1 1s .3s linear both; }
        .l1_2 { -webkit-animation: fadeIn 1s 1.3s linear both; }
        .xlx { background: url(img/xy/b1.3.png); background-size: 100% 100%; -webkit-animation: run4 4s ease-in infinite; }
        #xlx, #dlx, #star1, #loading { display: none; }
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
        <%--<img src="img/xy/1.gif" />--%>
        <img src="img/xy/b1.1.png" class="l1_1" />
        <img src="img/xy/b1.2.png" id="l1_2" class="l1_2" />
        <div id="xlx"></div>
        <div id="dlx"></div>
        <div id="star1"></div>
        <div id="loading"></div>
    </div>
    <div class="s1">
        <img src="img/xy/1.1.png" class="s1_1" />
        <img src="img/xy/1.2.png" class="s1_2" />
        <img src="img/xy/1.3.png" class="s1_3" />
        <img src="img/xy/1.4.png" class="s1_4" />
        <img src="img/xy/1.5.png" class="s1_5" />
        <img src="img/xy/1.6.png" class="s1_6" />
        <img src="img/xy/1.7.png" class="s1_7" />
        <img src="img/xy/1.8.png" class="s1_8" />
        <img src="img/xy/1.9.png" class="s1_9" />
        <img src="img/xy/1.10.png" class="s1_10" />
        <img src="img/xy/1.11.png" class="s1_11" />
        <div class="s1_13">
            温馨提示<br />
            已经有<%=tnum %>人参与活动<br />
            (根据参加人数实时更新)
        </div>
        <img src="img/xy/1.12.png" class="s1_12" />
    </div>
    <div class="s2">
        <img src="img/xy/sm.png" class="s2_6 sitem" />
        <img src="img/xy/sm.png" class="s2_7 sitem" />
        <img src="img/xy/sm.png" class="s2_8 sitem" />
        <img src="img/xy/sm.png" class="s2_9 sitem" />
        <img src="img/xy/sm.png" class="s2_10 sitem" />
        <img src="img/xy/sm.png" class="s2_11 sitem" />
        <img src="img/xy/sm.png" class="s2_12 sitem" />
        <img src="img/xy/3.1.png" class="s2_1" />
        <img src="img/xy/1.10.png" class="s2_2" />
        <img src="img/xy/1.11.png" class="s2_3" />
        <img src="img/xy/3.2.png" style="top: 2%;" />
        <img src="img/xy/3.3.png" class="s2_13" />
        <div class="s2_5">
            我的星星数：<span class="spnum"><%=startNum %></span>，我排行第<span class="sptop"><%=stopNum %></span>位
        </div>
        <img src="img/xy/btnyq.png" class="s2_4" />
    </div>
    <div class="s3">
        <img src="img/xy/5.1.png" class="s3_1" />
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
    <div class="addinfo">
        <input placeholder="请输入姓名" class="tname" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
            onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" oncontextmenu="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" />
        <input placeholder="请输入手机号" type="tel" class="tphone" maxlength="11" onkeypress='return /^\d$/.test(String.fromCharCode(event.keyCode))'
            oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace(/\D+/g, "")'
            onblur='this.value = this.value.replace(/\D+/g, "")' />
        <img src="img/xy/btnsure.png" class="btnsure" />
        <img src="img/xy/btnfh.png" class="btnfh2" />
    </div>
    <div class="divph">
        <dl class="itmlist">
        </dl>
        <img src="img/xy/btnfh.png" class="btnfh4" />
    </div>
    <img class="bigfx" src="img/xy/bigfx.png" />
    <div class="bg"></div>
    <input type="hidden" id="hidid" value="<%=tid %>" />
    <input type="hidden" id="hid3" value="0" />
    <img src="img/arrow-up.png" class="arraw" />
    <div style="display: none;">
        <script src="http://s11.cnzz.com/z_stat.php?id=1254174137&web_id=1254174137" language="JavaScript"></script>
    </div>
    <script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
    <%--<script src="http://ossweb-img.qq.com/images/js/jquery/jquery-1.9.1.min.js"></script>--%>
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
        dataForWeixin.title = "上海年华";
        dataForWeixin.desc = "上海年华";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/lnInfo/img/xy/fxs.jpg";

        this.flag = !0;
        this.shadeFlag = !1;
        this.shadeFlag1 = !0;
        var pageindex = 0;
        var isget = true;
        var n = 0, a = 0;
        var isflag = 0;
        var countp = 0;
        var REG = {
            name: /^[a-zA-Z\u4e00-\u9fa5]{2,12}$/,
            phone: /(^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$)|(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/,
            wxid: /^[a-zA-Z][a-zA-Z0-9_-]{5,19}$/,
            number: /^[+\-]?\d+(\.\d+)?$/,
            idCard: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/
        }
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
        document.body.addEventListener('touchmove', function (evt) {
            //In this case, the default behavior is scrolling the body, which
            //would result in an overflow.  Since we don't want that, we preventDefault.
            if (!evt._isScroller) {
                evt.preventDefault()
            }
        })
        var overscroll = function (el) {
            el.addEventListener('touchstart', function () {
                var top = el.scrollTop
                  , totalScroll = el.scrollHeight
                  , currentScroll = top + el.offsetHeight
                //If we're at the top or the bottom of the containers
                //scroll, push up or down one pixel.
                //
                //this prevents the scroll from "passing through" to
                //the body.
                if (top === 0) {
                    el.scrollTop = 1
                } else if (currentScroll === totalScroll) {
                    el.scrollTop = top - 1
                }
            })
            el.addEventListener('touchmove', function (evt) {
                //if the content is actually scrollable, i.e. the content is long enough
                //that scrolling can occur
                if (el.offsetHeight < el.scrollHeight)
                    evt._isScroller = true
            })
        }

        document.getElementById("l1_2").addEventListener("webkitAnimationEnd", function
() {
            $("#xlx,#dlx,#star1,#loading").show();
            $("#xlx").addClass("xlx");
            $("#dlx").addClass("dlx");
            $("#star1").addClass("star1");
            $("#loading").addClass("loading");
        }, false);

        var sourceArr = ['img/xy/4.mp3', 'img/xy/bg1.jpg', 'img/xy/b1.png', 'img/xy/b1.png', 'img/xy/b1.png', 'img/xy/b1.png', 'img/xy/b1.png', 'img/xy/b1.png', 'img/xy/b1.png', 'img/xy/1.jpg', 'img/xy/2.jpg', 'img/xy/3.1.png', 'img/xy/3.2.png', 'img/xy/3.3.png', 'img/xy/3.jpg', 'img/xy/bigfx.png', 'img/xy/btnfh.png', 'img/xy/btnjx.png', 'img/xy/btnsure.png', 'img/xy/btnyq.png', 'img/xy/gz.jpg', 'img/xy/inpxm.png', 'img/xy/inphone.png', 'img/xy/jx.jpg', 'img/xy/phbj.jpg', 'img/xy/sl.png', 'img/xy/sm.png', 'img/xy/util.png', 'img/xy/5.1.png', 'img/xy/5.png'];
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                //gid('loading_per').innerHTML = Math.floor(count / total * 100) + "%";
                //alert('加载中...（'+count/total*100+'%）');
            }, onComplete: function (time) {
                // gid("loading").parentNode.removeChild(gid("loading"));
                var myVideo = document.getElementById("ttnb");
                LoadAud(myVideo, "img/xy/4.mp3");
                return false;
                $(".s1,.biggz,.imggz,.bigjx,.imgjx,.bg,.addinfo,.s2,.bigfx,.divph,.s3").css({ width: ww, height: hh });
                setTimeout(function () {
                    $(".load").fadeOut("slow", function () {
                        if ("<%=isx%>" == "1") {
                            switch ("<%=startNum%>") {
                                case "1":
                                    $(".s2_12").hide();//.attr("src", "img/xy/sl.png");
                                    break;
                                case "2":
                                    $(".s2_12,.s2_11").hide();//.attr("src", "img/xy/sl.png");
                                    break;
                                case "3":
                                    $(".s2_12,.s2_11,.s2_10").hide();//.attr("src", "img/xy/sl.png");
                                    break;
                                case "4":
                                    $(".s2_12,.s2_11,.s2_10,.s2_9").hide();//.attr("src", "img/xy/sl.png");
                                    break;
                                case "5":
                                    $(".s2_12,.s2_11,.s2_10,.s2_9,.s2_8").hide();//.attr("src", "img/xy/sl.png");
                                    break;
                                case "6":
                                    $(".s2_12,.s2_11,.s2_10,.s2_9,.s2_8,.s2_7").hide();//.attr("src", "img/xy/sl.png");
                                    break;
                                case "7":
                                    $(".s2_12,.s2_11,.s2_10,.s2_9,.s2_8,.s2_7,.s2_6").hide();//.attr("src", "img/xy/sl.png");
                                    break;
                            }
                            dataForWeixin.async = true;
                            dataForWeixin.title = "我正在参加象屿·上海年华，快乐摘星，免费赢上海迪士尼套票活动！"
                            dataForWeixin.desc = "你能帮我实现愿望吗？赶快来帮忙吧！";
                            dataForWeixin.url = "http://wsjhb.tencenthouse.com/lnInfo/xydzinfo.aspx?tid=<%=tid%>";
                            $(".arraw").show();
                            $(".s2").fadeIn("slow");
                        } else {
                            $(".s1").fadeIn("slow");
                        }
                    });
                    //$(".load").fadeTo("slow", 0, function () {
                    //    $(".s1").fadeIn(50);
                    //});
                }, 3000);
                overscroll(document.querySelector('.itmlist'));
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
                $(".s2").swipeUp(function () {
                    $(".s2").fadeOut("slow", function () {
                        $(".s3").show();
                        $(".arraw").hide();
                    })
                });
                $(".s3").swipeDown(function (e) {
                    e.preventDefault();
                    $(".s3").fadeOut("slow", function () {
                        $(".s2").show();
                        $(".arraw").show();
                    })
                });
                $(".sitem").tap(function () {
                    var ttop = $(".s2_5").offset().top;
                    var tleft = ww * 0.4;
                    //this.style.webkitTransform = "translate3d(" + rt + "px,0,0)";
                    //return false;
                    $(".bg").show();
                    if ($(this).attr("src") == "img/xy/sl.png") {
                        $(".bg").hide();
                    } else {
                        $(this).attr("src", "img/xy/sl.png");
                        $(this).css({ "transform": "translate3d(" + tleft + "px," + ttop + "px,0)", "transition": "all ease 3s", "opacity": "0" });
                        changhits($(this));
                        $(".bg").hide();
                    }
                });
                $(".s1_11,.s2_3").tap(function () {

                    $(".bg").show();
                    loadinfolist(0);
                    $(".itmlist").scrollTop(0);
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
                $(".btnsure").tap(function () {
                    var name = $.trim($(".tname").val());
                    var phone = $.trim($(".tphone").val());
                    if (name == "" || name == null) {
                        showDialog("请输入姓名信息");
                        return false;
                    }

                    if (phone == "" || phone == null) {
                        showDialog("请输入手机号码信息");
                        return false;
                    }
                    var usernamereg = /^(13|15|16|14|18|17)[0-9]{9}$/;
                    if (!usernamereg.test(phone)) {
                        showDialog("请输入正确的手机号码");
                        return false;
                    }
                    $(".btnsure").attr("disabled", "disabled");
                    $(".bg").show();
                    window.overlay1 = new mo.Overlay({
                        content: "信息提交中，请稍后...",
                        valign: 'top',
                        offset: [0, 10]
                    });
                    $.ajax({
                        type: 'post',
                        url: 'Operation.ashx',
                        dataType: 'json',
                        data: {
                            type: "AddXYInfo", tname: name, tphone: phone
                        },
                        success: function (data) {
                            overlay1.close();
                            $(".bg").hide();
                            if (data.count == "2") {
                                //alert(data.result);
                                $("#hidid").val(data.code);
                                $(".spnum").text("0");
                                $(".sptop").text(data.result);
                                showDialog("信息提交成功!", "success");
                                dataForWeixin.async = true;
                                dataForWeixin.title = "我正在参加象屿·上海年华，快乐摘星，免费赢上海迪士尼套票活动！"
                                dataForWeixin.desc = "你能帮我实现愿望吗？赶快来帮忙吧！";
                                dataForWeixin.url = "http://wsjhb.tencenthouse.com/lnInfo/xydzinfo.aspx?tid=" + data.code;
                                $(".addinfo").fadeOut("slow", function () {
                                    $(".s1").hide();
                                    $(".arraw").show();
                                    $(".s2").fadeIn("slow");
                                });
                                return false;
                            } else if (data.count == "1") {
                                showDialog("请不要重复提交!", "alert");
                                return false;
                            } else if (data.count == "3") {
                                showDialog(data.code, "alert");
                                return false;
                            }
                            else {
                                showDialog("网络出错,请稍后提交", "error");
                                return false;
                            }
                        },
                        error: function (xhr, type, error) {
                            showDialog("出错信息：" + error)
                        }
                    });
                    $(".btnsure").removeAttr("disabled");
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
        function changhits(vt) {
            $.post("Operation.ashx", { type: "HDXYZJZan", tmpid: $("#hidid").val() }, function (result) {
                //alert(result);
                if (result.ist == "4") {
                    //vt.attr("src", "img/xy/sl.png");
                    $(".spnum").text(result.nums);
                    $(".sptop").text(result.ismsgs);
                    return false;
                } else {
                    showDialog(result.ismsgs, "alert")
                }
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
                    //alert(listd);
                    $(".itmlist").append(listd);
                    $(".itmlist").scrollTop(0);
                }
            }, "json");
        }
        //speed 滚动速度 time 时间间隔
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
</body>
</html>
