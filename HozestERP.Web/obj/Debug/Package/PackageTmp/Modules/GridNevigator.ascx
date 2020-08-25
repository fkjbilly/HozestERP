<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridNevigator.ascx.cs" Inherits="HozestERP.Web.Modules.GridNevigator" %>

<script language ="javascript">
    function CheckInputPageIndex(GotoId, pageCount) {
        var pageIndex = document.getElementById(GotoId).value;
        if (InputisDigit(pageIndex) && pageIndex != "") {
            if (parseInt(pageIndex) > parseInt(pageCount) || parseInt(pageIndex) <= 0) {
                alert('您输入的数字超出页面有效围');
                return false;
            }
            else {
                return true;
            }
        }
        else {
            alert('请输入正整数');
            return false;
        }
    }
    //校验是否全由数字组成
    function InputisDigit(s) {
        var patrn = /^[+]?[0-9]*$/;
        if (!patrn.exec(s)) return false;
        return true;
    }
</script>

<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td>
            <span id="Navigator1_lblRowsPerPageString" style="font-family: Microsoft Sans Serif">
                每页显示行数
                <asp:DropDownList ID="ddlPageSize" runat="server" Width="59px" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Enabled="False" CssClass="TextBox">
                </asp:DropDownList></span></td>
        <td style="text-align: right">
            <asp:Label ID="lblCurrent" runat="server">0</asp:Label>
            /
            <asp:Label ID="lblPageCount" runat="server">0</asp:Label>
            共
            <asp:Label ID="lblRowsCount" runat="server">0</asp:Label>
            笔
             <asp:ImageButton ID="imgbtnFirst" runat="server" SkinID="NevigatorFirst"  Enabled="false" CommandName="First" OnClick="imgbtn_Click" AccessKey="[" ToolTip="翻到第一页 ALT+[" />&nbsp;
            <asp:ImageButton ID="imgbtnPre" runat="server" SkinID="Nevigatorfront"  Enabled="false" CommandName="Pre" OnClick="imgbtn_Click" AccessKey="," ToolTip="向前翻页 ALT+,"  />&nbsp;
            <asp:ImageButton ID="imgbtnNext" runat="server" SkinID="NevigatorNext"  Enabled="false" CommandName="Next" OnClick="imgbtn_Click" AccessKey="." ToolTip="向后翻页 ALT+."  />&nbsp;
            <asp:ImageButton ID="imgbtnEnd" runat="server" SkinID="NevigatorEnd"  Enabled="false" CommandName="End" OnClick="imgbtn_Click" AccessKey="]" ToolTip="翻到最后一页 ALT+]"  />&nbsp; 转到
            <asp:TextBox ID="txtGoto" runat="server" Width="29px" Enabled="False" CssClass="TextBox" ></asp:TextBox>
            页
            <asp:ImageButton ID="imgbtnGo" runat="server" SkinID="NevigatorGo" Enabled="False"  CommandName="GoTo" OnClick="imgbtn_Click"  />
            &nbsp;</td>
    </tr>
</table>