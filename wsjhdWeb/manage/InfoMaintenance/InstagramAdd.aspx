﻿<%@ Page Title="" Language="C#" MasterPageFile="~/manage/InfoMaintenance/SysNewsmaster.master" AutoEventWireup="true" CodeBehind="InstagramAdd.aspx.cs" Inherits="NewInfoWeb.manage.InfoMaintenance.InstagramAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script src="../xheditor/xheditor-1.1.14-zh-cn.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function checkForm() {

            if ($("#ctl00_ContentPlaceHolder1_txttitle").val() == "") {
                alert("请输入分享人名称信息!");
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="table" cellpadding="4" cellspacing="1">
        <tbody>
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" style="width: 133px">
                    分享人名称：
                </td>
                <td>
                    <dry:TextBox runat="server" ID="txttitle" CanBeNull="必填" Size="80" Width="418px"
                        MaxLength="255"></dry:TextBox>
                    <span style="color: #ff3300">*</span>
                </td>
            </tr>
       
            <tr>
                <td align="right" valign="top" bgcolor="#eeeeee" class="htd" style="width: 133px">
                    图片：
                </td>
                <td>
                    <asp:FileUpload ID="upPic" runat="server" Width="415px" CssClass="colorblur" onchange="return confirmsuffix(this)" /><font
                        color="red"></font>
                </td>
            </tr>
         
           
            <tr class="tr1">
                <td style="width: 133px; height: 40px;">
                </td>
                <td style="height: 40px">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Manage/img/b_ok.jpg" OnClientClick="javascript:checkForm();"
                        OnClick="btnSave_Click" />
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Manage/img/b_reset.jpg"
                        OnClientClick="javascript:window.location.href='InstagramList.aspx';return false"
                        CausesValidation="false" />
                </td>
            </tr>
        </tbody>
    </table>
    <span runat="server" id="xc"></span>
</asp:Content>
