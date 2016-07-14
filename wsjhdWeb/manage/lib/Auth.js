$(document).keydown(function (event) {
    if (event.keyCode == 13) {
        $("input[id*=btnSearch]").click();
        return false;
    }
})
//Add
//节点横向排列
$(function () {
    $("span").each(function (i) {
        var item = $(this).attr("href");
        if (item.indexOf("_") > -1) {
            $(this).parent().parent().parent().parent().css("float", "left");
        }
        else {
            $(this).parent().parent().parent().parent().css("clear", "both");
        }
        $(this).parent().css("position", "relative");
        $(this).css({ "vertical-align": "middle", "position": "absolute", "top": "1px" });
    });

    $("#btnSave").click(function () {
        DataAdd("reset")
    });

    $("#btnSaveEditBack").click(function () {
        DataAdd("")
    });
    $("#btnSaveAddBack").click(function () {
        DataAdd("")
    });
})

//保存修改点击事件
function DataAdd(t) {
    var DutyName = $("#txtDutyName").val();
    var Id = $("#txtId").val();
    var Mark = $("#txtMark").val();
    var XMNo = "";
    //TODO:数据有效性验证\格式验证\非空验证等
    if (DutyName == "") {
        alert("角色名称不能为空!");
        return false;
    }

    valid();

    var AuthItem = ids;
    //参数Json串
    var paras = { RqtAction: "sysQX", Id: Id, DutyName: DutyName, AuthItem: AuthItem, Mark: Mark, XMNo: XMNo };
    //   console.log(paras);
    $.post("/manage/ashx/Sys_Login.ashx", paras, function (data) {
        if (data == "Error") {
            alert("操作失败");
        }
        else {
            if (t == "reset") //写入成功之后清空文本框
            {
                $(":input", "#form1").removeAttr("checked");
                $("#txtAuthId").val("");
                $("#txtId").val("");
                $("#txtDutyName").val("");
                $("#txtMark").val("");
            }
            else //写入成功之后返回列表
            {
                //
                //                window.parent.parent.leftFrame.location.reload();
                //window.parent.leftFrame.location.reload();
                alert("操作成功");
                //document.frames('leftFrame').location.reload();
                location.href = "/manage/Manager_Groups/Manager_Groups_List.aspx";
                //window.parent.frames["leftFrame"].location.reload();
            }
        }

    }, "text");
}

$(document).ready(function () {
    var funcStr = "$(\":checkbox\").click(function(){CheckedChildNode(this);});";
    eval(funcStr);
    return false;
});
var ids = ""; //模块
var idf = ""; //功能
function valid() {
    ids = "";
    idf = "";
    var checkbox = $("input:checked");
    for (var i = 0, j = checkbox.length; i < j; i++) {
        var item = $("input:checked").eq(i).next().attr("href");
        if (item.indexOf("_") > -1) {
            idf += item + ",";
        } else {
            ids += item + ",";
        }
    }
    if (ids == "") {
        return confirm("没选中任何信息,是否继续？");
    }
    else {
        //alert(ids);
        //$("input[id*=btnSav]").click();
    }
}
function CheckedChildNode(obj) {
    var divs = obj.parentElement.parentElement.parentElement.parentElement.nextSibling;
    if (divs != null && divs.tagName == "DIV") {
        divs = divs.getElementsByTagName("input");
        for (var i = 0; i < divs.length; i++) {
            if (divs[i].type == "checkbox") {
                divs[i].checked = obj.checked;
            }
        }
    }
    if (obj.checked) {
        divs = obj.parentElement.parentElement.parentElement.parentElement.parentElement.previousSibling;
        var ips = divs.getElementsByTagName("input");
        for (var i = 0; i < ips.length; i++) {
            if (ips[i].type == "checkbox") {
                ips[i].checked = obj.checked;
            }
        }
        while (divs.parentElement != null) {
            divs = divs.parentElement;
            if (divs != null && divs.tagName == "DIV") {
                divs = divs.previousSibling;
                var ips = divs.getElementsByTagName("input");
                for (var i = 0; i < ips.length; i++) {
                    if (ips[i].type == "checkbox") {
                        ips[i].checked = obj.checked;
                    }
                }
            }
        }
    }
}