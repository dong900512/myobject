<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lnychindex.aspx.cs" Inherits="NewInfoWeb.lnInfo.lnychindex" %>

<!DOCTYPE >
<html>
<head>
    <meta charset="UTF-8">
    <title>我敢--鲁能泰山7号</title>
    <meta name="description" content="泰山7号" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="renderer" content="webkit">
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <style>
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
        .s1_11 { width: 10% !important; z-index: 5; height: auto !important; right: 3%; bottom: 54%; -webkit-animation: fadeInRight 1s 3s linear both; }
        .s1_12 { width: 50% !important; z-index: 5; height: auto !important; left: 25%; bottom: 3%; -webkit-animation: fadeIn 1s 3.3s linear both; }
        .s1_13 { position: absolute; width: 100%; text-align: center; bottom: 16%; color: white; font-size: 15px; font-family: 微软雅黑; -webkit-animation: fadeIn 1s 2.2s linear both; }
        .biggz, .bigjx { position: absolute; top: 0; left: 0; z-index: 200; display: none; }
        .bg { position: absolute; z-index: 600; top: 0; left: 0; display: none; }
        .btnjx { position: absolute; width: 40%; bottom: 5%; left: 20%; }
        .btnfh { position: absolute; width: 20%; bottom: 2%; right: 20%; }
        .btnfh1 { position: absolute; width: 20%; bottom: 1%; right: 40%; }
        .addinfo { position: absolute; top: 0; left: 0; z-index: 200; display: none; background: url(img/ln/6.jpg); background-size: 100% 100%; }
        /*::-webkit-input-placeholder { color: #e73357; }*/
        input { border: 0px; padding-left: 5%; }
        .tname { position: absolute; width: 80%; height: 10%; background: url(img/ln/inpxm.png); background-size: 100% 100%; left: 10%; top: 12%; font-size: 100%; padding-left: 18%; }
        .tphone { position: absolute; width: 80%; height: 10%; background: url(img/ln/intphone.png); background-size: 100% 100%; left: 10%; top: 25%; font-size: 100%; padding-left: 18%; }
        .btnsure { position: absolute; width: 50%; left: 26%; bottom: 48%; }
        .btnfh2 { position: absolute; width: 20%; left: 40%; bottom: 33%; }
        .btnfh4 { position: absolute; width: 20%; left: 40%; bottom: 3%; }
        .imger { position: absolute; width: 70%; left: 15%; bottom: 4%; }

        .s2 { display: none; top: 0; left: 0; position: relative; background: url(img/ln/7.jpg); background-size: 100% 100%; overflow: hidden; }
        .s2_1 { -webkit-animation: ss1 1s infinite alternate linear both; z-index: 1; }
        .s2_2 { width: 10% !important; right: 3%; z-index: 5; height: auto !important; bottom: 74%; }
        .s2_3 { width: 10% !important; z-index: 5; height: auto !important; right: 3%; bottom: 54%; }
        .s2_4 { width: 50% !important; height: auto !important; z-index: 5; bottom: 3%; left: 25%; }
        .bigfx { position: absolute; top: 0; left: 0; z-index: 500; display: none; }
        .s2_5 { position: absolute; width: 100%; text-align: center; color: #b78e5a; font-family: 'Microsoft JhengHei'; font-weight: bold; font-size: 17px; bottom: 14%; }
        .sitem { width: 26% !important; height: auto !important; z-index: 8; }
        .sitem1 { width: 26% !important; height: auto !important; z-index: 9; display: none; }
        .st1 { left: 23%; bottom: 53%; }
        .st2 { right: 23%; bottom: 53%; }
        .st3 { bottom: 40%; left: 10%; }
        .st4 { bottom: 40%; left: 38%; }
        .st5 { bottom: 40%; right: 8%; }
        .st6 { bottom: 27%; left: 25%; }
        .st7 { bottom: 27%; right: 22%; }
        .s2_6_1 { -webkit-animation: down1 2s linear both; }
        .s2_13 { width: 15% !important; height: auto !important; right: 5%; bottom: 26%; pointer-events: none; }
        .divph { position: absolute; top: 0; left: 0; z-index: 300; background: url(img/ln/phbj.jpg); background-size: 100% 100%; display: none; }
        .itmlist { width: 90%; position: absolute; z-index: 10; left: 5%; height: 66%; font: 12px/1.5 tahoma, '\5b8b\4f53',sans-serif; overflow-y: auto; -webkit-overflow-scrolling: touch; bottom: 14%; }
            .itmlist dd { width: 100%; -webkit-margin-start: 0px; overflow: hidden; margin-top: 2%; }
                .itmlist dd span:nth-child(1) { float: left; text-align: center; font-size: 1rem; width: 20%; color: #edd05b; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-family: 'Microsoft YaHei'; margin-bottom: 2%; }
                .itmlist dd span:nth-child(2) { float: left; text-align: center; font-size: 1rem; width: 50%; color: #edd05b; font-family: 'Microsoft YaHei'; margin-bottom: 2%; }

                .itmlist dd span:nth-child(3) { float: left; text-align: center; font-size: 1rem; width: 30%; color: #edd05b; overflow: hidden; font-family: 'Microsoft YaHei'; margin-bottom: 2%; }

                    .itmlist dd span:nth-child(3)::after { clear: both; }
        .clearinfo { clear: both; border: 1px dashed #edd05b; width: 100%; }
        .s3 { display: none; top: 0; left: 0; position: relative; background: url(img/xy/5.jpg); background-size: 100% 100%; overflow: hidden; }
            .s3 img { position: absolute; }
        .s3_1 { bottom: 5%; width: 24%; left: 15%; }
        .arraw { display: none; margin: 0 auto; -webkit-animation: arrowtop 1s ease-out infinite; z-index: 150; margin-left: 45%; width: 10%; bottom: 2%; position: absolute; }

        .load img, .load div { width: 100%; height: 100%; position: absolute; }
        .dlx { background: url(img/xy/b1.9.png); background-size: 100% 100%; -webkit-animation: run2 2s ease-in infinite; }
        .star1 { background: url(img/xy/bs.1.png); background-size: 100% 100%; -webkit-animation: run3 4s ease-in infinite; }

        .xlx { background: url(img/xy/b1.3.png); background-size: 100% 100%; -webkit-animation: run4 4s ease-in infinite; }

        .slide { position: relative; width: 100%; height: 100%; overflow: hidden; display: none; }
            .slide .content { width: 100%; height: 100%; margin: 0 auto; }
                .slide .content li { width: 100%; height: 100%; overflow: hidden; -webkit-background-size: cover; background-size: 100% 100%; color: #fff; font-size: 100px; }

                    .slide .content li:nth-child(1) { background-image: url(img/ln/4.jpg); background-size: 100% 100%; }
                    .slide .content li:nth-child(2) { background-image: url(img/ln/5.jpg); background-size: 100% 100%; }
                    .slide .content li img { position: absolute; width: 100%; height: 100%; z-index: -5; }
        #l1_2 { display: none; }
        #l2_2 { display: none; }
        #l3_2 { display: none; }
        .s4, .s5, .s6 { position: relative; display: none; top: 0; left: 0; }
            .s4 img, .s5 img, .s6 img { width: 100%; height: 100%; position: absolute; }
        /*.s1*/
        ul, menu, dir { -webkit-padding-start: 0px; }
        .l4_1 { -webkit-animation: fd1 1s .3s linear both; }
        .l4_2 { -webkit-animation: zoomIn 1s .6s linear both; }
        .l4_3 { -webkit-animation: fadeIn 1s 1.3s linear both; }
        .l4_4 { -webkit-animation: bounceIn 1s 1.5s linear both; }
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
    <div class="s4">
        <img src="img/ln/1.jpg" id="l1_1" />
        <img src="img/ln/1.1.jpg" id="l1_2" />
    </div>
    <div class="s5">
        <img src="img/ln/2.jpg" id="l2_1" />
        <img src="img/ln/2.1.jpg" id="l2_2" style="display: none;" />
    </div>
    <div class="s6">
        <img src="img/ln/3.jpg" id="l3_1" />
        <img src="img/ln/3.1.jpg" id="l3_2" style="display: none;" />
    </div>
    <div class="slide">
        <ul class="content">

            <li class="l4">
                <img src="img/ln/4.1.png" id="l4_1" />
                <img src="img/ln/4.2.png" id="l4_2" />
                <img src="img/ln/4.3.png" id="l4_3" />
                <img src="img/ln/4.4.png" id="l4_4" />
            </li>
            <li class="l5">

                <img src="img/ln/1.10.png" class="s1_10" />
                <img src="img/ln/1.11.png" class="s1_11" />
                <div class="s1_13">
                    温馨提示<br />
                    已经有<%=tnum %>人参与活动<br />
                    (根据参加人数实时更新)
       
                </div>
                <img src="img/ln/1.12.png" class="s1_12" />
            </li>

        </ul>
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
        <img src="img/ln/s1.png" data-src="img/ln/s1_1.png" class="sitem st1" />
        <img src="img/ln/s1_1.png" class="sitem1 st1" />
        <img src="img/ln/s2_1.png" class="sitem1 st2" />
        <img src="img/ln/s3_1.png" class="sitem1 st3" />
        <img src="img/ln/s4_1.png" class="sitem1 st4" />
        <img src="img/ln/s5_1.png" class="sitem1 st5" />
        <img src="img/ln/s6_1.png" class="sitem1 st6" />
        <img src="img/ln/s7_1.png" class="sitem1 st7" />
        <img src="img/ln/s2.png" data-src="img/ln/s2_1.png" class="sitem st2" />
        <img src="img/ln/s3.png" data-src="img/ln/s3_1.png" class="sitem st3" />
        <img src="img/ln/s4.png" data-src="img/ln/s4_1.png" class="sitem st4" />
        <img src="img/ln/s5.png" data-src="img/ln/s5_1.png" class="sitem st5" />
        <img src="img/ln/s6.png" data-src="img/ln/s6_1.png" class="sitem st6" />
        <img src="img/ln/s7.png" data-src="img/ln/s7_1.png" class="sitem st7" />
        <img src="img/ln/1.10.png" class="s2_2" />
        <img src="img/ln/1.11.png" class="s2_3" />
        <img src="img/ln/tips.png" class="s2_13" />
        <div class="s2_5">
            <div style="color: white">我的勇气：<span class="spnum"><%=stotal %></span>，我的排行<span class="sptop"><%=stopNum %></span></div>
            需要更多勇气，分享朋友圈找好友助力
       
        </div>
        <img src="img/ln/btnyq.png" class="s2_4" />
    </div>
    <div class="s3">
        <img src="img/xy/5.1.png" class="s3_1" />
    </div>
    <div class="biggz">
        <img src="img/ln/gz.jpg" class="imggz" />
        <img src="img/ln/btnjx.png" class="btnjx" />
        <img src="img/ln/btnfh.png" class="btnfh" />
    </div>
    <div class="bigjx">
        <img src="img/ln/jx.jpg" class="imgjx" />
        <img src="img/ln/btnfh.png" class="btnfh1" />
    </div>
    <div class="addinfo">
        <input placeholder="姓名" class="tname" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
            onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" oncontextmenu="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" />
        <input placeholder="联系方式" type="tel" class="tphone" maxlength="11" onkeypress='return /^\d$/.test(String.fromCharCode(event.keyCode))'
            oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace(/\D+/g, "")'
            onblur='this.value = this.value.replace(/\D+/g, "")' />
        <img src="img/ln/btnsure.png" class="btnsure" />
        <img src="img/ln/btnfh.png" class="btnfh2" />
        <img src="img/ln/er.png" class="imger" />
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
    <script src="http://touch.code.baidu.com/touch.min.js"></script>
    <script type="text/javascript" src="/Scripts/common.js"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.PCPrompt = new mo.PCPrompt();
        dataForWeixin.title = "我敢--鲁能泰山7号";
        dataForWeixin.desc = "我敢--鲁能泰山7号";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/lnInfo/img/ln/fxs.jpg";

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
        var sourceArr = ['img/ln/1.1.jpg', 'img/ln/1.jpg', 'img/ln/2.1.jpg', 'img/ln/2.jpg', 'img/ln/3.1.jpg', 'img/ln/3.jpg', 'img/ln/4.1.png', 'img/ln/4.2.png', 'img/ln/4.3.png', 'img/ln/4.4.png', 'img/ln/4.jpg', 'img/ln/5.jpg', 'img/ln/6.jpg', 'img/ln/btnbm.png', 'img/ln/btncy.png', 'img/ln/btnfh.png', 'img/ln/btnjx.png', 'img/ln/btnsure.png', 'img/ln/btnyq.png', 'img/ln/fxs.jpg', 'img/ln/gz.jpg', 'img/ln/inpxm.png', 'img/ln/intphone.png', 'img/ln/jx.jpg', 'img/ln/phbj.jpg', 'img/ln/s1.png', 'img/ln/s1_1.png', 'img/ln/s2.png', 'img/ln/s2_1.png', 'img/ln/s3.png', 'img/ln/s3_1.png', 'img/ln/s4.png', 'img/ln/s4_1.png', 'img/ln/s5.png', 'img/ln/s5_1.png', 'img/ln/s6.png', 'img/ln/s6_1.png', 'img/ln/s7.png', 'img/ln/s7_1.png', 'img/ln/tips.png'];
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                gid('loading_per').innerHTML = Math.floor(count / total * 100) + "%";
                //alert('加载中...（'+count/total*100+'%）');
            }, onComplete: function (time) {
                gid("loading").parentNode.removeChild(gid("loading"));
                //var myVideo = document.getElementById("ttnb");
                //LoadAud(myVideo, "img/xy/4.mp3");
                //return false;
                $(".s1,.biggz,.imggz,.bigjx,.imgjx,.bg,.addinfo,.s2,.bigfx,.divph,.s3,.s4,.s5,.s6").css({ width: ww, height: hh });
                var tg1 = document.getElementById("l1_2");
                var tg2 = document.getElementById("l2_2");
                var tg3 = document.getElementById("l3_2");
                $(".s4").fadeIn("30");

                touch.on('#l1_2,#l2_2,#l3_2', 'touchstart', function (ev) {
                    ev.preventDefault();
                });
                $("#l1_1").tap(function () {
                    $(".arraw").show();
                    $("#l1_2").fadeIn("30");
                });
                touch.on(tg1, 'swipeup', function (ev) {
                    $(".s4").fadeOut("30", function () {
                        $(".arraw").hide();
                        $(".s5").fadeIn("30");
                    });
                });
                $("#l2_1").tap(function () {
                    $(".arraw").show();
                    $("#l2_2").fadeIn("30");
                });
                touch.on(tg2, 'swipeup', function (ev) {
                    $(".s5").fadeOut("30", function () {
                        $(".arraw").hide();
                        $(".s6").fadeIn("30");
                    });
                });

                $("#l3_1").tap(function () {
                    $(".arraw").show();
                    $("#l3_2").fadeIn("30");
                });
                touch.on(tg3, 'swipeup', function (ev) {
                    $(".s6").fadeOut("30", function () {
                        showslid();
                    });
                });
                //$(".s4").fadeOut("10");
                //showslid();
                setTimeout(function () {
                    if ("<%=isx%>" == "1") {
                        if ("<%=strstart%>" != "-1") {
                            var str = "<%=strstart%>".split(",");
                            for (var i = 0; i < str.length; i++) {
                                $(".sitem").eq(str[i]).addClass("ishow");
                                $(".sitem1").eq(str[i]).show();
                            }
                        }
                        $(".arraw").hide();
                        $(".s4").fadeOut("10");
                        $(".s2").fadeIn("slow");
                        dataForWeixin.async = true;
                        dataForWeixin.title = "我正在参加鲁能泰山7号'我敢'刘若英演唱会，免费赢门票活动！"
                        dataForWeixin.desc = "你能帮我实现愿望吗？赶快来帮忙吧！";
                        dataForWeixin.url = "http://wsjhb.tencenthouse.com/lnInfo/lndzinfo.aspx?tid=<%=tid%>";
                    }
                }, 200);

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

                $(".sitem").on("touchstart", function (e) {
                    //var ttop = $(".s2_5").offset().top;
                    //var tleft = ww * 0.4;
                    //this.style.webkitTransform = "translate3d(" + rt + "px,0,0)";
                    //return false;
                    $(".bg").show();
                    if ($(this).hasClass("ishow")) {
                        $(".bg").hide();
                    } else {
                        $(this).addClass("ishow");
                        var tindex = $(".sitem").index($(this));
                        $(".sitem1").eq(tindex).show();
                        //$(this).attr("src", $(this).attr("data-src"));
                        changhits($(this), tindex);
                        $(".bg").hide();
                    }
                });
                $(".s1_11,.s2_3").on("touchstart", function () {
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
                $(".btnsure").on("touchstart", function () {
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
                            type: "AddLnqpInfo", tname: name, tphone: phone
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
                                dataForWeixin.title = "我正在参加鲁能泰山7号'我敢'刘若英演唱会，免费赢门票活动！"
                                dataForWeixin.desc = "你能帮我实现愿望吗？赶快来帮忙吧！";
                                dataForWeixin.url = "http://wsjhb.tencenthouse.com/lnInfo/lndzinfo.aspx?tid=" + data.code;
                                $(".addinfo").fadeOut("slow", function () {
                                    $(".slide").hide();
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
        function showslid() {
            $(".slide").show();
            window.pageSlide = new mo.Slide({
                target: $('.slide li'),
                playTo: 0,
                event: {
                    init: function (e) {
                        $(".l4 img").css("opacity", "1");
                        $("#l4_1").addClass("l4_1");
                        $("#l4_2").addClass("l4_2");
                        $("#l4_3").addClass("l4_3");
                        $("#l4_4").addClass("l4_4");
                    },
                    change: function () {
                        var ti = this.curPage;
                        if (ti == 0) {
                            $(".l4 img").css("opacity", "1");
                            $("#l4_1").addClass("l4_1");
                            $("#l4_2").addClass("l4_2");
                            $("#l4_3").addClass("l4_3");
                            $("#l4_4").addClass("l4_4");
                        } else {
                            $(".l4 img").css("opacity", "0");
                            $("#l4_1").removeClass("l4_1");
                            $("#l4_2").removeClass("l4_2");
                            $("#l4_3").removeClass("l4_3");
                            $("#l4_4").removeClass("l4_4");
                        }
                        if (ti == 1) {
                            //$(".l5 img").css("opacity");
                            $(".arraw").hide();
                        } else {
                            $(".arraw").show();
                        }
                    }
                }
            });
        }
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
        function changhits(vt, tcuri) {
            $.post("Operation.ashx", { type: "HDlnZJZan", tmpid: $("#hidid").val(), tcurinfo: tcuri }, function (result) {
                //alert(result);
                if (result.ist == "4") {
                    //vt.attr("src", "img/xy/sl.png");
                    $(".spnum").text(result.nums);
                    $(".sptop").text(result.ismsgs);
                    //return false;
                } else {
                    showDialog(result.ismsgs, "alert")
                }
            }, "json");
        }
        function loadinfolist(page) {
            if (page == 0) {
                $(".itmlist").empty();
            }
            $.post("Operation.ashx", { type: "LNQPPgList", tmppage: page, pagesize: "10" }, function (result) {
                var listd = "";
                //alert(result.count);
                //alert(result.count);
                if (parseInt(result.count) < 1) {
                    isget = false;
                } else {
                    $.each(result.result, function (i, n) {
                        ++countp;
                        //alert(countp);
                        listd += "<dd><span>" + countp + "</span><span>" + n.nickname + "</span><span>" + n.nums + "</span><hr class=\"clearinfo\"/></dd>"
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
