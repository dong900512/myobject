<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SysMaintenance/maintenancemaster.master"
    AutoEventWireup="true" CodeBehind="AccountAdd.aspx.cs" Inherits="NewInfoWeb.manage.SysMaintenance.AccountAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" cellpadding="4" cellspacing="1">
        <tbody>
            <tr>
                <td>
                    真实姓名：
                </td>
                <td>
                    <asp:TextBox ID="txtRealName" runat="server" Width="418px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    登录名：
                </td>
                <td>
                    <asp:TextBox ID="txtLoginName" runat="server" Width="418px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginName"
                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" Width="418px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass"
                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    电子邮件：
                </td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" Width="418px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    手机：
                </td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" Width="417px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                    电话：
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Width="417px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htd" valign="top">
                </td>
                <td>
                    <asp:Literal ID="ltl_link" runat="server" Visible="false">此帐号已经为本站会员，可点击右边链接查看其基本信息，如<font color=#cc0000>确认关联此会员</font>请点继续链接&nbsp;&nbsp;<a target="_blank" href="{0}member/default.aspx?MemberId={1}">查看信息>></a></asp:Literal>
                    &nbsp;&nbsp;<asp:LinkButton ID="lbPass" runat="server" OnClick="lbPass_Click" Visible="False"></asp:LinkButton>
                    <asp:HiddenField ID="AccountName" runat="server" />
                </td>
            </tr>
            <tr class="tr1">
                <td>
                </td>
                <td height="40">
                    <asp:Panel ID="pBtn" runat="server">
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Manage/img/b_ok.jpg" OnClick="btnSave_Click" />
                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Manage/img/b_reset.jpg" /></asp:Panel>
                </td>
            </tr>
            <%--            <tr>
                <td colspan="2">
                    <font color="#cc0000">说明：在增加此帐号的过程中系统会自动将此管理员变为站点的会员。</font></td>
            </tr>--%>
        </tbody>
    </table>
</asp:Content>
