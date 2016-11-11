<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="creditLog.aspx.cs" Inherits="creditLog" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <script src="creditLog.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">会员管理</a>  <span
            class="divider">/</span>
        额度变化记录
    </ul>
    <div class="title_right" runat="server" id="trbj">
        <strong>额度变化记录</strong>
    </div>
    <input id="hidHYZH" type="hidden" runat="server" />
    <div style="width: 90%; margin: auto">

        <table width="100%" border="0" cellpadding="5" cellspacing="1" class="table" runat="server">

            <tr>
                <td width="12%" class="trr">记录时间：</td>
                <td class="trl">
                    <asp:TextBox ID="txtkjsj" runat="server" size="10"></asp:TextBox>
                    <asp:TextBox ID="txtjssj" runat="server" size="10"></asp:TextBox>
                </td>
                <td width="12%" class="trr">记录类型：</td>
                <td class="trl">
                    <asp:DropDownList ID="drpType1" runat="server">
                        <asp:ListItem Value="-1">全部</asp:ListItem>
                        <asp:ListItem Value="0">下注</asp:ListItem>
                        <asp:ListItem Value="1">状态删单</asp:ListItem>
                        <asp:ListItem Value="2">计算</asp:ListItem>
                        <asp:ListItem Value="3">重新计算</asp:ListItem>
                        <asp:ListItem Value="4">转账</asp:ListItem>
                        <asp:ListItem Value="5">彻底删单</asp:ListItem>
                        <asp:ListItem Value="6">恢复删单</asp:ListItem>
                        <asp:ListItem Value="8">恢复比赛</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="trr">会员帐号：</td>
                <td>
                    <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></td>
                <td class="trr">下注单号：</td>
                <td class="trl">
                    <asp:TextBox ID="txtBillId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="trl" colspan="4">
                    <asp:Button ID="btcx" runat="server" Text="查詢" OnClientClick="return Check();" OnClick="btcx_Click" CssClass="button" /></td>

            </tr>
        </table>
        <br>
        <cc1:JXGrid ID="grvCreditLog" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending" OnRowDataBound="grvCreditLog_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="记录时间" DataField="n_date">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="记录类型" DataField="n_type">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="会员帐号" DataField="n_uid">
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="初始额度" DataField="n_creditbefer">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="结束额度" DataField="n_creitafter">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="额度变化">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="下注单号" DataField="n_xzdh">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="下注金额" DataField="n_xzje">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="初始结果" DataField="n_hyjg_b">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="结束结果" DataField="n_hyjg_a">
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>
    </div>
</asp:Content>
