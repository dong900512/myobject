<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SysMaintenance/maintenancemaster.master" AutoEventWireup="true" CodeBehind="AccountList.aspx.cs" Inherits="NewInfoWeb.manage.SysMaintenance.AccountList" %>
<%@ Import Namespace="WX.Utils" %>
<%@ Register Assembly="PageCtrl" Namespace="PageCtrl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="table" cellspacing="1" cellpadding="4">
        <tr style="background-color: #E6E6E6; height: 24px" align="middle">
            <td width="80px">
                序号
            </td>
            <td width="15%">
                用户名
            </td>
            <td width="15%">
                E-mail
            </td>
            <%--       <td width="10%">
                登录次数</td>--%>
            <td width="10%">
                状态
            </td>
            <td width="20%">
                最后登录时间
            </td>
            <td width="180px">
                管理
                <input onclick="javascript:select_all(this.form);" type="checkbox" value="yes" name="sel_all">
            </td>
        </tr>
        <!-- news list  class="tims"-->
        <asp:Repeater ID="rptAccount" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr align="middle">
                    <td>
                        <%# ++count %>
                    </td>
                    <td align="left">
                        <a href="AccountEdit.aspx?id=<%# Eval("AccountID") %>" alt="修改帐号信息">
                            <%# WebUtil.Substring(Eval("LoginName"), 20)%>
                        </a>
                    </td>
                    <td align="left">
                        <%# Eval("Email") %>
                    </td>
                    <%-- <td align="left">
                        <%# Eval("LoginNums") %>
                    </td>--%>
                    <td align="left">
                        <%# (Eval("Status").ToString() == "1")?"<font color='#cc0000'>已更改</font>":"未更改" %>
                    </td>
                    <td class="tims" align="left">
                        <%# Eval("LastLoginTime", "{0:yyyy-MM-dd}")%>
                    </td>
                    <td>
                        <a href="AccountPopAllot.aspx?accountid=<%# Eval("AccountID") %>">权限分配</a> &nbsp;<a
                            href="AccountList.aspx?del=<%# Eval("AccountID") %>" onclick="return confirm('删除后将不能恢复，确认执行该操作吗？')">
                            删除</a>
                        <input type="checkbox" <%# (Eval("Status").ToString() == "1")?"disabled":"" %> name="sel_no">
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
        <!-- end list -->
    </table>
</asp:Content>
