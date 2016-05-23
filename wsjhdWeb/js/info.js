function testinfo() {
    $(".right").height($(window).height());
    $(".it1").height($(window).height());
    $(".item2").tap(function () {
        if ($(".right").hasClass("item1")) {

            $(".right").removeClass("item1").addClass("item3");
            $(".item2").removeClass("an1").addClass("an2");
            $(".it1").removeClass("it").addClass("it2");
            $(".t1,.t2,.t3,.t4,.t5,.t6").removeClass("it").addClass("it2");
            $(".right").css("left", "0");
            $(".item2").css("left", "0");
            $(".it1,.t1,.t2,.t3,.t4,.t5,.t6").css("width", "0");
        } else {
            $(".right").removeClass("item3").addClass("item1");
            $(".item2").removeClass("an2").addClass("an1");
            $(".it1").removeClass("it2").addClass("it");
            $(".right").css("left", "45%");
            $(".item2").css("left", "45%");
            $(".it1,.t1,.t2,.t3,.t4,.t5,.t6").css("width", "45%");
        }
    });
    $(".t1").tap(function () {
        window.location.href = "ltindex.html";
    });
    $(".t2").tap(function () {
        window.location.href = "index.htm";
    });
    $(".t3").tap(function () {
        //window.location.href = "xmplist.htm";
    });
    $(".t4").tap(function () {
        window.location.href = "newInfo.htm";
    });
    $(".t5").tap(function () {
        //window.location.href = "brandinfo.htm";
    });
    $(".t6").tap(function () {
        window.location.href = "yykf.htm";
    })
}