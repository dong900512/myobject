<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nbzsinfo.aspx.cs" Inherits="NewInfoWeb.zshmsg.nbzsinfo" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>一封给妈妈的不二情书</title>
    <meta name="description" content="梦想栖所" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <link href="css/all1.css" rel="stylesheet" type="text/css" />
    <style>
           @-webkit-keyframes arrowtop{0%{-webkit-transform:translate3d(0,50%, 0);opacity:1;}100%{ -webkit-transform:translate3d(0, 0, 0);opacity:0;}}
           @-webkit-keyframes arrowtop1{0%{-webkit-transform:translate3d(0,10%, 0);opacity:0;}100%{ -webkit-transform:translate3d(0, 0, 0);opacity:1;}}
            @-webkit-keyframes arrowtoLeft{0%{-webkit-transform:translate3d(0,0, 0);}100%{ -webkit-transform:translate3d(-28%, 0, 0);}}
            @-webkit-keyframes arrowtoRight{0%{-webkit-transform:translate3d(0,0, 0);}100%{ -webkit-transform:translate3d(29%, 0, 0);}}
            @-webkit-keyframes arrowtoLeft22{0%{-webkit-transform:translate3d(-5%,0, 0);}100%{ -webkit-transform:translate3d(0, 0, 0);}}
            @-webkit-keyframes atdown{0%{-webkit-transform:translate3d(0,0, 0);}100%{-webkit-transform:translate3d(0,-3%, 0);}}
            @-webkit-keyframes aroundinfo{
                0%{-webkit-transform:translate3d(-2%,-5%, 0);}
                25%{-webkit-transform:translate3d(-6%,-8%, 0);}
                50%{-webkit-transform:translate3d(5%,10%, 0);}
                75%{-webkit-transform:translate3d(8%,15%, 0);}
                100%{-webkit-transform:translate3d(10%,12%, 0);}
                }
            
           @-webkit-keyframes moveInfo{0%{background-position:0% 0%}100%{ background-position: 600% 0%}}
           @-webkit-keyframes bigsmal{0%{-webkit-transform: scale(1) ;}100%{ -webkit-transform:scale(1.5);}}
           @-webkit-keyframes fade1{0%{-webkit-transform:translate3d(0,-5%, 0);opacity:0;}100%{ -webkit-transform:translate3d(0, 0, 0);opacity:1;}}
           @-webkit-keyframes st1{0%{-webkit-transform:translate3d(0,0, 0);opacity:1;}100%{-webkit-transform:translate3d(0,-21%, 0);opacity:1;}}
           @-webkit-keyframes st2{0%{-webkit-transform:translate3d(0,0, 0);opacity:1;}100%{-webkit-transform:translate3d(0,-19%, 0);opacity:1;}}
           @-webkit-keyframes st3{0%{-webkit-transform:translate3d(0,0, 0);opacity:1;}100%{-webkit-transform:translate3d(0,-16%, 0);opacity:1;}}
            @-webkit-keyframes st4{0%{-webkit-transform:translate3d(0,0, 0);opacity:1;}100%{-webkit-transform:translate3d(0,-14%, 0);opacity:1;}}
            @-webkit-keyframes fbg{0%{background: url(img/hf/2.3.png);background-size:100% 100%;}20%{background: url(img/hf/2.4.png);background-size:100% 100%;}
40%{background: url(img/hf/2.5.png);background-size:100% 100%;}60%{}80%{background: url(img/hf/2.6.png);background-size:100% 100%;}100%{background: url
(img/hf/2.7.png);background-size:100% 100%;}}
           @-webkit-keyframes rotate1{0%{-webkit-transform:rotate(0)}25%{-webkit-transform:rotate(15deg)}50%{-webkit-transform:rotate(0)}75%{-webkit-transform:rotate
(-15deg)}100%{-webkit-transform:rotate(0)}}
         body{ background-color:Black;}
        .arraw { display: none; margin: 0 auto; -webkit-animation: arrowtop 1s ease-out infinite; z-index: 150; left: 41%; width: 18%; bottom: 3%; position: absolute; 
}
        .cg, .sb, .biggz, .bigfx { position: absolute; z-index: 300; top: 0; left: 0; display: none; }
        .u-globalAudio.z-play .icon-music { -webkit-animation: reverseRotataZ 1.2s linear infinite; }
        .m-bg-zoom { -webkit-animation: BgZoom 10s linear infinite; animation: BgZoom 10s linear infinite; -o-animation: BgZoom 10s linear infinite; }
        .u-globalAudio { left: 86%; }
        .app-header { position: fixed; top: 0; width: 640px; z-index: 100; }
        .u-globalAudio .icon-music { width: 30px; height: 30px; background: url(/images/units-icons.png); display: block; background-size: cover; }
        .u-globalAudio.z-play .icon-music { -webkit-animation: reverseRotataZ 1.2s linear infinite; }
        .u-globalAudio { color: #fff; text-decoration: none; font-size: 24px; position: fixed; bottom: 28px; display: block; z-index: 9999; }
        .box1{position: absolute;left: 0;top: 0;width: 100%;z-index: 100;}
        .box1_1{position: fixed; width: 100%; height: 100%; left: 0px; top: 0px; -webkit-transition: opacity 0.3s linear;transition: opacity 0.3s linear; opacity: 1; 
z-index: 999; background-color: rgba(0, 0, 0, 0.498039);display: table; pointer-events: none;}
        .box1_2{display: table-cell; vertical-align: middle; text-align: center;}
        .box1_info{position: relative; display: inline-block; text-align: left; pointer-events: auto;}
        ::-webkit-input-placeholder{ color:white;}
        input { width: 85%;  height: 25px; line-height: 25px;  left: 0; background-color: white; color: black; font-size: 1.1rem; font-weight: bold; padding-left: 
20px; border: 1px solid #6a3906; border-radius: 13px; }
        .tname { margin-top: 2px; }
        .sex { margin-top: 10px; }
        .tphone { margin-top: 2px; }
        .btnsure{z-index: 4;border: 0px;left: 0;width: 60%;margin-top: 4%;margin-bottom: 4%;}
        
        
        
        .tbg{ position:absolute; z-index:200; top:0; left:0; display:none;}
        .tbg1{ position:absolute;margin-top: 26%; z-index:250; top:0; left:0; display:none;-webkit-animation:arrowtoLeft22 1s infinite alternate linear;}
        
        
        
    
        
        .s5{ display:none; position:relative; }
        .s5 img{ width:100%; height:100%; position:absolute; z-index:-3; }
        .s5 div{width:100%; height:100%; position:absolute; }
        .s5 div img{z-index:1!important;}
        
        .s6{ display:none; position:relative; background:url(img/jmyj/7.jpg); background-size:100% 100%;}
        .s6 img{ width:100%; height:100%; position:absolute; z-index:-3; }
        .s6_1{z-index:1!important; }
        .s6_2{z-index:1!important;-webkit-animation:fadeIn 1s 1.6s linear both,atdown 1.2s 1.3s infinite alternate linear;}
        .btnyj{z-index:5!important;width:70%!important;height:auto!important; bottom:42%; right:10%;}
        .yjbj{z-index:6!important;width:70%!important;height:auto!important; bottom:42%; right:10%;}
        
        .btngz{z-index:6!important; width:30%!important; height:auto!important; left:10%; bottom:30%;}
        .btnjp{z-index:6!important; width:30%!important; height:auto!important; right:10%; bottom:30%;}
        .btnmd{z-index:6!important;width:12%!important; height:auto!important; bottom:44%;}
        
        
        .biggz,.bigjp,.bg{ position:absolute; z-index:500; top:0; left:0; display:none;}
        .jpinfo{ position:absolute; z-index:200; top:0; left:0;  display:none;}
        .jpimg{ position:absolute; width:100%; height:100%;}
        
        .box1{position: absolute;left: 0;top: 0;width: 100%;z-index: 100;}
        .box1_1{position: fixed; width: 100%; height: 100%; left: 0px; top: 0px; -webkit-transition: opacity 0.3s linear;transition: opacity 0.3s linear; opacity: 1; 
z-index: 999; background-color: rgba(0, 0, 0, 0.498039);display: table; pointer-events: none;}
        .box1_2{display: table-cell; vertical-align: middle; text-align: center;}
        .box1_info{position: relative; display: inline-block; text-align: left; pointer-events: auto;}
        ::-webkit-input-placeholder{ color:white;}
        input { width: 85%;  height: 35px; line-height: 30px;  left: 0; background-color: white; color: black; font-size: 1.1rem; font-weight: bold; padding-left: 
20px; border: 1px solid #6a3906; border-radius: 13px; }
        .tname { margin-top: 2px; }
        .sex { margin-top: 10px; }
        .tphone { margin-top: 2px; }
        .taddress { margin-top: 2px; }
        .btnsure{z-index: 4;border: 0px;left: 0;width: 60%;margin-top: 4%;margin-bottom: 4%;}
        
        
        
        .slide { position: relative; width: 100%; height: 100%; overflow: hidden; }
        .slide .content { width: 100%; height: 100%; margin: 0 auto; }
        .slide .content li { width: 100%; height: 100%; overflow: hidden; -webkit-background-size: cover; background-size: 100% 100%; color: #fff; font-size: 100px; }
        .slide .content li img { position: absolute; z-index:-3; width: 100%; height: 100%; }
        .slide .content li:nth-child(1){ background:url(img/1.jpg);background-size:100% 100%;}
        .slide .content li:nth-child(2){ background:url(img/2.jpg);background-size:100% 100%;}
        .slide .content li:nth-child(3){ background:url(img/3.jpg);background-size:100% 100%;}
        .slide .content li:nth-child(4){ background:url(img/4.jpg);background-size:100% 100%;}
        .slide .content li:nth-child(5){ background:url(img/5.jpg);background-size:100% 100%;}
        .l1_1{-webkit-animation:zoomIn 1s .3s linear both;}
        .l1_2{-webkit-animation:fade1 1s .6s linear both;}
        .l1_3{-webkit-animation:fadeIn 1s 1s linear both;}
        .l1_4{-webkit-animation:flipInX 1s 1.3s linear both;}
        .l1_5{-webkit-animation:fade1 1s 2s linear both;}

        .l2_1{-webkit-animation:zoomIn 1s .3s linear both;}
        .l2_2{-webkit-animation:fade1 1s .6s linear both;}
        .l2_3{-webkit-animation:fadeIn 1s 1s linear both;}
        .l2_4{-webkit-animation:flipInY 1s 1.3s linear both;}
        .l2_5{-webkit-animation:fade1 1s 2s linear both;}

        .l3_1{-webkit-animation:zoomIn 1s .3s linear both;}
        .l3_2{-webkit-animation:fade1 1s .6s linear both;}
        .l3_3{-webkit-animation:fadeIn 1s 1s linear both;}
        .l3_4{-webkit-animation:bounceInLeft 1s 1.3s linear both;}
        .l3_5{-webkit-animation:fade1 1s 2s linear both;}

        .l4_1{-webkit-animation:zoomIn 1s .3s linear both;}
        .l4_2{-webkit-animation:fade1 1s .6s linear both;}
        .l4_3{-webkit-animation:fadeIn 1s 1s linear both;}
        .l4_4{-webkit-animation:bounceInDown 1s 1.3s linear both;}
        .l4_5{-webkit-animation:fade1 1s 2s linear both;}

        .l5_1{-webkit-animation:fade1 1s .3s linear both;}
        .l5_2{-webkit-animation:fadeIn 1s .6s linear both;}
        .l5_3{-webkit-animation:bounceInDown 1s 1s linear both;}
        .l5_4{-webkit-animation:zoomIn 1s 1.3s linear both;}
        .l5_4_1{z-index:10!important; -webkit-animation:tada 1s 3 linear both;}
        .l5_5{-webkit-animation:fadeIn 1s 2s linear both;}

        .s1{ display:none;  position:relative; top:0; left:0;background:url(img/6.jpg); background-size:100% 100%;}
        .real-btn { position: absolute; left:10%; bottom: 7%; z-index: 5; opacity: 0; border: 0px; width:38%;  }
        .btnadd { position: absolute; bottom: 7%; z-index: 3; border: 0px; width:38%; left:10%;}
        .btnsc { position: absolute; bottom: 7%; border: 0px;  width:38%; right:10%; }
       
        .divBg { width: 100%; height: 100%; }
        .pg1_1 { position: absolute; top: 0; left: 0; }
        .gz { display: none;  position: absolute; z-index: 100; top: 0; left: 0; }
        .fx { display: none; background-color: rgba(0,0,0,.4); position: absolute; z-index: 100; top: 0; left: 0; }
        .picturemax { position: absolute; width: 90%; height:auto; left:5%; bottom:20%; z-index: 21;pointer-events: none; }
        .resimg { display: none; width: 100%; height: 494px; z-index: 21; pointer-events: none; }
        #container { width: 90%; left:5%; position: absolute; z-index: 20;bottom:20%; }
        #container canvas { }
        #popFail {position:fixed;left:50%;top:50%;z-index:500;}
        #popFail .bk,#popFail .cont {position:relative;width:146px;height:146px}
       #popFail .bk {background-color:#000;opacity:.5;border-radius:10px;margin:-73px 0 0 -73px;z-index:0}
       #popFail .cont {position:relative;margin:-146px 0 0 -73px;text-align:center;color:#f5f5f5;font-size:14px;line-height:35px;z-index:1}
       #popFail img {width:35px;height:35px;margin:30px auto;display:block}
       #markTips{ background:url(img/tips1.png) no-repeat center top; position:fixed; top:0px; left:0px; width:100%; height:100%; z-index:333; display:none; 
background-size:100% 100%;}
       
       .s2{ display:none; position:relative; top:0;left:0; background:url(img/7.jpg); background-size:100% 100%;}
       .s2 img{ position:absolute; width:100%;  height:100%;}
       #ly1{width:20%!important;  left:10%; z-index:15; bottom:8%; position:absolute;}
       #ly{ width:20%!important; height:auto!important; left:10%; z-index:10; bottom:8%;}
       #st{width:20%!important; height:auto!important; left:30%; z-index:10; bottom:8%;}
       #cl{width:20%!important; height:auto!important; left:50%; z-index:10; bottom:8%;}
       #sc{width:20%!important; height:auto!important; left:70%; z-index:10; bottom:8%;}
       #ca{bottom: -37%;left: -13%;}

       
       .s3{display:none; position:relative; top:0; left:0; background:url(img/8.1.jpg); background-size:100% 100%;}
       .s3 img{ position:absolute;}
       .s3_1{width:50%; left:25%; bottom:55%;}
       .s3_1_1{-webkit-animation:tada 1.5s infinite alternate linear both;}
       .btnzj{ width:30%; left:35%; bottom:3%;}
       
       .zjmd{ position:absolute; z-index:300; top:0; left:0; display:none; }
       .zjxq{width: 90%; height: 37%;left: 5%;position: absolute;text-align: center;background-color: rgba(255,255,255,.6);bottom: 6%;border-radius: 4%; -webkit-box-
sizing : border-box; overflow:hidden; background:url(img/zmbj.png); background-size:100% 100%;}
        .itmlist { width: 80%;    position: absolute;z-index:10%;
    left: 10%;height: 65%; font: 12px/1.5 tahoma, '\5b8b\4f53' ,sans-serif; overflow-y:auto; -webkit-overflow-scrolling: touch;     }
        .itmlist dd { width: 100%; }
        .itmlist dd span:nth-child(1) { float: left; text-align: center; width: 32.3%; color:white;white-space: nowrap;overflow: hidden;text-overflow: ellipsis; }
        .itmlist dd span:nth-child(2) { float: left; text-align: center; width: 38.3%; color: white; }
        .itmlist dd span:nth-child(3) { float: left; text-align: center; width: 28.3%; color: white; overflow: hidden; }
        .jpinfo{ position:absolute; top:0; left:0; z-index:100; display:none;}
    </style>
</head>
<body marginwidth="0" marginheight="0">
    <script src="js/thelper.js" type="text/javascript"></script>
    <header class="app-header">
        <a href="javascript:void(0);" class="u-globalAudio z-play">
            <audio src="" id="ttnb" preload type="audio/mpeg">
            </audio>
        </a>
    </header>
    <div class="main1">
        <div class="slide">
            <ul class="content">
                <li class="l1">
                    <img src="img/1.1.png" id="l1_1" />
                    <img src="img/1.2.png" id="l1_2" />
                    <img src="img/1.3.png" id="l1_3" />
                    <img src="img/1.4.png" id="l1_4" />
                    <img src="img/1.5.png" id="l1_5" />
                </li>
                <li class="l2">
                    <img src="img/1.1.png" id="l2_1" />
                    <img src="img/1.2.png" id="l2_2" />
                    <img src="img/1.3.png" id="l2_3" />
                    <img src="img/2.1.png" id="l2_4" />
                    <img src="img/1.5.png" id="l2_5" />
                </li>
                <li class="l3">
                    <img src="img/1.1.png" id="l3_1" />
                    <img src="img/1.2.png" id="l3_2" />
                    <img src="img/3.2.png" id="l3_3" />
                    <img src="img/3.1.png" id="l3_4" />
                    <img src="img/3.3.png" id="l3_5" />
                </li>
                <li class="l4">
                    <img src="img/1.1.png" id="l4_1" />
                    <img src="img/1.2.png" id="l4_2" />
                    <img src="img/3.2.png" id="l4_3" />
                    <img src="img/4.1.png" id="l4_4" />
                    <img src="img/3.3.png" id="l4_5" />
                </li>
                <li class="l5">
                    <img src="img/5.1.png" id="l5_1" />
                    <img src="img/5.2.png" id="l5_2" />
                    <img src="img/5.3.png" id="l5_3" />
                    <img src="img/5.4.png" id="l5_4" />
                    <img src="img/5.5.png" id="l5_5" />
                </li>
            </ul>
        </div>
        <div class="s1">
            <img src="" class="resimg" />
            <img src="img/hkbj.png" class="picturemax1" style="position: absolute; z-index: -1;" />
            <img src="img/hkbj.png" class="picturemax" />
            <div id="container" class="editor">
            </div>
            <input id="file" type="file" style="opacity: 0;" class="real-btn" />
            <img src="img/sczp.png" class="btnadd" />
            <img src="img/schk.png" class="btnsc" />
        </div>
        <div class="s2">
            <img src="img/7.1.png" id="s2_1" />
            <img src="img/7.2.png" id="s2_2" />
            <img src="img/7.3.png" id="s2_3" />
            <div id="ly1">
            </div>
            <img src="img/ly.png" id="ly" />
            <img src="img/st.png" id="st" />
            <img src="img/cl.png" id="cl" />
            <img src="img/sc.png" id="sc" />
        </div>
        <div class="s3">
            <img src="img/8.1.png" class="s3_1" />
            <img src="img/zjmd.png" class="btnzj" />
        </div>
    </div>
    <img src="" class="jpinfo" />
    <img class="bigfx" src="img/fxs.png" />
    <div class="bg">
    </div>
    <div id="bminfo" class="box1" index="1" style="display: none;">
        <div class="box1_1">
            <div class="box1_2">
                <div class="box1_info">
                    <div style="width: 80%; background: url(img/bj.png); color: White; background-size: 100% 100%;
                        text-align: center; margin: 0 auto; font-size: 1rem;">
                        <img src="img/clos1.png" class="closeinfo" style="right: 57px; float: right; margin-top: 5px;
                            width: 14%; display: none;" />
                        <div style="clear: both;">
                        </div>
                        <div style="text-align: left; margin-left: 8%;">
                            姓&nbsp;&nbsp;&nbsp;名：</div>
                        <input placeholder="姓名" class="tname" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
                            onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" oncontextmenu="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ 
]/g,'')" />
                        <div style="text-align: left; margin-left: 8%; margin-top: 10px;">
                            手&nbsp;&nbsp;&nbsp;机：</div>
                        <input placeholder="手机" type="tel" class="tphone" maxlength="11" onkeypress='return /^\d$/.test(String.fromCharCode(event.keyCode))'
                            oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace
(/\D+/g, "")' onblur='this.value = this.value.replace(/\D+/g, "")' /><br />
                        <img src="img/btn1.png" class="btnsure" id="tt3" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="zjmd">
        <img src="img/clos1.png" class="close" style="right: 7%; bottom: 39%; width: 13%;
            position: absolute; z-index: 100;" />
        <div class="zjxq">
            <h2 style="text-align: center; margin-top: 17%;">
            </h2>
            <dl class="itmlist">
            </dl>
        </div>
    </div>
    <div id="markTips">
    </div>
    <div id="popFail" style="display: none;">
        <div class="bk">
        </div>
        <div class="cont">
            <img src="http://1251002992.cdn.myqcloud.com/1251002992/qmox/Act6/images/loading.gif"
                alt="loading...">
            <span>正在加载...</span>
        </div>
    </div>
    <img src="img/arraw.png" class="arraw" />
    <input type="hidden" id="hid2" value="0" />
    <audio src="img/jmyj/km.mp3" loop id="kms" preload type="audio/mpeg">
    </audio>
    <input type="hidden" id="hid1" value="<%=wxopid %>" />
    <script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/loader.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/pc-prompt.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/film.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/image-editor.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/dialog.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/overlay.min.js"></script>
    <script src="http://touch.code.baidu.com/touch.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/slide.v2.0.min.js"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.PCPrompt = new mo.PCPrompt();
        dataForWeixin.title = "一封给妈妈的不二情书";
        dataForWeixin.desc = "一封给妈妈的不二情书";
        dataForWeixin.img = "http://wsjhd.tencenthouse.com/zshmsg/img//fxs.jpg";
        dataForWeixin.async = true;
        dataForWeixin.ShareCallBack = function (exe, it) {
            if (exe == "success" && it == "0") {
                //return false;
                $.ajax({
                    type: 'post',
                    url: "jmyj.ashx",
                    data: { type: "upjfinfo", topid: $("#hid1").val() },
                    dataType: 'json',
                    success: function (data) {
                    },
                    error: function (xhr, type) {
                    }
                });
            }
        };
        var ctindex = 0;
        this.flag = !0;
        this.shadeFlag = !1;
        this.shadeFlag1 = !0;
        var n = 0, a = 0;
        var isflag = 0;
        var numt = 0;
        var isupload = true;
        var REG = {
            name: /^[a-zA-Z\u4e00-\u9fa5]{2,12}$/,
            phone: /(^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$)|(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/,
            wxid: /^[a-zA-Z][a-zA-Z0-9_-]{5,19}$/,
            number: /^[+\-]?\d+(\.\d+)?$/,
            idCard: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/
        }
        var ww = $(window).width();
        var hh = $(window).height();
        var flag;
        var coud = 0;
        var voice = {
            localId: '',
            serverId: ''
        };
        var START;
        var END;
        var localStorage = {
            rainAllowRecord: ''
        }
        var recordTimer;
        var rtim1;
        $(function () {
            var sourceArr = ['img/1.1.png', 'img/1.2.png', 'img/1.3.png', 'img/1.4.png', 'img/1.5.png', 'img/1.jpg', 'img/2.jpg', 'img/3.jpg', 'img/4.jpg',
'img/5.jpg', 'img/2.1.png', 'img/3.1.png', 'img/3.2.png', 'img/3.3.png', 'img/4.1.png', 'img/5.1.png', 'img/5.2.png', 'img/5.3.png', 'img/5.4.png', 'img/arraw.png',
'img/bj.png', 'img/bt1.png', 'img/clos1.png', 'img/6.jpg', 'img/hkbj.png', 'img/schk.png', 'img/sczp.png', 'img/7.1.png', 'img/7.2.png', 'img/7.3.png', 'img/7.jpg',
'img/ly.png', 'img/st.png', 'img/cl.png', 'img/sc.png', 'img/8.jpg', 'img/8.1.png', 'img/zjmd.png', 'img/zmbj.png', 'img/j0.jpg', 'img/j1.jpg', 'img/j2.jpg',
'img/j3.jpg', 'img/j4.jpg'];
            new mo.Loader(sourceArr, {
                onLoading: function (count, total) {
                    gid('loading_per').innerHTML = Math.floor(count / total * 100) + "%";
                    //alert('加载中...（'+count/total*100+'%）');
                }, onComplete: function (time) {
                    gid("loading").parentNode.removeChild(gid("loading"));
                    var myVideo = document.getElementById("ttnb");

                    LoadAud(myVideo, "img/jmyj/2.mp3");
                    var kms = document.getElementById("kms");
                    $(".s1,.s2,.s3,.s4,.s5,.s6,.s7,.biggz,.bigjp,.jpinfo,.tbg,.bg,#bminfo,.slide,.zjmd,.jpinfo,.bigfx").css({ width: ww, height: hh });
                    showslid();
                    //$(".slide").hide();
                    if ("<%=iscurcj %>" == "1") {
                        dataForWeixin.async = true;
                        dataForWeixin.url = "http://wsjhd.tencenthouse.com/zshmsg/shzsDetail.htm?tid=" + data.result;
                        dataForWeixin.desc = "给妈妈赠送的贺卡";
                        dataForWeixin.title = "一封给妈妈的不二情书";
                        //alert("<%=lotNum %>");
                        $(".slide").hide();
                        $(".s3").fadeIn(50);
                        $(".jpinfo").attr("src", "img/j<%=lotNum %>.jpg");
                        setTimeout(function () {
                            $(".jpinfo").show();
                        }, 100);
                    }
                    $(".bigfx").on("touchend", function (e) {
                        $(".bigfx").hide();
                    });
                    $(".btnzj").on("touchend", function (e) {
                        $(".bg").show();
                        sholist();
                        setTimeout(function () {
                            $(".zjmd").fadeIn(30);
                            $(".bg").hide();
                        }, 300)
                    });
                    //yjinfo();
                    $("#ly1").on('touchend', function (event) {
                        if ($(this).hasClass("tid")) {
                            event.preventDefault();
                            $("#popFail").hide();
                            END = new Date().getTime();
                            if ((END - START) < 100) {
                                END = 0;
                                START = 0;
                                //小于300ms，不录音
                                clearTimeout(rtim1);
                                clearTimeout(recordTimer);
                            } else {
                                clearTimeout(rtim1);
                                wx.stopRecord({
                                    success: function (res) {
                                        voice.localId = res.localId;
                                    },
                                    fail: function (res) {
                                        //alert(JSON.stringify(res));
                                    }
                                });
                            }
                            $(this).removeClass("tid");
                        } else {
                            event.preventDefault();
                            $("#popFail .cont span").html("录音中...");
                            $("#popFail").show();
                            START = new Date().getTime();
                            recordTimer = setTimeout(function () {
                                if (voice.localId == '') {
                                    wx.startRecord({
                                        success: function () {
                                            localStorage.rainAllowRecord = 'true';
                                        },
                                        cancel: function () {
                                            $("#popFail").hide();
                                            dialog("您拒绝授权录音");
                                            return false;
                                        }
                                    });
                                } else {
                                    $("#popFail").hide();
                                    dialog("您已经录音成功，请不要重复操作！");
                                    return false;
                                }
                            }, 100);
                            rtim1 = setTimeout(function () {
                                clearTimeout(recordTimer);
                                wx.stopRecord({
                                    success: function (res) {
                                        voice.localId = res.localId;
                                    },
                                    fail: function (res) {
                                        //alert(JSON.stringify(res));
                                    }
                                });
                            }, 60000);
                            $(this).addClass("tid");
                        }
                    });
                    $(".jpinfo").on("touchend", function () {
                        $(".jpinfo").hide();
                    });
                    $("#st").on("click", function () {
                        if (voice.localId == '') {
                            dialog('请先录制一段声音,确认后播放');
                            return;
                        }
                        wx.playVoice({
                            localId: voice.localId
                        });
                    });
                    $("#cl").on("touchend", function () {
                        voice.localId = "";
                        voice.serverId = "";
                        START = "";
                        END = "";
                        dialog('您可以重新录制声音了。', alert);
                    });
                    $("#sc").on("touchend", function () {
                        if (voice.localId == '') {
                            dialog('请先录制一段声音,确认后再进行上传', alert);
                        } else {
                            wx.stopVoice({
                                localId: voice.localId
                            });
                            $(".bg").show();
                            uploadVoice();
                        }
                    });

                    $(".btnsc").on("touchend", function (e) {
                        if (isupload) {
                            dialog("请上传照片后操作！", "alert");
                            return false;
                        }

                        $(".bg").show();
                        var tw = $(".picturemax").width();
                        var th = $(".picturemax").height();
                        //alert(tw + "|" + th);
                        //return false;
                        isupload = true;
                        eidtor.toDataURL(function (data) {
                            //alert(data);
                            //图片合成
                            var cvs = document.createElement('canvas');
                            cvs.width = tw;
                            cvs.height = th;
                            var ctx = cvs.getContext("2d");
                            var img = new Image();
                            img.onload = function () {
                                ctx.drawImage(this, 0, 0, tw, th, 0, 0, 468, 462);
                                img = new Image();
                                img.onload = function () {
                                    ctx.drawImage(this, 0, 0, 468, 462, 0, 0, tw, th);
                                    upLoadImg(cvs.toDataURL("image/jpeg"));
                                }
                                img.src = $(".picturemax").attr("src");
                            };
                            img.src = data;
                            //document.write('<img src="' + data + '"/>');
                        });
                    });
                    $("#btnjp").on("touchend", function (e) {
                        $(".bigjp").fadeIn(20);
                    });
                    $(".bigjp").on("touchend", function (e) {
                        $(".bigjp").fadeOut(20);
                    });
                    $("#btngz").on("touchend", function (e) {
                        $(".biggz").fadeIn(20);
                    });
                    $(".biggz").on("touchend", function (e) {
                        $(".biggz").fadeOut(20);
                    });

                    $(".close").on("touchstart", function (e) {
                        e.preventDefault();
                    }).on("touchend", function (e) {

                        $(".zjmd").fadeOut(100);
                    });
                    $(".btnsure").on("touchend", function (e) {
                        var name = $.trim($(".tname").val());
                        var phone = $.trim($(".tphone").val());

                        if (name == "" || name == null) {
                            dialog("请输入姓名信息！");
                            $(".tname").focus();
                            return false;
                        }
                        if (!REG.name.test(name)) {
                            dialog("请填写正确的报名人信息");
                            $(".tname").focus();
                            return false;
                        }
                        if (phone == "" || phone == null) {
                            $(".tphone").focus();
                            dialog("请填写手机号码信息！");
                            return false;
                        }

                        if (!REG.phone.test(phone)) {
                            $(".tphone").focus();
                            dialog("请填写正确手机号码信息！");
                            return false;
                        }

                        $("#bminfo").fadeOut(10);
                        yjinfo();
                    });
                }
            });
        })

        function sholist() {
            $(".itmlist").empty();
            $.ajax({
                type: 'POST',
                url: "nbzshelper.ashx",
                data: { type: "getjpph" },
                dataType: "json",
                success: function (result) {
                    var listd = "";
                    //alert(result.count);
                    if (result.count < 1) {
                        isget1 = false;
                    } else {
                        $.each(result.result, function (i, n) {
                            listd += "<dd><span>" + n.name + "</span><span>" + n.phone + "</span><span>" + n.ords + "</span></dd><hr style=\"border: 1px dotted white; width: 90%; margin: 0 auto;margin-top: 11%;margin-bottom: 5%;\" />"
                        });
                        $(".itmlist").append(listd);
                    }
                }
            });
        }

        function showslid() {
            //            $(".slide").fadeIn(30);
            window.pageSlide = new mo.Slide({
                target: $('.slide li'),
                effect: 'push',
                playTo: 4,
                event: {
                    init: function (e) {
                        $(".l1 img").css("opacity", "1");
                        $("#l1_1").addClass("l1_1");
                        $("#l1_2").addClass("l1_2");
                        $("#l1_3").addClass("l1_3");
                        $("#l1_4").addClass("l1_4");
                        $("#l1_5").addClass("l1_5");
                        $(".arraw").show();
                    },
                    change: function () {
                        var ti = this.curPage;
                        if (ti == 0) {
                            $(".l1 img").css("opacity", "1");
                            $("#l1_1").addClass("l1_1");
                            $("#l1_2").addClass("l1_2");
                            $("#l1_3").addClass("l1_3");
                            $("#l1_4").addClass("l1_4");
                            $("#l1_5").addClass("l1_5");
                            $(".arraw").show();
                        } else {
                            $(".l1 img").css("opacity", "0");
                            $(".l1 img").removeClass();
                        }
                        if (ti == 1) {
                            $(".l2 img").css("opacity", "1");
                            $("#l2_1").addClass("l2_1");
                            $("#l2_2").addClass("l2_2");
                            $("#l2_3").addClass("l2_3");
                            $("#l2_4").addClass("l2_4");
                            $("#l2_5").addClass("l2_5");
                        } else {
                            $(".l2 img").css("opacity", "0");
                            $(".l2 img").removeClass();
                        }
                        if (ti == 2) {
                            $(".l3 img").css("opacity", "1");
                            $("#l3_1").addClass("l3_1");
                            $("#l3_2").addClass("l3_2");
                            $("#l3_3").addClass("l3_3");
                            $("#l3_4").addClass("l3_4");
                            $("#l3_5").addClass("l3_5");
                        } else {
                            $(".l3 img").css("opacity", "0");
                            $(".l3 img").removeClass();
                        }
                        if (ti == 3) {
                            $(".l4 img").css("opacity", "1");
                            $("#l4_1").addClass("l4_1");
                            $("#l4_2").addClass("l4_2");
                            $("#l4_3").addClass("l4_3");
                            $("#l4_4").addClass("l4_4");
                            $("#l4_5").addClass("l4_5");
                        } else {
                            $(".l4 img").css("opacity", "0");
                            $(".l4 img").removeClass();
                        }
                        if (ti == 4) {
                            $(".l5 img").css("opacity", "1");
                            $("#l5_1").addClass("l5_1");
                            $("#l5_2").addClass("l5_2");
                            $("#l5_3").addClass("l5_3");
                            $("#l5_4").addClass("l5_4");
                            $("#l5_5").addClass("l5_5");


                            yjinfo();
                            $(".arraw").hide();
                            //return false;
                        } else {
                            $(".l5 img").css("opacity", "0");
                            $(".l5 img").removeClass();
                            $(".arraw").show();
                        }
                    }
                }
            });
        }

        function upLoadImg(result) {
            $("#popFail .cont span").html("照片生成中...");
            $("#popFail").show();
            //return false;
            $.ajax({
                type: 'POST',
                data: { type: "AddImg", "img": result, tid: "10", stopid: $("#hid1").val() },
                url: 'nbzshelper.ashx',
                cache: false,
                dataType: 'json',
                error: function (data) {
                    $(".bg").hide();

                    $("#popFail").hide();
                    isupload = false;
                    dialog("服务器繁忙，请稍后重试！");
                },
                success: function (data) {
                    $("#popFail").hide();
                    $(".bg").hide();
                    //alert(data.count);
                    if (data.count == 2) {
                        $(".resimg").attr("src", "images/jm/" + data.result);
                        $(".s1").fadeOut(50);
                        $(".s2").fadeIn(50);
                        $("#ly1").css({ "height": $("#ly").height() });
                        return false;
                    } else {
                        dialog("生成图片失败,请重试", "alert");
                        isupload = false;
                    }
                }
            });
        }

        function uploadVoice() {
            // alert("tst");
            wx.uploadVoice({
                localId: voice.localId,
                isShowProgressTips: 1,
                success: function (res) {
                    //alert(res.serverId);
                    //把录音在微信服务器上的id（res.serverId）发送到自己的服务器供下载。
                    $.ajax({
                        type: 'POST',
                        url: "nbzshelper.ashx",
                        data: { type: "AddAudio", serverId: res.serverId, tmpid: $("#hid1").val() },
                        dataType: "json",
                        success: function (data) {
                            //alert(data);
                            if (data.count == 1) {
                                dataForWeixin.async = true;
                                dataForWeixin.url = "http://wsjhb.tencenthouse.com/zshmsg/shzsDetail.htm?tid=" + data.result;
                                dataForWeixin.desc = "给妈妈赠送的贺卡";
                                dataForWeixin.title = "一封给妈妈的不二情书";
                                $(".s2").fadeOut(30);
                                $(".s3").fadeIn(30);
                                yjinfo();
                            }
                        }, error: function (xhr, errorType, error) {
                            alert(error);
                            console.log(error);
                        }
                    });
                }
            });
        }

        //摇奖信息
        function yjinfo() {
            $(".bg").hide();
            Shake.config.shakelock = 0;
            Shake.config.SHAKE_THRESHOLD = 3000;
            Shake.Init(function () {
                if (ctindex > 0) {

                    if ("<%=iscurcj %>" == "0" && $.trim($(".tname").val()) == "") {
                        $("#bminfo").fadeIn(30);
                    } else {
                        $(".s3_1").addClass("s3_1_1");
                        $.ajax({
                            type: 'POST',
                            url: "nbzshelper.ashx",
                            data: {
                                type: "AddYJ",
                                tinfoid: $("#hid1").val(),
                                tname: $(".tname").val(),
                                tphone: $(".tphone").val(),
                                tadress: $(".taddress").val()
                            },
                            dataType: "json",
                            success: function (data) {
                                setTimeout(function () {
                                    $(".s3_1").removeClass("s3_1_1");
                                    alert(data.result);
                                    switch (data.count) {
                                        case 0:
                                            dialog("数据出错,请稍后重试！", "alert");
                                            break;
                                        case 1:
                                            dialog("抽奖时间已过，请关注！", "alert");
                                            break;
                                        case 3:
                                            $(".jpinfo").attr("src", "img/j" + data.code + ".jpg");
                                            setTimeout(function () {
                                                $(".jpinfo").show();
                                                $(".bigfx").fadeIn(50);
                                            }, 100);
                                            break;
                                    }
                                }, 1500);
                            }
                        });
                    }
                } else {
                    $("#l5_4").addClass("l5_4_1");
                    setTimeout(function () {
                        $(".slide").fadeOut(50);
                        $(".s1").fadeIn(50);
                        $(".real-btn").css("height", $(".btnadd").height());
                        $("#container").css({ "height": $(".picturemax").height() });
                        setTimeout(function () {
                            eidtor = new mo.ImageEditor({
                                trigger: $('#file'),
                                container: $('#container'),
                                width: $(".picturemax").width(),
                                height: $(".picturemax").height(),
                                stageX: $('#container')[0].offsetLeft,
                                event: {
                                    beforechange: function () {
                                        this.clear();
                                        $("#popFail .cont span").html("照片上传中...");
                                        $("#popFail").show();
                                    },
                                    change: function () {
                                        isupload = false;
                                        $("#popFail").hide();
                                        var tipsTime = setTimeout(function () {
                                            $("#markTips").hide();
                                        }, 4000);
                                        $("#markTips").show().one("touchstart", function () {
                                            $(this).hide();
                                            clearTimeout(tipsTime);
                                        });
                                    }
                                }
                            });
                        }, 100);
                    }, 2000);
                    ctindex++;
                }
            });
        }


        function dialog(msg, type) {
            window.dia1 = new mo.Dialog({
                content: msg,
                type: type
            });
        }
        function ycMp3(obj) {
            $(".u-globalAudio").removeClass("z-play play_yinfu");
            obj.pause();
        }
        function addMp3(obj) {
            $(".u-globalAudio").addClass("z-play play_yinfu");
            obj.play();
        }
     
    </script>
</body>
</html>
