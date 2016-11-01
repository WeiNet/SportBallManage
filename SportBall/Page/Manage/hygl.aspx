<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="hygl.aspx.cs" Inherits="hygl" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <asp:HiddenField ID="hidzj" runat="server" />
    <asp:HiddenField ID="hiddgd" runat="server" />
    <asp:HiddenField ID="hidzdl" runat="server" />
    <asp:HiddenField ID="hiddl" runat="server" />
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">会员管理</a>  <span
            class="divider">/</span>
    代理管理
    </ul>
    <div class="title_right" runat="server" id="trbj">
        <strong> 代理管理</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table  class="table" style=" width:100%">
            <tr>
                <td class="t1">
                    &nbsp;</td>
                <td class="t2" style="padding-top: 4px;">
                    <table  class="table" style=" width:100%">
                        <tr>
                           
                            <td class="trl"  style=" width:75px">
                                會員管理</td>
                            <td class="trl" runat="server" id="Td1">
                                目前会员總人數：<asp:Label ID="lbbj" runat="server" CssClass="font_blue" />人
                            </td>
                            <td height="22" class="trl" runat="server" id="trsj">
                                代理商：<asp:Label ID="lbsj" runat="server" CssClass="font_blue"></asp:Label>
                                目前代理人數：<asp:Label ID="lbxj" runat="server" CssClass="font_blue"></asp:Label>人 已用信用額度：<asp:Label
                                    ID="lbm1" runat="server" CssClass="font_blue"></asp:Label>
                                尚有信用額度：<asp:Label ID="lbm2" runat="server" CssClass="font_blue"></asp:Label>
                            </td>
                            <td align="right" style=" width:180px">
                                <asp:Button ID="btnAddUser" runat="server" Text="新增會員" OnClick="btnAddUser_Click"
                                    CssClass="button" />
                                <asp:Button ID="btnBack" runat="server" Visible="false" Text="返回上級" OnClick="btnBack_Click" CssClass="button" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="t3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="t4">
                    &nbsp;</td>
                <td class="t5">
                    <table  style="border: 1px solid #c0de98;">
                        <tr >
                        
                            <td class="trl">
                                選擇代理商：<asp:DropDownList ID="drpZJ" runat="server" OnSelectedIndexChanged="drpZJ_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:DropDownList ID="drpDLS" runat="server" OnSelectedIndexChanged="drpDLS_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <cc1:JXGrid ID="grvUserManage" runat="server" AutoGenerateColumns="False" GridViewSortDirection="Ascending"
                        GridViewSortExpression="" Width="100%" OnRowDataBound="grvUserManage_RowDataBound"
                        CellPadding="1" CssClass="grid">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="n_hyzh,n_dldh,n_zdldh,n_gddh,n_dgddh,n_zjdh,n_dzjdh"
                                DataNavigateUrlFormatString="xzhy.aspx?n_hyzh={0}&amp;n_dldh={1}&amp;n_zdldh={2}&amp;n_gddh={3}&amp;n_dgddh={4}&amp;n_zjdh={5}&amp;n_dzjdh={6}"
                                DataTextField="n_hyzh" HeaderText="會員帳號" DataTextFormatString="{0}">
                                <itemstyle horizontalalign="Center" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="n_hymc" HeaderText="會員名稱">
                                <itemstyle horizontalalign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="n_kyed" HeaderText="信用額度">
                                <itemstyle horizontalalign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="n_syed" HeaderText="剩餘額度">
                                <itemstyle horizontalalign="Center" />
                            </asp:BoundField>
                          
                            <asp:BoundField DataField="n_ycxz" HeaderText="比賽類別" Visible="False">
                                <itemstyle horizontalalign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="n_wxdj" HeaderText="會員等級" Visible="False">
                                <itemstyle horizontalalign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="n_hyjr" HeaderText="新增日期" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                HtmlEncode="False">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="n_yxdl" HeaderText="帳號狀況">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="功能">
                                <itemstyle wrap="False" horizontalalign="Center" />
                                <itemtemplate>
                                <asp:LinkButton runat="server" ID="lbtnTY" Text="停用" OnClick="btnOperate_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnJBZL" Text="基本資料設定"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnXXSD" Text="詳細設定"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnCZJL" Text="操作記錄"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnWLJL" Text="往來記錄"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnSC" Text="刪除" onClick="btdel_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnDJ" Text="凍結"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnTZXZ" Text="停止下注"  OnClick="btnOperate_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnTYYH" Text="退傭優惠"></asp:LinkButton>
                                <asp:Label runat="server" ID="lblYXXZ" Text='<%#Bind("n_yxxz")%>' style="display:none" ></asp:Label>
                                <asp:Label runat="server" ID="lblHYZH" Text='<%#Bind("n_hyzh")%>' style="display:none" ></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                              <asp:BoundField DataField="n_zqtz" HeaderText="盤口">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="球類遊戲功能">
                                <itemstyle wrap="False" horizontalalign="Center" />
                                <itemtemplate>
                                <asp:LinkButton runat="server" ID="lbtnQXXSD" Text="詳細設定"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnHYZL" Text="會員資料"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnXJ" Text="現金系統"></asp:LinkButton>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="押碼跳動"></asp:BoundField>
                           <%-- <asp:TemplateField HeaderText="彩票功能">
                                <itemstyle wrap="False" horizontalalign="Center" />
                                <itemtemplate>
                                <asp:LinkButton runat="server" ID="lbtnCXXSD" Text="詳細設定"></asp:LinkButton>
                                </itemtemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <RowStyle CssClass="GridCommonItem" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="GridCommonHeadBK" />
                    </cc1:JXGrid>
                </td>
                <td class="t6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="t7">
                    &nbsp;</td>
                <td class="t8">
                </td>
                <td class="t9">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
