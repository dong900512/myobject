/*******************************
* @Copyright:智讯科技
* @Creation date:2014.06.15
* @Author:Neil_song
*******************************/
if (navigator.userAgent.toLowerCase().match(/MicroMessenger/i) != 'micromessenger' && navigator.userAgent.toLowerCase().match(/Windows Phone/i) != 'windows phone') {
    // window.location.href = '/';
}

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
KISSY.use('node,io,json', function (S, Node, IO, JSON) {
    var $ = Node.all;
    function loadImages(sources, callback) {
        var count = 0,
				images = {},
				imgNum = 0;
        for (src in sources) {
            imgNum++;
        }
        for (src in sources) {
            images[src] = new Image();
            images[src].onload = function () {
                if (++count >= imgNum) {
                    callback(images);
                }
            }
            images[src].src = sources[src];
        }
    }
    loadImages(['/image/bg-loader.jpg', '/image/ico-logo.png', '/image/sales-bg-loader.jpg', '/image/ico-sales-logo.png', '/image/recommend-tips.png', '/image/recommend-submit.png', '/image/recommend-logo.png', '/image/icon-jjr.png', '/image/icon-prize.png', '/image/gift_11.png', '/image/gift_01.png'], function () {
        setTimeout(function () {
            $('.loader').addClass('fadeOut').hide();
            $('.user-loader').addClass('fadeOut').hide();
            $('.main-box').addClass('fadeIn');
            $('#loading-style').remove();
        }, 1000);
    });

    var REG = {
        name: /^[a-zA-Z\u4e00-\u9fa5]{2,12}$/,
        phone: /(^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$)|(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/,
        wxid: /^[a-zA-Z][a-zA-Z0-9_-]{5,19}$/,
        number: /^[+\-]?\d+(\.\d+)?$/,
        idCard: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/
    }
    var userStatus = { 0: '无效', 1: '新客户', 2: '已跟进', 3: '到访', 4: '认筹', 5: '认购', 6: '签约', 7: '回款', 8: '导入客户' }

    //经纪人注册
    var submit_broker = $('#J_submitReg');
    var companyName = $('.company-name');
    var name = $('#name');
    var phone = $('#phone');
    var uid = $('#uid').val();
    var waid = $('#waid').val();
    var job = $('#job');
    var password = $('#password');
    var company = $('#company');
    var agree = $('#agree');
    var DATA = {}

    if (job.val() == 'ZJGS' || job.val() == 'DLGS' || job.val() == 'HZHB' || job.val() == 'HZSP') {
        companyName.show();
    } else {
        companyName.hide();
    }

    job.on('change', function () {
        if (job.val() == 'ZJGS' || job.val() == 'DLGS' || job.val() == 'HZHB' || job.val() == 'HZSP') {
            companyName.show();
        } else {
            companyName.hide();
        }

        if (job.val() == 'GSYG') {
            $('#check_code_area').show();
        } else {
            $('#check_code_area').hide();
        }
    });

    submit_broker.on('click', function () {
        var safe_check = $('#safe_check').val();

        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (name.length > 6) {
                alert('姓名不能超过6个字！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        //密码
        if (password.length == 1) {
            var psw = S.trim(password.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }

        //职业
        if (job.length == 1) {
            var prv = job.val();
            var prCompany = S.trim(company.val());
            if (prv == 0) {
                alert('请选择您的职业');
                return false;
            } else if (prv == 'ZJGS' || prv == 'DLGS' || prv == 'HZHB' || prv == 'HZSP') {
                if (prCompany == '') {
                    alert('公司名称不能为空！');
                    return false;
                }
            }
            DATA.job = prv;
            DATA.company = prCompany;
        }
        //注册协议
        if (agree.prop('checked') == false) {
            alert('请同意注册协议');
            return false;
        }
        //验证码
        if (safe_check == true && job.val() == 'GSYG') {
            var check_code = S.trim($('#check_code').val());
            if (check_code == "") {
                alert('验证码不能为空！');
                return false;
            } else {
                DATA.check_code = check_code;
            }
        }

        DATA.uid = uid;
        DATA.waid = waid;
        DATA.safe_check = safe_check;
        DATA.type = "IsExits";
        DATA.tmpopid = $("#hidopid").val();
        //请求
        IO.post('/ashx/OperatInfo.ashx', DATA, function (data) {
            if (data.status == 200) {
                DATA.type = "AddInfo";
                IO.post('/ashx/OperatInfo.ashx', DATA, function (data) {
                    if (data.status == 200) {
                        alert("注册成功");
                        location.href = "/jjrinfo/center.aspx";
                    } else {
                        alert("注册失败");
                    }
                }, 'json');

            } else {
                if (data.status == 300) {
                    alert(data.message);
                } else {
                    alert('参数有误或系统异常，请稍后重试！');
                }
            }
        }, 'json');
    });

    /******************** 机构经纪人注册 ********************/
    var register_company = $('#register_company');
    var cpid = $('#cpid').val();
    register_company.on('click', function () {
        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (name.length > 6) {
                alert('姓名不能超过6个字！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        //密码
        if (password.length == 1) {
            var psw = S.trim(password.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }
        //注册协议
        if (agree.prop('checked') == false) {
            alert('请同意注册协议');
            return false;
        }

        DATA.uid = uid;
        DATA.waid = waid;
        DATA.cpid = cpid;

        //请求
        IO.post('/Home/Index/editUser', DATA, function (data) {
            if (data.status == 200) {
                DATA.type = "IsExits";
                IO.post('/Home/Company/register', DATA, function (data) {
                    if (data.status == 200) {
                        alert("注册成功");
                        var url = '/Home/Company/center';
                        location.href = url;
                    } else {
                        alert("注册失败");
                    }
                }, 'json');
            } else {
                if (data.status == 300) {
                    alert(data.message);
                } else {
                    alert('参数有误或系统异常，请稍后重试！');
                }
            }
        }, 'json');
    });

    //完善经纪人信息
    var complete = $('.confirm-btn');
    complete.on('click', function () {
        DATA.company = S.trim(company.val());
        DATA.waid = waid;
        DATA.uid = uid;
        DATA.return_url = return_url;
        //职业
        if (job.length == 1) {
            var prv = job.val();
            if (prv == 0) {
                alert('请选择您的职业');
                return false;
            }
            DATA.job = prv;
        }

        IO.post('/Home/Broker/complete', DATA, function (data) {
            if (data.status == 200) {
                alert("保存成功");
                location.href = data.return_url;
            } else {
                alert("保存失败");
            }
        }, 'json');
    });

    //老业主注册
    var submit_owner = $('#submit_owner');
    var idC = $('#idCard');
    var DATA = {}
    submit_owner.on('click', function () {
        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (name.length > 6) {
                alert('姓名不能超过6个字！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        //密码
        if (password.length == 1) {
            var psw = S.trim(password.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }
        //身份证号码验证
        if (idC.length == 1) {
            var idCard = S.trim(idC.val());
            if (idCard == '') {
                alert('身份证号码不能为空！');
                return false;
            } else if (!REG.idCard.test(idCard)) {
                alert('身份证号码不正确！');
                return false;
            }
            DATA.idCard = idCard;
        }


        //注册协议
        if (agree.prop('checked') == false) {
            alert('请同意注册协议');
            return false;
        }

        DATA.uid = uid;
        DATA.waid = waid;

        //请求
        IO.post('/Home/Index/editUser', DATA, function (data) {
            if (data.status == 200) {
                IO.post('/Home/Owner/register', DATA, function (data) {
                    if (data.status == 200) {
                        alert("注册成功");
                        location.href = '/Home/Broker/center';
                    } else if (data.status == 300) {
                        alert(data.message);
                        window.location.reload();
                    } else {
                        alert(data.message);
                    }
                }, 'json');
            } else {
                if (data.status == 300) {
                    alert(data.message);
                } else {
                    alert('参数有误或系统异常，请稍后重试！');
                }
            }
        }, 'json');
    });

    //经纪人登录
    var J_login = $('#J_login');
    var userPsw = $('#user-psw');
    J_login.on('click', function () {
        //密码
        if (userPsw.length == 1) {
            var psw = S.trim(userPsw.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }

        DATA.username = $('#user-name').val();
        //        DATA.return_url = return_url;
        DATA.type = "login";
        IO.post('/ashx/OperatInfo.ashx', DATA, function (data) {
            if (data.status == 200) {
                //alert(data.opid);
                location.href = "JJRInfo.aspx?useropenid=" + data.opid;
            } else {
                alert('帐号或密码错误');
            }
        }, 'json');
    });

    /******************** 机构经纪人登录 ********************/
    var login_company = $('#login_company');
    login_company.on('click', function () {
        //密码
        if (userPsw.length == 1) {
            var psw = S.trim(userPsw.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }

        DATA.uid = uid;
        DATA.waid = waid;

        IO.post('/Home/Company/login', DATA, function (data) {
            if (data.status == 200) {
                location.href = data.return_url;
            } else {
                alert('密码错误');
            }
        }, 'json');
    });

    //置业顾问登录
    var J_login_con = $('#J_login_con');
    J_login_con.on('click', function () {
        //密码
        if (userPsw.length == 1) {
            var psw = S.trim(userPsw.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }

        DATA.uid = uid;
        DATA.waid = waid;

        IO.post('/Home/Consultant/login', DATA, function (data) {
            if (data.status == 200) {
                location.href = '/Home/Consultant/newCustomer';
            } else {
                alert('密码错误');
            }
        }, 'json');
    });

    //案场经理登录
    var J_login_man = $('#J_login_man');
    J_login_man.on('click', function () {
        //密码
        if (userPsw.length == 1) {
            var psw = S.trim(userPsw.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }

        DATA.uid = uid;
        DATA.waid = waid;

        IO.post('/Home/Manager/login', DATA, function (data) {
            if (data.status == 200) {
                location.href = '/Home/Manager/managerIndex';
            } else {
                alert('密码错误');
            }
        }, 'json');
    });

    //个人中心登录
    var J_login_my = $('#J_login_my');
    var wz_time = $('#wz_time').val();
    var wz_token = $('#wz_token').val();
    J_login_my.on('click', function () {
        //密码
        if (userPsw.length == 1) {
            var psw = S.trim(userPsw.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }

        DATA.uid = uid;
        DATA.waid = waid;
        DATA.wz_time = wz_time;
        DATA.wz_token = wz_token;

        IO.post('/Home/Index/login', DATA, function (data) {
            if (data.status == 200) {
                location.href = data.url;
            } else {
                alert('密码错误');
            }
        }, 'json');
    });

    //老业主登录
    var J_login_owner = $('#J_login_owner');
    var userPsw = $('#user-psw');
    J_login_owner.on('click', function () {
        //密码
        if (userPsw.length == 1) {
            var psw = S.trim(userPsw.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }

        DATA.uid = uid;
        DATA.waid = waid;

        IO.post('/Home/Owner/login', DATA, function (data) {
            if (data.status == 200) {
                location.href = '/Home/Broker/center';
            } else {
                alert('密码错误');
            }
        }, 'json');
    });


    //案场经理注册
    var submit_consultant = $('#J_submitMan');
    var code = $('#code');
    var DATA = {}
    submit_consultant.on('click', function () {
        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        //密码
        if (password.length == 1) {
            var psw = S.trim(password.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }
        //邀请码
        if (code.length == 1) {
            var prv = code.val();
            if (prv == 0) {
                alert('请输入邀请码');
                return false;
            }
            DATA.code = prv;
        }
        //注册协议
        if (agree.prop('checked') == false) {
            alert('请同意注册协议');
            return false;
        }
        DATA.uid = uid;
        DATA.waid = waid;
        DATA.code = code.val();

        IO.post('/Home/Manager/check', DATA, function (data) {
            if (data.status == 200) {
                //请求
                IO.post('/Home/Index/editUser', DATA, function (data) {
                    if (data.status == 200) {
                        IO.post('/Home/Manager/register', DATA, function (data) {
                            if (data.status == 200) {
                                alert("注册成功");
                                location.href = '/Home/Manager/managerIndex';
                            } else {
                                alert("注册失败");
                            }
                        }, 'json');

                    } else {
                        if (data.status == 300) {
                            alert(data.message);
                        } else {
                            alert('参数有误或系统异常，请稍后重试！');
                        }
                    }
                }, 'json');
            } else {
                alert(data.message);
            }
        }, 'json');
    });


    //置业顾问注册
    var submit_manager = $('#J_submitCon');
    var DATA = {}
    submit_manager.on('click', function () {
        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        //密码
        if (password.length == 1) {
            var psw = S.trim(password.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }
        //邀请码
        if (code.length == 1) {
            var prv = code.val();
            if (prv == 0) {
                alert('请输入邀请码');
                return false;
            }
            DATA.code = prv;
        }
        //注册协议
        if (agree.prop('checked') == false) {
            alert('请同意注册协议');
            return false;
        }
        DATA.uid = uid;
        DATA.waid = waid;
        DATA.code = code.val();
        DATA.company = $('#company').val();

        IO.post('/Home/Consultant/check', DATA, function (data) {
            if (data.status == 200) {
                //请求
                IO.post('/Home/Index/editUser', DATA, function (data) {
                    if (data.status == 200) {
                        IO.post('/Home/Consultant/register', DATA, function (data) {
                            if (data.status == 200) {
                                alert("注册成功");
                                location.href = '/Home/Consultant/newCustomer';
                            } else {
                                alert("注册失败");
                            }
                        }, 'json');

                    } else {
                        if (data.status == 300) {
                            alert(data.message);
                        } else {
                            alert('参数有误或系统异常，请稍后重试！');
                        }
                    }
                }, 'json');
            } else {
                alert(data.message);
            }
        }, 'json');
    });

    //设置密码
    var J_submitPass = $('#J_submitPass');
    var setPassURL = $('#setPassURL').val();
    var return_url = $('#return_url').val();
    J_submitPass.on('click', function () {
        //密码
        if (password.length == 1) {
            var psw = S.trim(password.val());
            if (psw == '') {
                alert('密码不能为空！');
                return false;
            } else if (psw.length < 6 || psw.length > 8 || !REG.number.test(psw)) {
                alert('密码必须为6到8个数字！');
                return false;
            }
            DATA.password = psw;
        }

        DATA.opid = $("#uid").val();
        DATA.waid = waid;
        DATA.return_url = return_url;
        DATA.type = "SetPaswordInfo";
        IO.post("/ashx/OperatInfo.ashx", DATA, function (data) {
            if (data.status == 200) {
                location.href = "center.aspx";
            } else {
                alert('密码错误');
            }
        }, 'json');
    });

    //我要推荐提交
    var submitRec = $('#J_submitRec');
    var url = $('#submit_url').val();
    var floor = $('#floor');
    var remark = $('#remark');
    var isOwner = $('#isOwner').val();
    var message_url = $('#message_url').val();
    var DATA = {}
    submitRec.on('click', function () {
        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (nv.length > 6) {
                alert('姓名不能超过6个字！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        //意向楼盘
        if (floor.length == 1) {
            var prv = floor.val();
            if (prv == 0) {
                alert('请选择您的户型面积');
                return false;
            }
            DATA.floor = prv;
        }
        if (remark.length == 1) {
            var pre = S.trim(remark.val());
            if (pre.length > 50) {
                alert('备注不能超过50个字');
                return false;
            }
            DATA.remark = pre;
        }

        if (isOwner == 1) {//老业主推荐
            var zphone = S.trim($('#zphone').val());
            if (zphone != '') {//输入置业顾问电话
                if (!REG.phone.test(zphone)) {
                    alert('请填写正确的置业顾问手机号！');
                    return false;
                }
                DATA.zphone = zphone;
            }
        }

        var _token = $("#valid_token").val();
        DATA.token = _token;
        DATA.type = "AddRecomd";
        DATA.regId = $("#hidopid").val();
        //请求
        IO.post("/ashx/OperatInfo.ashx", DATA, function (data) {
            if (data.status == 200) {
                //                //获取佣金提示信息并弹窗显示
                //                IO.post(message_url, { pid: prv }, function (message) {
                //                    if (message != null) {
                //                        $('.user-get').html(message);
                //                    } else {
                //                        $('.recommend-text').hide();
                //                    }
                //                    //推荐弹出层
                //                    $('.recommend-pop').show();
                //                    $('.pop-bg').show();
                //                }, 'json');
                alert(data.message);
                window.location.reload();
            } else {
                alert(data.message);
                window.location.reload();
            }
        }, 'json');
    });

    //机构经纪人推荐客户提交
    var submitRec = $('#J_submitComRec');
    submitRec.on('click', function () {
        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (nv.length > 6) {
                alert('姓名不能超过6个字！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        //意向楼盘
        if (floor.length == 1) {
            var prv = floor.val();
            if (prv == 0) {
                alert('请选择您意向的楼盘');
                return false;
            }
            DATA.floor = prv;
        }
        if (remark.length == 1) {
            var pre = S.trim(remark.val());
            if (pre.length > 50) {
                alert('备注不能超过50个字');
                return false;
            }
            DATA.remark = pre;
        }

        //请求
        IO.post(url, DATA, function (data) {
            if (data.status == 200) {
                $('.recommend-text').hide();
                $('.recommend-pop').show();
                $('.pop-bg').show();
            } else {
                alert(data.message);
            }
        }, 'json');
    });

    //保存银行卡信息
    var saveCard = $('#J_saveCard');
    var url = $('#submit_url').val();
    var accountName = $('#bankAccount');
    var card = $('#cardCode');
    var bank = $('#bankName');
    var DATA = {}
    saveCard.on('click', function () {
        //户名
        if (accountName.length == 1) {
            var account = S.trim(accountName.val());
            if (account == '') {
                alert('户名不能为空！');
                return false;
            } else if (!REG.name.test(account)) {
                alert('请填写正确的户名！');
                return false;
            }
            DATA.account = account;
        }

        //银行卡号
        if (card.length == 1) {
            var num = S.trim(card.val());
            if (num == '') {
                alert('银行卡号不能为空！');
                return false;
            } else if (!REG.number.test(num)) {
                alert('请填写正确的银行号！');
                return false;
            }
            DATA.card = num;
        }
        //银行卡名称
        if (bank.length == 1) {
            var name = S.trim(bank.val());
            if (name == '') {
                alert('银行名称不能为空！');
                return false;
            }
            DATA.bank = name;
        }
        DATA.Pid = $("#hidPid").val();
        DATA.type = "AddBank";
        //请求
        IO.post("/ashx/OperatInfo.ashx", DATA, function (data) {
            if (data.status == 200) {
                window.location.href = "yjinfo.aspx?tmpopid=" + data.url;
            } else {
                alert(data.message);
            }
        }, 'json');

    });

    //客户详情操作
    var clientStates = $('.client-states a');
    var bg = $('.pop-bg');
    var cid = $('#cid').val();
    var zid = $('#zid').val();
    var statusUrl = $('#statusUrl').val();
    clientStates.on('click', function () {
        var self = $(this);
        var now_status = $('#now_status').val();
        var status = self.attr('status');
        var num_status = status - now_status;
        if (!self.hasClass('disable-step')) {

        } else {
            if (num_status == 1) {
                var DATA = {};
                DATA.customer_id = cid;
                DATA.zid = zid;
                DATA.waid = waid;

                if (self.hasClass('follow-up')) {
                    bg.show();
                    $('body').append('<div class="pop pop-note" style="display: block;"><div class="pop-box border-box"><i class="icon icon-cancel"></i><h1>这是一个</h1><p><a href="javascript:;" class="intent" data-type = "1" >有意向客户</a></p><p><a href="javascript:;" class="intent" data-type = "0">无意向客户</a></p></div></div>')

                    var intent = $('.intent');
                    intent.on('click', function (result) {
                        DATA.status = 2;
                        DATA.intent = $(this).attr('data-type');
                        //请求
                        IO.post(statusUrl, DATA, function (data) {
                            if (data.status == 200) {
                                bg.hide();
                                $('.pop-note').remove();
                                $('#now_status').val(data.now_status);
                                self.children().children().children('.data-time').html(data.create_time);
                                self.children().children('.option').html('操作人&nbsp;&nbsp;' + data.name);
                                if (data.intent == 1) {
                                    $(".note").html('有意向客户')
                                } else {
                                    $(".note").html('无意向客户')
                                }
                                self.removeClass('disable-step');
                            } else {
                                alert('操作失败');
                            }
                        }, 'json');
                    });
                } else if (self.hasClass('floor-subscribe')) {
                    DATA.intent = 1;
                    bg.show();
                    $('body').append('<div class="pop pop-price" style=" display: block;"><div class="pop-box border-box"><i class="icon icon-cancel"></i><h1>房屋认购价格<span>（单位：元）</span></h1><input type="tel" class="input" placeholder="请输入房屋认购价格" id="subscribe" /><h1>成交房屋信息<span>（如：房号）</span></h1><input type="text" class="input" placeholder="请输入成交房屋信息" id="house_detail" /><p><a href="javascript:;" id="J_subscribeSave">保存</a></p></div></div>')
                    var subscribeSave = $('#J_subscribeSave');
                    subscribeSave.on('click', function (result) {

                        var subscribe = S.trim($('#subscribe').val());
                        var houseDetail = S.trim($('#house_detail').val());
                        if (subscribe.length == '') {
                            alert('房屋认购价格不能为空');
                            return false;
                        } else if (subscribe != '' && !REG.number.test(subscribe)) {
                            alert('房屋认购价格必须为数字');
                            return false;
                        } else {
                            DATA.subscribe = subscribe;
                            DATA.houseDetail = houseDetail;
                            DATA.status = 5;
                            //请求
                            IO.post(statusUrl, DATA, function (data) {
                                if (data.status == 200) {
                                    bg.hide();
                                    $('.pop-price').remove();
                                    $("#now_status").val(data.now_status);
                                    self.children().children().children('.data-time').html(data.create_time);
                                    self.children().children('.option').html('操作人&nbsp;&nbsp;' + data.name);
                                    self.removeClass('disable-step');
                                    $('#hidden_houseinfo').val(houseDetail);
                                } else {
                                    alert('操作失败');
                                }
                            }, 'json');
                        }
                    });
                } else if (self.hasClass('floor-price')) {
                    DATA.intent = 1;
                    bg.show();
                    $('body').append('<div class="pop pop-price" style=" display: block;"><div class="pop-box border-box"><i class="icon icon-cancel"></i><h1>房屋认购价格<span>（单位：元）</span></h1><input type="tel" class="input" placeholder="请输入房屋认购价格" id="price" /><h1>成交房屋信息<span>（如：房号）</span></h1><input type="text" class="input" placeholder="请输入成交房屋信息" id="house_detail" value="' + $('#hidden_houseinfo').val() + '" /><p><a href="javascript:;" id="J_save">保存</a></p></div></div>')
                    var save = $('#J_save');
                    save.on('click', function (result) {

                        var price = S.trim($('#price').val());
                        var house_detail = S.trim($('#house_detail').val());
                        if (price.length == 0) {
                            alert('房屋成交价格不能为空');
                            return false;
                        } else if (price != '' && !REG.number.test(price)) {
                            alert('房屋成交价格必须为数字');
                            return false;
                        } else {
                            DATA.price = price;
                            DATA.houseDetail = house_detail;
                            DATA.status = 6;
                            //请求
                            IO.post(statusUrl, DATA, function (data) {
                                if (data.status == 200) {
                                    bg.hide();
                                    $('.pop-price').remove();
                                    $("#now_status").val(data.now_status);
                                    self.children().children().children('.data-time').html(data.create_time);
                                    self.children().children('.option').html('操作人&nbsp;&nbsp;' + data.name);
                                    self.removeClass('disable-step');
                                    $('#hidden_houseinfo').val(house_detail);
                                } else {
                                    alert('操作失败');
                                }
                            }, 'json');
                        }
                    });
                } else if (self.hasClass('had-notice')) {
                    var DATA = {};
                    DATA.customer_id = cid;
                    DATA.zid = zid;
                    DATA.waid = waid;
                    DATA.intent = 1;
                    DATA.status = status;
                    bg.show();
                    $('body').append('<div class="pop pop-notice" style="display: block;"><div class="pop-box border-box"><i class="icon icon-cancel"></i><h1>是否将客户状态更新为<span style=" display: block;color:#090;" id="updateStatus">' + userStatus[status] + '</span></h1><p><a href="javascript:;" id="J_OK">确定</a></p><p><a href="javascript:;" id="J_Cancel">取消</a></p></div></div>')
                    //确定修改
                    var Yes = $('#J_OK');
                    Yes.on('click', function () {
                        bg.hide();
                        $('.pop-notice').remove();
                        IO.post(statusUrl, DATA, function (data) {
                            if (data.status == 200) {
                                $("#now_status").val(data.now_status);
                                self.children().children().children('.data-time').html(data.create_time);
                                self.children().children('.option').html('操作人&nbsp;&nbsp;' + data.name);
                                self.removeClass('disable-step');
                            } else {
                                alert('操作失败');
                            }
                        }, 'json');
                    });

                    //取消修改
                    var No = $('#J_Cancel');
                    No.on('click', function () {
                        bg.hide();
                        $('.pop-notice').remove();
                    });
                }
            } else {
                alert('请先确认上步操作')
            }
        }
        //关闭弹出层
        var cancel = $('.icon-cancel');
        cancel.on('click', function () {
            bg.hide();
            $('.pop').remove();
        });
    });


    //领取新客户
    var getCustomer = $('#getCus');
    var DATA = {};
    getCustomer.on('click', function () {
        //请求
        IO.post('/Home/Consultant/getNewCustomer', DATA, function (data) {
            if (data.status == 500) {
                alert('对不起，案场经理没有开启自动领取功能！');
            } else if (data.status == 200) {
                window.location.href = data.url;
            } else if (data.status == 100) {
                alert('新客户数超过10个，请跟进后继续领取。');
            } else if (data.status == 300) {
                alert('客户被领光了，下次早点来。');
            } else if (data.status == 400) {
                alert('领取失败，请重新领取。');
            }
        }, 'json');

    });

    var clients = $('.checkbox-btn');
    clients.on('click', function () {
        var is_pitch = $(this).children('.pitch').prop('checked');
        if (is_pitch == false) {
            $(this).children('.pitch').prop("checked", true);
        } else {
            $(this).children('.pitch').prop("checked", false);
        }
    });

    $('.pitch').on('click', function () {
        var is_pitch = $(this).prop('checked');
        if (is_pitch == false) {
            $(this).prop("checked", true);
        } else {
            $(this).prop("checked", false);
        }
    });

    //案场经理分配
    var counselorInfo = $('.counselor-info');
    counselorInfo.on('click', function (e) {
        e.preventDefault();
        var is_pitch = $(this).children('.radio-btn').children('.regular-radio').prop('checked');
        if (is_pitch) {
            $(this).children('.radio-btn').children('.regular-radio').prop('checked', false);
        } else {
            $(this).children('.radio-btn').children('.regular-radio').prop('checked', true);
        }
    });

    //选择客户分给给置业顾问
    var allow = $('#J_allow');
    var assignUrl = $('#assignUrl').val();
    allow.on('click', function () {
        var cids = new Array();
        $('.checkbox-btn .regular-checkbox').each(function () {
            if ($(this).prop('checked')) {
                cids.push($(this).val());
            }
        });
        if (cids.length > 0) {
            document.getElementById("customer_form").submit();
        } else {
            alert('您还没有选择客户！');
        };
    });

    //选择置业顾问进行分配
    var aSubmit = $('.allot-submit');
    var assignCus = $('#assignCus').val();
    aSubmit.on('click', function () {
        var selects = new Array();
        $('.regular-radio').each(function () {
            if ($(this).prop('checked') == true) {
                selects.push($(this).val());
            }
        })

        var radio = $("input[name='person']:checked").val();
        if (selects.length > 0) {
            var DATA = {}
            DATA.zid = radio;
            DATA.cids = $('#cids').val();
            DATA.flag = $('#updateFlag').val();
            IO.post(assignCus, DATA, function (data) {
                if (data.status == 200) {
                    window.location.href = data.url;
                } else {
                    alert('分配失败');
                    return false;
                }
            }, 'json');
        } else {
            alert('您还没有选择置业顾问！');
            return false;
        };
    });

    //设置是否开启自动分配客户功能
    var onOff = $('.onOff');
    var turnUrl = $('#turnUrl').val();
    var DATA = {};
    onOff.on('click', function () {
        DATA.status_lq = false;
        if (onOff.prop('checked') == true) {
            DATA.status_lq = true;
        }
        IO.post(turnUrl, DATA, function (data) {
            if (data.status == 200) {
                alert('设置成功');
            } else {
                alert('设置失败');
            }
        }, 'json');
    });

    //案场经理个人信息修改
    var editManagerInfo = $('#J_SaveManagerInfo');
    var DATA = {};
    editManagerInfo.on('click', function () {
        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (name.length > 6) {
                alert('姓名不能超过6个字！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        //请求
        IO.post('/Home/Manager/edit', DATA, function (data) {

            if (data.status == 200) {
                alert('修改成功！');
                location.href = '/Home/Manager/basicSetting';
            } else {
                alert(data.message);
            }
        }, 'json');
    })

    //编辑个人资料
    var editSave = $('#J_edit_save');
    var DATA = {}
    editSave.on('click', function () {
        //姓名
        if (name.length == 1) {
            var nv = S.trim(name.val());
            if (nv == '') {
                alert('姓名不能为空！');
                return false;
            } else if (name.length > 6) {
                alert('姓名不能超过6个字！');
                return false;
            } else if (!REG.name.test(nv)) {
                alert('请填写正确的姓名！');
                return false;
            }
            DATA.name = nv;
        }
        //手机
        if (phone.length == 1) {
            var pv = S.trim(phone.val());
            if (pv == '') {
                alert('手机号不能为空！');
                return false;
            } else if (!REG.phone.test(pv)) {
                alert('请填写正确的手机号！');
                return false;
            }
            DATA.phone = pv;
        }
        var seltag = S.trim($('#sel_tag').val());
        //职业
        if (seltag !== 'OWNER' && seltag !== 'MSDK') {
            if (job.length == 1) {
                var prv = job.val();
                var prCompany = S.trim(company.val());
                if (prv == 0) {
                    alert('请选择您的职业');
                    return false;
                } else if (job.val() == 'ZJGS' || job.val() == 'DLGS' || job.val() == 'HZHB' || job.val() == 'HZSP') {
                    if (prCompany == '') {
                        alert('公司名称不能为空！');
                        return false;
                    }
                }
                DATA.job = prv;
                DATA.company = prCompany;
            }
        } else {
            DATA.tag = seltag;
        }
        DATA.Pid = $("#hidpid").val();
        DATA.type = "modifInfo";

        //请求
        IO.post('/ashx/OperatInfo.ashx', DATA, function (data) {

            if (data.status == 200) {
                alert('修改成功！');
                window.location.href = "MyIndex.aspx?tmpopid=" + data.rgid;
            } else {
                alert(data.message);
            }
        }, 'json');
    })

    //我是案场经理
    var becomeMan = $('#J_becomeMan');
    var code = $('#code');
    var DATA = {}
    becomeMan.on('click', function () {
        //邀请码
        if (code.length == 1) {
            var prv = code.val();
            if (prv == 0) {
                alert('请输入邀请码');
                return false;
            }
            DATA.code = prv;
        }
        DATA.uid = $('#uid').val();
        DATA.waid = $('#waid').val();
        DATA.code = code.val();

        IO.post('/Home/Manager/check', DATA, function (data) {
            if (data.status == 200) {
                DATA.pid = data.pid;
                IO.post('/Home/Manager/becomeMan', DATA, function (data) {
                    if (data.status == 200) {
                        location.href = '/Home/Manager/managerIndex';
                    } else {
                        alert('操作失败');
                    }
                }, 'json');
            } else {
                alert(data.message);
            }
        }, 'json');
    });

    //我是置业顾问
    var becomeCon = $('#J_becomeCon');
    var DATA = {}
    var conCheck = $('#conCheck').val();
    becomeCon.on('click', function () {
        //邀请码
        if (code.length == 1) {
            var prv = code.val();
            if (prv == 0) {
                alert('请输入邀请码');
                return false;
            }
            DATA.code = prv;
        }

        DATA.uid = $('#uid').val();
        DATA.waid = $('#waid').val();
        DATA.code = code.val();
        DATA.company = S.trim(company.val());

        IO.post(conCheck, DATA, function (data) {
            if (data.status == 200) {
                DATA.pid = data.pid;
                IO.post(data.becomeUrl, DATA, function (data) {
                    if (data.status == 200) {
                        location.href = data.newCustomerUrl;
                    } else {
                        alert('操作失败');
                    }
                }, 'json');
            } else {
                alert(data.message);
            }
        }, 'json');
    });

    //我是老业主
    var become_owner = $('#become_owner');
    var yesOrNo = $('#yesOrNo').val();
    var idC = $('#idCard');
    var DATA = {}
    become_owner.on('click', function () {
        //身份证号码验证
        if (idC.length == 1) {
            var idCard = S.trim(idC.val());
            if (idCard == '') {
                alert('身份证号码不能为空！');
                return false;
            } else if (!REG.idCard.test(idCard)) {
                alert('身份证号码不正确！');
                return false;
            }
            DATA.idCard = idCard;
        }

        DATA.uid = uid;
        DATA.waid = waid;
        DATA.name = name.val();
        DATA.phone = phone.val();

        //请求
        IO.post(yesOrNo, DATA, function (data) {
            if (data.status == 200) {
                IO.post(data.url, DATA, function (data) {
                    if (data.status == 200) {
                        location.href = '/Home/Broker/center';
                    } else {
                        alert(data.message);
                    }
                }, 'json');
            } else {
                alert('该业主信息不存在！');
            }
        }, 'json');
    });

    //我是机构经纪人
    var become_company = $('#become_company');
    var registerCode = $('#registerCode');

    become_company.on('click', function () {
        var codeCheck = $('#codeCheck').val();
        var DATA = {}
        //注册码验证
        if (registerCode.length == 1) {
            var regCode = S.trim(registerCode.val());
            if (regCode == '') {
                alert('注册码不能为空！');
                return false;
            }
            DATA.regCode = regCode;
        }

        DATA.uid = uid;
        DATA.waid = waid;
        DATA.name = name.val();
        DATA.phone = phone.val();

        //请求
        IO.post(codeCheck, DATA, function (data) {
            if (data.status == 200) {
                location.href = data.Url;
            } else {
                alert(data.message);
            }
        }, 'json');
    });

    //初始化页面高度
    var v_h = null;     //记录设备的高度
    function init_pageH() {
        var fn_h = function () {
            if (document.compatMode == 'BackCompat')
                var Node = document.body;
            else
                var Node = document.documentElement;
            return Math.max(Node.scrollHeight, Node.clientHeight);
        }
        var page_h = fn_h();

        // //设置各种模块页面的高度，扩展到整个屏幕高度
        $('.gift').height(page_h);
        $('.regift-page').height(page_h);
    };
    init_pageH();

    //注册有礼添加动画
    setTimeout(function () {
        $('.gift-box').addClass('animated tada');
    }, 200);
    setTimeout(function () {
        $('.gift-text').addClass('animated fadeInUp');
    }, 500);
    setTimeout(function () {
        $('.gift-open').addClass('animated fadeInDown');
    }, 600);
    setTimeout(function () {
        $('.gift-flash-1').addClass('animated flash');
        $('.gift-flash-2').addClass('animated flash');
        $('.gift-flash-3').addClass('animated flash');
        $('.gift-flash-4').addClass('animated flash');
        $('.gift-flash-5').addClass('animated flash');
    }, 1200);

    //打开奖品
    var gift = $('.gift-amount');
    var prize = $('.prize');
    gift.on('click', function () {
        prize.removeClass('animated zoomOut');
        prize.addClass('animated zoomInPrice');
        bg.show();
    })

    //关闭奖品
    var prizeClose = $('.prize-close');
    prizeClose.on('click', function () {
        prize.removeClass('animated zoomInPrice');
        prize.addClass('animated zoomOut');
        bg.hide();
    })

    //分享朋友圈提示
    var share = $('.J_share');
    share.on('click', function () {
        if ($('.share-tips').length == 0) {
            $('body').append('<div class="share-tips"><a href="javascript:;" class="close">关闭</a><img src="/image/bg-guide.png" alt="" /></div>');
        }
        $('.share-tips').on('click', function () {
            $('.share-tips,.share-tips .close,.share-tips img').remove();
        });
    });

    //案场经理全选
    var checkAll = $('.checkbox-all');
    var checkOne = $('.checkbox-btn .regular-checkbox');
    checkAll.on('click', function () {
        var is_pitch = $(this).prop('checked');
        if (is_pitch) {
            checkOne.each(function () {
                $(this).prop('checked', true);
            });
        } else {
            checkOne.each(function () {
                $(this).prop('checked', false);
            });
        }
    });

    //案场经理点击checkbox
    var clients = $('.checkbox-btn');
    clients.on('click', function () {
        checkAll.prop('checked', checkOne.length == checkOne.filter(':checked').length);
    });

    //置业顾问注销
    var logOut = $('.J_logout');
    var ok_delete = $('.J_ok_delete');
    var logoutBox = $('.logout-box');
    var logoutUrl = $('#logoutUrl').val();
    logOut.on('click', function () {
        logoutBox.show();
    });
    ok_delete.on('click', function () {
        IO.post(logoutUrl, { uid: uid }, function (data) {
            if (data.status == 200) {
                location.href = data.teamUrl;
            } else {
                alert("注销失败");
            }
        }, 'json');
    });

    //关闭置业顾问注销弹出层
    var Cons_cancel = $('.Cons_cancel');
    Cons_cancel.on('click', function () {
        logoutBox.hide();
    });

    //经纪人信息显示隐藏
    var jjrTitle = $('.jjr-title');
    var jjrHide = $('.jjr-hide');
    var iconDown = $('.icon-down-open-big');
    jjrTitle.on('click', function () {
        jjrHide.toggle();
        iconDown.toggleClass('icon-down-transform');
    });

    //案场经理更改客户状态Radio选中
    var clientStatus = $('.update-client-status li .radio');
    clientStatus.on('click', function (e) {
        e.preventDefault();
        //打开签约弹出层
        if ($(this).parent('li').hasClass('write-price')) {
            var self = $(this);
            if (!$(this).children('.regular-radio').prop('checked')) {
                $('body').append('<aside class="pop-box"><div class="pop-price"><h5 class="fn-clear"><span>房屋成交价格</span><i class="J_cancel"></i></h5><div class="price-input"><input type="tel" placeholder="请填写房屋成交价格" class="input floor-price" ><input type="text" placeholder="请填写成交房屋信息" class="input house-location" style="margin-top:10px;" value="' + $('#hidden_houseinfo').val() + '"></div><a href="javascript:;" class="btn J_save_price">确&nbsp;认</a></div></aside>');

                //保存房屋成交价
                var J_save_price = $('.J_save_price');
                J_save_price.on('click', function () {
                    var price = S.trim($('.floor-price').val());
                    var locationV = S.trim($('.house-location').val());
                    if (price.length == 0) {
                        alert('房屋成交价格不能为空');
                        return false;
                    } else if (price != '' && !REG.number.test(price)) {
                        alert('房屋成交价格必须为数字');
                        return false;
                    } else {
                        $(self).children('.regular-radio').prop('checked', true);
                        $('#updated_status').val($(self).parent('li').attr('status'));
                        $('#price').val(price);
                        $('#location').val(locationV);
                        $('.pop-box').remove();
                    }
                });
                //关闭弹出层
                var J_cancel = $('.J_cancel');
                J_cancel.on('click', function () {
                    $('.pop-box').remove();
                });
            }

        } else if ($(this).parent('li').hasClass('write-subscribe')) {//认购弹出层
            var self = $(this);
            if (!$(this).children('.regular-radio').prop('checked')) {
                $('body').append('<aside class="pop-box"><div class="pop-price"><h5 class="fn-clear"><span>请填写以下信息</span><i class="J_cancel"></i></h5><div class="price-input"><input type="tel" placeholder="请填写房屋认购价格" class="input floor-subscribe" ><input type="text" placeholder="请填写成交房屋信息" class="input house-location" style="margin-top:10px;" ></div><a href="javascript:;" class="btn J_save_subscribe">确&nbsp;认</a></div></aside>');

                //保存房屋成交价
                var J_save_subscribe = $('.J_save_subscribe');
                J_save_subscribe.on('click', function () {
                    var subscribe = S.trim($('.floor-subscribe').val());
                    var location = S.trim($('.house-location').val());
                    if (subscribe.length == '') {
                        alert('房屋认购价格不能为空');
                        return false;
                    } else if (subscribe != '' && !REG.number.test(subscribe)) {
                        alert('房屋认购价格必须为数字');
                        return false;
                    } else {
                        $(self).children('.regular-radio').prop('checked', true);
                        $('#updated_status').val($(self).parent('li').attr('status'));
                        $('#subscribe').val(subscribe);
                        $('#location').val(location);
                        $('.pop-box').remove();
                    }
                });
                //关闭弹出层
                var J_cancel = $('.J_cancel');
                J_cancel.on('click', function () {
                    $('.pop-box').remove();
                });
            }

        }
        else if (!$(this).children('.regular-radio').attr('disabled')) {
            var is_pitch = $(this).children('.regular-radio').prop('checked');
            var new_status = $(this).parent('li').attr('status');
            if (is_pitch) {
                $(this).children('.regular-radio').prop('checked', false);
                $('#updated_status').val('');
                $('#intent').val('');
            } else {
                $(this).children('.regular-radio').prop('checked', true);
                $('#updated_status').val(new_status);
                $('#intent').val($(this).parent('li').attr('data-type'));
            }
        }
    });


    //案场经理修改客户状态操作
    var J_save_status = $('.J_save_status');
    var cid = $('#cid').val();
    var zid = $('#zid').val();
    var statusUrl = $('#statusUrl').val();
    J_save_status.on('click', function () {
        var now_status = $('#now_status').val();
        var updated_status = $('#updated_status').val();
        var number_status = updated_status - now_status;
        if (number_status == 1) {
            var DATA = {};
            DATA.customer_id = cid;
            DATA.zid = zid;
            DATA.waid = waid;
            if (updated_status == 2) { //已跟进（有意向无意向）
                DATA.status = 2;
                DATA.intent = $('#intent').val();
                //请求
                IO.post(statusUrl, DATA, function (data) {
                    if (data.status == 200) {
                        $('#now_status').val(data.now_status);
                        location.href = data.url;
                    } else {
                        alert('操作失败');
                    }
                }, 'json');
            } else if (updated_status == 5) {//认购
                DATA.intent = 1;
                DATA.subscribe = $('#subscribe').val();
                DATA.location = $('#location').val();
                DATA.status = 5;

                IO.post(statusUrl, DATA, function (data) {
                    if (data.status == 200) {
                        $("#now_status").val(data.now_status);
                        location.href = data.url;
                    } else {
                        alert('操作失败');
                    }
                }, 'json');
            } else if (updated_status == 6) {//签约
                DATA.intent = 1;
                DATA.price = $('#price').val();
                DATA.status = 6;
                DATA.location = $('#location').val();
                IO.post(statusUrl, DATA, function (data) {
                    if (data.status == 200) {
                        $("#now_status").val(data.now_status);
                        location.href = data.url;
                    } else {
                        alert('操作失败');
                    }
                }, 'json');
            } else {
                var DATA = {};
                DATA.customer_id = cid;
                DATA.zid = zid;
                DATA.waid = waid;
                DATA.intent = 1;
                DATA.status = updated_status;

                IO.post(statusUrl, DATA, function (data) {
                    if (data.status == 200) {
                        $("#now_status").val(data.now_status);
                        location.href = data.url;
                    } else {
                        alert('操作失败');
                    }
                }, 'json');
            }
        } else {
            alert('请先确认上步操作')
        }
    });

    //置业顾问－我的简介js
    //上传图片
    //上传图片方法
    var xhr;
    function createXMLHttpRequest() {
        if (window.ActiveXObject) {
            xhr = new ActiveXObject("Microsoft.XMLHTTP");
        }
        else if (window.XMLHttpRequest) {
            xhr = new XMLHttpRequest();
        }
    }


    function UpladFile(fileId, url, callback) {
        var fileObj = document.getElementById(fileId).files[0];
        var FileController = url;
        var form = new FormData();
        form.append("myfile", fileObj);
        createXMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4) {
                if (xhr.status == 200 || xhr.status == 0) {
                    var result = xhr.responseText;
                    callback.call(this, result);
                } else {
                    alert('网络错误！请重试！');
                }
            }
        };
        xhr.open("post", FileController, true);
        xhr.send(form);
    }
    var _descAvatar = $('.avatar');
    var _descAvatarUploader = $('.avatar_uploader');
    //上传头像
    _descAvatar.delegate('change', '.input_avatar', function (e) {
        var _self = $(this);

        _descAvatarUploader.children('span').addClass('loading');
        UpladFile('avatar', $('#upload_url').val(), function (response) {
            var _json = KISSY.JSON.parse(response);
            if (_json.status == 200) {
                var avatarimg = $('.avatarimg');
                if (avatarimg.length > 0) {
                    avatarimg.attr('src', _json.path + _json.src);
                } else {
                    var _html = '<img class="avatarimg" src="' + _json.path + _json.src + '" style="max-width:100%">';
                    _descAvatar.append(_html);
                }
                _descAvatarUploader.hide();
                $('#avatarSrc').val(_json.src);
            } else {
                alert(_json.msg);
            }
        });
    });
    //提交简介数据
    var _submitDesc = $('#submitDescBtn');
    var _description = $('#description');
    var _avatarSrc = $('#avatarSrc');
    _submitDesc.on('click', function (e) {
        e.preventDefault();
        var _self = $(this);
        if (_self.hasClass('disabled')) return false;
        var Data = {
            'description': _description.val(),
            'avatar_src': _avatarSrc.val()
        };
        new IO({
            url: saveInfoUrl,
            data: Data,
            type: 'post',
            dataType: 'json',
            beforeSend: function () {
                _self.val('提交中...').addClass('disabled');
            },
            success: function (data) {
                if (data.status == 200) {
                    _self.val('提交').removeClass('disabled');
                    window.location.href = data.url;
                } else {
                    alert(data.message);
                }

            },
            error: function () {
                _self.val('提交').removeClass('disabled');
                alert('网络错误！请重试！');
            }
        });
    });
});

