<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllMember.aspx.cs" Inherits="NewInfoWeb.manage.Manager_MemberInfo.AllMember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员列表页</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" type="text/css" href="../css/public.css" />
    <link href="/manage/css/page.css" rel="stylesheet" type="text/css" />
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <style>
        .add_user { border: 0px; color: White;  margin-left:3%;}
        .hid { display: none; }
    </style>
</head>
<body style="background: #FFF;">
    <form id="form1" runat="server">
    <div class="itempage">
        <div class="search_total" style="height: 140px">
            <div class="tit_user">
                会员管理</div>
            <div class="itme_input">
                <div class="itme_import">
                    <dt>会员名:</dt>
                    <dd>
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="select_one"></asp:TextBox>
                    </dd>
                </div>
                <asp:ImageButton ImageUrl="../images/Subminchaxun.png" ID="btn_click"  CssClass="add_user" runat="server"
                    Width="94" OnClick="btn_click_Click" />
                <%--  <a class="add_user" href="Manager_Groups_Add.aspx" style="cursor: pointer">添加角色</a>--%>
                <br class="clear_both" />
            </div>
            <div class="btnall">
                <%--            <div class="btn_forbid margin_left">
                导入Excel</div>
            <div class="btn_forbid margin_left">
                导出Excel</div>--%>
            </div>
        </div>
        <div class="list_item">
            <div class="list_item_txt">
                <table style="width: 100%">
                    <asp:Repeater ID="rptLoop" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th class="list_li_txt1" style="width: 6%">
                                    编号
                                </th>
                                <th class="list_li_txt2" style="width: 15%">
                                    昵称
                                </th>
                                <th class="list_li_txt2" style="width: 20%">
                                    联系方式
                                </th>
                                <th class="list_li_txt2" style="width: 10%">
                                    头像
                                </th>
                                <th class="list_li_txt2" style="width: 10%">
                                    业主认证
                                </th>
                                <th class="list_li_txt2" style="width: 10%;">
                                    积分
                                </th>
                                <th class="list_li_txt2" style="width: 21%">
                                    操作
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="list_li_txt4" style="width: 6%">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td class="list_li_txt3" style="width: 15%" title="<%#Eval("Name")%>">
                                    <%#Eval("Name")%>
                                </td>
                                <td class="list_li_txt3" style="width: 20%" title="<%#Eval("Mobile")%>">
                                    <%#Eval("Mobile")%>
                                </td>
                                <td class="list_li_txt3" style="width: 10%">
                                    <img src="<%#Eval("Income")%>" style="width: 44px; border-radius: 44px;" />
                                </td>
                                <td class="list_li_txt3" style="width: 10%; color: Red;">
                                    <%#Eval("FormType").ToString()=="0"?"未通过":"通过"%>
                                </td>
                                <td class="list_li_txt3" style="width: 10%">
                                    <%#Eval("JFCount")%>
                                </td>
                                <td class="list_li_txt3" style="width: 21%">
                                    <a style="color: Red;" class=' <%#Eval("FormType").ToString()=="0"?"hid":""%>' href="MemberRZList.aspx?topid=<%#Eval("Source") %>"
                                        style="color: black;">查看业主信息</a><a href="/manage/Manager_llHD/LPDHList.aspx?topid=<%#Eval("Source") %>">我的兑换</a>
                                    <a style="color: black;" href="AllMember.aspx?del=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>&key=<%#Request["key"] %>"
                                        onclick="return confirm('删除后将无法恢复，您确定要删除吗？');">删除</a><br />
                                        <a href="/manage/Manager_MemberInfo/JFList.aspx?topid=<%#Eval("Source") %>">积分详情</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <ul>
                    <li class="list_li_page"><span style="float: left; margin-top: 20px; display: none;">
                        共
                        <asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>
                        条数据</span>
                        <webdiyer:AspNetPager ID="AspNetPager1" ShowCustomInfoSection="Left" Visible="true"
                            runat="server" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowInputBox="Always"
                            ShowBoxThreshold="10" PageSize="15" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                            PagingButtonSpacing="0" CurrentPageButtonClass="active" TextBeforePageIndexBox="跳转到第"
                            TextAfterPageIndexBox="页" NumericButtonCount="5" ShowPageIndexBox="Always" CustomInfoHTML="共%PageCount%页,每页显示%Pagesize%条数据，%RecordCount%条数据">
                        </webdiyer:AspNetPager>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
