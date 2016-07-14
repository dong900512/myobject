<%@ Page Title="" Language="C#" MasterPageFile="~/manage/jjrmantenance/JJRMaster.Master" AutoEventWireup="true" CodeBehind="upStatusRecmd.aspx.cs" Inherits="NewInfoWeb.manage.jjrmantenance.upStatusRecmd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" cellspacing="1" cellpadding="4">
        <tr>
            <td>
                客户姓名:
            </td>
            <td>
                <asp:Literal runat="server" ID="ltlName" />
            </td>
        </tr>
        <tr>
            <td>
                所选户型:
            </td>
            <td>
                <asp:Literal runat="server" ID="ltlhx" />㎡
            </td>
        </tr>
        <tr>
            <td>
                客户状态:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="drpStatus">
                    <asp:ListItem Text="初始推荐" Value="0"></asp:ListItem>
                    <asp:ListItem Text="电话联系" Value="1"></asp:ListItem>
                    <asp:ListItem Text="客户到访" Value="2"></asp:ListItem>
                    <asp:ListItem Text="意向定金" Value="3"></asp:ListItem>
                    <asp:ListItem Text="签约" Value="4"></asp:ListItem>
                    <asp:ListItem Text="成功" Value="5"></asp:ListItem>
                    <asp:ListItem Text="结束" Value="6"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                是否全额付款：
            </td>
            <td>
                <asp:DropDownList runat="server" ID="drpPI">
                    <asp:ListItem Text="否" Value="0" Selected></asp:ListItem>
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnUpdateStatus" Text="更改客户状态信息" OnClick="btnUpdateStatus_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

