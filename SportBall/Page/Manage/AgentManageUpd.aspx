<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="AgentManageUpd.aspx.cs" Inherits="AgentManageUpd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            border: 1px solid #96d0e5;
            vertical-align: middle;
            height: 29px;
        }

        .auto-style2 {
            height: 29px;
        }
    </style>
    <script src="AgentManageAdd.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <asp:HiddenField ID="hidvalue" runat="server" Value="123" />
    <asp:HiddenField ID="hidje" runat="server" />
    <asp:HiddenField ID="hidxy" runat="server" />
    <asp:HiddenField ID="hiddelxj" runat="server" />

    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">会员管理</a>  <span
            class="divider">/</span>
        <asp:Label ID="lbtitle" runat="server" Text="" /><asp:HyperLink ID="hlchangeboss" runat="server" Text="更改" ForeColor="blue" />
    </ul>
    <div class="title_right" runat="server" id="trbj">
        <strong>

            <asp:Label ID="lbtitle1" runat="server" Text="" /></strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table style="width: 100%" class="table">
            <tr>
                <td colspan="4">
                    <asp:Button ID="bttjzj" runat="server" Text="添加總監" OnClick="bttjzj_Click" CssClass="button" />
                    <asp:Button ID="btdel" runat="server" Text="删除" OnClick="btdel_Click" OnClientClick="return CheckDelXJ();" CssClass="button" />
                    <asp:Button ID="btfh" runat="server" Text="返回" OnClick="btfh_Click" CssClass="button" />
                </td>
            </tr>
            <tr onmouseover="changeto()" onmouseout="changeback()">
                <td class="trr">
                    <font color="red">*</font>
                    <asp:Label ID="lbzh" runat="server" Text="" />

                </td>
                <td id="accounts01">
                    <asp:Label ID="lbzj" runat="server" Text=""></asp:Label></td>
                <td class="trr">
                    <font color="red">*</font><span class="FormLabel">
                        <asp:Label ID="lbzhmc" runat="server"
                            Text=""></asp:Label>
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="txtzjmc" runat="server"></asp:TextBox></td>
            </tr>
            <tr onmouseover="changeto()" onmouseout="changeback()">
                <td class="trr">
                    <font color="red">*</font>密碼：</td>
                <td>
                    <asp:TextBox ID="txtmm" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox></td>
                <td class="trr">
                    <font color="red">*</font>密碼確認：</td>
                <td>
                    <asp:TextBox ID="txtzrmm" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox><span style="color: Red">(密碼長度不能大於20位)</span>
                    <asp:Label ID="lbps" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr onmouseover="changeto()" onmouseout="changeback()">
                <td class="trr">
                    <font color="red">*</font>信用額度：</td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtxyed" runat="server" MaxLength="9"></asp:TextBox>（萬）
                </td>
                <td class="trr">
                    <font color="red">*</font>剩餘額度：</td>
                <td>
                    <asp:Label ReadOnly="true" ID="txtsyed" runat="server"></asp:Label>（萬）
                </td>
            </tr>
            <tr onmouseover="changeto()" onmouseout="changeback()">
                <td class="trr">
                    <font color="red">*</font>是否延遲下注：</td>
                <td>
                    <asp:RadioButtonList ID="Rdycxz" runat="server" CssClass="hei" RepeatDirection="Horizontal" Width="95px">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td class="hei" class="trr">
                    <font color="red">*</font>是否允許登入：</td>
                <td>
                    <asp:RadioButtonList ID="Rdyxdl" runat="server" CssClass="hei" RepeatDirection="Horizontal" Width="95px">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr onmouseover="changeto()" onmouseout="changeback()">
                <td class="trr">單隊上限：</td>
                <td>
                    <asp:TextBox ID="txtddsx" runat="server"></asp:TextBox>（萬）
                </td>
                <td class="trr">
                    <font color="red">*</font>是否允許下注：</td>
                <td>
                    <asp:RadioButtonList ID="Rdyxxz" runat="server" CssClass="hei" RepeatDirection="Horizontal" Width="95px">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="trXiazhuNum" runat="server" onmouseover="changeto()" onmouseout="changeback()">
                <td id="tdlbXiazhuNum" runat="server" class="trr">
                    <font color="red">*</font>過關下注關數限制：</td>
                <td id="tddrpXiazhuNum" colspan="3" runat="server">
                    <asp:DropDownList ID="drpXiazhuNum" runat="server">
                        <asp:ListItem Value="0" Selected="True">不限制</asp:ListItem>
                        <asp:ListItem Value="1">1關</asp:ListItem>
                        <asp:ListItem Value="2">2關</asp:ListItem>
                        <asp:ListItem Value="3">3關</asp:ListItem>
                        <asp:ListItem Value="4">4關</asp:ListItem>
                        <asp:ListItem Value="5">5關</asp:ListItem>
                        <asp:ListItem Value="6">6關</asp:ListItem>
                        <asp:ListItem Value="7">7關</asp:ListItem>
                        <asp:ListItem Value="8">8關</asp:ListItem>
                        <asp:ListItem Value="9">9關</asp:ListItem>
                        <asp:ListItem Value="10">10關</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr onmouseover="changeto()" onmouseout="changeback()" style="display: none">
                <td class="trr">
                    <font color="red">*</font>
                    <asp:HyperLink ID="hycz" onclick=" return AllDisable('cz');" NavigateUrl="#" runat="server"><font color="#5F5F5F">拆帳百分比：</font></asp:HyperLink>
                </td>
                <td colspan="3">
                    <table class="table">
                        <tr>
                            <td>籃球%<br />
                                <asp:TextBox name="txtcz" ID="txtczlq" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczlq">
                                    &lt;=<asp:Label ID="lbczlq" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczlqt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>棒球%<br />
                                <asp:TextBox name="txtcz" ID="txtczmb" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczmb">
                                    &lt;=<asp:Label ID="lbczmb" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczmbt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>网球%<br />
                                <asp:TextBox name="txtcz" ID="txtczrb" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczrb">
                                    &lt;=<asp:Label ID="lbczrb" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczrbt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>排球%<br />
                                <asp:TextBox name="txtcz" ID="txtcztb" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divcztb">
                                    &lt;=<asp:Label ID="lbcztb" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbcztbt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>足球%<br />
                                <asp:TextBox name="txtcz" ID="txtczzq" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczzq">
                                    &lt;=<asp:Label ID="lbczzq" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczzqt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>美足%<br />
                                <asp:TextBox name="txtcz" ID="txtczmz" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczmz">
                                    &lt;=<asp:Label ID="lbczmz" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczmzt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>冰球%<br />
                                <asp:TextBox name="txtcz" ID="txtczbq" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczbq">
                                    &lt;=<asp:Label ID="lbczbq" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczbqt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>彩球%<br />
                                <asp:TextBox name="txtcz" ID="txtczcq" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczcq">
                                    &lt;=<asp:Label ID="lbczcq" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczcqt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>指數%<br />
                                <asp:TextBox name="txtcz" ID="txtczzs" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczzs">
                                    &lt;=<asp:Label ID="lbczzs" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczzst" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td style="display: none;">大樂透%<br />
                                <asp:TextBox name="txtcz" ID="txtczdlt" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczdlt">
                                    &lt;=<asp:Label ID="lbczdlt" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczdltt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>運彩%<br />
                                <asp:TextBox name="txtcz" ID="txtczcp" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczcp">
                                    &lt;=<asp:Label ID="lbczcp" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczcpt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>賽馬%<br />
                                <asp:TextBox name="txtcz" ID="txtczsm" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczsm">
                                    &lt;=<asp:Label ID="lbczsm" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczsmt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td style="display: none;">六合彩%<br />
                                <asp:TextBox name="txtcz" ID="txtczlhc" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczlhc">
                                    &lt;=<asp:Label ID="lbczlhc" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczlhct" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td style="display: none;">二星%<br />
                                <asp:TextBox name="txtcz" ID="txtcz2x" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divcz2x">
                                    &lt;=<asp:Label ID="lbcz2x" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbcz2xt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td style="display: none;">三星%<br />
                                <asp:TextBox name="txtcz" ID="txtcz3x" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divcz3x">
                                    &lt;=<asp:Label ID="lbcz3x" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbcz3xt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td style="display: none;">四星%<br />
                                <asp:TextBox name="txtcz" ID="txtcz4x" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divcz4x">
                                    &lt;=<asp:Label ID="lbcz4x" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbcz4xt" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td style="display: none;">今彩%<br />
                                <asp:TextBox name="txtcz" ID="txtczjc539" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczjc">
                                    &lt;=<asp:Label ID="lbczjc539" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczjc539t" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>時事%<br />
                                <asp:TextBox name="txtcz" ID="txtczss" Style="width: 40px" runat="server"></asp:TextBox>
                                <div name="divcz" id="divczss">
                                    &lt;=<asp:Label ID="lbczss" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbczsst" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

        </table>
        <br />
        <table  class="table" style=" width: 100%;display: none">
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">籃球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>籃球</td>
                <td>讓分</td>
                <td>大小</td>
                <td>獨贏</td>
                <td>單雙</td>
                <td>滾球讓分</td>
                <td>滾球大小</td>
                <td>半場讓分</td>
                <td>半場大小</td>
                <td>半場獨贏</td>
                <td>半場單雙</td>
                <td>單節讓分</td>
                <td>單節大小</td>
                <td>單節單雙</td>
                <td>過關</td>
                <td style="display: none;">冠軍</td>
                <td>全部設為<br />
                    <span style="color: Red">(不含過關)</span></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" onclick=" return AllDisable('lqty');" NavigateUrl="#"
                        runat="server">退佣設定</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtyrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtyrf">
                        &lt;=<asp:Label ID="lblqtyrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtyrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtydx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtydx">
                        &lt;=<asp:Label ID="lblqtydx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtydxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtydy">
                        &lt;=<asp:Label ID="lblqtydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtyds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtyds">
                        &lt;=<asp:Label ID="lblqtyds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtydst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtyzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtyzdrf">
                        &lt;=<asp:Label ID="lblqtyzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtyzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtyzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtyzddx">
                        &lt;=<asp:Label ID="lblqtyzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtyzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtybcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtybcrf">
                        &lt;=<asp:Label ID="lblqtybcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtybcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtybcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtybcdx">
                        &lt;=<asp:Label ID="lblqtybcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtybcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtybcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtybcdy">
                        &lt;=<asp:Label ID="lblqtybcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtybcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtybcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtybcds">
                        &lt;=<asp:Label ID="lblqtybcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtybcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtydjrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtydjrf">
                        &lt;=<asp:Label ID="lblqtydjrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtydjrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtydjdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtydjdx">
                        &lt;=<asp:Label ID="lblqtydjdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtydjdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtydjds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtydjds">
                        &lt;=<asp:Label ID="lblqtydjds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtydjdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtygg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtygg">
                        &lt;=<asp:Label ID="lblqtygg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtyggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtygj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqtygj">
                        &lt;=<asp:Label ID="lblqtygj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqtygjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqtyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink2" onclick="return AllDisable('lqdz');" NavigateUrl="#"
                        runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzrf">
                        &lt;=<asp:Label ID="lblqdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzdx">
                        &lt;=<asp:Label ID="lblqdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzdy">
                        &lt;=<asp:Label ID="lblqdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzds">
                        &lt;=<asp:Label ID="lblqdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzzdrf">
                        &lt;=<asp:Label ID="lblqdzzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzzddx">
                        &lt;=<asp:Label ID="lblqdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzbcrf">
                        &lt;=<asp:Label ID="lblqdzbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzbcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzbcdx">
                        &lt;=<asp:Label ID="lblqdzbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzbcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzbcdy">
                        &lt;=<asp:Label ID="lblqdzbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzbcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzbcds">
                        &lt;=<asp:Label ID="lblqdzbcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzbcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzdjrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzdjrf">
                        &lt;=<asp:Label ID="lblqdzdjrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzdjrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzdjdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzdjdx">
                        &lt;=<asp:Label ID="lblqdzdjdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzdjdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzdjds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzdjds">
                        &lt;=<asp:Label ID="lblqdzdjds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzdjdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzgg">
                        &lt;=<asp:Label ID="lblqdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdzgj">
                        &lt;=<asp:Label ID="lblqdzgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdzgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink3" onclick="return AllDisable('lqdc');" NavigateUrl="#"
                        runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcrf">
                        &lt;=<asp:Label ID="lblqdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcdx">
                        &lt;=<asp:Label ID="lblqdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcdy">
                        &lt;=<asp:Label ID="lblqdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcds">
                        &lt;=<asp:Label ID="lblqdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdczdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdczdrf">
                        &lt;=<asp:Label ID="lblqdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdczddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdczddx">
                        &lt;=<asp:Label ID="lblqdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcbcrf">
                        &lt;=<asp:Label ID="lblqdcbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcbcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcbcdx">
                        &lt;=<asp:Label ID="lblqdcbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcbcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcbcdy">
                        &lt;=<asp:Label ID="lblqdcbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcbcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcbcds">
                        &lt;=<asp:Label ID="lblqdcbcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcbcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcdjrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcdjrf">
                        &lt;=<asp:Label ID="lblqdcdjrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcdjrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcdjdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcdjdx">
                        &lt;=<asp:Label ID="lblqdcdjdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcdjdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcdjds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcdjds">
                        &lt;=<asp:Label ID="lblqdcdjds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcdjdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcgg">
                        &lt;=<asp:Label ID="lblqdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdcgj">
                        &lt;=<asp:Label ID="lblqdcgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdcgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink4" onclick="return AllDisable('lqdd');" NavigateUrl="#"
                        runat="server">單隊上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddrf">
                        &lt;=<asp:Label ID="lblqddrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqddrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdddx">
                        &lt;=<asp:Label ID="lblqdddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdddy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdddy">
                        &lt;=<asp:Label ID="lblqdddy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdddyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddds">
                        &lt;=<asp:Label ID="lblqddds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdddst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddzdrf">
                        &lt;=<asp:Label ID="lblqddzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqddzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddzddx">
                        &lt;=<asp:Label ID="lblqddzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqddzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddbcrf">
                        &lt;=<asp:Label ID="lblqddbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqddbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddbcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddbcdx">
                        &lt;=<asp:Label ID="lblqddbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqddbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddbcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddbcdy">
                        &lt;=<asp:Label ID="lblqddbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqddbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddbcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddbcds">
                        &lt;=<asp:Label ID="lblqddbcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqddbcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdddjrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdddjrf">
                        &lt;=<asp:Label ID="lblqdddjrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdddjrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdddjdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdddjdx">
                        &lt;=<asp:Label ID="lblqdddjdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdddjdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqdddjds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqdddjds">
                        &lt;=<asp:Label ID="lblqdddjds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqdddjdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <div style="display: none;">
                        <asp:TextBox CssClass="hiddeninput" ID="txtlqddgg" Style="width: 50px;" runat="server"></asp:TextBox>
                        <div id="divlqddgg">
                            &lt;=<asp:Label ID="lblqddgg" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:Label ID="lblqddggt" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlqddgj">
                        &lt;=<asp:Label ID="lblqddgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblqddgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtlqddALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">棒球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>棒球</td>
                <td>讓分</td>
                <td>大小</td>
                <td>獨贏</td>
                <td>單雙</td>
                <td>滾球讓分</td>
                <td>滾球大小</td>
                <td>一輸二贏</td>
                <td>過關</td>
                <td>半場讓分大小</td>
                <td>全部設為<span style="color: Red"><br />
                    (不含過關)</span></td>
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink11" onclick="return AllDisable('mbty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtyrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtyrf">
                        &lt;=<asp:Label ID="lbmbtyrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtyrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtydx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtydx">
                        &lt;=<asp:Label ID="lbmbtydx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtydxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtydy">
                        &lt;=<asp:Label ID="lbmbtydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtyds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtyds">
                        &lt;=<asp:Label ID="lbmbtyds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtydst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtyzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtyzdrf">
                        &lt;=<asp:Label ID="lbmbtyzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtyzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtyzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtyzddx">
                        &lt;=<asp:Label ID="lbmbtyzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtyzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtysy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtysy">
                        &lt;=<asp:Label ID="lbmbtysy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtysyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtygg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtygg">
                        &lt;=<asp:Label ID="lbmbtygg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtyggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtybcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbtybcrf">
                        &lt;=<asp:Label ID="lbmbtybcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbtybcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbtyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink22" onclick="return AllDisable('mbdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzrf">
                        &lt;=<asp:Label ID="lbmbdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzdx">
                        &lt;=<asp:Label ID="lbmbdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzdy">
                        &lt;=<asp:Label ID="lbmbdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzds">
                        &lt;=<asp:Label ID="lbmbdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzzdrf">
                        &lt;=<asp:Label ID="lbmbdzzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzzddx">
                        &lt;=<asp:Label ID="lbmbdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzsy">
                        &lt;=<asp:Label ID="lbmbdzsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzgg">
                        &lt;=<asp:Label ID="lbmbdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdzbcrf">
                        &lt;=<asp:Label ID="lbmbdzbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdzbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink33" onclick="return AllDisable('mbdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdcrf">
                        &lt;=<asp:Label ID="lbmbdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdcdx">
                        &lt;=<asp:Label ID="lbmbdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdcdxt" runat="server" Text=""> </asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdcdy">
                        &lt;=<asp:Label ID="lbmbdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdcds">
                        &lt;=<asp:Label ID="lbmbdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdczdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdczdrf">
                        &lt;=<asp:Label ID="lbmbdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdczddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdczddx">
                        &lt;=<asp:Label ID="lbmbdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdcsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdcsy">
                        &lt;=<asp:Label ID="lbmbdcsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdcsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdcgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdcgg">
                        &lt;=<asp:Label ID="lbmbdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdcbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmbdcbcrf">
                        &lt;=<asp:Label ID="lbmbdcbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmbdcbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmbdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">网球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>网球</td>
                <td>讓分</td>
                <td>大小</td>
                <td>獨贏</td>
                <td>單雙</td>
                <td>滾球讓分</td>
                <td>滾球大小</td>
                <td>一輸二贏</td>
                <td>過關</td>
                <td>半場讓分大小</td>
                <td>全部設為<br />
                    <span style="color: Red">(不含過關)</span></td>
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink111" onclick="return AllDisable('rbty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtyrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtyrf">
                        &lt;=<asp:Label ID="lbrbtyrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtyrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtydx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtydx">
                        &lt;=<asp:Label ID="lbrbtydx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtydxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtydy">
                        &lt;=<asp:Label ID="lbrbtydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtyds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtyds">
                        &lt;=<asp:Label ID="lbrbtyds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtydst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtyzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtyzdrf">
                        &lt;=<asp:Label ID="lbrbtyzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtyzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtyzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtyzddx">
                        &lt;=<asp:Label ID="lbrbtyzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtyzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtysy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtysy">
                        &lt;=<asp:Label ID="lbrbtysy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtysyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtygg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtygg">
                        &lt;=<asp:Label ID="lbrbtygg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtyggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtybcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbtybcrf">
                        &lt;=<asp:Label ID="lbrbtybcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbtybcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbtyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink222" onclick="return AllDisable('rbdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzrf">
                        &lt;=<asp:Label ID="lbrbdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzdx">
                        &lt;=<asp:Label ID="lbrbdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzdy">
                        &lt;=<asp:Label ID="lbrbdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzds">
                        &lt;=<asp:Label ID="lbrbdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzzdrf">
                        &lt;=<asp:Label ID="lbrbdzzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzzddx">
                        &lt;=<asp:Label ID="lbrbdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzsy">
                        &lt;=<asp:Label ID="lbrbdzsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzgg">
                        &lt;=<asp:Label ID="lbrbdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdzbcrf">
                        &lt;=<asp:Label ID="lbrbdzbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdzbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink333" onclick="return AllDisable('rbdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdcrf">
                        &lt;=<asp:Label ID="lbrbdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdcdx">
                        &lt;=<asp:Label ID="lbrbdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdcdy">
                        &lt;=<asp:Label ID="lbrbdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdcds">
                        &lt;=<asp:Label ID="lbrbdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdczdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdczdrf">
                        &lt;=<asp:Label ID="lbrbdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdczddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdczddx">
                        &lt;=<asp:Label ID="lbrbdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdcsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdcsy">
                        &lt;=<asp:Label ID="lbrbdcsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdcsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdcgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdcgg">
                        &lt;=<asp:Label ID="lbrbdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdcbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divrbdcbcrf">
                        &lt;=<asp:Label ID="lbrbdcbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbrbdcbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtrbdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">排球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>排球</td>
                <td>讓分</td>
                <td>大小</td>
                <td>獨贏</td>
                <td>單雙</td>
                <td>滾球讓分</td>
                <td>滾球大小</td>
                <td>一輸二贏</td>
                <td>過關</td>
                <td>半場讓分大小</td>
                <td>全部設為<br />
                    <span style="color: Red">(不含過關)</span></td>
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1111" onclick="return AllDisable('tbty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtyrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtyrf">
                        &lt;=<asp:Label ID="lbtbtyrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbtyrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtydx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtydx">
                        &lt;=<asp:Label ID="lbtbtydx" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lbtbtydxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtydy">
                        &lt;=<asp:Label ID="lbtbtydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbtydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtyds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtyds">
                        &lt;=<asp:Label ID="lbtbtyds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbtydst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtyzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtyzdrf">
                        &lt;=<asp:Label ID="lbtbtyzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbtyzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtyzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtyzddx">
                        &lt;=<asp:Label ID="lbtbtyzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbtyzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtysy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtysy">
                        &lt;=<asp:Label ID="lbtbtysy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbtysyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtygg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtygg">
                        &lt;=<asp:Label ID="lbtbtygg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbtyggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtybcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbtybcrf">
                        &lt;=<asp:Label ID="lbtbtybcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbtybcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbtyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink2222" onclick="return AllDisable('tbdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzrf">
                        &lt;=<asp:Label ID="lbtbdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzdx">
                        &lt;=<asp:Label ID="lbtbdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzdy">
                        &lt;=<asp:Label ID="lbtbdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzds">
                        &lt;=<asp:Label ID="lbtbdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzzdrf">
                        &lt;=<asp:Label ID="lbtbdzzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzzddx">
                        &lt;=<asp:Label ID="lbtbdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzsy">
                        &lt;=<asp:Label ID="lbtbdzsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzgg">
                        &lt;=<asp:Label ID="lbtbdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdzbcrf">
                        &lt;=<asp:Label ID="lbtbdzbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdzbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink3333" onclick="return AllDisable('tbdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdcrf">
                        &lt;=<asp:Label ID="lbtbdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdcdx">
                        &lt;=<asp:Label ID="lbtbdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdcdy">
                        &lt;=<asp:Label ID="lbtbdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdcds">
                        &lt;=<asp:Label ID="lbtbdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdczdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdczdrf">
                        &lt;=<asp:Label ID="lbtbdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdczddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdczddx">
                        &lt;=<asp:Label ID="lbtbdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdcsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdcsy">
                        &lt;=<asp:Label ID="lbtbdcsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdcsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdcgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdcgg">
                        &lt;=<asp:Label ID="lbtbdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdcbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divtbdcbcrf">
                        &lt;=<asp:Label ID="lbtbdcbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbtbdcbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txttbdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">足球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>足球</td>
                <td>讓球</td>
                <td>大小</td>
                <td>獨贏</td>
                <td>單雙</td>
                <td>滾球讓球</td>
                <td>滾球大小</td>
                <td>半場讓球</td>
                <td>半場大小</td>
                <td>半場獨贏</td>
                <td>入球數</td>
                <td>波膽</td>
                <td>半全場</td>
                <td>過關</td>
                <td style="display: none;">冠軍</td>
                <td>全部設為<br />
                    <span style="color: Red">(不含過關)</span></td>
                <td rowspan="6"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hyzq" onclick="return AllDisable('zqtya');" NavigateUrl="#" runat="server">退佣設定A盤</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyarf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyarf">
                        &lt;=<asp:Label ID="lbzqtyarf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyarft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyadx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyadx">
                        &lt;=<asp:Label ID="lbzqtyadx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyadxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyady" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyady">
                        &lt;=<asp:Label ID="lbzqtyady" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyadyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyads" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyads">
                        &lt;=<asp:Label ID="lbzqtyads" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyadst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyazdrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyazdrf">
                        &lt;=<asp:Label ID="lbzqtyazdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyazdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyazddx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyazddx">
                        &lt;=<asp:Label ID="lbzqtyazddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyazddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyabcrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyabcrf">
                        &lt;=<asp:Label ID="lbzqtyabcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyabcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyabcdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyabcdx">
                        &lt;=<asp:Label ID="lbzqtyabcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyabcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyabcdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyabcdy">
                        &lt;=<asp:Label ID="lbzqtyabcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyabcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyarqs" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyarqs">
                        &lt;=<asp:Label ID="lbzqtyarqs" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyarqst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyabd" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyabd">
                        &lt;=<asp:Label ID="lbzqtyabd" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyabdt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyabqc" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyabqc">
                        &lt;=<asp:Label ID="lbzqtyabqc" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyabqct" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyagg" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyagg">
                        &lt;=<asp:Label ID="lbzqtyagg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyaggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyagj" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyagj">
                        &lt;=<asp:Label ID="lbzqtyagj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyagjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyaALL" Style="width: 40px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hyss" onclick="return AllDisable('zqtyb');" NavigateUrl="#" runat="server">退佣設定B盤</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybrf">
                        &lt;=<asp:Label ID="lbzqtybrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybdx">
                        &lt;=<asp:Label ID="lbzqtybdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybdy">
                        &lt;=<asp:Label ID="lbzqtybdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybds" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybds">
                        &lt;=<asp:Label ID="lbzqtybds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybzdrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybzdrf">
                        &lt;=<asp:Label ID="lbzqtybzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybzddx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybzddx">
                        &lt;=<asp:Label ID="lbzqtybzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybbcrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybbcrf">
                        &lt;=<asp:Label ID="lbzqtybbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybbcdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybbcdx">
                        &lt;=<asp:Label ID="lbzqtybbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybbcdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybbcdy">
                        &lt;=<asp:Label ID="lbzqtybbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybrqs" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybrqs">
                        &lt;=<asp:Label ID="lbzqtybrqs" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybrqst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybbd" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybbd">
                        &lt;=<asp:Label ID="lbzqtybbd" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybbdt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybbqc" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybbqc">
                        &lt;=<asp:Label ID="lbzqtybbqc" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybbqct" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybgg" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybgg">
                        &lt;=<asp:Label ID="lbzqtybgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybgj" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtybgj">
                        &lt;=<asp:Label ID="lbzqtybgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtybgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtybALL" Style="width: 40px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="sdf" onclick="return AllDisable('zqtyc');" NavigateUrl="#" runat="server">退佣設定C盤</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycrf">
                        &lt;=<asp:Label ID="lbzqtycrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycdx">
                        &lt;=<asp:Label ID="lbzqtycdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycdy">
                        &lt;=<asp:Label ID="lbzqtycdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycds" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycds">
                        &lt;=<asp:Label ID="lbzqtycds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyczdrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyczdrf">
                        &lt;=<asp:Label ID="lbzqtyczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtyczddx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtyczddx">
                        &lt;=<asp:Label ID="lbzqtyczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtyczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycbcrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycbcrf">
                        &lt;=<asp:Label ID="lbzqtycbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycbcdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycbcdx">
                        &lt;=<asp:Label ID="lbzqtycbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycbcdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycbcdy">
                        &lt;=<asp:Label ID="lbzqtycbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycrqs" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycrqs">
                        &lt;=<asp:Label ID="lbzqtycrqs" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycrqst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycbd" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycbd">
                        &lt;=<asp:Label ID="lbzqtycbd" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycbdt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycbqc" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycbqc">
                        &lt;=<asp:Label ID="lbzqtycbqc" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycbqct" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycgg" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycgg">
                        &lt;=<asp:Label ID="lbzqtycgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycgj" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqtycgj">
                        &lt;=<asp:Label ID="lbzqtycgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqtycgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqtycALL" Style="width: 40px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="sdfsdf" onclick="return AllDisable('zqdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzrf">
                        &lt;=<asp:Label ID="lbzqdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzdx">
                        &lt;=<asp:Label ID="lbzqdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzdy">
                        &lt;=<asp:Label ID="lbzqdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzds" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzds">
                        &lt;=<asp:Label ID="lbzqdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzzdrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzzdrf">
                        &lt;=<asp:Label ID="lbzqdzzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzzddx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzzddx">
                        &lt;=<asp:Label ID="lbzqdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzbcrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzbcrf">
                        &lt;=<asp:Label ID="lbzqdzbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzbcdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzbcdx">
                        &lt;=<asp:Label ID="lbzqdzbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzbcdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzbcdy">
                        &lt;=<asp:Label ID="lbzqdzbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzrqs" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzrqs">
                        &lt;=<asp:Label ID="lbzqdzrqs" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzrqst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzbd" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzbd">
                        &lt;=<asp:Label ID="lbzqdzbd" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzbdt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzbqc" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzbqc">
                        &lt;=<asp:Label ID="lbzqdzbqc" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzbqct" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzgg" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzgg">
                        &lt;=<asp:Label ID="lbzqdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzgj" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdzgj">
                        &lt;=<asp:Label ID="lbzqdzgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdzgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdzALL" Style="width: 40px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="DDDD" onclick="return AllDisable('zqdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcrf">
                        &lt;=<asp:Label ID="lbzqdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcdx">
                        &lt;=<asp:Label ID="lbzqdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcdy">
                        &lt;=<asp:Label ID="lbzqdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcds" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcds">
                        &lt;=<asp:Label ID="lbzqdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdczdrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdczdrf">
                        &lt;=<asp:Label ID="lbzqdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdczddx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdczddx">
                        &lt;=<asp:Label ID="lbzqdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcbcrf" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcbcrf">
                        &lt;=<asp:Label ID="lbzqdcbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcbcdx" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcbcdx">
                        &lt;=<asp:Label ID="lbzqdcbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcbcdy" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcbcdy">
                        &lt;=<asp:Label ID="lbzqdcbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcrqs" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcrqs">
                        &lt;=<asp:Label ID="lbzqdcrqs" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcrqst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcbd" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcbd">
                        &lt;=<asp:Label ID="lbzqdcbd" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcbdt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcbqc" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcbqc">
                        &lt;=<asp:Label ID="lbzqdcbqc" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcbqct" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcgg" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcgg">
                        &lt;=<asp:Label ID="lbzqdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcgj" Style="width: 40px" runat="server"></asp:TextBox>
                    <div id="divzqdcgj">
                        &lt;=<asp:Label ID="lbzqdcgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzqdcgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzqdcALL" Style="width: 40px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">美足設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>美足</td>
                <td>讓分</td>
                <td>大小</td>
                <td>獨贏</td>
                <td>單雙</td>
                <td>滾球讓分</td>
                <td>滾球大小</td>
                <td>半場讓分</td>
                <td>半場大小</td>
                <td>半場獨贏</td>
                <td>半場單雙</td>
                <td>過關</td>
                <td style="display: none;">冠軍</td>
                <td>全部設為<br />
                    <span style="color: Red">(不含過關)</span></td>
                <td rowspan="4" colspan="3"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hysdf" onclick="return AllDisable('mzty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztyrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztyrf">
                        &lt;=<asp:Label ID="lbmztyrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztyrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztydx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztydx">
                        &lt;=<asp:Label ID="lbmztydx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztydxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztydy">
                        &lt;=<asp:Label ID="lbmztydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztyds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztyds">
                        &lt;=<asp:Label ID="lbmztyds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztydst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztyzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztyzdrf">
                        &lt;=<asp:Label ID="lbmztyzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztyzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztyzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztyzddx">
                        &lt;=<asp:Label ID="lbmztyzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztyzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztybcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztybcrf">
                        &lt;=<asp:Label ID="lbmztybcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztybcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztybcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztybcdx">
                        &lt;=<asp:Label ID="lbmztybcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztybcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztybcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztybcdy">
                        &lt;=<asp:Label ID="lbmztybcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztybcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztybcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztybcds">
                        &lt;=<asp:Label ID="lbmztybcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztybcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztygg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztygg">
                        &lt;=<asp:Label ID="lbmztygg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztyggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztygj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmztygj">
                        &lt;=<asp:Label ID="lbmztygj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmztygjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmztyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="sdfsd" onclick="return AllDisable('mzdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzrf">
                        &lt;=<asp:Label ID="lbmzdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzdx">
                        &lt;=<asp:Label ID="lbmzdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzdy">
                        &lt;=<asp:Label ID="lbmzdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzds">
                        &lt;=<asp:Label ID="lbmzdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzzdrf">
                        &lt;=<asp:Label ID="lbmzdzzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzzddx">
                        &lt;=<asp:Label ID="lbmzdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzbcrf">
                        &lt;=<asp:Label ID="lbmzdzbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzbcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzbcdx">
                        &lt;=<asp:Label ID="lbmzdzbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzbcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzbcdy">
                        &lt;=<asp:Label ID="lbmzdzbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzbcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzbcds">
                        &lt;=<asp:Label ID="lbmzdzbcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzbcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzgg">
                        &lt;=<asp:Label ID="lbmzdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdzgj">
                        &lt;=<asp:Label ID="lbmzdzgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdzgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="dddd2" onclick="return AllDisable('mzdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcrf">
                        &lt;=<asp:Label ID="lbmzdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcdx">
                        &lt;=<asp:Label ID="lbmzdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcdy">
                        &lt;=<asp:Label ID="lbmzdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcds">
                        &lt;=<asp:Label ID="lbmzdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdczdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdczdrf">
                        &lt;=<asp:Label ID="lbmzdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdczddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdczddx">
                        &lt;=<asp:Label ID="lbmzdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcbcrf">
                        &lt;=<asp:Label ID="lbmzdcbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcbcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcbcdx">
                        &lt;=<asp:Label ID="lbmzdcbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcbcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcbcdy">
                        &lt;=<asp:Label ID="lbmzdcbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcbcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcbcds">
                        &lt;=<asp:Label ID="lbmzdcbcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcbcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcgg">
                        &lt;=<asp:Label ID="lbmzdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divmzdcgj">
                        &lt;=<asp:Label ID="lbmzdcgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbmzdcgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtmzdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">冰球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>冰球</td>
                <td>讓分</td>
                <td>大小</td>
                <td>獨贏</td>
                <td>單雙</td>
                <td>滾球讓分</td>
                <td>滾球大小</td>
                <td>一輸二贏</td>
                <td>過關</td>
                <td>半場讓分大小</td>
                <td>全部設為<br />
                    <span style="color: Red">(不含過關)</span></td>
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink8" onclick="return AllDisable('bqty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtyrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtyrf">
                        &lt;=<asp:Label ID="lbbqtyrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtyrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtydx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtydx">
                        &lt;=<asp:Label ID="lbbqtydx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtydxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtydy">
                        &lt;=<asp:Label ID="lbbqtydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtyds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtyds">
                        &lt;=<asp:Label ID="lbbqtyds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtydst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtyzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtyzdrf">
                        &lt;=<asp:Label ID="lbbqtyzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtyzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtyzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtyzddx">
                        &lt;=<asp:Label ID="lbbqtyzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtyzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtysy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtysy">
                        &lt;=<asp:Label ID="lbbqtysy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtysyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtygg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtygg">
                        &lt;=<asp:Label ID="lbbqtygg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtyggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtybcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqtybcrf">
                        &lt;=<asp:Label ID="lbbqtybcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqtybcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqtyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink9" onclick="return AllDisable('bqdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzrf">
                        &lt;=<asp:Label ID="lbbqdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzdx">
                        &lt;=<asp:Label ID="lbbqdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzdy">
                        &lt;=<asp:Label ID="lbbqdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzds">
                        &lt;=<asp:Label ID="lbbqdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzzdrf">
                        &lt;=<asp:Label ID="lbbqdzzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzzddx">
                        &lt;=<asp:Label ID="lbbqdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzsy">
                        &lt;=<asp:Label ID="lbbqdzsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzgg">
                        &lt;=<asp:Label ID="lbbqdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdzbcrf">
                        &lt;=<asp:Label ID="lbbqdzbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdzbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink10" onclick="return AllDisable('bqdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdcrf">
                        &lt;=<asp:Label ID="lbbqdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdcdx">
                        &lt;=<asp:Label ID="lbbqdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdcdxt" runat="server" Text=""> </asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdcdy">
                        &lt;=<asp:Label ID="lbbqdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdcds">
                        &lt;=<asp:Label ID="lbbqdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdczdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdczdrf">
                        &lt;=<asp:Label ID="lbbqdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdczddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdczddx">
                        &lt;=<asp:Label ID="lbbqdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdcsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdcsy">
                        &lt;=<asp:Label ID="lbbqdcsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdcsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdcgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdcgg">
                        &lt;=<asp:Label ID="lbbqdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdcbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divbqdcbcrf">
                        &lt;=<asp:Label ID="lbbqdcbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbbqdcbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtbqdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">彩球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>彩球</td>
                <td>讓分</td>
                <td>大小</td>
                <td>獨贏</td>
                <td>單雙</td>
                <td>滾球讓分</td>
                <td>滾球大小</td>
                <td>半場讓分</td>
                <td>半場大小</td>
                <td>半場獨贏</td>
                <td>半場單雙</td>
                <td>過關</td>
                <td style="display: none;">冠軍</td>
                <td>全部設為<br />
                    <span style="color: Red">(不含過關)</span></td>
                <td rowspan="4" colspan="3"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink12" onclick="return AllDisable('cqty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtyrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtyrf">
                        &lt;=<asp:Label ID="lbcqtyrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtyrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtydx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtydx">
                        &lt;=<asp:Label ID="lbcqtydx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtydxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtydy">
                        &lt;=<asp:Label ID="lbcqtydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtyds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtyds">
                        &lt;=<asp:Label ID="lbcqtyds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtydst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtyzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtyzdrf">
                        &lt;=<asp:Label ID="lbcqtyzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtyzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtyzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtyzddx">
                        &lt;=<asp:Label ID="lbcqtyzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtyzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtybcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtybcrf">
                        &lt;=<asp:Label ID="lbcqtybcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtybcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtybcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtybcdx">
                        &lt;=<asp:Label ID="lbcqtybcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtybcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtybcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtybcdy">
                        &lt;=<asp:Label ID="lbcqtybcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtybcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtybcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtybcds">
                        &lt;=<asp:Label ID="lbcqtybcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtybcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtygg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtygg">
                        &lt;=<asp:Label ID="lbcqtygg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtyggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtygj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqtygj">
                        &lt;=<asp:Label ID="lbcqtygj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqtygjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqtyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink13" onclick="return AllDisable('cqdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzrf">
                        &lt;=<asp:Label ID="lbcqdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzdx">
                        &lt;=<asp:Label ID="lbcqdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzdy">
                        &lt;=<asp:Label ID="lbcqdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzds">
                        &lt;=<asp:Label ID="lbcqdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzzdrf">
                        &lt;=<asp:Label ID="lbcqdzzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzzddx">
                        &lt;=<asp:Label ID="lbcqdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzbcrf">
                        &lt;=<asp:Label ID="lbcqdzbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzbcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzbcdx">
                        &lt;=<asp:Label ID="lbcqdzbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzbcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzbcdy">
                        &lt;=<asp:Label ID="lbcqdzbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzbcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzbcds">
                        &lt;=<asp:Label ID="lbcqdzbcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzbcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzgg">
                        &lt;=<asp:Label ID="lbcqdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdzgj">
                        &lt;=<asp:Label ID="lbcqdzgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdzgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink14" onclick="return AllDisable('cqdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcrf">
                        &lt;=<asp:Label ID="lbcqdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcdx">
                        &lt;=<asp:Label ID="lbcqdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcdy">
                        &lt;=<asp:Label ID="lbcqdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcds">
                        &lt;=<asp:Label ID="lbcqdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdczdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdczdrf">
                        &lt;=<asp:Label ID="lbcqdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdczddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdczddx">
                        &lt;=<asp:Label ID="lbcqdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcbcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcbcrf">
                        &lt;=<asp:Label ID="lbcqdcbcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcbcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcbcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcbcdx">
                        &lt;=<asp:Label ID="lbcqdcbcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcbcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcbcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcbcdy">
                        &lt;=<asp:Label ID="lbcqdcbcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcbcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcbcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcbcds">
                        &lt;=<asp:Label ID="lbcqdcbcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcbcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcgg">
                        &lt;=<asp:Label ID="lbcqdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none;">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcqdcgj">
                        &lt;=<asp:Label ID="lbcqdcgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcqdcgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcqdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">期指設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>期指</td>
                <td style="display: none;">讓分</td>
                <td>大小</td>
                <td style="display: none;">獨贏</td>
                <td>單雙</td>
                <td style="display: none;">滾球讓分</td>
                <td style="display: none;">滾球大小</td>
                <td style="display: none;">一輸二贏</td>
                <td style="display: none;">波膽</td>
                <td style="display: none;">過關</td>
                <td style="display: none;">冠軍</td>
                <td>全部設為</td>
                <td rowspan="4" colspan="13"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="dddswq" onclick="return AllDisable('zsty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstyrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstyrf">
                        &lt;=<asp:Label ID="lbzstyrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstyrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstydx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstydx">
                        &lt;=<asp:Label ID="lbzstydx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstydxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstydy">
                        &lt;=<asp:Label ID="lbzstydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstyds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstyds">
                        &lt;=<asp:Label ID="lbzstyds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstydst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstyzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstyzdrf">
                        &lt;=<asp:Label ID="lbzstyzdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstyzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstyzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstyzddx">
                        &lt;=<asp:Label ID="lbzstyzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstyzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstysy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstysy">
                        &lt;=<asp:Label ID="lbzstysy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstysyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstybd" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstybd">
                        &lt;=<asp:Label ID="lbzstybd" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstybdt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstygg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstygg">
                        &lt;=<asp:Label ID="lbzstygg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstyggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstygj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzstygj">
                        &lt;=<asp:Label ID="lbzstygj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzstygjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzstyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hy4432" onclick="return AllDisable('zsdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzrf">
                        &lt;=<asp:Label ID="lbzsdzrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzdx">
                        &lt;=<asp:Label ID="lbzsdzdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzdy">
                        &lt;=<asp:Label ID="lbzsdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzds">
                        &lt;=<asp:Label ID="lbzsdzds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzzdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzzdrf">
                        &lt;=<asp:Label ID="lbzsdzzdrf" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lbzsdzzdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzzddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzzddx">
                        &lt;=<asp:Label ID="lbzsdzzddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzzddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzsy">
                        &lt;=<asp:Label ID="lbzsdzsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzbd" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzbd">
                        &lt;=<asp:Label ID="lbzsdzbd" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzbdt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzgg">
                        &lt;=<asp:Label ID="lbzsdzgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdzgj">
                        <&lt;=<asp:Label ID="lbzsdzgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdzgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hy435443" onclick="return AllDisable('zsdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdcrf">
                        &lt;=<asp:Label ID="lbzsdcrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdcrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcdx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdcdx">
                        &lt;=<asp:Label ID="lbzsdcdx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdcdxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdcdy">
                        &lt;=<asp:Label ID="lbzsdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdcds">
                        &lt;=<asp:Label ID="lbzsdcds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdcdst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdczdrf" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdczdrf">
                        &lt;=<asp:Label ID="lbzsdczdrf" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdczdrft" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdczddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdczddx">
                        &lt;=<asp:Label ID="lbzsdczddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdczddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcsy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdcsy">
                        &lt;=<asp:Label ID="lbzsdcsy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdcsyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcbd" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdcbd">
                        &lt;=<asp:Label ID="lbzsdcbd" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdcbdt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcgg" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdcgg">
                        &lt;=<asp:Label ID="lbzsdcgg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdcggt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcgj" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divzsdcgj">
                        &lt;=<asp:Label ID="lbzsdcgj" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbzsdcgjt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtzsdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">賽馬設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>賽馬</td>
                <td>獨贏</td>
                <td>位置</td>
                <td>連贏</td>
                <td>位置Q</td>
                <td>全部設為</td>
                <td rowspan="4" colspan="11"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hy34543" onclick="return AllDisable('smty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmtydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmtydy">
                        &lt;=<asp:Label ID="lbsmtydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmtydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmtywz" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmtywz">
                        &lt;=<asp:Label ID="lbsmtywz" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmtywzt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmtyly" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmtyly">
                        &lt;=<asp:Label ID="lbsmtyly" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmtylyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmtywzq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmtywzq">
                        &lt;=<asp:Label ID="lbsmtywzq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmtywzqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmtyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hy566" onclick="return AllDisable('smdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmdzdy">
                        &lt;=<asp:Label ID="lbsmdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdzwz" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmdzwz">
                        &lt;=<asp:Label ID="lbsmdzwz" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmdzwzt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdzly" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmdzly">
                        &lt;=<asp:Label ID="lbsmdzly" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmdzlyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdzwzq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmdzwzq">
                        &lt;=<asp:Label ID="lbsmdzwzq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmdzwzqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hy5676" onclick="return AllDisable('smdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmdcdy">
                        &lt;=<asp:Label ID="lbsmdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdcwz" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmdcwz">
                        &lt;=<asp:Label ID="lbsmdcwz" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmdcwzt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdcly" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmdcly">
                        &lt;=<asp:Label ID="lbsmdcly" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmdclyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdcwzq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsmdcwzq">
                        &lt;=<asp:Label ID="lbsmdcwzq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsmdcwzqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtsmdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">六合彩設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>六合彩</td>
                <td class="hei">特別號</td>
                <td class="hei">台特</td>
                <td class="hei">台號</td>
                <td class="hei">全車碰</td>
                <td class="hei">2星</td>
                <td class="hei">3星</td>
                <td class="hei">4星</td>
                <td class="hei">固定單雙</td>
                <td class="hei">固定大小</td>
                <td class="hei">全部設為</td>
                <td rowspan="4" colspan="5"></td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px;">
                    <asp:HyperLink ID="hy8897" onclick="return AllDisable('lhcty');" NavigateUrl="#" runat="server">退佣設定（百）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhctytbh" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhctytbh">
                        &lt;=<asp:Label ID="lblhctytbh" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhctytbht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhctytt" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhctytt">
                        &lt;=<asp:Label ID="lblhctytt" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhctyttt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhctyth" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhctyth">
                        &lt;=<asp:Label ID="lblhctyth" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhctytht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhctyqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhctyqcp">
                        &lt;=<asp:Label ID="lblhctyqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhctyqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcty2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcty2x">
                        &lt;=<asp:Label ID="lblhcty2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcty2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcty3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcty3x">
                        &lt;=<asp:Label ID="lblhcty3x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcty3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcty4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcty4x">
                        &lt;=<asp:Label ID="lblhcty4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcty4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhctygdds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhctygdds">
                        &lt;=<asp:Label ID="lblhctygdds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhctygddst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhctygddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhctygddx">
                        &lt;=<asp:Label ID="lblhctygddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhctygddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtlhctyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px">
                    <asp:HyperLink ID="hy1" onclick="return AllDisable('lhcdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdztbh" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdztbh">
                        &lt;=<asp:Label ID="lblhcdztbh" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdztbht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdztt" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdztt">
                        &lt;=<asp:Label ID="lblhcdztt" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdzttt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdzth" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdzth">
                        &lt;=<asp:Label ID="lblhcdzth" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdztht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdzqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdzqcp">
                        &lt;=<asp:Label ID="lblhcdzqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdzqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdz2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdz2x">
                        &lt;=<asp:Label ID="lblhcdz2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdz2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdz3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdz3x">
                        &lt;=<asp:Label ID="lblhcdz3x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdz3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdz4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdz4x">
                        &lt;=<asp:Label ID="lblhcdz4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdz4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdzgdds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdzgdds">
                        &lt;=<asp:Label ID="lblhcdzgdds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdzgddst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdzgddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdzgddx">
                        &lt;=<asp:Label ID="lblhcdzgddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdzgddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtlhcdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px;">
                    <asp:HyperLink ID="hy2" onclick="return AllDisable('lhcdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdctbh" Style="width: 50px" runat="server">
                    </asp:TextBox>
                    <div id="divlhcdctbh">
                        &lt;=<asp:Label ID="lblhcdctbh" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdctbht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdctt" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdctt">
                        &lt;=<asp:Label ID="lblhcdctt" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdcttt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdcth" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdcth">
                        &lt;=<asp:Label ID="lblhcdcth" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdctht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdcqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdcqcp">
                        &lt;=<asp:Label ID="lblhcdcqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdcqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdc2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdc2x">
                        &lt;=<asp:Label ID="lblhcdc2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdc2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdc3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdc3x">
                        &lt;=<asp:Label ID="lblhcdc3x" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblhcdc3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdc4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdc4x">
                        &lt;=<asp:Label ID="lblhcdc4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdc4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdcgdds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdcgdds">
                        &lt;=<asp:Label ID="lblhcdcgdds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdcgddst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtlhcdcgddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divlhcdcgddx">
                        &lt;=<asp:Label ID="lblhcdcgddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblhcdcgddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtlhcdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">大樂透設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="16">大樂透</td>
                <td class="hei">特別號</td>
                <td class="hei">台特</td>
                <td class="hei">台號</td>
                <td class="hei">全車碰</td>
                <td class="hei">2星</td>
                <td class="hei">3星</td>
                <td class="hei">4星</td>
                <td class="hei">固定單雙</td>
                <td class="hei">固定大小</td>
                <td class="hei">全部設為</td>
                <td rowspan="4" colspan="5"></td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px;">
                    <asp:HyperLink ID="hy3" onclick="return AllDisable('dltty');" NavigateUrl="#" runat="server">退佣設定（百）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdlttytbh" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdlttytbh">
                        &lt;=<asp:Label ID="lbdlttytbh" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdlttytbht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdlttytt" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdlttytt">
                        &lt;=<asp:Label ID="lbdlttytt" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdlttyttt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdlttyth" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdlttyth">
                        &lt;=<asp:Label ID="lbdlttyth" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdlttytht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdlttyqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdlttyqcp">
                        &lt;=<asp:Label ID="lbdlttyqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdlttyqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltty2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltty2x">
                        &lt;=<asp:Label ID="lbdltty2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltty2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltty3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltty3x">
                        &lt;=<asp:Label ID="lbdltty3x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltty3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltty4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltty4x">
                        &lt;=<asp:Label ID="lbdltty4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltty4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdlttygdds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdlttygdds">
                        &lt;=<asp:Label ID="lbdlttygdds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdlttygddst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdlttygddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdlttygddx">
                        &lt;=<asp:Label ID="lbdlttygddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdlttygddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtdlttyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px">
                    <asp:HyperLink ID="hy4" onclick="return AllDisable('dltdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdztbh" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdztbh">
                        &lt;=<asp:Label ID="lbdltdztbh" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdztbht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdztt" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdztt">
                        &lt;=<asp:Label ID="lbdltdztt" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdzttt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdzth" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdzth">
                        &lt;=<asp:Label ID="lbdltdzth" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdztht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdzqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdzqcp">
                        &lt;=<asp:Label ID="lbdltdzqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdzqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdz2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdz2x">
                        &lt;=<asp:Label ID="lbdltdz2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdz2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdz3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdz3x">
                        &lt;=<asp:Label ID="lbdltdz3x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdz3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdz4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdz4x">
                        &lt;=<asp:Label ID="lbdltdz4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdz4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdzgdds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdzgdds">
                        &lt;=<asp:Label ID="lbdltdzgdds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdzgddst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdzgddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdzgddx">
                        &lt;=<asp:Label ID="lbdltdzgddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdzgddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtdltdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px;">
                    <asp:HyperLink ID="hy5" onclick="return AllDisable('dltdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdctbh" Style="width: 50px" runat="server">
                    </asp:TextBox>
                    <div id="divdltdctbh">
                        &lt;=<asp:Label ID="lbdltdctbh" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdctbht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdctt" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdctt">
                        &lt;=<asp:Label ID="lbdltdctt" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdcttt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdcth" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdcth">
                        &lt;=<asp:Label ID="lbdltdcth" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdctht" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdcqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdcqcp">
                        &lt;=<asp:Label ID="lbdltdcqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdcqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdc2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdc2x">
                        &lt;=<asp:Label ID="lbdltdc2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdc2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdc3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdc3x">
                        &lt;=<asp:Label ID="lbdltdc3x" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lbdltdc3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdc4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdc4x">
                        &lt;=<asp:Label ID="lbdltdc4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdc4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdcgdds" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdcgdds">
                        &lt;=<asp:Label ID="lbdltdcgdds" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdcgddst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtdltdcgddx" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divdltdcgddx">
                        &lt;=<asp:Label ID="lbdltdcgddx" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbdltdcgddxt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtdltdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">今彩539設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="16">今彩</td>
                <td class="hei">全車碰</td>
                <td class="hei">2星</td>
                <td class="hei">3星</td>
                <td class="hei">4星</td>
                <td class="hei">全部設為</td>
                <td rowspan="4" colspan="10"></td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px;">
                    <asp:HyperLink ID="hy6" onclick="return AllDisable('jc539ty');" NavigateUrl="#" runat="server">退佣設定（百）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539tyqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539tyqcp">
                        &lt;=<asp:Label ID="lbjc539tyqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539tyqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539ty2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539ty2x">
                        &lt;=<asp:Label ID="lbjc539ty2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539ty2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539ty3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539ty3x">
                        &lt;=<asp:Label ID="lbjc539ty3x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539ty3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539ty4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539ty4x">
                        &lt;=<asp:Label ID="lbjc539ty4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539ty4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtjc539tyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px">
                    <asp:HyperLink ID="hy7" onclick="return AllDisable('jc539dz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539dzqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539dzqcp">
                        &lt;=<asp:Label ID="lbjc539dzqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539dzqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539dz2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539dz2x">
                        &lt;=<asp:Label ID="lbjc539dz2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539dz2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539dz3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539dz3x">
                        &lt;=<asp:Label ID="lbjc539dz3x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539dz3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539dz4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539dz4x">
                        &lt;=<asp:Label ID="lbjc539dz4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539dz4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtjc539dzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px;">
                    <asp:HyperLink ID="hy8" onclick="return AllDisable('jc539dc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539dcqcp" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539dcqcp">
                        &lt;=<asp:Label ID="lbjc539dcqcp" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539dcqcpt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539dc2x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539dc2x">
                        &lt;=<asp:Label ID="lbjc539dc2x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539dc2xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539dc3x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539dc3x">
                        &lt;=<asp:Label ID="lbjc539dc3x" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lbjc539dc3xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtjc539dc4x" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divjc539dc4x">
                        &lt;=<asp:Label ID="lbjc539dc4x" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbjc539dc4xt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtjc539dcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">運彩設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>運彩</td>
                <td>棒球彩票</td>
                <td>籃球彩票</td>
                <td>足球彩票</td>
                <td style="display: none">股市彩票</td>
                <td style="display: none">期指彩票</td>
                <td>全部設為</td>
                <td rowspan="2" colspan="12"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hy10" onclick="return AllDisable('cpdz');" NavigateUrl="#" runat="server">注数上限（注）</asp:HyperLink></td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdzbq" Style="width: 50px" runat="server" onblur="CheckZS(this)"></asp:TextBox>
                    <div id="divcpdzbq">
                        &lt;=<asp:Label ID="lbcpdzbq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdzbqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdzlq" Style="width: 50px" runat="server" onblur="CheckZS(this)"></asp:TextBox>
                    <div id="divcpdzlq">
                        &lt;=<asp:Label ID="lbcpdzlq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdzlqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdzzq" Style="width: 50px" runat="server" onblur="CheckZS(this)"></asp:TextBox>
                    <div id="divcpdzzq">
                        &lt;=<asp:Label ID="lbcpdzzq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdzzqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdzgs" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcpdzgs">
                        &lt;=<asp:Label ID="lbcpdzgs" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdzgst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdzqz" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcpdzqz">
                        &lt;=<asp:Label ID="lbcpdzqz" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdzqzt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td style="display: none">
                    <asp:HyperLink ID="hy9" onclick="return AllDisable('cpty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcptybq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcptybq">
                        &lt;=<asp:Label ID="lbcptybq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcptybqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcptylq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcptylq">
                        &lt;=<asp:Label ID="lbcptylq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcptylqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcptyzq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcptyzq">
                        &lt;=<asp:Label ID="lbcptyzq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcptyzqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcptygs" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcptygs">
                        &lt;=<asp:Label ID="lbcptygs" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcptygst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcptyqz" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcptyqz">
                        &lt;=<asp:Label ID="lbcptyqz" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcptyqzt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcptyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr style="display: none">
                <td style="display: none">
                    <asp:HyperLink ID="hy11" onclick="return AllDisable('cpdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdcbq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcpdcbq">
                        &lt;=<asp:Label ID="lbcpdcbq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdcbqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdclq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcpdclq">
                        &lt;=<asp:Label ID="lbcpdclq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdclqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdczq" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcpdczq">
                        &lt;=<asp:Label ID="lbcpdczq" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdczqt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdcgs" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcpdcgs">
                        &lt;=<asp:Label ID="lbcpdcgs" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdcgst" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdcqz" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divcpdcqz">
                        &lt;=<asp:Label ID="lbcpdcqz" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbcpdcqzt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="display: none">
                    <asp:TextBox CssClass="hiddeninput" ID="txtcpdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="17">
                    <table>
                        <tr>

                            <td class="td_title">時事設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="16">時事</td>
                <td class="hei">獨贏</td>
                <td class="hei">全部設為</td>
                <td rowspan="4" colspan="14"></td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px;">
                    <asp:HyperLink ID="HyperLink5" onclick="return AllDisable('ssty');" NavigateUrl="#" runat="server">退佣設定</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtsstydy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divsstydy">
                        &lt;=<asp:Label ID="lbsstydy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbsstydyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtsstyALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px">
                    <asp:HyperLink ID="HyperLink6" onclick="return AllDisable('ssdz');" NavigateUrl="#" runat="server">單注上限（萬）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtssdzdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divssdzdy">
                        &lt;=<asp:Label ID="lbssdzdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbssdzdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtssdzALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="hei" style="width: 96px;">
                    <asp:HyperLink ID="HyperLink7" onclick="return AllDisable('ssdc');" NavigateUrl="#" runat="server">單場上限（萬）</asp:HyperLink></td>
                <td class="hei">
                    <asp:TextBox class="hiddeninput" ID="txtssdcdy" Style="width: 50px" runat="server"></asp:TextBox>
                    <div id="divssdcdy">
                        &lt;=<asp:Label ID="lbssdcdy" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbssdcdyt" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="hiddeninput" ID="txtssdcALL" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
