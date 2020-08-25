<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEditNoUpdatePanel.Master"
    AutoEventWireup="true" CodeBehind="QuestionUploadEdit.aspx.cs" Inherits="HozestERP.Web.ManageProject.QuestionUploadEdit" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEditNoUpdatePanel.Master" %>
<%@ Register Src="~/Modules/UploadFile.ascx" TagName="UploadFile2" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
             <td>                
                   <CRM:UploadFile2 ID="UploadFile" runat="server" TableName="BU_Contract" 
                    Visible="<% $CRMIsActionAllowed:ManageProject.QuestionUploadEdit.UploadFile %>"></CRM:UploadFile2>
                </td>
            </tr>
            <tr>
             <td>                
                   <asp:Button ID="btnRefresh" SkinID="button6" Text="刷新图片" runat="server" 
                       onclick="btnRefresh_Click" />
                </td>
            </tr>
            <tr>
            <td>
            <asp:GridView ID="gvQuestionDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="UploadFileID"
                        SkinID="GridViewThemen">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </EditItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="图片" SortExpression="">
                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <img src='<%# "/Upload/XMQuestionDetailImg/" + Eval("Url") %>' width="100%" height="100%" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            </td>
            </tr>
        </tbody>
    </table>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
</asp:Content>
