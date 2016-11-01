<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="xzhy.aspx.cs" Inherits="xzhy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AgentManageAdd.js" type="text/javascript"></script>
    <script src="xzhy.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">会员管理</a>  <span
            class="divider">/</span>
         新增修改會員
    </ul>
    <div class="title_right" runat="server" id="trbj">
        <strong>添加會員 代理商帳號:<asp:Label ID="lblDLS" runat="server" Text="" /></strong>
    </div>
    <input id="hidMode" runat="server" type="hidden" />
    <div style="width: 90%; margin: auto">
        <table class="table" style="">
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存會員" OnClick="btnSave_Click" OnClientClick="return Check();" CssClass="button"/>
                                <asp:Button ID="btnZD" runat="server" Text="刪除該賬號" OnClick="btnZD_Click" OnClientClick="return confirm('確認刪除??');" CssClass="button" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" CssClass="button" />
                </td>
            </tr>
     
            <tr>
                
                <td class="t5">
                    <table class="table" style="width:100%"  >
                      
                        <tr >
                            <td class="trr">
                                <font color="red">*</font>會員帳號：</td>
                            <td>
                                <asp:Label ID="lblEndUser" runat="server" Text=""></asp:Label>
                                <asp:DropDownList ID="drpEndUser" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="trr">
                                <font color="red">*</font>會員名稱：</td>
                            <td>
                                <input type="text" runat="server" id="txtUserName" style="width: 107px" />
                                <asp:Button ID="btnCopy" runat="server" Text="複製會員" Visible="false" OnClientClick="return openUseeName(document.getElementById('ContentPlaceHolder11_lblEndUser'),document.getElementById('ContentPlaceHolder11_lblDLS'));"
                                    OnClick="btnCopy_Click" CssClass="button" /></td>
                        </tr>
                        <tr >
                            <td class="trr">
                                <font color="red">*</font>密碼：</td>
                            <td>
                                <asp:TextBox ID="txtPwd" TextMode="Password" MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                            <td class="trr">
                                <font color="red">*</font>密碼確認：</td>
                            <td>
                                <asp:TextBox ID="txtPwdS" TextMode="Password" MaxLength="20" runat="server" /><span
                                    style="color: Red">(密碼長度不能大於20位)</span>
                            </td>
                        </tr>
                        <tr >
                            <td class="trr">
                                <font color="red">*</font>是否允許登入：</td>
                            <td>
                                <asp:RadioButtonList ID="rdoLogin" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td class="trr">
                                <font color="red">*</font>是否允許下注：</td>
                            <td>
                                <asp:RadioButtonList ID="rdoXiazhu" runat="server" CssClass="hei" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr id="trTime" >
                            <td class="trr">
                                <font color="red">*</font>登入時間：</td>
                            <td>
                                <asp:Label ID="lblLoginTime" CssClass="hei" runat="server" Text="" /></td>
                            <td class="trr">
                                <font color="red">*</font>下注時間：</td>
                            <td>
                                <asp:Label ID="lblXIaZhuTime" CssClass="hei" runat="server" Text="" /></td>
                        </tr>
                        <tr >
                            <td class="trr">
                                <font color="red">*</font>分配信用額度：<br />
                                <span id="spnSed"></span>
                            </td>
                            <td>
                                <input type="text" id="txtPay" readonly runat="server" style="width: 80px; text-align: right"
                                    maxlength="9" />(萬)
                                <asp:Label ID="txtDLSED" runat="server" Style="display: none"></asp:Label>
                                <asp:Label ID="lblPay" runat="server" Style="display: none"></asp:Label></td>
                            <td class="trr">
                                <span style="color: #ff0000">*</span><asp:Label class="FormLabel" ID="Label1" runat="server"
                                    Text="剩餘額度：" /></td>
                            <td>
                                <span id="spnLeftED">
                                    <asp:TextBox ID="txtLeftED" ReadOnly="true" CssClass="TransparentTextBoxRight" runat="server"
                                        Width="107px" />(萬)
                                    <asp:Label ID="lbLeftED" runat="server" Text="" Style="display: none" /></span></td>
                        </tr>
                        <tr >
                            <td class="trr">
                                <span style="color: #ff0000">*</span>比賽類別：</td>
                            <td colspan="3">
                                <input type="checkbox" value="1" checked="checked" id="chkLQ" runat="server" />籃球
                                <input type="checkbox" value="1" checked="checked" id="chkMB" runat="server" />棒球
                                <input type="checkbox" value="1" checked="checked" id="chkRB" runat="server" />网球
                                <input type="checkbox" value="1" checked="checked" id="chkTB" runat="server" />排球
                                <input type="checkbox" value="1" checked="checked" id="chkMQ" runat="server" />美足
                                <input type="checkbox" value="1" checked="checked" id="chkBQ" runat="server" />冰球
                                <input type="checkbox" value="1" checked="checked" id="chkCQ" runat="server" />彩球
                                <input type="checkbox" value="1" checked="checked" id="chkZQ" runat="server" />足球
                                <select id="drpPB" runat="server">
                                    <option value="1">A盤</option>
                                    <option value="2">B盤</option>
                                    <option value="3">C盤</option>
                                    <option selected="selected" value="4">D盤</option>
                                </select>
                                <input type="checkbox" value="1" checked="checked" id="chkZS" runat="server" />指數
                                <input type="checkbox" value="1" checked="checked" id="chkLT" runat="server" />大樂透
                                <input type="checkbox" value="1" checked="checked" id="chkCP" runat="server" />彩票
                                <input type="checkbox" value="1" checked="checked" id="chkSM" runat="server" />賽馬
                                <input type="checkbox" value="1" checked="checked" id="chkLHC" runat="server" />六合彩
                                <input type="checkbox" value="1" checked="checked" id="chkJC" runat="server" />今彩539
                                <input type="checkbox" value="1" checked="checked" id="chkSS" runat="server" />時事
                            </td>
                        </tr>
                        <tr >
                            <td class="trr">
                                <font color="red">*</font>單注下限：</td>
                            <td>
                                <input type="text" runat="server" value="100" onblur="_onlyNum(this);return checkLower(this.value,event.srcElement);"
                                    size="12" id="txtDZXX" />&gt;= 100</td>
                            <td class="trr">
                                <font color="red">*</font>是否延遲下注：</td>
                            <td>
                                <asp:CheckBoxList ID="chkYSXZ" CssClass="hei" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">篮球</asp:ListItem>
                                    <asp:ListItem Value="2">棒球</asp:ListItem>
                                    <asp:ListItem Value="4">排球</asp:ListItem>
                                    <asp:ListItem Value="8">足球</asp:ListItem>
                                    <asp:ListItem Value="16">美足</asp:ListItem>
                                    <asp:ListItem Value="32">网球</asp:ListItem>
                                    <asp:ListItem Value="64">指數</asp:ListItem>
                                    <asp:ListItem Value="128">賽馬</asp:ListItem>
                                    <asp:ListItem Value="256">六合彩</asp:ListItem>
                                    <asp:ListItem Value="512">大樂透</asp:ListItem>
                                    <asp:ListItem Value="1024">今彩</asp:ListItem>
                                    <asp:ListItem Value="2048">運彩</asp:ListItem>
                                    <asp:ListItem Value="4096">時事</asp:ListItem>
                                    <asp:ListItem Value="8192">冰球</asp:ListItem>
                                    <asp:ListItem Value="16384">彩球</asp:ListItem>
                                </asp:CheckBoxList></td>
                        </tr>
                        <tr >
                            <td class="trr">
                                <font color="red">*</font>會員等級：</td>
                            <td>
                                <asp:DropDownList ID="drpSafeType" runat="server">
                                    <asp:ListItem Value="1" Selected="True">一般會員</asp:ListItem>
                                    <asp:ListItem Value="2">特殊會員</asp:ListItem>
                                    <asp:ListItem Value="3">危險會員</asp:ListItem>
                                    <%--<asp:ListItem Value="3">危險等級二</asp:ListItem>
                                    <asp:ListItem Value="4">危險等級三</asp:ListItem>--%>
                                </asp:DropDownList></td>
                            <td class="trr">
                                <font color="red">*</font>過關下注關數限制：</td>
                            <td>
                                <asp:DropDownList ID="drpXiazhuNum" runat="server">
                                </asp:DropDownList></td>
                        </tr>
                        <tr id="tr_add" runat="server"  visible="false">
                            <td class="trc" colspan="4">
                                <asp:Button ID="btAddzj" runat="server" Text="新增會員" OnClick="btnSave_Click" OnClientClick="return Check();" CssClass="button" />
                            </td>
                        </tr>
                         
                    </table>
                    <br />
                    <table  border="0" cellpadding="5" cellspacing="1" class="table" style="display:none">
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            籃球設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                籃球</td>
                            <td>
                                讓分</td>
                            <td>
                                大小</td>
                            <td>
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td>
                                滾球讓分</td>
                            <td>
                                滾球大小</td>
                            <td>
                                半場讓分</td>
                            <td>
                                半場大小</td>
                            <td>
                                半場獨贏</td>
                            <td>
                                半場單雙</td>
                            <td>
                                單節讓分</td>
                            <td>
                                單節大小</td>
                            <td>
                                單節單雙</td>
                            <td>
                                過關</td>
                            <td style="display: none;">
                                冠軍</td>
                            <td>
                                全部設為<br />
                                <span style="color: Red">(不含過關)</span></td>
                        </tr>
                        <tr class="trc" id="a1" >
                            <td class="pk">
                                <a class="trc" onclick="return showinput('a1','a1');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_LQRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_RFTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_RFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DXTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DYTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDSTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_DSTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_ZDRFTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_ZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQZDDXTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_ZDDXTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCRFTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCRFTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_BCDXTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDYTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCDYTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDSTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCDSTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJRFTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_DJRFTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DJDXTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DJDSTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJDSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQGGTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_GGTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_GGTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_LQGJTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_GJTY%>"
                                    onblur="return CheckNext('a1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" />
                                <div style="display: none" name="a1">
                                    &lt;=
                                    <%=mo_KFB_SETUPLQ.N_GJTY%>
                                </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a1',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b1" >
                            <td class="pk">
                                <a  onclick="return showinput('b1','b1');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_LQRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_RFDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDXDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_DXDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DYDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDSDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_DSDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQZDRFDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_ZDRFDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQZDDXDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_ZDDXDZ %>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_BCRFDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDXDZ" maxlength="7"" " size="4" value="<%= mo_KFB_SETUPLQ.N_BCDXDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDYDZ" maxlength="7" size="4" value="<% =mo_KFB_SETUPLQ.N_BCDYDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDSDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCDSDZ %>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DJRFDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJDXDZ" maxlength="7"" " size="4" value="<%= mo_KFB_SETUPLQ.N_DJDXDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJDSDZ" maxlength="7"" " size="4" value="<%= mo_KFB_SETUPLQ.N_DJDSDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJDSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQGGDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_GGDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_GGDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_LQGJDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_GJDZ%>"
                                    onblur="return CheckNext('b1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b1',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c1" >
                            <td class="pk">
                                <a  onclick="return showinput('c1','c1');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_LQRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_RFDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DXDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DYDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DSDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQZDRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_ZDRFDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQZDDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_ZDDXDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_BCRFDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDXDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCDXDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_BCDYDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDSDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCDSDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DJRFDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJDXDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_DJDXDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJDSDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_DJDSDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJDSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQGGDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_GGDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_GGDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_LQGJDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_GJDC%>"
                                    onblur="return CheckNext('c1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_GJDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c1',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="d1" >
                            <td class="pk">
                                <a  onclick="return showinput('d1','d1');">單隊上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_LQRFDD" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_RFDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_RFDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDXDD" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DXDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DXDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDYDD" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DYDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DYDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDSDD" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_DSDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DSDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQZDRFDD" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_ZDRFDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_ZDRFDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQZDDXDD" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_ZDDXDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_ZDDXDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCRFDD" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCRFDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCRFDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDXDD" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_BCDXDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDXDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDYDD" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCDYDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDYDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQBCDSDD" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_BCDSDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_BCDSDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJRFDD" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_DJRFDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJRFDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJDXDD" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DJDXDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJDXDD%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LQDJDSDD" maxlength="7" size="4" value="<%=mo_KFB_SETUPLQ.N_DJDSDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ1.N_DJDSDD%>
                                    </div>
                            </td>
                            <td>
                                <div style="display: none">
                                    <input type="text" name="N_LQGGDD" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_GGDD%>"
                                        onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                        readonly="readonly" /><div style="display: none" name="d1">
                                            &lt;=
                                            <%=mo_KFB_SETUPLQ1.N_GGDD%>
                                        </div>
                                </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_LQGJDD" maxlength="7" size="4" value="<%= mo_KFB_SETUPLQ.N_GJDD%>"
                                    onblur="return CheckNext('d1',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d1">
                                        &lt;=
                                        <%=mo_KFB_SETUPLQ.N_GJDD%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('d1',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            棒球/冰球設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                棒球/冰球</td>
                            <td>
                                讓分</td>
                            <td>
                                大小</td>
                            <td>
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td>
                                滾球讓分</td>
                            <td>
                                滾球大小</td>
                            <td>
                                一輸二贏</td>
                            <td>
                                過關</td>
                            <td>
                                半場讓分大小</td>
                            <td>
                                全部設為<br />
                                <span style="color: Red">(不含過關)</span></td>
                            <td rowspan="4" colspan="5">
                            </td>
                        </tr>
                        <tr class="trc" id="a2" >
                            <td class="pk">
                                <a  onclick="return showinput('a2','a2');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_MBRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_RFTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_RFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DXTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DYTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DSTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_ZDRFTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_ZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_ZDDXTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBSYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_SYTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_SYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_GGTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_GGTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBGJTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_GJTY%>"
                                    onblur="return CheckNext('a2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_GJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a2',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b2" >
                            <td class="pk">
                                <a  onclick="return showinput('b2','b2');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_MBRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_RFDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DXDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DYDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DSDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBZDRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_ZDRFDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBZDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_ZDDXDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBSYDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPMB.N_SYDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_SYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBGGDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPMB.N_GGDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_GGDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBGJDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_GJDZ%>"
                                    onblur="return CheckNext('b2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b2',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c2" >
                            <td class="pk">
                                <a  onclick="return showinput('c2','c2');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_MBRFDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPMB.N_RFDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DXDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DYDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_DSDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_DSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBZDRFDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPMB.N_ZDRFDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBZDDXDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPMB.N_ZDDXDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBSYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_SYDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_SYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBGGDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMB.N_GGDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_GGDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MBGJDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPMB.N_GJDC%>"
                                    onblur="return CheckNext('c2',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c2">
                                        &lt;=
                                        <%=mo_KFB_SETUPMB1.N_GJDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c2',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            网球設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                网球</td>
                            <td>
                                讓分</td>
                            <td>
                                大小</td>
                            <td>
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td>
                                滾球讓分</td>
                            <td>
                                滾球大小</td>
                            <td>
                                一輸二贏</td>
                            <td>
                                過關</td>
                            <td>
                                半場讓分大小</td>
                            <td>
                                全部設為<br />
                                <span style="color: Red">(不含過關)</span></td>
                            <td rowspan="4" colspan="5">
                            </td>
                        </tr>
                        <tr class="trc" id="a3" >
                            <td class="pk">
                                <a  onclick="return showinput('a3','a3');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_RBRFTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPRB.N_RFTY%>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_RFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDXTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPRB.N_DXTY%>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_DYTY %>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_DSTY%>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_ZDRFTY%>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_ZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_ZDDXTY%>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBSYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_SYTY%>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_SYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_GGTY%>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_GGTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBGJTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_GJTY%>"
                                    onblur="return CheckNext('a3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_GJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a3',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b3" >
                            <td class="pk">
                                <a  onclick="return showinput('b3','b3');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_RBRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_RFDZ%>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDXDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPRB.N_DXDZ%>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_DYDZ%>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_DSDZ%>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBZDRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_ZDRFDZ%>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBZDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_ZDDXDZ %>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBSYDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPRB.N_SYDZ%>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_SYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBGGDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_GGDZ%>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_GGDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBGJDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_GJDZ%>"
                                    onblur="return CheckNext('b3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b3',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c3" >
                            <td class="pk">
                                <a  onclick="return showinput('c3','c3');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_RBRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_RFDC%>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_DXDC%>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_DYDC%>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_DSDC%>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_DSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBZDRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_ZDRFDC%>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBZDDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_ZDDXDC %>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBSYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_SYDC%>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_SYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBGGDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_GGDC%>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_GGDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_RBGJDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPRB.N_GJDC%>"
                                    onblur="return CheckNext('c3',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c3">
                                        &lt;=
                                        <%=mo_KFB_SETUPRB1.N_GJDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c3',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            排球設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                排球</td>
                            <td>
                                讓分</td>
                            <td>
                                大小</td>
                            <td>
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td>
                                滾球讓分</td>
                            <td>
                                滾球大小</td>
                            <td>
                                一輸二贏</td>
                            <td>
                                過關</td>
                            <td>
                                半場讓分大小</td>
                            <td>
                                全部設為<br />
                                <span style="color: Red">(不含過關)</span></td>
                            <td rowspan="4" colspan="5">
                            </td>
                        </tr>
                        <tr class="trc" id="a6" >
                            <td class="pk">
                                <a  onclick="return showinput('a6','a6');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_TBRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_RFTY%>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_RFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_DXTY%>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DXTY%>
                                    </div>
                            </td>
                            <td class="hei">
                                <input type="text" name="N_TBDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_DYTY%>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_DSTY%>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_ZDRFTY%>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_ZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_ZDDXTY%>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBSYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_ZDDXTY %>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_GGTY%>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_GGTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBGJTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPTB.N_GJTY%>"
                                    onblur="return CheckNext('a6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_GJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a6',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b6" >
                            <td class="pk">
                                <a  onclick="return showinput('b6','b6');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_TBRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_RFDZ%>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_DXDZ%>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBDYDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPTB.N_DYDZ%>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_DSDZ%>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBZDRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_ZDRFDZ  %>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBZDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_ZDDXDZ %>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBSYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_SYDZ%>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_SYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBGGDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPTB.N_GGDZ%>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_GGDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBGJDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_GJDZ%>"
                                    onblur="return CheckNext('b6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b6',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c6" >
                            <td class="pk">
                                <a  onclick="return showinput('c6','c6');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_TBRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_RFDC%>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_DXDC%>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_DYDC%>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_DSDC%>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_DSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBZDRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_ZDRFDC%>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBZDDXDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPTB.N_ZDDXDC %>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBSYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_SYDC%>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_SYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBGGDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPTB.N_GGDC%>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_GGDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_TBGJDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPTB.N_GJDC%>"
                                    onblur="return CheckNext('c6',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c6">
                                        &lt;=
                                        <%=mo_KFB_SETUPTB1.N_GJDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c6',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            足球設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                足球</td>
                            <td>
                                讓球</td>
                            <td>
                                大小</td>
                            <td>
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td>
                                滾球讓球</td>
                            <td>
                                滾球大小</td>
                            <td>
                                半場讓球</td>
                            <td>
                                半場大小</td>
                            <td>
                                半場獨贏</td>
                            <td>
                                入球數</td>
                            <td>
                                波膽</td>
                            <td>
                                半全場</td>
                            <td>
                                過關</td>
                            <td style="display: none;">
                                冠軍</td>
                            <td>
                                全部設為<br />
                                <span style="color: Red">(不含過關)</span></td>
                            <td rowspan="6">
                            </td>
                        </tr>
                        <tr class="trc" id="a4" >
                            <td class="pk">
                                <a  onclick="return showinput('a4','a4');">退佣設定A盤</a></td>
                            <td>
                                <input type="text" name="N_ZQARFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ARFTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ARFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQADXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ADXTY %>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ADXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQADYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ADYTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ADYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQADSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ADSTY %>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ADSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQAZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_AZDRFTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_AZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQAZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_AZDDXTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_AZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQABCRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ABCRFTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ABCRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQABCDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ABCDXTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ABCDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQABCDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ABCDYTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ABCDYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQARQSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ARQSTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ARQSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQABDTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ABDTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ABDTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQABQCTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ABQCTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ABQCTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQAGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_AGGTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_AGGTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZQAGJTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_AGJTY%>"
                                    onblur="return CheckNext('a4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_AGJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a4',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b4" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('b4','b4');">退佣設定B盤</a></td>
                            <td>
                                <input type="text" name="N_ZQBRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BRFTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BDXTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BDYTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BDYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BDSTY %>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BDSTY %>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BZDRFTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BZDDXTY %>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BZDDXTY %>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBBCRFTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPZQ.N_BBCRFTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BBCRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBBCDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BBCDXTY %>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BBCDXTY %>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBBCDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BBCDYTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BBCDYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBRQSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BRQSTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BRQSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBBDTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BBDTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BBDTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBBQCTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BBQCTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BBQCTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BGGTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BGGTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZQBGJTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BGJTY%>"
                                    onblur="return CheckNext('b4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BGJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b4',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c4" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('c4','c4');">退佣設定C盤</a></td>
                            <td>
                                <input type="text" name="N_ZQCRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CRFTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CDXTY %>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CDXTY %>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCDYTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPZQ.N_CDYTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%= mo_KFB_SETUPZQ1.N_CDYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCDSTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPZQ.N_CDSTY %>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%= mo_KFB_SETUPZQ1.N_CDSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCZDRFTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPZQ.N_CZDRFTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCZDDXTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPZQ.N_CZDDXTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%= mo_KFB_SETUPZQ1.N_CZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCBCRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CBCRFTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CBCRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCBCDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CBCDXTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CBCDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCBCDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CBCDYTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CBCDYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCRQSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CRQSTY %>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CRQSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCBDTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CBDTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CBDTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCBQCTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPZQ.N_CBQCTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%= mo_KFB_SETUPZQ1.N_CBQCTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQCGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CGGTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CGGTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZQCGJTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_CGJTY%>"
                                    onblur="return CheckNext('c4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_CGJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c4',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="d4" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('d4','d4');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_ZQRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_RFDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_DXDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_DXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_DYDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_DSDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_DSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQZDRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ZDRFDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQZDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ZDDXDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBCRFDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPZQ.N_BCRFDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%= mo_KFB_SETUPZQ1.N_BCRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBCDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BCDXDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BCDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBCDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BCDYDZ %>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BCDYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQRQSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_RQSDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_RQSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBDDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BDDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BDDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBQCDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BQCDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BQCDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQGGDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_GGDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_GGDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZQGJDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_GJDZ%>"
                                    onblur="return CheckNext('d4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="d4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('d4',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="e4" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('e4','e4');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_ZQRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_RFDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_DXDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_DXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQDYDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPZQ.N_DYDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%= mo_KFB_SETUPZQ1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_DSDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_DSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQZDRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ZDRFDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQZDDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_ZDDXDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBCRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BCRFDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BCRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBCDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BCDXDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BCDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBCDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BCDYDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BCDYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQRQSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_RQSDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_RQSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBDDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BDDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BDDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQBQCDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_BQCDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_BQCDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZQGGDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_GGDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_GGDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZQGJDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZQ.N_GJDC%>"
                                    onblur="return CheckNext('e4',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="e4">
                                        &lt;=
                                        <%=mo_KFB_SETUPZQ1.N_GJDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('e4',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            美足設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                美足</td>
                            <td>
                                讓分</td>
                            <td>
                                大小</td>
                            <td>
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td>
                                滾球讓分</td>
                            <td>
                                滾球大小</td>
                            <td>
                                半場讓分</td>
                            <td>
                                半場大小</td>
                            <td>
                                半場獨贏</td>
                            <td>
                                半場單雙</td>
                            <td>
                                過關</td>
                            <td style="display: none;">
                                冠軍</td>
                            <td>
                                全部設為<br />
                                <span style="color: Red">(不含過關)</span></td>
                            <td rowspan="4" colspan="3">
                            </td>
                        </tr>
                        <tr class="trc" id="a5" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('a5','a5');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_MQRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_RFTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_RFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_DXTY %>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_DXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_DYTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_DSTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_DSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_ZDRFTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_ZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_ZDDXTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCRFTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDXTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDYTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDSTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_GGTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_GGTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_MQGJTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPMQ.N_GJTY%>"
                                    onblur="return CheckNext('a5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a5">
                                        &lt;=
                                        <%= mo_KFB_SETUPMQ1.N_GJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a5',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b5" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('b5','b5');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_MQRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_RFDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_DXDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_DXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_DYDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_DSDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_DSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQZDRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_ZDRFDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQZDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_ZDDXDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCRFDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDXDZ %>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDYDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDSDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQGGDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_GGDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_GGDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_MQGJDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPMQ.N_GJDZ%>"
                                    onblur="return CheckNext('b5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b5">
                                        &lt;=
                                        <%= mo_KFB_SETUPMQ1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b5',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c5" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('c5','c5');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_MQRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_RFDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_DXDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_DXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDYDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPMQ.N_DYDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%= mo_KFB_SETUPMQ1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_DSDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_DSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQZDRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_ZDRFDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQZDDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_ZDDXDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCRFDC %>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDXDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDYDC %>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQBCDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_BCDSDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_BCDSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_MQGGDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPMQ.N_GGDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_GGDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_MQGJDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPMQ.N_GJDC%>"
                                    onblur="return CheckNext('c5',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c5">
                                        &lt;=
                                        <%=mo_KFB_SETUPMQ1.N_GGDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c5',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            冰球設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                冰球</td>
                            <td>
                                讓分</td>
                            <td>
                                大小</td>
                            <td>
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td>
                                滾球讓分</td>
                            <td>
                                滾球大小</td>
                            <td>
                                一輸二贏</td>
                            <td>
                                過關</td>
                            <td>
                                半場讓分大小</td>
                            <td>
                                全部設為<br />
                                <span style="color: Red">(不含過關)</span></td>
                            <td rowspan="4" colspan="5">
                            </td>
                        </tr>
                        <tr class="trc" id="a14" >
                            <td class="pk">
                                <a  onclick="return showinput('a14','a14');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_BQRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_RFTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_RFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DXTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DYTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DSTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_ZDRFTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_ZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_ZDDXTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQSYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_SYTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_SYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_GGTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_GGTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQGJTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_GJTY%>"
                                    onblur="return CheckNext('a14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_GJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a14',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b14" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('b14','b14');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_BQRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_RFDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DXDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DYDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DSDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQZDRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_ZDRFDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQZDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_ZDDXDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQSYDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPBQ.N_SYDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_SYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQGGDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPBQ.N_GGDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_GGDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQGJDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_GJDZ%>"
                                    onblur="return CheckNext('b14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b14',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c14" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('c14','c14');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_BQRFDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPBQ.N_RFDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DXDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DYDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_DSDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_DSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQZDRFDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPBQ.N_ZDRFDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQZDDXDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPBQ.N_ZDDXDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQSYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_SYDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_SYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQGGDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPBQ.N_GGDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_GGDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_BQGJDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPBQ.N_GJDC%>"
                                    onblur="return CheckNext('c14',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c14">
                                        &lt;=
                                        <%=mo_KFB_SETUPBQ1.N_GJDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c14',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                      
                                        <td class="trc">
                                            彩球設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                彩球</td>
                            <td>
                                讓分</td>
                            <td>
                                大小</td>
                            <td>
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td>
                                滾球讓分</td>
                            <td>
                                滾球大小</td>
                            <td>
                                半場讓分</td>
                            <td>
                                半場大小</td>
                            <td>
                                半場獨贏</td>
                            <td>
                                半場單雙</td>
                            <td>
                                過關</td>
                            <td style="display: none;">
                                冠軍</td>
                            <td>
                                全部設為<br />
                                <span style="color: Red">(不含過關)</span></td>
                            <td rowspan="4" colspan="3">
                            </td>
                        </tr>
                        <tr class="trc" id="a15" >
                            <td class="pk">
                                <a  onclick="return showinput('a15','a15');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_CQRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_RFTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_RFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_DXTY %>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_DXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_DYTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_DSTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_DSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_ZDRFTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_ZDRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_ZDDXTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCRFTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCRFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDXTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDYTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDSTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_GGTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_GGTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_CQGJTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPCQ.N_GJTY%>"
                                    onblur="return CheckNext('a15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a15">
                                        &lt;=
                                        <%= mo_KFB_SETUPCQ1.N_GJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a15',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b15" >
                            <td class="pk">
                                <a  onclick="return showinput('b15','b15');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_CQRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_RFDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_DXDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_DXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_DYDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_DSDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_DSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQZDRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_ZDRFDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQZDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_ZDDXDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCRFDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDXDZ %>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDYDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDSDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQGGDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_GGDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_GGDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_CQGJDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPCQ.N_GJDZ%>"
                                    onblur="return CheckNext('b15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b15">
                                        &lt;=
                                        <%= mo_KFB_SETUPCQ1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b15',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c15" >
                            <td class="pk">
                                <a  onclick="return showinput('c15','c15');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_CQRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_RFDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_DXDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_DXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDYDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPCQ.N_DYDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%= mo_KFB_SETUPCQ1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_DSDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_DSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQZDRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_ZDRFDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQZDDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_ZDDXDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCRFDC %>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCRFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDXDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDYDC %>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQBCDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_BCDSDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_BCDSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CQGGDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCQ.N_GGDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_GGDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_CQGJDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPCQ.N_GJDC%>"
                                    onblur="return CheckNext('c15',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c15">
                                        &lt;=
                                        <%=mo_KFB_SETUPCQ1.N_GGDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c15',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                      
                                        <td class="trc">
                                            指數設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                指數</td>
                            <td style="display: none;">
                                讓分</td>
                            <td>
                                大小</td>
                            <td style="display: none;">
                                獨贏</td>
                            <td>
                                單雙</td>
                            <td style="display: none;">
                                滾球讓分</td>
                            <td style="display: none;">
                                滾球大小</td>
                            <td style="display: none;">
                                一輸二贏</td>
                            <td style="display: none;">
                                波膽</td>
                            <td style="display: none;">
                                過關</td>
                            <td style="display: none;">
                                冠軍</td>
                            <td>
                                全部設為</td>
                            <td rowspan="4" colspan="12">
                            </td>
                        </tr>
                        <tr class="trc" id="a7" >
                            <td class="pk">
                                <a  onclick="return showinput('a7','a7');">退佣設定</a></td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSRFTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPZS.N_RFTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%= mo_KFB_SETUPZS1.N_RFTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZSDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DXTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DXTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DYTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZSDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DSTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DSTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSZDRFTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_ZDRFTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_ZDRFTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSZDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_ZDDXTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_ZDDXTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSSYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_SYTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_SYTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSBDTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_BDTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_BDTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSGGTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_GGTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_GGTY%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSGJTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_GJTY%>"
                                    onblur="return CheckNext('a7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_GJTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a7',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b7" >
                            <td class="pk">
                                <a  onclick="return showinput('b7','b7');">單注上限（萬）</a></td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSRFDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_RFDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_RFDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZSDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DXDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DXDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DYDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZSDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DSDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DSDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSZDRFDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPZS.N_ZDRFDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%= mo_KFB_SETUPZS1.N_ZDRFDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSZDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_ZDDXDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_ZDDXDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSSYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_SYDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_SYDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSBDDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_BDDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_BDDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSGGDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_GGDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_GGDZ%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSGJDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_GJDZ%>"
                                    onblur="return CheckNext('b7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_GJDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b7',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c7" >
                            <td class="trc" class="pk">
                                <a  onclick="return showinput('c7','c7');">單場上限（萬）</a></td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_RFDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_RFDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZSDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DXDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DXDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DYDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_ZSDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_DSDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_DSDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSZDRFDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_ZDRFDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_ZDRFDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSZDDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_ZDDXDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_ZDDXDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSSYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_SYDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_SYDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSBDDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_BDDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_BDDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSGGDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_GGDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_GGDC%>
                                    </div>
                            </td>
                            <td style="display: none;">
                                <input type="text" name="N_ZSGJDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPZS.N_GJDC%>"
                                    onblur="return CheckNext('c7',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c7">
                                        &lt;=
                                        <%=mo_KFB_SETUPZS1.N_GJDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c7',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            賽馬設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                賽馬</td>
                            <td>
                                獨贏</td>
                            <td>
                                位置</td>
                            <td>
                                連贏</td>
                            <td>
                                位置Q</td>
                            <td>
                                全部設為</td>
                            <td rowspan="4" colspan="10">
                            </td>
                        </tr>
                        <tr class="trc" id="a10" >
                            <td class="pk">
                                <a  onclick="return showinput('a10','a10');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_SMDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_DYTY%>"
                                    onblur="return CheckNext('a10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMWZTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_WZTY%>"
                                    onblur="return CheckNext('a10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_WZTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMLYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_LYTY%>"
                                    onblur="return CheckNext('a10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_LYTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMWZQTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_WZQTY%>"
                                    onblur="return CheckNext('a10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_WZQTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a10',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b10" >
                            <td class="pk">
                                <a  onclick="return showinput('b10','b10');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_SMDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_DYDZ%>"
                                    onblur="return CheckNext('b10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMWZDZ" maxlength="7" size="4" value="<%= mo_KFB_SETUPSM.N_WZDZ%>"
                                    onblur="return CheckNext('b10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_WZDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMLYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_LYDZ%>"
                                    onblur="return CheckNext('b10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_LYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMWZQDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_WZQDZ%>"
                                    onblur="return CheckNext('b10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_WZQDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b10',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c10" >
                            <td class="pk">
                                <a  onclick="return showinput('c10','c10');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_SMDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_DYDC%>"
                                    onblur="return CheckNext('c10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMWZDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_WZDC%>"
                                    onblur="return CheckNext('c10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_WZDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMLYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_LYDC%>"
                                    onblur="return CheckNext('c10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_LYDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_SMWZQDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPSM.N_WZQDC%>"
                                    onblur="return CheckNext('c10',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c10">
                                        &lt;=
                                        <%=mo_KFB_SETUPSM1.N_WZQDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c10',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                        <td class="trc">
                                            六合彩設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                六合彩</td>
                            <td>
                                特別號</td>
                            <td>
                                台特</td>
                            <td>
                                台號</td>
                            <td>
                                全車碰</td>
                            <td>
                                2星</td>
                            <td>
                                3星</td>
                            <td>
                                4星</td>
                            <td>
                                固定單雙</td>
                            <td>
                                固定大小</td>
                            <td>
                                全部設為</td>
                            <td rowspan="4" colspan="5">
                            </td>
                        </tr>
                        <tr class="trc" id="a11" >
                            <td class="pk">
                                <a  onclick="return showinput('a11','a11');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_LHCTBHTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_TBHTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_TBHTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCTTTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_TTTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_TTTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCTHTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_THTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_THTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCQCPTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_QCPTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_QCPTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC2XTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_2XTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_2XTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC3XTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_3XTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_3XTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC4XTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_4XTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_4XTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCGDDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_GDDSTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_GDDSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCGDDXTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPLHC.N_GDDXTY%>"
                                    onblur="return CheckNext('a11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_GDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a11',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b11" >
                            <td class="pk">
                                <a  onclick="return showinput('b11','b11');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_LHCTBHDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_TBHDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_TBHDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCTTDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_TTDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_TTDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCTHDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_THDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_THDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCQCPDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_QCPDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_QCPDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC2XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_2XDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_2XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC3XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_3XDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_3XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC4XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_4XDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_4XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCGDDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_GDDSDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_GDDSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCGDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_GDDXDZ%>"
                                    onblur="return CheckNext('b11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_GDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b11',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c11" >
                            <td class="pk">
                                <a  onclick="return showinput('c11','c11');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_LHCTBHDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_TBHDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_TBHDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCTTDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_TTDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_TTDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCTHDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_THDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_THDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCQCPDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_QCPDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_QCPDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC2XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_2XDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_2XDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC3XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_3XDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_3XDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHC4XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_4XDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_4XDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCGDDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_GDDSDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_GDDSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_LHCGDDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPLHC.N_GDDXDC%>"
                                    onblur="return CheckNext('c11',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c11">
                                        &lt;=
                                        <%=mo_KFB_SETUPLHC1.N_GDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c11',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                        <td class="trc">
                                            大樂透設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                大樂透</td>
                            <td>
                                特別號</td>
                            <td>
                                台特</td>
                            <td>
                                台號</td>
                            <td>
                                全車碰</td>
                            <td>
                                2星</td>
                            <td>
                                3星</td>
                            <td>
                                4星</td>
                            <td>
                                固定單雙</td>
                            <td>
                                固定大小</td>
                            <td>
                                全部設為</td>
                            <td rowspan="4" colspan="5">
                            </td>
                        </tr>
                        <tr class="trc" id="a8" >
                            <td class="pk">
                                <a  onclick="return showinput('a8','a8');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_DLTTBHTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_TBHTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_TBHTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTTTTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_TTTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_TTTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTTHTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_THTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_THTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTQCPTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_QCPTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_QCPTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT2XTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_2XTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_2XTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT3XTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_3XTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_3XTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT4XTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_4XTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_4XTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTGDDSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_GDDSTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_GDDSTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTGDDXTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_GDDXTY%>"
                                    onblur="return CheckNext('a8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_GDDXTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a8',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b8" >
                            <td class="pk">
                                <a  onclick="return showinput('b8','b8');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_DLTTBHDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_TBHDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_TBHDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTTTDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_TTDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_TTDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTTHDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_THDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_THDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTQCPDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_QCPDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_QCPDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT2XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_2XDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_2XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT3XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_3XDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_3XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT4XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_4XDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_4XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTGDDSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_GDDSDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_GDDSDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTGDDXDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_GDDXDZ%>"
                                    onblur="return CheckNext('b8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_GDDXDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b8',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c8" >
                            <td class="pk">
                                <a  onclick="return showinput('c8','c8');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_DLTTBHDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPDLT.N_TBHDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_TBHDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTTTDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_TTDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_TTDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTTHDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_THDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_THDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTQCPDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_QCPDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_QCPDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT2XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_2XDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_2XDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT3XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_3XDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_3XDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLT4XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_4XDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_4XDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTGDDSDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_GDDSDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_GDDSDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_DLTGDDXDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPDLT.N_GDDXDC%>"
                                    onblur="return CheckNext('c8',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c8">
                                        &lt;=
                                        <%=mo_KFB_SETUPDLT1.N_GDDXDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c8',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            今彩設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                今彩</td>
                            <td>
                                全車碰</td>
                            <td>
                                2星</td>
                            <td>
                                3星</td>
                            <td>
                                4星</td>
                            <td>
                                全部設為</td>
                            <td rowspan="4" colspan="10">
                            </td>
                        </tr>
                        <tr class="trc" id="a12" >
                            <td class="pk">
                                <a  onclick="return showinput('a12','a12');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_JCQCPTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_QCPTY%>"
                                    onblur="return CheckNext('a12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_QCPTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC2XTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_2XTY%>"
                                    onblur="return CheckNext('a12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_2XTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC3XTY" maxlength="7" size="4" value="<%= mo_KFB_SETUPJC539.N_3XTY%>"
                                    onblur="return CheckNext('a12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_3XTY%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC4XTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_4XTY%>"
                                    onblur="return CheckNext('a12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_4XTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a12',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b12" >
                            <td class="pk">
                                <a  onclick="return showinput('b12','b12');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_JCQCPDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_QCPDZ%>"
                                    onblur="return CheckNext('b12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_QCPDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC2XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_2XDZ%>"
                                    onblur="return CheckNext('b12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_2XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC3XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_3XDZ%>"
                                    onblur="return CheckNext('b12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_3XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC4XDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_4XDZ%>"
                                    onblur="return CheckNext('b12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_4XDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b12',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c12" >
                            <td class="pk">
                                <a  onclick="return showinput('c12','c12');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_JCQCPDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_QCPDC%>"
                                    onblur="return CheckNext('c12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_QCPDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC2XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_2XDC%>"
                                    onblur="return CheckNext('c12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_2XDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC3XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_3XDC%>"
                                    onblur="return CheckNext('c12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_3XDC%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_JC4XDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPJC539.N_4XDC%>"
                                    onblur="return CheckNext('c12',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c12">
                                        &lt;=
                                        <%=mo_KFB_SETUPJC5391.N_4XDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c12',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            運彩設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                運彩</td>
                            <td>
                                棒球彩票</td>
                            <td>
                                籃球彩票</td>
                            <td>
                                足球彩票</td>
                            <td style="display: none">
                                股市彩票</td>
                            <td style="display: none">
                                期指彩票</td>
                            <td>
                                全部設為</td>
                            <td colspan="11" rowspan="2">
                            </td>
                        </tr>
                        <tr class="trc" id="b9" >
                            <td class="pk">
                                <a  onclick="return showinput('b9','b9');">注数上限（注）</a></td>
                            <td>
                                <input type="text" name="N_CPBQDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_BQDZ%>"
                                    onblur="CheckZS(this);return CheckNext('b9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_BQDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CPLQDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_LQDZ%>"
                                    onblur="CheckZS(this);return CheckNext('b9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_LQDZ%>
                                    </div>
                            </td>
                            <td>
                                <input type="text" name="N_CPZQDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_ZQDZ%>"
                                    onblur="CheckZS(this);return CheckNext('b9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_ZQDZ%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPGSDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_GSDZ%>"
                                    onblur="return CheckNext('b9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_GSDZ%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPQZDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_QZDZ%>"
                                    onblur="return CheckNext('b9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_QZDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="CheckZS(this);return setVale('b9',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr id="c9" style="display: none" >
                            <td class="pk" style="display: none">
                                <a  onclick="return showinput('c9','c9');">單場上限（萬）</a></td>
                            <td style="display: none">
                                <input type="text" name="N_CPBQDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_BQDC%>"
                                    onblur="return CheckNext('c9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_BQDC%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPLQDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_LQDC%>"
                                    onblur="return CheckNext('c9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_LQDC%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPZQDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_ZQDC%>"
                                    onblur="return CheckNext('c9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_ZQDC%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPGSDC" maxlength="7" size="4" value="<%= mo_KFB_SETUPCP.N_GSDC%>"
                                    onblur="return CheckNext('c9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_GSDC%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPQZDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_QZDC%>"
                                    onblur="return CheckNext('c9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_QZDC%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input value="" maxlength="7" size="4" onblur="return setVale('c9',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="a9"  style="display: none">
                            <td class="pk" style="display: none">
                                <a  onclick="return showinput('a9','a9');">退佣設定</a></td>
                            <td style="display: none">
                                <input type="text" name="N_CPBQTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_BQTY%>"
                                    onblur="return CheckNext('a9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_BQTY%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPLQTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_LQTY%>"
                                    onblur="return CheckNext('a9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_LQTY%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPZQTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_ZQTY%>"
                                    onblur="return CheckNext('a9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_ZQTY%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPGSTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_GSTY%>"
                                    onblur="return CheckNext('a9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_GSTY%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input type="text" name="N_CPQZTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPCP.N_QZTY%>"
                                    onblur="return CheckNext('a9',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a9">
                                        &lt;=
                                        <%=mo_KFB_SETUPCP1.N_QZTY%>
                                    </div>
                            </td>
                            <td style="display: none">
                                <input value="" maxlength="7" size="4" onblur="return setVale('a9',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr >
                            <td colspan="16">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="trc">
                                            時事設定</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="trc" >
                            <td>
                                時事</td>
                            <td>
                                獨贏</td>
                            <td>
                                全部設為</td>
                            <td colspan="13" rowspan="4">
                            </td>
                        </tr>
                        <tr class="trc" id="a13" >
                            <td class="pk">
                                <a  onclick="return showinput('a13','a13');">退佣設定</a></td>
                            <td>
                                <input type="text" name="N_SSDYTY" maxlength="7" size="4" value="<%=mo_KFB_SETUPSS.N_DYTY%>"
                                    onblur="return CheckNext('a13',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="a13">
                                        &lt;=
                                        <%=mo_KFB_SETUPSS1.N_DYTY%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('a13',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="b13" >
                            <td class="pk">
                                <a  onclick="return showinput('b13','b13');">單注上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_SSDYDZ" maxlength="7" size="4" value="<%=mo_KFB_SETUPSS.N_DYDZ%>"
                                    onblur="return CheckNext('b13',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="b13">
                                        &lt;=
                                        <%=mo_KFB_SETUPSS1.N_DYDZ%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('b13',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                        <tr class="trc" id="c13" >
                            <td class="pk">
                                <a  onclick="return showinput('c13','c13');">單場上限（萬）</a></td>
                            <td>
                                <input type="text" name="N_SSDYDC" maxlength="7" size="4" value="<%=mo_KFB_SETUPSS.N_DYDC%>"
                                    onblur="return CheckNext('c13',this.value,event.srcElement);" class="hiddeninput"
                                    readonly="readonly" /><div style="display: none" name="c13">
                                        &lt;=
                                        <%=mo_KFB_SETUPSS1.N_DYDC%>
                                    </div>
                            </td>
                            <td>
                                <input value="" maxlength="7" size="4" onblur="return setVale('c13',this.value,event.srcElement);"
                                    class="hiddeninput" readonly="readonly" /></td>
                        </tr>
                       
                    </table>
                    <br />
                    說明：<br />
                    如果 "退佣" 為100, 表示每下注一萬元可以得到退佣100元.
                </td>
                <td class="t6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="t7">
                    &nbsp;</td>
                <td class="t8">
                </td>
                <td class="t9">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
