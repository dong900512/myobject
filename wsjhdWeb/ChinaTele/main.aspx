<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="NewInfoWeb.ChinaTele.main" %>

<!DOCTYPE html>
<html lang="zh-cn">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1">
    <title>中国电信国际业务推介会</title>
    <link href="/zui/css/zui.min.css" rel="stylesheet" />
    <!-- <link href="css/swiper.min.css" rel="stylesheet" type="text/css" />-->
    <!--[if lt IE 9]>
      <script src="/zui/lib/ieonly/html5shiv.js"></script>
      <script src="/zui/lib/ieonly/respond.js"></script>
      <script src="/zui/lib/ieonly/excanvas.js"></script>
    <![endif]-->
    <style>
        body { display: block !important; background-color: black; max-width: 640px; margin: 0 auto; }
        ::-webkit-scrollbar { width: 0px; height: 0px; }

        @-webkit-keyframes fad1 {
            0% { opacity: .4; }
            100% { opacity: 1; }
        }

        .btnqd { width: 50%; margin-left: 25%; margin-top: -21%; }
        .s2, .s3, .s4, .s5, .s6 { position: relative; display: none; top: 0; left: 0; }
        .btnfh { margin-top: -12%; width: 50%; margin-left: 25%; }
        .tips1 { position: absolute; width: 100%; text-align: center; top: 49%; color: white; font-size: 1.6rem; font-family: 微软雅黑; }
        .txtyzm { position: absolute; width: 70%; left: 15%; text-align: center; border-radius: 5px; border: 0; top: 60%; height: 40px; line-height: 40px; font-size: 3rem; }
        .btnqr1 { position: absolute; border: none; width: 30%; background-color: #e95513; color: white; height: 45px; top: 80%; font-size: 2.2rem; border-radius: 8px; left: 18%; }



        .tname { font-size: 3rem; }
        .tgs { font-size: 2rem; margin-bottom: 7%; }
        .tips2 { color: #b2b2b2; font-size: 1.6rem; margin-bottom: 3%; }
        .yzm { font-size: 2rem; }
        .tips3 { color: #b2b2b2; font-size: 1.6rem; margin-top: 3%; margin-bottom: 5%; }
        .btnqr2 { position: absolute; border: none; width: 30%; background-color: #e95513; color: white; height: 45px; font-size: 2.2rem; border-radius: 8px; left: 15%; margin-bottom: 10%; }

        .s1 { position: relative; }
        .s1_tips { position: absolute; width: 85%; top: 55%; left: 7.5%; }
        .s1_1 { margin-bottom: 5%; }
        .s1_2 { margin-bottom: 5%; }
        .s1_3 { margin-bottom: 5%; }
        .s1_4 { margin-bottom: 5%; }
        .s1_5 { position: absolute; width: 20%; right: 0; bottom: 38%; -webkit-animation: fad1 1s ease infinite alternate; }
        .btnfh1 { border: none; background-color: #e95513; width: 40%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; margin-bottom: 9%; }

        .s2 { text-align: center; }
        .tinfo { position: absolute; text-align: center; width: 85%; left: 7.5%; top: 32%; color: white; }

        .btnfh2 { border: none; background-color: #e95513; width: 40%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; margin-top: 3%; margin-bottom: 9%; }
        .tinfo a { display: inline-block; }
        .tcont { position: absolute; width: 94%; color: white; top: 25%; left: 3%; }
            .tcont button { min-width: 30%; background-color: white; border-radius: 4px; border: none; margin-bottom: 5%; }
        .ct { font-size: 1.3rem; }
        .ctdsc { margin: 5% 0 0 3%; }
        .i1 { background-color: white; border-radius: 4px; border: none; margin-bottom: 5%; }
            .i1:nth-child(odd) { float: left; }
            .i1:nth-child(even) { float: right; }

        .btncur { background-color: #e95513 !important; color: white; }
        .i2:nth-child(2) { margin: 0 3.5%; }
        .i3:nth-child(2) { margin: 0 3.5%; }
        .i4:nth-child(2) { margin: 0 2%; }
        .i5:nth-child(2) { margin-left: 23%; }
        .btntj3 { border: none; background-color: #e95513 !important; margin: 3% 6.6% 9% 6.6%; width: 40%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; margin-bottom: 11% !important; }
        .btnfh3 { border: none; background-color: #e95513 !important; width: 40%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; margin-top: 3%; margin-bottom: 9%; }
        .s5info { position: absolute; text-align: center; width: 85%; left: 7.5%; top: 33%; }
        .btnfh4 { border: none; background-color: #e95513 !important; width: 40%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; margin-top: 3%; margin-bottom: 9%; }
        .stcode { color: white; font-size: 2rem; }

        .s6info { position: absolute; text-align: center; width: 85%; left: 7.5%; top: 40%; }
        .btntj5 { border: none; background-color: #e95513 !important; margin: 6% 6.6% 9% 0; width: 40%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; margin-bottom: 11% !important; }
        .btnfh5 { border: none; background-color: #e95513 !important; width: 40%; color: white; height: 45px; border-radius: 8px; font-size: 2.2rem; margin-top: 3%; margin-bottom: 9%; }
        textarea { border-radius: 5px; border: 1px solid #CCC6C6; resize: none; padding-left: 5px; line-height: 22px; }
        #txtcontent { width: 100%; }
    </style>
</head>
<body>
    <div id="grid">
        <div class="s1">
            <img src="img/xq/4.jpg" />
            <div class="s1_tips">
                <img src="img/xq/t1.png" class="s1_1" />
                <img src="img/xq/t2.png" class="s1_2" />
                <img src="img/xq/t3.png" class="s1_3" />
                <img src="img/xq/t4.png" class="s1_4" />
                <img src="img/xq/tips.png" class="s1_5" />
            </div>
        </div>
        <div class="s2">
            <img src="img/xq/5.jpg" />
            <button class="btnfh1">返回</button>
        </div>
        <div class="s3">
            <img src="img/xq/6.jpg" />
            <div class="tinfo">
                <%-- onclick="javascript:shTips();" download="img/xq/4.pdf"--%>
                <a href="img/xq/1.pdf" target="_self">
                    <img src="img/xq/s3_1.png" /></a>
                <a href="img/xq/2.pdf" target="_self">
                    <img src="img/xq/s3_2.png" /></a>
                <a href="img/xq/3.pdf" target="_self">
                    <img src="img/xq/s3_3.png" /></a>
                <a href="img/xq/4.pdf" target="_self" style="width: 107%;">
                    <img src="img/xq/s3_4.png" /></a>
                <button class="btnfh2">返回</button>
            </div>
        </div>
        <div class="s4">
            <img src="img/xq/7.jpg" />
            <div class="tcont">
                <div class="ct">1.贵司目前的IT需求，重点侧重以下哪一部分：</div>
                <div class="ctdsc">
                    <div>
                        <button class="i1">国际电路</button>
                        <button class="i1">境外数据中心</button>
                        <div style="clear: both;"></div>
                    </div>
                    <div>
                        <button class="i1">境外信息化解决方案</button>
                        <button class="i1">移动国际漫游</button>
                        <div style="clear: both;"></div>
                    </div>

                </div>
                <div class="ct">2.贵司认为目前中国电信国际业务的竞争优势是以下哪一部分：</div>
                <div class="ctdsc">
                    <button class="i2">价格</button>
                    <button class="i2">质量</button>
                    <button class="i2">服务</button>
                </div>
                <div class="ct">3.贵司认为市场上和中国电信同质化产品和服务的竞争对手是：</div>
                <div class="ctdsc">
                    <button class="i3">境外运营商</button>
                    <button class="i3">境内运营商</button>
                    <button class="i3">代理商</button>
                </div>
                <div class="ct">4.贵司对于中国电信的整体服务水平能力的评价认可度最高的是哪一部分：</div>
                <div class="ctdsc">
                    <button class="i4">售前解决方案</button>
                    <button class="i4">售中开通支付</button>
                    <button class="i4">售后运营服务</button>
                </div>
                <div class="ct">5.贵司目前全球组网的产品和业务中需要提升改进的部分是：</div>
                <div class="ctdsc">

                    <button class="i5">境外网络访问加速</button>
                    <button class="i5">故障处理的效率</button>
                    <button class="i5">境外分支机构的整体IT解决方案</button>
                </div>
                <button class="btntj3">提交</button>
                <button class="btnfh3">返回</button>
            </div>
        </div>
        <div class="s5">
            <img src="img/xq/8.jpg" />
            <div class="s5info">
                <img src="img/xq/er.png" />
                <div class="stcode"><%= tmpcode%></div>
                <button class="btnfh4">返回</button>
            </div>
        </div>
        <div class="s6">
            <img src="img/xq/9.jpg" />
            <div class="s6info">
                <textarea id="txtcontent" style="height: 300px;"></textarea>
                <button class="btntj5">提交</button>
                <button class="btnfh5">返回</button>
            </div>
        </div>
    </div>
    <input type="hidden" id="hidTJ" value="<%=tmpdcwj %>" />
</body>

<script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
<script src="http://ossweb-img.qq.com/images/js/motion/dialog.min.js"></script>
<script src="http://ossweb-img.qq.com/images/js/motion/overlay.min.js"></script>
<script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
<script src="/js/share.js" type="text/javascript"></script>
<script type="text/javascript">
    dataForWeixin.img = "http://wsjhb.tencenthouse.com/chinatele/img/fxs.jpg";
    dataForWeixin.desc = "中国电信国际业务推介会";
    dataForWeixin.title = "中国电信国际业务推介会";
    dataForWeixin.isWXShare = false;
    //document.body.addEventListener('touchmove', function (evt) {
    //    //In this case, the default behavior is scrolling the body, which
    //    //would result in an overflow.  Since we don't want that, we preventDefault.
    //    if (!evt._isScroller) {
    //        evt.preventDefault()
    //    }
    //});
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
    $(function () {
       <%-- alert("<%=tmpstr%>");--%>
        //overscroll(document.querySelector('.s2'));
        //overscroll(document.querySelector('.s3'));
        //overscroll(document.querySelector('.s3'));
        //overscroll(document.querySelector('.s2'));


        //$(".s1").fadeOut();
        //$(".s3").fadeIn();
        $(".s1_1").on("touchstart", function () {
            gotoTop();
            $(".s1").fadeOut("slow", function () {
                $(".s2").fadeIn();
            });
        });
        $(".s1_2").on("touchstart", function () {
            gotoTop();
            $(".s1").fadeOut("slow", function () {
                $(".s3").fadeIn();
            });
        });
        $(".s1_3").on("touchstart", function () {
            gotoTop();
            if ($("#hidTJ").val() == "1") {
                $(".s1").fadeOut("slow", function () {
                    $(".s5").fadeIn();
                });
            } else {
                $(".s1").fadeOut("slow", function () {
                    $(".s4").fadeIn();
                });
            }
        });
        $(".s1_4").on("touchstart", function () {
            gotoTop();
            $(".s1").fadeOut("slow", function () {
                $(".s6").fadeIn();
            });
        });
        $(".btnfh1").tap(function () {
            gotoTop();
            $(".s2").fadeOut("slow", function () {
                $(".s1").fadeIn("10");
            });
        });
        $(".btnfh2").on("touchstart", function (e) {
            gotoTop();
            $(".s3").fadeOut("slow", function () {
                $(".s1").fadeIn("10");
            });
        });
        $(".i1,.i2,.i3,.i4,.i5").tap(function () {
            if ($(this).hasClass("btncur")) {
                $(this).removeClass("btncur");
            } else {
                $(this).addClass("btncur");
            }
        });
        $(".btnfh3").on("touchstart", function () {
            gotoTop()
            $(".i1,.i2,.i3,.i4,.i5").removeClass("btncur");
            $(".s4").fadeOut("slow", function () {
                $(".s1").fadeIn("10");
            });
        });
        $(".btnfh4").tap(function () {
            gotoTop();
            $(".s5").fadeOut("slow", function () {
                $(".s1").fadeIn("10");
            });
        });
        $(".btnfh5").tap(function () {
            gotoTop();
            $("#txtcontent").val("");
            $(".s6").fadeOut("slow", function () {
                $(".s1").fadeIn("10");
            });
        });
        $(".btntj5").tap(function () {
            var tcont = $.trim($("#txtcontent").val());
            if (tcont == "" || tcont == null) {
                showDialog("请填写信息后提交", "alert");
                return false;
            }
            window.overlay1 = new mo.Overlay({
                content: "提交中，请稍后...",
                valign: 'top',
                offset: [0, 10]
            });
            $.ajax({
                url: "helper.ashx",
                type: "post",
                data: { type: "tjjy", tname: "<%=tmpstr%>", tmsg: tcont },
                dataType: "json",
                success: function (data) {
                    overlay1.close();
                    if (data.ist == "1") {
                        $("#txtcontent").val("");
                        gotoTop();
                        //$(".s4").fadeOut("slow", function () {
                        //    $(".s5").fadeIn("10");
                        //});
                    } else {
                        showDialog("请重新提交信息", "alert");
                    }
                }
            });
        });
        $(".btntj3").tap(function () {
            var t1 = $(".i1.btncur").length;
            var t2 = $(".i2.btncur").length;
            var t3 = $(".i3.btncur").length;
            var t4 = $(".i4.btncur").length;
            var t5 = $(".i5.btncur").length;
            //alert(t1 + "!" + t2 + "!" + t3 + "!" + t4 + "!"+t5);
            if (t1 <= 0 || t2 <= 0 || t3 <= 0 || t4 <= 0 || t5 <= 0) {
                showDialog("请选择问题项信息后提交", "alert");
                return false;
            } else {
                var ts1 = "", ts2 = "", ts3 = "", ts4 = "", ts5 = "";
                $(".i1.btncur").each(function () {
                    ts1 += $(this).text() + ",";
                });
                $(".i2.btncur").each(function () {
                    ts2 += $(this).text() + ",";
                });
                $(".i3.btncur").each(function () {
                    ts3 += $(this).text() + ",";
                });
                $(".i4.btncur").each(function () {
                    ts4 += $(this).text() + ",";
                });
                $(".i5.btncur").each(function () {
                    ts5 += $(this).text() + ",";
                });
                var tmsg = ts1 + "|" + ts2 + "|" + ts3 + "|" + ts4 + "|" + ts5;
                window.overlay1 = new mo.Overlay({
                    content: "信息提交中，请稍后...",
                    valign: 'top',
                    offset: [0, 10]
                });
                $.ajax({
                    url: "helper.ashx",
                    type: "post",
                    data: { type: "tjwj", tname: "<%=tmpstr%>", tcod: tmsg },
                    dataType: "json",
                    success: function (data) {
                        overlay1.close();
                        if (data.ist == "1") {
                            $("#hidTJ").val("1");
                            gotoTop();
                            $(".s4").fadeOut("slow", function () {
                                $(".s5").fadeIn("10");
                            });
                        } else {
                            showDialog("请重新提交信息", "alert");
                        }
                    }
                });
            }
        });

        $(".btnqr2").on("touchstart", function () {
            $.ajax({
                url: "helper.ashx",
                type: "post",
                data: { type: "bcArea", tname: $.trim($(".tname").text()) },
                dataType: "json",
                success: function (data) {
                    if (data.ist == "1") {
                        window.location.href = "main.aspx";
                    } else {
                        showDialog("请输入正确的验证码信息", "alert");
                    }
                }
            });
        });
        $(".btnqr1").tap(function () {
            var tpyzm = $.trim($(".txtyzm").val());
            if (tpyzm == "" || tpyzm == null) {
                showDialog("请填写验证码信息", "alert");
                return false;
            }
            $.ajax({
                url: "helper.ashx",
                type: "post",
                data: { type: "isexit", tyzm: tpyzm },
                dataType: "json",
                success: function (data) {
                    if (data.ist == "2") {
                        $(".txtyzm").val("");
                        gotoTop();
                        $(".s2").fadeOut("slow", function () {
                            $(".tname").text(data.name);
                            $(".tgs").text(data.gs);
                            $(".yzm").text(tpyzm);
                            $(".s3").fadeIn("10");
                        });
                    } else {
                        showDialog("请输入正确的验证码信息", "alert");
                    }
                }
            });
        });
    })
    function shTips() {
        if (is_weixn()) {
            showDialog("请通过右上角在浏览器中打开进行查看", "alert");
        }
    }
    function showDialog(msg, type) {
        window.dia1 = new mo.Dialog({
            content: msg,
            type: type
        });
    }
    function is_weixn() {
        var ua = navigator.userAgent.toLowerCase();
        if (ua.match(/MicroMessenger/i) == "micromessenger") {
            return true;
        } else {
            return false;
        }
    }
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
</html>
