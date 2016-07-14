<%@ Page Title="" Language="C#" MasterPageFile="~/manage/jjrmantenance/JJRMaster.Master" AutoEventWireup="true" CodeBehind="RegistJSInfo.aspx.cs" Inherits="NewInfoWeb.manage.jjrmantenance.RegistJSInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" cellspacing="1" cellpadding="4">
        <tr>
            <td>
                姓名:
            </td>
            <td>
                <asp:Literal runat="server" ID="ltlName" />
            </td>
        </tr>
        <tr>
            <td>
                手机号码:
            </td>
            <td>
                <asp:Literal runat="server" ID="ltlPhone" />
            </td>
        </tr>
        <tr>
            <td>
                开户人:
            </td>
            <td>
                <asp:Literal runat="server" ID="ltlCName" />
            </td>
        </tr>
        <tr>
            <td>
                开户银行:
            </td>
            <td>
                <asp:Literal runat="server" ID="ltlBankName" />
            </td>
        </tr>
        <tr>
            <td>
                银行卡号:
            </td>
            <td>
                <asp:Literal runat="server" ID="ltltCarId" />
            </td>
        </tr>
        <tr>
            <td>
                应支付佣金:
            </td>
            <td>
                <asp:Literal runat="server" ID="ltlyj" />
            </td>
        </tr>
        <tr>
            <td>
                佣金是否支付成功：
            </td>
            <td>
                <asp:DropDownList runat="server" ID="drpyj">
                    <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnUpdateStatus" Text="确认" OnClick="btnUpdateStatus_Click" />
                <asp:Button runat="server" ID="Button1" Text="返回" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
