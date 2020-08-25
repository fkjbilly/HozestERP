<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="XMLogisticsCost.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMLogisticsCost" %>


<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>

    <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                        <ext:ResourceManager ID="ResourceManager1" runat="server"/>
                    <ext:GridPanel runat="server" ID="GridPanel1" Title="运费管理" Margins="0 0 5 5" Icon="UserSuit" Region="Center" StripeRows="true" AutoScroll="true" Height="580">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" ID ="btnImport" Icon="Add" Text="导入物流信息"></ext:Button>
                                <ext:Button runat="server" ID="btnRefresh" Text="123" Hidden="true">
                                    <Listeners>
                                        <Click Handler="#{StoreWorker}.reload()" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                   <Store>
                        <ext:Store runat="server" ID="StoreWorker" OnRefreshData="Data_Refresh">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID"></ext:RecordField>
                                        <ext:RecordField Name="LogisticsNumber"></ext:RecordField>
                                        <ext:RecordField Name="Fee"></ext:RecordField>
                                        <ext:RecordField Name="ReconciliationTime"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                   <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn />
                            <ext:Column Header="单号" Width="200" DataIndex="LogisticsNumber" />
                            <ext:Column Header="运费" Width="100" DataIndex="Fee" />
                            <ext:DateColumn Header="对账时间" Width="100" DataIndex="ReconciliationTime" Format="yyyy-MM-dd HH:mm"/>
                        </Columns>
                    </ColumnModel>

                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" SingleSelect="true">
                        </ext:RowSelectionModel>
                    </SelectionModel>

                    <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />

            </ext:GridPanel>

    </asp:Content>






