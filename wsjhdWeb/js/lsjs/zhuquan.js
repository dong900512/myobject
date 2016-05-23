var PAGE_INDEX = 0;
var TRANSTION_SPEED = 'all .5s'
var api;
var LASTINDEX = 1;
var TranslateZ = Zhu._translateZ();
var IDINDEX = 0;



var BstopTime = null;


window.Timer = null;
window.stopped = false;

document.addEventListener('touchmove', function (ev) {
    ev.preventDefault();
    return false;
}, false)
function orientationchange() {
    if (window.orientation == 0 || window.orientation == 180) {
        document.getElementById("horizontal").style.display = 'none';
        $('#main').show();

    } else {
        document.getElementById("horizontal").style.display = 'block';
        $('#main').hide();
    }

};



function is_weixn() {
    var ua = navigator.userAgent.toLowerCase();
    if (ua.match(/MicroMessenger/i) == "micromessenger") {
        return true;
    } else {
        return false;
    }
}
if (is_weixn()) {
    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
        WeixinJSBridge.call('hideToolbar');
    });

}

$(function () {


    setTimeout(scrollTo, 0, 0, 0);
    window.onorientationchange = function () {
        orientationchange();
    };


    function LoadFn(arr, fn) {

        var loader = new PxLoader();

        for (var i = 0; i < arr.length; i++) {
            loader.addImage(arr[i]);
        }
        loader.addImage('/images/ls/loading1.jpg');


        loader.addProgressListener(function (e) {

            var percent = Math.round(e.completedCount / e.totalCount * 100);
            $('#loading-black span').text(percent);

        });
        loader.addCompletionListener(fn);
        loader.start();
    };

    var LoadArr = [];
    $('img').each(function () {
        LoadArr.push($(this).attr('src'));
    });


    LoadFn(LoadArr, function () {
        $('#loading-black').fadeOut();
        $('.box-step:first').show();
        Animate();
        $('body').append('<div id="load" style="background:url(/images/ls/loading1.jpg?' + Math.random() + ') no-repeat center center #000;"></div>')

        setTimeout(function () {
            $('#load').fadeOut();
        }, 3000)
        $('.nguang').show();
        //	        $('.start_btn').addClass('shan');

        /*TweenMax.from($('.zk-1') , 1 , {opacity : 0 , marginTop : 50})
        TweenMax.from($('.zk-2') , 1 , {opacity : 0 , marginTop : 50 , delay : .2})
        TweenMax.from($('.zk-3') , 1 , {opacity : 0 , marginTop : 50 , delay : .4})
        TweenMax.from($('.zk-4') , 1 , {opacity : 0 , marginTop : 50 , delay : .6})
        TweenMax.from($('.start_btn') , 1 , {opacity : 0 , marginTop : 50 , delay : .8})
		
        setTimeout( function (){
			
			
        } , 1200)*/
        window.stopped = false;

    })




    var ZINDEX = 10;
    var Bstop = true;


    /*startSlide: 4,  //起始图片切换的索引位置
    auto: 3000, //设置自动切换时间，单位毫秒
    continuous: true,  //无限循环的图片切换效果
    disableScroll: true,  //阻止由于触摸而滚动屏幕
    stopPropagation: false,  //停止滑动事件
    callback: function(index, element) {},  //回调函数，切换时触发
    transitionEnd: function(index, element) {}  //回调函数，切换结束调用该函数。
	
    除此之外，还有一些比较使用的API方法，例如：

    prev()：上一页
    next()：下一页
    getPos()：获取当前页的索引
    getNumSlides()：获取所有项的个数
    slide(index, duration)：滑动方法*/



    function PageUp(index) {



        if (!Bstop) return;
        Bstop = false;


        if (index == 12) index = 3;
        //PAGE_INDEX ++

        PAGEINDEX = index;
        var THIS = $('.zhuquan' + LASTINDEX)[0];



        //$('.dianall span').eq( index - 1 - 2).addClass('hover').siblings().removeClass('hover');

        $('.dianall').each(function () {
            $(this).find('span').eq(index - 1 - 2).addClass('hover').siblings().removeClass('hover');
        })


        THIS.style[Zhu._prefixStyle('transition')] = '';
        THIS.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(0 0)' + TranslateZ
        THIS.style['opacity'] = 1;



        setTimeout(function () {

            THIS.style[Zhu._prefixStyle('transition')] = TRANSTION_SPEED;
            THIS.style[Zhu._prefixStyle('transform')] = 'scale(.8) translate(0,-200px)' + TranslateZ
            THIS.style['opacity'] = 0;

        }, 50)

        var THIS2 = $('.zhuquan' + index)[0];

        THIS2.style.zIndex = ++ZINDEX;
        THIS2.style.display = 'block';


        THIS2.style[Zhu._prefixStyle('transition')] = '';
        THIS2.style[Zhu._prefixStyle('transform')] = 'scale(1.3) translate(0,500px)' + TranslateZ
        THIS2.style['opacity'] = 0;



        setTimeout(function () {
            THIS2.style[Zhu._prefixStyle('transition')] = TRANSTION_SPEED;
            THIS2.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(0,0)' + TranslateZ
            THIS2.style['opacity'] = 1;
            Animate();
        }, 50)

        setTimeout(function () {
            THIS.style.display = 'none';
            Bstop = true;
            //var API = $(THIS2).jScrollPane().data('jsp');
            $(THIS2).attr('id', 'myIscroll' + ++IDINDEX)
            window.API = new iScroll('myIscroll' + IDINDEX, {
                bounce: false
                /*
                fixedScrollbar:false,
                snap: true,
                momentum: false,
                hScrollbar: false,
                vScrollbar: false,
                bounce: false
						
						
                */
            })


            console.log(API);




            if (index == 1 || index == 2) {
                $('.newtop').hide();
            } else {
                $('.newtop').show();

            }



            $('.down-ico-box').show().one('click', function () {
                $(this).remove();
            });

            setTimeout(function () {
                $('.down-ico-box').remove();
            }, 2000)


        }, 550);
        LASTINDEX = index;
    }


    function PageDown(index, s) {

        if (!Bstop) return;
        Bstop = false;

        //PAGE_INDEX --
        if (index == 2 && !s) index = 11;


        PAGEINDEX = index;
        $('.dianall').each(function () {
            $(this).find('span').eq(index - 1 - 2).addClass('hover').siblings().removeClass('hover');
        })
        var THIS = $('.zhuquan' + index)[0];
        THIS.style.display = 'block';


        THIS.style.zIndex = ++ZINDEX;

        THIS.style[Zhu._prefixStyle('transition')] = '';
        THIS.style[Zhu._prefixStyle('transform')] = 'scale(0.8) translate(0,-200px)' + TranslateZ
        THIS.style['opacity'] = 0;

        setTimeout(function () {
            THIS.style[Zhu._prefixStyle('transition')] = TRANSTION_SPEED;
            THIS.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(0,0)' + TranslateZ
            THIS.style['opacity'] = 1;
        }, 50)


        /////////////////////////////////////////////////////////
        var THIS2 = $('.zhuquan' + LASTINDEX)[0];
        THIS2.style.display = 'block';



        THIS2.style[Zhu._prefixStyle('transition')] = '';
        THIS2.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(0,0)' + TranslateZ
        THIS2.style['opacity'] = 1;


        setTimeout(function () {

            THIS2.style[Zhu._prefixStyle('transition')] = TRANSTION_SPEED;
            THIS2.style[Zhu._prefixStyle('transform')] = 'scale(1.3) translate(0,500px)' + TranslateZ
            THIS2.style['opacity'] = 0;
            Animate();
        }, 50);
        if (index == 1 || index == 2) {
            $('.newtop').hide();
        } else {
            $('.newtop').show();

        }
        setTimeout(function () {
            THIS2.style.display = 'none';
            Bstop = true;
            //api.reinitialise();
            //var API = $(THIS).jScrollPane().data('jsp');
            $(THIS).attr('id', 'myIscroll' + ++IDINDEX)
            window.API = new iScroll('myIscroll' + IDINDEX, {
                bounce: false
                /*
                fixedScrollbar:false,
                snap: true,
                momentum: false,
                hScrollbar: false,
                vScrollbar: false,
                bounce: false
						
						
                */
            })
            //API.scrollToBottom();
        }, 550)

        LASTINDEX = index;

    }



    function PageLeft(index) {



        if (!Bstop) return;
        Bstop = false;


        if (index == 9) index = 3;
        //PAGE_INDEX ++

        PAGEINDEX = index;
        var THIS = $('.zhuquan' + LASTINDEX)[0];



        //$('.dianall span').eq( index - 1 - 2).addClass('hover').siblings().removeClass('hover');

        $('.dianall').each(function () {
            $(this).find('span').eq(index - 1 - 2).addClass('hover').siblings().removeClass('hover');
        })


        THIS.style[Zhu._prefixStyle('transition')] = '';
        THIS.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(0 0)' + TranslateZ




        setTimeout(function () {

            THIS.style[Zhu._prefixStyle('transition')] = TRANSTION_SPEED;
            THIS.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(-640px,0)' + TranslateZ


        }, 50)

        var THIS2 = $('.zhuquan' + index)[0];

        THIS2.style.zIndex = ++ZINDEX;
        THIS2.style.display = 'block';
	THIS2.style.opacity = "1";

        THIS2.style[Zhu._prefixStyle('transition')] = '';
        THIS2.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(640px , 0)' + TranslateZ




        setTimeout(function () {
            THIS2.style[Zhu._prefixStyle('transition')] = TRANSTION_SPEED;
            THIS2.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(0,0)' + TranslateZ

            Animate();
        }, 50)

        setTimeout(function () {
            THIS.style.display = 'none';
            Bstop = true;
            //var API = $(THIS2).jScrollPane().data('jsp');
            $(THIS2).attr('id', 'myIscroll' + ++IDINDEX)
            window.API = new iScroll('myIscroll' + IDINDEX, {
                bounce: false
                /*
                fixedScrollbar:false,
                snap: true,
                momentum: false,
                hScrollbar: false,
                vScrollbar: false,
                bounce: false
						
						
                */
            })


            console.log(API);




            if (index == 1 || index == 2) {
                $('.newtop').hide();
            } else {
                $('.newtop').show();

            }



            $('.down-ico-box').show().one('click', function () {
                $(this).remove();
            });

            setTimeout(function () {
                $('.down-ico-box').remove();
            }, 2000)


        }, 550);
        LASTINDEX = index;
    }


    function PageRight(index, s) {

        if (!Bstop) return;
        Bstop = false;

        //PAGE_INDEX --
        if (index == 2 && !s) index = 8;


        PAGEINDEX = index;
        $('.dianall').each(function () {
            $(this).find('span').eq(index - 1 - 2).addClass('hover').siblings().removeClass('hover');
        })
        var THIS = $('.zhuquan' + index)[0];
        THIS.style.display = 'block';


        THIS.style.zIndex = ++ZINDEX;

        THIS.style[Zhu._prefixStyle('transition')] = '';
        THIS.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(-640px , 0)' + TranslateZ
        THIS.style.opacity = "1";

        setTimeout(function () {
            THIS.style[Zhu._prefixStyle('transition')] = TRANSTION_SPEED;
            THIS.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(0,0)' + TranslateZ

        }, 50)


        /////////////////////////////////////////////////////////
        var THIS2 = $('.zhuquan' + LASTINDEX)[0];
        THIS2.style.display = 'block';



        THIS2.style[Zhu._prefixStyle('transition')] = '';
        THIS2.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(0,0)' + TranslateZ



        setTimeout(function () {

            THIS2.style[Zhu._prefixStyle('transition')] = TRANSTION_SPEED;
            THIS2.style[Zhu._prefixStyle('transform')] = 'scale(1) translate(640px , 0)' + TranslateZ

            Animate();
        }, 50);
        if (index == 1 || index == 2) {
            $('.newtop').hide();
        } else {

            $('.newtop').show();

        }
        setTimeout(function () {
            THIS2.style.display = 'none';
            Bstop = true;
            //api.reinitialise();
            //var API = $(THIS).jScrollPane().data('jsp');
            $(THIS).attr('id', 'myIscroll' + ++IDINDEX)
            window.API = new iScroll('myIscroll' + IDINDEX, {
                bounce: false
                /*
                fixedScrollbar:false,
                snap: true,
                momentum: false,
                hScrollbar: false,
                vScrollbar: false,
                bounce: false
						
						
                */
            })
            //API.scrollToBottom();
        }, 550)

        LASTINDEX = index;

    }




    var wpul1, wpul2, wpul3;



    var Html = '';
    for (var i = 0; i < $('.box-step').size() - 2; i++) {
        Html += '<span></span>';
    };
    $('.dianall').html(Html);
    $('.dianall span:first').addClass('hover');
    $('.step2-ul li').click(function () {
        if ($(this).index() > 5) {

            PageUp($(this).index() * 1 + 4);
        } else {

            PageUp($(this).index() * 1 + 3);
        }



    });
    $('.left-btn').click(function () {
        eval($(this).parent().attr('id') + '.prev()');
    })
    $('.right-btn').click(function () {
        eval($(this).parent().attr('id') + '.next()');
    })



    $('.return').click(function () {
        PageDown(2, true);
    })

    var PAGEINDEX = 1;

    $('#main').swipe({
        swipeLeft: function () {

            if (!Bstop || $('.zhuquan1:visible').size() || $('.zhuquan2:visible').size()) return;
            PageLeft(++PAGEINDEX);
        },
        swipeRight: function () {
            if (!Bstop || $('.zhuquan1:visible').size() || $('.zhuquan2:visible').size()) return;
            PageRight(--PAGEINDEX,false);
        }
    })



    /*$('.start_btn').click( function (){
		
    PageUp( 2 );	
		
		
		
    $('.step2-ul li').each( function ( i ){
			
    //$(this).css({'left' : $(this).offset().left , 'top' : $(this).offset().top});
    var T = this;
    var XY = i % 3 == 0 ? "X" : "Y";
    T.style[Zhu._prefixStyle('transition')] = 'all .8s';
    T.style[Zhu._prefixStyle('transform') + 'Origin'] = '50% 50% 0';
    T.style[Zhu._prefixStyle('transform')] = 'perspective(400px) rotate'+XY+'(-90deg)' + TranslateZ
    T.style['opacity'] = 0;
			
			
    setTimeout( function (){
    T.style[Zhu._prefixStyle('transform')] = 'perspective(400px) rotate'+XY+'(0deg)' + TranslateZ;
    T.style['opacity'] = 1;
    } , i * 300 + 300 )
			
			
		
    })
		
		
		
		
		
		
		
		
    });*/


    $('.start_btn').bind('touchend mouseup', function () {

        PageUp(2);



        $('.step2-ul li').each(function (i) {

            //$(this).css({'left' : $(this).offset().left , 'top' : $(this).offset().top});
            var T = this;
            var XY = i % 2 == 0 ? "Y" : "X";
            T.style[Zhu._prefixStyle('transition')] = 'all .8s';
            T.style[Zhu._prefixStyle('transform') + 'Origin'] = '50% 50% 0';
            T.style[Zhu._prefixStyle('transform')] = 'perspective(400px) rotate' + XY + '(-90deg)' + TranslateZ
            T.style['opacity'] = 0;


            setTimeout(function () {
                T.style[Zhu._prefixStyle('transform')] = 'perspective(400px) rotate' + XY + '(0deg)' + TranslateZ;
                T.style['opacity'] = 1;
            }, i * 350 + 350)



        })








    })

    function Animate() {

        window.stopped = true;

        switch (PAGE_INDEX) {
            case 0:

                break;

            case 1:

                break;
            case 2:

                break;
            case 3:

                break;


        };
    }

});




window.addEventListener('deviceorientation', orientationListener, false);
window.addEventListener('MozOrientation', orientationListener, false);
window.addEventListener('devicemotion', orientationListener, false);

var zkbox = $('.zk-box')[0];


function orientationListener(evt) {

    var acceleration = evt.accelerationIncludingGravity;


    var gamma = evt.gamma || acceleration.x
    var beta = evt.beta || acceleration.y
    var alpha = evt.alpha || acceleration.z




    gamma = gamma.toFixed(0);
    beta = beta.toFixed(0);
    alpha = alpha.toFixed(0);
    zkbox.style.marginLeft = gamma / 2 + 'px';
    zkbox.style.marginTop = beta / 2 + 'px';
};

