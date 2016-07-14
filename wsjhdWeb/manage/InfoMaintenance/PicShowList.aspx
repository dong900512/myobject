<%@ Page Title="" Language="C#" MasterPageFile="~/manage/InfoMaintenance/SysNewsmaster.master"
    AutoEventWireup="true" CodeBehind="PicShowList.aspx.cs" Inherits="NewInfoWeb.manage.InfoMaintenance.PicShowList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <a href="PicShowAdd.aspx?TypeID=<%= tmpPicTypeid %>" target="_blank" style="cursor: pointer;
                    color: #ff6600; font-weight: bolder">添加图片</a>
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
                    图片名称
                </td>
                <td width="300px">
                    图片地址
                </td>
                <td width="200px">
                    创建时间
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
                            <%#Eval("PicTitle")%>
                        </td>
                        <td>
                            <%#Eval("PicUrl")%>
                        </td>
                        <td>
                            <%#Eval("AddTime")%>
                        </td>
                        <td align="center">
                            <%--<a href="PicShowEdit.aspx?pid=<%#Eval("Id") %>&id=<%=tmpPicTypeid %>&page=<%#AspNetPager1.CurrentPageIndex %>">
                                修改图片名称</a> |--%>
                            <a href="PicShowList.aspx?delt=<%#Eval("Id") %>&page=<%#AspNetPager1.CurrentPageIndex %>&key=<%#Request["key"] %>&del=<%#Request["del"] %>"
                                onclick="return confirm('删除后将无法恢复，您确定要删除吗？');">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="5" align="center">
                    <span style="float: left">共<asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>条</span>
                    <webdiyer:AspNetPager ID="AspNetPager1" Visible="true" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                        ShowInputBox="Always" ShowBoxThreshold="10" PageSize="30">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 25px">
                    <img src="../img/hint.jpg" alt="" />&nbsp;<font color="#cc0000">提示：</font><font color="#666666">此模块提供所有图片类型信息的显示。</font>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
