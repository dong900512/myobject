﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HdPostList.aspx.cs" Inherits="NewInfoWeb.manage.Manager_llHD.HdPostList" %>

<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>活动列表</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" type="text/css" href="../css/public.css" />
    <link href="/manage/css/page.css" rel="stylesheet" type="text/css" />
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <style>
        .add_user { border: 0px; color: White; float: right; margin-right: 150px; }
        .add_user1 { border: 0px; color: White; display: inline-block; margin-right: 30px; background-color: #297fb8; height: 45px; border-radius: 10px; line-height: 45px; padding: 0 10px 0 10px; }
        .hd1 { display: none; }
    </style>
</head>
<body style="background: #FFF;">
    <form id="form1" runat="server">
    <div class="itempage">
        <div class="search_total" style="height: 140px">
            <div class="tit_user">
                <%=ctitile%>
                回复管理</div>
            <div class="itme_input">
                <a class="add_user1" href="HdInfoList.aspx" style="cursor: pointer">返回兴趣爱好</a>
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
                                <th class="list_li_txt2" style="width: 10%">
                                    作者
                                </th>
                                <th class="list_li_txt2" style="width: 45%">
                                    回复内容
                                </th>
                                <th class="list_li_txt2" style="width: 10%">
                                    回复时间
                                </th>
                                <th class="list_li_txt2" style="width: 24%">
                                    操作
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="list_li_txt4" style="width: 6%">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td class="list_li_txt3" style="width: 10%">
                                    <%#Eval("Title") %>
                                </td>
                                <td class="list_li_txt3" style="cursor: hand; width: 45%" title="<%#Eval("Contents")%>">
                                    <%#Eval("Contents")%>
                                </td>
                                <td class="list_li_txt3" style="width: 10%">
                                    <%#string.Format("{0:yyyy-MM-dd}",Eval("AddTime"))%>
                                </td>
                                <td class="list_li_txt3" style="width: 24%">
                                    <a style="color: red;" href="HdPostList.aspx?del=<%#Eval("Id") %>&key=<%#Request["key"] %>&tid=<%=tid %>"
                                        onclick="return confirm('删除后将无法恢复，您确定要删除吗？');">删除</a>
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
                            LastPageText="尾页" NumericButtonCount="5" NextPageText="下一页" PrevPageText="上一页"
                            ShowInputBox="Always" ShowBoxThreshold="10" PageSize="8" CssClass="pagination"
                            LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0"
                            CurrentPageButtonClass="active" TextBeforePageIndexBox="跳转到第" TextAfterPageIndexBox="页"
                            ShowPageIndexBox="Always" CustomInfoHTML="共%PageCount%页,每页显示%PageSize%条数据，共%RecordCount%条数据">
                        </webdiyer:AspNetPager>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
