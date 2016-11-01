<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YC_set.aspx.cs" Inherits="YC_set" %>

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
                                <td>運彩</td>
                                <td style="display: none">退傭</td>
                                <td>大賠率</td>
                                <td>注數上限</td>
                                <td style="display: none">單場限額</td>
                                <td rowspan="2">
                                    <asp:Button runat="server" ID="btnCancle" Text="取消" OnClick="btnCancle_Click"  CssClass="button"/></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>快速選單</td>
                                <td style="display: none">
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
                                <td style="display: none">
                                    <input type="text" class="textbox1" id="txtdcall" onblur="SetSX(this)" /></td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="pt_table">
                            <tr class="colorbg" align="center">
                                <td>運彩</td>
                                <td style="display: none">退傭</td>
                                <td>注數上限（注）</td>
                                <td style="display: none">單場上限（萬）</td>
                                <td style="background-color: White" rowspan="25">
                                    <asp:Button runat="server" ID="btnSave" OnClientClick="return (checkBallInput()&& SetBallAble());"
                                        Text="確定" OnClick="btnSave_Click" CssClass="button" />
                                </td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>棒球彩票</td>
                                <td style="display: none">
                                    <asp:Label ID="lbtybqt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptybq">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzbq" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdzbq" runat="server" Text=""></asp:Label><asp:Label ID="lbdzbqt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td style="display: none">
                                    <asp:TextBox CssClass="textbox1" ID="txtdcbq" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdcbq" runat="server" Text=""></asp:Label><asp:Label ID="lbdcbqt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>籃球彩票</td>
                                <td style="display: none">
                                    <asp:Label ID="lbtylqt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptylq">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzlq" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdzlq" runat="server" Text=""></asp:Label><asp:Label ID="lbdzlqt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td style="display: none">
                                    <asp:TextBox CssClass="textbox1" ID="txtdclq" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdclq" runat="server" Text=""></asp:Label><asp:Label ID="lbdclqt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>足球彩票</td>
                                <td style="display: none">
                                    <asp:Label ID="lbtyzqt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyzq">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzzq" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdzzq" runat="server" Text=""></asp:Label><asp:Label ID="lbdzzqt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                                <td style="display: none">
                                    <asp:TextBox CssClass="textbox1" ID="txtdczq" runat="server"></asp:TextBox>
                                    &lt;=<asp:Label ID="lbdczq" runat="server" Text=""></asp:Label><asp:Label ID="lbdczqt"
                                        runat="server" Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>股市彩票</td>
                                <td style="display: none">
                                    <asp:Label ID="lbtygst" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptygs">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzgs" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzgs" runat="server" Text=""></asp:Label><asp:Label ID="lbdzgst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td style="display: none">
                                    <asp:TextBox CssClass="textbox1" ID="txtdcgs" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcgs" runat="server" Text=""></asp:Label><asp:Label ID="lbdcgst" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                            </tr>
                            <tr class="colorbg" align="center" onmouseover="changeto()" onmouseout="changeback()">
                                <td>期指彩票</td>
                                <td style="display: none">
                                    <asp:Label ID="lbtyqzt" runat="server" Text="" Style="display: none"></asp:Label>
                                    <asp:DropDownList runat="server" ID="drptyqz">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtdzqz" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdzqz" runat="server" Text=""></asp:Label><asp:Label ID="lbdzqzt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
                                <td style="display: none">
                                    <asp:TextBox CssClass="textbox1" ID="txtdcqz" runat="server"></asp:TextBox>&lt;=<asp:Label
                                        ID="lbdcqz" runat="server" Text=""></asp:Label><asp:Label ID="lbdcqzt" runat="server"
                                            Text="" Style="display: none"></asp:Label></td>
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
