<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hdinfo.aspx.cs" Inherits="NewInfoWeb.yqh.hdinfo" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>【有鬼@你】万圣节红包你敢拿吗</title>
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


        .ccgd1{-webkit-animation: ccgd1 2s linear  alternate  infinite both;}
        .ccgd{-webkit-animation: ccgd 2s linear  alternate  infinite both;}
       
        .start{position: fixed;left: 50%;margin-left: -17px;bottom: 2%;margin-top: -34px;width: 34px;height: 34px;}
        .wp-inner div{ width:100%; background-size:100% 100%;}
        .page div{opacity:0;position:absolute; height:100%;}
        .sec1{background:url(img/1.jpg); background-size:100% 100%; width:100%; height:100%;}
        .sec2{background:url(img/bg.jpg); background-size:100% 100%; width:100%; height:100%;display:none; }
        
        .sec3{background:url(img/2.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        .sec4{background:url(img/3.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        .sec5{background:url(img/bg.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        .sec6{background:url(img/bg.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        .sec7{background:url(img/fx.jpg); background-size:100% 100%; width:100%; height:100%;display:none;}
        
        .i1{opacity:0; width: 100%;height: 100%; position:absolute; background:url(img/1.1.png); background-size:100% 100%; z-index:1;-webkit-animation: show1 1s  .5s linear  alternate  infinite both;}
        .i2{opacity:0;width:100%; height:100%;position:absolute; background:url(img/1.2.png); background-size:100% 100%;-webkit-animation: movetop 1s linear 1.5s forwards;}
        .i3{opacity:0;width:100%; height:100%;position:absolute; background:url(img/1.3.png); background-size:100% 100%;-webkit-animation: show1 1.5s  2s linear     both;}
        .x1{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x1.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 1s forwards;}
        .x2{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x2.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 2s forwards;}
        .x3{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x3.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 3s forwards;}
        .x4{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x4.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 4s forwards;}
        .x5{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x5.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 5s forwards;}
        .x6{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x6.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 6s forwards;}
        .x7{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x7.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 7s forwards;}
        .x8{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x8.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 8s forwards;}
        .x9{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x9.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 9s forwards;}
        .x10{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x10.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 10s forwards;}
        .x11{opacity:0;width:100%; height:100%;position:absolute; background:url(img/x10.png); background-size:100% 100%;-webkit-animation: movetop 1.5s linear infinite 11s forwards;}
        .i4,.i5,.i6, .i8,.i9,.i10,.i11,.i7{ opacity:0;}
        
        .i4{width:100%; height:100%;position:absolute; background:url(img/1.4.png); background-size:100% 100%; -webkit-animation: show1 1.5s  2.5s linear  alternate  infinite both;}
        .it5{opacity:0; width:100%; height:100%;position:absolute; background:url(img/gzbg.png); background-size:100% 100%; -webkit-animation: bounceInDown1 2s  .5s linear  forwards;}
        .it6{opacity:0;width:100%; height:100%;position:absolute; background:url(img/gz.png); background-size:100% 100%; -webkit-animation: show1 1s 2.5s linear  forwards;}
         .not{ z-index:10; margin-left:81px; width:200px; height:82px; position:absolute; background:url(img/not.png);background-size:100% 100%;-webkit-animation: show1 1s  3s linear both; bottom:7%; border:0px;}
         .yes{z-index:10; margin-left:380px; width:198px; height:82px; position:absolute; background:url(img/yes.png);background-size:100% 100%;-webkit-animation: show1 1s  3s linear both;bottom:7%; border:0px;}
         
         .it7{opacity:0; width:100%; height:100%;position:absolute; background:url(img/2.1.png); background-size:100% 100%; -webkit-animation: movetop 1s  .5s linear  forwards;}
         .it8{opacity:0;width:100%; height:100%;position:absolute; background:url(img/2.2.png); background-size:100% 100%; -webkit-animation: show1 1s 1.5s linear  forwards;}
         .it9{opacity:0;width:100%; height:100%;position:absolute; background:url(img/2.3.png); background-size:100% 100%; -webkit-animation: bounceleft 1s 1.5s linear  forwards; z-index:10;}
         .it10{opacity:0;width:100%; height:100%;position:absolute; background:url(img/2.4.png); background-size:100% 100%; -webkit-animation: show1 1.5s 1.5s linear   infinite forwards;}
         .it11{opacity:0;width:100%; height:100%;position:absolute; background:url(img/2.5.png); background-size:100% 100%; -webkit-animation: show1 1.5s 1.5s linear   infinite forwards;}
         .it12{opacity:0; border:0; margin-left:205px; width:216px; height:89px; position:absolute; background:url(img/btnsure.png); background-size:100% 100%; -webkit-animation: show1 1.5s 1.5s linear forwards;z-index:15;bottom: 11%;}
         
         .id5{opacity:0; width:100%; height:100%;position:absolute; background:url(img/5.1.png); background-size:100% 100%; -webkit-animation: bounceInDown1 2s  .5s linear  forwards;}
                 
        .id6{opacity:0; width:100%; height:100%;position:absolute; background:url(img/6.1.png); background-size:100% 100%; -webkit-animation: bounceInDown1 2s  .5s linear  forwards;}                 
         ::-webkit-input-placeholder{ color:White;}
         input{ width:211px; height:58px; line-height:58px; position:absolute; background-color:#6a3906; color:#fff; font-size:1.5em; margin-left:208px; font-weight:bold; padding-left:10px;border:1px solid #6a3906;}
         .tname{}
         .tphone{}
         .btnsure{ border:0; margin-left:200px; width:223px; height:80px; position:absolute; background:url(img/btnsure.png); background-size:100% 100%;z-index:15;}
          
         .zd{opacity:0; border:0; margin-left:208px; width:223px; height:78px; position:absolute; background:url(img/zd.png); background-size:100% 100%; -webkit-animation: show1 1s 2.5s linear forwards;z-index:15; bottom:37%;}
         .fx{opacity:0; border:0; margin-left:208px; width:224px; height:78px; position:absolute; background:url(img/fx.png); background-size:100% 100%; -webkit-animation: show1 1s 2.5s linear forwards;z-index:15; bottom:37%;}             
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
    </style>
</head>
<body>
    <div class="loading-container">
        <img src="image/loading-outer.png" class="loading-outer" width="100%" /><img src="image//loading-inner.png"
            class="loading-inner" width="100%" /><img src="image//loading-logo.png" class="loading-logo"
                width="100%" /><img src="image/loading-text.png" class="loading-text" width="100%" /><img
                    src="image/loading-point.png" class="loading-point" width="100%" />
    </div>
    <header class="app-header">
        <a href="javascript:void(0);" class="u-globalAudio z-play">
            <audio loop="" src="" id="ttnb" autoplay="" preload type="audio/mpeg">
            </audio>
        </a>
    </header>
    <section class="sec1" style="display: none;">
        <div class="i1">
        </div>
        <div class="i2">
        </div>
        <div class="i3">
        </div>
        <div class="i4">
        </div>
        <div class="x1"></div>
        <div class="x2"></div>
        <div class="x3"></div>
        <div class="x4"></div>
        <div class="x5"></div>
        <div class="x6"></div>
        <div class="x7"></div>
        <div class="x8"></div>
        <div class="x9"></div>
        <div class="x10"></div>
        <div class="x11"></div>
        <button class="not" id="tt1">
        </button>
        <button class="yes">
        </button>
    </section>
    <section class="sec2">
        <div class="i5">
        </div>
        <div class="i6">
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
        <div class="id5"></div>
        <button class="fx" id="fx">
        </button>
    </div>
    <div class="sec6">
        <div class="id6"></div>
        <button class="zd" id="zd">
        </button>
    </div>
    <div class="sec7">
        <div class="i32">
        </div>
        <div class="i33">
        </div>
        <div class="i34">
        </div>
        <div class="i35">
        </div>
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
    <script src="/yqh/js/layer.m.js" type="text/javascript"></script>
    <script src="/yqh/js/jquery.let_it_snow.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        dataForWeixin.title = "【有鬼@你】万圣节红包你敢拿吗";
        dataForWeixin.desc = "【有鬼@你】万圣节红包你敢拿吗";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/yqh/img/fxs.jpg";
        var count = 0;
        var vh = $(window).height();
        var vw = $(window).width();
        var Landscape = new mo.Landscape({});
        $("html,body").css({ "width": vw, "height": vh });
        var sourceArr = ['img/2.mp3', 'img/1.jpg', 'img/1.1.png', 'img/1.2.png', 'img/1.3.png', 'img/1.4.png', 'img/2.jpg', 'img/2.1.png', 'img/2.2.png', 'img/2.3.png', 'img/2.4.png', 'img/2.5.png', 'img/3.jpg', 'img/4.jpg', 'img/5.jpg', 'img/bg.jpg', 'img/btnsure.png', 'img/fx.png', 'img/fx.jpg', 'img/fxs.jpg', 'img/gz.png', 'img/gzbg.png', 'img/lq.png', 'img/not.png', 'img/yes.png', 'img/zd.png','img/5.1.png','img/6.1.png']; //需要加载的资源列表
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                //alert('加载中...（'+count/total*100+'%）');
            },
            onComplete: function (time) {
                //alert("<%=wxopid%>")
                var myVideo = document.getElementById("ttnb");
                LoadAud(myVideo, "img/2.mp3");
                //return false;
                $(".loading-container").fadeOut(200);
                document.addEventListener('WeixinJSBridgeReady', function () {
                    myVideo.play();
                });
                $(".sec1,.sec2,.sec3,.sec4,.sec5,.sec6,.sec7,.flake").css({ width: vw, height: vh });

                $(".sec1").fadeIn("200");
//                $(".i5").addClass("it5");
//                $(".i6").addClass("it6");

                $(".tname").css("top", vh * 480 / 1050);
                $(".tphone").css("top", vh * 560 / 1050);
                $(".btnsure").css("top", vh * 640 / 1050);
                document.getElementById("tt1").addEventListener("webkitAnimationEnd", function () { //动画结束时事件 
                    //不领取红包
                    $(".not").on("click", function () {
                        $(".sec1").fadeOut();
                        $(".sec2").fadeIn(200);
                        $(".i5").addClass("it5");
                        $(".i6").addClass("it6");
                    });
                    //领取红包
                    $(".yes").on("click", function () {
                        $(".sec1").fadeOut();
                        $(".sec3").fadeIn(200);
                        $(".i7").addClass("it7");
                        $(".i8").addClass("it8");
                        $(".i9").addClass("it9");
                        $(".i10").addClass("it10");
                        $(".i11").addClass("it11");
                        $(".i12").addClass("it12");
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
                    $(".zd").on("click", function () {
                        $(".sec6").fadeOut();
                        $(".sec7").fadeIn(200);
                    });
                }, false);
                document.getElementById("fx").addEventListener("webkitAnimationEnd", function () { //动画结束时事件 
                    $(".fx").on("click", function () {
                        $(".sec5").fadeOut();
                        $(".sec7").fadeIn(200);
                    });
                }, false);

                $(".btnsure").on("click", function () {
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
                    showTips();
                    $.ajax({
                        type: 'post',
                        url: '/yqh/helper.ashx?type=AddInfo',
                        dataType: 'json',
                        data: {
                            tname: name, tphone: phone
                        },
                        success: function (data) {

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
