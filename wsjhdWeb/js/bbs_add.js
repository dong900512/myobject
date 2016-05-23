 $(function () {
            $('#userReview').click(function (e) {
                $('#imgPopTips').lightbox({
                    centered: true,
                    onLoad: function () {
                    }
                });
                e.preventDefault();
            });
            $("#btnSend").click(function (e) {
                var tmptitle = $("#tfTitle").val();
                var cont = $("#tfContent").val();
                if (tmptitle == "") {
                    //alert("请输入标题信息");
                    $('#popTips').lightbox({
                        centered: true,
                        onLoad: function () {
                            $("#tipsMsg p").text('请输入标题信息');
                        },
                        onClose: function() {
                            $("#tipsMsg p").text('');
                        }
                    });
                    return false;
                }
                if (cont == "") {
                    //alert("请输入内容信息");
                    $('#popTips').lightbox({
                        centered: true,
                        onLoad: function () {
                            $("#tipsMsg p").text('请输入内容信息');
                        },
                        onClose: function() {
                            $("#tipsMsg p").text('');
                        }
                    });
                    return false;
                }
                $.getJSON(
                "/ashx/bbslib.ashx",
                 { bbstype: "bbsAdd", username: "<%=nickname %>", tmptitle: tmptitle, tmpconts: cont },
                 function (json) {
                     if (json.reslut == "1") {
                         //alert("数据发布成功！");
                         $('#popTips').lightbox({
                            centered: true,
                            onLoad: function () {
                                $("#tipsMsg p").text('请输入内容信息');
                            },
                            onClose: function() {
                                $("#tipsMsg p").text('');
                                window.location.href = "bbs_index.aspx";
                            }
                        });
                        
                     } else {
                        //alert("数据发送失败!请尝试！");
                        $('#popTips').lightbox({
                            centered: true,
                            onLoad: function () {
                                $("#tipsMsg p").text('数据发送失败!请尝试！');
                            },
                            onClose: function() {
                                $("#tipsMsg p").text('');
                            }
                        });
                     }
                 }
                );
                e.preventDefault();
            });
        })