<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SphereActivity/Activity.master" AutoEventWireup="true" CodeBehind="ActivityList.aspx.cs" Inherits="NewInfoWeb.manage.SphereActivity.ActivityList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table cellspacing="0" cellpadding="0">
        <tr>
            <td>
                活动类型:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="drpActityType">
                    <asp:ListItem Selected Text="--请选择--" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="活动介绍" Value="0"></asp:ListItem>
                    <asp:ListItem Text="活动预告" Value="1"></asp:ListItem>
                    <asp:ListItem Text="楼盘活动" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                活动状态:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="drpisshow">
                    <asp:ListItem Selected Text="--请选择--" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="进行中" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已经结束" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                活动标题：
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
                <td width="100px">
                    活动类型
                </td>
                <td width="500px">
                    活动标题
                </td>
                <td width="300px">
                    活动时间
                </td>
                <td width="200px">
                    发布人
                </td>
                <td width="140px" align="center">
                    管理
                </td>
            </tr>
            <asp:Repeater ID="rptnews" runat="server">
                <ItemTemplate>
                    <tr align="center">
                        <td>
                            <%#++count %>
                        </td>
                        <td>
                            <%#Eval("Type").ToString() == "0" ? "活动介绍" : ((Eval("Type").ToString() == "1") ? "活动预告" : "楼盘活动")%>
                        </td>
                        <td>
                            <%#Eval("Title")%>
                        </td>
                        <td align="center">
                            <%#Eval("StartTime", "{0:yyyy年MM月dd日}") + "—" + Eval("EndTime", "{0:yyyy年MM月dd日}")%>
                        </td>
                        <td>
                            <%#Eval("Author")%>
                        </td>
                        <td align="center">
                            <a href="ActivityEdit.aspx?id=<%#Eval("ID") %>&page=<%#AspNetPager1.CurrentPageIndex %>">
                                编辑</a> | <a href="ActivityList.aspx?del=<%#Eval("ID") %>&page=<%#AspNetPager1.CurrentPageIndex %>&key=<%#Request["key"] %>"
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
