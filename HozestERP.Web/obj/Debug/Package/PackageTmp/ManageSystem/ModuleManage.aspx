<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleManage.aspx.cs" Inherits="HozestERP.Web.ManageSystem.ModuleManage" %>

<html>
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript" src="../Script/Menu.js"></script>
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td id="tdTree" style="width: 171px;" nowrap name="fmTitle" align="center" valign="top">
                <table id="a" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                    <tr>
                        <td>
                            <iframe id="IframeTree" scrolling="yes" style="color: Black" frameborder="0" height="100%"
                                marginheight="0" scrolling="no" border="0" marginwidth="0" name="Model" src="ModuleTree.aspx"
                                style="border-top-style: none; border-right-style: none; border-left-style: none;
                                border-bottom-style: none; text-align: center;" width="230px"></iframe>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 7px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 7px; height: 100%">
                    <tr style="width: 7px;">
                        <td class="Split_V">
                        </td>
                    </tr>
                    <tr style="width: 7px;">
                        <td class="Split_V_Bar">
                            <img id="imgSplit" onclick="HideMenu()" src="../../App_Themes/BLUE/Image/hiddenbtn.gif"
                                style="height: 100%; width: 7px; border-width: 0px; cursor: pointer" />
                        </td>
                    </tr>
                    <tr style="width: 7px;">
                        <td class="Split_V">
                        </td>
                    </tr>
                </table>
            </td>
            <td id="tdContent" height=" 100%">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                    <tr>
                        <td height="8" style="line-height: 8px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout: fixed;">
                                <tr>
                                    <td class="Main_Top1" width="4" height="8">
                                        </div>
                                        <td height="8" class="Main_Top2" style="line-height: 8px;">
                                            <td class="Main_Top3" width="7" height="8">
                                                </div>
                                            </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 100%; width: 100%;">
                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="table-layout: fixed;">
                                <tr>
                                    <td>
                                        <iframe id="ModuleContentPage" frameborder="0" height="100%" marginheight="0" marginwidth="0"
                                            scrolling="auto" name="ModuleContentPage" src="ModuleDetails.aspx" style="border-top-style: none;
                                            border-right-style: none; border-left-style: none; border-bottom-style: none;
                                            text-align: center;" width="100%"></iframe>
                                    </td>
                                    <td width="3" style="width: 3px;" class="Main_Right">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="8">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout: fixed;">
                                <tr>
                                    <td class="Main_Top4" width="4" height="8">
                                        <td height="8" class="Main_Top5" style="line-height: 8px;">
                                            <td class="Main_Top6" width="7" height="8">
                                            </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
