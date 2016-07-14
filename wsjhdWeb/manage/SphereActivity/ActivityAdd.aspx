<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SphereActivity/Activity.master"
    AutoEventWireup="true" CodeBehind="ActivityAdd.aspx.cs" Inherits="NewInfoWeb.manage.SphereActivity.ActivityAdd"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">

        KindEditor.ready(function (K) {
            window.editor = K.create('#ctl00_ContentPlaceHolder1_txtcontent', { uploadJson: '/manage/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '/manage/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: true
            });
        });
        function checkForm() {

            if ($("#ctl00_ContentPlaceHolder1_txttitle").val() == "") {
                alert("请输入标题信息!");
                return false;
            }
            if ($("#ctl00_ContentPlaceHolder1_txtcontent").val() == "") {
                alert("请输入内容信息");
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="table" cellpadding="4" cellspacing="1">
        <tbody>
            <%-- <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 29px;">
                    活动类别
                </td>
                <td style="height: 29px">
                    <asp:DropDownList runat="server" ID="drpActityType">
                        <asp:ListItem Selected Text="--请选择--" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="活动介绍" Value="0"></asp:ListItem>
                        <asp:ListItem Text="活动预告" Value="1"></asp:ListItem>
                        <asp:ListItem Text="楼盘活动" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px">
                    活动名称：
                </td>
                <td>
                    <dry:TextBox runat="server" ID="txttitle" CanBeNull="必填" Size="80" Width="418px"
                        MaxLength="255"></dry:TextBox>
                    <span style="color: #ff3300">*</span>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" class="htd" style="width: 133px">
                    开始时间：
                </td>
                <td>
                    <asp:TextBox ID="txtStart" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" runat="server"
                        CssClass="Wdate" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStart"
                        ErrorMessage="请输入活动开始时间"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" class="htd" style="width: 133px">
                    结束时间：
                </td>
                <td>
                    <asp:TextBox ID="txtEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'ctl00_ContentPlaceHolder1_txtStart\')}'})"
                        runat="server" CssClass="Wdate" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEnd"
                        ErrorMessage="请输入活动结束时间"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" class="htd" style="width: 133px">
                    封面图片：
                </td>
                <td>
                    <asp:FileUpload ID="upPic" runat="server" Width="415px" CssClass="colorblur" onchange="return confirmsuffix(this)" /><font
                        color="red"></font>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 22px;">
                    活动摘要：
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtsummary" CssClass="colorblur" runat="server" Height="105px" TextMode="MultiLine"
                        Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 22px;">
                    活动内容：
                </td>
                <td style="height: 22px">
                    <textarea id="txtcontent" runat="server" cols="50" rows="5" style="width: 600px;
                        height: 300px;"></textarea>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 28px;">
                    次序：
                </td>
                <td style="height: 28px">
                    <dry:TextBox runat="server" ID="txtorders" CanBeNull="必填" RequiredFieldType="数据校验"
                        Size="80" Width="418px" MaxLength="255"></dry:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 28px;">
                    活动状态:
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="rdisshow" RepeatDirection="Horizontal">
                        <asp:ListItem Text="进行中" Value="0" Selected></asp:ListItem>
                        <asp:ListItem Text="已经结束" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="tr1">
                <td style="width: 133px; height: 40px;">
                </td>
                <td style="height: 40px">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Manage/img/b_ok.jpg" OnClientClick="javascript:checkForm();"
                        OnClick="btnSave_Click" />
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Manage/img/b_reset.jpg"
                        OnClientClick="javascript:window.location.href='ActivityList.aspx';return false"
                        CausesValidation="false" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
