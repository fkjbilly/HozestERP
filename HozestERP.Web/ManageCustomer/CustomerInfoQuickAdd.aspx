<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="True" CodeBehind="CustomerInfoQuickAdd.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.CustomerInfoQuickAdd"
    EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/UpdateImageControl.ascx" TagName="UpdateImageControl"
    TagPrefix="SHIBR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    //这个可以验证15位和18位的身份证，并且包含生日和校验位的验证。
    //如果有兴趣，还可以加上身份证所在地的验证，就是前6位有些数字合法有些数字不合法。

    function isIdCardNo() {
        var Text = document.getElementById('<%=btnIDNumber.ClientID %>');
        var num = Text.value;
        if (num == "") {
            alert('身份证号不能为空！');
            return false;
        }
        num = num.toUpperCase();
        //身份证号码为15位或者18位，15位时全为数字，18位前17位为数字，最后一位是校验位，可能为数字或字符X。 
        if (!(/(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test(num))) {
            alert('输入的身份证号长度不对，或者号码不符合规定！\n15位号码应全为数字，18位号码末位可以为数字或X。');
            return false;
        }

        //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。 
        //下面分别分析出生日期和校验位 
        var len, re;
        len = num.length;
        if (len == 15) {
            re = new RegExp(/^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})$/);
            var arrSplit = num.match(re);
            //检查生日日期是否正确 
            var dtmBirth = new Date('19' + arrSplit[2] + '/' + arrSplit[3] + '/' + arrSplit[4]);
            var bGoodDay;
            bGoodDay = (dtmBirth.getYear() == Number(arrSplit[2])) && ((dtmBirth.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() == Number(arrSplit[4]));
            if (!bGoodDay) {
                alert('输入的身份证号里出生日期不对！');
                return false;
            }
            else {
                //将15位身份证转成18位 
                //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。 
                var arrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);
                var arrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2');
                var nTemp = 0, i;
                num = num.substr(0, 6) + '19' + num.substr(6, num.length - 6);
                for (i = 0; i < 17; i++) {
                    nTemp += num.substr(i, 1) * arrInt[i];
                }
                num += arrCh[nTemp % 11];
                return num;
            }
        }

        if (len == 18) {
            re = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
            var arrSplit = num.match(re);
            //检查生日日期是否正确 
            var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[4]);
            var bGoodDay;
            bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() == Number(arrSplit[4]));
            if (!bGoodDay) {
                alert(dtmBirth.getYear());
                alert(arrSplit[2]);
                alert('输入的身份证号里出生日期不对！');
                return false;
            }
            else {

                //检验18位身份证的校验码是否正确。 
                //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。 
                var valnum;
                var arrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);
                var arrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2');
                var nTemp = 0, i;
                for (i = 0; i < 17; i++) {
                    nTemp += num.substr(i, 1) * arrInt[i];
                }
                valnum = arrCh[nTemp % 11];
                if (valnum != num.substr(17, 1)) {
                    alert('18位身份证的校验码不正确！应该为：' + valnum);
                    return false;
                }
                return num;
            }
        }
        return false;
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="">
        <tr>
            <td style="width: 8px; height: 8px">
                <asp:HiddenField ID="hidCustomerInfoID" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px">
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px">
            </td>
            <td colspan="16">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
                姓名<font color="red">*</font>：
            </td>
            <td style="width: 200px">
                <SHIBR:SimpleTextBox ID="txtFullName" runat="server" Width="100%" ErrorMessage="姓名为必填."
                    ValidationGroup="ModuleValidationGroup" />
            </td>
            <td>
            </td>
            <td>
                用户名<font color="red">*</font>：
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtUserName" runat="server" Width="100%" ErrorMessage="用户名必填."
                    ValidationGroup="ModuleValidationGroup" />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtUserName$txtValue"
                    OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="ModuleValidationGroup"
                    SetFocusOnError="True" ValidateEmptyText="True" Display="None"></asp:CustomValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="CustomValidator1"
                    HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomRight" />
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
                密码<font color="red">*</font>：
            </td>
            <td style="width: 200px">
                <SHIBR:SimpleTextBox ID="txtPassword" runat="server" Width="100%" ErrorMessage="密码为必填."
                    TextMode="Password" ValidationGroup="ModuleValidationGroup" />
            </td>
            <td>
            </td>
            <td>
                归属部门<font color="red">*</font>：
            </td>
            <td>
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="100%" ValidationGroup="ModuleValidationGroup">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
                角色<font color="red">*</font>：
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlRole" runat="server" Width="100%" ValidationGroup="ModuleValidationGroup">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
                入职日期 ：
            </td>
            <td>
                <SHIBR:DatePicker ID="txtDueday" runat="server" Format="yyyy-MM-dd"></SHIBR:DatePicker>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
                性别 ：
            </td>
            <td>
                <SHIBR:CodeControl ID="ddlGender" runat="server" CodeType="85" EmptyValue="true"
                    Width="100%" />
            </td>
            <td>
            </td>
            <td>
                在职状态：
            </td>
            <td>
                <asp:DropDownList ID="ddlCustomerStatus" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
                身份证号：
            </td>
            <td>
                <asp:TextBox ID="btnIDNumber" runat="server" Width="100%"/>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"  OnClientClick="return isIdCardNo()"
                    OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
        </tr>
    </table>
</asp:Content>
