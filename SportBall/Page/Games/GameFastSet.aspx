<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameFastSet.aspx.cs" Inherits="GameFastSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Styles/master.css" rel="stylesheet" />
    <script src="baseball.js" type="text/javascript"></script>
    <script src="game.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table" style="width: 100%">
                <tr>
                    <td class="title" colspan="2">修改
                              
                    </td>
                </tr>
                <tr>
                    <td class="title" colspan="2">
                        <asp:Button ID="btnModify" runat="server" Text="保存修改" OnClick="btnModify_Click" CssClass="button" />
                        <input type="button" id="btnClose" name="btnClose" onclick="return refresh(true);"
                            value="關閉" class="button" />
                    </td>
                </tr>
                <tr>
                    <td class="trr">
                        <input name="btnOpen" runat="server" type="button" onclick="OpenAll(this, hidOpen)"
                            class="button" value="開放中" id="btnOpen" />
                        <input id="hidOpen" runat="server" style="width: 79px" type="hidden" value="-1" />
                    </td>
                    <td class="trl">
                        <asp:Label ID="lblDWName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="trr"><span  id="sphj" runat="server">◎兩邊賠率加總：</span>
                        <input name="txtPLTT" type="text" readonly="readonly" value="0"
                            size="8" maxlength="5" id="txtPLTT" runat="server" onblur="_onlyNum(this);CountRate(txtLPL,txtRPL,txtPLTT,3);" />
                    </td>
                    <td class="trl">
                        <asp:CheckBox ID="chkLock" Checked="true" onclick="if(this.checked) document.getElementById('txtPLTT').readOnly = true; else document.getElementById('txtPLTT').readOnly = false;"
                            runat="server" Text="鎖定賠率加總" />
                    </td>
                </tr>
                <tr runat="server" id="trLX">
                    <td class="trr" >
                        <asp:Label ID="lblLXName" runat="server" Text=""></asp:Label>：
                                <asp:TextBox ID="txtFS" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td class="trl">
                        <select name="drpFS" id="drpFS" runat="server">
                            <option selected="selected">0</option>
                            <option>0.5</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                            <option>6</option>
                            <option>7</option>
                            <option>8</option>
                            <option>9</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                            <option>25</option>
                            <option>26</option>
                            <option>27</option>
                            <option>28</option>
                            <option>29</option>
                            <option>30</option>
                        </select>
                        分
                                <select name="drpLB" id="drpLB" runat="server" onchange="ConRate(this,txtPL)">
                                    <option value="1">+</option>
                                    <option value="0" selected="selected">平</option>
                                    <option value="-1">-</option>
                                    <option value="-2">輸</option>
                                </select>
                        <input name="txtPL" type="text" value="50" size="5" maxlength="3"
                            onblur="_onlyNum(this);" id="txtPL" runat="server" />
                        ％
                    </td>
                </tr>
                <tr>
                    <td class="trr">
                        <input id="hidLOpen" runat="server" style="width: 79px" type="hidden" value="-1" />
                        <input name="btnLOpen" type="button" id="btnLOpen" runat="server" class="button"
                            style="vertical-align: bottom" onclick="OpenPL(this, hidLOpen)" value="開" />
                        <asp:Label ID="lblLDW" runat="server" Text=""></asp:Label>：
                            <input type="button" name="btnLAdd" value="+" onclick="CountPLAdd(txtLPL, txtRPL)" />
                        <input name="txtLPL" type="text" size="8" maxlength="5" id="txtLPL"
                            value="0" runat="server" onblur="_onlyNum(this);CountRate(txtLPL,txtRPL,txtPLTT,1);" />
                        <input type="button" name="btnLSub" value="-" onclick="CountPLSub(txtLPL, txtRPL)" />
                    </td>
                    <td class="trl">
                        <input name="btnROpen" type="button" id="btnROpen" runat="server" class="button"
                            style="vertical-align: bottom" onclick="OpenPL(this, hidROpen)" value="開" />
                        <asp:Label ID="lblRDW" runat="server" Text=""></asp:Label>：
                                <input type="button" name="btnRAdd" value="+" onclick="CountPLAdd(txtRPL, txtLPL)" />
                        <input name="txtRPL" type="text" size="8" maxlength="5" id="txtRPL"
                            value="0" runat="server" onblur="_onlyNum(this);CountRate(txtLPL,txtRPL,txtPLTT,2);" />
                        <input type="button" name="btnRSub" style="vertical-align: bottom" value="-" onclick="CountPLSub(txtRPL, txtLPL)" />
                        <input id="hidROpen" runat="server" style="width: 79px" type="hidden" value="-1" />
                    </td>
                </tr>
                <tr  runat="server" id="trRF">
                    <td class="trr">讓分互換
                        
                    </td>
                    <td class="trl">
                        <input id="chkLet" type="checkbox" runat="server" />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
