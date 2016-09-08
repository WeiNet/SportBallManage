<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameCalculation.aspx.cs" Inherits="GameCalculation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注单计算</title>
    <link href="../../Styles/master.css" rel="stylesheet" />
    <script src="GameCalculation.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            border: 1px solid #96d0e5;
            background: #EEEEEE;
            font-size: 13;
            vertical-align: middle;
            height: 19px;
        }

        .auto-style2 {
            text-align: left;
            border: 1px solid #96d0e5;
            vertical-align: middle;
            height: 19px;
        }

        .auto-style3 {
            text-align: right;
            border: 1px solid #96d0e5;
            background: #EEEEEE;
            font-size: 13;
            vertical-align: middle;
            height: 22px;
        }

        .auto-style4 {
            text-align: left;
            border: 1px solid #96d0e5;
            vertical-align: middle;
            height: 22px;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table">
                <tr>
                    <td class="title" colspan="2">
                        <asp:Label ID="lblball" runat="server" Text=""></asp:Label>设置结果</td>
                </tr>
                <tr>
                    <td class="title" colspan="2">
                        <asp:Button ID="btnCount" runat="server" CssClass="button" Text="計算結果"
                            OnClientClick="return CheckNum();" OnClick="btnCount_Click" />
                        <asp:Button ID="btnBack" runat="server" CssClass="button" Text="返回" OnClientClick="return refresh(true);" OnClick="btnBack_Click" /></td>
                </tr>
                <tr>
                    <td class="trr" style="width: 20%">所属联盟
                    </td>
                    <td class="trl">
                        <asp:Label ID="lblLM" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="trr" style="width: 20%">场别
                    </td>
                    <td class="trl">
                        <asp:Label ID="lblCB" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="trr">比赛球队
                    </td>
                    <td class="trl">
                        <asp:Label ID="lblDW" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="trr" style="width: 20%">比赛结果
                    </td>
                    <td class="trl">
                        <input name="txtVisit" type="text"
                            size="8" maxlength="5" id="txtVisit" runat="server" value="0" />
                        ：<input name="txtHome" type="text" size="8" maxlength="5" id="txtHome"
                            runat="server" value="0" />
                    </td>
                </tr>
                <tr id="trUp" runat="server">
                    <td class="trr" style="width: 20%">上半场结果
                    </td>
                    <td class="trl">
                        <input name="txtVisit_Up" type="text"
                            size="8" maxlength="5" id="txtVisit_Up" runat="server" value="0" />
                        ：
                                    <input name="txtHome_Up" type="text" size="8" maxlength="5" id="txtHome_Up"
                                        runat="server" value="0" />
                    </td>
                </tr>
                <tr>
                    <td class="trr" style="width: 20%">打满<asp:Label ID="lblDM" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdoSF9J" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">备注</td>
                    <td class="auto-style4">
                        <input name="txtRemark" type="text"
                            size="20" maxlength="20" id="txtRemark" runat="server" /></td>
                </tr>
                <tr>
                    <td class="trr">比赛时间</td>
                    <td class="trl">
                        <asp:Label ID="lblBSTime" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="trCountTime">
                    <td class="auto-style1">计算时间</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblCountDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="trr">备注</td>
                    <td class="trl">
                        <input name="txtRemark" type="text"
                            size="20" maxlength="20" id="Text3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="blueText" colspan="2">说明: 如果联盟裁定比赛没有输赢, 请在结果比分输入 -1 : -1.
                                <br>
                        · 棒球比赛如果没有打满9局但是联盟裁定有输赢, 则 "大小" / "一输二赢" / "单双" 的注单不计算结果, 但是 "让分" / "独赢" 的注单仍然会计算结果.
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
