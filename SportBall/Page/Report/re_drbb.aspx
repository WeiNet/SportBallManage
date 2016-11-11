<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="re_drbb.aspx.cs" Inherits="re_drbb" %>

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
    <asp:HiddenField ID="hidjb" runat="server" Value="4" />
    <asp:HiddenField ID="hidzwrq" runat="server" />
    <asp:HiddenField ID="hidzh" runat="server" Value="0" />
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">报表管理</a>  <span
            class="divider">/</span>當日報表查詢
    </ul>
    <div class="title_right">
        <strong>
            <asp:Label ID="lblball" runat="server" Text=""></asp:Label>當日報表查詢</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btcx" runat="server" Text="查詢" CssClass="button" OnClick="btcx_Click" />
                    <asp:Button ID="btLink" runat="server" Text="返回上一級" CssClass="button" OnClick="btLink_Click"></asp:Button>

                </td>
            </tr>
            <tr>
                <td class="trr" style="width: 10%">是否显示拆帐 </td>
                <td class="trl">
                    <asp:CheckBox ID="CheckBoxcz" Text="是否顯示拆帳" runat="server" OnCheckedChanged="CheckBoxcz_CheckedChanged"
                        AutoPostBack="True" />
                </td>
            </tr>
        </table>

        <table class="table" style="width: 100%">
            <tr>
                <td class="trr" style="width: 10%">比賽類型</td>
                <td class="trl">
                    <asp:CheckBox ID="chAll" runat="server" Text="全部" Checked="True" Width="50px" />
                    <asp:CheckBox ID="chbk" runat="server" Text="籃球" Checked="True" Width="50px" />
                    <asp:CheckBox ID="chbj" runat="server" Text="棒球" Checked="True" Width="50px" />
                    <asp:CheckBox ID="chby" runat="server" Text="网球" Checked="True" Width="50px" />
                    <asp:CheckBox ID="chbb" runat="server" Text="排球" Checked="True" Width="50px" />
                    <asp:CheckBox ID="chzq" runat="server" Text="足球" Checked="True" Width="50px" />
                    <asp:CheckBox ID="chbf" runat="server" Text="美足" Checked="True" Visible="false" Width="50px" />
                    <asp:CheckBox ID="chbq" runat="server" Text="冰球" Checked="True" Width="50px" />
                    <asp:CheckBox ID="chcq" runat="server" Text="彩球" Checked="True" Visible="false" Width="50px" />
                    <asp:CheckBox ID="chzs" runat="server" Text="指數" Checked="True" Visible="false" Width="50px" />
                    <asp:CheckBox ID="chsm" runat="server" Text="賽馬" Checked="True" Visible="false" Width="50px" />
                    <asp:CheckBox ID="chlhc" runat="server" Text="六合彩" Checked="True" Visible="false" Width="50px" />
                    <asp:CheckBox ID="chdlt" runat="server" Text="大樂透" Checked="True" Visible="false" Width="50px" />
                    <asp:CheckBox ID="chjc" runat="server" Text="今彩539" Checked="True" Visible="false" Width="50px" />
                    <asp:CheckBox ID="chcp" runat="server" Text="運動彩票" Checked="True" Visible="false" Width="50px" />
                    <asp:CheckBox ID="chss" runat="server" Text="時事" Checked="True" Visible="false" Width="50px" />
                </td>

            </tr>
            <tr>
                <td class="trr" style="width: 10%">帳務日期</td>
                <td>
                    <asp:Label ID="lbzwrq" runat="server" Text=""></asp:Label>
                    &nbsp;
                            <asp:Button ID="btjt" runat="server" Text="今天" CssClass="button" />
                    <asp:Button ID="btzt" runat="server" Text="昨天" CssClass="button" />&nbsp; (<asp:Label ID="lbrq" runat="server"
                        Text=""></asp:Label>前的存帳請至「歷史總帳」查詢)</td>

            </tr>
            <tr>
                <td class="trr" style="width: 10%">下注方式：</td>
                <td class="auto-style1" colspan="3">
                    <asp:DropDownList ID="drwf" runat="server">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="l_rf">讓分</asp:ListItem>
                        <asp:ListItem Value="l_dx">大小</asp:ListItem>
                        <asp:ListItem Value="l_dy">獨贏</asp:ListItem>
                        <asp:ListItem Value="l_ds">單雙</asp:ListItem>
                        <asp:ListItem Value="l_zdrf">滾球讓分</asp:ListItem>
                        <asp:ListItem Value="l_zddx">滾球大小</asp:ListItem>
                        <asp:ListItem Value="l_bd">波膽</asp:ListItem>
                        <asp:ListItem Value="l_bq">半全場</asp:ListItem>
                        <asp:ListItem Value="l_ye">一輸二贏</asp:ListItem>
                        <asp:ListItem Value="l_smdy">賽馬獨贏</asp:ListItem>
                        <asp:ListItem Value="l_ly">連贏</asp:ListItem>
                        <asp:ListItem Value="l_wz">位置</asp:ListItem>
                        <asp:ListItem Value="l_wzq">位置Q</asp:ListItem>
                        <asp:ListItem Value="l_tbh">特別號</asp:ListItem>
                        <asp:ListItem Value="l_th">台號</asp:ListItem>
                        <asp:ListItem Value="l_tt">台特</asp:ListItem>
                        <asp:ListItem Value="l_qcp">全車碰</asp:ListItem>
                        <asp:ListItem Value="l_234">二三四星</asp:ListItem>
                        <asp:ListItem Value="l_gg">過關</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="trr">测试帐号:</td>
                <td class="trl">
                    <asp:RadioButtonList ID="rdoTest" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <cc1:JXGrid ID="JXGrid1" runat="server" AutoGenerateColumns="False" CssClass="grid"
                ShowFooter="false" AllowPaging="false" Width="100%"
                GridViewSortDirection="Ascending" OnRowDataBound="JXGrid1_RowDataBound" OnDataBound="JXGrid1_DataBound">
                <Columns>
                    <asp:TemplateField HeaderText="帳號">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lbzh" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="注單筆數" DataField="COUTS">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="下注金額" DataField="JE">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="會員結果" DataField="n_hyjg" DataFormatString="{0:0}" HtmlEncode="False">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="代理商未拆賬" DataField="n_dlswcz" DataFormatString="{0:0}"
                        HtmlEncode="False">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="代理商結果" DataField="n_dlsjg" DataFormatString="{0:0}" HtmlEncode="False">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="總代理結果" DataField="n_zdljg" DataFormatString="{0:0}" HtmlEncode="False"
                        Visible="false">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="股東結果" DataField="n_gdjg" DataFormatString="{0:0}" HtmlEncode="False"
                        Visible="false">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="大股東結果" DataField="n_dgdjg" DataFormatString="{0:0}" HtmlEncode="False"
                        Visible="false">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="總監結果" DataField="n_zjjg" DataFormatString="{0:0}" HtmlEncode="False"
                        Visible="false">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="大總監結果" DataField="n_dzjjg" DataFormatString="{0:0}" HtmlEncode="False"
                        Visible="false">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="總公司結果" DataField="n_gsjg" DataFormatString="{0:0}" HtmlEncode="False">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="實投注%" DataField="N_STZ" HtmlEncode="False">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="拆賬百分比" DataField="N_ZC" HtmlEncode="False">
                        <ItemStyle Wrap="False" Width="10%" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="n_no" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbqh" runat="server" Text='<%#Bind("qh")%>'></asp:Label>
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
        <asp:Panel ID="Panel2" runat="server" Width="100%">
            <table style="width: 100%">
                <tr>
                    <td class="trc">會員明細 
                        <asp:Label ID="lbhy" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <cc1:JXGrid ID="JXGrid2" runat="server" AutoGenerateColumns="False" CssClass="grid"
                            ShowFooter="false" AllowPaging="false" Width="100%"
                            GridViewSortDirection="Ascending" OnRowDataBound="JXGrid2_RowDataBound">
                            <Columns>
                                <asp:BoundField HeaderText="下注時間" DataField="n_xzrq" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="退水" DataField="n_ty">
                                    <ItemStyle Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="下注單號" DataField="n_xzdh">
                                    <ItemStyle Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="下注內容">
                                    <ItemStyle Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="下注金額" DataField="n_xzje">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="會員結果" DataField="n_hyjg" DataFormatString="{0:0}" HtmlEncode="False">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="代理商未拆賬" DataField="n_dlswcz" DataFormatString="{0:0}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="代理商拆帳%" DataField="n_dlcz" DataFormatString="{0:0}" HtmlEncode="False">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="代理商結果" DataField="n_dlsjg" DataFormatString="{0:0}" HtmlEncode="False">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="總代理拆帳%" DataField="n_zdlcz" DataFormatString="{0:0}"
                                    Visible="false" HtmlEncode="False">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="總代理結果" DataField="n_zdljg" DataFormatString="{0:0}" HtmlEncode="False"
                                    Visible="false">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="股東拆帳%" DataField="n_gdcz" DataFormatString="{0:0}" HtmlEncode="False"
                                    Visible="false">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="股東結果" DataField="n_gdjg" DataFormatString="{0:0}" HtmlEncode="False"
                                    Visible="false">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="大股東拆帳%" DataField="n_zgdcz" DataFormatString="{0:0}"
                                    Visible="false" HtmlEncode="False">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="大股東結果" DataField="n_dgdjg" DataFormatString="{0:0}" HtmlEncode="False"
                                    Visible="false">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="總監拆帳%" DataField="n_zjcz" DataFormatString="{0:0}" HtmlEncode="False"
                                    Visible="false">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="總監結果" DataField="n_zjjg" DataFormatString="{0:0}" HtmlEncode="False"
                                    Visible="false">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="大總監拆帳%" DataField="n_dzjcz" DataFormatString="{0:0}"
                                    Visible="false" HtmlEncode="False">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="大總監結果" DataField="n_dzjjg" DataFormatString="{0:0}" HtmlEncode="False"
                                    Visible="false">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="總公司結果" DataField="n_gsjg" DataFormatString="{0:0}" HtmlEncode="False">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
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
                                        <asp:Label ID="lbn_gsty" runat="server" Text='<%#Bind("n_gsty")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbn_xzwf" runat="server" Text='<%#Bind("n_xzwf")%>'></asp:Label>
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
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
