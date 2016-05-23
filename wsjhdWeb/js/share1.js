var dataForWeixin = {
    isWXShare: false,
    appId: "", //wxae93304ccdcd5dbb
    cururl: (window.location.href.indexOf('#') == -1 ? window.location.href : window.location.href.substring(0, window.location.href.indexOf('#'))),
    img: "",
    url: "",
    title: "",
    desc: "",
    fakeid: "",
    async: false, //是否启用每次分享都重置分享内容
    debug: false, //是否开启debug模式
    issend: false,
    ShareCallBack: function (ex) { }
};
function WeChatSDKjsonpCallback(json) {
    //alert(dataForWeixin.url);
    wx.config({
        debug: dataForWeixin.debug,
        appId: json.appid1,
        timestamp: json.timeStamp1,
        nonceStr: json.nonceStr1,
        signature: json.signature1,
        jsApiList: [
        'checkJsApi',
        'onMenuShareTimeline',
        'onMenuShareAppMessage',
        'onMenuShareQQ',
        'onMenuShareWeibo',
        'hideMenuItems',
        'showMenuItems',
        'hideAllNonBaseMenuItem',
        'showAllNonBaseMenuItem',
        'translateVoice',
        'startRecord',
        'stopRecord',
        'onRecordEnd',
        'playVoice',
        'pauseVoice',
        'stopVoice',
        'uploadVoice',
        'downloadVoice',
        'chooseImage',
        'previewImage',
        'uploadImage',
        'downloadImage',
        'getNetworkType',
        'openLocation',
        'getLocation',
        'hideOptionMenu',
        'showOptionMenu',
        'closeWindow',
        'scanQRCode',
        'chooseWXPay',
        'openProductSpecificView',
        'addCard',
        'chooseCard',
        'openCard'
      ]
    });
}

wx.ready(function () {
    if (dataForWeixin.isWXShare) {
        //alert(dataForWeixin.isWXShare);
        //分享到朋友圈
        wx.onMenuShareTimeline({
            title: dataForWeixin.title,
            link: dataForWeixin.url,
            imgUrl: dataForWeixin.img,
            trigger: function (res) {

                if (dataForWeixin.async) {
                    this.title = dataForWeixin.title;
                    this.link = dataForWeixin.url;
                    this.imgUrl = dataForWeixin.img;
                    this.desc = dataForWeixin.desc;
                }
            },
            success: function () {

                dataForWeixin.ShareCallBack("success");
            },
            cancel: function () {
                dataForWeixin.ShareCallBack("cancel");
            }
        });
        //发送给好友
        wx.onMenuShareAppMessage({
            title: dataForWeixin.title,
            desc: dataForWeixin.desc,
            link: dataForWeixin.url,
            imgUrl: dataForWeixin.img,
            type: '',
            dataUrl: '',
            trigger: function (res) {
                //alert("123");
                if (dataForWeixin.async) {
                    this.title = dataForWeixin.title;
                    this.link = dataForWeixin.url;
                    this.imgUrl = dataForWeixin.img;
                    this.desc = dataForWeixin.desc;
                }
            },
            success: function () {
                dataForWeixin.ShareCallBack("success");
            },
            cancel: function () {
                dataForWeixin.ShareCallBack("cancel");
            }
        });
        //分享到QQ
        wx.onMenuShareQQ({
            title: dataForWeixin.title,
            desc: dataForWeixin.desc,
            link: dataForWeixin.url,
            imgUrl: dataForWeixin.img,
            trigger: function (res) {
                if (dataForWeixin.async) {
                    this.title = dataForWeixin.title;
                    this.link = dataForWeixin.url;
                    this.imgUrl = dataForWeixin.img;
                    this.desc = dataForWeixin.desc;
                }
            },
            success: function () {
                dataForWeixin.ShareCallBack("success");
            },
            cancel: function () {
                dataForWeixin.ShareCallBack("cancel");
            }
        });
        //分享到腾讯微博
        wx.onMenuShareWeibo({
            title: dataForWeixin.title,
            desc: dataForWeixin.desc,
            link: dataForWeixin.url,
            imgUrl: dataForWeixin.img,
            trigger: function (res) {
                if (dataForWeixin.async) {
                    this.title = dataForWeixin.title;
                    this.link = dataForWeixin.url;
                    this.imgUrl = dataForWeixin.img;
                    this.desc = dataForWeixin.desc;
                }
            },
            success: function () {
                dataForWeixin.ShareCallBack("success");
            },
            cancel: function () {
                dataForWeixin.ShareCallBack("cancel");
            }
        });
    } else {
        wx.hideOptionMenu();
    }
});


KISSY.use('node,io,json', function (S, Node, IO, JSON) {
    var $ = Node.all;
    if (dataForWeixin.issend) {
        IO.post('/ashx/wxlessfx.ashx', { getsign: "WXSign", urlinfo: dataForWeixin.cururl }, function (data) {
            if (data.count > 0) {
                WeChatSDKjsonpCallback(data.result[0]);

            }
        }, 'json');
    }
})
