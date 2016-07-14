/*-----------------------------------------自定义业务校验-------------------------------------*/
//非空验证
function IsNull(val) {
    if (val == "")
        return true;
}

//电子邮箱验证
function IsEmail(val) {
    reg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//手机号码
function IsMobile(val) {
    reg = /(86)*0*13\d{9} /;
    if (reg.test(val))
        return true;
    else
        return false;
}
//域名
function IsDomain(val) {
    reg = new RegExp("[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(/.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+/.?");
    if (reg.test(val))
        return true;
    else
        return false;
}
////URL
function IsURL(val) {
    reg = new RegExp("^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$");
    if (reg.test(val))
        return true;
    else
        return false;
}
//电话号码(/XXX-XXXXXXX/、/XXXX-XXXXXXXX/、/XXX-XXXXXXX/、/XXX-XXXXXXXX/、/XXXXXXX/和/XXXXXXXX)
function IsTel(val) {
    reg = new RegExp("^(\(\d{3,4}-)|\d{3.4}-)?\d{7,8}$");
    if (reg.test(val))
        return true;
    else
        return false;
}

//国内电话号码(0511-4405222、021-87888822)
function IsTel2(val) {
    reg = /\d{3}-\d{8}|\d{4}-\d{7}/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//身份证号(15位、18位数字)
function IsIDCard(val) {
    reg = /^\d{15}|\d{18}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//短身份证号码(数字、字母x结尾)
function IsIDShort(val) {
    reg = /^([0-9]){7,18}(x|X)?$ 或 ^\d{8,18}|[0-9x]{8,18}|[0-9X]{8,18}?$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//帐号是否合法(字母开头，允许n-m字节，允许字母数字下划线)
function IsAccount(val) {
    reg = /^[a-zA-Z][a-zA-Z0-9_]{4,19}$/;
    if (reg.test(val))
        return true;
    else 
        return false;      
}
//密码(以字母开头，长度在n~m之间，只能包含字母、数字和下划线)
function IsPwd(val) {
    reg = /^[a-zA-Z]\w{4,29}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//强密码(必须包含大小写字母和数字的组合，不能使用特殊字符，长度在n-m之间)
function IsStrangPwd(val, n, m) {
    reg = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{n,m}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//日期格式
function IsDate(val) {
    reg = /^\d{4}-\d{1,2}-\d{1,2}/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//一年的12个月(01～09和1～12)
function IsMonth(val) {
    reg = /^(0?[1-9]|1[0-2])$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//一个月的31天(01～09和1～31)
function IsDay(val) {
    reg = /^((0?[1-9])|((1|2)[0-9])|30|31)$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//中国邮政编码中国邮政编码为6位数字
function IsZip(val) {
    reg = /[1-9]\d{5}(?!\d)/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//IP地址
function IsIP(val) {
    reg = /\d+\.\d+\.\d+\.\d+/;
    if (reg.test(val))
        return true;
    else
        return false;
}

/*----------------------------数字校验-------------------------------------*/
//数字
function IsNumber(val) {
    reg = /^[0-9]*$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//n位的数字
function IsNumberOfLen(val, n) {
    reg = /^\d{n}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//至少n位的数字
function IsNumMoreThanLen(val, n) {
    reg = /^\d{n,}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//n-m位的数字
function IsMtoN(val, n, m) {
    reg = /^\d{n,m}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//带n-m位小数的正数或负数
function IsNumber2(val, n, m) {
    reg = /^(\-)?\d+(\.\d{n,m})?$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//正数、负数、和小数
function IsNumber3(val) {
    reg = /^(\-|\+)?\d+(\.\d+)?$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//有n位小数的正实数
function IsNumber4(val, n) {
    reg = /^[0-9]+(.[0-9]{n})?$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//有n~m位小数的正实数
function IsNumber5(val, n, m) {
    reg = /^[0-9]+(.[0-9]{n,m})?$/;
    if (reg.test(val))
        return true;
    else
        return false;
}

/*------------------------校验字符的表达式-------------------------------------*/

//只能输入汉字
function IsCN(val) {
    reg = /^[\u4e00-\u9fa5]{0,}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//n-m位英文和数字
function IsENandNum(val,n,m) {
    reg = /^[A-Za-z0-9]+$ 或 ^[A-Za-z0-9]{n-1,m-1}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//只能英文和数字
function IsENandNum(val) {
    reg = /^[A-Za-z0-9]+$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//长度为n-m的所有字符
function IsChar(val,n,m) {
    reg = /^.{n,m}$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//由26个英文字母组成的字符串
function IsChar26(val) {
    reg = /^[A-Za-z]+$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//由26个大写英文字母组成的字符串
function IsENCharUP(val) {
    reg = /^[A-Z]+$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//由26个小写英文字母组成的字符串
function IsENCharLower(val) {
    reg = /^[a-z]+$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//由数字和26个英文字母组成的字符串
function IsENandNum26(val) {
    reg = /^[A-Za-z0-9]+$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//中文、英文、数字包括下划线
function IsENandNumLine(val) {
    reg = /^[\u4E00-\u9FA5A-Za-z0-9_]+$/;
    if (reg.test(val))
        return true;
    else
        return false;
}
//中文、英文、数字但不包括下划线等符号
function IsENandNumNotLine(val) {
    reg = /^[\u4E00-\u9FA5A-Za-z0-9]+$/;
    if (reg.test(val))
        return true;
    else
        return false;
}

//可以输入含有^%&',;=?$\/等特殊字符
function IsCharSpecial(val) {
    reg = /[^%&',;=?$\x22]+/;
    if (reg.test(val))
        return true;
    else
        return false;
}