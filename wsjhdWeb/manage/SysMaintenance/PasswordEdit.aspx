<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SysMaintenance/maintenancemaster.master" AutoEventWireup="true" CodeBehind="PasswordEdit.aspx.cs" Inherits="NewInfoWeb.manage.SysMaintenance.PasswordEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table class="table" cellpadding="4" cellspacing="1">
        <tbody>
            <tr>
                <td>
                    真实姓名：</td>
                <td>
                    <asp:TextBox ID="txtRealName" runat="server" Width="418px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    登录名：</td>
                <td>
                    <asp:TextBox ID="txtLoginName" runat="server" Width="418px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    密码：</td>
                <td style="color: red">
                    <asp:TextBox ID="txtPass" runat="server" Width="418px" TextMode="Password"></asp:TextBox>
                    *不改变请保持为空</td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    电子邮件：</td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" Width="418px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    手机：</td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" Width="417px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    电话：</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Width="417px"></asp:TextBox></td>
            </tr>
            <tr class="tr1">
                <td>
                </td>
                <td height="40">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Manage/img/b_ok.jpg" OnClick="btnSave_Click" />
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Manage/img/b_reset.jpg" /></td>
            </tr>
        </tbody>
    </table>
</asp:Content>
