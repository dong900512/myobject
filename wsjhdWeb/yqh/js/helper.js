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
function loadingInfo(){

            var LoadingHtml = document.createElement("div");
            LoadingHtml.className = "loading-container";
            LoadingHtml.id = "loading";
            LoadingHtml.innerHTML = '<img src="http://17.tencenthouse.com/Scripts/img/loading-outer.png" class="loading-outer" width="100%" /><img src="http://17.tencenthouse.com/Scripts/img/loading-inner.png" class="loading-inner" width="100%" /><img src="http://17.tencenthouse.com/Scripts/img/loading-logo.png" class="loading-logo" width="100%" /><img src="http://17.tencenthouse.com/Scripts/img/loading-text.png" class="loading-text" width="100%" /><img src="http://17.tencenthouse.com/Scripts/img/loading-point.png" class="loading-point" width="100%" />';
            document.getElementsByTagName("body")[0].appendChild(LoadingHtml);
        
}

function hideInfo(){
    $("div.loading-container").fadeOut("200");
   
}

var Wi = [ 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1 ];    // 加权因子   
var ValideCode = [ 1, 0, 10, 9, 8, 7, 6, 5, 4, 3, 2 ];            // 身份证验证位值.10代表X   
function IdCardValidate(idCard) { 
    idCard = trim(idCard.replace(/ /g, ""));               //去掉字符串头尾空格                     
    if (idCard.length == 15) {   
        return isValidityBrithBy15IdCard(idCard);       //进行15位身份证的验证    
    } else if (idCard.length == 18) {   
        var a_idCard = idCard.split("");                // 得到身份证数组   
        if(isValidityBrithBy18IdCard(idCard)&&isTrueValidateCodeBy18IdCard(a_idCard)){   //进行18位身份证的基本验证和第18位的验证
            return true;   
        }else {   
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
    for ( var i = 0; i < 17; i++) {   
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
function isValidityBrithBy18IdCard(idCard18){   
    var year =  idCard18.substring(6,10);   
    var month = idCard18.substring(10,12);   
    var day = idCard18.substring(12,14);   
    var temp_date = new Date(year,parseFloat(month)-1,parseFloat(day));   
    // 这里用getFullYear()获取年份，避免千年虫问题   
    if(temp_date.getFullYear()!=parseFloat(year)   
          ||temp_date.getMonth()!=parseFloat(month)-1   
          ||temp_date.getDate()!=parseFloat(day)){   
            return false;   
    }else{   
        return true;   
    }   
}   
  /**  
   * 验证15位数身份证号码中的生日是否是有效生日  
   * @param idCard15 15位书身份证字符串  
   * @return  
   */  
  function isValidityBrithBy15IdCard(idCard15){   
      var year =  idCard15.substring(6,8);   
      var month = idCard15.substring(8,10);   
      var day = idCard15.substring(10,12);   
      var temp_date = new Date(year,parseFloat(month)-1,parseFloat(day));   
      // 对于老身份证中的你年龄则不需考虑千年虫问题而使用getYear()方法   
      if(temp_date.getYear()!=parseFloat(year)   
              ||temp_date.getMonth()!=parseFloat(month)-1   
              ||temp_date.getDate()!=parseFloat(day)){   
                return false;   
        }else{   
            return true;   
        }   
  }   
//去掉字符串头尾空格   
function trim(str) {   
    return str.replace(/(^\s*)|(\s*$)/g, "");   
}


function alertMsg(msg, mode) { //mode为空，即只有一个确认按钮，mode为1时有确认和取消两个按钮
    msg = msg || '';
    mode = mode || 0;
    var top = document.body.scrollTop || document.documentElement.scrollTop;
    var isIe = (document.all) ? true : false;
    var isIE6 = isIe && !window.XMLHttpRequest;
    var sTop = document.documentElement.scrollTop || document.body.scrollTop;
    var sLeft = document.documentElement.scrollLeft || document.body.scrollLeft;
    var winSize = function () {
        var xScroll, yScroll, windowWidth, windowHeight, pageWidth, pageHeight;
        // innerHeight获取的是可视窗口的高度，IE不支持此属性
        if (window.innerHeight && window.scrollMaxY) {
            xScroll = document.body.scrollWidth;
            yScroll = window.innerHeight + window.scrollMaxY;
        } else if (document.body.scrollHeight > document.body.offsetHeight) { // all but Explorer Mac
            xScroll = document.body.scrollWidth;
            yScroll = document.body.scrollHeight;
        } else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari
            xScroll = document.body.offsetWidth;
            yScroll = document.body.offsetHeight;
        }

        if (self.innerHeight) {    // all except Explorer
            windowWidth = self.innerWidth;
            windowHeight = self.innerHeight;
        } else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
            windowWidth = document.documentElement.clientWidth;
            windowHeight = document.documentElement.clientHeight;
        } else if (document.body) { // other Explorers
            windowWidth = document.body.clientWidth;
            windowHeight = document.body.clientHeight;
        }

        // for small pages with total height less then height of the viewport
        if (yScroll < windowHeight) {
            pageHeight = windowHeight;
        } else {
            pageHeight = yScroll;
        }

        // for small pages with total width less then width of the viewport
        if (xScroll < windowWidth) {
            pageWidth = windowWidth;
        } else {
            pageWidth = xScroll;
        }

        return {
            'pageWidth': pageWidth,
            'pageHeight': pageHeight,
            'windowWidth': windowWidth,
            'windowHeight': windowHeight
        }
    } ();
    //alert(winSize.pageWidth);
    //遮罩层
    var styleStr = 'top:0;left:0;position:absolute;z-index:10000;background:#666;width:' + winSize.pageWidth + 'px;height:' + (winSize.pageHeight + 30) + 'px;';
    styleStr += (isIe) ? "filter:alpha(opacity=80);" : "opacity:0.8;"; //遮罩层DIV
    var shadowDiv = document.createElement('div'); //添加阴影DIV
    shadowDiv.style.cssText = styleStr; //添加样式
    shadowDiv.id = "shadowDiv";
    //如果是IE6则创建IFRAME遮罩SELECT
    if (isIE6) {
        var maskIframe = document.createElement('iframe');
        maskIframe.style.cssText = 'width:' + winSize.pageWidth + 'px;height:' + (winSize.pageHeight + 30) + 'px;position:absolute;visibility:inherit;z-index:-1;filter:alpha(opacity=0);';
        maskIframe.frameborder = 0;
        maskIframe.src = "about:blank";
        shadowDiv.appendChild(maskIframe);
    }
    document.body.insertBefore(shadowDiv, document.body.firstChild); //遮罩层加入文档
    //弹出框
    var styleStr1 = 'display:block;position:fixed;_position:absolute;left:' + (winSize.windowWidth / 2 - 200) + 'px;top:' + (winSize.windowHeight / 2 - 150) + 'px;_top:' + (winSize.windowHeight / 2 + top - 150) + 'px;'; //弹出框的位置
    var alertBox = document.createElement('div');
    alertBox.id = 'alertMsg';
    alertBox.style.cssText = styleStr1;
    //创建弹出框里面的内容P标签
    var alertMsg_info = document.createElement('P');
    alertMsg_info.id = 'alertMsg_info';
    alertMsg_info.innerHTML = msg;
    alertBox.appendChild(alertMsg_info);
    //创建按钮
    var btn1 = document.createElement('a');
    btn1.id = 'alertMsg_btn1';
    btn1.href = 'javas' + 'cript:void(0)';
    btn1.innerHTML = '<cite>确定</cite>';
    btn1.onclick = function () {
        document.body.removeChild(alertBox);
        document.body.removeChild(shadowDiv);
        return true;
    };
    alertBox.appendChild(btn1);
    if (mode === 1) {
        var btn2 = document.createElement('a');
        btn2.id = 'alertMsg_btn2';
        btn2.href = 'javas' + 'cript:void(0)';
        btn2.innerHTML = '<cite>取消</cite>';
        btn2.onclick = function () {
            document.body.removeChild(alertBox);
            document.body.removeChild(shadowDiv);
            return false;
        };
        alertBox.appendChild(btn2);
    }
    document.body.appendChild(alertBox);
}