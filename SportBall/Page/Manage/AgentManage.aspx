<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="AgentManage.aspx.cs" Inherits="AgentManage" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <asp:HiddenField ID="hidzj" runat="server" />
    <asp:HiddenField ID="hiddgd" runat="server" />
    <asp:HiddenField ID="hidzdl" runat="server" />
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">会员管理</a>  <span
            class="divider">/</span> 总代理管理
    </ul>
    <div class="title_right" runat="server" id="trbj">
        <strong>目前總代理總人數：<asp:Label ID="lbbj" runat="server" />人</strong>
    </div>

    <div style="width: 90%; margin: auto">
        <table class="table">
            <tr>
                <td class="trl" runat="server" id="trsj">股東：<asp:Label ID="lbsj" runat="server" />，
                                目前总代理人數：<asp:Label ID="lbxj" runat="server" />人，
                                已用信用額度：<asp:Label ID="lbm1" runat="server" />，
                                尚有信用額度：<asp:Label ID="lbm2" runat="server" />
                    &nbsp &nbsp &nbsp<asp:Button ID="btnAdd" runat="server" Text="新增總代理" OnClick="Adddgd_Click" CssClass="button" />
                    <asp:Button ID="btnBack" runat="server" Text="返回上級" Visible="false" OnClick="btnBack_Click" CssClass="button" />

                </td>
            </tr>
            <tr style="display: none">
                <td class="trl">
                    <asp:Label ID="lbzj" runat="server" Text="選擇大總監"></asp:Label>
                    <asp:DropDownList ID="drzj" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                                <asp:Label ID="lbdgd" runat="server" Text="選擇總監"></asp:Label>
                    <asp:DropDownList ID="drdgd" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                                <asp:Label ID="Label1" runat="server" Text="選擇大股東"></asp:Label>
                    <asp:DropDownList ID="drgd" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                                <asp:Label ID="Label2" runat="server" Text="選擇股東"></asp:Label>
                    <asp:DropDownList ID="drzdl" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="K1C31">請選擇</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <cc1:JXGrid ID="ZJGrid" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" Width="100%"
            GridViewSortDirection="Ascending" OnDataBound="ZJGrid_DataBound">
            <Columns>
                <asp:BoundField ApplyFormatInEditMode="True" DataField="n_hyzh" HeaderText="總代理帳號">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="n_hymc" HeaderText="總代理名稱">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="n_kyed" HeaderText="信用額度">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="n_syed" HeaderText="剩餘額度">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>

                <asp:BoundField HeaderText="拆賬百分比" Visible="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="代理人數">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="n_hyjrsj" HeaderText="新增日期" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                    HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="n_yxdl" HeaderText="帳號狀況">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="功能">
                    <ItemStyle Wrap="False" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnTY" Text="停用" OnClick="btnOperate_Click"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnJBZL" Text="基本資料設定"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnXXSD" Text="詳細設定"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnCZJL" Text="操作記錄"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnSC" Text="刪除" OnClick="btdel_Click"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnDJ" Text="凍結"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnTZXZ" Text="停止下注" OnClick="btnOperate_Click"></asp:LinkButton>
                        <asp:Label runat="server" ID="lblYXXZ" Text='<%#Bind("n_yxxz")%>' Style="display: none"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="球類遊戲功能">
                    <ItemStyle Wrap="False" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnQXXSD" Text="詳細設定"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="押碼跳動"></asp:BoundField>
                <asp:TemplateField HeaderText="彩票功能">
                    <ItemStyle Wrap="False" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnCXXSD" Text="詳細設定"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="備註">
                    <HeaderStyle Width="8%" />
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
