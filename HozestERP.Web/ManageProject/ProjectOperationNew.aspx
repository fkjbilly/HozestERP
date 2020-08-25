<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectOperationNew.aspx.cs"
    Inherits="HozestERP.Web.ManageProject.ProjectOperationNew" %>

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
                    <ext:Panel Title="店铺经营数据概况" ID="PagePRNickManageInfoNew" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.PRNickManageInfoNew.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:P<%--anel Title="营销活动基本信息" ID="pageNickMarketingCampaignInfoNew" runat="server"
                        Visible="<% $CRMIsActionAllowed:ManageProject.NickMarketingCampaignInfoNew.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>--%>
                    <ext:Panel Title="产品管理" ID="pagePRProductManageNew" runat="server"
                        Visible="<% $CRMIsActionAllowed:ManageProject.PRProductManageNew.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="目标值设定" ID="PageTargetOperation" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.TargetOperation.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="达成值数据" ID="PagePRReachedValueOperation" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.PRReachedValueOperation.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <%--<ext:Panel Title="成交分析" ID="PagePRTransactionAnalysisOperation" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.PRTransactionAnalysisOperation.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="转化分析" ID="PagePRTransformationAnalysisOperation" runat="server"
                        Visible="<% $CRMIsActionAllowed:ManageProject.PRTransformationAnalysisOperation.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="淘宝直通车" ID="PageZTCOperation" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.ZTCOperation.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="客服" ID="PageCustomerServiceOperation" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.CustomerServiceOperation.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="淘宝流量" ID="PagePRFlow" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.PRFlows.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="淘宝单品" ID="PagePRSingleProduct" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.PRSingleProduct.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                     <ext:Panel Title="同品牌数据分析"  ID="PageWithBrandsNick" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.WithBrandsNick.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel> 
                    <ext:Panel Title="店铺经营概况分析" ID="PagePRNickManageInfoNewDetail" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.PRNickManageInfoNewDetail.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="店铺退款统计" ID="PagePRNickRefundStatistics" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.PRNickRefundStatistics.PageView %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>--%>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
