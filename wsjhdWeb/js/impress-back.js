function GetMsg(classname) {
            if ($("#userReview").attr("class") == "is_25") {
                $("#noticeDiv").lightbox({
                    centered: true,
                    onLoad: function() {
                        $("#noticeTipsMsg P").text('您已经添加过印象了！');
                    },
                    onClose: function() {
                        $("#noticeTipsMsg P").text('请输入四个字的中文描述');
                    }
                });
                return false;
            } else {

                $.getJSON("/ashx/newsInfo.ashx", { newtype: "impressType", useropenid: '<%=currentopenid %>', EffectTitle: $("." + classname).text() })
                    .done(function (json) {
                        if (json.ismsgs == "1") {
                            //alert("印象添加成功！");
                            

                            $("#userReview").attr("class", "is_25");
                            $("#userReview").html("<em>我的楼盘印象<br/>" + $("." + classname).text() + "</em>");

                            $("#noticeDiv").lightbox({
                                centered: true,
                                onLoad: function() {
                                    $("#noticeTipsMsg P").text('印象添加成功！');
                                },
                                onClose: function() {
                                    $("#noticeTipsMsg P").text('请输入四个字的中文描述');
                                }
                            });
                            //$this.trigger('close');
                        } else {
                            alert("网络错误,添加印象失败!");
                        }
                        $this.trigger('close');
                    })
            }
        }
        $(function () {

            $('#userReview').click(function (e) {
                if ($(this).attr("class") == "is_25") {
                    //alert("您已经添加过印象了！");
                    $("#noticeDiv").lightbox({
                        centered: true,
                        onLoad: function() {
                            $("#noticeTipsMsg P").text('您已经添加过印象了！');
                        }
                    });
                    return false;
                } else {
                    var tmpInfo = $(this);
                    $('#imgPopTips').lightbox({
                        centered: true,
                        onLoad: function () {
                            $("#popConfirmBtn").click(function (event) {
                                $this = $(this);
                                var impress = $("#inputImpress").val();
                                if (impress != '') {
                                    $.getJSON(
                                                                            "/ashx/newsInfo.ashx", { newtype: "impressType", useropenid: '<%=currentopenid %>', EffectTitle: impress })
                                                                            .done(function (json) {
                                                                                if (json.ismsgs == "1") {
                                                                                    //alert("印象添加成功！");
                                                                                    tmpInfo.attr("class", "is_25");
                                                                                    tmpInfo.html("<em>我的楼盘印象<i>" + impress + "</i></em>");
                                                                                    $("#noticeDiv").lightbox({
                                                                                        centered: true,
                                                                                        onLoad: function() {
                                                                                            $("#noticeTipsMsg P").text('印象添加成功！');
                                                                                        },
                                                                                        onClose: function() {
                                                                                            $("#noticeTipsMsg P").text('请输入四个字的中文描述');
                                                                                        }
                                                                                    });
                                                                                    //$this.trigger('close');
                                                                                } else {
                                                                                    //alert("网络错误,添加印象失败!");
                                                                                    $("#noticeDiv").lightbox({
                                                                                        centered: true,
                                                                                        onLoad: function() {
                                                                                            $("#noticeTipsMsg P").text('网络错误,添加印象失败!');
                                                                                        },
                                                                                        onClose: function() {
                                                                                            $("#noticeTipsMsg P").text('请输入四个字的中文描述');
                                                                                        }
                                                                                    });
                                                                                }
                                                                                //$this.trigger('close');
                                                                            })


                                } else {
                                    //$this.trigger('close');
                                    $("#noticeDiv").lightbox({
                                        centered: true
                                    })

                                }
                            });
                        }
                    });
                    e.preventDefault();
                }
            });


        })