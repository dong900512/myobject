<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frame.aspx.cs" Inherits="NewInfoWeb.manage.frame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<frameset rows="120,*" frameborder="no" border="0" framespacing="0" name="selfIn">
    <frame src="Top.aspx" noresize="noresize" frameborder="no" name="topFrame" scrolling="no" marginwidth="0" marginheight="0" target="main" />
    <frameset cols="220,*"  rows="1000,*" id="frame">
      <frame src="Left.aspx" cols="220,*" style="overflow:auto" id="leftFrame"   name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="0"  target="main" />
      <frame src="Default.aspx" width="1131px" name="main" marginwidth="0" marginheight="0" frameborder="0" scrolling="auto" target="_self" />
     
    </frameset>
</frameset>
<noframes></noframes>
</html>
