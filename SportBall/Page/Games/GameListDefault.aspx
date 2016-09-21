<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="GameListDefault.aspx.cs" Inherits="GameListDefault" %>

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
        <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table">
            <tr  >
                <td  style="width:30%" class="trr">修改時間 ：
                </td>
                <td  colspan="7" class="trl">
                    <span>
                        <asp:CheckBoxList ID="chkCB" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">全場</asp:ListItem>
                            <asp:ListItem Value="2">上半場</asp:ListItem>
                            <asp:ListItem Value="4">下半場</asp:ListItem>
                        </asp:CheckBoxList></span></td>
            </tr>
            <tr   style="display: none">
                <td class="trr">
                    <span>會員單注上限 ：</span></td>
                <td  colspan="7" class="trl">
                    <input name="txtDZSX" type="text" onblur="_onlyNum(this)" value="0"
                        size="10" maxlength="10" id="txtDZSX" runat="server" />
                    (萬)</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>會員單場上限 ：</span></td>
                <td colspan="7" class="trl">
                    <input name="txtDCSX" type="text" onblur="_onlyNum(this)" value="0"
                        size="10" maxlength="10" id="txtDCSX" runat="server" />
                    (萬)</td>
            </tr>
            <tr  >
                <td align="center" colspan="8">
                    <span>讓分預設值</span></td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>讓分：</span></td>
                <td colspan="7" class="trl">
                    <select name="drpRFFS" id="drpRFFS" runat="server">
                        <option selected="selected">0</option>
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
                    </select>
                    分
                                <select name="drpRFLX" id="drpRFLX" runat="server" onchange="ConRate(this,txtRFBL)">
                                    <option value="1">+</option>
                                    <option value="0" selected="selected">平</option>
                                    <option value="-1">-</option>
                                    <option value="-2">輸</option>
                                </select>
                    <input name="txtRFBL" type="text" value="50" size="5" maxlength="3"
                        onblur="_onlyNum(this)" id="txtRFBL" runat="server" />
                    ％</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>左隊賠率：</span></td>
                <td  class="trl">
                    <span class="eng_bk_r"><span>
                        <input name="txtLRFPL" type="text" value="0" onblur="_onlyNum(this);CountRate(txtLRFPL,txtRRFPL,txtRFPLJZ,1);"
                            size="10" maxlength="10" id="txtLRFPL" runat="server" />
                    </span></span>
                </td>
                <td class="trr">
                    <span>右隊賠率：</span></td>
                <td  class="trl">
                    <span>
                        <input name="txtRRFPL" type="text" value="0" onblur="_onlyNum(this);CountRate(txtLRFPL,txtRRFPL,txtRFPLJZ,2);"
                            size="10" maxlength="10" id="txtRRFPL" runat="server" />
                    </span>
                </td>
                <td class="trr">
                    <span>讓分賠率加總：</span></td>
                <td  colspan="3" class="trl">
                    <span>
                        <input name="txtRFPLJZ" type="text" value="0" onblur="_onlyNum(this);CountRate(txtLRFPL,txtRRFPL,txtRFPLJZ,3);"
                            size="10" maxlength="10" id="txtRFPLJZ" runat="server" />
                    </span>
                </td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>左隊過關差距：</span></td>
                <td class="trl" >
                    <span>
                        <select name="drpLRFCJ" id="drpLRFCJ" runat="server">
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
                    <span>右隊過關差距</span></td>
                <td  class="trl">
                    <span>
                        <select name="drpRRFCJ" id="drpRRFCJ" runat="server">
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
                <td align="center" colspan="3">&nbsp;</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span><span>左隊上限：</span></span></td>
                <td  class="trl">
                    <span>
                        <input name="txtLRFSX" type="text" value="0" onblur="_onlyNum(this)"
                            size="10" maxlength="10" id="txtLRFSX" runat="server" />
                        (萬)</span></td>
                <td class="trr">
                    <span>右隊上限：</span></td>
                <td  class="trl">
                    <span>
                        <input name="txtRRFSX" type="text" value="0" onblur="_onlyNum(this)"
                            size="10" maxlength="10" id="txtRRFSX" runat="server" />
                        (萬)</span></td>
                <td class="trr">&nbsp;</td>
                <td align="center" colspan="3">&nbsp;</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span><span>自動設置：</span></span></td>
                <td  class="trl" colspan="7" >兩隊金額差距：<span>
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
            <tr align="center" >
                <td colspan="8">
                    <span>大小預設值</span></td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>大小：</span></td>
                <td colspan="7" class="trl" >
                    <select name="drpDXFS" id="drpDXFS" runat="server">
                        <option selected="selected">0</option>
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
                    </select>
                    <%--
                                <input name="txtDXFS" type="text"  value="0" onblur="_onlyNum(this)"
                                    size="10" maxlength="10" id="txtDXFS" runat="server" />--%>
                                分
                                <select name="drpDXLX" id="drpDXLX" runat="server" onchange="ConRate(this,txtDXBL)">
                                    <option value="1">+</option>
                                    <option value="0" selected="selected">平</option>
                                    <option value="-1">-</option>
                                    <option value="-2">輸</option>
                                </select>
                    <input name="txtDXBL" type="text" value="50" size="5" maxlength="3"
                        onblur="_onlyNum(this)" id="txtDXBL" runat="server" />
                    ％</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>大賠率：</span></td>
                <td  class="trl">
                    <span>
                        <input name="txtDXDPL" type="text" value="0" onblur="_onlyNum(this);CountRate(txtDXDPL,txtDXXPL,txtDXPLJZ,1);"
                            size="10" maxlength="10" id="txtDXDPL" runat="server" xml:lang="0" />
                    </span>
                </td>
                <td class="trr">
                    <span>小賠率：</span></td>
                <td class="trl" >
                    <span>
                        <input name="txtDXXPL" type="text" value="0" onblur="_onlyNum(this);CountRate(txtDXDPL,txtDXXPL,txtDXPLJZ,2);"
                            size="10" maxlength="10" id="txtDXXPL" runat="server" xml:lang="0" />
                    </span>
                </td>
                <td class="trr">
                    <span>大小賠率加總：</span></td>
                <td  colspan="3" class="trl">
                    <span>
                        <input name="txtDXPLJZ" type="text" value="0" onblur="_onlyNum(this);CountRate(txtDXDPL,txtDXXPL,txtDXPLJZ,3);"
                            size="10" maxlength="10" id="txtDXPLJZ" runat="server" />
                    </span>
                </td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>大過關差距：</span></td>
                <td  class="trl">
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
                <td  class="trl">
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
                <td align="center" colspan="3">&nbsp;</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>左隊上限：</span></td>
                <td  class="trl">
                    <span>
                        <input name="txtLDXSX" type="text" value="0" onblur="_onlyNum(this)"
                            size="10" maxlength="10" id="txtLDXSX" runat="server" />
                        (萬)</span></td>
                <td class="trr">
                    <span>右隊上限：</span></td>
                <td  class="trl">
                    <span>
                        <input name="txtRDXSX" type="text" value="0" onblur="_onlyNum(this)"
                            size="10" maxlength="10" id="txtRDXSX" runat="server" />
                        (萬)</span></td>
                <td class="trr">&nbsp;</td>
                <td colspan="3" align="center">&nbsp;</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span><span>自動設置：</span></span></td>
                <td class="trl" colspan="7" >兩隊金額差距：<span>
                    <input name="txtDXCJ" type="text" value="0" onblur="_onlyNum(this)"
                        size="10" maxlength="10" id="txtDXCJ" runat="server" />
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
            <tr align="center" >
                <td colspan="8">
                    <span>獨贏預設值</span></td>
            </tr>
            <tr  >
                <td class="trr" style="width: 15%">
                    <span>左隊賠率：</span></td>
                <td  style="width: 15%" class="trl">
                    <span>
                        <input name="txtLDYPL" type="text" value="0" onblur="_onlyNum(this);//CountRate(txtLDYPL,txtRDYPL,txtDYPLJZ,1);"
                            size="10" maxlength="10" id="txtLDYPL" runat="server" />
                    </span>
                </td>
                <td class="trr" style="width: 15%">
                    <span>右隊賠率：</span></td>
                <td  style="width: 15%" class="trl">
                    <span>
                        <input name="txtRDYPL" type="text" value="0" onblur="_onlyNum(this);//CountRate(txtLDYPL,txtRDYPL,txtDYPLJZ,2);"
                            size="10" maxlength="10" id="txtRDYPL" runat="server" />
                    </span>
                </td>
                <td class="trr" style="width: 10%; display: none">
                    <span>獨贏賠率加總：</span></td>
                <td  style="width: 10%; display: none">
                    <span>
                        <input name="txtDYPLJZ" type="text" value="0" onblur="_onlyNum(this);//CountRate(txtLDYPL,txtRDYPL,txtDYPLJZ,3);"
                            size="10" maxlength="10" id="txtDYPLJZ" runat="server" />
                    </span>
                </td>
                <td class="trr" style="width: 10%">和局賠率：</td>
                <td  class="trl">
                    <input name="txtN_HJPL" type="text" value="0" onblur="_onlyNum(this);"
                        size="10" maxlength="10" id="txtN_HJPL" runat="server" /></td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>左隊過關差距：</span></td>
                <td  class="trl">
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
                <td  class="trl">
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
                <td class="trr" style="display: none"></td>
                <td  style="display: none"></td>
                <td class="trr">和局過關差距：</td>
                <td class="trl" >
                    <input name="txtN_HJGGCJ" type="text" value="0" onblur="_onlyNum(this);"
                        size="10" maxlength="10" id="txtN_HJGGCJ" runat="server" /></td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>左隊上限</span></td>
                <td  class="trl">
                    <span>
                        <input name="txtLDYSX" type="text" size="10" maxlength="10" id="txtLDYSX"
                            runat="server" value="0" onblur="_onlyNum(this)" />
                        (萬)</span></td>
                <td class="trr">
                    <span>右隊上限：</span></td>
                <td class="trl" >
                    <span>
                        <input name="txtRDYSX" type="text" size="10" maxlength="10" id="txtRDYSX"
                            runat="server" value="0" onblur="_onlyNum(this)" />
                        (萬)</span></td>
                <td class="trr" style="display: none"></td>
                <td align="center" style="display: none"></td>
                <td class="trr">和局上限：</td>
                <td  class="trl">
                    <input name="txtN_HJSX" type="text" value="0" onblur="_onlyNum(this);"
                        size="10" maxlength="10" id="txtN_HJSX" runat="server" /></td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>自動設置：</span></td>
                <td colspan="7" class="trl">
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
            <tr align="center" >
                <td colspan="8">
                    <span>單雙預設值</span></td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>單賠率：</span></td>
                <td class="trl" >
                    <span>
                        <input name="txtDSDPL" type="text" value="0" onblur="_onlyNum(this);CountRate(txtDSDPL,txtDSSPL,txtDSPLJZ,1);"
                            size="10" maxlength="10" id="txtDSDPL" runat="server" />
                    </span>
                </td>
                <td class="trr">
                    <span>雙賠率：</span></td>
                <td class="trl" >
                    <span>
                        <input name="txtDSSPL" type="text" value="0" onblur="_onlyNum(this);CountRate(txtDSDPL,txtDSSPL,txtDSPLJZ,2);"
                            size="10" maxlength="10" id="txtDSSPL" runat="server" />
                    </span>
                </td>
                <td class="trr">
                    <span>單雙賠率加總：</span></td>
                <td  colspan="3" class="trl">
                    <span>
                        <input name="txtDSPLJZ" type="text" value="0" onblur="_onlyNum(this);CountRate(txtDSDPL,txtDSSPL,txtDSPLJZ,3);"
                            size="10" maxlength="10" id="txtDSPLJZ" runat="server" />
                    </span>
                </td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>單過關差距：</span></td>
                <td  class="trl">
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
                <td  class="trl">
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
                <td >&nbsp;</td>
                <td  colspan="3">&nbsp;</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>左隊上限：</span></td>
                <td class="trl" >
                    <span>
                        <input name="txtLDSSX" type="text" value="0" onblur="_onlyNum(this)"
                            size="10" maxlength="10" id="txtLDSSX" runat="server" />
                        (萬)</span></td>
                <td class="trr">
                    <span>右隊上限：</span></td>
                <td class="trl" >
                    <span>
                        <input name="txtRDSSX" type="text" value="0" onblur="_onlyNum(this)"
                            size="10" maxlength="10" id="txtRDSSX" runat="server" />
                        (萬)</span></td>
                <td class="trr">&nbsp;</td>
                <td colspan="3" align="center">&nbsp;</td>
            </tr>
            <tr  >
                <td class="trr">
                    <span>自動設置：</span></td>
                <td colspan="7" class="trl" >
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
            <tr>
                <td colspan="8"  align="center">
                    <span>入球數預設值</span></td>
            </tr>
            <tr >
                <td class="trr">
                    <span>賠率：</span></td>
                <td  colspan="12" style="width: 200px;" class="trl">
                    <table  style="width:100%; height:100%;" cellpadding="1" class="table"
                        cellspacing="1">
                        <tr>
                            <td align="center">0-1
                            </td>
                            <td align="center">2-3</td>
                            <td align="center">4-6</td>
                            <td align="center">&gt;=7</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:TextBox ID="txtrqs01" Text="0" onblur="_onlyNum(this);" Style="width: 50px;" runat="server"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtrqs23" Text="0" onblur="_onlyNum(this);" runat="server"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtrqs46" Text="0" onblur="_onlyNum(this);" runat="server"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtrqs7" Text="0" onblur="_onlyNum(this);" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr  style="display: none">
                <td class="trr">
                    <span><span class="FormLabel">每項上限</span>：</span></td>
                <td  colspan="12" class="trl">
                    <span>
                        <asp:TextBox Style="width: 50px;" ID="txtrqssx" onblur="_onlyNum(this);" Text="0" runat="server"></asp:TextBox>万</span></td>
            </tr>
            <tr>
                <td align="center"  class="tr_f1" colspan="8">
                    <span>波膽預設值</span></td>
            </tr>
            <tr >
                <td class="trr" style="height: 78px">
                    <span>賠率：</span></td>
                <td  colspan="12" style="height: 78px" class="trl">
                    <table style="width:100%" class="table"  cellpadding="1"
                        cellspacing="1">
                        <tr>
                            <td align="center" style="height: 21px; width: 40px;"></td>
                            <td align="center" style="height: 21px">1：0</td>
                            <td align="center" style="height: 21px">2：0</td>
                            <td align="center" style="height: 21px">2：1</td>
                            <td align="center" style="height: 21px; width: 43px;">3：0</td>
                            <td align="center" style="height: 21px">3：1</td>
                            <td align="center" style="height: 21px">3：2</td>
                            <td align="center" style="height: 21px">4：0</td>
                            <td align="center" style="height: 21px">4：1</td>
                            <td align="center" style="height: 21px">4：2</td>
                            <td align="center" style="height: 21px">4：3</td>
                            <td align="center" style="height: 21px">0：0</td>
                            <td align="center" style="height: 21px">1：1</td>
                            <td align="center" style="height: 21px">2：2</td>
                            <td align="center" style="height: 21px">3：3</td>
                            <td align="center" style="height: 21px">4：4</td>
                            <td align="center" style="height: 21px">&gt;=5</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <span class="FormLabel">主場</span></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtzc10" onblur="_onlyNum(this);" Text="0" runat="server"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtzc20" Text="0" onblur="_onlyNum(this);" runat="server"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtzc21" Text="0" onblur="_onlyNum(this);" runat="server"></asp:TextBox></td>
                            <td align="center" style="height: 21px; width: 43px;">
                                <asp:TextBox Style="width: 50px;" ID="txtzc30" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtzc31" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtzc32" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtzc40" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtzc41" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtzc42" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtzc43" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td rowspan="2" align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txt00" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td rowspan="2" align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txt11" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td rowspan="2" align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txt22" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td rowspan="2" align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txt33" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td rowspan="2" align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txt44" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtzc5" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <span class="FormLabel">客場</span></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtkc10" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtkc20" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtkc21" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px; width: 43px;">
                                <asp:TextBox Style="width: 50px;" ID="txtkc30" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtkc31" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtkc32" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtkc40" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtkc41" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtkc42" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtkc43" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center" style="height: 21px">
                                <asp:TextBox Style="width: 50px;" ID="txtkc5" runat="server" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr  style="display: none">
                <td class="trr">
                    <span><span class="FormLabel">每項上限</span>：</span></td>
                <td  colspan="12">
                    <span>
                        <asp:TextBox Style="width: 50px;" ID="txtbdsx" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox>万</span></td>
            </tr>
            <tr>
                <td align="center"  class="tr_f1" colspan="8">
                    <span>半全場預設值</span></td>
            </tr>
            <tr >
                <td class="trr">
                    <span>賠率：</span></td>
                <td  colspan="12" style="width: 200px;">
                    <table style="width: 100%;" cellpadding="1" class="table"
                        cellspacing="1">
                        <tr>
                            <td align="center" style="height: 21px">主/主
                            </td>
                            <td align="center" style="height: 21px">主/和</td>
                            <td align="center" style="height: 21px">主/客</td>
                            <td align="center" style="height: 21px">和/主</td>
                            <td align="center" style="height: 21px">和/和
                            </td>
                            <td align="center" style="height: 21px">和/客</td>
                            <td align="center" style="height: 21px">客/主</td>
                            <td align="center" style="height: 21px">客/和</td>
                            <td align="center" style="height: 21px">客/客
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:TextBox ID="txtbqczz" Text="0" Style="width: 50px;" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtbqczh" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtbqczk" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtbqchz" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox ID="txtbqchh" Text="0" Style="width: 50px;" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtbqchk" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtbqckz" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtbqckh" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                            <td align="center">
                                <asp:TextBox Style="width: 50px;" ID="txtbqckk" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr  style="display: none">
                <td class="trr">
                    <span><span class="FormLabel">每項上限</span>：</span></td>
                <td  colspan="12" class="trl">
                    <span>
                        <asp:TextBox Style="width: 50px;" ID="txtbqcsx" Text="0" runat="server" onblur="_onlyNum(this);"></asp:TextBox>万</span></td>
            </tr>
            
        </table>
    </div>
</asp:Content>
