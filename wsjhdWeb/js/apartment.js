$(function() {
        

        window.onload = function() {
            $("#popFail").hide();
            swiper = new Swiper('.picwrap', {
                loop:true
            });

            var docWidth = $(document).width();
            var docHeight = $(document).height();
            var imgWidth = $(".small_pic:first>img").width();
            var imgHeight = $(".small_pic:first>img").height();
            var paddingT;
            var paddingL;

            if(imgWidth > imgHeight) {
                paddingL = parseInt((docWidth - imgWidth) / 2);
                $('.pic_show').css({
                    'margin-top' : paddingT + 'px',
                    'margin-left' : paddingL + 'px'
                });
            } else {
                if(docHeight > imgHeight) {
                    paddingT = parseInt((docHeight - (imgHeight + 85)) / 2);
                } else {
                    var Ratio = (docHeight - 85) / imgHeight;
                    imgWidth = parseInt(imgWidth * Ratio);

                    paddingL = (docWidth - imgWidth) / 2;
                    $('.small_pic img').css({
                        'width' : imgWidth + 'px',
                        'height': (docHeight - 85) + 'px',
                        'margin-left' : paddingL + 'px'
                    })
                }
            }
            
        }
        

        isShow = $(".btn_more").parents().hasClass('type_full');

        $('.btn_more').click(function(event) {
            if (!isShow) {
                $("#detailContainer").addClass('type_full');
                isShow = true;
            } else {
                $("#detailContainer").removeClass('type_full');
                isShow = false;
            }
        });

        $('.btn_show_close').click(function(event) {
            window.history.back(-1);
        });

    });