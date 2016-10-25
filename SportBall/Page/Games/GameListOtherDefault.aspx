<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="GameListOtherDefault.aspx.cs" Inherits="GameListOtherDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 58px;
        }
    </style>
    <script src="game.js" type="text/javascript"></script>
    <script src="jquery-1.8.3.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">足球操盘</a> /<asp:Label ID="lblball" runat="server" Text=""></asp:Label>新比賽預設值
    </ul>
    <div class="title_right">
        <strong>新比賽預設值</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">

            <tr>
                <td class="title" colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="儲存比賽修改" OnClick="btnSave_Click" CssClass="button" />
                </td>
            </tr>
        </table>
        <table style="width: 100%" border="0" class="table">
            <tr>
                <td style="width: 18%" class="trr">修改時間
                </td>
                <td colspan="5" class="trl">
                    <span>
                        <asp:CheckBoxList ID="chkCB" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">全場</asp:ListItem>
                            <asp:ListItem Value="2">上半場</asp:ListItem>
                            <asp:ListItem Value="4">下半場</asp:ListItem>
                        </asp:CheckBoxList></span></td>
            </tr>
            <tr class="trl" style="display: none">
                <td class="trr">
                    <span>會員單注上限 ：</span></td>
                <td colspan="5" class="trl">
                    <input name="txtDZSX" type="text" onblur="_onlyNum(this)" value="0"
                        size="10" maxlength="10" id="txtDZSX" runat="server" />
                    (萬)</td>
            </tr>
            <tr class="trl">
                <td class="trr">
                    <span>會員單場上限 ：</span></td>
                <td colspan="5" class="trl">
                    <input name="txtDCSX" type="text" onblur="_onlyNum(this)" value="0"
                        size="10" maxlength="10" id="txtDCSX" runat="server" />
                    (萬)</td>
            </tr>
            <tbody id="handicap">
                <tr class="trl">
                    <td colspan="6" class="trc">
                        <span>讓分預設值 </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>讓分：</span></td>
                    <td colspan="5" class="trl">
                        <select name="drpRFFS" id="drpRFFS" runat="server">
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
                        </select>
                        分
                                    <select name="drpRFLX" id="drpRFLX" runat="server" onchange="ConRate(this,ContentPlaceHolder11_txtRFBL)">
                                        <option value="1">+</option>
                                        <option value="0" selected="selected">平</option>
                                        <option value="-1">-</option>
                                        <option value="-2">輸</option>
                                    </select>
                        <input name="txtRFBL" type="text" value="50" size="5" maxlength="3"
                            onblur="_onlyNum(this)" id="txtRFBL" runat="server" />
                        ％</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊賠率：</span></td>
                    <td width="15%" class="trl">
                        <span class="eng_bk_r"><span>
                            <input name="txtLRFPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLRFPL,ContentPlaceHolder11_txtRRFPL,ContentPlaceHolder11_txtRFPLJZ,1,10);"
                                size="10" maxlength="10" id="txtLRFPL" runat="server" />
                        </span></span>
                    </td>
                    <td width="16%" class="trr">
                        <span>右隊賠率：</span></td>
                    <td width="19%" class="trl">
                        <span>
                            <input name="txtRRFPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLRFPL,ContentPlaceHolder11_txtRRFPL,ContentPlaceHolder11_txtRFPLJZ,2,10);"
                                size="10" maxlength="10" id="txtRRFPL" runat="server" />
                        </span>
                    </td>
                    <td width="17%" class="trr">
                        <span>讓分賠率加總：</span></td>
                    <td width="15%" class="trl">
                        <span>
                            <input name="txtRFPLJZ" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLRFPL,ContentPlaceHolder11_txtRRFPL,ContentPlaceHolder11_txtRFPLJZ,3,10);"
                                size="10" maxlength="10" id="txtRFPLJZ" runat="server" />
                        </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpLRFCJ" id="drpLRFCJ" runat="server">
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">
                        <span>右隊過關差距</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpRRFCJ" id="drpRRFCJ" runat="server">
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊上限：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtLRFSX" type="text" value="0" onblur="_onlyNum(this)"
                                size="10" maxlength="10" id="txtLRFSX" runat="server" />
                            (萬)</span></td>
                    <td class="trr">
                        <span>右隊上限：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtRRFSX" type="text" value="0" onblur="_onlyNum(this)"
                                size="10" maxlength="10" id="txtRRFSX" runat="server" />
                            (萬)</span></td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span><span>自動設置：</span></span></td>
                    <td colspan="5" class="trl">兩隊金額差距：<span>
                        <input name="txtRFCJJE" type="text" value="0" onblur="_onlyNum(this)"
                            size="10" maxlength="10" id="txtRFCJJE" runat="server" />
                        (萬)<select name="drpRFCJFS" id="drpRFCJFS" runat="server" onchange="changefenshu(this)">
                            <option selected="selected" value="0">調賠率</option>
                            <option value="1">調讓分</option>
                        </select>
                        <select name="drpRFCJPL" id="drpRFCJPL" runat="server">
                            <option selected="selected">0</option>
                            <option>0.005</option>
                            <option>0.01</option>
                            <option>0.015</option>
                            <option>0.02</option>
                            <option>0.025</option>
                            <option>0.03</option>
                            <option>0.035</option>
                            <option>0.04</option>
                            <option>0.045</option>
                            <option>0.05</option>
                        </select>
                        <select name="drpRFCJPL1" id="drpRFCJPL1" runat="server">
                            <option selected="selected">0</option>
                            <option value="0.05">5%</option>
                            <option value="0.1">10%</option>
                            <option value="0.15">15%</option>
                            <option value="0.2">20%</option>
                            <option value="0.25">25%</option>
                            <option value="0.3">30%</option>
                            <option value="0.35">35%</option>
                            <option value="0.4">40%</option>
                            <option value="0.45">45%</option>
                            <option value="0.5">50%</option>
                            <option value="0.55">55%</option>
                            <option value="0.6">60%</option>
                            <option value="0.65">65%</option>
                            <option value="0.7">70%</option>
                            <option value="0.75">75%</option>
                            <option value="0.8">80%</option>
                            <option value="0.85">85%</option>
                            <option value="0.9">90%</option>
                            <option value="0.95">95%</option>
                            <option value="1">100%</option>
                        </select>
                    </span>
                    </td>
                </tr>
            </tbody>
            <tbody id="ou">
                <tr class="trc">
                    <td colspan="6">
                        <span>大小預設值 </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>大小：</span></td>
                    <td colspan="5" class="trl">
                        <input name="txtDXFS" type="text" value="0" onblur="_onlyNum(this)"
                            size="10" maxlength="10" id="txtDXFS" runat="server" />
                        分
                                    <select name="drpDXLX" id="drpDXLX" runat="server" onchange="ConRate(this,ContentPlaceHolder11_txtDXBL)">
                                        <option value="1">+</option>
                                        <option value="0" selected="selected">平</option>
                                        <option value="-1">-</option>
                                        <option value="-2">輸</option>
                                    </select>
                        <input name="txtDXBL" type="text" value="50" size="5" maxlength="3"
                            onblur="_onlyNum(this)" id="txtDXBL" runat="server" />
                        ％</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>大賠率：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtDXDPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtDXDPL,ContentPlaceHolder11_txtDXXPL,ContentPlaceHolder11_txtDXPLJZ,1,10);"
                                size="10" maxlength="10" id="txtDXDPL" runat="server" xml:lang="0" />
                        </span>
                    </td>
                    <td class="trr">
                        <span>小賠率：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtDXXPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtDXDPL,ContentPlaceHolder11_txtDXXPL,ContentPlaceHolder11_txtDXPLJZ,2,10);"
                                size="10" maxlength="10" id="txtDXXPL" runat="server" xml:lang="0" />
                        </span>
                    </td>
                    <td class="trr">
                        <span>大小賠率加總：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtDXPLJZ" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtDXDPL,ContentPlaceHolder11_txtDXXPL,ContentPlaceHolder11_txtDXPLJZ,3,10);"
                                size="10" maxlength="10" id="txtDXPLJZ" runat="server" />
                        </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>大過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpDXDCJ" id="drpDXDCJ" runat="server">
                                <%--<option value="-1">不開過關</option>--%>
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">
                        <span>小過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpDXXCJ" id="drpDXXCJ" runat="server">
                                <%--<option value="-1">不開過關</option>--%>
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊上限：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtLDXSX" type="text" value="0" onblur="_onlyNum(this)"
                                size="10" maxlength="10" id="txtLDXSX" runat="server" />
                            (萬)</span></td>
                    <td class="trr">
                        <span>右隊上限：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtRDXSX" type="text" value="0" onblur="_onlyNum(this)"
                                size="10" maxlength="10" id="txtRDXSX" runat="server" />
                            (萬)</span></td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span><span>自動設置：</span></span></td>
                    <td colspan="5" class="trl">兩隊金額差距：<span>
                        <input name="txtDXCJ" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10" id="txtDXCJ" runat="server" />
                        (萬)調賠率：
                                        <select name="drpDXCJPL" id="drpDXCJPL" runat="server">
                                            <option selected="selected">0</option>
                                            <option>0.005</option>
                                            <option>0.01</option>
                                            <option>0.015</option>
                                            <option>0.02</option>
                                            <option>0.025</option>
                                            <option>0.03</option>
                                            <option>0.035</option>
                                            <option>0.04</option>
                                            <option>0.045</option>
                                            <option>0.05</option>
                                        </select>
                    </span>
                    </td>
                </tr>
            </tbody>
            <tbody id="Single">
                <tr class="trc">
                    <td colspan="6">
                        <span>獨贏預設值 </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊賠率：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtLDYPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLDYPL,ContentPlaceHolder11_txtRDYPL,ContentPlaceHolder11_txtDYPLJZ,1,10);"
                                size="10" maxlength="10" id="txtLDYPL" runat="server" />
                        </span>
                    </td>
                    <td class="trr">
                        <span>右隊賠率：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtRDYPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLDYPL,ContentPlaceHolder11_txtRDYPL,ContentPlaceHolder11_txtDYPLJZ,2,10);"
                                size="10" maxlength="10" id="txtRDYPL" runat="server" />
                        </span>
                    </td>
                    <td class="trr">
                        <span>獨贏賠率加總：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtDYPLJZ" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLDYPL,ContentPlaceHolder11_txtRDYPL,ContentPlaceHolder11_txtDYPLJZ,3,10);"
                                size="10" maxlength="10" id="txtDYPLJZ" runat="server" />
                        </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpLDYCJ" id="drpLDYCJ" runat="server">
                                <%--<option value="-1">不開過關</option>--%>
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">
                        <span>右隊過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpRDYCJ" id="drpRDYCJ" runat="server">
                                <%--<option value="-1">不開過關</option>--%>
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊上限</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtLDYSX" type="text" size="10" maxlength="10" id="txtLDYSX"
                                runat="server" value="0" onblur="_onlyNum(this)" />
                            (萬)</span></td>
                    <td class="trr">
                        <span>右隊上限：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtRDYSX" type="text" size="10" maxlength="10" id="txtRDYSX"
                                runat="server" value="0" onblur="_onlyNum(this)" />
                            (萬)</span></td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>自動設置：</span></td>
                    <td colspan="5" class="trl">
                        <span>兩隊金額差距：
                                        <input name="txtDYCJ" type="text" value="0" onblur="_onlyNum(this)"
                                            size="10" maxlength="10" id="txtDYCJ" runat="server" />
                            (萬)調賠率：
                                        <select name="drpDYCJPL" id="drpDYCJPL" runat="server">
                                            <option selected="selected">0</option>
                                            <option>0.005</option>
                                            <option>0.01</option>
                                            <option>0.015</option>
                                            <option>0.02</option>
                                            <option>0.025</option>
                                            <option>0.03</option>
                                            <option>0.035</option>
                                            <option>0.04</option>
                                            <option>0.045</option>
                                            <option>0.05</option>
                                        </select>
                        </span>
                    </td>
                </tr>
            </tbody>
            <tbody id="onePonit">
                <tr>
                    <td colspan="6" class="trc">
                        <span>一輸二贏預設值 </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊賠率：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtLSYPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLSYPL,ContentPlaceHolder11_txtRSYPL,ContentPlaceHolder11_txtSYPLJZ,1);"
                                size="10" maxlength="10" id="txtLSYPL" runat="server" />
                        </span>
                    </td>
                    <td class="trr">
                        <span>右隊賠率：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtRSYPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLSYPL,ContentPlaceHolder11_txtRSYPL,ContentPlaceHolder11_txtSYPLJZ,2);"
                                size="10" maxlength="10" id="txtRSYPL" runat="server" />
                        </span>
                    </td>
                    <td class="trr">
                        <span>獨贏賠率加總：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtSYPLJZ" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtLSYPL,ContentPlaceHolder11_txtRSYPL,ContentPlaceHolder11_txtSYPLJZ,3);"
                                size="10" maxlength="10" id="txtSYPLJZ" runat="server" />
                        </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpLSYCJ" id="drpLSYCJ" runat="server">
                                <%--<option value="-1">不開過關</option>--%>
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">
                        <span>右隊過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpRSYCJ" id="drpRSYCJ" runat="server">
                                <%--<option value="-1">不開過關</option>--%>
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊上限</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtLSYSX" type="text" size="10" maxlength="10" id="txtLSYSX"
                                runat="server" value="0" onblur="_onlyNum(this)" />
                            (萬)</span></td>
                    <td class="trr">
                        <span>右隊上限：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtRSYSX" type="text" size="10" maxlength="10" id="txtRSYSX"
                                runat="server" value="0" onblur="_onlyNum(this)" />
                            (萬)</span></td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>自動設置：</span></td>
                    <td colspan="5" class="trl">
                        <span>兩隊金額差距：
                                        <input name="txtSYCJ" type="text" value="0" onblur="_onlyNum(this)"
                                            size="10" maxlength="10" id="txtSYCJ" runat="server" />
                            (萬)調賠率：
                                        <select name="drpSYCJPL" id="drpSYCJPL" runat="server">
                                            <option selected="selected">0</option>
                                            <option>0.005</option>
                                            <option>0.01</option>
                                            <option>0.015</option>
                                            <option>0.02</option>
                                            <option>0.025</option>
                                            <option>0.03</option>
                                            <option>0.035</option>
                                            <option>0.04</option>
                                            <option>0.045</option>
                                            <option>0.05</option>
                                        </select>
                        </span>
                    </td>
                </tr>
            </tbody>
            <tbody id="oe">
                <tr class="trc">
                    <td colspan="6">
                        <span>單雙預設值 </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>單賠率：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtDSDPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtDSDPL,ContentPlaceHolder11_txtDSSPL,ContentPlaceHolder11_txtDSPLJZ,1,10);"
                                size="10" maxlength="10" id="txtDSDPL" runat="server" />
                        </span>
                    </td>
                    <td class="trr">
                        <span>雙賠率：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtDSSPL" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtDSDPL,ContentPlaceHolder11_txtDSSPL,ContentPlaceHolder11_txtDSPLJZ,2,10);"
                                size="10" maxlength="10" id="txtDSSPL" runat="server" />
                        </span>
                    </td>
                    <td class="trr">
                        <span>單雙賠率加總：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtDSPLJZ" type="text" value="0" onblur="_onlyNum(this);CountRate(ContentPlaceHolder11_txtDSDPL,ContentPlaceHolder11_txtDSSPL,ContentPlaceHolder11_txtDSPLJZ,3,10);"
                                size="10" maxlength="10" id="txtDSPLJZ" runat="server" />
                        </span>
                    </td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>單過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpDSDCJ" id="drpDSDCJ" runat="server">
                                <%--<option value="-1">不開過關</option>--%>
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trr">
                        <span>雙過關差距：</span></td>
                    <td class="trl">
                        <span>
                            <select name="drpDSSCJ" id="drpDSSCJ" runat="server">
                                <%--<option value="-1">不開過關</option>--%>
                                <option value="0">0</option>
                                <option value="-0.01">-0.01</option>
                                <option value="-0.02">-0.02</option>
                                <option value="-0.03">-0.03</option>
                                <option value="-0.04">-0.04</option>
                                <option value="-0.05">-0.05</option>
                                <option value="-0.06">-0.06</option>
                                <option value="-0.07">-0.07</option>
                                <option value="-0.08">-0.08</option>
                                <option value="-0.09">-0.09</option>
                                <option value="-0.10">-0.10</option>
                            </select>
                        </span>
                    </td>
                    <td class="trl">&nbsp;</td>
                    <td class="trl">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>左隊上限：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtLDSSX" type="text" value="0" onblur="_onlyNum(this)"
                                size="10" maxlength="10" id="txtLDSSX" runat="server" />
                            (萬)</span></td>
                    <td class="trr">
                        <span>右隊上限：</span></td>
                    <td class="trl">
                        <span>
                            <input name="txtRDSSX" type="text" value="0" onblur="_onlyNum(this)"
                                size="10" maxlength="10" id="txtRDSSX" runat="server" />
                            (萬)</span></td>
                    <td class="trr">&nbsp;</td>
                    <td class="trc">&nbsp;</td>
                </tr>
                <tr class="trl">
                    <td class="trr">
                        <span>自動設置：</span></td>
                    <td colspan="5" class="trl">
                        <span>兩隊金額差距：
                                    <input name="txtDSCJ" type="text" value="0" onblur="_onlyNum(this)"
                                        size="10" maxlength="10" id="txtDSCJ" runat="server" />
                            (萬)調賠率：
                                    <select name="drpDSCJPL" id="drpDSCJPL" runat="server">
                                        <option selected="selected">0</option>
                                        <option>0.005</option>
                                        <option>0.01</option>
                                        <option>0.015</option>
                                        <option>0.02</option>
                                        <option>0.025</option>
                                        <option>0.03</option>
                                        <option>0.035</option>
                                        <option>0.04</option>
                                        <option>0.045</option>
                                        <option>0.05</option>
                                    </select>
                        </span>
                    </td>
                </tr>
            </tbody>

        </table>
    </div>
</asp:Content>
