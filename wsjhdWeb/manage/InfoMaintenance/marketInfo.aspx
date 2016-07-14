<%@ Page Title="" Language="C#" MasterPageFile="~/manage/InfoMaintenance/SysNewsmaster.master"
    AutoEventWireup="true" CodeBehind="marketInfo.aspx.cs" Inherits="NewInfoWeb.manage.InfoMaintenance.marketInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkform() {

            if ($("#ctl00_ContentPlaceHolder1_txtMarkInfo").val() == "") {
                alert("请输入咨询信息!");
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" cellpadding="4" cellspacing="1">
        <tbody>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 29px;">
                    当前销售资讯：
                </td>
                <td style="height: 29px">
                    <asp:TextBox ID="txtMarkInfo" TextMode="MultiLine" runat="server" Height="333px"
                        Width="639px"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr1">
                <td style="width: 133px; height: 40px;">
                </td>
                <td style="height: 40px">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Manage/img/b_ok.jpg" OnClientClick="return checkform();"
                        OnClick="btnSave_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
