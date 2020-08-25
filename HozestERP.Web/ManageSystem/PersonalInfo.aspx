<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="HozestERP.Web.ManageSystem.PersonalInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .x-grouptabs-expanded .x-grouptabs-expand
        {
            display: none;
        }
        .x-grouptabs-panel
        {
            background-color: #4E78B1;
            border: 2px solid #4E78B1;
        }
    </style>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:GroupTabPanel ID="GroupTabPanel1" runat="server" Region="Center" TabWidth="100"
                ActiveGroupIndex="0">
                <Groups>
                    <ext:GroupTab ID="GroupTab4">
                        <Items>
                            <ext:Panel ID="Panel4" runat="server" Title="个人资料" StyleSpec="padding: 0px;" Layout="Fit">
                                <AutoLoad ShowMask="true" Url="PsnInfoEdit.aspx" Mode="IFrame" MaskMsg="正在初始化 个人资料，请稍等...">
                                </AutoLoad>
                            </ext:Panel>
                        </Items>
                    </ext:GroupTab>
                    <ext:GroupTab ID="GroupTab5">
                        <Items>
                            <ext:Panel ID="Panel2" runat="server" Title="用户头像" StyleSpec="padding: 0px;" Layout="Fit">
                                <AutoLoad ShowMask="true" Url="PsnAvatarEdit.aspx" Mode="IFrame" MaskMsg="正在初始化 头像，请稍等...">
                                </AutoLoad>
                            </ext:Panel>
                        </Items>
                    </ext:GroupTab>
                    <ext:GroupTab ID="GroupTab2">
                        <Items>
                            <ext:Panel ID="Panel3" runat="server" Title="我的账户" StyleSpec="padding: 0px;" Layout="Fit">
                                <AutoLoad ShowMask="true" Url="PsnAccount.aspx" Mode="IFrame" MaskMsg="正在初始化 我的账户，请稍等...">
                                </AutoLoad>
                            </ext:Panel>
                        </Items>
                    </ext:GroupTab>
                    <ext:GroupTab ID="GroupTab1">
                        <Items>
                            <ext:Panel ID="Panel1" runat="server" Title="修改密码" StyleSpec="padding: 0px;" Layout="Fit">
                                <AutoLoad ShowMask="true" Url="PersonSet.aspx" Mode="IFrame" MaskMsg="正在初始化 修改密码，请稍等...">
                                </AutoLoad>
                            </ext:Panel>
                        </Items>
                    </ext:GroupTab>
                </Groups>
            </ext:GroupTabPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
