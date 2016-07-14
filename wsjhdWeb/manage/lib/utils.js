  //鼠标移动连接上，显示图片
  $(function(){
      $("[myTip]").hover(function(){
        $('<div id="luluTip"><div class="triangle" /></div>')
        .insertAfter(this)
        .prepend($(this).attr("myTip"));
      $(this).mousemove(function(e){
            e=e || window.event;
            var x=e.pageX-36;
            if(x-2<0)
                x=2;
            if(x+152>document.body.clientWidth)
                x=document.body.clientWidth-152;
            $("#luluTip").css({"left":x,"top":e.pageY+18,"display":"block"});
      });
        },function(){
        $("#luluTip").remove();
    })
});