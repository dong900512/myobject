<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SphereActivity/Activity.master"
    AutoEventWireup="true" CodeBehind="keywordedit.aspx.cs" Inherits="NewInfoWeb.manage.SphereActivity.keywordedit"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" cellpadding="4" cellspacing="1">
        <tr>
            <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 22px;">
                关键词：
            </td>
            <td style="height: 22px">
                <asp:TextBox runat="server" ID="txtKeword" Width="600" />
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 22px;">
                关键词信息：
            </td>
            <td style="height: 22px">
                <textarea id="txtcontent" runat="server" cols="50" rows="5" style="width: 600px;
                    height: 300px;"></textarea>
            </td>
        </tr>
        <tr class="tr1">
            <td style="width: 133px; height: 40px;">
            </td>
            <td style="height: 40px">
                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Manage/img/b_ok.jpg" OnClientClick="javascript:checkForm();"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
