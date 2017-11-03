<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SengokuCG.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SengokuGCLogin</title>
    <style type="text/css">
        body,ul,li,h4,a{margin:0px;padding:0px;}
        ul,li,ol{list-style:none;}
        a:link,a:visited{color:black;}
        img{border:0;}

        form{
            margin:auto;
            width:800px;
            text-align:center;
        }
    </style>
</head>
<body>
    <form method="post" action="./index.aspx">
        <input type="hidden" name="hidden" value="1" />
        <div style="height:200px;"></div>
        <div style="height:100px;text-align:center;font-size:50px;">请输入用户名：</div>
        <input name="userName" type="text" />
        <input type="submit" value="登录" />
    </form>
</body>
</html>
