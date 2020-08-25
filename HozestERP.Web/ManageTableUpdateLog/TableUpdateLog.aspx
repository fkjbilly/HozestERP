<%@ Page Language="C#" 
    AutoEventWireup="true" 
    MasterPageFile="~/MasterPages/Root.Master" 
    CodeBehind="TableUpdateLog.aspx.cs" 
    Inherits="HozestERP.Web.ManageTableUpdateLog.TableUpdateLogForm" %>

<%@ Import Namespace="HozestERP.BusinessLogic.ManageTableLog" %>
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register src="../Modules/DatePicker.ascx" tagname="DatePicker" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 80px">
                    字段名称
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="dropFieldName" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    修改时间
                </td>
                <td style="width: 180px">
                    <uc1:DatePicker ID="dateUpdateDate" runat="server" />
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    修改人
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtOperator" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
     </table>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:GridView ID="gridLogs" runat="server" AutoGenerateColumns="False" 
        SkinID="GridViewThemen"  >
        <Columns >
            <asp:TemplateField HeaderText="字段名称">
                <ItemTemplate>
                    <%# CommonHelper.GetDescription((Container.DataItem as HozestERP.BusinessLogic.ManageTableLog.TableUpdateLog).FieldNameEnum)%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="修改前">
                <ItemTemplate>
                    <%# GetColumnsName((Container.DataItem as HozestERP.BusinessLogic.ManageTableLog.TableUpdateLog).FieldNameEnum, Eval("OrginValue").ToString())%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" ></HeaderStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="修改后">
                <ItemTemplate>
                    <%# GetColumnsName((Container.DataItem as HozestERP.BusinessLogic.ManageTableLog.TableUpdateLog).FieldNameEnum, Eval("NewValue").ToString())%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" ></HeaderStyle>
            </asp:TemplateField>
             <asp:BoundField DataField="UpdateTime" HeaderText="修改时间" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}">
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="130px"></HeaderStyle>
            </asp:BoundField>
             <asp:TemplateField HeaderText="修改人">
                <ItemTemplate>
                    <%# Eval("Operator.FullName")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>