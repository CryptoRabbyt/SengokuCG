<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SengokuCG.pages.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%-- --------------WebSocket相关------------- --%>
    <script type="text/javascript">
        var webSocket;
        webSocket = new WebSocket("ws://localhost:53185/pages/UserHandler.ashx?userName=<% =Request.QueryString["userName"] %>");
        webSocket.onmessage = function (e) {
            document.getElementById("showArea").innerHTML += e.data+"<br/>";
        }
        webSocket.onclose = function (e) {
            document.body.innerHTML="已断开连接"
        }
        function Send() {
            webSocket.send(document.getElementById("sendText").value)
        }
        

    </script>
</head>
<body>
    <div id="showArea" style="height:200px"></div>
    <input id="sendText" type="text" style="width:80px" />
    <a href="javascript: Send()">发送</a>
</body>
</html>
