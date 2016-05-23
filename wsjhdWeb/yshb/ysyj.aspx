<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ysyj.aspx.cs" Inherits="NewInfoWeb.yshb.ysyj" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>燕山一號老业主感恩回馈</title>
    <meta name="description" content="燕山一號老业主感恩回馈" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-touch-fullscreen" content="yes">
    <!-- 是否启用 WebApp 全屏模式，删除苹果默认的工具栏和菜单栏 -->
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <!-- 设置苹果工具栏颜色 -->
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <!-- 忽略页面中的数字识别为电话，忽略email识别 -->
    <meta name="format-detection" content="telphone=no, email=no" />
    <!-- 启用360浏览器的极速模式(webkit) -->
    <meta name="renderer" content="webkit">
    <!--优先使用 IE 最新版本和 Chrome-->
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!--百度禁止转码-->
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <!-- 针对手持设备优化，主要是针对一些老的不识别viewport的浏览器，比如黑莓 -->
    <meta name="HandheldFriendly" content="true">
    <!-- 微软的老式浏览器 -->
    <meta name="MobileOptimized" content="320">
    <!-- uc强制竖屏 -->
    <meta name="screen-orientation" content="portrait">
    <!-- QQ强制竖屏 -->
    <meta name="x5-orientation" content="portrait">
    <!-- UC强制全屏 -->
    <meta name="full-screen" content="yes">
    <!-- QQ强制全屏 -->
    <meta name="x5-fullscreen" content="true">
    <!-- UC应用模式 -->
    <meta name="browsermode" content="application">
    <!-- QQ应用模式 -->
    <meta name="x5-page-mode" content="app">
    <!-- windows phone 点击无高光 -->
    <meta name="msapplication-tap-highlight" content="no">
    <!--无缓存设置-->
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate" />
    <meta http-equiv="expires" content="Wed, 26 Feb 1997 08:21:57 GMT" />
    <link href="/Tepay/css/swiper-3.2.5.min.css" rel="stylesheet" type="text/css" />
    <link href="/Tepay/css/animate.min.css" rel="stylesheet" type="text/css" />
    <link href="/Tepay/css/loading.css" rel="stylesheet" type="text/css" />
    <style>
        html, body { width: 100%; height: 100%; overflow: hidden; max-width: 640px; }
        .hide { display: none; }
        .main { max-width: 640px; width: 100%; height: 100%; overflow: hidden; display: none; }
        ul, ol, dl { list-style: none; }
        .arrows-up { position: absolute; z-index: 100000; left: 50%; margin-left: -20px; bottom: 1%; -webkit-animation: arrowsSlide 1s linear infinite; }
        .arrowsSlide { -webkit-animation-name: arrowsSlide; animation-name: arrowsSlide; /*-webkit-animation: arrowsSlide ease-out 1s infinite; 	-webkit-animation-delay: 0.5s*/ }
        .swiper-container { width: 100%; position: absolute; top: 0; left: 0; }
        .pg1_1 { position: absolute; top: 0; width: 100%; height: 100%; }
        .pg1_2 { position: absolute; top: 0; width: 100%; height: 100%; }
        .pg1_3 { position: absolute; top: 0; width: 100%; height: 100%; }
        .pg1_5 { position: absolute; bottom: 0; width: 100%; height: auto !important; }
        .sec6 { position: absolute; width: 100%; height: 100%; top: 0; left: 0; background-color: rgba(0,0,0,.6); z-index: 3; display: none; }
        .sec6 img { width: 100%; height: 100%; }
    </style>
    <script>
        if (navigator.userAgent.toLowerCase().match(/MicroMessenger/i) != 'micromessenger') {
            //window.location.href="/index.html";
        }
    </script>
    <style>
        
    </style>
</head>
<body>
    <div class="spinner">
        <div class="rect1">
        </div>
        <div class="rect2">
        </div>
        <div class="rect3">
        </div>
        <div class="rect4">
        </div>
        <div class="rect5">
        </div>
    </div>
    <header class="app-header" style="display: none;">
        <a href="javascript:void(0);" class="u-globalAudio z-play">
            <audio loop="" src="" id="ttnb" autoplay="" preload type="audio/mpeg">
            </audio>
        </a>
        
    </header>
    <div class="main">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide">
                    <img class="divBg" src="img/1.jpg" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.3s" src="img/1.1.png" width="100%" />
                    <img class="pg1_2 ani" swiper-animate-effect="fadeIn" swiper-animate-duration="0.5s"
                        swiper-animate-delay="0.6s" src="img/1.2.png" width="100%" />
                    <img class="pg1_3 ani" swiper-animate-effect="zoomIn" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.9s" src="img/1.3.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeIn" swiper-animate-duration="0.3s"
                        swiper-animate-delay="1.2s" src="img/1.4.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeIn" swiper-animate-duration="0.3s"
                        swiper-animate-delay="1.5s" src="img/1.5.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeIn" swiper-animate-duration="0.3s"
                        swiper-animate-delay="1.8s" src="img/1.6.png" width="100%" />
                    <img class="arrows-up ani infinite" swiper-animate-effect="arrowsSlide" swiper-animate-duration="1s"
                        swiper-animate-delay="s" src="/Tepay/img/arrow-up.png" style="width: 40px!important;
                        height: 30px!important;" />
                </div>
                <div class="swiper-slide">
                    <img class="divBg" src="img/2.jpg" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="1s"
                        swiper-animate-delay="0.6s" src="img/2.1.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomIn" swiper-animate-duration="1s"
                        swiper-animate-delay="0.9s" src="img/2.2.png" width="100%" />
                    <img class="arrows-up ani infinite" swiper-animate-effect="arrowsSlide" swiper-animate-duration="1s"
                        swiper-animate-delay="s" src="/Tepay/img/arrow-up.png" style="width: 40px!important;
                        height: 30px!important;" />
                </div>
                <div class="swiper-slide">
                    <img class="divBg" src="img/3.jpg" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.3s" src="img/3.1.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeIn" swiper-animate-duration="0.6s"
                        swiper-animate-delay="0.9s" src="img/3.2.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeIn" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.2s" src="img/3.3.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomIn" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.5s" src="img/3.4.png" width="100%" />
                    <img class="pg1_5 ani" swiper-animate-effect="fadeInUp" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.7s" src="img/3.5.png" width="100%" />
                </div>
            </div>
        </div>
    </div>
    <div class="sec6">
        <div>
            <img class="img1" /></div>
    </div>
    <input type="hidden" id="jg" value="12" />
    <input type="hidden" id="hid1" value="<%=wxopid %>" />
    <script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/loader.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/dialog.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/overlay.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/pc-prompt.min.js"></script>
    <script src="http://hyrz.qq.com/cp/a20150717test/scripts/landscape.min.js"></script>
    <script src="/Tepay/js/swiper-3.2.5.min.js" type="text/javascript"></script>
    <script src="/Tepay/js/swiper.animate1.0.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/yshb/img/fxs.jpg";
        dataForWeixin.url = "http://wsjhb.tencenthouse.com/yshb/ysyj.aspx";
        dataForWeixin.desc = "燕山一號老业主感恩回馈";
        dataForWeixin.title = "燕山一號老业主感恩回馈";
        dataForWeixin.isWXShare = false;
        var vh = $(window).height();
        var vw = $(window).width();
        var landscape_shine = new landscape({});
        window.PCPrompt = new mo.PCPrompt();
        $(".box1_info").css("width", vw);
        $(".divBg,.swiper-container,.sec2,.box1_1,.box1_2").css({ "height": vh, width: vw });
        var sourceArr = ['img/1.jpg', 'img/2.jpg', 'img/3.jpg', 'img/1.1.png', 'img/1.2.png', 'img/1.3.png', 'img/1.4.png', 'img/1.5.png', 'img/1.6.png', 'img/2.1.png', 'img/2.2.png', 'img/3.1.png', 'img/3.2.png', 'img/3.3.png', 'img/3.4.png', 'img/3.5.png']; //需要加载的资源列表
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                //alert('加载中...（'+count/total*100+'%）');
            },
            onComplete: function (time) {
                $(".spinner").fadeOut(100);
                $(".main").fadeIn(100);
                $(".swiper-container,.divBg,.ani").css({ "height": vh, width: vw });
                var mySwiper = new Swiper('.swiper-container', {
                    direction: 'vertical',
                    // pagination: '.swiper-pagination',
                    onInit: function (swiper) {
                        swiperAnimateCache(swiper);
                        swiperAnimate(swiper);
                    },
                    onSlideChangeEnd: function (swiper) {
                        swiperAnimate(swiper);
                    }
                });
                $(".sec6").on("touchend", function (e) {
                    e.preventDefault();
                    $(".sec6").hide();
                });
                $(".pg1_5").on("touchend", function (e) {
                    e.preventDefault();
                    setTimeout(function () {
                        if ("<%=isexit %>" == "0" || "<%=iscj %>" == "0") {
                            dialog("活动时间未到,请活动开始后进行操作", "error");
                            return false;
                        } else {
                            if ("<%=jpnum %>" == "1") {
                                window.overlay1 = new mo.Overlay({
                                    content: '红包领取中',
                                    valign: 'top'
                                });
                                $.ajax({
                                    type: 'POST',
                                    url: "helper.ashx",
                                    data: { type: 'fhb', tid: $("#hid1").val(), sjd: "<%=ids %>" },
                                    dataType: "json",
                                    success: function (data) {
                                        overlay1.close();
                                        if (data.count == 200) {

                                            $(".img1").attr("src", "img/j" + parseInt(data.code) / 100 + ".png");
                                            $(".sec6").show();
                                        } else if (data.count == 3) {
                                            dialog("你已经领取过红包了不能重复领取！", "alert");
                                        } else {
                                            dialog(data.code, "alert")
                                        }
                                    }
                                });
                            } else {
                                dialog("当前红包已领完，请明天继续", "alert");
                                return false;
                            }
                        }
                    }, 0);
                });
            }
        });
        function dialog(cont, type) {
            window.dia1 = new mo.Dialog({
                content: cont,
                type: type
            });
        }
    </script>
</body>
</html>
