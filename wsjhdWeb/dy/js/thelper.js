var LoadingCssBlock = '.loading {height: 100%; width: 100%; top:0; left:0; background: #282a30; position: fixed; display:block; z-index:99999;}';
LoadingCssBlock += '.loading_circle {height: 72px; width: 72px; background: url(data:image/jpeg;base64,/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAAAyAAD/4QMqaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjUtYzAxNCA3OS4xNTE0ODEsIDIwMTMvMDMvMTMtMTI6MDk6MTUgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDQyAoV2luZG93cykiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6NDFFMEU4NEZDQkFDMTFFMzlGNzdEMzMzNzUzOUE4NTQiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6NDFFMEU4NTBDQkFDMTFFMzlGNzdEMzMzNzUzOUE4NTQiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo0MUUwRTg0RENCQUMxMUUzOUY3N0QzMzM3NTM5QTg1NCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo0MUUwRTg0RUNCQUMxMUUzOUY3N0QzMzM3NTM5QTg1NCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/Pv/uACFBZG9iZQBkwAAAAAEDABADAwYJAAAIBAAADF8AABAX/9sAhAAI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) no-repeat; position: absolute; left: 50%; margin: -36px 0px 0px -36px; top: 50%; background-size: 72px 72px; -webkit-animation: load 1s infinite linear;}';
LoadingCssBlock += '.loading_per {font-size: 14px; height: 72px; width: 72px; position: absolute; color: #fff; text-align: center; left: 50%; margin: -36px 0px 0px -36px; line-height: 72px; top: 50%}';
LoadingCssBlock += '@-webkit-keyframes load{0% {-webkit-transform:rotate(0deg);}100% {-webkit-transform:rotate(360deg);}}';
var style = document.createElement("style");
style.type = "text/css";
style.textContent = LoadingCssBlock;
document.getElementsByTagName("HEAD").item(0).appendChild(style);
var LoadingHtml = document.createElement("div");
LoadingHtml.className = "loading";
LoadingHtml.id = "loading";
LoadingHtml.innerHTML = '<div class="loading_ctn"><div class="loading_circle"></div><div id="loading_per" class="loading_per"></div></div>';
document.getElementsByTagName("body")[0].appendChild(LoadingHtml);

function LoadAud(obj, aud) {
    if (obj != null && obj.canPlayType && obj.canPlayType("audio/mpeg")) {
        obj.pause();
        obj.src = aud;
        try {
            obj.currentTime = 0;

            //alert("456")
            obj.play();

        } catch (e) {
        }
        obj.play();
        document.addEventListener('WeixinJSBridgeReady', function () {
            obj.play();
        });
        $audio = $("audio");
        if ($audio.length > 0) {
            $(".u-globalAudio").addClass("play_yinfu");
            $audio.parent("a").prepend('<i class="icon-music"></i>');
        }
        $(".u-globalAudio").on("click", function () {
            $(this).toggleClass("z-play");
            if ($(this).hasClass("z-play")) {
                $(this).addClass("play_yinfu");
                obj.play();
            } else {
                $(this).removeClass("play_yinfu");

                obj.pause();
            }
        });
    }
}
function gid(o) { return document.getElementById(o); }