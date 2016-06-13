<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lnzl.aspx.cs" Inherits="NewInfoWeb.lnInfo.lnzl" %>

<!DOCTYPE >
<html>
<head>
    <meta charset="UTF-8">
    <title>鲁能泰山7号，助力城市梦想！</title>
    <meta name="description" content="房地产-微生活" />
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

        @-webkit-keyframes moveInfo {
            0% { background-position: 0% 0%; }
            100% { background-position: 600% 0%; }
        }

        @-webkit-keyframes fad2 {
            0% { -webkit-transform: translate3d(0,-10%, 0); opacity: 0; }
            100% { -webkit-transform: translate3d(0,0, 0); opacity: 1; }
        }

        @-webkit-keyframes bigsmal {
            0% { -webkit-transform: scale(1.5); opacity: 0; }
            100% { -webkit-transform: scale(1); opacity: 1; }
        }

        @-webkit-keyframes fade1 {
            0% { opacity: .5; }
            100% { opacity: 1; }
        }

        @-webkit-keyframes st1 {
            0% { -webkit-transform: translate3d(0,0, 0); opacity: 1; }
            100% { -webkit-transform: translate3d(0,-21%, 0); opacity: 1; }
        }

        @-webkit-keyframes st2 {
            0% { -webkit-transform: translate3d(0,0, 0); opacity: 1; }
            100% { -webkit-transform: translate3d(0,-19%, 0); opacity: 1; }
        }

        @-webkit-keyframes st3 {
            0% { -webkit-transform: translate3d(0,0, 0); opacity: 1; }
            100% { -webkit-transform: translate3d(0,-16%, 0); opacity: 1; }
        }

        @-webkit-keyframes st4 {
            0% { -webkit-transform: translate3d(0,0, 0); opacity: 1; }
            100% { -webkit-transform: translate3d(0,-14%, 0); opacity: 1; }
        }

        @-webkit-keyframes st6 {
            0% { background: url(img/fx.png); background-size: 100% 100%; }
            25% { background: url(img/fx.png); background-size: 100% 100%; }
            50% { background: url(img/fx.png); background-size: 100% 100%; }
            75% { background: url(img/fx1.png); background-size: 100% 100%; }
            100% { background: url(img/fx1.png); background-size: 100% 100%; }
        }

        @-webkit-keyframes st7 {
            0% { -webkit-transform: translate3d(0,5%, 0); opacity: 1; }
            100% { -webkit-transform: translate3d(0,25%, 0); opacity: 1; }
        }

        body { margin: 0; padding: 0; }
        ul, ol, dl { list-style: none; -webkit-padding-start: 0px; }
        body, div, dl, dt, dd, ul, ol, li, h1, h2, h3, h4, h5, h6, pre, form, fieldset, input, textarea, p, blockquote, th, td, img, button { padding: 0; margin: 0; }
        .arraw { display: none; margin: 0 auto; -webkit-animation: arrowtop 1s ease-out infinite; z-index: 150; margin-left: 45%; width: 10%; bottom: 2%; position: absolute; }
        .u-globalAudio.z-play .icon-music { -webkit-animation: reverseRotataZ 1.2s linear infinite; }
        .m-bg-zoom { -webkit-animation: BgZoom 10s linear infinite; animation: BgZoom 10s linear infinite; -o-animation: BgZoom 10s linear infinite; }
        .u-globalAudio { left: 86%; }
        .app-header { position: fixed; top: 0; z-index: 100; }
        .u-globalAudio .icon-music { width: 30px; height: 30px; background: url(img/units-icons.png); display: block; background-size: cover; }
        .u-globalAudio.z-play .icon-music { -webkit-animation: reverseRotataZ 1.2s linear infinite; }
        .u-globalAudio { color: #fff; text-decoration: none; font-size: 24px; position: fixed; bottom: 28px; display: block; z-index: 9999; }

        .slide { position: relative; width: 100%; height: 100%; overflow: hidden; }
            .slide .content { width: 100%; height: 100%; margin: 0 auto; }
                .slide .content li { width: 100%; height: 100%; overflow: hidden; -webkit-background-size: cover; background-size: 100% 100%; color: #fff; font-size: 100px; }
                    .slide .content li:nth-child(1) { background-image: url(img/1.jpg); background-size: 100% 100%; }
                    .slide .content li:nth-child(2) { background-image: url(img/2.jpg); background-size: 100% 100%; }
                    .slide .content li:nth-child(3) { background-image: url(img/3.jpg); background-size: 100% 100%; }
                    .slide .content li:nth-child(4) { background-image: url(img/4.jpg); background-size: 100% 100%; }
                    .slide .content li:nth-child(5) { background-image: url(img/5.jpg); background-size: 100% 100%; }
                    .slide .content li:nth-child(6) { background-color: white; overflow-y: scroll; color: black; }
                    .slide .content li img { position: absolute; z-index: -3; width: 100%; height: 100%; }
        .l1_1 { -webkit-animation: bounceInLeft 1s .3s ease both; }
        .l1_2 { -webkit-animation: bounceRight 1s .3s ease both; }
        .l1_3 { -webkit-animation: bounceIn 1s 1s ease both; }

        .l2_1 { -webkit-animation: fad2 1s .3s ease both; }
        .l2_2 { -webkit-animation: flipInX 1s .8s ease both; }

        .l3_1 { -webkit-animation: fad2 1s .3s ease both; }
        .l3_2 { -webkit-animation: flipInY 1s .8s ease both; }

        .l4_1 { -webkit-animation: fad2 1s .3s ease both; }
        .l4_2 { -webkit-animation: flipInY 1s .8s ease both; }

        .l5_1 { -webkit-animation: fad2 1s .3s ease both; }
        .l5_2 { -webkit-animation: flipInX 1s .8s ease both; }

        .pggz { display: none; position: fixed; width: 100%; height: 100%; z-index: 100; top: 0; background-color: rgba(0,0,0,0.5); }
        .biggz { position: absolute; width: 100%; top: 50%; left: 50%; -webkit-transform: translate3d(-50%,-50%,0); }

        .bigfx { display: none; position: fixed; width: 100%; height: 100%; z-index: 100; top: 0; }
        input { border: 0; outline: 0; background-color: transparent; -webkit-appearance: none; }
        .plPage { display: none; position: fixed; width: 100%; height: 100%; z-index: 100; top: 0; background-color: rgba(0,0,0,0.7); }
        .backg { width: 80%; top: 5rem; position: absolute; left: 50%; -webkit-transform: translate3d(-50%,0,0); background-color: white; border-radius: 0.5rem; }
        .pl-top { height: 3rem; }
        .xpl2 { color: #631811; font-weight: 500; padding-top: 1rem; padding-left: 0.6rem; float: left; }
        .pl-return { width: 20%; height: 2rem; text-align: center; float: right; margin-top: 0.8rem; margin-right: 1.3rem; background-color: #ca762c; border-radius: 0.4rem; line-height: 2rem; }
        .pl-content { width: 90%; margin-left: 5%; height: 8.71rem; border: 1px solid #d6d6d6; padding: 0.1rem; font-size: 100%; resize: none; }
        .submitBtn { width: 50%; height: 2rem; background-color: #ca762c; margin-left: 25%; border-radius: 0.15rem; margin-top: 0.6rem; margin-bottom: 0.6rem; text-align: center; line-height: 2rem; color: white; font-weight: bold; font-size: 100%; }
        .divName { width: 90%; height: 2rem; border: 1px solid #ca762c; border-radius: 0.1rem; margin-top: 0.8rem; margin-left: 5%; font-size: 100%; }
        .inputPhone { width: 70%; height: 100%; line-height: 2rem; margin-left: 0.2rem; font-size: 100%; }
        .pphone { float: left; height: 100%; line-height: 2rem; margin-left: 0.2rem; color: #ca762c; }
            .pphone:after { content: ''; clear: both; }
        .divPhone { width: 90%; height: 2rem; border: 1px solid #ca762c; border-radius: 0.1rem; margin-top: 0.5rem; margin-left: 5%; font-size: 100%; }
        .inputName { width: 70%; height: 100%; line-height: 2rem; margin-left: 0.2rem; font-size: 100%; }
        .pname { float: left; height: 100%; line-height: 2rem; margin-left: 0.2rem; color: #ca762c; }
        .bg { position: absolute; top: 0; left: 0; z-index: 300; display: none; }

        .s1 { position: absolute; top: 0; left: 0; z-index: 3; display: none; background-color: white; color: black; overflow-x: hidden; }
        .s1_fx { position: absolute; right: 0; top: 0; width: 25% !important; }

        .btngz { position: absolute; width: 35%; left: 10%; }
        .btnmx { position: absolute; width: 35%; right: 10%; }
        .ullist { width: 100%; }
            .ullist li { width: 100%; margin: 3% 0; }
        .lbd1, .lbd2 { width: 90%; margin-left: 5%; }
        .lbd2 { font-family: 'Microsoft YaHei'; color: #7b7b7b; clear: both; padding: 3% 0; }
        .lbname { float: left; width: 40%; font-weight: bold; font-family: 'Microsoft YaHei'; font-size: 14px; }
        .lbdz { float: right; width: 37%; font-weight: bold; font-family: 'Microsoft YaHei'; }

        .fgx { width: 100%; }
        .skipBtn { position: absolute; width: 12% !important; height: auto !important; z-index: 10 !important; right: 1%; }
        .xl { width: 5%; height: auto; font-family: 'Microsoft JhengHei'; font-weight: bold; font-size: 1.3rem; color: red; position: absolute; top: 5%; left: 4%; -webkit-animation: st7 1s infinite alternate; }
        .ph { width: 13%; margin-top: 12%; position: absolute; height: auto; -webkit-animation: st7 1s infinite alternate; }
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
    <img src="img/skip.png" class="skipBtn">
    <div class="main1">
        <div class="slide">
            <ul class="content">
                <li class="l1">
                    <img src="img/1.1.png" id="l1_1" />
                    <img src="img/1.2.png" id="l1_2" />
                    <img src="img/1.3.png" id="l1_3" />
                </li>
                <li class="l2">
                    <img src="img/2.1.png" id="l2_1" />
                    <img src="img/2.2.png" id="l2_2" />
                    <img src="img/2.3.png" id="l2_3" style="opacity: 1!important;" />
                </li>
                <li class="l3">
                    <img src="img/3.1.png" id="l3_1" />
                    <img src="img/3.2.png" id="l3_2" />
                    <img src="img/2.3.png" id="l3_3" style="opacity: 1!important;" />
                </li>
                <li class="l4">
                    <img src="img/4.3.png" id="l4_3" style="opacity: 1!important;" />
                    <img src="img/4.1.png" id="l4_1" />
                    <img src="img/4.2.png" id="l4_2" />
                </li>
                <li class="l5">
                    <img src="img/4.3.png" id="l5_3" style="opacity: 1!important;" />
                    <img src="img/5.1.png" id="l5_1" />
                    <img src="img/5.2.png" id="l5_2" />
                </li>

            </ul>
        </div>
        <div class="s1" id="s1">
            <img src="img/6.jpg" style="width: 100%;" class="st1" />
            <img src="img/fx.png" class="s1_fx" />
            <img src="img/ph.png" class="ph" />
            <img src="img/gz.png" class="btngz" />
            <img src="img/mx.png" class="btnmx" />
            <img src="img/tips.jpg" style="width: 100%" />
            <ul class="ullist">
                <li>
                    <div class="lbd1">
                        <p class="lbname">梦想破灭</p>
                        <div class="lbdz clearfix">
                            <img src="img/dz.png" style="vertical-align: middle; width: 20%;" />赞：<span class="dznum">1000</span>
                        </div>
                    </div>
                    <div class="lbd2">
                        在还是一个玩童时，梦想是当探险家。那时我天不怕地不怕，只怕爸妈的拳头巴掌。小学时是漫画家，因为自己爱画，无数人称赞过我的连环画。
但都被妈妈扔了，自己也被骂。初中时是开公司赚钱，买豪车好房送爱自己的和自己爱的人。
                    </div>
                    <img src="img/fg.png" class="fgx" />
                </li>

            </ul>
            <ul class="strformat" style="display: none;">
                <li>
                    <div class="lbd1">
                        <p class="lbname">{1}</p>
                        <div onclick="javascript:changhits('{0}')" class="lbdz clearfix">
                            <img src="img/dz.png" style="vertical-align: middle; width: 20%;" />赞：<span id="zaninfo_{0}" class="dznum">{2}</span>
                        </div>
                    </div>
                    <div class="lbd2">{3}</div>
                    <img src="img/fg.png" class="fgx" />
                </li>
            </ul>
        </div>
    </div>
    <div class="pggz">
        <img src="img/biggz.png" class="biggz" />
    </div>
    <div class="plPage hidden">
        <div class="backg">
            <div class="pl-top">
                <p class="xpl2">写梦想</p>
                <div class="pl-return">返回</div>
            </div>
            <textarea class="pl-content" id="txtcomment" placeholder="写出你关于梦想或者与更好的自己相关的一段话！"></textarea>
            <div class="divName">
                <p class="pname">姓名</p>
                <input class="inputName" placeholder="请输入2-6位中文姓名" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
                    onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" oncontextmenu="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
                    id="username" type="text">
            </div>
            <div class="divPhone">
                <p class="pphone">电话</p>
                <input class="inputPhone" placeholder="请输入11位手机号码" maxlength="11" id="usermobile" type="tel" onkeypress='return /^\d$/.test
(String.fromCharCode(event.keyCode))'
                    oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace(/\D+/g, 
"")'
                    onblur='this.value = this.value.replace(/\D+/g, "")'>
            </div>
            <div class="submitBtn">提交</div>
        </div>
    </div>
    <div class="bg"></div>
    <img src="img/bigfx.png" class="bigfx" />
    <img src="img/arrow-up.png" class="arraw" />
    <input type="hidden" id="hid1" value="<%=tmpstr %>" />
    <input type="hidden" id="hid2" value="0" />
    <input type="hidden" id="hid3" value="0" />

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
        dataForWeixin.title = "鲁能泰山7号，助力城市梦想！";
        dataForWeixin.desc = "就差你啦，快帮我点赞赢取3000元梦想基金吧！";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/lnInfo/img/fxs.jpg";
        this.flag = !0;
        this.shadeFlag = !1;
        this.shadeFlag1 = !0;
        var pageindex = 0;
        var isget = true;
        var n = 0, a = 0;
        var isflag = 0;
        var REG = {
            name: /^[a-zA-Z\u4e00-\u9fa5]{2,12}$/,
            phone: /(^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$)|(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/,
            wxid: /^[a-zA-Z][a-zA-Z0-9_-]{5,19}$/,
            number: /^[+\-]?\d+(\.\d+)?$/,
            idCard: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/
        }
        var ww = $(window).width();
        var hh = $(window).height();
        var sourceArr = ['img/4.mp3', 'img/1.jpg', 'img/2.jpg', 'img/3.jpg', 'img/4.jpg', 'img/5.jpg', 'img/1.1.png', 'img/1.2.png', 'img/1.3.png', 'img/2.1.png',
'img/2.2.png', 'img/3.1.png', 'img/3.2.png', 'img/4.1.png', 'img/4.2.png', 'img/5.1.png', 'img/5.2.png'];
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                gid('loading_per').innerHTML = Math.floor(count / total * 100) + "%";
                //alert('加载中...（'+count/total*100+'%）');
            }, onComplete: function (time) {
                gid("loading").parentNode.removeChild(gid("loading"));
                var myVideo = document.getElementById("ttnb");
                LoadAud(myVideo, "img/4.mp3");
                $(".s1").css({ width: ww });
                $(".slide,.bg,.bigfx").css({ width: ww, height: hh });
                showslid();
                $(".pl-return").tap(function () {
                    $(".plPage").fadeOut(10);
                });
                $(".btngz").tap(function () {
                    $(".pggz").fadeIn(30);
                });
                $(".s1_fx,.s1_fx_1").tap(function () {
                    $(".bigfx").fadeIn(30);
                });
                $(".bigfx").tap(function () {
                    $(".bigfx").fadeOut(30);
                });
                $(".pggz").tap(function () {
                    $(".pggz").fadeOut(30);
                });
                $(".btnmx").tap(function () {
                    if ("<%=isx%>" == "1" || $("#hid2").val() == "1") {
                        dialog("您已提交梦想信息,请不要重复操作！");
                        return false;
                    } else {
                        $(".plPage").fadeIn(30);
                    }

                });
                $(".skipBtn").tap(function () {
                    $(".skipBtn").hide();
                    $(".arraw").hide();
                    $(".slide").fadeOut(30);
                    $(".s1").fadeIn(30);
                    $(".btngz,.btnmx").css({ "top": $(".st1").height() * 850 / 960 });
                });
                $(".submitBtn").tap(function () {
                    var tcontext = $.trim($("#txtcomment").val());
                    var tname = $.trim($("#username").val());
                    var tphone = $.trim($("#usermobile").val());

                    if (tcontext == "" || tcontext == null) {
                        dialog("请填写梦想信息！");
                        $("#txtcomment").focus();
                        return false;
                    }
                    var maxChars = 500;//最多字符数  
                    if (tcontext.length > maxChars) {
                        dialog("梦想信息不能超过500字！");
                        $("#txtcomment").focus();
                        return false;
                        //$("#txtcomment").val($("#txtcomment").val().substring(0, maxChars));
                    }
                    if (tname == "" || tname == null) {
                        dialog("请填写姓名信息");
                        $("#username").focus();
                        return false;
                    }
                    if (!REG.name.test(tname)) {
                        dialog("请填写正确的姓名信息");
                        $("#username").focus();
                        return false;
                    }
                    if (tphone == "" || tphone == null) {
                        $("#usermobile").focus();
                        dialog("请填写手机号码信息！");
                        return false;
                    }
                    if (!REG.phone.test(tphone)) {
                        $("#usermobile").focus();
                        dialog("请填写正确手机号码信息！");
                        return false;
                    }
                    window.overlay1 = new mo.Overlay({
                        content: "梦想传达中，请稍后...",
                        valign: 'top',
                        offset: [0, 10]
                    });
                    $(".bg").show();
                    $.ajax({
                        type: 'POST',
                        url: "Operation.ashx",
                        data: {
                            type: "AddMX",
                            tpid: $("#hid1").val(),
                            tname: tname,
                            tphone: tphone,
                            tcont: tcontext
                        },
                        dataType: "json",
                        success: function (data) {
                            //alert(data.code);
                            overlay1.close();
                            $(".bg").hide();
                            if (data.count == "2") {
                                $(".tname").val('');
                                $(".thpone").val('');
                                $("#hid2").val("1");
                                dialog("梦想提交成功!", "success");
                                $(".ullist").prepend(String.format($(".strformat").html(), data.code, tname, 0, tcontext));
                                $(".plPage").fadeOut(30);

                                return false;
                            } else if (data.count == "1") {
                                $(".plPage").fadeOut(30);
                                dialog("请不要重复提交信息!", "alert");
                                return false;
                            } else if (data.count == "3") {

                                dialog(data.code, "alert");
                                return false;
                            }
                            else {
                                dialog("网络出错,请稍后提交", "error");
                                return false;
                            }
                        }
                    });
                });
                loadinfolist(0);
                $(window).scroll(function () {
                    if (($(window).scrollTop() + $(window).height() > $(document).height() - 40)) {
                        if (isget) {
                            pageindex++;
                            loadinfolist(pageindex);
                        }
                    }
                });
            }
        });
        function showslid() {
            window.pageSlide = new mo.Slide({
                target: $('.slide li'),
                effect: 'push',
                playTo: 0,
                disable: 4,
                event: {
                    init: function (e) {
                        $(".l1 img").css("opacity", "1");
                        $("#l1_1").addClass("l1_1");
                        $("#l1_2").addClass("l1_2");
                        $("#l1_3").addClass("l1_3");
                        $(".arraw").show();
                    },
                    change: function () {
                        var ti = this.curPage;
                        if (ti == 0) {
                            $(".l1 img").css("opacity", "1");
                            $("#l1_1").addClass("l1_1");
                            $("#l1_2").addClass("l1_2");
                            $("#l1_3").addClass("l1_3");
                        } else {
                            $(".l1 img").css("opacity", "0");
                            $(".l1 img").removeClass();
                        }
                        if (ti == 1) {
                            $(".l2 img").css("opacity", "1");
                            $("#l2_1").addClass("l2_1");
                            $("#l2_2").addClass("l2_2");
                        } else {
                            $(".l2 img").css("opacity", "0");
                            $(".l2 img,.sl2 div").removeClass();

                        }
                        if (ti == 2) {
                            $(".l3 img").css("opacity", "1");
                            $("#l3_1").addClass("l3_1");
                            $("#l3_2").addClass("l3_2");
                        } else {
                            $(".l3 img").css("opacity", "0");
                            $(".l3 img").removeClass();

                        }
                        if (ti == 3) {
                            $(".l4 img").css("opacity", "1");
                            $("#l4_1").addClass("l4_1");
                            $("#l4_2").addClass("l4_2");
                        } else {
                            $(".l4 img").css("opacity", "0");
                            $(".l4 img").removeClass();

                        }
                        if (ti == 4) {
                            $(".arraw").hide();
                            $(".l5 img").css("opacity", "1");
                            $("#l5_1").addClass("l5_1");
                            $("#l5_2").addClass("l5_2");
                            document.getElementById("l5_2").addEventListener("webkitAnimationEnd", function 
() {
                                setTimeout(function () {
                                    $(".skipBtn").hide();
                                    $(".slide").fadeOut(30);
                                    $(".s1").fadeIn(30);
                                    $(".btngz,.btnmx").css({ "top": $(".st1").height() * 850 / 960 });
                                    // loadinfolist(0);
                                },
                                    800);
                            }, false);

                        } else {
                            $(".l5 img").css("opacity", "0");
                            $(".l5 img").removeClass();
                        }
                    }
                }
            });
        }
        function dialog(msg, type) {
            window.dia1 = new mo.Dialog({
                content: msg,
                type: type
            });
        }
        function loadinfolist(page) {

            if (page == 0) {
                $(".ullist").empty();
            }
            $.post("Operation.ashx", { type: "getlist", tmppage: page, pagesize: "10" }, function (result) {
                var listd = "";
                var template = $(".strformat").html();

                if (parseInt(result.count) < 1) {
                    isget = false;
                } else {
                    $.each(result.result, function (i, n) {
                        listd += String.format(template, n.id, n.name, n.nums, n.tcont);
                    });
                    //alert(listd);
                    $(".ullist").append(listd);
                }
            }, "json");
        }
        function changhits(pid) {
            if ($("#hid3").val() == "1") {
                dialog("您已点赞成功,不能重复点赞", alert);
            } else {
                $.post("Operation.ashx", { type: "HDZan", tmpid: pid, tmpopenid: $("#hid1").val() }, function (result) {
                    //alert(result);
                    if (result.ist == "0") {
                        dialog('网络错误，请重试');
                        // 显示消息
                        return false;
                    } else if (result.ist == "1") {
                        //$("#thumb_" + pid).removeClass().addClass("icon-thumbs-up2");
                        $("#zaninfo_" + pid).text(result.ismsgs);
                        dialog('您已点赞成功!', "success");
                        return false;
                    } else if (result.ist == "2") {
                        dialog('请通过正规渠道进行操作');
                        return false;
                    }
                    else if (result.ist == "3") {
                        dialog('活动时间已过，请关注公告信息');
                        return false;
                    }
                    else if (result.ist == "4") {
                        dialog('网络错误，请重试');
                        return false;
                    } else if (result.ist == "5") {
                        dialog('您已点赞成功,不能重复点赞！');
                        return false;
                    }
                }, "json");
            }
        }
    </script>
</body>
</html>
