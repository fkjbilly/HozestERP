<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMprojectCostDetailAdd.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMprojectCostDetailAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .FloatRight
        {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hiddAllID" runat="server" ViewStateMode="Enabled" />
    <asp:HiddenField ID="hiddAllCost" runat="server" ViewStateMode="Enabled" />
    <asp:HiddenField ID="hiddType" runat="server" ViewStateMode="Enabled" />
    <table>
        <tr>
            <td valign="top" style="border-right: none;">
                <div style="height: 100%; width: 100%;" id="DivFrozen">
                    <%=TableStr %>
                </div>
            </td>
            <td valign="top" style="border-left: none;">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 400px;">
            </td>
            <td style="width: 10px">
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMprojectCostDetailAdd.Save %>"
                    OnClick="btnSave_Click" CssClass="FloatRight" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function trim(str) {
            return str.replace(/(^\s+)|(\s+$)/g, "");
        }
        var t = '';
        var c = '';
        $("input[name='dd']").each(function () {
            t = t + $(this).prev().val() + ',';
            c = c + $(this).val() + ',';
        });
        document.getElementById("<%=hiddAllID.ClientID %>").value = t;
        document.getElementById("<%=hiddAllCost.ClientID %>").value = c;
        $("input[name='dd']").change(function () {
            var type = document.getElementById("<%=hiddType.ClientID %>").value;
            var sum = 0;
            var c = $(this).val();
            if (c.length > 11) {
                alert('输入数字过长，请重新输入！');
                return;
            }
            if (isNaN($(this).val())) {
                alert('输入格式不正确，请重新输入！');
                return;
            }
            var d = $(this).prev().val();     //id
            $.ajax({ url: "XMField.ashx?Id=" + d,
                type: "GET",
                dataType: "json",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    var parentID = '';
                    $("input[name='dd']").each(function () {
                        for (var i = 0; i < json.length; i++) {
                            if ($(this).prev().val() == json[i]["Id"]) {
                                parentID = json[i]["ParentId"];
                                sum = sum + Number($(this).val());
                            }

                        }
                    });
                    var ids = '';
                    var costs = '';
                    $("input[name='dd']").each(function () {
                        if ($(this).prev().val() == parentID) {
                            $(this).val(sum.toFixed(2).toString());
                        }
                    });

                    $("input[name='dd']").each(function () {
                        ids = ids + $(this).prev().val() + ',';
                        costs = costs + $(this).val() + ',';
                    });
                    document.getElementById("<%=hiddAllID.ClientID %>").value = ids;
                    document.getElementById("<%=hiddAllCost.ClientID %>").value = costs;
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            });

            //自动计算
            if (type == '0') {                            //项目（喜临门，利豪等）
                //计算增值税  增值税 ： （营业收入-进货成本）/1.17*0.17 - （平台成本费用+广告费+运费）/1.06*0.06
                var yysu = '';     //营业收入
                var jhcb = '';     //进货成本
                var ptfy = '';     //平台成本费用
                var ggf = '';      //广告费
                var yf = '';        //运费
                var yycb = '';    //营业成本
                var zzjg = '';     //直接人工
                var qtfy = '';     //其他费用
                var ggfbt = '';   //广告费补贴
                $("input[id='hiddID']").each(function () {
                    if ($(this).val().indexOf("营业收入") > 0) {
                        yysu = $(this).prev().val();
                    }
                    if ($(this).val().indexOf("进货成本") > 0) {
                        jhcb = $(this).prev().val();
                    }

                    if ($(this).val().indexOf("平台成本费用") > 0) {
                        ptfy = $(this).prev().val();
                    }
                    if (trim($(this).val()) == "广告费") {
                        ggf = $(this).prev().val();
                    }
                    if ($(this).val().indexOf("运费") > 0) {
                        yf = $(this).prev().val();
                    }
                    if ($(this).val().indexOf("营业成本") > 0) {
                        yycb = $(this).prev().val();
                    }

                    if ($(this).val().indexOf("直接人工") > 0) {
                        zzjg = $(this).prev().val();
                    }
                    if ($(this).val().indexOf("其他费用") > 0) {
                        qtfy = $(this).prev().val();
                    }
                    if ($(this).val().indexOf("广告费补贴") > 0) {
                        ggfbt = $(this).prev().val();
                    }

                });

                //增值税计算公式
                var zzs = (Number(yysu) - Number(jhcb)) / 1.17 * 0.17 - (Number(ptfy) + Number(ggf) + Number(yf)) / 1.06 * 0.06;           //增值税
                var maoli = Number(yysu) - Number(zzs) - Number(yycb);                         //毛利
                var yyesjfj = Number(zzs) * 0.12 + Number(yysu) / 1.17 * 0.001;               // 营业税金及附加
                $("input[id='hiddID']").each(function () {
                    if ($(this).val().indexOf("增值税") > 0) {
                        $(this).prev().val(zzs.toFixed(2));
                    }
                    if ($(this).val().indexOf("毛利") > 0) {
                        $(this).prev().val(maoli.toFixed(2));
                    }
                    if ($(this).val().indexOf("营业税及附加") > 0) {
                        $(this).prev().val(yyesjfj.toFixed(2));
                    }
                });
                //税前利润 = 毛利 - 直接人工-其他费用 - 营业税金及附加 + 广告补贴
                var sqlr = Number(maoli) - Number(zzjg) - Number(qtfy) - Number(yyesjfj) + Number(ggfbt);                         //税前利润
                $("input[id='hiddID']").each(function () {
                    if ($(this).val().indexOf("税前利润") > 0) {
                        $(this).prev().val(sqlr.toFixed(2));
                    }
                });
            }

            if (type == '1') {                              //B2B或B2C
                //所得税
                var sds = '';     //所得税
                var yyyje = '';   //营业业绩额
                var zzs = '';      //增值税
                var yysfj = '';   //营业税及附加
                var maoli = '';   //毛利
                var yycb = '';    //营业成本
                var sqlr = '';      //税前利润
                var yyfy = '';     //营业费用
                var zxjlr = '';      //直销净利润
                $("input[id='hiddID']").each(function () {
                    if ($(this).val().indexOf("营业业绩额") > 0) {
                        yyyje = $(this).prev().val();
                    }
                    if ($(this).val().indexOf("营业成本") > 0) {
                        yycb = $(this).prev().val();
                    }
                    if ($(this).val().indexOf("营业费用") > 0) {
                        yyfy = $(this).prev().val();
                    }
                });
                sds = Number(yyyje) * 0.25;         //所得税公式  营业业绩额*0.25
                zzs = Number(yyyje) / 1.06 * 0.06;                                   //增值税公式   营业业绩额/1.06*0.06
                yysfj = Number(zzs) * 0.12 + Number(yyyje) / 1.06 * 0.001;        //   公式         增值税 * 0.12 + 营业业绩额 / 1.06 * 0.001
                maoli = Number(yyyje) - Number(yycb) - Number(zzs);               // 毛利         营业业绩额 - 营业成本 - 增值税 
                sqlr = Number(maoli) - Number(yyfy) - Number(yysfj);               //税前利润    毛利-营业费用-营业税及附加
                zxjlr = sqlr - sds;                                                                                 //直销净利润 = 税前利润-所得税
                $("input[id='hiddID']").each(function () {
                    if ($(this).val().indexOf("所得税") > 0) {
                        $(this).prev().val(sds.toFixed(2));
                    }
                    if ($(this).val().indexOf("增值税") > 0) {
                        $(this).prev().val(zzs.toFixed(2));
                    }
                    if ($(this).val().indexOf("营业税及附加") > 0) {
                        $(this).prev().val(yysfj.toFixed(2));
                    }
                    if (trim($(this).val()) == "毛利") {
                        $(this).prev().val(maoli.toFixed(2));
                    }
                    if ($(this).val().indexOf("税前利润") > 0) {
                        $(this).prev().val(sqlr.toFixed(2));
                    }
                    if ($(this).val().indexOf("直销净利润") > 0) {
                        $(this).prev().val(zxjlr.toFixed(2));
                    }
                });
            }



            var t = '';
            var c = '';
            $("input[name='dd']").each(function () {
                t = t + $(this).prev().val() + ',';
                c = c + $(this).val() + ',';
            });
            document.getElementById("<%=hiddAllID.ClientID %>").value = t;
            document.getElementById("<%=hiddAllCost.ClientID %>").value = c;
        });

     
    </script>
</asp:Content>
