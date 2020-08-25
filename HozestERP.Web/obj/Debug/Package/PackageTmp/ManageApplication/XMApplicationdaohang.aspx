<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMApplicationdaohang.aspx.cs"
    Inherits="HozestERP.Web.ManageApplication.XMApplicationdaohang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder1" runat="server" Mode="Script">
    </ext:ResourcePlaceHolder>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:TabPanel ID="TabPanel1" Region="Center" EnableTabScroll="true" LayoutOnTabChange="true"
                TabPosition="Top" TabAlign="Left" runat="server">
                <Items>
                    <ext:Panel Title="退换货" ID="PageQuestion" runat="server" Visible="<% $CRMIsActionAllowed:ManageApplication.Daohang.index %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="主管审核" ID="pageQuestionDeal" runat="server" Visible="<% $CRMIsActionAllowed:ManageApplication.Daohang.Sup %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <%--<ext:Panel Title="财务审核" ID="Panel1" runat="server" Visible="<% $CRMIsActionAllowed:ManageApplication.Daohang.Fin %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>--%>
                    <ext:Panel Title="退换货数据分析-客服" ID="PageDataAnalysis" runat="server" Visible="<% $CRMIsActionAllowed:ManageApplication.XMDataAnalysisApplication.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="退换货数据分析-退换货类型" ID="PageDataAnalysisType" runat="server" Visible="<% $CRMIsActionAllowed:ManageApplication.XMDataAnalysisApplicationType.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="退换货统计" ID="PageDataStatistics" runat="server">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
