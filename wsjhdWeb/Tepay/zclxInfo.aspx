<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zclxInfo.aspx.cs" Inherits="NewInfoWeb.Tepay.zclxInfo" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>联想科技城-众筹</title>
    <meta name="description" content="联想科技城-众筹" />
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
    <link href="css/swiper-3.2.5.min.css" rel="stylesheet" type="text/css" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <link href="css/loading.css" rel="stylesheet" type="text/css" />
    <link href="css/index.css" rel="stylesheet" type="text/css" />
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
                        swiper-animate-delay="0.3s" src="img/1.2.png" width="100%" />
                    <img class="pg1_2 ani" swiper-animate-effect="bounceInRight" swiper-animate-duration="0.5s"
                        swiper-animate-delay="0.6s" src="img/1.3.png" width="100%" />
                    <img class="pg1_3 ani" swiper-animate-effect="zoomIn" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.9s" src="img/1.4.png" width="100%" />
                    <img class="arrows-up ani infinite" swiper-animate-effect="arrowsSlide" swiper-animate-duration="1s"
                        swiper-animate-delay="s" src="img/arrow-up.png" style="width: 40px!important;
                        height: 30px!important;" />
                </div>
                <div class="swiper-slide">
                    <img class="divBg" src="img/2.jpg" />
                    <img class="pg2_1 ani" swiper-animate-effect="zoomIn" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.3s" src="img/2.1.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.6s" src="img/2.2.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="bounceInUp" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.9s" src="img/2.11.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.1s" src="img/2.9.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.4s" src="img/2.3.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="bounceInRight" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.8s" src="img/2.4.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.6s"
                        swiper-animate-delay="2.2s" src="img/2.5.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.6s"
                        swiper-animate-delay="2.4s" src="img/2.6.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.6s"
                        swiper-animate-delay="2.6s" src="img/2.7.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.6s"
                        swiper-animate-delay="2.8s" src="img/2.8.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="slideInUp" swiper-animate-duration="0.6s"
                        swiper-animate-delay="3s" src="img/2.10.png" width="100%" />
                    <img class="arrows-up ani infinite" swiper-animate-effect="arrowsSlide" swiper-animate-duration="1s"
                        swiper-animate-delay="s" src="img/arrow-up.png" style="width: 40px!important;
                        height: 30px!important;" />
                </div>
                <div class="swiper-slide">
                    <img class="divBg" src="img/3.jpg" />
                    <img class="pg2_1 ani" swiper-animate-effect="zoomIn" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.3s" src="img/3.11.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.6s" src="img/2.2.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="0.6s"
                        swiper-animate-delay="0.9s" src="img/3.2.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.2s" src="img/3.3.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomIn" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.5s" src="img/3.4.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="slideInDown" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.7s" src="img/3.5.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="bounceInLeft" swiper-animate-duration="0.6s"
                        swiper-animate-delay="1.9s" src="img/3.6.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="bounceInRight" swiper-animate-duration="0.6s"
                        swiper-animate-delay="2.1s" src="img/3.8.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="tada1" swiper-animate-duration="0.6s"
                        swiper-animate-delay="2.3s" src="img/3.10.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="slideInUp" swiper-animate-duration="0.6s"
                        swiper-animate-delay="2.4s" src="img/3.9.png" width="100%" />
                    <img class="arrows-up ani infinite" swiper-animate-effect="arrowsSlide" swiper-animate-duration="1s"
                        swiper-animate-delay="s" src="img/arrow-up.png" style="width: 40px!important;
                        height: 30px!important;" />
                </div>
                <div class="swiper-slide">
                    <img class="divBg" src="img/4.jpg" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.3s" src="img/4.1.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.5s"
                        swiper-animate-delay="0.6s" src="img/4.2.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.5s"
                        swiper-animate-delay="0.9s" src="img/4.3.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="slideInUp" swiper-animate-duration="0.5s"
                        swiper-animate-delay="1.2s" src="img/4.4.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomInDown" swiper-animate-duration="0.5s"
                        swiper-animate-delay="1.5s" src="img/4.5.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomInUp" swiper-animate-duration="0.5s"
                        swiper-animate-delay="1.8s" src="img/4.6.png" width="100%" />
                    <img class="arrows-up ani infinite" swiper-animate-effect="arrowsSlide" swiper-animate-duration="1s"
                        swiper-animate-delay="s" src="img/arrow-up.png" style="width: 40px!important;
                        height: 30px!important;" />
                </div>
                <div class="swiper-slide">
                    <img class="divBg" src="img/5.jpg" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.3s" src="img/5.1.png" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomInDown" swiper-animate-duration="0.5s"
                        swiper-animate-delay="0.7s" src="img/5.2.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomInUp" swiper-animate-duration="0.5s"
                        swiper-animate-delay="1s" src="img/5.3.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="rollIn" swiper-animate-duration="0.5s"
                        swiper-animate-delay="1.4s" src="img/5.4.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInUpBig" swiper-animate-duration="0.5s"
                        swiper-animate-delay="1.7s" src="img/5.5.png" width="100%" />
                    <img class="arrows-up ani infinite" swiper-animate-effect="arrowsSlide" swiper-animate-duration="1s"
                        swiper-animate-delay="s" src="img/arrow-up.png" style="width: 40px!important;
                        height: 30px!important;" />
                </div>
                <div class="swiper-slide">
                    <img class="divBg" src="img/6.jpg" />
                    <img class="pg1_1 ani" swiper-animate-effect="fadeInDown" swiper-animate-duration="0.3s"
                        swiper-animate-delay="0.3s" src="img/5.1.png" />
                    <img class="pg1_1 ani" swiper-animate-effect="show1" swiper-animate-duration="0.5s"
                        swiper-animate-delay="0.6s" src="img/6.2.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomIn" swiper-animate-duration="0.5s"
                        swiper-animate-delay="1s" src="img/6.3.png" width="100%" />
                    <img class="pg1_1 ani" swiper-animate-effect="zoomInUp" swiper-animate-duration="1s"
                        swiper-animate-delay="1.3s" src="img/6.4.png" width="100%" />
                    <button class="gz ani" swiper-animate-effect="fadeInUp" swiper-animate-duration="1s"
                        swiper-animate-delay="1.6s">
                    </button>
                    <button class="cj ani" swiper-animate-effect="fadeInUp" swiper-animate-duration="1s"
                        swiper-animate-delay="1.7s">
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="box1">
        <div class="box1_1">
            <div class="box1_2">
                <div class="box1_info">
                    <img src="img/close.png" class="closeinfo" style="right: 57px; float: right; margin-top: 5px;
                        margin-right: 5%;" />
                    <div style="clear: both;">
                    </div>
                    <div style="width: 90%; margin-left: 5%; height: 279px; background-color: #f8b72c;
                        border-radius: 8%; background-size: 100% 100%; text-align: center;">
                        <img src="img/topline.png" style="width: 100%;" />
                        <table>
                            <tr>
                                <td>
                                    姓名
                                </td>
                                <td>
                                    <input class="tname" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
                                        onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" oncontextmenu="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    电话
                                </td>
                                <td>
                                    <input type="tel" class="tphone" maxlength="11" onkeypress='return /^\d$/.test(String.fromCharCode(event.keyCode))'
                                        oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace(/\D+/g, "")'
                                        onblur='this.value = this.value.replace(/\D+/g, "")' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    份额
                                </td>
                                <td>
                                    <button class="jian">
                                    </button>
                                    <input type="tel" readonly class="tfnum" value="1" onkeypress='return /^\d$/.test(String.fromCharCode(event.keyCode))'
                                        oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace(/\D+/g, "")'
                                        onblur='this.value = this.value.replace(/\D+/g, "")' />
                                    <button class="jia">
                                    </button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    总金额
                                </td>
                                <td>
                                    <input value="12.00" type="text" readonly style="text-align: center;" class="total" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <button class="btnsure">
                                        提交支付</button>
                                </td>
                            </tr>
                        </table>
                        <img src="img/botline.png" style="width: 100%;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="sec2">
        <img src="img/gz.png" style="position: absolute;" />
        <button class="btnreturn">
        </button>
    </div>
    <input type="hidden" id="jg" value="12" />
    <script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/loader.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/dialog.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/overlay.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/landscape.min.js"></script>
    <script src="js/swiper-3.2.5.min.js" type="text/javascript"></script>
    <script src="js/swiper.animate1.0.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/Tepay/img/fxs.jpg";
        dataForWeixin.url = "http://wsjhb.tencenthouse.com/Tepay/zclxInfo.aspx";
        dataForWeixin.desc = "众筹通道";
        dataForWeixin.title = "众筹通道";
        var vh = $(window).height();
        var vw = $(window).width();
        var Landscape = new mo.Landscape({});
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
        $(".box1_info").css("width", vw);
        $(".divBg,.swiper-container,.sec2,.box1_1,.box1_2").css({ "height": vh, width: vw });
        var sourceArr = ['img/1.jpg', 'img/2.jpg', 'img/4.jpg', 'img/5.jpg', 'img/6.jpg', 'img/1.1.png', 'img/1.2.png', 'img/1.3.png', 'img/1.4.png', 'img/2.1.png', 'img/2.10.png', 'img/2.11.png', 'img/2.2.png', 'img/2.3.png', 'img/2.4.png', 'img/2.5.png', 'img/2.6.png', 'img/2.7.png', 'img/2.8.png', 'img/2.9.png', 'img/3.1.png', 'img/3.2.png', 'img/3.3.png', 'img/3.4.png', 'img/3.5.png', 'img/3.6.png', 'img/3.8.png', 'img/3.9.png', 'img/3.10.png', 'img/4.1.png', 'img/4.2.png', 'img/4.3.png', 'img/4.4.png', 'img/4.5.png', 'img/4.6.png', 'img/5.1.png', 'img/5.2.png', 'img/5.3.png', 'img/5.4.png', 'img/5.5.png', 'img/6.1.png', 'img/6.2.png', 'img/6.3.png', 'img/6.4.png', 'img/btncj.png', 'img/btngz.png', 'img/btnreturn.png', 'img/gz.png', 'img/topline.png', 'img/botline.png']; //需要加载的资源列表
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                //alert('加载中...（'+count/total*100+'%）');
            },
            onComplete: function (time) {
                $(".spinner").fadeOut(100);
                $(".main").fadeIn(100);
                $(".gz").on("touchend", function () {
                    mySwiper.lockSwipes();
                    $(".sec2").fadeIn(100);
                });
                $(".cj").on("touchend", function () {
                    mySwiper.lockSwipes();
                    $(".box1").fadeIn(100);
                });
                $(".closeinfo").on("touchend", function () {
                    $(".box1").fadeOut(100);
                    mySwiper.unlockSwipes();
                });
                $(".btnreturn").on("touchend", function () {
                    $(".sec2").fadeOut(100);
                    mySwiper.unlockSwipes();
                });



                $(".jian").on("touchend", function () {
                    var tmpnum = parseInt($(".tfnum").val());
                    if (tmpnum > 1) {
                        $(".tfnum").val(parseInt($(".tfnum").val()) - 1);
                        $(".total").val(parseInt($(".tfnum").val()) * 12 + ".00");
                        $("#jg").val(parseInt($(".tfnum").val()) * 12);
                    } else {
                        dialog("众筹金额至少需要购买一份！", "alert");
                    }
                });
                $(".jia").on("touchend", function () {
                    var tmpnum = parseInt($(".tfnum").val());

                    if (tmpnum >= 20) {
                        dialog("每人购买的众筹上限是20份", "alert");
                        return false;
                    } else {
                        $(".tfnum").val(parseInt($(".tfnum").val()) + 1);
                        $(".total").val(parseInt($(".tfnum").val()) * 12 + ".00");
                    }
                    $("#jg").val(parseInt($(".tfnum").val()) * 12);
                })
                $(".btnsure").on("click", function () {
                    tjinfo();
                });
            }
        });
        function tjinfo() {
            document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
                //alert($("#jg").val());
                var totalprice = parseInt($("#jg").val());
                var tnum = $(".tfnum").val();
                var name = $(".tname").val();
                var phone = $(".tphone").val();

                if (name == "" || name == null) {
                    dialog("请输入姓名信息", "alert");
                    return false;
                }
                if (phone == "" || phone == null) {
                    dialog("请输入手机号码信息", "alert");
                    return false;
                }
                var usernamereg = /^(13|15|18|17)[0-9]{9}$/;
                if (!usernamereg.test(phone)) {
                    dialog("请输入正确的手机号码", "alert");
                    return false;
                }
                $(".btnsure").attr("disabled", "disabled");
                //alert(totalprice+"|"+tnum);
                // return false;
                if ("<%=wxopid %>" == "" || "<%=wxopid %>" == null) {
                    window.location.href = "zclxInfo.aspx";
                } else {
                    window.overlay1 = new mo.Overlay({
                        content: '支付信息请求中...',
                        valign: 'top',
                        offset: [0, 10]
                    });
                    //首先通过ashx获取信息
                    $.ajax({
                        url: "payhelperinfo.ashx?type=AddInfo",
                        type: "post",
                        dataType: "json",
                        data: { "total": totalprice, "tnum": tnum, "name": name, "phone": phone },
                        success: function (result) {
                            if (result.count == 1) {
                                //alert(result);
                                overlay1.close();
                                $.each(result.result, function (i, n) {
                                    var ordid = n.orderid;
                                    //alert("进入支付:"+ordid+",tim:"+n.timeStamp+",non:"+n.nonceStr+",pack:"+n.package+",sign:"+n.paySign);
                                    wx.chooseWXPay({
                                        timestamp: n.timeStamp,
                                        nonceStr: n.nonceStr,
                                        package: n.package,
                                        signType: 'MD5',
                                        paySign: n.paySign,
                                        success: function (res) {
                                            //alert(res);
                                        }, error: function (st) {
                                            //alert(st);
                                        }
                                    });
                                    //alert(res);
                                    //                                    $(".btnsure").attr("disabled", "disabled");
                                    $(".btnsure").removeAttr("disabled");
                                });
                            } else {
                                dialog("服务器繁忙，请稍后重试！");
                                return false;
                            }
                        },
                        error: function () {
                            alert_t("服务器繁忙，请稍候再试！");
                        }
                    });
                }
            }, false);
        }

        function dialog(cont, type) {
            window.dia1 = new mo.Dialog({
                content: cont,
                type: type
            });
        }
    </script>
</body>
</html>
