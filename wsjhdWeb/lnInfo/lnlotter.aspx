<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lnlotter.aspx.cs" Inherits="NewInfoWeb.lnInfo.lnlotter1" %>

<!DOCTYPE>
<html>
<head>
    <meta charset="utf-8">
    <title>龙湖大转盘抽奖</title>
    <meta name="description" content="龙湖大转盘抽奖" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <style>
        @-webkit-keyframes fade1 {
            0% { opacity: .5; }
            100% { opacity: 1; }
        }

        body { width: 100%; height: 100%; }

        .box1 { position: absolute; left: 0; top: 0; width: 100%; z-index: 100; }
        .box1_1 { position: fixed; width: 100%; height: 100%; left: 0px; top: 0px; -webkit-transition: opacity 0.3s linear; transition: opacity 0.3s linear; opacity: 1; z-index: 999; background-color: rgba(0, 0, 0, 0.498039); display: table; pointer-events: none; }
        .box1_2 { display: table-cell; vertical-align: middle; text-align: center; }
        .box1_info { position: relative; display: inline-block; text-align: left; pointer-events: auto; }
        ::-webkit-input-placeholder { color: gainsboro; }
        input { width: 76%; height: 30px; line-height: 30px; left: 0; background-color: white; color: black; font-size: 1.1rem; font-weight: bold; padding-left: 20px; border: 1px solid #6a3906; border-radius: 8px; }
        .tname { margin-top: 2px; }
        .sex { margin-top: 10px; }
        .tphone { margin-top: 2px; }
        .btnsure { z-index: 4; border: 0px; left: 0; width: 60%; margin-top: 4%; margin-bottom: 4%; }

        #mnum, #mnum1 { z-index: -3; position: absolute; }
        .mnum { width: 15%; z-index: 4 !important; text-align: center; left: 25%; font-size: 1.2rem; color: #f1d47e; -webkit-animation: zoomIn 1s 1.3s linear both; }
        .mnum1 { width: 15%; z-index: 4 !important; text-align: center; left: 60%; font-size: 0.8rem; color: #f1d47e; -webkit-animation: zoomIn 1s 1.3s linear both; }
        .bg { position: absolute; width: 100%; height: 100%; z-index: 800; top: 0; left: 0; display: none; }
        .bg1 { position: absolute; width: 100%; height: 100%; z-index: 800; top: 0; left: 0; background-color: rgba(0,0,0,.6); display: none; }
        .bg2 { position: absolute; width: 100%; height: 100%; z-index: 800; top: 0; left: 0; background-color: rgba(0,0,0,.6); display: none; }
        .spinfo { position: absolute; width: 100%; height: 100%; z-index: 100; top: 0; left: 0; display: none; background-color: rgba(0,0,0,.5); }
        #sp { position: absolute; top: 33%; left: 10%; width: 80%; height: auto; }

        .flash { position: absolute; bottom: 21%; left: 10%; }
        .swfcontent_hover { background-size: 100% 100%; }
        .swfcontent_start { }
            .swfcontent_start:hover { -webkit-transform: scale(1); }
        .main1 { position: relative; width: 100%; height: 100%; overflow: hidden; background: url(lot/bg.jpg); background-size: 100% 100%; }
        .tip { position: absolute; bottom: 10%; width: 40%; left: 30%; }
        .ctc { position: absolute; width: 70%; top: 50%; left: 50%; -webkit-transform: translate(-50%,-50%); }
            .ctc img { max-width: 100%; }
        .stjp { position: absolute; bottom: 54%; width: 100%; text-align: center; font-weight: bold; }
        .btnlq { width: 60%; /* margin-left: 35%; */ position: absolute; bottom: 16%; left: 20%; }

        .btnqr { width: 60%; /* margin-left: 35%; */ position: absolute; bottom: 11%; left: 20%; }
        .tname { position: absolute; bottom: 56%; left: 12%; }
        .tphone { margin-top: 2px; position: absolute; bottom: 37%; left: 12%; }
        .zjbh { position: absolute; bottom: 34%; width: 100%; text-align: center; color: black; font-weight: bold; }
    </style>
</head>
<body marginwidth="0" marginheight="0">
    <script src="js/thelper.js" type="text/javascript"></script>
    <header class="app-header" style="display: none;">
        <a href="javascript:void(0);" class="u-globalAudio z-play">
            <audio src="" loop="" src="" id="ttnb" autoplay="" preload type="audio/mpeg">
            </audio>
        </a>
    </header>
    <div class="main1">
        <div class="flash">
            <div id="swfcontent">
            </div>
        </div>
        <img src="lot/tip.png" class="tip" />
    </div>
    <div class="bg">
    </div>
    <div class="bg1">
        <div class="ctc">
            <img src="lot/tc.png" />
            <span class="stjp"></span>
            <span class="zjbh"></span>
            <img src="lot/btnlq.png" class="btnlq" />
        </div>
    </div>
    <div class="bg2">
        <div class="ctc">
            <img src="lot/tc1.png" />
            <input type="text" class="tname" placeholder="请输入姓名" />
            <input type="tel" class="tphone" placeholder="请输入手机号码" />
            <img src="lot/btnlq.png" class="btnqr" />
        </div>
    </div>
    <input type="hidden" id="hid1" />
    <input type="hidden" id="hid2" value="0" />
    <script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/loader.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/pc-prompt.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/film.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/dialog.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/overlay.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/slide.v2.0.min.js"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/lottery.min.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.PCPrompt = new mo.PCPrompt();
        dataForWeixin.title = "龙湖大转盘";
        dataForWeixin.desc = "龙湖大转盘";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/lnInfo/lot/fxs.jpg";
        this.flag = !0;
        this.shadeFlag = !1;
        this.shadeFlag1 = !0;
        var n = 0, a = 0;
        var isflag = 0;
        var cods = 0;
        var codnum;
        var ICode;
        var REG = {
            name: /^[a-zA-Z\u4e00-\u9fa5]{2,12}$/,
            phone: /(^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$)|(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/,
            wxid: /^[a-zA-Z][a-zA-Z0-9_-]{5,19}$/,
            number: /^[+\-]?\d+(\.\d+)?$/,
            idCard: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/
        }
        var ww = $(window).width();
        var hh = $(window).height();
        var coud = 0;
        $(function () {
            var sourceArr = ['lot/5555.png', 'lot/z.png', 'lot/bg.jpg'];
            new mo.Loader(sourceArr, {
                onLoading: function (count, total) {
                    gid('loading_per').innerHTML = Math.floor(count / total * 100) + "%";
                    //alert('加载中...（'+count/total*100+'%）');
                }, onComplete: function (time) {
                    gid("loading").parentNode.removeChild(gid("loading"));
                    //var myVideo = document.getElementById("ttnb");
                    // LoadAud(myVideo, "img/dd/1.mp3");
                    $(".bminfo").css({ top: hh * 430 / 1008 });

                    $(".s1,.main1,.bg,.biggz,.bigfx,#bminfo,.main1,.st2,.spinfo,.zjmd,.jpinfo,.biggz1").css({ width: ww, height: hh });
                    if ("<%=ispic %>" == "1") {
                        if ("<%=isexit%>" == "1") {
                            if ("<%=isname%>" == "1") {
                                $(".btnlq").hide();
                                $(".zjbh").text("奖品编号：<%=jpcode%>");
                                $(".stjp").text("<%=jpinfo%>");
                                $(".bg1").fadeIn("300");
                            } else {
                                $(".zjbh").text("奖品编号：<%=jpcode%>");
                                $(".stjp").text("<%=jpinfo%>");
                                $(".bg1").fadeIn("300");
                            }
                        }
                    } else {
                        dialog("活动时间已过,请继续关注！", "alert");
                    }
                    $(".btnlq").tap(function () {
                        $(".bg1").fadeOut("30", function () {
                            $(".bg2").fadeIn("30");
                        })
                    });
                    $(".btnqr").tap(function () {
                        var tname = $.trim($(".tname").val()) || "";
                        var tphone = $.trim($(".tphone").val()) || "";
                        if (tname == "" || tname == null) {
                            shtip("请填写姓名信息");
                            return false;
                        }
                        if (tphone == "" || tphone == null) {
                            shtip("请填写手机号码信息");
                            return false;
                        }
                        if (!REG.phone.test(tphone)) {
                            shtip("请填写正确的手机号码信息");
                            return false;
                        }
                        window.overlay1 = new mo.Overlay({
                            content: "信息提交中...",
                            valign: 'top',
                            offset: [0, 10]
                        });
                        $(".bg").show();
                        $.ajax({
                            type: 'POST',
                            url: "lnlotter.ashx",
                            data: {
                                type: "tjinfo",
                                tname: tname,
                                tphone: tphone
                            },
                            dataType: "json",
                            success: function (data) {
                                overlay1.close();
                                $(".bg").hide();
                                if (data.count == 0) {
                                    shtip("请重新提交");
                                    return false;
                                } else if (data.count == 1) {
                                    shtip("用户信息提交成功");
                                    $(".btnlq").hide();
                                    $(".bg2").fadeOut("30", function () {
                                        $(".bg1").fadeIn("30");
                                    })
                                    return false;
                                } else {
                                    shtip("不存在奖品数据");
                                    return false;
                                }
                            }
                        });
                    });
                }
            });
        })

        function shtip(msg) {
            window.overlay1 = new mo.Overlay({
                content: msg,
                valign: 'top',
                offset: [0, 10],
            });
            overlay1.on('open', function () {
                var self = this;
                window.setTimeout(function () {
                    self.close();
                }, 800);
            })
        }

        function dialog(msg, type) {
            window.dia1 = new mo.Dialog({
                content: msg,
                type: type
            });
        }

        function GetLotter() {
            $(".bg").show();
            //callFlashToRoll(2);
            //return false;
            window.overlay1 = new mo.Overlay({
                content: "抽奖中，请稍后...",
                valign: 'top',
                offset: [0, 10]
            });
            $.ajax({
                type: 'POST',
                url: "lnlotter.ashx",
                data: {
                    type: "cj"
                },
                dataType: "json",
                success: function (data) {
                    overlay1.close();
                    switch (data.count) {
                        case 0:
                            dialog("数据出错,请稍后重试！", "alert");
                            break;
                        case 1:
                            dialog("抽奖时间已过，请关注！", "alert");
                            break;
                        case 3:
                            cods = data.result.jpid;
                            ICode = data.code;
                            codnum = data.result.jp;
                            callFlashToRoll(cods);
                            break;
                    }
                }
            });
        }
        function callJsToStart() {
            if ("<%=ispic %>" == "1") {
                if ("<%=isexit%>" == "1") {
                    if ("<%=isname%>" == "1") {
                        $(".btnlq").hide();
                        $(".stjp").text("<%=jpinfo%>");
                        $(".bg1").fadeIn("300");
                    } else {
                        $(".stjp").text("<%=jpinfo%>");
                        $(".bg1").fadeIn("300");
                    }
                } else {
                    GetLotter();
                }
            } else {
                dialog("活动时间已过,请继续关注！", "alert");
            }
        }
        //开发获得抽奖结果 通知flash开始播放效果 js->flash
        function callFlashToRoll(id) {
            //通知转盘转到对应的中奖产品的id （序号从0,1,2.....，0是指针初始指示的位置，沿着顺时针的方向递增）
            if (SWFOBJ) {
                SWFOBJ.stopRoll(id);
            }
        }
        //3、flash动画完成通知js  flash->js
        function callJsToComplete() {
            $(".stjp").text(codnum);
            $(".zjbh").text("奖品编号：" + ICode);
            $(".bg1").fadeIn("300");
            //$(".jpimg").attr("src", "img/ln2/j" + cods + ".png");
            //$(".jpnum").text("编号：" + codnum);
            //$(".jpinfo").fadeIn(50);
        }
        //初始化抽奖对象的SWFOBJ
        //转盘的中心点坐标为（0,0））
        var SWFOBJ = new mo.Lottery({
            'flashUrl': 'http://ossweb-img.qq.com/images/flash/lottery/circle/lotteyround_2013_v1.swf',
            'r': 6, //奖品总数
            'width': ww * 0.8, //flash宽度
            'height': ww * 0.8, //flash高度
            'flashFirst': false,
            'b': '/lnInfo/lot/5555.png', //圆盘的图片 文件格式可以是swf、png、jpg（建议swf 可以压缩）
            's': '/lnInfo/lot/z.png', //开始抽奖按钮图片
            'bx': 0, //圆盘的图片位置x坐标 （转盘的中心点坐标为（0,0））
            'by': 0, //圆盘的图片位置y坐标
            'sx': 0, //开始抽奖按钮x坐标
            'sy': 0, //开始抽奖按钮y坐标
            'contentId': 'swfcontent', //嵌入swf 的div层的 id 
            'onClickRollEvent': callJsToStart, //对应上面接口
            'onCompleteRollEvent': callJsToComplete //对应上面接口
        });    </script>
</body>
</html>

