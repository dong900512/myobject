<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_User_List.aspx.cs"
    Inherits="NewInfoWeb.manage.Manager_User.Manager_User_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台用户列表</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" type="text/css" href="../css/public.css" />
    <link href="../css/page.css" rel="stylesheet" type="text/css" />
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function (e) {
            //列表的hover事件
        });
    </script>
</head>
<body style="background: #FFF;">
    <form id="form1" runat="server">
    <div class="itempage">
        <div class="search_total">
            <div class="tit_user">
                后台用户列表</div>
            <div class="itme_input">
                <div class="itme_import">
                    <dt>用户名:</dt>
                    <dd>
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="select_one"></asp:TextBox>
                    </dd>
                </div>
                <div class="itme_num">
                    <dt style=" width:40%;">每页显示条数:</dt>
                    <dd style=" width:60%;">
                        <asp:DropDownList ID="DrpTotalCount" runat="server" CssClass="select_one">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="15">15</asp:ListItem>
                        </asp:DropDownList>
                    </dd>
                </div>
                <asp:ImageButton ImageUrl="../images/Subminchaxun.png" ID="btn_click" runat="server"
                    Width="94" OnClientClick="return checkJs();" OnClick="btn_click_Click" />
                <br class="clear_both" />
            </div>
        </div>
        <div class="list_item">
            <div class="list_item_txt">
                <!--------------------------------信息读取 start--------------------------------------------->
                <table style="width: 100%">
                    <asp:Repeater ID="rpt_dataTable" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th class="list_li_txt1" style="width: 6%">
                                    编号
                                </th>
                                <th class="list_li_txt2" style="width: 10%">
                                    用户名
                                </th>
                                <th class="list_li_txt2" style="width: 10%">
                                    真实姓名
                                </th>
                                <th class="list_li_txt2" style="width: 10%">
                                    手机
                                </th>
                                <th class="list_li_txt2" style="width: 10%">
                                    角色权限
                                </th>
                                <th class="list_li_txt2" style="width: 15%">
                                    注册时间
                                </th>
                                <th class="list_li_txt2" style="width: 15%">
                                    最后登陆时间
                                </th>
                                <th class="list_li_txt2" style="width: 16%">
                                    操作
                                </th>
                                <%--  <input type="checkbox" class="list_li_radio" />--%>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="list_li_txt4" style="width: 6%">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td class="list_li_txt3" style="width: 10%">
                                    <%#Eval("LoginName") %>
                                </td>
                                <td class="list_li_txt3" style="width: 10%">
                                    <%#Eval("RealName")%>
                                </td>
                                <td class="list_li_txt3" style="width: 10%">
                                    <%#Eval("Mobile")%>
                                </td>
                                <td class="list_li_txt3" style="width: 10%">
                                    <%# getManager_GroupsName(int.Parse(Eval("SyType").ToString()))%>
                                </td>
                                <td class="list_li_txt3" style="width: 15%">
                                    
                                </td>
                                <td class="list_li_txt3" style="width: 15%">
                                  
                                </td>
                                <td class="list_li_txt3" style="width: 16%">
                                    <a href='Manager_User_Add.aspx?change=edit&UserId=<%#Eval("AccountID") %>' style="color: black;">
                                        修改</a> &nbsp;<a style="color: red;" href="Manager_User_List.aspx?del=<%#Eval("AccountID") %>&page=<%#AspNetPager1.CurrentPageIndex %>&key=<%#Request["key"] %>"
                                            onclick="return confirm('删除后将无法恢复，您确定要删除吗？');">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <!--------------------------------信息读取 end--------------------------------------------->
                <ul>
                    <li class="list_li_page">
                        <webdiyer:AspNetPager ID="AspNetPager1" ShowCustomInfoSection="Left" Visible="true"
                            runat="server" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowInputBox="Always"
                            ShowBoxThreshold="10" PageSize="8" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                            PagingButtonSpacing="0" CurrentPageButtonClass="active" TextBeforePageIndexBox="跳转到第"
                            TextAfterPageIndexBox="页" ShowPageIndexBox="Always" CustomInfoHTML="共%PageCount%页,%RecordCount%条数据">
                        </webdiyer:AspNetPager>
                    </li>
                </ul>
            </div>
        </div>
        <div class="btnall">
            <div class="add_user" onclick="window.location.href = 'Manager_User_Add.aspx'" style="cursor: pointer">
                添加用户</div>
            <%-- <div class="btn_forbid margin_left">
                导入Excel</div>
            <div class="btn_forbid margin_left">
                导出Excel</div>--%>
        </div>
    </div>
    </form>
</body>
</html>
