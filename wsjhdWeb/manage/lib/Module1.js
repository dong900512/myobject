﻿
//sys_Module_Menu.aspx
function editshow(Text, Value, ID, Url, isno) {
    if (Value == "0") {
        window.parent.right.location.href = "sys_City_Add.aspx?nodeText=" + Text + "&nodeValue=" + Value + "&nodeID=" + ID + "&Url=" + Url;
    }
    else {
        if (isno == "isno") {
            window.parent.right.location.href = "sys_City_Manage.aspx?nodeText=" + Text + "&nodeValue=" + Value + "&nodeID=" + ID + "&Url=" + Url + "&isno=0";
        } else {
            window.parent.right.location.href = "sys_City_Manage.aspx?nodeText=" + Text + "&nodeValue=" + Value + "&nodeID=" + ID + "&Url=" + Url;
        }
    }

}
//sys_Module_Manage.aspx  or  sys_Module_Add.aspx
function valCode() {
    var txt_MenuNameC = document.getElementById("txt_MenuNameC").value;
    if (txt_MenuNameC.length == 0) {
        alert("城市/项目名称不能为空!");
        return false;
    }
    var txtPno = document.getElementById("txtpNo").value;
    if (txtPno.length == 0) {
        alert("城市/项目编号不能为空!");
        return false;
    }
    return true;
}
function save_onclick() {
    var txt_MenuNameC = document.getElementById("txt_MenuNameC").value;
    if (txt_MenuNameC.length == 0) {
        alert("城市/项目名称不能为空!");
        return false;
    }
    var txtPno = document.getElementById("txtpNo").value;
    if (txtPno.length == 0) {
        alert("城市/项目编号不能为空!");
        return false;
    }
    $("#btnSave").click();
}
function reset_onclick() {
    //location.href = "sys_Module_Manage.aspx?nodeText=<%=nodeText %>&nodeValue=<%=nodeValue %>&nodeID=<%=nodeID %>&Url=<%=Url %>";
    $("#txt_MenuCode").val("");
    $("#txt_MenuNameC").val("");
    $("#txt_MenuOrder").val("");
    $("#txt_MenuUrl").val("");
}

