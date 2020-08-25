<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HozestERP.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>宁波市和众互联科技有限公司</title>
    <script type="text/javascript">
        function ShowOpenWindow(strUrl) {
            var aa = window.open(strUrl, '', 'height=' + window.screen.availHeight + ', width=' + window.screen.availWidth + ', top=0, left=0, toolbar=no, menubar=no, scrollbars=yes,resizable=yes, status=yes')
            aa.resizeTo(screen.availWidth, screen.availHeight);
            window.opener = null;
            window.close();
            window.location.href = strUrl;
        }

        function ShowWindow(strUrl) {

            window.location.href = strUrl;
        }
        function ShowModalDialog(paramID) {
            window.open("NotesDetail.aspx?ID=" + paramID, "", "resizable=yes,scrollbars=yes");
        }
    
    
    </script>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
    <div id="formlogin">
        <div class="Login_logo">
        </div>
        <div id="left">
            <div class="R_text">
                <img src="App_Themes/<%=this.Page.Theme %>/image/left_img.gif" />
                <div class="Red_text">
                    <b style="font-size: 14px;">职业生涯开发与管理讲求的是：</b><br />
                    只要开始、永远不晚；<br />
                    只要进步、总有空间；<br />
                    重要的不是目前所处的位置，而是迈出下一步的方向。</div>
            </div>
            <div class="New">
                公司动态</div>
            <ul>
                <%
                    var notices = base.NoticeService.GetStartNotices("", 1, 15);
                    foreach (var item in notices)
                    {
                %>
                <li><a href="javascript:ShowModalDialog('<%=item.ID %>');">
                    <%=Server.HtmlEncode(item.Title) %></a><div class="data">
                        <%=DateTimeHelper.ConvertToUserTime(item.DateTime, DateTimeKind.Utc).ToString("yyyy-MM-dd")%></div>
                </li>
                <%
                    }
                %>
            </ul>
        </div>
        <div id="right">
            <div class="R_text">
                <a href="#">帮助中心</a></div>
            <div class="Login_img">
                <asp:Login runat="server" ID="LoginForm" TitleText="" DestinationPageUrl="~/Default.aspx"
                    RememberMeSet="false" FailureText="用户名或密码输入有误." OnLoggedIn="OnLoggedIn" OnLoggingIn="OnLoggingIn"
                    OnLoginError="OnLoginError">
                    <LayoutTemplate>
                        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="55" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="50" height="30" align="right">
                                    用户名：
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="input" Style="width: 130px;" />
                                    <asp:RequiredFieldValidator ID="UserNameOrEmailRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="用户名是必填." ToolTip="用户名是必填." ValidationGroup="LoginForm">
                                            *
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td height="30" align="right">
                                    密 码：
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" TextMode="Password" runat="server" MaxLength="50" CssClass="input"
                                        Style="width: 130px;" />
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="密码是必填." ToolTip="密码是必填." ValidationGroup="LoginForm">
                                            *
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td height="30" style="width: 55px">
                                    &nbsp;
                                </td>
                                <td height="30">
                                    <asp:Label ID="FailureText" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="35">
                                </td>
                                <td>
                                    <asp:Button ID="LoginButton" runat="server" Text="登 录" class="btn-inp" onmouseover="this.className='btn-inp-on'"
                                        onmouseout="this.className='btn-inp'" value="登 陆" ValidationGroup="LoginForm"
                                        CommandName="Login"/>
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="记住我" ForeColor="red" />
                                </td>
                            </tr>
                            <tr>
                                <td height="23" colspan="2">
                                    如果您忘记密码，请与行政部联系！
                                </td>
                            </tr>
                            <tr>
                                <td height="23" colspan="2">
                                    请每天关注公司的内部通知公告。
                                </td>
                            </tr>
                            
                            <tr>
                                <td height="23" colspan="2" style="padding-right:35px;"><a href="http://download.firefox.com.cn/releases/webins3.0/official/zh-CN/Firefox-latest.exe" style="text-decoration: underline; color:Red;">*建议使用火狐浏览器点击下载</a>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
            </div>
            <div class="faq">
                <div class="New">
                    系统小提示</div>
                <ul>
                    <li><a href="#">如何修改我的个人资料及密码？</a></li>
                    <li><a href="#">如何添加、修改、管理日志。</a></li>
                    <li><a href="#">如何设置自己默认的通告人员。</a></li>
                </ul>
            </div>
        </div>
        <div class="bottom">
            Copyright &copy; 2012 
            宁波市和众互联科技有限公司 Hozest Internet Technology All Rights Reserved.</div>
                    <a rel="nofollow" href="https://www.beian.miit.gov.cn" target="_blank">浙B2-20100026-2</a></div>
    </div>
    </form>
</body>
</html>
