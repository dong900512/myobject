<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WYBXListInf.aspx.cs" Inherits="NewInfoWeb.manage.Manager_Wy.WYBXListInf" %>

<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>物业报修列表</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" type="text/css" href="../css/public.css" />
    <link href="/manage/css/page.css" rel="stylesheet" type="text/css" />
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <style>
        .add_user { border: 0px; color: White; float: right; margin-right: 150px; }
        .add_user1 { border: 0px; color: White; display: inline-block; margin-right: 30px; background-color: #297fb8; height: 45px; border-radius: 10px; line-height: 45px; padding: 0 10px 0 10px; }
        .hd { display: none; }
    </style>
</head>
<body style="background: #FFF;">
    <form id="form1" runat="server">
    <div class="itempage">
        <div class="search_total" style="height: 140px">
            <div class="tit_user">
                物业报修列表</div>
            <div class="itme_input">
                <div class="itme_num">
                    <dt>房屋信息:</dt>
                    <dd>
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="select_one"></asp:TextBox>
                    </dd>
                </div>
                <asp:ImageButton ImageUrl="../images/Subminchaxun.png" ID="btn_click" runat="server"
                    Width="94" OnClick="btnSearch_Click" />
                <a class="add_user1" href="WYNoticeAdd.aspx" style="cursor: pointer">添加公告信息</a>
                <br class="clear_both" />
            </div>
            <div class="btnall">
            </div>
        </div>
        <div class="list_item">
            <div class="list_item_txt">
                <table style="width: 100%">
                    <asp:Repeater ID="rptLoop" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th class="list_li_txt1" style="width: 5%">
                                    编号
                                </th>
                                <th class="list_li_txt2" style="width: 20%">
                                    报修房屋
                                </th>
                                <th class="list_li_txt2" style="width: 40%">
                                    报修内容
                                </th>
                                <th class="list_li_txt2" style="width: 10%">
                                    是否解决
                                </th>
                                <th class="list_li_txt2" style="width: 20%">
                                    操作
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="list_li_txt4" style="width: 5%">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td class="list_li_txt3" style="cursor: hand; width: 20%">
                                    <%#Eval("Income")%>
                                </td>
                                <td class="list_li_txt3" style="width: 40%"  title="<%#Eval("Remark") %>">
                                    <%#Eval("Remark") %>
                                </td>
                                <td class="list_li_txt3" style="width: 10%; color: Red;">
                                    <%#Eval("Status").ToString()=="1"?"已解决":"未解决" %>
                                </td>
                                <td class="list_li_txt3" style="width: 20%">
                                    <a href="WYBXListInf.aspx?del=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>&change=edit"
                                        style="color: black;">删除</a> <a class="<%#Eval("Status").ToString()=="1"?"hd":"" %>"
                                            href="WYBXListInf.aspx?jeid=<%#Eval("Id") %>" style="color: Red;">解决</a>
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
