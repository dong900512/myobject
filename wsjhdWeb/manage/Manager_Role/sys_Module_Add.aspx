<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Module_Add.aspx.cs"
    Inherits="NewInfoWeb.manage.Manager_Role.sys_Module_Add" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>模块信息管理</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/manage/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/manage/css/ace.min.css" />
    <script src="/js/lib/jquery-1.10.2.min.js"></script>
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
                    <small>&nbsp;&nbsp;<input type="button" id="Button1" class="button01" value="上一步"
                        onclick="javascript:history.go(-1);" /></small>
                </div>
                <div class="row-fluid">
                    <div class="control-group">
                        <label class="control-label" for="form-field-1" style="color: #757575; font-size: 16px;">
                            父级名称</label>
                        <div class="controls">
                            <label style="margin-top: 5px; font-size: 16px;" runat="server" id="lbTitle">
                            </label>
                        </div>
                    </div>
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
                            <input type="text" value="0" id="txt_MenuOrder" runat="server" style="width: 50px"
                                onkeyup="if(isNaN(value))execCommand('undo')" />
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
    </form>
</body>
</html>
