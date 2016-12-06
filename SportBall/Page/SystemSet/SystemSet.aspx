<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="SystemSet.aspx.cs" Inherits="SystemSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <script src="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <script src="SystemSet.js" type="text/javascript"></script>

    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">系统设置</a>  <span
            class="divider">/</span> 系统设置
    </ul>
    <div class="title_right">
        <strong>球类系统设置</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table">
             <tr>
                <td class="trr" style="width: 20%"></td>
                <td style="width: 80%" align="left">
                    <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="button" OnClick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">系統模式：

                </td>
                <td class="trl" style="width: 80%">
                    <asp:DropDownList ID="dropMode" runat="server">
                        <asp:ListItem Value="1">模式一</asp:ListItem>
                        <asp:ListItem Value="2">模式二</asp:ListItem>
                        <asp:ListItem Value="3">模式三</asp:ListItem>
                        <asp:ListItem Value="4">模式四</asp:ListItem>
                        <asp:ListItem Value="5">模式五</asp:ListItem>
                    </asp:DropDownList>
                    <span>模式說明</span>

                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">今日帳務日期：
                  
                </td>
                <td class="trl" style="width: 80%">
                    <asp:TextBox ID="textDate" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">已經過帳並備份完成日期:

                </td>
                <td class="trl" style="width: 80%">
                    <asp:TextBox ID="textFinishDate" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">是否允許修改拆帳：

                </td>
                <td class="trl" style="width: 80%">
                    <asp:DropDownList ID="dropIsAllow" runat="server">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>

                    </asp:DropDownList>

                    <span>※注意：修改拆帳百分比只會對「新注單」生效，設定為不允許時，沒有未計算注單者仍可修改。</span>
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">會員登入後首頁：

                </td>
                <td class="trl" style="width: 80%">
                    <asp:DropDownList ID="dropIsHome" runat="server">
                        <asp:ListItem Value="1">籃球</asp:ListItem>
                        <asp:ListItem Value="2">棒球</asp:ListItem>
                        <asp:ListItem Value="3">网球</asp:ListItem>
                        <asp:ListItem Value="6">排球</asp:ListItem>
                        <asp:ListItem Value="4">足球</asp:ListItem>
                        <asp:ListItem Value="5">美足</asp:ListItem>
                        <asp:ListItem Value="13">冰球</asp:ListItem>
                        <asp:ListItem Value="14">彩球</asp:ListItem>
                        <asp:ListItem Value="7">期指</asp:ListItem>
                        <asp:ListItem Value="9">賽馬</asp:ListItem>
                        <asp:ListItem Value="10">六合彩</asp:ListItem>
                        <asp:ListItem Value="11">大樂透</asp:ListItem>
                        <asp:ListItem Value="12">運動彩票</asp:ListItem>
                        <asp:ListItem Value="15">時事</asp:ListItem>

                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">重設所有會員信用額度：

                </td>
                <td class="trl" style="width: 80%">
                    <asp:Button ID="btnreset" Enabled="false" runat="server" Text="重設" OnClick="btnreset_Click"  CssClass="button"/>
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">所有會員的單注下限不得低於：

                </td>
                <td class="trl" style="width: 80%">

                    <input name="txtn_hyxx" type="text" maxlength="7" onblur="_onlyNum(this);" value="0"
                        size="14" id="txtn_hyxx" runat="server" />
                    （元）
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">過關下注的每注最高彩上限：

                </td>
                <td class="trl" style="width: 80%">

                    <input name="txtn_ggxs" type="text" onblur="_onlyNum(this);" value="0"
                        maxlength="7" size="14" id="txtn_ggxs" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">下注金額大於等於多少才判斷是否為危險注單：

                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtn_wxje" type="text" onblur="_onlyNum(this);" maxlength="7" value="0"
                        size="14" id="txtn_wxje" runat="server" />
                    （元）
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">指定的會員下注延遲：

                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtn_ycxz" type="text" onblur="onlyInt(this);" value="0"
                        size="14" maxlength="7" id="txtn_ycxz" runat="server" />
                    （秒） <a href="DelayedManager.aspx?type=HY">下注延遲的會員清單 </a><a href="DelayedManager.aspx?type=ZH">下注延遲的六級用戶清單
                    </a>
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">滾球延遲：

                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtn_zdyc" runat="server" onblur="onlyInt(this);" value="0" id="txtn_zdyc"
                        maxlength="7" type="text" size="14">
                    （秒）
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">足球A盤的賠率=足球D盤的賠率： -

                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtn_zqapl" runat="server" id="txtn_zqapl" value="0" onblur="_onlyNum(this);"
                        type="text" maxlength="7" size="14">
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">足球B盤的賠率=足球D盤的賠率： -

                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtn_zqbpl" runat="server" id="txtn_zqbpl" value="0" onblur="_onlyNum(this);"
                        type="text" maxlength="7" size="14">
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">足球C盤的賠率=足球D盤的賠率： -

                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtn_hl" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtn_hl" runat="server">
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">會員超過幾天下注，系統就不允許登入：

                </td>
                <td class="trl" style="width: 80%">
                    <select name="drpn_gbhy" runat="server" id="drpn_gbhy">
                        <option selected="selected" value="5">5</option>
                        <option value="10">10</option>
                        <option value="15">15</option>
                        <option value="20">20</option>
                        <option value="25">25</option>
                        <option value="30">30</option>
                        <option value="35">35</option>
                        <option value="40">40</option>
                        <option value="45">45</option>
                        <option value="50">50</option>
                        <option value="55">55</option>
                        <option value="60">60</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">會員單式右側：

                </td>
                <td class="trl" style="width: 80%">
                    <select name="drpn_rzcx" runat="server" id="drpn_rzcx">
                        <option selected="selected" value="0">無廣告</option>
                        <option value="1">指數(FLASH1)</option>
                        <option value="2">線上暗棋(FLASH1)</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">是否允許查詢歷史報表：

                </td>
                <td class="trl" style="width: 80%">
                    <select name="drpn_cxbb" runat="server" id="drpn_cxbb">
                        <option selected="selected" value="0">允許</option>
                        <option value="1">不允許</option>
                        <option value="2">僅允許公司</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">滾球延遲：

                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtn_zdyc" runat="server" onblur="onlyInt(this);" value="0" id="Text7"
                        maxlength="7" type="text" size="14">
                    （秒）
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">是否启用押跳

                </td>
                <td class="trl" style="width: 80%">
                    <asp:RadioButtonList ID="radIsJump" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>

                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">主客和压跳金额：

                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtJumpedMoneySpecial" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtJumpedMoneySpecial" runat="server" />
                    赔率：<input name="txtJumpedRateSpecial" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtJumpedRateSpecial" runat="server" />
                    最大次数：<input name="txtJumpedMaxSpecial" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtJumpedMaxSpecial" runat="server" />
                </td>

            </tr>
            <tr>
                <td class="trr" style="width: 20%">一般压跳金额：
                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtJumpedMoneyGeneral" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtJumpedMoneyGeneral" runat="server" />
                    赔率：<input name="txtJumpedRateGeneral" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtJumpedRateGeneral" runat="server" />
                    最大次数：<input name="txtJumpedMaxGeneral" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtJumpedMaxGeneral" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">滚球删单延时循环次数：
                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtDelayTimes" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtDelayTimes" runat="server" />次
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">滚球删单每次延时时间：
                </td>
                <td class="trl" style="width: 80%">
                    <input name="txtDelayTime" type="text" onblur="_onlyNum(this);" value="0"
                        size="14" maxlength="7" id="txtDelayTime" runat="server" />秒
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%">允許操盤手登入的IP
                </td>
                <td class="trl" style="width: 80%">
                    <span style="text-decoration-color: red">空白表示不限制 ，請用；分開</span>
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%"></td>
                <td class="trl" style="width: 80%">
                    <asp:TextBox ID="txtIP" runat="server" TextMode="MultiLine" Height="80px" Width="800px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 20%"></td>
                <td class="trl" style="width: 80%">
                    <span><span class="text_12_bklue"><a href="#">查看備份網站</a></span></span>
                </td>
            </tr> 
        </table>

    </div>

</asp:Content>
