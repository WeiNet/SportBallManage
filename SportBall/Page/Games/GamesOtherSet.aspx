<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GamesOtherSet.aspx.cs" Inherits="GamesOtherSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="jquery.json.js" type="text/javascript"></script>
    <script src="game.js" type="text/javascript"></script>
    <script src="baseball.js" type="text/javascript"></script>
    <script src="GamesOtherSet.js" type="text/javascript"></script>
    <link href="../../Styles/master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" border="0" class="blue_table">

                <tr>
                    <td class="t1">&nbsp;</td>
                    <td class="t2" style="padding-top: 4px;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>

                                <td class="td_title" align="left">
                                    <asp:Label ID="lblball" runat="server" Text=""></asp:Label>新比賽建立
                                <input id="hidMode" type="hidden" runat="server" value="Add" />
                                    <input id="hidN_ID" type="hidden" runat="server" value="-1" />
                                    <input id="hidTeam" type="hidden" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="t3">&nbsp;</td>
                </tr>
                <tr align="left" class="colorbg">
                    <td height="19" colspan="6">
                        <asp:Button ID="btnSave" runat="server" Text="儲存比賽" OnClick="btnSave_Click" OnClientClick="return checkSave();" CssClass="button" />
                        <asp:Button ID="btnBack" runat="server" Text="返回比賽" OnClick="btnBack_Click" Visible="false" CssClass="button" />
                        <asp:Button ID="btnCopy" runat="server" Text="複製比賽" OnClick="btnCopy_Click" Visible="false"
                            OnClientClick="return confirm('你確定要複製這場比賽嗎?')" CssClass="button" />
                        <asp:Button ID="btnDelete" runat="server" Text="刪除比賽" OnClick="btnDelete_Click" Visible="false"
                            OnClientClick="return confirm('你確定要刪除這場比賽嗎?')" CssClass="button" /></td>
                </tr>
                <tr>
                    <td class="t4">&nbsp;</td>
                    <td class="t5">
                        <table width="100%" border="0" cellpadding="4" cellspacing="1" class="pt_table">
                            <tr align="left" class="colorbg">
                                <td width="18%" align="right">帳務日期：</td>
                                <td colspan="5" align="left">
                                    <select name="drpZWYear" id="drpZWYear" runat="server">
                                        <option selected="selected">2008</option>
                                        <option>2009</option>
                                        <option>2010</option>
                                        <option>2011</option>
                                        <option>2012</option>
                                        <option>2013</option>
                                        <option>2014</option>
                                        <option>2015</option>
                                    </select>
                                    年
                                <select name="drpZWMonth" id="drpZWMonth" runat="server">
                                    <option selected="selected">01</option>
                                    <option>02</option>
                                    <option>03</option>
                                    <option>04</option>
                                    <option>05</option>
                                    <option>06</option>
                                    <option>07</option>
                                    <option>08</option>
                                    <option>09</option>
                                    <option>10</option>
                                    <option>11</option>
                                    <option>12</option>
                                </select>
                                    月
                                <select name="drpZWDay" id="drpZWDay" runat="server">
                                    <option selected="selected">01</option>
                                    <option>02</option>
                                    <option>03</option>
                                    <option>04</option>
                                    <option>05</option>
                                    <option>06</option>
                                    <option>07</option>
                                    <option>08</option>
                                    <option>09</option>
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
                                    <option>31</option>
                                </select>
                                    日</td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">比賽時間：
                                </td>
                                <td colspan="5" align="left">
                                    <select name="drpBSYear" id="drpBSYear" runat="server">
                                        <option selected="selected">2008</option>
                                        <option>2009</option>
                                        <option>2010</option>
                                        <option>2011</option>
                                        <option>2012</option>
                                        <option>2013</option>
                                        <option>2014</option>
                                        <option>2015</option>
                                    </select>
                                    年
                                <select name="drpBSMonth" id="drpBSMonth" runat="server">
                                    <option selected="selected">01</option>
                                    <option>02</option>
                                    <option>03</option>
                                    <option>04</option>
                                    <option>05</option>
                                    <option>06</option>
                                    <option>07</option>
                                    <option>08</option>
                                    <option>09</option>
                                    <option>10</option>
                                    <option>11</option>
                                    <option>12</option>
                                </select>
                                    月
                                <select name="drpBSDay" id="drpBSDay" runat="server">
                                    <option selected="selected">01</option>
                                    <option>02</option>
                                    <option>03</option>
                                    <option>04</option>
                                    <option>05</option>
                                    <option>06</option>
                                    <option>07</option>
                                    <option>08</option>
                                    <option>09</option>
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
                                    <option>31</option>
                                </select>
                                    日
                                <select name="drpBSHour" id="drpBSHour" runat="server">
                                    <option selected="selected">00</option>
                                    <option>01</option>
                                    <option>02</option>
                                    <option>03</option>
                                    <option>04</option>
                                    <option>05</option>
                                    <option>06</option>
                                    <option>07</option>
                                    <option>08</option>
                                    <option>09</option>
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
                                </select>
                                    時
                                <select name="drpBSMinute" id="drpBSMinute" runat="server">
                                    <option selected="selected">00</option>
                                    <option>05</option>
                                    <option>10</option>
                                    <option>15</option>
                                    <option>20</option>
                                    <option>25</option>
                                    <option>30</option>
                                    <option>35</option>
                                    <option>40</option>
                                    <option>45</option>
                                    <option>50</option>
                                    <option>55</option>
                                </select>
                                    分</td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">所屬聯盟：
                                </td>
                                <td colspan="2" align="left">
                                    <span>
                                        <input id="hidLM" type="hidden" value="-1" runat="server" />
                                        <asp:DropDownList ID="drpLM" onchange="getTeamList12(this,false);$('#hidLM').val(this.value);"
                                            runat="server">
                                        </asp:DropDownList></span></td>
                                <td align="right">場別：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:CheckBoxList Css ID="chkCB" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">全場</asp:ListItem>
                                        <asp:ListItem Value="2">上半場</asp:ListItem>
                                        <asp:ListItem Value="4">下半場</asp:ListItem>
                                    </asp:CheckBoxList>
                                    <asp:RadioButtonList Css ID="rdoCB" runat="server" RepeatDirection="Horizontal" Visible="False">
                                        <asp:ListItem Value="1">全場</asp:ListItem>
                                        <asp:ListItem Value="2">上半場</asp:ListItem>
                                        <asp:ListItem Value="4">下半場</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">比賽球隊：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:RadioButton ID="rdoVisit" runat="server" GroupName="Team" />
                                    <asp:DropDownList ID="drpVisit" runat="server" Width="150px" onchange="$('#hidVisit').val(this.value);">
                                    </asp:DropDownList>
                                    <input id="hidVisit" type="hidden" value="-1" runat="server" style="width: 15px" />VS
                                <asp:RadioButton ID="rdoHome" GroupName="Team" runat="server" />
                                    <asp:DropDownList ID="drpHome" runat="server" Width="150px" onchange="$('#hidHome').val(this.value);">
                                    </asp:DropDownList>
                                    <input id="hidHome" type="hidden" value="-1" runat="server" style="width: 13px" /></td>
                                <td align="right">是否開滾球：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:RadioButtonList ID="rdoZD" runat="server" Css RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr align="left" style="display: none" id="trJZF" runat="server" visible="false">
                                <td align="right">基準分：
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtVisitJZF" runat="server" Text="0" onblur="_onlyNum(this)"></asp:TextBox>
                                    VS
                                <asp:TextBox ID="txtHomeJZF" runat="server" Text="0" onblur="_onlyNum(this)"></asp:TextBox></td>
                                <td align="right">是否開放基準分：
                                </td>
                                <td align="left" colspan="2">
                                    <asp:RadioButtonList ID="rdoOpenJZF" runat="server" Css RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">場次編號：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtVisitNo" runat="server" onblur="getOtherHomeNo(this);"></asp:TextBox>
                                    VS
                                <asp:TextBox ID="txtHomeNo" runat="server" onblur="getOtherVisitNo(this);"></asp:TextBox></td>
                                <td align="right">直播名稱：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:DropDownList ID="drpZBName" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">投 手：
                                </td>
                                <td colspan="5" align="left">
                                    <asp:TextBox ID="txtVisitTSNo" runat="server" MaxLength="50"></asp:TextBox>
                                    VS
                                <asp:TextBox ID="txtHomeTSNo" runat="server" MaxLength="50"></asp:TextBox></td>
                            </tr>
                            <tr align="left" class="colorbg" style="display: none">
                                <td align="right">會員單注上限：
                                </td>
                                <td colspan="5" align="left">
                                    <asp:TextBox ID="txtDZSX" runat="server" Text="0" MaxLength="7" onblur="_onlyNum(this)"></asp:TextBox>
                                    (萬)
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">會員單場上限：
                                </td>
                                <td colspan="5" align="left">
                                    <asp:TextBox ID="txtDCSX" runat="server" Text="0" MaxLength="7" onblur="_onlyNum(this)"></asp:TextBox>
                                    (萬)
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td colspan="6" align="center">
                                    <span>讓分預設值</span></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>讓分：</span></td>
                                <td colspan="3" align="left">
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
                                <select name="drpRFLX" id="drpRFLX" runat="server" onchange="ConRate(this,txtRFBL) ">
                                    <option value="1">+</option>
                                    <option value="0" selected="selected">平</option>
                                    <option value="-1">-</option>
                                    <option value="-2">輸</option>
                                </select>
                                    <input name="txtRFBL" type="text" value="" size="5" maxlength="3" onblur="_onlyNum(this)"
                                        id="txtRFBL" runat="server" />
                                    ％</td>
                                <td align="right">下為強隊：
                                </td>
                                <td>
                                    <%--<asp:CheckBox ID="chkLet" runat="server" />--%>
                                    <input id="chkLet" type="checkbox" runat="server" />
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>左隊賠率：</span></td>
                                <td width="15%" align="left">
                                    <span class="eng_bk_r"><span>
                                        <input name="txtLRFPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtLRFPL,txtRRFPL,txtRFPLJZ,1);"
                                            size="10" maxlength="10" id="txtLRFPL" runat="server" />
                                    </span></span>
                                </td>
                                <td width="16%" align="right">
                                    <span>右隊賠率：</span></td>
                                <td width="19%" align="left">
                                    <span>
                                        <input name="txtRRFPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtLRFPL,txtRRFPL,txtRFPLJZ,2);"
                                            size="10" maxlength="10" id="txtRRFPL" runat="server" /></span></td>
                                <td width="17%" align="right">
                                    <span>讓分賠率加總：</span></td>
                                <td width="15%" align="left">
                                    <span>
                                        <input name="txtRFPLJZ" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtLRFPL,txtRRFPL,txtRFPLJZ,3);"
                                            size="10" maxlength="10" id="txtRFPLJZ" runat="server" />
                                    </span>
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>左隊過關差距：</span></td>
                                <td align="left">
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
                                <td align="right">
                                    <span>右隊過關差距</span></td>
                                <td align="left">
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
                                <td align="right">過關是否關閉：</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkRFGGClose" runat="server" Checked="true" /></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span><span>左隊上限：</span></span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtLRFSX" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10"
                                            id="txtLRFSX" runat="server" />
                                        (萬) </span>
                                </td>
                                <td align="right">
                                    <span>右隊上限：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtRRFSX" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10"
                                            id="txtRRFSX" runat="server" />
                                        (萬) </span>
                                </td>
                                <td align="right">&nbsp;</td>
                                <td align="center">&nbsp;</td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span><span>自動設置：</span></span></td>
                                <td colspan="3" align="left">兩隊金額差距：<span>
                                    <input name="txtRFCJJE" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10"
                                        id="txtRFCJJE" runat="server" />
                                    (萬)
                                    <select name="drpRFCJFS" id="drpRFCJFS" runat="server" onchange="changefenshu(this)">
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
                                <td align="right">是否關閉：</td>
                                <td>
                                    <asp:CheckBox ID="chkRFClose" runat="server" Checked="true" /></td>
                            </tr>
                            <tr align="center" class="colorbg">
                                <td colspan="6">
                                    <span>大小預設值</span></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>大小：</span></td>
                                <td colspan="5" align="left">
                                    <input name="txtDXFS" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10"
                                        id="txtDXFS" runat="server" />
                                    分
                                <select name="drpDXLX" id="drpDXLX" runat="server" onchange="ConRate(this,txtDXBL) ">
                                    <option value="1">+</option>
                                    <option value="0" selected="selected">平</option>
                                    <option value="-1">-</option>
                                    <option value="-2">輸</option>
                                </select>
                                    <input name="txtDXBL" type="text" value="50" size="5" maxlength="3" onblur="_onlyNum(this)"
                                        id="txtDXBL" runat="server" />
                                    ％</td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>大賠率：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtDXDPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtDXDPL,txtDXXPL,txtDXPLJZ,1);"
                                            size="10" maxlength="10" id="txtDXDPL" runat="server" xml:lang="0" />
                                    </span>
                                </td>
                                <td align="right">
                                    <span>小賠率：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtDXXPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtDXDPL,txtDXXPL,txtDXPLJZ,2);"
                                            size="10" maxlength="10" id="txtDXXPL" runat="server" xml:lang="0" />
                                    </span>
                                </td>
                                <td align="right">
                                    <span>大小賠率加總：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtDXPLJZ" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtDXDPL,txtDXXPL,txtDXPLJZ,3);"
                                            size="10" maxlength="10" id="txtDXPLJZ" runat="server" />
                                    </span>
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>大過關差距：</span></td>
                                <td align="left">
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
                                <td align="right">
                                    <span>小過關差距：</span></td>
                                <td align="left">
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
                                <td align="right">過關是否關閉：</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkDXGGClose" runat="server" Checked="true" /></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>左隊上限：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtLDXSX" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10"
                                            id="txtLDXSX" runat="server" />
                                        (萬) </span>
                                </td>
                                <td align="right">
                                    <span>右隊上限：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtRDXSX" type="text" size="10" maxlength="10" id="txtRDXSX" runat="server"
                                            value="0" onblur="_onlyNum(this)" />
                                        (萬) </span>
                                </td>
                                <td align="right"></td>
                                <td></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span><span>自動設置：</span></span></td>
                                <td colspan="3" align="left">兩隊金額差距：<span>
                                    <input name="txtDXCJ" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10"
                                        id="txtDXCJ" runat="server" />
                                    (萬) 調賠率：
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
                                <td align="right">是否關閉：</td>
                                <td>
                                    <asp:CheckBox ID="chkDXClose" runat="server" Checked="true" /></td>
                            </tr>
                            <tr align="center" class="colorbg">
                                <td colspan="6">
                                    <span>獨贏預設值</span></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>左隊賠率：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtLDYPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(this,txtRDYPL,txtDYPLJZ,1);"
                                            size="10" maxlength="10" id="txtLDYPL" runat="server" />
                                    </span>
                                </td>
                                <td align="right">
                                    <span>右隊賠率：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtRDYPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtLDYPL,this,txtDYPLJZ,2);"
                                            size="10" maxlength="10" id="txtRDYPL" runat="server" />
                                    </span>
                                </td>
                                <td align="right">
                                    <span>獨贏賠率加總：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtDYPLJZ" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtLDYPL,txtRDYPL,this,3);"
                                            size="10" maxlength="10" id="txtDYPLJZ" runat="server" />
                                    </span>
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>左隊過關差距：</span></td>
                                <td align="left">
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
                                <td align="right">
                                    <span>右隊過關差距：</span></td>
                                <td align="left">
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
                                <td align="right">過關是否關閉：</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkDYGGClose" runat="server" Checked="true" /></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>左隊上限</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtLDYSX" type="text" size="10" maxlength="10" id="txtLDYSX" runat="server"
                                            value="0" onblur="_onlyNum(this)" />
                                        (萬) </span>
                                </td>
                                <td align="right">
                                    <span>右隊上限：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtRDYSX" type="text" size="10" maxlength="10" id="txtRDYSX" runat="server"
                                            value="0" onblur="_onlyNum(this)" />
                                        (萬) </span>
                                </td>
                                <td align="right">&nbsp;</td>
                                <td align="center">&nbsp;</td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>自動設置：</span></td>
                                <td colspan="3" align="left">
                                    <span>兩隊金額差距：
                                    <input name="txtDYCJ" type="text" value="0" size="10" maxlength="10" id="txtDYCJ"
                                        runat="server" />
                                        (萬) 調賠率：
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
                                <td align="right">是否關閉：</td>
                                <td>
                                    <asp:CheckBox ID="chkDYClose" runat="server" Checked="true" /></td>
                            </tr>
                            <tbody id="onePonit">
                                <tr>
                                    <td colspan="6" class="colorbg" align="center">
                                        <span>一輸二贏預設值</span></td>
                                </tr>
                                <tr class="colorbg">
                                    <td align="right">
                                        <span>左隊賠率：</span></td>
                                    <td align="left">
                                        <span>
                                            <input name="txtLSYPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtLSYPL,txtRSYPL,txtSYPLJZ,1);"
                                                size="10" maxlength="10" id="txtLSYPL" runat="server" />
                                        </span>
                                    </td>
                                    <td align="right">
                                        <span>右隊賠率：</span></td>
                                    <td align="left">
                                        <span>
                                            <input name="txtRSYPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtLSYPL,txtRSYPL,txtSYPLJZ,2);"
                                                size="10" maxlength="10" id="txtRSYPL" runat="server" />
                                        </span>
                                    </td>
                                    <td align="right">
                                        <span>獨贏賠率加總：</span></td>
                                    <td align="left">
                                        <span>
                                            <input name="txtSYPLJZ" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtLSYPL,txtRSYPL,txtSYPLJZ,3);"
                                                size="10" maxlength="10" id="txtSYPLJZ" runat="server" />
                                        </span>
                                    </td>
                                </tr>
                                <tr class="colorbg">
                                    <td align="right">
                                        <span>左隊過關差距：</span></td>
                                    <td align="left">
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
                                    <td align="right">
                                        <span>右隊過關差距：</span></td>
                                    <td align="left">
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
                                    <td align="right">過關是否關閉：</td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkSYGGClose" runat="server" Checked="true" /></td>
                                </tr>
                                <tr class="colorbg">
                                    <td align="right">
                                        <span>左隊上限</span></td>
                                    <td align="left">
                                        <span>
                                            <input name="txtLSYSX" type="text" size="10" maxlength="10" id="txtLSYSX" runat="server"
                                                value="0" onblur="_onlyNum(this)" />
                                            (萬) </span>
                                    </td>
                                    <td align="right">
                                        <span>右隊上限：</span></td>
                                    <td align="left">
                                        <span>
                                            <input name="txtRSYSX" type="text" size="10" maxlength="10" id="txtRSYSX" runat="server"
                                                value="0" onblur="_onlyNum(this)" />
                                            (萬) </span>
                                    </td>
                                    <td align="right">&nbsp;</td>
                                    <td align="center">&nbsp;</td>
                                </tr>
                                <tr class="colorbg">
                                    <td align="right">
                                        <span>自動設置：</span></td>
                                    <td colspan="3" align="left">
                                        <span>兩隊金額差距：
                                    <input name="txtSYCJ" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10"
                                        id="txtSYCJ" runat="server" />
                                            (萬) 調賠率：
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
                                    <td align="right">是否關閉：</td>
                                    <td>
                                        <asp:CheckBox ID="chkSYClose" runat="server" Checked="true" /></td>
                                </tr>
                            </tbody>
                            <tr align="center" class="colorbg">
                                <td colspan="6">
                                    <span>單雙預設值</span></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>單賠率：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtDSDPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtDSDPL,txtDSSPL,txtDSPLJZ,1);"
                                            size="10" maxlength="10" id="txtDSDPL" runat="server" />
                                    </span>
                                </td>
                                <td align="right">
                                    <span>雙賠率：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtDSSPL" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtDSDPL,txtDSSPL,txtDSPLJZ,2);"
                                            size="10" maxlength="10" id="txtDSSPL" runat="server" />
                                    </span>
                                </td>
                                <td align="right">
                                    <span>單雙賠率加總：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtDSPLJZ" type="text" value="0" onblur="_onlyNum4(this);CountRate(txtDSDPL,txtDSSPL,txtDSPLJZ,3);"
                                            size="10" maxlength="10" id="txtDSPLJZ" runat="server" />
                                    </span>
                                </td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>單過關差距：</span></td>
                                <td align="left">
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
                                <td align="right">
                                    <span>雙過關差距：</span></td>
                                <td align="left">
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
                                <td align="right">過關是否關閉：</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkDSGGClose" runat="server" Checked="true" /></td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>左隊上限：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtLDSSX" type="text" size="10" maxlength="10" id="txtLDSSX" runat="server"
                                            value="0" onblur="_onlyNum(this)" />
                                        (萬) </span>
                                </td>
                                <td align="right">
                                    <span>右隊上限：</span></td>
                                <td align="left">
                                    <span>
                                        <input name="txtRDSSX" type="text" size="10" maxlength="10" id="txtRDSSX" runat="server"
                                            value="0" onblur="_onlyNum(this)" />
                                        (萬) </span>
                                </td>
                                <td align="right">&nbsp;</td>
                                <td align="center">&nbsp;</td>
                            </tr>
                            <tr align="left" class="colorbg">
                                <td align="right">
                                    <span>自動設置：</span></td>
                                <td colspan="3" align="left">
                                    <span>兩隊金額差距：
                                    <input name="txtDSCJ" type="text" value="0" onblur="_onlyNum(this)" size="10" maxlength="10"
                                        id="txtDSCJ" runat="server" />
                                        (萬) 調賠率：
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
                                <td align="right">是否關閉：</td>
                                <td>
                                    <asp:CheckBox ID="chkDSClose" runat="server" Checked="true" /></td>
                            </tr>
                        </table>
                    </td>
                    <td class="t6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="t7">&nbsp;</td>
                    <td class="t8"></td>
                    <td class="t9">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
