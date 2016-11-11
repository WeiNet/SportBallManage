<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="re_zdxg.aspx.cs" Inherits="re_zdxg" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="report.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            border: 1px solid #96d0e5;
            vertical-align: middle;
            width: 90%;
        }

        table td {
            word-break: keep-all;
            white-space: nowrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <asp:HiddenField ID="delyy" Value="" runat="server" />
    <asp:HiddenField ID="hidupdate" Value="" runat="server" />
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">报表管理</a>  <span
            class="divider">/</span>注单修改
    </ul>
    <div class="title_right">
        <strong>注单修改</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">
            <tr>
                <td class="trr" style="width: 10%">比賽類型</td>
                <td class="trl">
                    <asp:DropDownList ID="drwf" runat="server">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="b_bk">籃球</asp:ListItem>
                        <asp:ListItem Value="b_bj">棒球</asp:ListItem>
                        <asp:ListItem Value="b_by">网球</asp:ListItem>
                        <asp:ListItem Value="b_bb">排球</asp:ListItem>
                        <asp:ListItem Value="b_zq">足球</asp:ListItem>
                        <%--<asp:ListItem Value="b_bf">美足</asp:ListItem>--%>
                        <asp:ListItem Value="b_bq">冰球</asp:ListItem>
                        <%--<asp:ListItem Value="b_cq">彩球</asp:ListItem>
                                    <asp:ListItem Value="b_zs">指數</asp:ListItem>
                                    <asp:ListItem Value="b_sm">賽馬</asp:ListItem>
                                    <asp:ListItem Value="b_lhc">六合彩</asp:ListItem>
                                    <asp:ListItem Value="b_dlt">大樂透</asp:ListItem>
                                    <asp:ListItem Value="b_jc539">今彩539</asp:ListItem>
                                    <asp:ListItem Value="b_cp">運動彩票</asp:ListItem>
                                    <asp:ListItem Value="b_ss">時事</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td class="trr" style="width: 10%">帳務日期</td>
                <td>
                    <asp:DropDownList ID="drzwrq" runat="server">
                        <asp:ListItem Value="0">請選擇帳務日期</asp:ListItem>
                    </asp:DropDownList>
            </tr>
            <tr runat="server" id="tr_xzfs">
                <td class="trr" style="width: 10%">下注方式：</td>
                <td class="auto-style1" colspan="3">
                    <asp:DropDownList ID="drlx" runat="server">
                        <asp:ListItem Value="0">單式+過關</asp:ListItem>
                        <asp:ListItem Value="1">單式</asp:ListItem>
                        <asp:ListItem Value="2">過關</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="trr">修改選項:</td>
                <td class="trl">
                    <asp:DropDownList ID="drzd" runat="server">
                        <asp:ListItem Value="-1">全部</asp:ListItem>
                        <asp:ListItem Value="0">有效注單</asp:ListItem>
                        <asp:ListItem Value="1">已刪除的注單</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btqd" runat="server" Text="查詢" OnClick="btqd_Click" CssClass="button" />&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btqbxg" runat="server" Text="全部修改" OnClientClick="return xiugaiconfirms();"
                                OnClick="btqbxg_Click" CssClass="button" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <cc1:JXGrid ID="JXGrid1" runat="server" AutoGenerateColumns="False" CssClass="grid"
                ShowFooter="false" AllowPaging="false" Width="100%"
                GridViewSortDirection="Ascending" OnRowDataBound="JXGrid1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="下注時間" DataField="n_xzrq" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"
                        HtmlEncode="False" />
                    <asp:BoundField HeaderText="下注單號" />
                    <asp:BoundField HeaderText="會員" DataField="n_hydh" />
                    <asp:BoundField HeaderText="下注內容" />
                    <asp:BoundField HeaderText="注單帳期" />
                    <asp:BoundField HeaderText="比賽帳期" />
                    <asp:BoundField HeaderText="下注金額" DataField="n_xzje" />
                    <asp:BoundField HeaderText="操作" />
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbn_xzdh" runat="server" Text='<%#Bind("n_xzdh")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbn_hyip" runat="server" Text='<%#Bind("n_hyip")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbn_del" runat="server" Text='<%#Bind("n_del")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbn_xzwf" runat="server" Text='<%#Bind("n_xzwf")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbn_gsty" runat="server" Text='<%#Bind("n_gsty")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbn_gglp" runat="server" Text='<%#Bind("n_gglp")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbn_delyy" runat="server" Text='<%#Bind("n_delyy")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="Row1" />
                <SelectedRowStyle CssClass="RowSel" />
                <AlternatingRowStyle CssClass="Row2" />
                <HeaderStyle CssClass="FixedTitleRow" />
                <RowStyle Wrap="false" />
            </cc1:JXGrid>
        </asp:Panel>
    </div>
</asp:Content>
