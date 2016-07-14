<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SysMaintenance/maintenancemaster.master" AutoEventWireup="true" CodeBehind="ModuleAdd.aspx.cs" Inherits="NewInfoWeb.manage.SysMaintenance.ModuleAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table class="table" cellpadding="4" cellspacing="1">
        <tbody>
            <tr>
                <td>
                    模块名称：</td>
                <td>
                    <asp:TextBox ID="txtModuleName" runat="server" Width="418px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    文件夹名：</td>
                <td>
                    <asp:TextBox ID="txtDefaultUrl" runat="server" Width="418px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    图片路径：</td>
                <td>
                    <asp:FileUpload ID="upPicPath" runat="server" Width="415px" /></td>
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
