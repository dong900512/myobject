<%@ Page Title="" Language="C#" MasterPageFile="~/manage/InfoMaintenance/SysNewsmaster.master" AutoEventWireup="true" CodeBehind="SysNewsList.aspx.cs" Inherits="NewInfoWeb.manage.InfoMaintenance.SysNewsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" cellpadding="0">
        <tr>
            <td>
                新闻类型:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="drpType" />
            </td>
            <td>
                新闻标题：
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtSearch" Width="200px" />
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="确定" Width="75px" />
            </td>
        </tr>
    </table>
    <table class="table" cellspacing="1" cellpadding="4">
        <tbody>
            <tr style="background-color: #E6E6E6; height: 24px" align="center">
                <td width="60px">
                    序号
                </td>
                <td width="500px">
                    新闻标题
                </td>
                <td width="200px">
                    关键字信息
                </td>
                <td width="200px">
                    发布人
                </td>
                 <td width="200px">是否结束</td>
                <td width="140px" align="center">
                    管理
                </td>
            </tr>
            <asp:Repeater ID="rptnews" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#++count %>
                        </td>
                        <td>
                            <%#Eval("Title")%>
                        </td>
                        <td>
                            <%#Eval("Extend1")%>
                        </td>
                        <td>
                            <%#Eval("Extend")%>
                        </td>
                          <td>
                            <%#Eval("Status").ToString()=="1"?"已结束":"" %>
                        </td>
                        <td align="center">
                            <a href="SysNewsEdit.aspx?id=<%#Eval("AritcleID") %>&page=<%#AspNetPager1.CurrentPageIndex %>">
                                编辑</a> | <a href="SysNewsList.aspx?del=<%#Eval("AritcleID") %>&page=<%#AspNetPager1.CurrentPageIndex %>&key=<%#Request["key"] %>"
                                    onclick="return confirm('删除后将无法恢复，您确定要删除吗？');">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="6" align="center">
                    <span style="float: left">共<asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>条</span>
                    <webdiyer:AspNetPager ID="AspNetPager1" Visible="true" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                        ShowInputBox="Always" ShowBoxThreshold="10" PageSize="30">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 25px">
                    <img src="../img/hint.jpg" alt="" />&nbsp;<font color="#cc0000">提示：</font><font color="#666666">此模块提供所有新闻信息的显示。</font>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>

