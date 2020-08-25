<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="LoginLogs.aspx.cs" Inherits="HozestERP.Web.ManageSystem.LoginLogs" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript" type="text/javascript">
        function ShowDetail(URL) {
            //var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:800px;dialogHeight:600px;center:yes;");
            window.location = URL;
            return true;
        }
    </script>
    <asp:GridView ID="grdvMessage" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerSessionGUID"
        SkinID="GridViewThemen">
        <Columns>
            <asp:TemplateField HeaderText="用户">
                <ItemTemplate>
                    <%# (Container.DataItem as CustomerSession).Customer != null ? (Container.DataItem as CustomerSession).Customer.Username : ""%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="150px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="登陆时间">
                <ItemTemplate>
                    <%#DateTimeHelper.ConvertToUserTime((DateTime)Eval("LogTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="120px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="最后活动时间">
                <ItemTemplate>
                    <%#DateTimeHelper.ConvertToUserTime((DateTime)Eval("LastAccessed"), DateTimeKind.Utc).ToString("yyyy-MM-dd HH:mm:ss")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="120px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="已过期">
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsExpired" runat="server" Checked='<%#Eval("IsExpired")%>' />
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="60px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
