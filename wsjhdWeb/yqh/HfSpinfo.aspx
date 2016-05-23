<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HfSpinfo.aspx.cs" Inherits="NewInfoWeb.yqh.HfSpinfo" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>认筹先行，红包添喜</title>
    <meta name="description" content="投资前景" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=640, user-scalable=no" />
    <link href="image/loading.css" rel="stylesheet" type="text/css" />
    <link href="/yqh/js/layer.css" rel="stylesheet" type="text/css" />
    <script>
        if (navigator.userAgent.toLowerCase().match(/MicroMessenger/i) != 'micromessenger') {
            //window.location.href="/index.html";
        }
    </script>
    <style>
          html,body{background:rgb(0,0,0);}
         .full img{position: absolute;  width:100%; height:100%;}
         @-webkit-keyframes anima2{0%{opacity:.4}100%{opacity:1;}}
         @-webkit-keyframes anima1{0%{-webkit-transform:  translate3d(20%, 0, 0); opacity:0;}100%{-webkit-transform:  translate3d(0, 0, 0); opacity:1;}}
        @-webkit-keyframes  btninfo{0%{ opacity:.4;}100%{opacity:1;}}
        @-webkit-keyframes  btnleft{0%{ -webkit-transform:  translate3d(10%, 0, 0);}100%{-webkit-transform:  translate3d(-10%, 0, 0);}}
        @-webkit-keyframes  btnto{0%{ -webkit-transform:  translate3d(0, 4%, 0);}100%{-webkit-transform:  translate3d(0, 0, 0);}}
        @-webkit-keyframes  movebutton1 {0%{ -webkit-transform:  translate3d(0, 75%, 0);opacity:0;}100%{opacity:1;-webkit-transform:  translate3d(0, 0, 0);}}
       @-webkit-keyframes show2{0%{opacity:0;z-index:-5;}100%{opacity:1; z-index:50;}}
        @-webkit-keyframes ccgd {0% {-webkit-transform-origin:top right;-webkit-transform: rotate(0deg) skew(0deg);}100% { -webkit-transform-origin:top right;-webkit-transform: rotate(20deg) skew(10deg);}}
        @-webkit-keyframes ccgd1 {0% {-webkit-transform-origin:left bottom;-webkit-transform: rotate(0deg) skew(0deg);}100% { -webkit-transform-origin:left bottom;-webkit-transform: rotate(20deg) skew(10deg);}} 
        
        @-webkit-keyframes rotateIn{ 0% {-webkit-transform-origin: center;-webkit-transform: rotate3d(0, 0, 1, -200deg);}100% {-webkit-transform-origin: center; }}
        @-webkit-keyframes rotateIn1{ 0% {opacity:1;-webkit-transform-origin: center;-webkit-transform: rotate3d(0, 0, 1, -200deg);}100% {-webkit-transform-origin: center;opacity:1; }}
        @-webkit-keyframes bounceInDown1 {
  0%, 60%, 75%, 90%, 100% {
    -webkit-transition-timing-function: cubic-bezier(0.215, 0.610, 0.355, 1.000);
    transition-timing-function: cubic-bezier(0.215, 0.610, 0.355, 1.000);
  }
0% {opacity: 0;-webkit-transform: translate3d(0, -200px, 0);}
20%,30%, 50%, 70%, 90% {opacity:1;-webkit-transform: translate3d(0px, 0px, 0);}
40%,60%, 80% {opacity:1;-webkit-transform: translate3d(0px, -50px, 0);}
100% {opacity:1;-webkit-transform: translate3d(0, 0, 0);}}
@-webkit-keyframes zoomInUp {
  from {
    opacity: 0;
    -webkit-transform: scale3d(.1, .1, .1) translate3d(0, 1000px, 0);
    transform: scale3d(.1, .1, .1) translate3d(0, 1000px, 0);
    -webkit-animation-timing-function: cubic-bezier(0.550, 0.055, 0.675, 0.190);
    animation-timing-function: cubic-bezier(0.550, 0.055, 0.675, 0.190);
  }

  60% {
    opacity: 1;
    -webkit-transform: scale3d(.475, .475, .475) translate3d(0, -60px, 0);
    transform: scale3d(.475, .475, .475) translate3d(0, -60px, 0);
    -webkit-animation-timing-function: cubic-bezier(0.175, 0.885, 0.320, 1);animation-timing-function: cubic-bezier(0.175, 0.885, 0.320, 1);}100%{opacity:1;}}

        .ccgd1{-webkit-animation: ccgd1 2s linear  alternate  infinite both;}
        .ccgd{-webkit-animation: ccgd 2s linear  alternate  infinite both;}
       
        .start{position: fixed;left: 50%;margin-left: -17px;bottom: 2%;margin-top: -34px;width: 34px;height: 34px;}
        .wp-inner div{ width:100%; background-size:100% 100%;}
        .page div{opacity:0;position:absolute; height:100%;}
        .sec1{background:url(img2/1.jpg); background-size:100% 100%; width:100%; height:100%;}
        .sec2{background:url(img2/bg.png); background-size:100% 100%; width:100%; height:100%;display:none;position: absolute;top: 0;z-index: 100; }
        
        .sec3{background:url(img2/2.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        .sec4{background:url(img2/3.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        .sec5{background:url(img2/bg.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        .sec6{background:url(img2/bg.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        .sec7{background:url(img2/fx.png); background-size:100% 100%; width:100%; height:100%;display:none; position:absolute; z-index:100; top:0;}
        
        .i1{opacity:0; width: 100%;height: 100%; position:absolute; background:url(img1/1.1.png); background-size:100% 100%; z-index:1;-webkit-animation: show1 1s  .5s linear  alternate  infinite both;}
        .i2{opacity:0;width:100%; height:100%;position:absolute; background:url(img1/1.2.png); background-size:100% 100%;-webkit-animation: movetop 1s linear 1.5s forwards;}
        .i3{opacity:0;width:100%; height:100%;position:absolute; background:url(img1/1.3.png); background-size:100% 100%;-webkit-animation: show1 1.5s  2s linear     forwards;}
        .x1{opacity:0;width:100%; height:100%;position:absolute; background:url(img2/1.5.png); background-size:100% 100%;-webkit-animation: show1 1.5s  .5s linear infinite  forwards;}
        .x2{opacity:0;width:100%; height:100%;position:absolute; background:url(img2/1.5.png); background-size:100% 100%;-webkit-animation:zoomInUp 1s 1s both;}
        .x3{opacity:0;width:100%; height:100%;position:absolute; background:url(img2/1.2.png); background-size:100% 100%;-webkit-animation:zoomInUp 1s 1.5s forwards;}
        .x4{opacity:0;width:100%; height:100%;position:absolute; background:url(img2/1.3.png); background-size:100% 100%;-webkit-animation:zoomInUp 1s 2s forwards;}
        
        .x5{opacity:0;width:100%; height:100%;position:absolute; background:url(img2/1.4.png); background-size:100% 100%;-webkit-animation:zoomInUp 1s 2.5s forwards; z-index:1;}
        .x6{opacity:0;width:100%; height:100%;position:absolute; background:url(img1/x6.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 6s forwards;}
        .x7{opacity:0;width:100%; height:100%;position:absolute; background:url(img1/x7.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 7s forwards;}
        .x8{opacity:0;width:100%; height:100%;position:absolute; background:url(img1/x8.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 8s forwards;}
        .x9{opacity:0;width:100%; height:100%;position:absolute; background:url(img1/x9.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 9s forwards;}
        .x10{opacity:0;width:100%; height:100%;position:absolute; background:url(img1/x10.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 10s forwards;}
        .x11{opacity:0;width:100%; height:100%;position:absolute; background:url(img1/x10.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 11s forwards;}
        .i4,.i5,.i6, .i8,.i9,.i10,.i11,.i7{ opacity:0;}
        
        .i4{width:100%; height:100%;position:absolute; background:url(img1/1.4.png); background-size:100% 100%; -webkit-animation: show1 1.5s  2.5s linear  alternate  infinite both;}
        .it5{opacity:0; width:100%; height:100%;position:absolute; background:url(img1/gzbg.png); background-size:100% 100%; -webkit-animation: bounceInDown1 2s  .5s linear  forwards;}
        .it6{opacity:0;width:100%; height:100%;position:absolute; background:url(img2/gz.png); background-size:100% 100%; -webkit-animation: show1 1s .5s linear  forwards;}
         .not{ z-index:10; margin-left:41px; width:569px; height:162px; position:absolute; background:url(img2/not.png);background-size:100% 100%;-webkit-animation: show1 1s  3s linear both; bottom:14%; border:0px;}
         .yes{z-index:10; margin-left:41px; width:569px; height:162px; position:absolute; background:url(img2/yes.png);background-size:100% 100%;-webkit-animation: show1 1s  3s linear both;bottom:30%; border:0px;}
         
         .it7{opacity:0; width:100%; height:100%;position:absolute; background:url(img/2.1.png); background-size:100% 100%; -webkit-animation: movetop 1s  .5s linear  forwards;}
         .it8{opacity:0;width:100%; height:100%;position:absolute; background:url(img/2.2.png); background-size:100% 100%; -webkit-animation: show1 1s 1.5s linear  forwards;}
         .it9{opacity:0;width:100%; height:100%;position:absolute; background:url(img/2.3.png); background-size:100% 100%; -webkit-animation: bounceleft 1s 1.5s linear  forwards; z-index:10;}
         .it10{opacity:0;width:100%; height:100%;position:absolute; background:url(img/2.4.png); background-size:100% 100%; -webkit-animation: show1 1.5s 1.5s linear   infinite forwards;}
         .it11{opacity:0;width:100%; height:100%;position:absolute; background:url(img/2.5.png); background-size:100% 100%; -webkit-animation: show1 1.5s 1.5s linear   infinite forwards;}
         .it12{opacity:0; border:0; margin-left:177px; width:295px; height:96px; position:absolute; background:url(img2/btnsure.png); background-size:100% 100%; -webkit-animation: show1 1.5s 1.5s linear forwards;z-index:15;bottom: 11%;}
         
         .id5{opacity:0; width:100%; height:100%;position:absolute; background:url(img2/5.1.png); background-size:100% 100%; -webkit-animation: bounceInDown1 2s  .5s linear  forwards;}
                 
        .id6{opacity:0; width:100%; height:100%;position:absolute; background:url(img2/6.1.png); background-size:100% 100%; -webkit-animation: bounceInDown1 2s  .5s linear  forwards;}                 
         ::-webkit-input-placeholder{ color:#e73357;}
         input{ width:431px; height:80px; line-height:80px; position:absolute; background-color:white; color:#e73357; font-size:2.5em; margin-left:70px; font-weight:bold; padding-left:57px;border:1px solid #6a3906; border-radius:22px;}
         .tname{}
         .tphone{}
         .btnsure{ border:0; margin-left:177px; width:295px; height:96px; position:absolute; background:url(img2/btnsure.png); background-size:100% 100%;z-index:15;}
          
         .zd{opacity:0; border:0; margin-left:118px; width:417px; height:130px; position:absolute; background:url(img1/zd.png); background-size:100% 100%; -webkit-animation: show1 1s 2.5s linear forwards;z-index:15; bottom:32%;}
         .fx{opacity:0; border:0; margin-left:118px; width:418px; height:116px; position:absolute; background:url(img1/fx1.png); background-size:100% 100%; -webkit-animation: show1 1s 2.5s linear forwards;z-index:15; bottom:31%;}             
        .cl1,.cl2,.cl3,.cl4,.cl5,.cl6{bottom: 6.5%; width:97px; height:93px; position:absolute;}
        .cl7,.cl8,.cl9{bottom: 18.5%; width:97px; height:93px; position:absolute;}
        .cl10,.cl11,.cl12{bottom: 12.5%; width:97px; height:93px; position:absolute;}
        .cl13,.cl14,.cl15{bottom: 32.5%; width:97px; height:93px; position:absolute;}        
        .cl1,.cl4,.cl7,.cl10,.cl13{margin-left: 148px;}
        .cl2,.cl5,.cl8,.cl11,.cl14{margin-left: 266px;}
        .cl3,.cl6,.cl9,.cl12,.cl15{margin-left: 394px;}
        /**
          margin-left:178px;
          margin-left:303px;
          margin-left:427px
        **/
        .layermbox0 .layermchild{ max-width:400px; min-width:400px;}
        .layermchild{ font-size:30px;}
        .layermcont {padding: 52px 38px;font-weight:bold;}
        .layermbtn{ height:72px; line-height:72px;}
        .layermbtn span:first-child{ height:72px;}
        .layermbtn span{ font-size:30px; font-weight:bold;}
        .loading-container{background-size: cover;}
	
        .u-globalAudio .icon-music{ width:50px; height:50px;}
        .start b{width: 39px;height: 32px;}
	.layermcont{ line-height:45px;}
	.flake{ top:0; left:0; position:absolute;}
ul,ol,dl{list-style:none;}
.loader-box{position: absolute;left: 50%;top: 50%;width: 100px;height: 100px;margin-left: -50px;margin-top: -50px;}
.loader-box li{float: left;width: 30px;height: 30px;margin: 1px;background-color: #f00;}
.loader-box li:nth-child(1){background-color: #b2db11;border-top-left-radius: 5px;}
.loader-box li:nth-child(2){background-color: #ffff00;}
.loader-box li:nth-child(3){background-color: #ff0000;border-top-right-radius: 5px;}
.loader-box li:nth-child(4){background-color: #66b821;}
.loader-box li:nth-child(5){background-color: #ffb200;}
.loader-box li:nth-child(6){background-color: #f0027f;}
.loader-box li:nth-child(7){background-color: #008837;border-bottom-left-radius: 5px;}
.loader-box li:nth-child(8){background-color: #ff6600;}
.loader-box li:nth-child(9){background-color: #81017e;border-bottom-right-radius: 5px;}
    </style>
</head>
<body>
    <div class="loading-container">
        <ul class="loader-box">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
    </div>
    <header class="app-header">
        <a href="javascript:void(0);" class="u-globalAudio z-play">
            <audio loop="" src="" id="ttnb" autoplay="" preload type="audio/mpeg">
            </audio>
        </a>
    </header>
    <section class="sec1" style="display: none;">
        <div class="x2">
        </div>
        <div class="x3">
        </div>
        <div class="x4">
        </div>
        <div class="x5">
        </div>
        <button class="not" id="tt1">
        </button>
        <button class="yes">
        </button>
    </section>
    <section class="sec2">
        <div class="i5">
        </div>
        <div class="i6" id="i6">
        </div>
    </section>
    <div class="sec3">
        <div class="i7">
        </div>
        <div class="i8">
        </div>
        <div class="i9" id="tt2">
        </div>
        <div class="i10">
        </div>
        <div class="i11">
        </div>
        <button class="i12">
        </button>
    </div>
    <div class="sec4">
        <input placeholder="姓名" class="tname" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
            onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" oncontextmenu="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" />
        <input placeholder="手机" type="tel" class="tphone" maxlength="11" onkeypress='return /^\d$/.test(String.fromCharCode(event.keyCode))'
            oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace(/\D+/g, "")'
            onblur='this.value = this.value.replace(/\D+/g, "")' />
        <button class="btnsure" id="tt3">
        </button>
    </div>
    <div class="sec5">
        <div class="id5" id="fx">
        </div>
        <%-- <button class="fx" id="fx">
        </button>--%>
    </div>
    <div class="sec6">
        <div class="id6" id="zd">
        </div>
        <%--<button class="zd" id="zd">
        </button>--%>
    </div>
    <div class="sec7">
    </div>
    <div style="position: fixed; width: 100%; height: 100%; left: 0px; top: 0px; -webkit-transition: opacity 0.3s linear;
        transition: opacity 0.3s linear; opacity: 1; z-index: 999; background-color: rgba(0, 0, 0, 0.498039);
        display: none" id="shareTips">
        <div style="display: block; width: 74px; height: 102px; overflow: hidden; position: absolute;
            right: 10px; top: 10px; background: url(img/1.png) 0px 0px / 100% 100% no-repeat;">
        </div>
        <h3 style="padding: 0px; position: absolute; width: 100%; height: auto; text-align: center;
            top: 50%; margin: -60px 0px 0px; font-size: 40px; line-height: 75px; color: #bba251;
            font-weight: bold;">
            点击右上角<br />
            分享好友/朋友圈<br />
        </h3>
    </div>
    <script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/loader.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/landscape.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/animation.min.js"></script>
    <script src="/yqh/js/layer.m.js" type="text/javascript"></script>
    <script src="/yqh/js/jquery.let_it_snow.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        dataForWeixin.title = "认筹先行，红包添喜";
        dataForWeixin.desc = "认筹先行，红包添喜";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/yqh/img2/fxs.jpg";
        //        dataForWeixin.async = true;
        //        dataForWeixin.url = "http://mp.weixin.qq.com/s?__biz=MzI4OTA0ODI0Mw==&mid=400372808&idx=1&sn=1c7f27f57c348ad970d4687d4dc24169&scene=1&srcid=11124hMg1n9z0p2gGOKGdoBi&from=singlemessage&isappinstalled=0#wechat_redirect";
        var count = 0;
        var vh = $(window).height();
        var vw = $(window).width();
        var Landscape = new mo.Landscape({});

        $("html,body").css({ "width": vw, "height": vh });
        var sourceArr = ['img1/4.mp3', 'img2/1.jpg', 'img2/1.2.png', 'img2/1.5.png', 'img2/1.3.png', 'img2/1.4.png', 'img2/3.jpg', 'img2/btnsure.png', 'img2/fx.png', 'img2/gz.png', 'img2/not.png', 'img2/yes.png', 'img2/5.1.png', 'img2/6.1.png']; //需要加载的资源列表
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                //alert('加载中...（'+count/total*100+'%）');
                $(window).on('touchmove', function (e) {
                    //e.preventDefault();
                });
                var boxes = $('.loader-box li');
                boxes.each(function (i, elem) {
                    var delay = parseInt(i / 3) + i % 3;
                    new mo.Animation({
                        target: $(elem),
                        delay: delay * 200,
                        iteration: 'infinite',
                        keyframes: {
                            50: { opacity: 0, 'transform': 'scale(0.2,0.2)' }
                        }
                    });

                });
            },
            onComplete: function (time) {
                //alert("<%=wxopid%>")
                var myVideo = document.getElementById("ttnb");
                LoadAud(myVideo, "img1/4.mp3");
                //return false;
                $(".loading-container").fadeOut(200);
                document.addEventListener('WeixinJSBridgeReady', function () {
                    myVideo.play();
                });
                $(".sec1,.sec2,.sec3,.sec4,.sec5,.sec6,.sec7,.flake").css({ width: vw, height: vh });

                $(".sec1").fadeIn("200");
                //                $(".i5").addClass("it5");
                //                $(".i6").addClass("it6");

                $(".tname").css("top", vh * 460 / 1050);
                $(".tphone").css("top", vh * 570 / 1050);
                $(".btnsure").css("top", vh * 680 / 1050);
                document.getElementById("tt1").addEventListener("webkitAnimationEnd", function () { //动画结束时事件 
                    //不领取红包
                    $(".not").on("click", function () {
                        $(".sec2").fadeIn(200);
                        $(".i5").addClass("it5");
                        $(".i6").addClass("it6");
                    });
                    //领取红包
                    $(".yes").on("click", function () {
                        //showDialog("红包将在中午12点准时开抢，敬请期待！");
                        //return false;
                        if ("<%=isexit %>" == "1") {
                            $(".sec1").fadeOut();
                            $(".sec5").fadeIn(200);
                        } else {
                            $(".sec1").fadeOut();
                            $(".sec4").fadeIn(200);
                        }

                    });
                }, false);

                document.getElementById("i6").addEventListener("webkitAnimationEnd", function () { //动画结束时事件 
                    $(".sec2").on("click", function () {
                        $(".sec2").fadeOut(200);
                    });
                }, false);
                document.getElementById("tt2").addEventListener("webkitAnimationEnd", function () { //动画结束时事件 
                    $(".i12").on("click", function () {
                        if ("<%=isexit %>" == "1") {
                            $(".sec3").fadeOut();
                            $(".sec5").fadeIn(200);
                        } else {
                            $(".sec3").fadeOut();
                            $(".sec4").fadeIn(200);
                        }

                    });
                }, false);
                document.getElementById("zd").addEventListener("webkitAnimationEnd", function () { //动画结束时事件 
                    $("#zd").on("click", function () {
                        //$(".sec6").fadeOut();
                        $(".sec7").fadeIn(200);
                    });
                }, false);
                $(".sec7").on("click", function () {
                    $(".sec7").fadeOut();
                });
                document.getElementById("fx").addEventListener("webkitAnimationEnd", function () { //动画结束时事件 
                    $("#fx").on("click", function () {
                        // $(".sec5").fadeOut();
                        $(".sec7").fadeIn(200);
                    });
                }, false);

                $(".btnsure").on("click", function () {
                    //                    $(".sec4").fadeOut();
                    //                    $(".sec5").fadeIn(200);
                    //                    return false;
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
                    var int = layer.open({
                        content: '红包发送中...请稍等！',
                        style: 'background-color:#fff; color:black; border:none;'

                    });
                    $.ajax({
                        type: 'post',
                        url: '/yqh/helper2.ashx?type=AddInfo',
                        dataType: 'json',
                        data: {
                            tname: name, tphone: phone
                        },
                        success: function (data) {
                            layer.close(int);
                            alert(data.code);
                            if (data.count == 200) {
                                //领取成功
                                $(".sec4").fadeOut();
                                $(".sec5").fadeIn(200);
                            } else if (data.count == 3) {
                                showDialog1("你已经领取过红包了不能重复领取！");
                            } else {
                                $(".sec4").fadeOut();
                                $(".sec6").fadeIn(200);
                            }
                        },
                        error: function (xhr, type, error) {
                            alert(error)
                        }
                    });
                    $(".btnsure").removeAttr("disabled");
                });

                myVideo.play();
                $audio = $("audio");
                if ($audio.length > 0) {
                    $(".u-globalAudio").addClass("play_yinfu");
                    $audio.parent("a").prepend(' <i class="icon-music"></i>');
                }
                $(".u-globalAudio").tap(function () {
                    $(this).toggleClass("z-play");
                    if ($(this).hasClass("z-play")) {
                        $(this).addClass("play_yinfu");
                        myVideo.play();
                    } else {
                        $(this).removeClass("play_yinfu");
                        myVideo.pause();
                    }
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
            }
        }
        function showTips() {
            layer.open({
                content: '红包发送中...请稍等！',
                style: 'background-color:#fff; color:black; border:none;',
                time: 3
            });
        }
        function showDialog(cont) {
            layer.open({
                content: cont,
                btn: ['确定']
            });
        }
        function showDialog1(cont) {
            layer.open({
                content: cont,
                btn: ['确定'],
                yes: function (index) {
                    layer.close(index);
                    $(".sec4").fadeOut();
                    $(".sec5").fadeIn(200);
                }
            });
        }
    </script>
</body>
</html>
