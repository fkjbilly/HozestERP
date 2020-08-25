<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="Logs.aspx.cs" Inherits="HozestERP.Web.ManageSystem.Logs" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px">
                日志类型
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlLogType" runat="server" OnSelectedIndexChanged="ddlLogType_SelectedIndexChanged"
                    AutoPostBack="true" />
            </td>
            <td style="width: 40px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 120px">
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnDel" runat="server" Text="清除日志" SkinID="button4" OnClick="btnDel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript" type="text/javascript">
        function ShowDetail(URL) {
            //var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:800px;dialogHeight:600px;center:yes;");
            window.location = URL;
            return true;
        }
    </script>
    <asp:GridView ID="grdvMessage" runat="server" AutoGenerateColumns="False" DataKeyNames="LogID"
        OnRowDataBound="grdvMessage_RowDataBound" SkinID="GridViewThemen" >
        <Columns>
            <asp:TemplateField HeaderText="日志类型">
                <ItemTemplate>
                    <%#CommonHelper.ConvertEnum(((LogTypeEnum)(Eval("LogType"))).ToString())%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户">
                <ItemTemplate>
                    <%# (Container.DataItem as Log).Customer!=null?(Container.DataItem as Log).Customer.Username:""%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"  Width="150px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创建于">
                <ItemTemplate>
                    <%#DateTimeHelper.ConvertToUserTime((DateTime)Eval("CreatedOn"), DateTimeKind.Utc).ToString()%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="120px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="Message" HeaderText="消息">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Wrap="False" ></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="详细">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail1" runat="server" CommandArgument='<%# Eval("LogID") %>'
                        SkinID="btnDetail"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
