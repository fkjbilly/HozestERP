<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFileSeeControl.ascx.cs"
    Inherits="HozestERP.Web.Modules.UploadFileSeeControl" %>
<div>
    <asp:Repeater ID="rpFiles" runat="server">
        <ItemTemplate>
            <div style="float: left; padding-right: 10px;">
                <a href="#" onclick="window.open('<%# CommonHelper.GetStoreLocation()%>ManageFile/GetDownload.ashx?FilePath=../Upload/<%# Eval("Url")%>&Filename=<%# Eval("FullName") %>');return false;"
                    target="_blank" class="linkBlue">
                    <img src="geticon.axd?file=<%# Eval("Url").ToString().Substring(Eval("Url").ToString().LastIndexOf('.'))%>&size=small"
                        alt="<%# Eval("Url").ToString().Substring(Eval("Url").ToString().LastIndexOf('.'))%>" />
                    <%# Eval("FullName") %></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
