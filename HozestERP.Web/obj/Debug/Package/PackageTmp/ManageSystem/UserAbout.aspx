<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="UserAbout.aspx.cs"
    Inherits="HozestERP.Web.UserAbout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <style>
        .SMS
        {
            background: url("../images/write_sms.png") no-repeat scroll center center transparent;
            display: inline-block;
            height: 30px;
            margin-right: 10px;
            width: 100px;
            cursor: pointer;
        }
        .email
        {
            background: url("../images/write_email.png") no-repeat scroll center center transparent;
            display: inline-block;
            height: 30px;
            width: 100px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
        <script language="javascript" type="text/javascript">

            var SendSMSWidnow;
            function ShowDetail() {
                if (SendSMSWidnow == undefined) {
                    SendSMSWidnow = new Ext.Window({
                        title: '发送短信',
                        bodyStyle: 'background:#fff;',
                        closeAction: 'hide',
                        layout: "border",
                        closable: true,
                        width: 700,
                        height: 350,
                        modal: true,
                        maximizable: true,
                        resizable: false,
                        autoScroll: false,
                        plain: true,
                        autoLoad: { showMask: true, scripts: true, url: 'SendSMS.aspx?CustomerID=<%=CustomerID %>&rnd=' + Math.round(), mode: 'iframe', maskMsg: '正在初始化 发送短信，请稍等...' }
                    });
                }
                else {
                    SendSMSWidnow.reload(true);
                }
                SendSMSWidnow.show(document.body);
                return false;
            }
            var SendMailWidnow;

            function ShowWindow() {
                if (SendMailWidnow == undefined) {
                    SendMailWidnow = new Ext.Window({
                        title: '发送邮件',
                        bodyStyle: 'background:#fff;',
                        closeAction: 'hide',
                        layout: "border",
                        closable: true,
                        maximizable: true,
                        width: 700,
                        height: 550,
                        modal: true,
                        resizable: false,
                        autoScroll: false,
                        plain: true,
                        autoLoad: { showMask: true, scripts: true, url: 'SendEmail.aspx?CustomerID=<%=CustomerID %>&rnd=' + Math.round(), mode: 'iframe', maskMsg: '正在初始化 发送邮件，请稍等...' }
                    });
                }
                else {
                    SendMailWidnow.reload(true);
                }
                SendMailWidnow.show(document.body);
                return false;
            }
        </script>
        <table class="detailTable" style="float: left; background-color: White; margin: 5px 5px 5px 5px;"
            border="0" cellspacing="0" cellpadding="3" width="300px">
            <tbody>
                <tr>
                    <th colspan="2" style="text-align: center; height: 20px; font-weight: bold; font-size: 17px;
                        letter-spacing: 10px;">
                        个人信息
                    </th>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="border-bottom: 0">
                        <asp:Image ID="imgProduct" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="height: 25px;">
                        <a class="SMS" onclick="javascript:return ShowDetail();"></a><a class="email" onclick="javascript:return ShowWindow();">
                        </a>
                    </td>
                </tr>
                <tr>
                    <th width="80px" style="text-align: right; height: 20px; padding-right: 5px;">
                        姓名
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        工作岗位
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblJobPost" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        部门
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblDepartment" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        性别
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblGender" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        生日
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblBirthday" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: center; height: 20px;" colspan="2">
                        联系方式(单位)
                    </th>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        单位电话
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblOfficeTel" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        单位传真
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblOfficeFax" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: center; height: 20px;" colspan="2">
                        联系方式(家庭)
                    </th>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        家庭住址
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblAddress" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        家庭邮编
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblPostCode" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        家庭电话
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblHomeTel" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        手机
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblMobilePhone" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        小灵通
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblPHS" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        电子邮件
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblEmail" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        QQ号码
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblQQ" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; height: 20px; padding-right: 5px;">
                        MSN
                    </th>
                    <td style="padding-left: 5px;">
                        <asp:Literal ID="lblMSN" runat="server"></asp:Literal>
                    </td>
                </tr>
            </tbody>
        </table>
        <table class="detailTable" style="background-color: White; margin: 5px 5px 5px 5px;"
            border="0" cellspacing="0" cellpadding="3" width="70%">
            <tbody>
                <tr>
                    <th style="text-align: center; height: 20px; font-weight: bold; font-size: 17px;
                        letter-spacing: 22px;">
                        工作日志
                    </th>
                </tr>
                <%--    <tr>
                    <td width="100%" style="padding-left: 20px; height: 20px;" align="left">
                        <a style="cursor: pointer;">[月报]&nbsp;&nbsp;XXXXXX……&nbsp;(XXX)
                            2012-03-08</a>
                    </td>
                </tr>--%>
                <asp:Panel ID="pnlDiaryData" runat="server">
                    <tr>
                        <td width="100%" style="height: 20px;" align="left">
                            <img src="../images/no-diary.jpg" />
                        </td>
                    </tr>
                </asp:Panel>
            </tbody>
        </table>
        <table class="detailTable" style="background-color: White; margin: 5px 5px 5px 5px;"
            border="0" cellspacing="0" cellpadding="3" width="70%">
            <tbody>
                <tr>
                    <th style="text-align: center; height: 20px; font-weight: bold; font-size: 17px;
                        letter-spacing: 22px;">
                        日程安排
                    </th>
                </tr>
                <asp:Panel ID="pnlNoCalendarData" runat="server">
                    <tr>
                        <td width="100%" style="height: 20px;" align="left">
                            <img src="../images/no-date.jpg" />
                        </td>
                    </tr>
                </asp:Panel>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
