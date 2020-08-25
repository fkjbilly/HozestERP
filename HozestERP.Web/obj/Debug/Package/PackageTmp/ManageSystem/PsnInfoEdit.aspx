<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/CommonEdit.Master" CodeBehind="PsnInfoEdit.aspx.cs" Inherits="HozestERP.Web.ManageSystem.PsnInfoEdit" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
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

    <table class="detailTable" style="float: left; background-color: White; margin: 5px 5px 5px 5px;"
        border="0" cellspacing="0" cellpadding="3" width="99%">
        <tr>
            <th colspan="2" style="text-align: center; font-weight: bold; font-size: 17px;letter-spacing:10px;">
                个人信息
            </th>
        </tr>
        <tr>
            <td width="120">
                姓名：
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" ReadOnly="true" style="background-color:#E0E0E0"> </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                性别：
            </td>
            <td>
                <CRM:CodeControl ID="ddlGender" runat="server" CodeType="85" EmptyValue="true"
                    Width="200" />
            </td>
        </tr>
        <tr>
            <td>
                生日：
            </td>
            <td>
                <SHIBR:DatePicker ID="txtDate" Width="180px" runat="server" Format="yyyy-MM-dd">
                </SHIBR:DatePicker>
            </td>
        </tr>
<%--        <tr>
            <th colspan="2" style="text-align: left; font-weight: bold; font-size: 14px;">
                联系方式
            </th>
        </tr>
        <tr>
            <td>
                单位电话：
            </td>
            <td>
                <asp:TextBox ID="txtOfficeTel" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                单位传真：
            </td>
            <td>
                <asp:TextBox ID="txtOfficeFax" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                手机：
            </td>
            <td>
                <asp:TextBox ID="txtMobilePhone" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                小灵通：
            </td>
            <td>
                <asp:TextBox ID="txtPHS" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td>
                电子邮件：
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                身份证号：
            </td>
            <td>
                <asp:TextBox ID="btnIDNumber" runat="server" Width="200"/>
            </td>
        </tr>
<%--        <tr>
            <td>
                QQ号码：
            </td>
            <td>
                <asp:TextBox ID="txtQQ" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                MSN：
            </td>
            <td>
                <asp:TextBox ID="txtMSN" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="2" style="text-align: left; font-weight: bold; font-size: 14px;">
                家庭信息
            </th>
        </tr>
        <tr>
            <td>
                家庭住址：
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                家庭邮编：
            </td>
            <td>
                <asp:TextBox ID="txtPostCode" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                家庭电话：
            </td>
            <td>
                <asp:TextBox ID="txtHomeTel" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text="保存修改" SkinID="button4" OnClientClick="return isIdCardNo()"
                    onclick="btnSave_Click" />
            </td>
        </tr>
    </table>
    </asp:Content>
