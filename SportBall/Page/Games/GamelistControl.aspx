<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="GamelistControl.aspx.cs" Inherits="GamelistControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 149px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">系统设置</a>  <span
            class="divider">/</span>比赛控管
    </ul>
    <div class="title_right">
        <strong>
            <asp:Label ID="lblball" runat="server" Text=""></asp:Label>比赛控管</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">
            <tr>
                <td style="width: 5%" class="title">
                    <asp:Label ID="lblball1" runat="server" Text=""></asp:Label></td>
                <td class="title"  align="center">讓分
                </td>
                <td class="title"  align="center">大小
                </td>
                <td class="title"  align="center">獨贏
                </td>
                <td class="title"  align="center">單雙
                </td>
                <td class="title"  align="center">滾球讓分
                </td>
                <td class="title"  align="center">滾球大小
                </td>
                <td class="title"  align="center">半場讓分
                </td>
                <td class="title"  align="center">半場大小
                </td>
                <td class="title"  align="center">半場獨贏
                </td>
                <td class="title"  align="center">入球數
                </td>
                <td class="title"  align="center">波膽
                </td>
                <td class="title"  align="center">半全場
                </td>
                <td class="title"  align="center">過關
                </td>
                <td class="title"  align="center">半場讓分大小
                </td>
                <td class="title"  align="center">基準分
                </td>
            </tr>
            <tr align="left">
                <td class="trr">
                    <span>是否開放下注</span></td>
                <td class="trc">
                    <asp:CheckBox ID="chkRFOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkDXOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkDYOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkDSOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkZDRFOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkZDDXOpen" runat="server" /></td>
                <td class="trc"></td>
                <td class="trc"></td>
                <td class="trc"></td>
                <td class="trc">
                    <asp:CheckBox ID="chkRQSOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkBDOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkBQCOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkGGOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkRFDXOpen" runat="server" /></td>
                <td class="trc">
                    <asp:CheckBox ID="chkJZFOpen" runat="server" /></td>
            </tr>
            <tr align="left">
                <td class="trr">
                    <span>會員單隊上限（萬）</span></td>
                <td class="trc">
                    <asp:TextBox ID="txtRFTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDXTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDYTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDSTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDRFTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDDXTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCRFTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCDXTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCDYTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtRQSTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBDTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBQCXTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">總注上限
                                <asp:TextBox ID="txtGGTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtRFDXTop" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc"></td>
            </tr>
            <tr align="left">
                <td class="trr">
                    <span>會員單注上限（萬）</span></td>
                <td class="trc">
                    <asp:TextBox ID="txtRFDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDXDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDYDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDSDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDRFDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDDXDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCRFDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCDXDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCDYDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtRQSDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBDDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBQCXDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">總注上限
                                <asp:TextBox ID="txtGGDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtRFDXDZ" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc"></td>
            </tr>
            <tr align="left">
                <td class="trr">
                    <span>大筆注單(萬）</span></td>
                <td class="trc">
                    <asp:TextBox ID="txtRFSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDXSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDYSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDSSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDRFSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDDXSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCRFSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCDXSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCDYSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtRQSSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBDSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBQCSingle" runat="server" Width="50px" Text="0" onblur="_onlyNum(this);"></asp:TextBox></td>
                <td class="trc"></td>
                <td class="trc"></td>
                <td class="trc"></td>
            </tr>
            <tr align="left">
                <td class="trr">
                    <span>兩邊賠率加總</span></td>
                <td class="trc">
                    <asp:TextBox ID="txtRFRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDXRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDYRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDSRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDRFRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDDXRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCRFRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCDXRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtBCDYRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc"></td>
                <td class="trc"></td>
                <td class="trc"></td>
                <td class="trc"></td>
                <td class="trc"></td>
                <td class="trc"></td>
            </tr>
            <tr align="left">
                <td class="trr">
                    <span>修改</span></td>
                <td class="trc">
                    <asp:Button ID="btnRFUpdate" runat="server" Text="修改" CommandName="RF" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnDXUpdate" runat="server" Text="修改" CommandName="DX" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnDYUpdate" runat="server" Text="修改" CommandName="DY" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnDSUpdate" runat="server" Text="修改" CommandName="DS" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnZDRFUpdate" runat="server" Text="修改" CommandName="ZDRF" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnZDDXUpdate" runat="server" Text="修改" CommandName="ZDDX" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnBCRFUpdate" runat="server" Text="修改" CommandName="BCRF" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnBCDXUpdate" runat="server" Text="修改" CommandName="BCDX" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnBCDYUpdate" runat="server" Text="修改" CommandName="BCDY" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnRQSUpdate" runat="server" Text="修改" CommandName="RQS" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnBDUpdate" runat="server" Text="修改" CommandName="BD" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnBQCUpdate" runat="server" Text="修改" CommandName="BQC" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnGGUpdate" runat="server" Text="修改" CommandName="GG" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnRFDXUpdate" runat="server" Text="修改" CommandName="RFDX" OnClick="btnUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnJZFUpdate" runat="server" Text="修改" CommandName="JZF" OnClick="btnUpdate_Click" CssClass="button" /></td>
            </tr>
            
            <tr align="left">
                <td colspan="19" class="trc">
                    <asp:Button ID="btnModify" runat="server" Text="全部修改" OnClick="btnModify_Click" CssClass="button"/></td>
            </tr>
            <tr align="left">
                <td class="trc" colspan="19">跟盤賠率：讓分差距
                                <asp:TextBox ID="txtRFCJ" runat="server" Width="50px" Text="0"></asp:TextBox>
                    <asp:Button ID="btnRFCJ" runat="server" Text="修改" CommandName="RFCJ" OnClick="btnUpdate_Click" CssClass="button" />
                    大小差距
                                <asp:TextBox ID="txtDXCJ" runat="server" Width="50px" Text="0"></asp:TextBox>
                    <asp:Button ID="btnDXCJ" runat="server" Text="修改" CommandName="DXCJ" OnClick="btnUpdate_Click" CssClass="button" />
                    單雙差距<asp:TextBox ID="txtDSCJ" runat="server" Width="50px" Text="0"></asp:TextBox>
                    <asp:Button ID="btnDSCJ" runat="server" Text="修改" CommandName="DSCJ" OnClick="btnUpdate_Click" CssClass="button" /></td>
            </tr>
        </table>

        <table class="table" style="width: 100%">
            <tr>
                <td colspan="7">
                    <span><span style="width: 40%">&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblballJZ" runat="server" Text=""></asp:Label>兩邊賠率加總控管(跟盤)</span>
                        <span>聯盟：
                                        <asp:DropDownList ID="drpLM" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpLM_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="全部"></asp:ListItem>
                                        </asp:DropDownList>
                            場別：
                                        <asp:DropDownList ID="drpCB" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpCB_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="全部"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="全場"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="上半場"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="下半場"></asp:ListItem>
                                        </asp:DropDownList></span> </span>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" class="title">
                    <asp:Label ID="lblballJZ1" runat="server" Text=""></asp:Label></td>
                <td class="title">讓分</td>
                <td class="title">大小</td>
                <td class="title">獨贏</td>
                <td class="title">單雙</td>
                <td class="title">走地讓分</td>
                <td class="title" >走地大小</td>
            </tr>
            <tr align="left">
                <td class="trr">
                    <span>兩邊賠率加總</span></td>
                <td class="trc">
                    <asp:TextBox ID="txtRFJZRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDXJZRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDYJZRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtDSJZRate" runat="server" onblur="_onlyNum(this);" Text="0" Width="50px"></asp:TextBox></td>
                <td class="trc">
                    <asp:TextBox ID="txtZDRFJZRate" runat="server" onblur="_onlyNum(this);" Text="0"
                        Width="50px"></asp:TextBox></td>
                <td class="trc" class="auto-style1">
                    <asp:TextBox ID="txtZDDXJZRate" runat="server" onblur="_onlyNum(this);" Text="0"
                        Width="50px"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td class="trr">
                    <span>修改</span></td>
                <td class="trc">
                    <asp:Button ID="btnRFJZUpdate" runat="server" Text="修改" CommandName="RF" OnClick="btnJZUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnDXJZUpdate" runat="server" Text="修改" CommandName="DX" OnClick="btnJZUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnDYJZUpdate" runat="server" Text="修改" CommandName="DY" OnClick="btnJZUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnDSJZUpdate" runat="server" Text="修改" CommandName="DS" OnClick="btnJZUpdate_Click" CssClass="button" /></td>
                <td class="trc">
                    <asp:Button ID="btnZDRFJZUpdate" runat="server" Text="修改" CommandName="ZDRF" OnClick="btnJZUpdate_Click" CssClass="button" /></td>
                <td class="trc" class="auto-style1">
                    <asp:Button ID="btnZDDXJZUpdate" runat="server" Text="修改" CommandName="ZDDX" OnClick="btnJZUpdate_Click" CssClass="button" /></td>
            </tr>
            <tr align="left">
                <td colspan="7" class="trc">
                    <asp:Button ID="btnJZModify" runat="server" Text="全部修改" OnClick="btnJZModify_Click" CssClass="button" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
