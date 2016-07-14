<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_Groups_Add.aspx.cs"
    Inherits="NewInfoWeb.manage.Manager_Groups.Manager_Groups_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/manage/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/manage/css/ace.min.css" rel="stylesheet" type="text/css" />
    <link href="/manage/css/public.css" rel="stylesheet" type="text/css" />
    <script src="/js/lib/jquery-1.10.2.min.js"></script>
    <script src="/manage/lib/Auth.js" type="text/javascript"></script>
    <style type="text/css">
        .abc table { display: inline; }
        #TreeView1 { margin-top: -11%; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid" id="main-container">
        <div id="main-content" class="clearfix">
            <div id="page-content" class="clearfix">
                <!--页面标题区-->
                <div class="add_txt" style="padding-left: 20px;">
                    添加角色</div>
                <input type="hidden" name="name" id="txtId" value="<%=strID %>" />
                <div class="row-fluid">
                    <div class="control-group">
                        <table style="margin-left: 5%;">
                            <tr>
                                <td>
                                    <table style="width: 500px;">
                                        <tr>
                                            <td style="width: 120px; font-size: 17px; color: #757575">
                                                角色名称&nbsp;<font color="red">*</font>
                                            </td>
                                            <td>
                                                <div class="infot_input">
                                                    <input type="text" id="txtDutyName" runat="server" value="" class="input_txt" style="height: 17px;
                                                        margin-top: 10px; border: 0px none; background-color: #FFF; font-size: 17px;"
                                                        placeholder="角色名称不能为空" />
                                                    <input type="hidden" id="Hidden1" name="name" value="<%=strID %>" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 500px;">
                                        <tr>
                                            <td style="width: 120px; font-size: 17px; color: #757575">
                                                角色描述&nbsp;<font color="red">*</font>
                                            </td>
                                            <td>
                                                <div class="infot_input">
                                                    <input type="text" id="txtMark" runat="server" class="input_txt" style="height: 17px;
                                                        margin-top: 10px; border: 0px none; font-size: 17px;" placeholder="角色描述" value="" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px; font-size: 17px; color: #757575">
                                    <label style="margin-top: 20px; font-size: 17px; color: #757575">
                                        权&nbsp;限</label>
                                    <table style="width: 500px;">
                                        <tr>
                                            <td style="width: 120px">
                                            </td>
                                            <td>
                                                <asp:TreeView ID="TreeView1" LeafNodeStyle-CssClass="abc" ShowCheckBoxes="All" runat="server">
                                                    <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                                                    <NodeStyle Font-Names="Tahoma" Font-Size="12pt" ForeColor="#757575" HorizontalPadding="5px"
                                                        NodeSpacing="0px" VerticalPadding="0px" />
                                                    <ParentNodeStyle Font-Bold="False" />
                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                </asp:TreeView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <div class="form-actions" style="background: none">
                                        <button class="btn btn-info" type="button" id="btnSaveEditBack" onclick="" style="width: 80px;">
                                            <i class="icon-ok"></i>确定</button>
                                        &nbsp; &nbsp;
                                        <button class="btn" type="button" id="back" onclick="javascript:history.go(-1);"
                                            style="width: 80px;">
                                            <i class="icon-undo"></i>返回</button>
                                        <%--         <asp:ImageButton ImageUrl="../images/affirmimg.png" ID="btn_click" runat="server"
                        Width="94" OnClientClick=" DataAdd('')"/>--%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
