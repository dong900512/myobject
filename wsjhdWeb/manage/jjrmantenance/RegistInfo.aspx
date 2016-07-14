<%@ Page Title="" Language="C#" MasterPageFile="~/manage/jjrmantenance/JJRMaster.Master" AutoEventWireup="true" CodeBehind="RegistInfo.aspx.cs" Inherits="NewInfoWeb.manage.jjrmantenance.RegistInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hide
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                注册人：<asp:TextBox runat="server" ID="txtname" />
                <br />
                <br />
                手机号码：<asp:TextBox runat="server" ID="txtphone" />
                <br />
                <br />
                <asp:Button runat="server" ID="btnCallInfo" Text="查询" OnClick="btnCallInfo_Click" />
                <asp:Button runat="server" ID="Button1" Text="导出数据" OnClick="Button1_Click" />
                <asp:Button runat="server" ID="Button2" Text="导入数据" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    <table class="table" cellspacing="1" cellpadding="4">
        <tbody>
            <tr style="background-color: #E6E6E6; height: 24px" align="center">
                <td width="60px">
                    序号
                </td>
                <td width="200px">
                    注册人
                </td>
                <td width="200px">
                    手机号码
                </td>
                <td width="200px">
                    所得佣金
                </td>
                <td width="200px">
                    已结算佣金
                </td>
                <td width="200px">
                    身份类别
                </td>
                <td width="200px">
                    公司名称
                </td>
                <td width="200px">
                    推荐人数
                </td>
                <td width="200px">
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
                            <%#Eval("Phone")%>
                        </td>
                        <td>
                            <%#Eval("BeforeMoney")%>
                        </td>
                        <td>
                            <%#Eval("MoneyOld")%>
                        </td>
                        <td>
                            <%#GetSFInfo(Eval("ZwInfo"))%>
                        </td>
                        <td>
                            <%#Eval("CompanyName")%>
                        </td>
                        <td>
                            <%# GetCount(Eval("Id"))%>
                        </td>
                        <td>
                            <a href="RegRecomdInfo.aspx?rgid=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>">
                                查看推荐人信息</a>
                            <br />
                            <a href="RegistJSInfo.aspx?isid=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>">
                                结算佣金</a>
                            <br />
                            <span class='<%=name=="xinhy"?"hide":"" %>'><a href="RegistInfo.aspx?del=<%# Eval("Id") %>"
                                onclick="return confirm('删除后将不能恢复，确认执行该操作吗？')">删除信息</a> </span>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="9" align="center">
                    <span style="float: left">共<asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>条</span>
                    <webdiyer:AspNetPager ID="AspNetPager1" Visible="true" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                        ShowInputBox="Always" ShowBoxThreshold="10" PageSize="30">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td colspan="9" style="height: 25px">
                    <img src="../img/hint.jpg" alt="" />&nbsp;<font color="#cc0000">提示：</font><font color="#666666">此模块提供注册人的信息的显示。</font>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>

