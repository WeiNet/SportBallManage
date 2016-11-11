<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="re_mfyproblembet.aspx.cs" Inherits="re_mfyproblembet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="report.js" type="text/javascript"></script>
    <link href="../../Styles/master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%" class="table">
                <tr>
                    <td colspan="2" class="title">问题注单
                    </td>
                </tr>
                <tr>
                    <td class="trr" style="width: 10%">类型 
                    </td>
                    <td class="trl">
                        <asp:Label runat="server" ID="lblType"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="trr">单号</td>
                    <td class="trl">
                        <asp:Label runat="server" ID="lblDH"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="trr">注单内容</td>
                    <td class="trl">
                        <asp:TextBox runat="server" ID="txtNR" TextMode="MultiLine" Width="550px" Height="150px"></asp:TextBox><span style="color: Red">(*注单内容只需修改球头，其他不要修改)</span>
                    </td>
                </tr>
                <tr>
                    <td class="trr">分数</td>
                    <td class="trl"><asp:TextBox runat="server" ID="txtFS"  onkeypress="return inputNubmer()" onblur="_onlyNum2(this);"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="trr">类型</td>
                    <td class="trl"><asp:TextBox runat="server" ID="txtXT" onblur="Check_Int_Field(this)" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="trr">比率</td>
                    <td class="trl"><asp:TextBox runat="server" ID="txtBL"  onkeypress="return inputNubmer()" onblur="_onlyNum2(this);"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnSubmit" Text="修改" OnClick="btnSubmit_Click"  CssClass="button"  OnClientClick="return checkSubmit();"/><asp:Button runat="server" ID="btnCancel"  Text="返回" OnClick="btnCancel_Click" CssClass="button"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
