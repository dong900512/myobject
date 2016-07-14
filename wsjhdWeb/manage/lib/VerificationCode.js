// JavaScript Document

var code; //在全局 定义验证码  
function createCode(obj) {
	code = "";
	var codeLength = 4; //验证码的长度  
	var checkCode = document.getElementById(obj);
	var selectChar = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9); //所有候选组成验证码的字符，当然也可以用中文的  

	for (var i = 0; i < codeLength; i++) {


		var charIndex = Math.floor(Math.random() * 10);
		code += selectChar[charIndex];
	}
	//       alert(code);  
	if (checkCode) {
		checkCode.className = "code";
		checkCode.value = code;
	}
}


function DataValidate()
{
	var DataBol=true;
	
	$("input[DataValid='Valid']").each(function () {
		var t=$(this).attr("DataType");  //验证类型
		var e=$(this).attr("ErrorType"); //错误id
		var i=$(this).attr("ErrorInfo"); //错误信息
		switch (t)
		{
			case 'Text':
				if(IsNull($(this).val()))
				{
					$('#'+e).html(i).show();
					DataBol=false;
				}else
				{
					$('#'+e).hide();
				}
				break;
			case 'Code':
				if($(this).val()!=code)
				{
					$('#'+e).html(i).show();
					DataBol=false;
				}
				else
				{
					$('#'+e).hide();
				}
				break;
		}
    })

    return DataBol;
	
}