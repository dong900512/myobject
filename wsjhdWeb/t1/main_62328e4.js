var Main = function() {};
Main.prototype = {
    constructor: "Main",
    init: function() {
        var t = this;
        this.flag = !0,
        this.shadeFlag = !1,
        this.shadeFlag1 = !0,
        this.timer1 = null,
        this.timer2 = null,
        this.timer3 = null,
        this.timer4 = null,
        this.timer5 = null,
        this.timer6 = null,
        this.timer7 = null,
        this.handle(),
        $(document.body).on("touchmove",
        function(t) {
            t.preventDefault()
        }),
        $("#J_ShareBtn").on("touchstart",
        function() {
            $("#J_ShareTip").removeClass("hide"),
            t.shadeFlag = !0
        }),
        $("#J_ShareTip").on("touchstart",
        function() {
            $("#J_ShareTip").addClass("hide"),
            t.shadeFlag = !1
        }),
        $("#J_MapBtn").on("touchstart",
        function() {
            $("#J_Map").removeClass("hide"),
            t.shadeFlag = !0
        }),
        $("#J_CloseMap").on("touchstart",
        function() {
            $("#J_Map").addClass("hide"),
            t.shadeFlag = !1
        }),
        $("#J_Navigation").on("touchstart",
        function() {
            wx.openLocation({
                latitude: 39.9876416805,
                longitude: 116.4995204161,
                name: "751新罐",
                address: "北京市朝阳区酒仙桥北路4号",
                scale: 18,
                infoUrl: ""
            })
        })
    },
    handle: function() {
        var t = this.audioFn();
        $.extend(t, {
            src: "http://s.flyfinger.com/360-h5/invitation/images/sound.mp3",
            loop: !0,
            autoPlay: !1
        }),
        t.init(),
        setTimeout(function() {
            t.playMusic()
        },
        0);
        var e = this,
        n = 0,
        a = 0;
        window.addEventListener("deviceorientation",
        function(t) {
            n = Math.round(t.beta),
            a = Math.round(t.gamma),
            0 > n && 0 > a || 0 > n && a > 0 ? (e.flag && !e.shadeFlag && (clearTimeout(e.timer6), e.flag = !1, e.timer5 = setTimeout(function() {
                e.animate0()
            },
            1e3)), e.shadeFlag && e.shadeFlag1 && (e.shadeFlag1 = !1, e.timer7 = setTimeout(function() {
                $("#J_Map").animate({
                    "-webkit-transform": "rotate(180deg)"
                },
                500,
                function() {
                    e.shadeFlag1 = !0
                })
            },
            1e3))) : (n > 0 && a > 0 || n > 0 && 0 > a) && (e.flag || e.shadeFlag || (clearTimeout(e.timer5), e.flag = !0, e.timer6 = setTimeout(function() {
                e.animate2()
            },
            1e3)), e.shadeFlag && e.shadeFlag1 && (e.shadeFlag1 = !1, e.timer7 = setTimeout(function() {
                $("#J_Map").animate({
                    "-webkit-transform": "rotate(0)"
                },
                500,
                function() {
                    e.shadeFlag1 = !0
                })
            },
            1e3)))
        },
        !0),
        $(window).on("orientationchange",
        function() {
            90 === window.orientation || -90 === window.orientation ? $(".J_NoRotateTip").show() : $(".J_NoRotateTip").hide()
        })
    },
    animate0: function() {
        var t = this;
        $(".J_OneText").addClass("hide").removeClass("animated fadeIn"),
        $(".J_OnePhoneTip").addClass("hide"),
        $(".J_Text4").hide(),
        $(".J_Btns").hide(),
        $(".J_IndexBg").animate({
            "-webkit-transform": "translateY(5%)"
        },
        1500,
        function() {
            $(".J_IndexOne").fadeOut(1500,
            function() {
                t.timer1 = setTimeout(function() {
                    t.animate1()
                },
                1e3)
            })
        }),
        $(".J_FBg").fadeIn(1e3),
        $(".J_OneLight").removeClass("hide").css({
            "-webkit-transform": "rotate(180deg) translateY(0)"
        },
        1500)
    },
    animate1: function() {
        var t = this;
        $(".J_Fragment1").show(),
        $(".J_Fragment2").show(),
        this.peopleAuto = Auto($(".J_People"), "p", 1, 30, !0),
        t.timer4 = setTimeout(function() {
            t.a1()
        },
        1e3)
    },
    animate2: function() {
        var t = this;
        clearTimeout(t.timer1),
        clearTimeout(t.timer2),
        clearTimeout(t.timer3),
        clearTimeout(t.timer4),
        $(".J_Text0").fadeOut(),
        t.a2(),
        $(".J_Fragment1").hide(),
        $(".J_Fragment2").hide(),
        $(".J_Text4").fadeOut(),
        $(".J_Btns").fadeOut(),
        $(".J_IndexOne").fadeIn(1500,
        function() {
            $(".J_IndexBg").animate({
                "-webkit-transform": "translateY(0)"
            },
            1500,
            function() {
                $(".J_OneText").addClass("animated fadeIn").removeClass("hide"),
                $(".J_OnePhoneTip").removeClass("hide")
            }),
            $(".J_FBg").fadeOut(),
            $(".J_OneLight").css({
                "-webkit-transform": "rotate(180deg) translateY(5%)"
            },
            1500).addClass("hide")
        })
    },
    a1: function() {
        function t() {
            var i = Date.now(),
            o = (i - a) / 1e3;
            n -= parseFloat((12 * o).toFixed(2)),
            $(".J_Text").children().css({
                "-webkit-transform": "translate3d(0, " + n + "%, 0)"
            }),
            -100 > n && setTimeout(function() {
                window.cancelAFrame(e.timer2),
                $(".J_Text").fadeOut(1e3,
                function() {
                    $(".J_Text0").fadeIn(1500,
                    function() {
                        $(".J_Text4").fadeIn(1500),
                        $(".J_Btns").fadeIn(1500,
                        function() {
                            e.peopleAuto.stop()
                        })
                    })
                })
            },
            0),
            a = i,
            e.timer2 = window.requestAFrame(t)
        }
        var e = this,
        n = 90,
        a = Date.now();
        $(".J_Text").fadeIn(1e3,
        function() {
            t()
        })
    },
    a2: function() {
        var t = this;
        $(".J_Text").fadeOut(1e3),
        setTimeout(function() {
            window.cancelAFrame(t.timer2),
            $(".J_Text").children().css({
                "-webkit-transform": "translate3d(0, 90%, 0)"
            })
        },
        0)
    },
    textAnimate: function() {
        var t = this,
        e = $(".J_T"),
        n = e.length,
        a = !0;
        $(".J_Text").fadeIn(1e3,
        function() {
            for (var i = 0; n > i; i++) {
                var o = t.random(300, 500),
                s = t.random(500, 800),
                r = 0 === t.random(1) ? o: -o,
                u = 0 === t.random(1) ? s: -s;
                e.eq(i).css({
                    "-webkit-transform": "translate3d(" + r + "px, " + u + "px, 0)"
                })
            }
            t.timer2 = setTimeout(function() {
                e.animate({
                    "-webkit-transform": "translate3d(0,0,0)"
                },
                1200,
                function() {
                    a && (a = !1, t.timer3 = setTimeout(function() {
                        t.textAnimate1()
                    },
                    5e3))
                })
            },
            1e3)
        })
    },
    textAnimate1: function() {
        for (var t = this,
        e = $(".J_T"), n = e.length, a = 0, i = 0; n > i; i++) {
            var o = t.random(300, 500),
            s = t.random(500, 800),
            r = 0 === t.random(1) ? o: -o,
            u = 0 === t.random(1) ? s: -s;
            e.eq(i).animate({
                "-webkit-transform": "translate3d(" + r + "px, " + u + "px, 0)"
            },
            1500,
            function() {
                a++,
                a >= n - 1 && (a = 0, $(".J_Text").fadeOut(1e3,
                function() {
                    $(".J_Text0").fadeIn(1500,
                    function() {
                        $(".J_Text4").fadeIn(1500),
                        $(".J_Btns").fadeIn(1500,
                        function() {
                            t.peopleAuto.stop()
                        })
                    })
                }))
            })
        }
    },
    textAnimate2: function() {
        var t = this,
        e = $(".J_T"),
        n = e.length;
        $(".J_Text").fadeOut(1e3,
        function() {
            for (var a = 0; n > a; a++) {
                var i = t.random(500, 1e3),
                o = t.random(500, 1e3),
                s = 0 === t.random(1) ? i: -i,
                r = 0 === t.random(1) ? o: -o;
                e.eq(a).css({
                    "-webkit-transform": "translate3d(" + s + "px, " + r + "px, 0)"
                })
            }
        })
    },
    random: function(t, e) {
        return null == e && (e = t, t = 0),
        t + Math.floor(Math.random() * (e - t + 1))
    },
    audioFn: function() {
        var t = {
            _isAutoPlayed: !1,
            src: "",
            obj: null,
            "switch": null,
            controlSwitchClass: "",
            volume: 1,
            isVolume: !1,
            loop: !0,
            autoPlay: !0,
            timer: null,
            init: function() {
                var t = this;
                return t.obj = document.createElement("audio"),
                null != t.obj && t.obj.canPlayType && t.obj.canPlayType("audio/mpeg") && (t.obj.src = t.src, t.obj.volume = t.volume, t.obj.loop = t.loop, t.obj.autoplay = t.autoPlay, document.body.appendChild(t.obj)),
                t.
                switch && t.
                switch.on("touchstart",
                function() {
                    t.obj.paused ? t.playMusic() : t.pauseMusic()
                }).on("touchmove touchend touchcancel",
                function(t) {
                    t.stopPropagation()
                }),
                this
            },
            playMusic: function() {
                var t = this;
                return t.
                switch && this.
                switch.removeClass(this.controlSwitchClass),
                this.isVolume && (this.obj.volume = 0, this.volumeFn()),
                this.obj.play(),
                this
            },
            pauseMusic: function() {
                return this.
                switch && this.
                switch.addClass(this.controlSwitchClass),
                this.obj.pause(),
                this
            },
            volumeFn: function() {
                var t = this;
                return t.volume += .1,
                t.volume >= 1 && (t.volume = 1, clearTimeout(t.timer)),
                t.obj.volume = t.volume,
                t.timer = setTimeout(function() {
                    t.volumeFn()
                },
                800),
                this
            },
            autoPlayMusic: function() {
                var t = this;
                return t._isautoplayed ? "": function() {
                    t.init(),
                    t._isautoplayed = !0,
                    t.playMusic()
                } (),
                this
            },
            setCurrentTime: function(t) {
                return this.obj.currentTime = t,
                this
            },
            ended: function(t) {
                var e = this;
                this.obj.onended = function() {
                    t.call(e)
                }
            }
        };
        return t
    },
    deviceMotionHandler: function() {}
};