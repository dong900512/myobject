<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NewInfoWeb.yhjc.index" %>

<!DOCTYPE >
<html>
<head>
    <meta charset="UTF-8">
    <title>欧洲杯 快乐竞猜 颐和有礼</title>
    <meta name="description" content="颐和有礼" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="renderer" content="webkit">
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <link href="css/index.css" rel="stylesheet" />
    <style>
       
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
        <img src="img/btnks.png" class="s1_1" />
        <button class="s1_2">关注微信</button>
        <button class="s1_3">活动详情</button>
        <button class="s1_4">奖项设置</button>

        <div class="s1_13" style="display: none;">
            温馨提示<br />
            已经有<%=tnum %>人参与活动<br />
            (根据参加人数实时更新)
       
        </div>
    </div>
    <div class="s2">
        <div class="img-slide">
            <ul class="st">
            </ul>
        </div>
        <img src="img/cleft.png" class="cleft" />
        <img src="img/cright.png" class="cright" />
        <ul class="strinfo" style="display: none;">
            <li>
                <img src="img/{2}" />
                <img src="img/s.png" class="sp1 bt1 ct_{0}" attdaid="{0}" attdata="{1}" attinfo="胜" />
                <img src="img/p.png" class="sp1 bt2 ct_{0}" attdaid="{0}" attdata="{1}" attinfo="平" />
                <img src="img/f.png" class="sp1 bt3 ct_{0}" attdaid="{0}" attdata="{1}" attinfo="败" />
            </li>
        </ul>
        <img src="img/tj.png" class="s2_1" />
        <img src="img/gz.png" class="s2_2" />
        <img src="img/hdxq.png" class="s2_3" />
    </div>
    <div class="s3">
        <img src="img/xy/5.1.png" class="s3_1" />
    </div>
    <div class="biggz">
        <img src="img/xq.png" class="imggz" />
        <div class="clos1">×</div>
    </div>
    <div class="bigjx">
        <img src="img/jx.jpg" class="imgjx" />
        <button class="btngbjx">我要竞猜</button>
    </div>
    <div class="biger">
        <img src="img/er.png" class="bimger" />
    </div>
    <div class="addinfo">
        <div class="ctinfo">
            <img src="img/tip1.png" />
            <input placeholder="姓名" class="tname" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
                onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" oncontextmenu="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" />
            <input placeholder="联系方式" type="tel" class="tphone" maxlength="11" onkeypress='return /^\d$/.test(String.fromCharCode(event.keyCode))'
                oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace(/\D+/g, "")'
                onblur='this.value = this.value.replace(/\D+/g, "")' />
            <div class="clos2">×</div>
            <img src="img/tip2.png" class="btnsure1" />
        </div>
    </div>
    <div class="jccg">
        <div class="cginfo">
            <img src="img/ctip.png" />
            <button class="btnyq">邀请助威团</button>
            <div class="cgtip">
                转发至朋友圈，每邀请一位朋友助威<br />
                即可赚得5个积分
            </div>
            <div class="ctxq">
                我的目前积分:<span style="color: red;"><%=stotal %></span><br />
                我的目前排名<span style="color: red;" class="stpm"><%=stopNum %></span>
            </div>
            <button class="btnqsjg">球赛结果</button>
            <button class="btnqsmy">我的竞猜</button>
            <button class="btnjfph">积分排行榜</button>
        </div>
    </div>
    <div class="divph">
        <dl class="itmlist">
        </dl>
        <button class="phfh">返回</button>
    </div>
    <div class="divmyjc">
        <dl class="itmlist1">
        </dl>
        <button class="jcfh">返回</button>
    </div>
    <div class="divqsjg">
        <dl class="itmlist2">
        </dl>
        <button class="jgfh">返回</button>
    </div>
    <img class="bigfx" src="/lninfo/img/xy/bigfx.png" />
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
        dataForWeixin.title = "欧洲杯 快乐竞猜 颐和有礼";
        dataForWeixin.desc = "欧洲杯 快乐竞猜 颐和有礼";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/yhjc/img/fxs.jpg";
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
            if (isget) {
                pageindex++;
                loadinfolist(pageindex);
            }
            ticking = false;
        }
        document.body.addEventListener('touchmove', function (evt) {
            if (!evt._isScroller) {
                evt.preventDefault()
            }
        })
        var overscroll = function (el) {
            el.addEventListener('touchstart', function () {
                var top = el.scrollTop
                  , totalScroll = el.scrollHeight
                  , currentScroll = top + el.offsetHeight
                if (top === 0) {
                    el.scrollTop = 1
                } else if (currentScroll === totalScroll) {
                    el.scrollTop = top - 1
                }
            })
            el.addEventListener('touchmove', function (evt) {
                if (el.offsetHeight < el.scrollHeight)
                    evt._isScroller = true
            })
        }
        var sourceArr = ['img/1.jpg', 'img/er.png', 'img/jx.jpg', 'img/xq.png'];
        new mo.Loader(sourceArr, {
            onLoading: function (count, total) {
                gid('loading_per').innerHTML = Math.floor(count / total * 100) + "%";
                //alert('加载中...（'+count/total*100+'%）');
            }, onComplete: function (time) {
                gid("loading").parentNode.removeChild(gid("loading"));
                //var myVideo = document.getElementById("ttnb");
                //LoadAud(myVideo, "img/xy/4.mp3");
                $(".s1,.biggz,.imggz,.bigjx,.imgjx,.bg,.addinfo,.s2,.bigfx,.divph,.s3,.s4,.s5,.s6,.biger,.jccg,.divqsjg,.divmyjc").css({ width: ww, height: hh });
                if ("<%=isx%>" == "1") {
                    dataForWeixin.async = true;
                    dataForWeixin.title = "我正在参加欧洲杯 快乐竞猜 颐和有礼活动！"
                    dataForWeixin.desc = "欧洲杯 快乐竞猜 颐和有礼活动？赶快来帮忙吧！";
                    dataForWeixin.url = "http://wsjhb.tencenthouse.com/yhjc/yhdzinfo.aspx?tid=<%=tid%>"
                }
                $(".s1_1").on("touchstart", function () {
                    if ("<%=isx%>" == "1") {
                        //alert( );|| "<%=isbs%>" == "2"
                        if ("<%=isjc%>" == "1") {
                            $(".jccg").show();
                            //$(".s2_1").hide();
                        }
                        $(".s1").hide();
                        $(".s2").fadeIn("slow");
                    } else {
                        //出现报名信息
                        $(".addinfo").fadeIn(30);
                    }
                });
                GetBannerList();
                $(".btnyq").on("touchstart", function () {
                    $(".bigfx").fadeIn(10);
                });
                $(".bigfx").on("touchstart", function () {
                    $(".bigfx").fadeOut(10);
                });
                $(".btnqsjg").on("touchstart", function () {
                    getQS();
                    $(".divqsjg").fadeIn(30);
                });
                $(".btnqsmy").on("touchstart", function () {
                    getMyJC();
                    $(".divmyjc").fadeIn(30);
                });
                overscroll(document.querySelector('.itmlist2'));
                overscroll(document.querySelector('.itmlist1'));
                overscroll(document.querySelector('.itmlist'));
                $(".btnjfph").on("touchend", function () {
                    $(".bg").show();
                    loadinfolist(0);
                    setTimeout(function () {
                        $(".divph").show();
                        $(".bg").hide();
                    }, 300);
                });
                $(".phfh").on("touchend", function () {
                    ticking = false;
                    pageindex = 0;
                    isget = true;
                    countp = 0;
                    $(".itmlist").scrollTop(0);
                    $(".itmlist").empty();
                    $(".divph").hide();
                });
                $(".jgfh").on("touchend", function () {
                    $(".itmlist2").scrollTop(0);
                    $(".divqsjg").fadeOut(30);
                });
                $(".jcfh").on("touchend", function () {
                    $(".itmlist1").scrollTop(0);
                    $(".divmyjc").fadeOut(30);
                });
                $(".s2_1").on("touchstart", function () {
                    //提交竞猜
                    var tlength = $(".st li").length;
                    var tsend = $(".sp1_1").length;
                    if (tlength == 0) {
                        showDialog("暂无比赛,你可以邀请朋友助威来获取积分", "alert");
                        if ("<%=isbs%>" == "2") {
                            $(".jccg").show();
                        }
                        return false;
                    } else {
                        if ("<%=sjdjc%>" == "0") {
                            showDialog("请在规定时间内进行投票", "alert");
                            $(".jccg").show();
                            return false;
                        } else {
                            if (tsend < tlength) {
                                showDialog("请选择所有比赛后提交", "alert");
                                return false;
                            } else {
                                var tlist = "";
                                for (var i = 0; i < tsend; i++) {
                                    tlist += $(".sp1_1").eq(i).attr("attdata") + "," + $(".sp1_1").eq(i).attr("attdaid") + "," + $(".sp1_1").eq(i).attr("attinfo") + "|";
                                }
                                $(".bg").show();
                                window.overlay1 = new mo.Overlay({
                                    content: "竞猜信息提交中，请稍后...",
                                    valign: 'top',
                                    offset: [0, 10]
                                });
                                // alert(tlist);
                                $.ajax({
                                    type: 'post',
                                    url: 'helper.ashx',
                                    dataType: 'json',
                                    data: { type: "AddJCInfo", tinfo: tlist },
                                    success: function (data) {
                                        //alert(data.count)
                                        overlay1.close();
                                        $(".bg").hide();
                                        if (data.count == 2) {
                                            //竞猜成功
                                            $(".jccg").show();
                                        } else if (data.count == 3) {
                                            showDialog("当前时间段不允许竞猜", "alert");
                                        }
                                        else {
                                            //竞猜失败
                                            showDialog("竞猜失败", "alert");
                                        }
                                    }
                                });
                            }
                        }
                    }
                });
                $(".clos2").tap(function (e) {
                    $(".tname").val("");
                    $(".tphone").val("");
                    $(".addinfo").fadeOut(30);
                });
                $(".s1_2,.s2_2").on("touchstart", function () {
                    $(".biger").fadeIn("30");
                });
                $(".biger").tap(function () {
                    $(".biger").fadeOut("30");
                });
                $(".s1_3,.s2_3").on("touchstart", function () {
                    $(".biggz").fadeIn("30");
                });
                $(".clos1").tap(function () {
                    $(".biggz").fadeOut("30");
                });
                $(".s1_4").on("touchstart", function () {
                    $(".bigjx").fadeIn("30");
                });
                $(".btngbjx").tap(function () {
                    $(".bigjx").fadeOut("30");
                });

                $(".btnsure1").on("touchstart", function () {
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
                    $(".btnsure1").attr("disabled", "disabled");
                    $(".bg").show();
                    window.overlay1 = new mo.Overlay({
                        content: "信息提交中，请稍后...",
                        valign: 'top',
                        offset: [0, 10]
                    });
                    $.ajax({
                        type: 'post',
                        url: 'helper.ashx',
                        dataType: 'json',
                        data: {
                            type: "addBmInfo", tname: name, tphone: phone
                        },
                        success: function (data) {
                            overlay1.close();
                            $(".bg").hide();
                            if (data.count == "2") {
                                //alert(data.result);
                                $("#hidid").val(data.code);
                                $(".stpm").text(data.result);
                                showDialog("信息提交成功!", "success");
                                dataForWeixin.async = true;
                                dataForWeixin.title = "我正在参加欧洲杯 快乐竞猜 颐和有礼活动！"
                                dataForWeixin.desc = "欧洲杯 快乐竞猜 颐和有礼活动？赶快来帮忙吧！";
                                dataForWeixin.url = "http://wsjhb.tencenthouse.com/yhjc/yhdzinfo.aspx?tid=" + data.code;
                                $(".addinfo").fadeOut("slow", function () {
                                   <%-- alert("<%=isbs%>");
                                    if ("<%=isbs%>" == "2") {
                                        $(".jccg").show();
                                        //$(".s2_1").hide();
                                    }--%>
                                    $(".s1").hide();
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
                    $(".btnsure1").removeAttr("disabled");
                });
                return false;
            }
        });
        function showDialog(msg, type) {
            window.dia1 = new mo.Dialog({
                content: msg,
                type: type
            });
        }
        function GetBannerList() {
            $.post("helper.ashx", { type: "getXMlist" }, function (result) {
                var listd = "";
                if (parseInt(result.count) < 1) {
                    $(".cleft,.cright").hide();
                } else {
                    $.each(result.result, function (i, n) {
                        listd += String.format($(".strinfo").html(), n.id, n.sjd + "--" + n.gj
                            , n.img);// "<li><img src=\"" + n.img + "\" /></li>";
                    });
                    //alert(listd);
                    $(".st").append(listd);
                    window.imgSlide = new mo.Slide({
                        target: $('.img-slide li'),
                        direction: 'x',
                        loop: true
                    })
                    $(".cleft").on("touchstart", function (e) {
                        imgSlide.prev();
                    });
                    $(".cright").on("touchstart", function (e) {
                        imgSlide.next();
                    });
                    $(".sp1").on("touchstart", function () {
                        //alert("123");
                        if ($(this).hasClass("sp1_1")) {

                        } else {
                            $(this).siblings(".sp1").removeClass("sp1_1");
                            $(this).addClass("sp1_1");
                            imgSlide.next();
                        }
                    });
                }
            }, "json");
        }
        function loadinfolist(page) {
            if (page == 0) {
                $(".itmlist").empty();
            }
            $.post("helper.ashx", { type: "yhPgList", tmppage: page, pagesize: "10" }, function (result) {
                var listd = "";
                //alert(result.count);
                //alert(result.count);
                if (parseInt(result.count) < 1) {
                    isget = false;
                } else {
                    $.each(result.result, function (i, n) {
                        ++countp;
                        //alert(countp);
                        listd += "<dd><span>No." + countp + "</span><span>" + n.nickname + "</span><span><img src=\"" + n.img + "\"/>积分" + n.nums + "</span><hr class=\"clearinfo\"/></dd>"
                    });
                    //alert(listd);
                    $(".itmlist").append(listd);
                    $(".itmlist").scrollTop(0);
                }
            }, "json");
        }
        function getQS() {
            //
            $(".itmlist2").empty();
            $.post("helper.ashx", { type: "getQSJG" }, function (result) {
                var listd = "";
                //alert(result.count);
                //alert(result.count);
                if (parseInt(result.count) < 1) {

                } else {
                    $.each(result.result, function (i, n) {
                        var img = "";
                        switch (n.sb) {
                            case "": break;
                            case "胜":
                                img = "<img src='img/s.png'/>";
                                break;
                            case "平":
                                img = "<img src='img/p.png'/>";
                                break;
                            case "败":
                                img = "<img src='img/f.png'/>";
                                break;
                        }
                        listd += "<dd><span>" + n.sjd + "--" + n.gj + "</span><span>" + img + "</span></dd>"
                    });
                    //alert(listd);
                    $(".itmlist2").append(listd);
                    $(".itmlist2").scrollTop(0);
                }
            }, "json");
        }
        function getMyJC() {
            $(".itmlist1").empty();
            $.post("helper.ashx", { type: "getmyJC" }, function (result) {
                var listd = "";
                //alert(result.count);
                //alert(result.count);
                if (parseInt(result.count) < 1) {

                } else {
                    $.each(result.result, function (i, n) {
                        var img = "";
                        var sta = n.sy == "0" ? "" : (n.sy == "1" ? "√" : "×");
                        switch (n.jc) {
                            case "胜":
                                img = "<img src='img/s.png'/>";
                                break;
                            case "平":
                                img = "<img src='img/p.png'/>";
                                break;
                            case "败":
                                img = "<img src='img/f.png'/>";
                                break;
                        }
                        listd += "<dd><span>" + n.sjd + "</span><span>" + img + "</span><span>" + sta + "</span></dd>";
                    });
                    //alert(listd);
                    $(".itmlist1").append(listd);
                    $(".itmlist1").scrollTop(0);
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

