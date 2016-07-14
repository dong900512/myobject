<%@ Page Title="" Language="C#" MasterPageFile="~/manage/InfoMaintenance/SysNewsmaster.master" AutoEventWireup="true" CodeBehind="OrderTable .aspx.cs" Inherits="NewInfoWeb.manage.InfoMaintenance.OrderTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" cellpadding="0">
        <tr>
            <td>
                开始时间:
            </td>
            <td>
                <input class="long_input Wdate" readonly="readonly" width="85px" id="txtStart" runat="server"
                    onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',maxDate:'#F{$dp.$D(\'ctl00_ContentPlaceHolder1_txtEnd\')}'})"
                    type="text" />
            </td>
            <td>
                结束时间:
            </td>
            <td>
                <input class="long_input Wdate" readonly="readonly" width="85px" id="txtEnd" runat="server"
                    onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'ctl00_ContentPlaceHolder1_txtStart\',{d:1});}'})"
                    type="text" />
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" Width="75px" />
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
                    预约人
                </td>
                <td width="200px">
                    人数
                </td>
                <td width="200px">
                    手机号码
                </td>
                <td width="200px">
                    收入
                </td>
                  <td width="400px">
                   获知渠道
                </td>
                <td width="400px">
                   推荐人
                </td>
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
                            <%#Eval("Name")%>
                        </td>
                        <td>
                            <%#Eval("Number")%>
                        </td>
                        <td>
                            <%#Eval("Mobile")%>
                        </td>
                        <td>
                            <%#Eval("Income")%>
                        </td>
                       <td>
                            <%#Eval("Source")%>
                        </td>
                        <td>
                            <%#Eval("Extend")%>
                        </td>
                        <td align="center">
                          <%--  <a href="OrderTable.aspx?id=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>">
                                通过</a> |--%> <a href="OrderTable .aspx?del=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>&key=<%#Request["key"] %>"
                                    onclick="return confirm('删除后将无法恢复，您确定要删除吗？');">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="8" align="center">
                    <span style="float: left">共<asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>条</span>
                    <webdiyer:AspNetPager ID="AspNetPager1" Visible="true" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                        ShowInputBox="Always" ShowBoxThreshold="10" PageSize="30">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="height: 25px">
                    <img src="../img/hint.jpg" alt="" />&nbsp;<font color="#cc0000">提示：</font><font color="#666666">此模块提供预约看房信息的显示。</font>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>

