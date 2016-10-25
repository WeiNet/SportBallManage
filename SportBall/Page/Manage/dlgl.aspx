<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="dlgl.aspx.cs" Inherits="dlgl" %>

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
        <table class="table">
            <tr>
                <td class="t1">&nbsp;</td>
                <td class="t2" style="padding-top: 4px;">
                    <table class="table" style="width:100%" >
                        <tr>
                           
                            <td  class="trl" style="width:75px;" >代理管理</td>
                            <td class="trl" runat="server" id="Td1">目前代理總人數：<asp:Label ID="lbbj" runat="server" CssClass="font_blue" />人
                            </td>
                            <td class="trl" runat="server" id="trsj">总代理：<asp:Label ID="lbsj" runat="server" CssClass="font_blue" />，
                                目前代理人數：<asp:Label ID="lbxj" runat="server" CssClass="font_blue" />人，
                                已用信用額度：<asp:Label ID="lbm1" runat="server" CssClass="font_blue" />，
                                尚有信用額度：<asp:Label ID="lbm2" runat="server" CssClass="font_blue" />。
                            </td>
                            <td class="trr" style="width:180px;">
                                <asp:Button ID="btnAdd" runat="server" Text="新增代理" OnClick="Adddgd_Click" CssClass="button" />
                                <asp:Button ID="btnBack" runat="server" Text="返回上級" OnClick="btnBack_Click" CssClass="button" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="t3">&nbsp;</td>
            </tr>
            <tr>
                <td class="t4">&nbsp;</td>
                <td class="t5">
                    <table class="table"  style="border: 1px solid #c0de98; width:100%">
                        <tr >
                           
                            <td class="trl">
                                <div style="display: none">
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
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>&nbsp;
                                </div>
                                <asp:Label ID="Label3" runat="server" Text="選擇總代理"></asp:Label>
                                <asp:DropDownList ID="drdl" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="0">請選擇</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <cc1:JXGrid ID="ZJGrid" Width="100%" runat="server" AutoGenerateColumns="False" OnDataBound="ZJGrid_DataBound"
                        GridViewSortDirection="Ascending" GridViewSortExpression="" CssClass="grid" >
                        <Columns>
                            <asp:BoundField ApplyFormatInEditMode="True" DataField="n_hyzh" HeaderText="代理帳號">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="7%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="n_hymc" HeaderText="代理名稱">
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
                            <asp:BoundField HeaderText="會員人數">
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
                        <RowStyle CssClass="GridCommonItem" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="GridCommonHeadBK" />
                    </cc1:JXGrid>
                    <table class="table" style="display: none">
                        <tr class="tr_2">
                            <td>
                                <asp:Label ID="lbps" runat="server" CssClass="hei" Text="說明：無"></asp:Label></td>
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
</asp:Content>
