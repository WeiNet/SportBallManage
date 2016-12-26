<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录</title>
    <link href="/Styles/style.css" rel="stylesheet" />
    <script src="Login.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <script src="Login.js" type="text/javascript"></script>
        <div class="main">
            <div class="login">
                <h1>管理系统</h1>
                <div class="inset">
                    <!--start-main-->
                    <div>
                        <h2>管理登录</h2>
                        <span>
                            <label>用户名</label></span>
                        <span>
                            <asp:TextBox ID="textUserName" runat="server" class="textbox"></asp:TextBox></span>
                    </div>
                    <div>
                        <span>
                            <label>密码</label></span>
                        <span>
                            <asp:TextBox ID="textPassWord" runat="server" class="password" TextMode="Password"></asp:TextBox></span>
                    </div>
                    <div class="sign">
                        <asp:Button runat="server" class="submit" Text="登录" ID="btnLogin" OnClick="btnLogin_Click" />

                    </div>

                </div>
            </div>
            <!--//end-main-->
        </div>

        <div class="copy-right">
            <p>&copy; 2016 Ethos Login Form. All Rights Reserved</p>

        </div>

    </form>
</body>
</html>
