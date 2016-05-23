$().ready(function () {
    var Heightyy = $(window).height();
    var Widthyy = $(window).width();
    $(".futuretown_bgimg img").height(Heightyy);
    $(".panel2").height(Heightyy);
    $(".panel3").height(Heightyy);

    //关闭中奖页面
    $(".btn_back").click(function () {
        $(".pageimg").hide();
    });


    var alldata = new Array();
    var alltrue = new Array();
    $.ajaxSettings.async = false;
    $.getJSON("handlers/Index.ashx", {}, function (data) {
        $.each(data, function (i, n) {
            alldata[i] = n.st.split("|")[0];
            alltrue[i] = n.st.split("|")[1];
        });
    });

    var num = alldata.length - 1;
    var timer;

    //点击开始页面重新滚动
    function againbtn() {
        clearInterval(timer);
        timer = setInterval(change, 100); //随机数据变换速度，越小变换的越快 

    }

    //点击暂停页面获取数据（五个数据）
    function pause_five() {
        clearInterval(timer);
        var num_array = new Array();
        num_array = getArrayItems(alltrue, 5);
        $(".selected").each(function (i) {
            $(this).html(num_array[i]);
        });
    }


    //点击暂停页面获取数据（一个数据）
    function pause_one() {
        clearInterval(timer);
        var num_array = new Array();
        num_array = getArrayItems(alldata, 1);
        $(".tiwn_txt").each(function (i) {
            $(this).html(num_array[i]);
        });
    }


    function change() {
        //页面随机滚动
        $(".show").each(function (i) {
            var prizetxt = alldata[GetRnd(0, num)];
            $(this).text(prizetxt);
        });
    }

    //随机滚动的方法	
    function GetRnd(min, max) {
        return parseInt(Math.random() * (max - min + 1));
    }

    //产生多个随机数的方法
    function getArrayItems(arr, num) {
        //新建一个数组,将传入的数组复制过来,用于运算,而不要直接操作传入的数组;
        var temp_array = new Array();
        for (var index in arr) {
            temp_array.push(arr[index]);
        }
        //取出的数值项,保存在此数组
        var return_array = new Array();
        for (var i = 0; i < num; i++) {
            //判断如果数组还有可以取出的元素,以防下标越界
            if (temp_array.length > 0) {
                //在数组中产生一个随机索引
                var arrIndex = Math.floor(Math.random() * temp_array.length);
                //将此随机索引的对应的数组元素值复制出来
                return_array[i] = temp_array[arrIndex];
                //然后删掉此索引的数组元素,这时候temp_array变为新的数组
                temp_array.splice(arrIndex, 1);
            } else {
                //数组中数据项取完后,退出循环,比如数组本来只有10项,但要求取出20项.
                break;
            }
        }
        return return_array;
    }
    //点击开始的按钮		
    $(".btn_start").click(function () {
        againbtn();
    });

    //点击暂停的按钮需要抽取五个数据时调用
    $(".btn_pause").click(function () {
        //五个数据时调用这个方法
        pause_five();
        $(".panel2").show();

        //一个数据时调用这个方法
        /*pause_one();
        $(".panel3").show();*/
    });
})