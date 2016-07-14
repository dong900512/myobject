<%@ Page Title="" Language="C#" MasterPageFile="~/manage/jjrmantenance/JJRMaster.Master" AutoEventWireup="true" CodeBehind="RegRecomdInfo.aspx.cs" Inherits="NewInfoWeb.manage.jjrmantenance.RegRecomdInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                推荐人：<asp:Literal runat="server" ID="ltlServer" />
                <br />
                <br />
                <br />
                <asp:Button runat="server" ID="btnCallInfo" Text="返回" OnClick="btnCallInfo_Click" />
                <asp:Button runat="server" ID="Button1" Text="导出数据" OnClick="Button1_Click" />
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
                    姓名
                </td>
                <td width="200px">
                    手机号码
                </td>
                <td width="200px">
                    推荐时间
                </td>
                <td width="200px">
                    状态
                </td>
                <td width="200px">
                    户型面积
                </td>
                <td width="200px">
                    备注信息
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
                            <%#String.Format("{0:yyyy年MM月dd日 HH:mm:ss}",Eval("AddTime"))%>
                        </td>
                        <td>
                            <%# WX.Utils.Utils.GetStatus(Convert.ToInt32(Eval("Status")))%>
                        </td>
                        <td>
                            <%#Eval("loupanInfo")%>
                        </td>
                        <td>
                            <%#Eval("Extent1")%>
                        </td>
                        <td>
                            <a href="upStatusRecmd.aspx?rcid=<%#Eval("Id") %>&rgid=<%=rgid %>">更改状态信息</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="8" align="center">
                    <span style="float: left">共<asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>条</span>
                    <webdiyer:AspNetPager ID="AspNetPager1" Visible="true" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                        ShowInputBox="Always" ShowBoxThreshold="10" PageSize="1">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="height: 25px">
                    <img src="../img/hint.jpg" alt="" />&nbsp;<font color="#cc0000">提示：</font><font color="#666666">此模块提供注册人推荐信息的显示。</font>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>

