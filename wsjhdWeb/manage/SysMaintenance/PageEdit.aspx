<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SysMaintenance/maintenancemaster.master" AutoEventWireup="true" CodeBehind="PageEdit.aspx.cs" Inherits="NewInfoWeb.manage.SysMaintenance.PageEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table class="table" cellpadding="4" cellspacing="1">
        <tbody>
            <tr>
                <td>
                    所属模块：</td>
                <td>
                    <asp:DropDownList ID="drpModule" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    页面名称：</td>
                <td>
                    <asp:TextBox ID="txtPageName" runat="server" Width="418px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    URL：</td>
                <td>
                    <asp:TextBox ID="txtUrl" runat="server" Width="418px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    图片路径：</td>
                <td>
                    <asp:FileUpload ID="upPic" runat="server" /></td>
            </tr>
                        <tr>
                <td class="htd" valign="top">
                    是否显示：</td>
                <td>
                    <asp:CheckBox ID="IsDisplay" runat="server" />
                </td>
            </tr>
            <tr class="tr1">
                <td>
                </td>
                <td height="40">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Manage/img/b_ok.jpg" OnClick="btnSave_Click" />
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Manage/img/b_reset.jpg" />
                    <asp:HiddenField ID="refer" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
