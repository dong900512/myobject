Array.prototype.objCount = function (c) { return c; }

String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g, function (m, i) {
        return args[i];
    });
}


String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }

    return str;
}

String.formatArgs = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    var args = arguments[1];
    for (var i = 0; i < args.length; i++) {
        var re = new RegExp('\\{' + i + '\\}', 'gm');
        str = str.replace(re, args[i]);
    }

    return str;
}
function $get() { return document.getElementById(arguments[0]); }

function pagerDelegate(obj, method, mode) {
    var delegate = function () {
        var args = [];
        args.push(mode);
        method.apply(obj, args);
    }

    return delegate;
}

function HtmlDecode(txt) {
    var ele = document.createElement("DIV");

    ele.innerHTML = txt;
    var output = ele.innerText || ele.textContent;

    ele = null;
    return output;
}


function OperationMessage(id, msg) {
    $("#" + id)[0].innerHTML = msg;
    $("#" + id).show();

    window.setInterval("OperationMessageColse('" + id + "');", 3000);
}
function OperationMessageAndRedirect(id, msg, tourl) {
    $("#" + id + "_msgid")[0].innerHTML = msg;
    $("#" + id).show();

    window.setInterval("Redirect('" + tourl + "');", 1000);
}
function OperationMessageAndRedirectParent(id, msg, tourl) {
    $("#" + id + "_msgid")[0].innerHTML = msg;
    $("#" + id).show();

    window.setInterval("RedirectParent('" + tourl + "');", 1000);
}
function OperationMessageAndClose(id, msg) {
    $("#" + id + "_msgid")[0].innerHTML = msg;
    $("#" + id).show();

    window.setInterval("window.close()", 1000);
}
function OperationMessageAndCloseDialog(id, msg) {
    $("#" + id + "_msgid")[0].innerHTML = msg;
    $("#" + id).show();

    window.setInterval("closeDialog();", 1000);
}
function OperationMessageColse(id) {
    $("#" + id).hide();
}
function BlockUI(mesid) {

    $.blockUI({ message: $("#" + mesid), css: { width: '275px'} });
}
function Redirect(url) {
    window.location.href = url;
}
function RedirectParent(url) {
    window.parent.location.href = url;
}
function delaytabit(btnfilter, btnid, _index, clsName, divfilter, divname) {

    $(btnfilter).removeClass(clsName);
    $("#" + btnid).addClass(clsName);

    $(divfilter).hide();
    $("#" + divname + _index).show();
}
function Over(element) {
    //--mxw--
    $("div[id^='list_']").each(function (i) {
        $(this).hide();
    });
    //--end--
    document.getElementById(element).style.display = "block";

}

var win = null;
function NewWindow(mypage, myname, w, h, scroll) {
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
    win = window.open(mypage, myname, settings);
    win.focus();
}

function OpenModalWindow(openpage, textid, width, height) {
    var obj = new Object();
    obj.value = "";

    str = window.showModalDialog(openpage, obj, "dialogWidth=" + width + "px;dialogHeight=" + height + "px");
    $("#" + textid).val(str);
}
function OpenModalWindowByValue(openpage, txtvalue, width, height) {
    var obj = new Object();
    obj.value = txtvalue;

    str = window.showModalDialog(openpage, obj, "dialogWidth=" + width + "px;dialogHeight=" + height + "px");

}

function ModalWindowClose(result) {
    window.returnValue = result;
}




function getWeek() {
    var weekOfDay = (new Date()).getDay();
    if (weekOfDay == 1)
        document.write("星期一");
    if (weekOfDay == 2)
        document.write("星期二");
    if (weekOfDay == 3)
        document.write("星期三");
    if (weekOfDay == 4)
        document.write("星期四");
    if (weekOfDay == 5)
        document.write("星期五");
    if (weekOfDay == 6)
        document.write("星期六");
    if (weekOfDay == 0)
        document.write("星期日");
}

function getTimes() {
    now = new Date();
    hour = now.getHours()
    if (hour < 6) { document.write("凌晨好"); }
    else if (hour < 9) { document.write("早上好"); }
    else if (hour < 12) { document.write("上午好"); }
    else if (hour < 14) { document.write("中午好"); }
    else if (hour < 17) { document.write("下午好"); }
    else if (hour < 19) { document.write("傍晚好"); }
    else if (hour < 22) { document.write("晚上好"); }
    else { document.write("夜里好"); }
}


function UrlDecode(str) {
    alert(str);
    var ret = "";
    for (var i = 0; i < str.length; i++) {
        var chr = str.charAt(i);
        if (chr == "+") {
            ret += " ";
        }
        else if (chr == "%") {
            var asc = str.substring(i + 1, i + 3);
            if (parseInt("0x" + asc) > 0x7f) {
                ret += asc2str(parseInt("0x" + asc + str.substring(i + 4, i + 6)));
                i += 5;
            }
            else {
                ret += asc2str(parseInt("0x" + asc));
                i += 2;
            }
        }
        else {
            ret += chr;
        }
    }
    return ret;
}

function getQueryString(key) {
    var value = "";
    var sURL = window.document.URL;

    if (sURL.indexOf("?") > 0) {
        var arrayParams = sURL.split("?");
        var arrayURLParams = arrayParams[1].split("&");

        for (var i = 0; i < arrayURLParams.length; i++) {
            var sParam = arrayURLParams[i].split("=");

            if ((sParam[0] == key) && (sParam[1] != "")) {
                value = sParam[1];
                break;
            }
        }
    }

    return value;
}


//-----------------------------------------------------
//
//-----------------------------------------------------
function textarea_resize(textareaname, textareamp) {
    var tt_num = 5;
    if (textareamp == '-') { tt_num = -5; }
    var tt_obj = document.getElementById(textareaname);
    if (parseInt(tt_obj.rows) + tt_num >= 3) { tt_obj.rows = parseInt(tt_obj.rows) + tt_num; }
    if (tt_num > 0) { tt_obj.width = "90%"; }
}

//-----------------------------------------------------
//
//-----------------------------------------------------
function del_nsort(t2, t3) {
    if (t3 == "yes") {
        var cf = window.confirm("您确定要删除主分类（" + t2 + "）吗？\n其下的二级分类也将一并删除！\n\n删除后将不可恢复！是否确定该操作？");
        if (cf)
        { return true; }
        else
        { return false; }
    }
    else {
        var cf1 = window.confirm("您确定要删除二级分类（" + t2 + "）吗？\n\n删除后将不可恢复！是否确定该操作？");
        if (cf1)
        { return true; }
        else
        { return false; }
    }
    return false;
}

//-----------------------------------------------------
//    选中当前模块下的所有页面 checkbox
//-----------------------------------------------------
function sel_pagebox(formobj, ckid, ckval, ckele) {
    var obj = eval(formobj.name.toString() + ".ck_page" + ckval.toString());

    for (var i = 0; i < formobj.elements.length; i++) {
        var ele = formobj.elements[i];

        if (ele.name == ("ck_page" + ckval.toString()))
            ele.checked = ckele.checked;
    }
}

//-----------------------------------------------------
//    如果选中某页面的 checkbox ，则要回选其所归属的模块
//-----------------------------------------------------
function sel_modulebox(formobj, ckele) {
    var moduleval = ckele.name.toString().substring(7);

    // 如果 当前的页面 checkbox 为选中状态，则判断模块是否为选中，若不是则选中        
    if (ckele.checked) {
        for (var i = 0; i < formobj.elements.length; i++) {
            var ele = formobj.elements[i];

            if (ele.value == moduleval) {
                if (ele.name.toString().indexOf("ck_module") != -1)
                    ele.checked = true;
            }
        }
    }
    else {
        var hasck = false;
        for (var i = 0; i < formobj.elements.length; i++) {
            var ele = formobj.elements[i];

            if (ele.name.toString() == ckele.name.toString()) {
                if (ele.checked) {
                    hasck = true;
                    break;
                }
            }
        }

        if (!hasck) {
            for (var i = 0; i < formobj.elements.length; i++) {
                var ele = formobj.elements[i];

                if (ele.value == moduleval) {
                    if (ele.name.toString().indexOf("ck_module") != -1)
                        ele.checked = false;
                }
            }
        }

    }
}


//-----------------------------------------------------
//    根据 parm 值反选页面中的 Module 对象
//-----------------------------------------------------
function pageItemChecked(parm, formobj) {
    for (var i = 0; i < formobj.elements.length; i++) {
        var ele = formobj.elements[i];

        if (ele.name == ("ck_page" + parm.toString()) && ele.checked)
            return true;
    }

    return false;
}

function Overmxw(parm1) {
    $("#" + parm1).toggle();
}
//----------------------------------------------------
//返回日期
//---
function initArray() {
    for (i = 0; i < initArray.arguments.length; i++)
        this[i] = initArray.arguments[i];
}
var isnMonths = new initArray("1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月");
var isnDays = new initArray("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日");
today = new Date();
hrs = today.getHours();
min = today.getMinutes();
sec = today.getSeconds();
clckh = "" + ((hrs > 12) ? hrs - 12 : hrs);
clckm = ((min < 10) ? "0" : "") + min; clcks = ((sec < 10) ? "0" : "") + sec;
clck = (hrs >= 12) ? "下午" : "上午";
var stnr = "";
var ns = "0123456789";
var a = "";
function getFullYear(d) {
    yr = d.getYear(); if (yr < 1000)
        yr += 1900; return yr;
}

//function confirmsuffix(ele) {
//    if (ele.value == "") return true;
//    var filename = ele.value;
//    var exName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();

//    if (exName == "GIF" || exName == "JPG" || exName == "BMP" || exName == "PNG")
//        return true;
//    else {
//        alert("图片只能是 jpg,bmp,png 或 gif 格式!");
//        ele.select();
//        document.execCommand("delete");
//        try {
//            ele.form.submit();
//        }
//        catch (expt) { }
//        return false;
//    }
//}
function confirmsuffix(ele) {
    var type = "pic";
    if (arguments[1] != "")
        type = arguments[1];
    if (ele.value == "")
        return true;

    var filename = ele.value;
    var exName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();
    if (type == "video") {
        if (exName == "WMV" || exName == "FLV" || exName == "ASF" || exName == "SWF" || exName == "AVI" || exName == "MPEG")
            return true;
        else {
            alert("视频只能是 FLV,WMV,ASF,SWF,AVI,MPEG 格式!");
        }
    }
    else if (type == "music") {
        if (exName == "MP3" || exName == "WMA")
            return true;
        else {
            alert("文件格式只能是 MP3,WMA格式!");
        }
    }
    else if (type == "pic") {
        if (exName == "GIF" || exName == "JPG" || exName == "JPEG" || exName == "BMP" || exName == "PNG")
            return true;
        else {
            alert("图片只能是 jpg,bmp,png 或 gif 格式!");
        }
    }
    else {
        if (exName == "GIF" || exName == "JPG" || exName == "JPEG" || exName == "BMP" || exName == "PNG")
            return true;
        else {
            alert("图片只能是 jpg,bmp,png 或 gif 格式!");
        }
    }

    ele.select();
    ele.value = "";
    document.execCommand("delete");
    try {
        ele.form.submit();
    }
    catch (expt) { }
    return false;
}


function setJareaHtml() {
    var ifr = window.frames[0];
    ifr.document.body.innerHTML = arguments[0];
}

//window.onload = function() {
//    $("a").each(function(i, ele) {
//        var h = $(ele).attr("href").toLowerCase(); //alert(h);
//        $(ele).attr({ "href": h });
//    });
//}
