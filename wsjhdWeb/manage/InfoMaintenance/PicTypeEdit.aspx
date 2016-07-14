<%@ Page Title="" Language="C#" MasterPageFile="~/manage/InfoMaintenance/SysNewsmaster.master" AutoEventWireup="true" CodeBehind="PicTypeEdit.aspx.cs" Inherits="NewInfoWeb.manage.InfoMaintenance.PicTypeEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function checkForm() {
            if ($("#ctl00_ContentPlaceHolder1_txttitle").val() == "") {
                alert("请输入标题信息");
                return false;
            }
        }
    </script>
    <table class="table" cellpadding="4" cellspacing="1">
        <tbody>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px">
                    类别名称:
                </td>
                <td>
                    <dry:TextBox runat="server" ID="txttitle" CanBeNull="必填" Size="80" Width="418px"
                        MaxLength="255"></dry:TextBox>
                    <span style="color: #ff3300">*</span>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 28px;">
                    类别描述：
                </td>
                <td style="height: 28px">
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="colorblur" Height="105px" TextMode="MultiLine"
                        Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 28px;">
                    次序：
                </td>
                <td style="height: 28px">
                    <dry:TextBox runat="server" ID="txtorders" CanBeNull="必填" RequiredFieldType="数据校验"
                        Size="80" Width="418px" Text="0" MaxLength="255"></dry:TextBox>
                </td>
            </tr>
            <tr class="tr1">
                <td style="width: 133px; height: 40px;">
                </td>
                <td style="height: 40px">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Manage/img/b_ok.jpg" OnClientClick="javascript:checkForm();"
                        OnClick="btnSave_Click" />
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Manage/img/b_reset.jpg"
                        OnClientClick="javascript:window.location.href='PicTypeList.aspx';return false"
                        CausesValidation="false" />
                </td>
            </tr>
        </tbody>
    </table>
    <span runat="server" id="xc"></span>
</asp:Content>