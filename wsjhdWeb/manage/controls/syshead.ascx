<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="syshead.ascx.cs" Inherits="NewInfoWeb.manage.controls.syshead" %>
<table class="table" cellspacing="1" cellpadding="4">
    <tbody>
        <tr>
            <td class="td" colspan="2" align="left">
                系统帐号管理模块</td>
        </tr>
        <tr>
            <td align="middle" colspan="2" height="30">
                <table border="0">
                    <tbody>
                        <tr>
                            <td style="height: 16px">
                                <a href="/manage/SysMaintenance/AccountList.aspx">管理员信息管理</a></td>
                            <td width="10" style="height: 16px">
                            </td>
                            <td style="height: 16px">
                                <a href="/manage/SysMaintenance/ModuleList.aspx">模块信息管理</a></td>
                            <td width="10" style="height: 16px">
                            </td>
                            <td style="height: 16px">
                                <a href="/manage/SysMaintenance/PageList.aspx">页面信息管理分类</a></td>
                            <td width="10" style="height: 16px">
                            </td>
                            <td style="height: 16px">
                                <a href="/manage/SysMaintenance/AccountAdd.aspx">添加管理员信息</a></td>
                            <td width="10" style="height: 16px">
                            </td>
                            <td style="height: 16px">
                                <a href="/manage/SysMaintenance/ModuleAdd.aspx">添加模块信息</a></td>
                            <td width="10" style="height: 16px">
                            </td>
                            <td style="height: 16px">
                                <a href="/manage/SysMaintenance/PageAdd.aspx">添加页面信息</a></td>
                            <td width="10" style="height: 16px">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr id="trProcessRecord" runat="server">
            <td align="left" valign="middle">
                <table>
                    <tr align="center">
                        <td>
                            管理员：<asp:DropDownList ID="drpParentid" runat="server" AutoPostBack="True" >
                                    </asp:DropDownList>&nbsp;&nbsp;
                        </td>
                        <td>
                            操作时间：<asp:TextBox ID="txtCreateTime" runat="server" CssClass="colorblur" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnSerachProcessRecord" runat="server" ImageUrl="~/Manage/img/beginsearch.gif"
                               CausesValidation="False" OnClick="btnSerachProcessRecord_Click" /></td>
                    </tr>
                </table>

            </td>
        </tr>  
    </tbody>
</table>
