<%@ Page Title="" Language="C#" MasterPageFile="~/manage/SphereActivity/Activity.master"
    AutoEventWireup="true" CodeBehind="znkf.aspx.cs" Inherits="NewInfoWeb.manage.SphereActivity.znkf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/lib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/manage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script charset="utf-8" src="/manage/kindeditor-4.1.10/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="/manage/kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="/manage/kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            window.editor = K.create('#txtcontent', { resizeType: 0, uploadJson: '/manage/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '/manage/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: true, afterBlur: function () { this.sync(); }
            });
            window.editor = K.create('#txtsummary', { items: ["source"], resizeType: 0, uploadJson: '/manage/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '/manage/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: true, afterBlur: function () { this.sync(); }
            })
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="table" cellpadding="4" cellspacing="1">
        <tr>
            <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px; height: 22px;">
                智能客服信息：
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
