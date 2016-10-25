<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="AgentManageAdd.aspx.cs" Inherits="AgentManageAdd" %>

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
     <asp:HiddenField ID="hidje" runat="server" />
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">会员管理</a>  <span
            class="divider">/</span> <asp:Label ID="lbtitle" runat="server" Text="" />/总代理新增
    </ul>
    <div class="title_right" runat="server" id="trbj">
        <strong>
         
            <asp:Label ID="lbtitle1" runat="server" Text="" /></strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table style="width: 100%" class="table">
            <tr>
                <td class="trl" colspan="3">
                    <asp:Button ID="btAddzj" runat="server" Text="新增總監" OnClick="bttjzj_Click" CssClass="button" />
                </td>
            </tr>
            <tr>
                <td style="width: 12%" class="trl">
                    <font color="red">*</font>
                    <asp:Label ID="lbzh" runat="server" Text="" />
                </td>
                <td id="accounts01" style="width: 38%">
                    <asp:DropDownList ID="drzjzh" runat="server">
                    </asp:DropDownList></td>
                <td class="trl" style="width: 12%">
                    <font color="red">*</font>
                    <asp:Label ID="lbzhmc" runat="server" Text="" />
                </td>
                <td>
                    <asp:TextBox ID="txtzjmc" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <font color="red">*</font>密碼：
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtmm" runat="server" MaxLength="20" TextMode="Password" /></td>
                <td class="auto-style1">
                    <font color="red">*</font>密碼確認：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtzrmm" runat="server" MaxLength="20" TextMode="Password" />
                    <span style="color: Red">(密碼長度不能大於20位)</span>
                </td>
            </tr>
            <tr>
                <td class="trl">
                    <font color="red">*</font>分配信用額度：</td>
                <td>
                    <asp:TextBox ID="txtxyed" runat="server" MaxLength="9" />（萬）</td>
                <td class="trl">
                    <font color="red">*</font>是否允許登入：</td>
                <td>
                    <asp:RadioButtonList ID="Rdyxdl" runat="server" class="font_12_black" RepeatDirection="Horizontal"
                        Width="95px">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="trl">單隊上限：
                </td>
                <td>
                    <asp:TextBox ID="txtddsx" runat="server">0</asp:TextBox>（萬）<font color="red">注：值是‘0’時不限制</font></td>
                <td class="trl">
                    <font color="red">*</font>是否延遲下注：
                </td>
                <td>
                    <asp:RadioButtonList ID="Rdycxz" runat="server" RepeatDirection="Horizontal" Width="95px">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td class="trl">
                    <font color="red">*</font>是否允許下注：</td>
                <td id="tdcol" runat="server">
                    <asp:RadioButtonList ID="Rdyxxz" runat="server" RepeatDirection="Horizontal" Width="95px">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td id="tdlbXiazhuNum" runat="server" class="trl">
                    <font color="red">*</font>
                    <asp:Label ID="lblggxz" runat="server" Text="過關下注關數限制：" /></td>
                <td id="tddrpXiazhuNum" runat="server">
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
            <tr style="display: none">
                <td class="trl">
                    <font color="red">*</font>
                    <asp:HyperLink ID="hycz" onclick=" return AllDisable('cz');" NavigateUrl="#" runat="server"><span style="color:Blue">拆帳百分比：</span></asp:HyperLink></td>
                <td colspan="3">
                    <table style="width: 100%" class="table">
                        <tr>
                            <td class="trc">籃球%</td>
                            <td class="trc">棒球%</td>
                            <td class="trc">网球%</td>
                            <td class="trc">排球%</td>
                            <td class="trc">足球%</td>
                            <td class="trc">美足%</td>
                            <td class="trc">冰球%</td>
                            <td class="trc">彩球%</td>
                            <<td class="trc">指數%</td>
                            <td class="trc" style="display: none;">大樂透%</td>
                            <td class="trc">運彩%</td>
                            <td class="trc">賽馬%</td>
                            <td class="trc" style="display: none;">六合彩%</td>
                            <td class="trc" style="display: none;">二星%</td>
                            <td class="trc" style="display: none;">三星%</td>
                            <td class="trc" style="display: none;">四星%</td>
                            <td class="trc" style="display: none;">今彩%</td>
                            <td class="trc">時事%</td>
                        </tr>
                        <tr class="trc">
                            <td>
                                <asp:TextBox ID="txtlq" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtmb" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtrb" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txttb" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtzq" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtmz" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtbq" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtcq" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtzs" Style="width: 40px" runat="server" />
                            </td>
                            <td style="display: none;">
                                <asp:TextBox ID="txtdlt" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtcp" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtsm" Style="width: 40px" runat="server" />
                            </td>
                            <td style="display: none;">
                                <asp:TextBox ID="txtlhc" Style="width: 40px" runat="server" />
                            </td>
                            <td style="display: none;">
                                <asp:TextBox ID="txt2x" Style="width: 40px" runat="server" />
                            </td>
                            <td style="display: none;">
                                <asp:TextBox ID="txt3x" Style="width: 40px" runat="server" />
                            </td>
                            <td style="display: none;">
                                <asp:TextBox ID="txt4x" Style="width: 40px" runat="server" />
                            </td>
                            <td style="display: none;">
                                <asp:TextBox ID="txtjc539" Style="width: 40px" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtss" Style="width: 40px" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
        </table>
        <br />
        <table class="table" style="display: none; width: 100%">
            <tr class="tp_bg">
                <td colspan="15">
                    <table class="table">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">籃球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
                <td style="width: 100%">籃球</td>
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
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtybcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtybcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtybcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtydjrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtydjdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtydjds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqtygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtlqtygj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzbcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzdjrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzdjdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzdjds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtlqdzgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcbcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcdjrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcdjdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcdjds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtlqdcgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單隊上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddrf" Style="width: 50px" runat="server" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdddx" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdddy" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddds" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddbcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdddjrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdddjdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqdddjds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqddgg" Style="width: 60px; display: none;"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox class="hiddeninput" ReadOnly="true" ID="txtlqddgj" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">棒球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
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
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtysy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbtybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdzbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdcsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmbdcbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">网球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
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
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtysy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbtybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdzbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdcsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtrbdcbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">排球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
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
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtysy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbtybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdzbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdcsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txttbdcbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">足球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
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
                <td rowspan="6"></td>
            </tr>
            <tr style="display: none" class="trc">
                <td>
                    <a href="#">退佣設定A盤</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatybcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatybcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatyrqs" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatybd" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatybqc" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqatygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzqatygj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none" class="trc">
                <td>
                    <a href="#">退佣設定B盤</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtybcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtybcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtyrqs" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtybd" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtybqc" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqbtygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzqbtygj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定C盤</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctybcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctybcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctyrqs" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctybd" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctybqc" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqctygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzqctygj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzrqs" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzbd" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzbqc" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzqdzgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcrqs" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcbd" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcbqc" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzqdcgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">美足設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
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
                <td colspan="3" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztybcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztybcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztybcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmztygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtmztygj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzbcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtmzdzgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcbcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtmzdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtmzdcgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">冰球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
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
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtysy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqtybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdzbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdcsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqdcbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">彩球設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
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
                <td colspan="3" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtybcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtybcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtybcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtybcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqtygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtcqtygj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzbcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtcqdzgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcbcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcbcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcbcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcbcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtcqdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtcqdcgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">期指設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
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
                <td colspan="12" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzstyrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzstydx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzstydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzstyds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzstyzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzstyzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzstysy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzstybd" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzstygg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzstygj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdzrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzsdzdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzsdzds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdzzdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdzzddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdzsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdzbd" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdzgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdzgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdcrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzsdcdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzsdcds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdczdrf" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdczddx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdcsy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdcbd" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdcgg" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="display: none;">
                    <asp:TextBox ReadOnly="true" ID="txtzsdcgj" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">賽馬設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
                <td>賽馬</td>
                <td>獨贏</td>
                <td>位置</td>
                <td>連贏</td>
                <td>位置Q</td>
                <td colspan="10" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmtydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmtywz" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmtyly" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmtywzq" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmdzwz" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmdzly" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmdzwzq" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmdcwz" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmdcly" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsmdcwzq" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">六合彩設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
                <td>六合彩</td>
                <td>特別號</td>
                <td>台特</td>
                <td>台號</td>
                <td>全車碰</td>
                <td>2星</td>
                <td>3星</td>
                <td>4星</td>
                <td>固定單雙</td>
                <td>固定大小</td>
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhctytbh" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhctytt" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhctyth" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhctyqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcty2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcty3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcty4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhctygds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhctygdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdztbh" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdztt" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdzth" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdzqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdz2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdz3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdz4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdzgds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdzgdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdctbh" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdctt" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdcth" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdcqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdc2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdc3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdc4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdcgds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlhcdcgdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">大樂透設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
                <td>大樂透</td>
                <td>特別號</td>
                <td>台特</td>
                <td>台號</td>
                <td>全車碰</td>
                <td>2星</td>
                <td>3星</td>
                <td>4星</td>
                <td>固定單雙</td>
                <td>固定大小</td>
                <td colspan="5" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdlttytbh" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdlttytt" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdlttyth" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdlttyqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltty2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltty3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltty4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdlttygds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdlttygdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdztbh" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdztt" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdzth" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdzqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdz2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdz3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdz4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdzgds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdzgdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdctbh" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdctt" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdcth" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdcqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdc2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdc3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdc4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdcgds" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtdltdcgdx" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">今彩539設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
                <td>今彩</td>
                <td>全車碰</td>
                <td>2星</td>
                <td>3星</td>
                <td>4星</td>
                <td colspan="10" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539tyqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539ty2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539ty3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539ty4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539dzqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539dz2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539dz3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539dz4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539dcqcp" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539dc2x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539dc3x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtjc539dc4x" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">運彩設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
                <td>運彩</td>
                <td>棒球彩票</td>
                <td>籃球彩票</td>
                <td>足球彩票</td>
                <td style="display: none">股市彩票</td>
                <td style="display: none">期指彩票</td>
                <td colspan="11" rowspan="3">&nbsp;</td>
            </tr>
            <tr class="trc" style="display: none">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqcpty" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqcpty" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqcpty" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td style="display: none">
                    <asp:TextBox ReadOnly="true" ID="txtgscpty" Style="width: 60px; display: none" runat="server"></asp:TextBox>
                </td>
                <td style="display: none">
                    <asp:TextBox ReadOnly="true" ID="txtzscpty" Style="width: 60px; display: none" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">注数上限(注)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqcpdz" Style="width: 50px" runat="server" onblur="CheckZS(this)"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqcpdz" Style="width: 50px" runat="server" onblur="CheckZS(this)"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqcpdz" Style="width: 50px" runat="server" onblur="CheckZS(this)"></asp:TextBox>
                </td>
                <td style="display: none">
                    <asp:TextBox ReadOnly="true" ID="txtgscpdz" Style="width: 60px; display: none" runat="server"></asp:TextBox>
                </td>
                <td style="display: none">
                    <asp:TextBox ReadOnly="true" ID="txtzscpdz" Style="width: 60px; display: none" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc" style="display: none">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtbqcpdc" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtlqcpdc" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtzqcpdc" Style="width: 50px" runat="server"></asp:TextBox>
                </td>
                <td style="display: none">
                    <asp:TextBox ReadOnly="true" ID="txtgscpdc" Style="width: 60px; display: none" runat="server"></asp:TextBox>
                </td>
                <td style="display: none">
                    <asp:TextBox ReadOnly="true" ID="txtzscpdc" Style="width: 60px; display: none" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="tp_bg">
                <td colspan="15">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../../Images/005.gif" width="14" height="14" alt="" /></td>
                            <td class="td_title">特殊投注設定</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="trc">
                <td>特殊投注</td>
                <td>獨贏</td>
                <td colspan="13" rowspan="4"></td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">退佣設定</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtsstydy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單注上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtssdzdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td>
                    <a href="#">單場上限(萬)</a></td>
                <td>
                    <asp:TextBox ReadOnly="true" ID="txtssdcdy" Style="width: 50px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="trc">
                <td colspan="15">
                    <asp:Button ID="bttjzj" runat="server" Text="添加總監" OnClick="bttjzj_Click" />
                    <asp:Button ID="btfh" runat="server" Text="返回" OnClick="btfh_Click" />
                </td>
            </tr>
        </table>
        <br />
        說明：
                    <ul>
                        <li>如果 "退佣" 為100, 表示每下注一萬元可以得到退佣100元.</li>
                    </ul>
    </div>
</asp:Content>
