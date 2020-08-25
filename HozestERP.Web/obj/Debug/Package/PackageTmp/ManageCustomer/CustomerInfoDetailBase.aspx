<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoDetailBase.aspx.cs"
    Inherits="HozestERP.Web.ManageCustomer.CustomerInfoDetailBase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
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

<body style="background-color: White;">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" EnableScriptGlobalization="true"
        runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="detailTable" style="float: left; background-color: White; margin: 5px 5px 5px 5px;"
        border="0" cellspacing="0" cellpadding="3" width="99%">
        <tr>
            <th colspan="5" style="text-align: center; font-weight: bold; font-size: 17px; letter-spacing: 10px;">
                个人信息
            </th>
        </tr>
        <tr>
            <td style="padding-left: 20px; width: 100px">
                归属部门<font color="red">*</font>：
            </td>
            <td style="width: 250px" colspan="3">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="200" Height="20">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="ddlDepartment" Font-Name="verdana"
                    Font-Size="9pt" runat="server" Display="None" ErrorMessage="归属部门为必选。" ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
                    HighlightCssClass="validatorCalloutHighlight"  />
                <asp:HiddenField ID="hidCustomerInfoID" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px;">
                工号：
            </td>
            <td>
                <asp:TextBox ID="txtJobNumber" runat="server" Width="200"></asp:TextBox>
            </td>
            <td style="padding-left: 20px; width: 100px">
                序列：
            </td>
            <td>
                <CRM:NumericTextBox ID="txtDisplayOrder" runat="server" PopupPosition="TopRight"
                    Width="200" RangeErrorMessage="请输入正确的整数." RequiredErrorMessage="请输入正确的整数." ValidationGroup="ModuleValidationGroup"
                    MaximumValue="99999" MinimumValue="-99999" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px; width: 100px">
                姓名<font color="red">*</font>：
            </td>
            <td>
                <CRM:SimpleTextBox ID="txtFullName" runat="server" Width="200" ErrorMessage="姓名为必填."
                    ValidationGroup="ModuleValidationGroup" />
            </td>
            <td style="padding-left: 20px; width: 100px">
                性别：
            </td>
            <td>
                <CRM:CodeControl ID="ddlGender" runat="server" CodeType="85" EmptyValue="true"
                    Width="200" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px; width: 100px">
                民族：
            </td>
            <td>
                <CRM:CodeControl ID="dllNationality" runat="server" CodeType="81" EmptyValue="true"
                    Width="200" />
            </td>
            <td style="padding-left: 20px; width: 100px">
                生肖：
            </td>
            <td>
                <CRM:CodeControl ID="dllAnimal" runat="server" CodeType="82" EmptyValue="true"
                    Width="200" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px; width: 100px">
                户籍地：
            </td>
            <td>
                <asp:TextBox ID="txtRegisteredResidence" runat="server" Width="200"></asp:TextBox>
            </td>
            <td style="padding-left: 20px; width: 100px">
                出生日期：
            </td>
            <td>
                <CRM:DatePicker ID="txtBirthday" runat="server" Format="yyyy-MM-dd" Width="200">
                </CRM:DatePicker>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px; width: 100px">
                婚姻状况：
            </td>
            <td>
                <CRM:CodeControl ID="dllMarriage" runat="server" CodeType="83" EmptyValue="true"
                    Width="200" />
            </td>
            <td style="padding-left: 20px; width: 100px">
                血型：
            </td>
            <td>
                <CRM:CodeControl ID="dllBloodType" runat="server" CodeType="84" EmptyValue="true"
                    Width="200" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px; width: 100px">
                政治面貌：
            </td>
            <td>
                <CRM:CodeControl ID="dllPoliticalStatus" runat="server" CodeType="80" EmptyValue="true"
                    Width="200" />
            </td>
            <td style="padding-left: 20px; width: 100px">
                身高：
            </td>
            <td>
                <CRM:NumericTextBox ID="txtStature" runat="server" Width="200" RangeErrorMessage="请输入正确的整数."
                    RequiredErrorMessage="请输入正确的整数." ValidationGroup="ModuleValidationGroup" MaximumValue="999"
                    MinimumValue="0" />
                CM
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px; width: 100px">
                是否生育：
            </td>
            <td>
                <asp:DropDownList ID="dllChildbearing" runat="server" Width="200" CssClass="DropDownList">
                    <asp:ListItem Value="0">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="padding-left: 20px; width: 100px">
                在职状态：
            </td>
            <td>
                <asp:DropDownList ID="ddlCustomerStatus" runat="server" Width="200">
                </asp:DropDownList>
            </td>
        </tr> 
        <tr>
            <td style="padding-left: 20px; width: 100px">
                是否活动：
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" Text="可用" />
            </td>
            <td style="padding-left: 20px; width: 100px">
            身份证号：
            </td>
            <td>
            <asp:TextBox ID="btnIDNumber" runat="server" Width="200"/>
            </td>
        </tr>        
        <tr>
            <td colspan="6" align="center">
                <asp:Button ID="btnSave" runat="server" Text="保存修改" SkinID="button4" ValidationGroup="ModuleValidationGroup" OnClientClick="return isIdCardNo()"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
