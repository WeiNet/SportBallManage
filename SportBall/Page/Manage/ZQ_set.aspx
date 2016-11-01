<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZQ_set.aspx.cs" Inherits="ZQ_set" %>

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
                                    &nbsp;</td>
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
                                    &nbsp;</td>
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
                                <td>足球</td>
                                <td>A</td>
                                <td>B</td>
                                <td>C</td>
                                <td>大賠率</td>
                                <td>單注限額</td>
                                <td>單場限額</td>
                                <td rowspan="2">
                                    <asp:Button runat="server" ID="btnCancle" Text="取消" OnClick="btnCancle_Click" CssClass="button" /></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>快速選單</td>
                                <td>
                                    <asp:DropDownList runat="server" ID="drptyaall" onchange="SetTY(this)">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="drptyball" onchange="SetTY(this)">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="drptycall" onchange="SetTY(this)">
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
                            </tr>
                        </table>
                        <br />
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="pt_table">
                            <tr class="colorbg" align="center">
                                <td>足球</td>
                                <td>退傭設定A盤</td>
                                <td>退傭設定B盤</td>
                                <td>退傭設定C盤</td>
                                <td>單注上限（萬）</td>
                                <td>單場上限（萬）</td>
                                <td style="background-color: White;" rowspan="14">
                                    <asp:Button runat="server" ID="btnSave" OnClientClick="return (checkBallInput()&& SetBallAble());"
                                        Text="確定" OnClick="btnSave_Click" CssClass="button" />
                                </td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>讓球</td>
                                <td>
                                    <asp:Label ID="lbtyarft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyarf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycrf">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>大小</td>
                                <td>
                                    <asp:Label ID="lbtyadxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyadx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybdxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybdx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycdxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycdx">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>獨贏</td>
                                <td>
                                    <asp:Label ID="lbtyadyt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyady">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybdyt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybdy">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycdyt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycdy">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>單雙</td>
                                <td>
                                    <asp:Label ID="lbtyadst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyads">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybdst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybds">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycdst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycds">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>滾球讓球</td>
                                <td>
                                    <asp:Label ID="lbtyazdrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyazdrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybzdrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybzdrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtyczdrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyczdrf">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>滾球大小</td>
                                <td>
                                    <asp:Label ID="lbtyazddxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyazddx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybzddxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybzddx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtyczddxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyczddx">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>半場讓球</td>
                                <td>
                                    <asp:Label ID="lbtyabcrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyabcrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybbcrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybbcrf">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycbcrft" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycbcrf">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>半場大小</td>
                                <td>
                                    <asp:Label ID="lbtyabcdxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyabcdx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybbcdxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybbcdx">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycbcdxt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycbcdx">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>半場獨贏</td>
                                <td>
                                    <asp:Label ID="lbtyabcdyt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyabcdy">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybbcdyt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybbcdy">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycbcdyt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycbcdy">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>入球數</td>
                                <td>
                                    <asp:Label ID="lbtyarqst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyarqs">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybrqst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybrqs">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycrqst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycrqs">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzrqs" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzrqs" runat="server" Text=""></asp:Label><asp:Label ID="lbdzrqst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcrqs" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcrqs" runat="server" Text=""></asp:Label><asp:Label ID="lbdcrqst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>波膽</td>
                                <td>
                                    <asp:Label ID="lbtyabdt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyabd">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybbdt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybbd">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycbdt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycbd">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzbd" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzbd" runat="server" Text=""></asp:Label><asp:Label ID="lbdzbdt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcbd" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcbd" runat="server" Text=""></asp:Label><asp:Label ID="lbdcbdt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>半全場</td>
                                <td>
                                    <asp:Label ID="lbtyabqct" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyabqc">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybbqct" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybbqc">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycbqct" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycbqc">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzbqc" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzbqc" runat="server" Text=""></asp:Label><asp:Label ID="lbdzbqct" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdcbqc" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcbqc" runat="server" Text=""></asp:Label><asp:Label ID="lbdcbqct" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>過關</td>
                                <td>
                                    <asp:Label ID="lbtyaggt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyagg">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybggt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybgg">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycggt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycgg">
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
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()"
                                style="display: none">
                                <td>冠軍</td>
                                <td>
                                    <asp:Label ID="lbtyagjt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyagj">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtybgjt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybgj">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbtycgjt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptycgj">
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
        $(".pt_table tr").find("td:eq(2)").hide();
        $(".pt_table tr").find("td:eq(3)").hide();
    });
</script>
