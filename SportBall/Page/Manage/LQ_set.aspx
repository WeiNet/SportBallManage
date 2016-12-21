﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_set.aspx.cs" Inherits="LQ_set" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="ZQ_set.js" type="text/javascript"></script>
    <script src="AgentManageAdd.js" type="text/javascript"></script>
    <link href="/Styles/master.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidvalue" runat="server" Value="123" />
        <div>
            <table cellpadding="0" cellspacing="0" border="0" class="green_table" style=" width:100%">
                <tr>
                    <td class="t1">&nbsp;</td>
                    <td class="t2" style="padding-top: 4px;">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    </td>
                                <td class="td_title">球類遊戲——詳細設定</td>
                                <td class="td_title">
                                    <a href="ZQ_set.aspx?UserName=<%=this.GetUser %>" target="_self">足球</a>
                                </td>
                                <td class="td_title">
                                    <a href="LQ_set.aspx?UserName=<%=this.GetUser %>" target="_self">籃球</a>
                                </td>
                                <td class="td_title">
                                    <a href="MZ_set.aspx?UserName=<%=this.GetUser %>" target="_self">美足</a>
                                </td>
                                <td class="td_title">
                                    <a href="MB_set.aspx?UserName=<%=this.GetUser %>" target="_self">棒球</a>
                                </td>
                                <td class="td_title">
                                    <a href="RB_set.aspx?UserName=<%=this.GetUser %>" target="_self">网球</a>
                                </td>
                                <td class="td_title">
                                    <a href="TB_set.aspx?UserName=<%=this.GetUser %>" target="_self">排球</a>
                                </td>
                                <td class="td_title">
                                    <a href="BQ_set.aspx?UserName=<%=this.GetUser %>" target="_self">冰球</a>
                                </td>
                                <td class="td_title">
                                    <a href="CQ_set.aspx?UserName=<%=this.GetUser %>" target="_self">彩球</a>
                                </td>
                                <td class="td_title">
                                    <a href="QZ_set.aspx?UserName=<%=this.GetUser %>" target="_self">期指</a>
                                </td>
                                <td class="td_title">
                                    <a href="SM_set.aspx?UserName=<%=this.GetUser %>" target="_self">赛马</a>
                                </td>
                                <td class="td_title">
                                    <a href="JC_set.aspx?UserName=<%=this.GetUser %>" target="_self">今彩</a>
                                </td>
                                <td class="td_title">
                                    <a href="YC_set.aspx?UserName=<%=this.GetUser %>" target="_self">運彩</a>
                                </td>
                                <td class="td_title">
                                    <a href="SS_set.aspx?UserName=<%=this.GetUser %>" target="_self">特殊投注</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="t3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="t4">&nbsp;</td>
                    <td class="t5">
                        <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #c0de98;">
                            <tr class="tp_bg">
                                <td class="td_title" width="20">
                                    </td>
                                <td class="td_title" width="130">
                                    <asp:Label runat="server" ID="lblDJ"></asp:Label>
                                    ——詳細設定
                                </td>
                                <td class="td_title" width="130">帳號：<asp:Label runat="server" ID="lblName"></asp:Label>
                                </td>
                                <td class="td_title" width="130">名稱：<asp:Label runat="server" ID="lblRealName"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="pt_table">
                            <tr class="colorbg" align="center">
                                <td>籃球</td>
                                <td>退傭</td>
                                <td>大賠率</td>
                                <td>單注限額</td>
                                <td>單場限額</td>
                                <td>單隊限額</td>
                                <td rowspan="2">
                                    <asp:Button runat="server" ID="btnCancle" Text="取消" OnClick="btnCancle_Click"  CssClass="button"/></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>快速選單</td>
                                <td>
                                    <asp:DropDownList runat="server" ID="drptyall" onchange="SetTY(this)">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <select>
                                        <option>8</option>
                                    </select>
                                </td>
                                <td>
                                    <input type="text" class="textbox1" id="txtdzall" onblur="SetSX(this)" /></td>
                                <td>
                                    <input type="text" class="textbox1" id="txtdcall" onblur="SetSX(this)" /></td>
                                <td>
                                    <input type="text" class="textbox1" id="txtddall" onblur="SetSX(this)" /></td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="pt_table">
                            <tr class="colorbg" align="center">
                                <td>籃球</td>
                                <td>退傭</td>
                                <td>單注上限（萬）</td>
                                <td>單場上限（萬）</td>
                                <td>單隊上限（萬）</td>
                                <td style="background-color: White" rowspan="15">
                                    <asp:Button runat="server" ID="btnSave" OnClientClick="return (checkBallInput()&& SetBallAble());"
                                        Text="確定" OnClick="btnSave_Click"  CssClass="button"/>
                                </td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>讓分</td>
                                <td>
                                    <asp:Label ID="lbtyrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzrf" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdzrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdzrft"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcrf" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdcrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdcrft"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddrf" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbddrf" runat="server" Text=""></asp:Label><asp:Label ID="lbddrft"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>大小</td>
                                <td>
                                    <asp:Label ID="lbtydxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptydx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzdx" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdzdx" runat="server" Text=""></asp:Label><asp:Label ID="lbdzdxt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcdx" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdcdx" runat="server" Text=""></asp:Label><asp:Label ID="lbdcdxt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdddx" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdddx" runat="server" Text=""></asp:Label><asp:Label ID="lbdddxt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>獨贏</td>
                                <td>
                                    <asp:Label ID="lbtydyt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptydy">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzdy" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdzdy" runat="server" Text=""></asp:Label><asp:Label ID="lbdzdyt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcdy" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdcdy" runat="server" Text=""></asp:Label><asp:Label ID="lbdcdyt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdddy" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdddy" runat="server" Text=""></asp:Label><asp:Label ID="lbdddyt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>單雙</td>
                                <td>
                                    <asp:Label ID="lbtydst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyds">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzds" runat="server" Text=""></asp:Label><asp:Label ID="lbdzdst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcds" runat="server" Text=""></asp:Label><asp:Label ID="lbdcdst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddds" runat="server" Text=""></asp:Label><asp:Label ID="lbdddst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>滾球讓分</td>
                                <td>
                                    <asp:Label ID="lbtyzdrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyzdrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzzdrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzzdrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdzzdrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdczdrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdczdrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdczdrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddzdrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddzdrf" runat="server" Text=""></asp:Label><asp:Label ID="lbddzdrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>滾球大小</td>
                                <td>
                                    <asp:Label ID="lbtyzddxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyzddx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzzddx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzzddx" runat="server" Text=""></asp:Label><asp:Label ID="lbdzzddxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdczddx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdczddx" runat="server" Text=""></asp:Label><asp:Label ID="lbdczddxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddzddx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddzddx" runat="server" Text=""></asp:Label><asp:Label ID="lbddzddxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>半場讓分</td>
                                <td>
                                    <asp:Label ID="lbtybcrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybcrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzbcrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzbcrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdzbcrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcbcrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcbcrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdcbcrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddbcrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddbcrf" runat="server" Text=""></asp:Label><asp:Label ID="lbddbcrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>半場大小</td>
                                <td>
                                    <asp:Label ID="lbtybcdxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybcdx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzbcdx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzbcdx" runat="server" Text=""></asp:Label><asp:Label ID="lbdzbcdxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcbcdx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcbcdx" runat="server" Text=""></asp:Label><asp:Label ID="lbdcbcdxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddbcdx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddbcdx" runat="server" Text=""></asp:Label><asp:Label ID="lbddbcdxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>半場獨贏</td>
                                <td>
                                    <asp:Label ID="lbtybcdyt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybcdy">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzbcdy" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzbcdy" runat="server" Text=""></asp:Label><asp:Label ID="lbdzbcdyt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcbcdy" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcbcdy" runat="server" Text=""></asp:Label><asp:Label ID="lbdcbcdyt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddbcdy" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddbcdy" runat="server" Text=""></asp:Label><asp:Label ID="lbddbcdyt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>半場單雙</td>
                                <td>
                                    <asp:Label ID="lbtybcdst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybcds">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzbcds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzbcds" runat="server" Text=""></asp:Label><asp:Label ID="lbdzbcdst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcbcds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcbcds" runat="server" Text=""></asp:Label><asp:Label ID="lbdcbcdst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddbcds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddbcds" runat="server" Text=""></asp:Label><asp:Label ID="lbddbcdst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>單節讓分</td>
                                <td>
                                    <asp:Label ID="lbtydjrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptydjrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzdjrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzdjrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdzdjrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcdjrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcdjrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdcdjrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdddjrf" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdddjrf" runat="server" Text=""></asp:Label><asp:Label ID="lbdddjrft" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>單節大小</td>
                                <td>
                                    <asp:Label ID="lbtydjdxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptydjdx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzdjdx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzdjdx" runat="server" Text=""></asp:Label><asp:Label ID="lbdzdjdxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcdjdx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcdjdx" runat="server" Text=""></asp:Label><asp:Label ID="lbdcdjdxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdddjdx" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdddjdx" runat="server" Text=""></asp:Label><asp:Label ID="lbdddjdxt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>單節單雙</td>
                                <td>
                                    <asp:Label ID="lbtydjdst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptydjds">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzdjds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzdjds" runat="server" Text=""></asp:Label><asp:Label ID="lbdzdjdst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcdjds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcdjds" runat="server" Text=""></asp:Label><asp:Label ID="lbdcdjdst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdddjds" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdddjds" runat="server" Text=""></asp:Label><asp:Label ID="lbdddjdst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>過關</td>
                                <td>
                                    <asp:Label ID="lbtyggt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptygg">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzgg" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzgg" runat="server" Text=""></asp:Label><asp:Label ID="lbdzggt" runat="server"
                                            Text="" Style="display: none"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcgg" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcgg" runat="server" Text=""></asp:Label><asp:Label ID="lbdcggt" runat="server"
                                            Text="" Style="display: none"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddgg" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddgg" runat="server" Text=""></asp:Label><asp:Label ID="lbddggt" runat="server"
                                            Text="" Style="display: none"></asp:Label>
                                </td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()" style="display: none">
                                <td>冠軍</td>
                                <td>
                                    <asp:Label ID="lbtygjt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptygj">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzgj" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzgj" runat="server" Text=""></asp:Label><asp:Label ID="lbdzgjt" runat="server"
                                            Text="" Style="display: none"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcgj" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcgj" runat="server" Text=""></asp:Label><asp:Label ID="lbdcgjt" runat="server"
                                            Text="" Style="display: none"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtddgj" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbddgj" runat="server" Text=""></asp:Label><asp:Label ID="lbddgjt" runat="server"
                                            Text="" Style="display: none"></asp:Label>
                                </td>
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
<script type="text/javascript" language="javascript">
    $(function () {
        $(".pt_table tr").find("td:eq(1)").hide();
    });
</script>