<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SphereActivity/Activity.master"
    AutoEventWireup="true" CodeBehind="Memberinfo.aspx.cs" Inherits="NewInfoWeb.manage.SphereActivity.Memberinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" cellspacing="1" cellpadding="4">
        <tbody>
            <tr style="background-color: #E6E6E6; height: 24px" align="center">
                <td width="60px">
                    序号
                </td>
                <td width="500px">
                    姓名
                </td>
                <td width="200px">
                    手机号码
                </td>
                <td width="200px">
                    区域
                </td>
                <td width="400px">
                    备注
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
                            <%#Eval("Name")%>
                        </td>
                        <td>
                            <%#Eval("Mobile")%>
                        </td>
                        <td>
                            <%#Eval("Extend")%>
                        </td>
                        <td>
                            <%#Eval("Remark")%>
                        </td>
                        <td align="center">
                            <%--  <a href="OnlineRegistEdit.aspx?id=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>">
                                通过</a> |--%>
                            <a href="Memberinfo.aspx?del=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>&key=<%#Request["key"] %>"
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
                    <img src="../img/hint.jpg" alt="" />&nbsp;<font color="#cc0000">提示：</font><font color="#666666">此模块提供会员信息的显示。</font>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
