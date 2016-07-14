<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Module_Manage.aspx.cs"
    Inherits="NewInfoWeb.manage.Manager_Role.sys_Module_Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>模块信息管理</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/manage/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/manage/css/ace.min.css" />
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/manage/lib/Module.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
    <div class="container-fluid" id="main-container">
        <div class="clearfix">
            <div id="page-content" class="clearfix">
                <div class="page-header position-relative">
                    <h1>
                        模块管理</h1>
                    <small>&nbsp;&nbsp;
                        <asp:Button ID="btnDel" runat="server" Style="height: 25px; cursor: hand; cursor: pointer;"
                            Text="删除" OnClientClick="return confirm('您确定进行删除操作吗？')" OnClick="btnDel_Click" />
                        &nbsp;&nbsp;<input type="button"  onclick="javascript:location.href='sys_Module_Add.aspx?nodeText=<%=nodeText%>&nodeValue=<%=nodeValue%>&nodeID=<%=nodeID%>&iszcd=0'"
                            style=" height: 25px; cursor: hand; cursor: pointer;" value="添加子模块" class="btnaddChild"  id="btnaddChild"/>
                    </small>
                </div>
                <div class="row-fluid">
                    <div class="control-group">
                        <label class="control-label" for="form-field-2" style="color: #757575; font-size: 16px;">
                            <font color="red">*</font>&nbsp;模块名称</label>
                        <div class="controls">
                            <input type="text" id="txt_MenuNameC" runat="server" placeholder="模块名称不能为空" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="form-field-2" style="color: #757575; font-size: 16px;">
                            显示顺序</label>
                        <div class="controls">
                            <input type="text" id="txt_MenuOrder" runat="server" style="width: 50px" onkeyup="if(isNaN(value))execCommand('undo')" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="form-field-2" style="color: #757575; font-size: 16px;">
                            链接地址</label>
                        <div class="controls">
                            <input type="text" id="txt_MenuUrl" runat="server" style="width: 206px" />
                        </div>
                    </div>
                    <div class="form-actions">
                        <button class="btn btn-info" type="button" id="save" onclick="return save_onclick()">
                            <i class="icon-ok"></i>保存</button>
                        &nbsp; &nbsp;
                        <button class="btn btn-info" type="button" id="reset" onclick="return reset_onclick()">
                            <i class="icon-ok"></i>重置</button>
                    </div>
                    <span style="display: none;">
                        <asp:Button ID="btnSave" runat="server" Text="Button" OnClientClick="return valCode()"
                            OnClick="btnSave_Click" /></span>
                    <div class="space-24ger">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function getQueryString(key) {
            var value = "";
            var sURL = window.document.URL;

            if (sURL.indexOf("?") > 0) {
                var arrayParams = sURL.split("?");
                var arrayURLParams = arrayParams[1].split("&");

                for (var i = 0; i < arrayURLParams.length; i++) {
                    var sParam = arrayURLParams[i].split("=");

                    if ((sParam[0] == key) && (sParam[1] != "")) {
                        value = sParam[1];
                        break;
                    }
                }
            }

            return value;
        }
        if (getQueryString("isno")=="0") {
            $(".btnaddChild").hide();
        }
       
    </script>
    </form>
</body>
</html>
