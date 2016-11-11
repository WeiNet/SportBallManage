<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="dzjgl.aspx.cs" Inherits="dzjgl" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">

    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">会员管理</a>  <span
            class="divider">/</span>
        大總監管理
    </ul>
    <div class="title_right" runat="server" id="trbj">
        <strong>代理管理</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table">
            <tr>
                <td class="t1">&nbsp;</td>
                <td class="t2" style="padding-top: 4px;">
                    <table class="table" style="width: 100%">
                        <tr>

                            <td class="trl" style="width: 75px;">代理管理</td>
                            <td class="trl" runat="server" id="Td1">目前代理總人數：<asp:Label ID="lbxj" runat="server" CssClass="font_blue"></asp:Label>人</td>
                            <td class="trr" style="width: 180px;">
                                <asp:Button ID="btAddZJ" runat="server" Text="新增大總監" OnClick="btAddZJ_Click" CssClass="button" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="t3">&nbsp;</td>
            </tr>
        </table>

        <cc1:JXGrid ID="ZJGrid" CssClass="grid" Width="100%" runat="server" AutoGenerateColumns="False" OnDataBound="ZJGrid_DataBound"
            GridViewSortDirection="Ascending" GridViewSortExpression="">
            <Columns>
                <asp:BoundField ApplyFormatInEditMode="True" DataField="n_hyzh" HeaderText="大總監賬號">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="n_hymc" HeaderText="大總監名稱">
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
                <asp:BoundField HeaderText="總監人數">
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
                        <asp:LinkButton runat="server" ID="lbtnKG" Text="管理段控管"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnPMD" Text="跑馬燈"></asp:LinkButton>
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
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
            </Columns>
            <RowStyle CssClass="GridCommonItem" HorizontalAlign="Center" />
            <HeaderStyle CssClass="GridCommonHeadBK" />
        </cc1:JXGrid>
    </div>
</asp:Content>
