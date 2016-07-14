<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Module_Menu.aspx.cs"
    Inherits="NewInfoWeb.manage.Manager_Role.sys_Module_Menu" %>

<!DOCTYPE html >
<html>
<head id="Head1" runat="server">
    <title></title>
    <script src="/js/lib/jquery-1.10.2.min.js"></script>
    <script src="/manage/lib/Module.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top: 5px; padding-left: 20px;">
        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Faq">
            <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
            <NodeStyle Font-Names="Tahoma" Font-Size="12pt" ForeColor="#757575" HorizontalPadding="5px"
                NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
