<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMInstallationListDetails.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMInstallationListDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server"> 
       <asp:GridView ID="gvXMProduct" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            SkinID="GridViewThemen" OnRowDataBound="gvXMProduct_RowDataBound" OnRowCancelingEdit="gvXMProduct_RowCancelingEdit" >

            <Columns>
                <asp:TemplateField HeaderText="安装类型" SortExpression="ShipperName">
                    <HeaderStyle  HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Height="40px" /> 
                    <ItemTemplate>
                            <%# Eval("type")%>
                    <asp:Label ID="lblType" runat="server"></asp:Label> 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="安装要求" SortExpression="Series">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle  /> 
                    <ItemTemplate>
                        <%--<asp:DropDownList ID="ddlDemand" runat="server" Width="100%">
                        </asp:DropDownList>--%> 
                            <asp:RadioButtonList ID="ddlDemand" runat="server" AutoPostBack="true" 
                                OnSelectedIndexChanged="ddlDemand_SelectedIndexChanged" RepeatColumns="5" 
                                RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="金额(元)" SortExpression="Remarks">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" /> 
                    <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" align="center"></asp:Label>    
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="Save" runat="server" Text="保存"  OnClick="btnSave_Click"/> 
</form>
</body>
</html>
