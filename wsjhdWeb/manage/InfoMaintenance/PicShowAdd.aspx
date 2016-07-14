<%@ Page Title="" Language="C#" MasterPageFile="~/manage/InfoMaintenance/SysNewsmaster.master" AutoEventWireup="true" CodeBehind="PicShowAdd.aspx.cs" Inherits="NewInfoWeb.manage.InfoMaintenance.PicShowAdd" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/ImgUpload/ImgUp/baiduUE.js" type="text/javascript"></script>
    <link href="/ImgUpload/ImgUp/image.css" rel="stylesheet" type="text/css" />
    <div class="wrapper">
        <div id="imageTab">
            <div id="tabBodys" class="tabbody" style="border: 1px solid #CCCCCC;">
                <div id="local">
                    <div id="flashContainer">
                    </div>
                    <div>
                        <a id="lnkReset" href="javascript:void(0)" target="_self">清空</a>
                        <div id="upload" style="background: url('../img/addpic.png') repeat scroll 0% 0% transparent;
                            width: 77px; height: 25px" flag="0">
                        </div>
                        <div id="localFloat">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/ImgUpload/ImgUp/image.js" type="text/javascript"></script>
    <script type="text/javascript">
        //全局变量
        var imageUrls = [],          //用于保存从服务器返回的图片信息数组
            selectedImageCount = 0;  //当前已选择的但未上传的图片数量

        baiduUE.domReady(function () {

            var flashOptions = {
                container: "flashContainer",                                                    //flash容器id<a href="../../ImgUpload/ueditor_2.6.1/net/imageUp.ashx">../../ImgUpload/ueditor_2.6.1/net/imageUp.ashx</a>
                url: "../../ImgUpload/ueditor_2.6.1/net/imageUp.ashx",                                           // 上传处理页面的url地址
                ext: '{"ViewID":"<%=picTypeid %>","IsWeb":"1","UserName":"<%=curloginname %>"}',                                 //可向服务器提交的自定义参数列表
                fileType: '{"description":"' + lang.fileType + '", "extension":"*.gif;*.jpeg;*.png;*.jpg"}',     //上传文件格式限制
                flashUrl: '../../ImgUpload/ImgUp/imageUploader.swf',                                                  //上传用的flash组件地址
                width: 608,          //flash的宽度
                height: 272,         //flash的高度
                gridWidth: 121,     // 每一个预览图片所占的宽度
                gridHeight: 120,    // 每一个预览图片所占的高度
                picWidth: 100,      // 单张预览图片的宽度
                picHeight: 100,     // 单张预览图片的高度
                uploadDataFieldName: "upfile",    // POST请求中图片数据的key
                picDescFieldName: 'pictitle',      // POST请求中图片描述的key
                maxSize: 2,                         // 文件的最大体积,单位M
                compressSize: 2,                   // 上传前如果图片体积超过该值，会先压缩,单位M
                maxNum: 32,                         // 单次最大可上传多少个文件
                compressSide: 0,                 //等比压缩的基准，0为按照最长边，1为按照宽度，2为按照高度
                compressLength: 900        //能接受的最大边长，超过该值Flash会自动等比压缩
            };
            //回调函数集合，支持传递函数名的字符串、函数句柄以及函数本身三种类型
            var callbacks = {
                // 选择文件的回调
                selectFileCallback: function (selectFiles) {
                    baiduUE.each(selectFiles, function (file) {
                        var tmp = {};
                        tmp.id = file.index;
                        tmp.data = {};
                        postConfig.push(tmp);
                    });
                    selectedImageCount += selectFiles.length;
                    if (selectedImageCount) {
                        baiduUE.g("upload").attributes["flag"].value = "1";
                    }
                    //dialog.buttons[0].setDisabled(true); //初始化时置灰确定按钮
                },
                // 删除文件的回调
                deleteFileCallback: function (delFiles) {
                    for (var i = 0, len = delFiles.length; i < len; i++) {
                        var index = delFiles[i].index;
                        postConfig.splice(index, 1);
                    }
                    selectedImageCount -= delFiles.length;
                    if (!selectedImageCount) {
                        baiduUE.g("upload").attributes["flag"].value = "0";
                        //dialog.buttons[0].setDisabled(false);         //没有选择图片时重新点亮按钮
                    }
                },

                // 单个文件上传完成的回调
                uploadCompleteCallback: function (data) {
                    try {
                        var info = eval("(" + data.info + ")");
                        info && imageUrls.push(info);
                        selectedImageCount--;
                    } catch (e) {
                        alert(e);
                    }

                },
                // 单个文件上传失败的回调,
                uploadErrorCallback: function (data) {
                    if (!data.info) {
                        alert(lang.netError);
                    }
                    //console && console.log(data);
                },
                // 全部上传完成时的回调
                allCompleteCallback: function () {
                    //dialog.buttons[0].setDisabled(false);    //上传完毕后点亮按钮
                    window.opener.location.href = window.opener.location.href;
                    window.close();
                },
                // 文件超出限制的最大体积时的回调
                //exceedFileCallback: 'exceedFileCallback',
                // 开始上传某个文件时的回调
                startUploadCallback: function () {
                    var config = postConfig.shift();
                    //也可以在这里更改
                    //if(config.id==2){ //设置第三张图片的对应参数
                    //     config.data={"myParam":"value"}
                    // }
                    flashObj.addCustomizedParams(config.id, config.data);
                }
            };
            imageUploader.init(flashOptions, callbacks);
            baiduUE.g("upload").onclick = function () {
                /**
                * 接口imageUploader.setPostParams()可以在提交时设置本次上传提交的参数（包括所有图片）
                * 参数为json对象{"key1":"value1","key2":"value2"}，其中key即为向后台post提交的name，value即为值。
                * 其中有一个特殊的保留key值为action，若设置，可以更改本次提交的处理地址
                */
                if (this.attributes["flag"].value == "0") {
                    return;
                }
                var postParams = {
                    "dir": 1//editor.options.imagePath
                };
                imageUploader.setPostParams(postParams);
                flashObj.upload();
                baiduUE.g("upload").attributes["flag"].value = "0";
            };
            baiduUE.g("lnkReset").onclick = function () {
                imageUploader.clearFlash();
            };

        });
    </script>
</asp:Content>
