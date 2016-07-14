var REG = {
    name: /^[a-zA-Z\u4e00-\u9fa5]{2,12}$/,
    phone: /(^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$)|(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/,
    wxid: /^[a-zA-Z][a-zA-Z0-9_-]{5,19}$/,
    number: /^[+\-]?\d+(\.\d+)?$/,
    idCard: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/
}

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

function dialog(msg, type) {
    window.dia1 = new mo.Dialog({
        content: msg,
        type: type
    });
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

function waiting() {
    //$("#waiting").show();
    setTimeout(function () {
        $("#waiting").hide();
    }, 150);
}
function showwaiting() {
    setTimeout(function () {
        $("#waiting").show();
    }, 80);
}
function shoParmartwait(info) {
    setTimeout(function () {
        $(".cont span").text(info);
        $("#waiting").show();
    }, 80);
}

function shotips(cont, pos, delay) {
    window.overlay1 = new mo.Overlay({
        content: cont,
        valign: pos
    });
    overlay1.on('open', function () {
        var self = this;
        window.setTimeout(function () {
            self.close();
        }, delay);
    })
}

var Wi = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1];    // 加权因子   
var ValideCode = [1, 0, 10, 9, 8, 7, 6, 5, 4, 3, 2];            // 身份证验证位值.10代表X   
function IdCardValidate(idCard) {
    idCard = trim(idCard.replace(/ /g, ""));               //去掉字符串头尾空格                     
    if (idCard.length == 15) {
        return isValidityBrithBy15IdCard(idCard);       //进行15位身份证的验证    
    } else if (idCard.length == 18) {
        var a_idCard = idCard.split("");                // 得到身份证数组   
        if (isValidityBrithBy18IdCard(idCard) && isTrueValidateCodeBy18IdCard(a_idCard)) {   //进行18位身份证的基本验证和第18位的验证
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}
/**  
* 判断身份证号码为18位时最后的验证位是否正确  
* @param a_idCard 身份证号码数组  
* @return  
*/
function isTrueValidateCodeBy18IdCard(a_idCard) {
    var sum = 0;                             // 声明加权求和变量   
    if (a_idCard[17].toLowerCase() == 'x') {
        a_idCard[17] = 10;                    // 将最后位为x的验证码替换为10方便后续操作   
    }
    for (var i = 0; i < 17; i++) {
        sum += Wi[i] * a_idCard[i];            // 加权求和   
    }
    valCodePosition = sum % 11;                // 得到验证码所位置   
    if (a_idCard[17] == ValideCode[valCodePosition]) {
        return true;
    } else {
        return false;
    }
}
/**  
* 验证18位数身份证号码中的生日是否是有效生日  
* @param idCard 18位书身份证字符串  
* @return  
*/
function isValidityBrithBy18IdCard(idCard18) {
    var year = idCard18.substring(6, 10);
    var month = idCard18.substring(10, 12);
    var day = idCard18.substring(12, 14);
    var temp_date = new Date(year, parseFloat(month) - 1, parseFloat(day));
    // 这里用getFullYear()获取年份，避免千年虫问题   
    if (temp_date.getFullYear() != parseFloat(year)
          || temp_date.getMonth() != parseFloat(month) - 1
          || temp_date.getDate() != parseFloat(day)) {
        return false;
    } else {
        return true;
    }
}
/**  
* 验证15位数身份证号码中的生日是否是有效生日  
* @param idCard15 15位书身份证字符串  
* @return  
*/
function isValidityBrithBy15IdCard(idCard15) {
    var year = idCard15.substring(6, 8);
    var month = idCard15.substring(8, 10);
    var day = idCard15.substring(10, 12);
    var temp_date = new Date(year, parseFloat(month) - 1, parseFloat(day));
    // 对于老身份证中的你年龄则不需考虑千年虫问题而使用getYear()方法   
    if (temp_date.getYear() != parseFloat(year)
              || temp_date.getMonth() != parseFloat(month) - 1
              || temp_date.getDate() != parseFloat(day)) {
        return false;
    } else {
        return true;
    }
}
//去掉字符串头尾空格   
function trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}
//物业板块
function tjswy() {
    $.ajax({
        type: 'POST',
        url: "/ServiceLib/account.ashx",
        data: { type: "tjswy" },
        dataType: "json",
        success: function (data) {
            //alert(data.count);
            if (data.count == 1) {
                window.location.href = "/webInfo/wyinfo/index.aspx";
            } else if (data.count == 2) {
                //没有通过认证
                window.location.href = "/webinfo/accm/memberRz.aspx";
            }
            else {
                window.location.href = "/webInfo/login.aspx";
            }
        }
    });
}
//邻里互动板块
function tjsllhd() {
    $.ajax({
        type: 'POST',
        url: "/ServiceLib/account.ashx",
        data: { type: "tjsllhd" },
        dataType: "json",
        success: function (data) {
            if (data.count == 1) {
                window.location.href = "/webInfo/llhd/index.aspx";
            }
            //            else if (data.count == 2) {
            //                //没有通过认证
            //                window.location.href = "/webinfo/accm/memberRz.aspx";
            //            }
            else {
                window.location.href = "/webInfo/login.aspx";
            }
        }
    });
}
//个人中心板块
function tjsInfo() {
    return false;
    $.ajax({
        type: 'POST',
        url: "/ServiceLib/account.ashx",
        data: { type: "tjsInfo" },
        dataType: "json",
        success: function (data) {
            if (data.count == 1) {
                window.location.href = "/webInfo/meb/index.aspx";
            }
            //            else if (data.count == 2) {
            //                //没有通过认证
            //                window.location.href = "/webinfo/accm/memberRz.aspx";
            //            }
            else {
                window.location.href = "/webInfo/login.aspx";
            }
        }
    });
}