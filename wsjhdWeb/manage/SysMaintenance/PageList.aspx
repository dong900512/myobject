<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SysMaintenance/maintenancemaster.master" AutoEventWireup="true" CodeBehind="PageList.aspx.cs" Inherits="NewInfoWeb.manage.SysMaintenance.PageList" %>
<%@ Import Namespace="WX.Utils" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table class="table" cellspacing="1" cellpadding="4">
        <tr style="background-color: #E6E6E6; height: 24px" align="middle">
            <td width="100px">
                序号
            </td>
            <td width="30%">
                页面名称
            </td>
            <td width="20%">
                页面地址
            </td>
            <td width="20%">
                模块名称
            </td>
            <td width="210px">
                管理
                <input onclick="javascript:select_all(this.form);" type="checkbox" value="yes" name="sel_all" />
            </td>
        </tr>
        <!-- news list  class="tims"-->
        <asp:Repeater ID="rptPage" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr align="middle">
                    <td>
                        <%# ++count %>
                    </td>
                    <td align="left">
                        <%--<a href="PageEdit.aspx?id=<%# Eval("ID") %>&refer=<%# globalVariables.curUri %>" alt="修改页面信息">--%>
                        <%# WebUtil.Substring(Eval("PageName").ToString(), 20)%>
                        <%-- </a>--%>
                    </td>
                    <td align="left">
                        <%# Eval("Url") %>
                    </td>
                    <td align="left">
                        <%# Eval("ModuleItem.ModuleName")%>
                    </td>
                    <td>
                        <a href="PageEdit.aspx?id=<%# Eval("ItemID") %>&refer=<%# globalVariables.curUri %>">
                            修改</a>&nbsp;<a href="PageList.aspx?del=<%# Eval("ItemID") %>" onclick="return confirm('删除后将不能恢复，确认执行该操作吗？')">
                                删除</a>
                        <input type="checkbox" value="<%# Eval("ItemID") %>" name="sel_no">
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
        <!-- end list -->
        <tr class="tr1">
            <td colspan="4">
                <span style="float: left">共<asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>条</span>
                <webdiyer:AspNetPager ID="AspNetPager1" Visible="true" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                    AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                    ShowInputBox="Always" ShowBoxThreshold="10" PageSize="20">
                </webdiyer:AspNetPager>
            </td>
            <td align="middle" colspan="1">
                <%--                执行
                <select size="1" name="sel_type">
                    <option value="审核" selected>审核</option>
                    <option value="删除">删除</option>
                </select>
                <input onclick="return sel_click(this.form);" type="submit" value="操作">--%>
            </td>
        </tr>
    </table>
</asp:Content>
