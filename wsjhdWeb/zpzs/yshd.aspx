<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yshd.aspx.cs" Inherits="NewInfoWeb.zpzs.yshd" %>

<!DOCTYPE >
<html>
<head>
    <meta charset="UTF-8">
    <title>光明·燕山1號杯有奖征文大赛</title>
    <meta name="description" content="房地产-微生活" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="renderer" content="webkit">
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <style>
        @-webkit-keyframes rotateplane {
            0% { -webkit-transform: perspective(120px); }
            50% { -webkit-transform: perspective(120px) rotateY(180deg); }
            100% { -webkit-transform: perspective(120px) rotateY(180deg) rotateX(180deg); }
        }

        ::-webkit-input-placeholder { text-align: center; color: #6a3906; font-weight: bold; }
        body, div, dl, dt, dd, ul, ol, li, h1, h2, h3, h4, h5, h6, pre, code, form, fieldset, legend, input, textarea, p, blockquote, th, td { margin: 0; padding: 0; font: 12px/1.5 tahoma, '\5b8b\4f53',sans-serif; }

        table { border-collapse: collapse; border-spacing: 0; }
        fieldset, img { border: 0; }
        address, caption, cite, code, dfn, em, strong, th, var { font-style: normal; font-weight: normal; }
        ol, ul { list-style: none; }
        caption, th { text-align: left; }
        h1, h2, h3, h4, h5, h6 { font-size: 100%; font-weight: normal; }
        q:before, q:after { content: ''; }
        abbr, acronym { border: 0; font-variant: normal; }
        sup { vertical-align: text-top; }
        sub { vertical-align: text-bottom; }
        input, textarea, select { font-family: inherit; font-size: inherit; font-weight: inherit; }
        input, textarea, select { font-size: 100%; }
        html, body { max-width: 640px; margin: 0 auto; }
        body { background: url(img/bg.jpg) repeat; }
        img { width: 100%; }
        #listdiv { width: 100%; }
        .item { width: 45%; height: 30%; border: 3px solid ffda27; float: left; border-radius: 15% 15% 0% 0%; overflow: hidden; margin-left: 2%; margin-bottom: 22%; border-bottom: 0px; }
        .clearf { clear: both; padding-top: 15%; }
        .it1 { }
        h1 { text-align: center; font-weight: bold; padding-top: 2%; position: absolute; border: 3px solid ffda27; width: 45%; border-top: 0px; border-radius: 0 0 25% 25%; height: 24px; margin-left: -1%; }
        .mask1 { position: fixed; top: 0px; filter: alpha(opacity=60); background-color: #777; z-index: 800; left: 0px; opacity: 0.5 !important; -moz-opacity: 0.5; width: 100%; height: 100000000px; }
        .mask { position: fixed; top: 0px; filter: alpha(opacity=60); background-color: #777; z-index: 800; left: 0px; opacity: 0.5 !important; -moz-opacity: 0.5; width: 100%; height: 100000000px; display: none; }
        #applyBox { width: 80%; z-index: 802; top: 30%; left: 10%; margin: 0px; position: fixed; background-color: #22ac43; border: 2px solid #a40319; border-radius: 6px; pointer-events: auto; }
        input, .act_join { text-align: center; color: #6a3906; font-weight: bold; }
        .act_join { margin-top: 10%; }
            .act_join li { margin-bottom: 5%; }
        .in { height: 37px; width: 57%; border-radius: 5px; }
        .filebtn { width: 57%; height: 35px; line-height: 35px; display: inline-block; border: 1px solid #ccc; color: #6a3906; background: white; font-weight: bold; text-align: center; overflow: hidden; position: relative; }

        .fbtn { font-size: 118px; width: 100%; height: 40px; cursor: pointer; position: absolute; right: 0; top: 0; opacity: 0; filter: alpha(opacity=0); }
        .btnron { background-color: #dcd3a4; border: 2px solid #a40319; border-radius: 6px; width: 33%; height: 34px; font-weight: bold; border-radius: 5px; }
        .spinner { width: 60px; height: 60px; background-color: #67CF22; margin: 0 auto; -webkit-animation: rotateplane 1.2s infinite ease-in-out; }

        .footinfo { position: fixed; bottom: 4%; height: 35px; width: 100%; font-size: 23px; font-weight: bold; line-height: 35px; }
        .footinfo1 { position: fixed; bottom: 4%; height: 35px; width: 33%; right: 10%; text-align: center; font-size: 23px; font-weight: bold; line-height: 35px; }
        .mo-pop-wrap1 h2, .mo-pop-wrap1 p { margin: 9px; }
        .mask2 { position: fixed; top: 0px; filter: alpha(opacity=60); background-color: #777; z-index: 800; left: 0px; opacity: 0.5 !important; -moz-opacity: 0.5; width: 100%; height: 100000000px; }
        .btnro { background-color: #dcd3a4; border: 2px solid #a40319; border-radius: 6px; width: 75%; height: 34px; font-weight: bold; border-radius: 5px; margin-top: 5%; margin-bottom: 5%; }

        .g1 { display: none; position: absolute; z-index: 600; top: 0; left: 0; -webkit-overflow-scrolling: touch; }
        .gc img, .bm img, .fl img, .jl img { width: 100%; }
        .er { position: absolute; width: 23%; right: 5%; }
        .bigimg { width: 75%; }
        .btnro1 { position: absolute; background-color: #dcd3a4; border: 2px solid #a40319; border-radius: 6px; width: 45%; height: 34px; font-weight: bold; border- radius: 5px; margin-top: 9%; margin-bottom: 5%; }
        .cy { position: absolute; width: 28% !important; height: auto !important; left: 4%; }
        .xq { position: absolute; width: 30% !important; height: auto !important; left: 36%; }
        .px { position: absolute; width: 28% !important; height: auto !important; left: 70%; }
    </style>
</head>
<body>
    <div id="loading-black" style="top: 45%; left: 45%; position: absolute;">
        <div class="spinner">
        </div>
    </div>
    <div class="mwarp" style="display: none;">
        <img src="img/1.jpg" />
        <img src="img/er.png" class="er" />
        <div id="listdiv">
        </div>
        <div class="clearf">
        </div>
        <div class="strformat" style="display: none;">
            <div class="item">
                <div class="it1">
                    <img src="/zpzs/img/{2}" onclick="javascript:showBigImg('{3}','{2}','{4}','{5}')"
                        style="height: 100%;" />
                </div>
                <h1>{0} (<span id="zaninfo_{3}">{1}</span>)</h1>
                <button class="btnro1" onclick="dzio({3})" sid="{3}">
                    点击 投票</button>
            </div>
        </div>
    </div>
    <div class="mo-pop-wrap" style="display: block; position: fixed; top: 0px; left: 0px; pointer-events: none; width: 100%; height: 100%; overflow: hidden; perspective: 1000px; -webkit-perspective: 1000px; -webkit-backface-visibility: hidden; z-index: 500;">
        <div id="mask" class="mask">
        </div>
        <div id="applyBox" class="box" style="display: none;">
            <ul class="act_join">
                <li>
                    <input id="uname" type="text" class="in" maxlength="30" placeholder="姓名" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')"
                        onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" oncontextmenu="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\ ]/g,'')" />
                </li>
                <li>
                    <input id="phone" type="text" class="in" maxlength="20" placeholder="手机" onkeypress='return /^\d$/.test(String.fromCharCode(event.keyCode))'
                        oninput='this.value = this.value.replace(/\D+/g, "")' onpropertychange='if(!/\D+/.test(this.value)){return;};this.value=this.value.replace(/\D

+/g, "")'
                        onblur='this.value = this.value.replace(/\D+/g, "")' />
                </li>
                <li><span type="text" class="filebtn">
                    <input class="fbtn" id="file" type="file" /><label class="lt">
                        添加作品
                    </label>
                </span></li>
                <li>文章写好之后拍照上传，凡仅上传现场照片的无效。</li>
                <li>
                    <button class="btnron">
                        提交</button>
                </li>
            </ul>
            <span style="width: 10%; position: absolute; right: 0; top: 10px; text-align: center; cursor: pointer;"
                class="cos">X</span>
        </div>
    </div>
    <div class="g1">
        <img class="clos2" src="img/close.png" style="position: fixed; width: 15%; right: 0; display: none;" />
        <img src="img/g1.jpg" />
        <img src="img/g2.jpg" />
        <img src="img/g3.jpg" />
        <img src="img/g4.jpg" />
        <img src="img/g5.jpg" />
    </div>
    <div class="mo-pop-wrap2" style="display: none; position: fixed; top: 0px; left: 0px; pointer-events: none; width: 100%; height: 100%; overflow: hidden; perspective: 1000px; -webkit-perspective: 1000px; -webkit-backface-visibility: hidden; z-index: 500;">
        <span style="width: 17%; position: fixed; right: 0; z-index: 880; text-align: center; cursor: pointer; pointer-events: auto;"
            class="cos1">
            <img onclick="javascript:clos2();" src="/zpzs/img/close.png" /></span>
        <div class="mask2">
        </div>
        <div class="clinfo" style="-webkit-transform-origin: 0px 0px; opacity: 1; -webkit-transform: scale(1, 1); pointer-events: auto; width: 90%; margin: 0 auto; background-color: #9ec83e; position: absolute; z-index: 830; left: 50%; top: 50%; -webkit-transform: translate3d(-50%,-50%,0); overflow-y: scroll; height: auto; text-align: center;">
            <img class="bigimg" style="margin-top: 3%;" />
            <button class="btnro" sid="">
                点击 投票(作品编号:<span class="it2"></span>票数:<span class="it3"></span>)</button>
        </div>
    </div>
    <div class="footinfo" style="display: none;">
        <img src="img/cy.png" style="width: 100%;" class="cy" /><img src="img/xq.png" style="width: 100%;"
            class="xq" /><img src="img/ph.png" style="width: 100%;" class="px" />
    </div>
    <input type="hidden" id="hdmsg" value="0" />
    <canvas id="canvas" style="display: none;"></canvas>
    <input type="hidden" id="hid1" value="0" />
    <input type="hidden" id="hidpx" value="0" />

    <script src="http://ossweb-img.qq.com/images/js/zepto/zepto.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/jquery/jquery-1.9.1.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/loader.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/pc-prompt.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/film.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/dialog.min.js"></script>
    <script src="http://ossweb-img.qq.com/images/js/motion/overlay.min.js"></script>
    <script type="text/javascript" src="/Scripts/common.js"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="/js/share.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.PCPrompt = new mo.PCPrompt();
        dataForWeixin.title = "光明·燕山1號杯有奖征文大赛";
        dataForWeixin.desc = "光明·燕山1號杯有奖征文大赛";
        dataForWeixin.img = "http://wsjhb.tencenthouse.com/zpzs/img/fxs.jpg";
        var ww = $(window).width();
        var hh = $(window).height();
        var countnum = 0;
        if ($("#hid1").val() == "") {
            window.location.href = "/zpzs/yshd.aspx";
        }
        function showMask() {
            $("#mask").css("height", "100%");
            $("#mask").show();
            $("#applyBox").show();
        }
        function clos2() {
            $(".mo-pop-wrap2").hide();
        }
        function showBigImg(pid, src, ntm, ords) {

            var ti = "http://wsjhb.tencenthouse.com/zpzs/img/" + src;
            wx.previewImage({
                current: ti,
                urls: [ti]
            });
        }
        function hideshowmsk() {
            $("#mask").hide();
            $("#applyBox").hide();
        }
        function ovlog(msg) {
            window.overlay1 = new mo.Overlay({
                content: msg,
                valign: 'top',
                offset: [0, 10]
            });
            overlay1.on('open', function () {
                var self = this;
                window.setTimeout(function () {
                    self.close();
                }, 2000);
            })
        }
        function dialog(msg, type) {
            window.dia1 = new mo.Dialog({
                content: msg,
                type: type
            });
        }
        var pageindex = 0;
        var isget = true;
        window.addEventListener("load", function () {
            loadinfolist(0);
            window.setTimeout(function () {
                $("#loading-black").hide();
                $(".er").css({ top: hh * 740 / 1008 });
                $(".mwarp").show();
                $(".footinfo").show();
            }, 1000);

            $(".g1").on("click", function (e) {
                $(".g1").fadeOut(50);
            });
            $(".mwarp").scroll(function () {
                if ($("#hidpx").val() == "0") {
                    if (($(window).scrollTop() + $(window).height() > $(document).height() - 40)) {
                        if (isget) {
                            pageindex++;
                            loadinfolist(pageindex);
                        }
                    }
                } else {
                    //  排序号
                    if (($(window).scrollTop() + $(window).height() > $(document).height() - 40)) {
                        if (isget) {
                            pageindex++;
                            loadpxinfolist(pageindex);
                        }
                    }
                }

            });
            var fileupload = document.getElementById("file");
            $(".cos").on("click", function () {
                hideshowmsk();
            });
            $(".px").on("click", function () {
                $("#hidpx").val("1");
                pageindex = 0;
                isget = true;
                loadpxinfolist(pageindex);
            });
            $(".cy").on("click", function () {
                if ($("#hdmsg").val() == "1" || "<%=isx %>" == "1") {
                    dialog("您已上传作品,请不要重复操作!", "error");
                } else {
                    showMask();
                }
            });
            $(".btnro").on("click", function () {
                changhits($(this).attr("sid"), $("#hid1").val());
            });
            $(".xq").on("click", function () {
                $(".g1").show();
            });
            $(".bigimg").on("click", function () {
                var ti = 'http://wsjhb.tencenthouse.com' + $(this).attr("src");
                wx.previewImage({
                    current: 'http://wsjhb.tencenthouse.com' + $(this).attr("src"),
                    urls: [ti]
                });
            });
            $(".btnron").on("click", function () {
                var name = $("#uname").val();
                var phone = $("#phone").val();
                if (name == "" || name == null) {
                    dialog("请输入姓名信息", "alert");
                    return false;
                }
                if (phone == "" || phone == null) {
                    dialog("请输入手机号码信息", "alert");

                    return false;
                }
                var usernamereg = /^(13|15|16|14|18|17)[0-9]{9}$/;
                if (!usernamereg.test(phone)) {
                    dialog("请输入正确的手机号码", "alert");
                    return false;
                }
                if ($(".filebtn").text().indexOf("添加作品") != '-1') {
                    dialog("请添加作品信息", "alert");
                    return false;
                }
                var filename = fileupload.value;
                var exName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();
                if (exName == "JPG" || exName == "GIF" || exName == "PNG" || exName == "BMP")
                { }
                else {
                    dialog("请添加图片文件", "alert");
                    return false;
                }
                window.overlay1 = new mo.Overlay({
                    content: '信息提交中，请稍候！',
                    valign: 'top',
                    offset: [0, 10]
                });
                var file = fileupload.files[0];
                //alert(file);
                var _maxWidth = 640;
                var _maxHeight = 640;
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (evt) {
                    var $img = new Image();
                    $img.onload = function () {
                        //生成比例
                        var width = $img.width,
                    height = $img.height,
                    scale = width / height;
                        width = parseInt(640);
                        height = parseInt(width / scale);
                        //生成canvas
                        var $canvas = $('#canvas');
                        var ctx = $canvas[0].getContext('2d');
                        $canvas.attr({ width: width, height: height });
                        ctx.drawImage($img, 0, 0, width, height);
                        var base64 = $canvas[0].toDataURL('image/jpeg', 0.7);
                        $.post("helper.ashx", { type: "makeImg", "img": base64, "tname": name, "tphone": phone, "tmpid": $("#hid1").val() }, function (json) {
                            if (json.count == 0) {
                                //dialog(json.code,"error");
                                overlay1.close();
                                dialog("很抱歉，信息提交失败！请稍后重试。", "error");
                                return false;
                            }
                            if (json.count == 1) {
                                overlay1.close();
                                dialog("很抱歉，信息提交失败！请稍后重试。", "error");
                                return false;
                            }
                            if (json.count == 2) {
                                overlay1.close();
                                $("#hdmsg").val("1");
                                dialog("信息提交成功", "success");
                                loadinfolist(0);
                                hideshowmsk();
                            }
                        }, "json");
                    }
                    $img.src = webkitURL.createObjectURL(file);
                };
            });

            fileupload.onchange = function () {
                var t = getFileName(fileupload.value);
                // alert($(".filebtn").val());
                $(".lt").text(t);
                return false;
            };
            var type = "";
            if (/android/i.test(navigator.userAgent)) {
                type = "image/png"
            } else {
                type = "image/jpeg"
            }
            function getFileName(path) {
                var pos1 = path.lastIndexOf('/');
                var pos2 = path.lastIndexOf('\\');
                var pos = Math.max(pos1, pos2)
                if (pos < 0)
                    return path;
                else
                    return path.substring(pos + 1);
            }

        });
            function changhits(pid, opid) {
                $.post("helper.ashx", { type: "HDZan", tmpid: pid, tmpopenid: opid }, function (result) {
                    //alert(result);
                    if (result.ist == "0") {
                        ovlog('网络错误，请重试');
                        // 显示消息
                        return false;
                    } else if (result.ist == "1") {
                        //$("#thumb_" + pid).removeClass().addClass("icon-thumbs-up2");
                        $("#zaninfo_" + pid).text("票数:" + result.ismsgs);
                        //showmsg("！");
                        $(".it3").text(result.ismsgs);
                        ovlog('您已投票成功!');
                        return false;
                    }
                    else if (result.ist == "2") {
                        ovlog('今天的票数已投完，请明天继续！');
                        return false;
                    }
                    else if (result.ist == "3") {
                        ovlog('活动时间已过，请关注公告信息');
                        return false;
                    }
                    else if (result.ist == "4") {
                        ovlog('请通过正规渠道访问！');
                        return false;
                    } else if (result.ist == "5") {
                        ovlog('您已投票成功,不能重复投票！');
                        return false;
                    } else if (result.ist == "6") {
                        ovlog('请通过正规渠道访问！');
                        return false;
                    }
                }, "json");
            }
            function clos1() {
                $(".g1").hide();
            }
            function loadinfolist(page) {
                if (page == 0) {
                    $("#listdiv").empty();
                }
                $.post("helper.ashx", { type: "getlist", tmppage: page, pagesize: "5" }, function (result) {
                    var listd = "";
                    var template = $(".strformat").html();
                    if (parseInt(result.count) < 1) {
                        isget = false;
                    } else {
                        ovlog("作品信息加载中...");
                        $.each(result.result, function (i, n) {
                            listd += String.format(template, n.ntnum + "号作品:" + n.name, "票数:" + n.nums, n.imgurl, n.id, n.ntnum, n.nums);
                        });
                        $("#listdiv").append(listd);
                    }
                }, "json");

            }
            function loadpxinfolist(page) {
                if (page == 0) {
                    $("#listdiv").empty();
                }
                $.post("helper.ashx", { type: "GetList1", tmppage: page, pagesize: "5" }, function (result) {
                    var listd = "";
                    var template = $(".strformat").html();
                    if (parseInt(result.count) < 1) {
                        isget = false;
                    } else {
                        ovlog("作品信息加载中...");
                        $.each(result.result, function (i, n) {
                            listd += String.format(template, n.ntnum + "号作品:" + n.name, "票数:" + n.nums, n.imgurl, n.id, n.ntnum, n.nums);
                        });
                        $("#listdiv").append(listd);
                    }
                }, "json");

            }
            function dzio(ct) {

                //alert("345");
                changhits(ct, $("#hid1").val());

            }
    </script>
</body>
</html>
