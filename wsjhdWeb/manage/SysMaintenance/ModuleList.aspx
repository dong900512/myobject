<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SysMaintenance/maintenancemaster.master" AutoEventWireup="true" CodeBehind="ModuleList.aspx.cs" Inherits="NewInfoWeb.manage.SysMaintenance.ModuleList" %>
<%@ Import Namespace="WX.Utils" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table class="table0" cellspacing="1" cellpadding="3">
        <tbody>
            <tr align="middle">
                <td style="background-color: #E6E6E6; height: 24px" width="70%">
                    模块名称及添加操作
                </td>
                <td style="background-color: #E6E6E6; height: 24px" width="30%">
                    相关操作
                </td>
            </tr>
            <asp:Repeater ID="rptModule" runat="server" OnItemDataBound="rptModule_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <!-- top level categories list -->
                    <tr>
                        <td>
                            &nbsp;<img alt="" src="../img/s_left.gif" align="absMiddle" border="0">&nbsp;<font
                                class="red2"><b><%# Eval("ModuleName")%></b></font>&nbsp;（<a href="PageAdd.aspx?mid=<%# Eval("ModuleID") %>&refer=<%# globalVariables.curUri %>">添加此模块页面</a>&nbsp;|&nbsp;<a
                                    href="PageAdd.aspx?type=bat&mid=<%# Eval("ModuleID") %>">批量添加此模块页面</a>）
                        </td>
                        <td>
                            &nbsp;<a href="ModuleEdit.aspx?id=<%# Eval("ModuleID") %>&refer=<%# globalVariables.curUri %>">编辑</a>
                            &nbsp; &nbsp;<a onclick="return del_nsort('<%# Eval("ModuleName") %>', 'yes')" href="ModuleList.aspx?delid=<%# Eval("ModuleID") %>">删除</a>
                        </td>
                    </tr>
                    <!-- end top level -->
                    <!-- relation child categories list -->
                    <asp:Repeater ID="rptPage" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    &nbsp; <font class="blue"><b>
                                        <%# Eval("PageName")%>
                                    </b></font>
                                </td>
                                <td>
                                    &nbsp;<a href="PageEdit.aspx?mid=<%# Eval("ModuleID") %>&id=<%# Eval("ItemID") %>&refer=<%# globalVariables.curUri %>">修改</a>
                                    &nbsp; &nbsp;<a onclick="return del_nsort('<%# Eval("PageName") %>', 'no')" href="ModuleList.aspx?delpid=<%# Eval("ItemID") %>">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- end child list -->
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
            <!-- start page list -->
            <tr class="tr1">
                <td>
                    <%-- <cc1:Pager ID="Pager1" runat="server" />--%>
                </td>
                <td align="middle">
                    <%--                    执行
                    <select size="1" name="sel_type">
                        <option value="审核" selected>审核</option>
                        <option value="删除">删除</option>
                    </select>
                    <input onclick="return sel_click(this.form);" type="submit" value="操作">--%>
                </td>
            </tr>
            <!-- end page list -->
        </tbody>
    </table>
</asp:Content>
