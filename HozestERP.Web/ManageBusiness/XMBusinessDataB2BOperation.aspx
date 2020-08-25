<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMBusinessDataB2BOperation.aspx.cs"
    Inherits="HozestERP.Web.ManageBusiness.XMBusinessDataB2BOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <ext:Panel Title="B2B管理" ID="pageB2BMamager" runat="server" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMBusinessDataB2BOperation.B2BMamager %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="B2B数据分析-业务员" ID="pageB2BDataBySalePerson" runat="server" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMBusinessDataB2BOperation.pageB2BDataBySalePerson %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="B2B数据分析-业务类型" ID="PageAnalysis" runat="server"  Visible="<% $CRMIsActionAllowed:ManageBusiness.XMBusinessDataB2BOperation.PageAnalysis %>">
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
