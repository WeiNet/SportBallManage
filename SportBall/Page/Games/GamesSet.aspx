<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GamesSet.aspx.cs" Inherits="GamesSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="GamesSet.js" type="text/javascript"></script>
    <link href="../../Styles/master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table">
                <tr>
                    <td class="title" colspan="2">
                        <asp:Label ID="lblball" runat="server" Text=""></asp:Label>新比賽建立
                                <input id="hidMode" type="hidden" runat="server" value="Add" />
                        <input id="hidN_ID" type="hidden" runat="server" value="-1" />
                        <input id="hidTeam" type="hidden" runat="server" /></td>
                </tr>
                <tr>
                    <td class="trc" style="width: 50%">
                        <asp:Label ID="lblDW" runat="server" Text=""></asp:Label>
                        <input id="hidType" type="hidden" runat="server" />
                    </td>
                    <td class="trc">
                        <asp:Button runat="server" ID="lbtnDetail" Text="注單明細" CssClass="button" OnClick="lbtnDetail_Click" />
                        <asp:Button runat="server" ID="lbtnStat" Text="盤口統計" CssClass="button" OnClick="lbtnStat_Click" />
                        <asp:Button runat="server" ID="lbtnCount" Text="盤口試算" CssClass="button" OnClick="lbtnCount_Click" />

                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="trc">
                        <asp:Label ID="lblWF" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnUpdate" runat="server" Text="更新" CssClass="button" OnClick="btnUpdate_Click" />
                        <asp:DropDownList ID="drpBill" runat="server"
                            TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="drpBill_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="顯示全部"></asp:ListItem>
                            <asp:ListItem Value="1" Text="只顯示有效注單"></asp:ListItem>
                            <asp:ListItem Value="2" Text="只顯示危險注單"></asp:ListItem>
                            <asp:ListItem Value="3" Text="只顯示已刪除注單"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpPage" runat="server" AutoPostBack="true"
                            TabIndex="2" OnSelectedIndexChanged="drpPage_SelectedIndexChanged">
                            <asp:ListItem Value="15" Text="每頁顯示15筆"></asp:ListItem>
                            <asp:ListItem Value="30" Text="每頁顯示30筆"></asp:ListItem>
                            <asp:ListItem Value="45" Text="每頁顯示45筆"></asp:ListItem>
                            <asp:ListItem Value="50" Text="每頁顯示50筆"></asp:ListItem>
                            <asp:ListItem Selected="True" Value="100" Text="每頁顯示100筆"></asp:ListItem>
                        </asp:DropDownList>
                        <input type="button" id="btnClose" name="btnClose" onclick="window.close();" class="button"
                            value="關閉" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
