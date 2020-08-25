<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMLogisticsStatistics.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMLogisticsStatistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
        <ext:Panel ID="Panel1"
                    runat="server"
                    Region="North"
                    Title="查询"
                    AutoHeight="true"
                    Padding="5"
                    Frame="true"
                    Layout="ColumnLayout"
                    Icon="Information">
            <Content>
                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                    <tr>
                        <td style="width: 5px; text-align: left">
                            开始时间
                        </td>
                        <td style="width: 20px">
                            <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                                runat="server" style="width: 100%;" />
                        </td>
                        <td style="width: 5px; text-align: center">
                            <span>结束时间</span>
                        </td>
                        <td style="width: 20px">
                            <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                                runat="server" style="width: 100%;" />
                        </td>
                        <td style="width: 5px; text-align: center">
                            <span>物流公司</span>
                        </td>
                        <td style="width: 20px">
                            <asp:DropDownList ID="ddlLogisticsCompany" runat="server" Width="100%">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 50px">
                            <asp:Button runat="server" ID="searchbtn" Text="查询" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </Content>
        </ext:Panel>
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            Frame="true"
            StripeRows="true"
            AutoExpandColumn="DepName" 
            Collapsible="true"
            AnimCollapse="false"
            Icon="ApplicationViewColumns"
            TrackMouseOver="false" AutoHeight="true"
            >
            <Store>
                <ext:Store runat="server" GroupField="DepName">
                    <Reader>
                        <ext:JsonReader IDProperty="ProjectID">
                            <Fields>
                                <ext:RecordField Name="DepID" />
                                <ext:RecordField Name="DepName" />
                                <ext:RecordField Name="ProjectID" />
                                <ext:RecordField Name="ProjectName" />
                                <ext:RecordField Name="PackageNum" Type="Int" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:GroupingSummaryColumn
                        ColumnID="ProjectName" 
                        Header="Task" 
                        Sortable="true" 
                        DataIndex="ProjectName" 
                        Hideable="false"
                        SummaryType="Count">
                        <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' Tasks)' : '(1 Task)');" /> 
                    </ext:GroupingSummaryColumn>

                    <ext:Column ColumnID="DepName" Header="Dep" DataIndex="DepName"/>

                    <ext:GroupingSummaryColumn
                        Width="150"
                        ColumnID="PackageNum" 
                        Header="快递数量" 
                        Sortable="true" 
                        DataIndex="PackageNum" 
                        SummaryType="Sum">

                        <Renderer Handler="return value +' 件';" />
                    </ext:GroupingSummaryColumn>
                </Columns>
            </ColumnModel>
            <View>
                <ext:GroupingView 
                    ID="GroupingView1"  
                    runat="server" 
                    ForceFit="true"
                    MarkDirty="false"
                    ShowGroupName="false"
                    EnableNoGroups="true"
                    HideGroupedColumn="true"
                    />
            </View>  
            <Plugins>
                <ext:HybridSummary ID="RemoteSummary1" runat="server">
                    <Calculations>
                        <ext:JFunction Name="totalCost" Handler="return v + record.data.PackageNum;" />
                    </Calculations>
                </ext:HybridSummary>
            </Plugins>
        </ext:GridPanel>

        <ext:Panel runat="server" Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="导出数据" Icon="ControlStartBlue">
                    <DirectEvents>
                        <Click OnEvent="DataExport_Click" IsUpload="true">

                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
