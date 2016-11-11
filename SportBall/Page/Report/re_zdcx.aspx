<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="re_zdcx.aspx.cs" Inherits="re_zdcx" %>

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
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">报表管理</a>  <span
            class="divider">/</span>注单查询
    </ul>
    <div class="title_right">
        <strong>注单查询</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">
            <tr>
                <td class="trr" style="width: 10%">比賽類型</td>
                <td class="trl">
                    <asp:DropDownList ID="drwf" runat="server">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="b_bk">籃球</asp:ListItem>
                        <asp:ListItem Value="b_bj" Selected="True">棒球</asp:ListItem>
                        <asp:ListItem Value="b_by">网球</asp:ListItem>
                        <asp:ListItem Value="b_bb">排球</asp:ListItem>
                        <asp:ListItem Value="b_zq">足球</asp:ListItem>
                        <%-- <asp:ListItem Value="b_bf">美足</asp:ListItem>--%>
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
                    </asp:DropDownList></td>

            </tr>
            <tr  runat="server" id="tr_xzfs">
                <td class="trr" style="width: 10%">下注方式：</td>
                <td class="auto-style1" colspan="3">
                    <asp:DropDownList ID="drlx" runat="server">
                        <asp:ListItem Value="0">單式</asp:ListItem>
                        <asp:ListItem Value="1">過關</asp:ListItem>
                        <asp:ListItem Value="2">滾球</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="trr">查詢選項:</td>
                <td class="trl">
                    <asp:DropDownList ID="drzd" runat="server">
                        <asp:ListItem Value="0">有效注單</asp:ListItem>
                        <asp:ListItem Value="1">已刪除的注單</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="trr">是否计算:</td>
                <td class="trl">
                    <asp:DropDownList ID="drpCount" runat="server">
                        <asp:ListItem Value="-1">全部注單</asp:ListItem>
                        <asp:ListItem Value="0">未计算注單</asp:ListItem>
                        <asp:ListItem Value="1">已计算注單</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="trr">是否已經過賬:</td>
                <td class="trl">
                    <asp:RadioButtonList ID="rdon_gz" CssClass="hei" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">未過賬</asp:ListItem>
                        <asp:ListItem Value="1">已過賬</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="trr">查詢條件:</td>
                <td class="trl">
                    <asp:DropDownList ID="drtj" runat="server">
                        <asp:ListItem Value="0">不設條件</asp:ListItem>
                        <asp:ListItem Value="1">下注的帳號為</asp:ListItem>
                        <%-- <asp:ListItem Value="2">下注會員的代理商為</asp:ListItem>
                                    <asp:ListItem Value="3">下注會員的總代理為</asp:ListItem>
                                    <asp:ListItem Value="4">下注會員的股東為</asp:ListItem>
                                    <asp:ListItem Value="5">下注會員的大股東為</asp:ListItem>
                                    <asp:ListItem Value="6">下注會員的總監為</asp:ListItem>
                                    <asp:ListItem Value="7">下注會員的大總監為</asp:ListItem>--%>
                        <asp:ListItem Value="8" Selected="true">下注單號為</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtbh" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btqd" runat="server" Text="查詢" OnClick="btqd_Click" CssClass="button" />
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
                    <asp:BoundField HeaderText="下注金額" DataField="n_xzje" />
                    <asp:BoundField HeaderText="會員結果" DataField="n_hyjg" />
                    <asp:BoundField HeaderText="輸贏結果 " DataField="n_syjg" />
                    <asp:BoundField HeaderText="退佣" DataField="n_ty" />
                    <asp:BoundField HeaderText="公司結果" DataField="n_gsjg" />
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
