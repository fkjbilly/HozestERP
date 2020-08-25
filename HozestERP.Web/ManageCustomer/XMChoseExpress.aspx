<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMChoseExpress.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.XMChoseExpress" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">

        var socket;
        var printTaskId;
        var msg = "";
        var json;
        function doConnect(request) {
            var IPConfig = 'ws://10.10.10.39:13528';
            if ((request["task"])["printer"] == "HPRT HLP106S") {
                IPConfig = 'ws://10.10.10.39:13528';
            } else if ((request["task"])["printer"] == "KM-106 Printer") {
                IPConfig = 'ws://127.0.0.1:13528';
            } 
//            else if ((request["task"])["printer"] == "QR-586 LABEL") {
//                IPConfig = 'ws://10.10.10.39:13528';
//            }

            socket = new WebSocket(IPConfig); //('ws://127.0.0.1:13528')
            // 打开Socket
            socket.onopen = function (event) {
                //alert("Websocket准备就绪,连接到客户端成功");
            };

            // 监听消息
            socket.onmessage = function (event) {
                console.log('Client received a message', event);
                var data = JSON.parse(event.data);
                if ("setPrinterConfig" == data.cmd) {
                    if (data["status"] != 'success') {
                        alert("配置打印机失败！");
                    }
                    else {
                        doPrint(json)
                    }
                }
                else if ("print" == data.cmd) {
                    jQuery(function ($) {
                        $.ajax({ url: "xMChoseExpress.ashx",
                            type: "GET",
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            data: "action=Print",
                            success: function (json) {
                                if (json == "1") {
                                    if (msg != "") {
                                        alert(msg);
                                    }
                                    else {
                                        alert("打印成功！"); // + JSON.stringify(data);打印预览pdf
                                    }
                                }
                                else {
                                    alert("没有可打印数据！");
                                }
                            },
                            error: function (x, e) {
                            },
                            complete: function (x) {
                            }
                        });
                    });
                }
                else if ("getDocumentStatus" == data.cmd) {
                    if (data["status"] != 'success') {//
                        var t = data["requestID"].substring(15);
                        msg += "单号：" + t + ",打印失败！<br/>";
                    }
                }
                else {
                    //alert("返回数据:" + JSON.stringify(data));
                }
                if (msg != "") {
                    alert(msg);
                }
            };

            // 监听Socket的关闭
            socket.onclose = function (event) {
                console.log('Client notified socket has closed', event);
            };

            socket.onerror = function (event) {
                alert('无法连接到:' + printer_address);
            };
        }

        function waitForSocketConnection(socket, callback) {
            setTimeout(
            function () {
                if (socket.readyState === 1) {
                    if (callback !== undefined) {
                        callback();
                    }
                    return;
                } else {
                    waitForSocketConnection(socket, callback);
                }
            }, 5);
        }

        function getDocumentStatus() {
            var str = document.getElementById("<%=documentIDs.ClientID %>").value;
            var arr = str.split(",");
            //var a = (1000000 * Math.random()).toString();
            //var b = (1000000 * Math.random()).toString();
            for (var i = 0; i < arr.length; i++) {
                var config = {
                    requestID: arr[i],
                    verson: '1.0',
                    cmd: 'getDocumentStatus',
                    documentIDs: [arr[i]]
                };
                waitForSocketConnection(socket, function () {
                    socket.send(JSON.stringify(config))
                });
            }
        }

        function doSetPrinterConfig(request) {
            json = request;
            doConnect(request);

            var a = (1000000 * Math.random()).toString();
            var b = (1000000 * Math.random()).toString();
            var config = {
                requetid: a + b,
                verson: '1.0',
                cmd: 'setPrinterConfig',
                printer: {
                    name: (request["task"])["printer"],
                    orientation: 'horizontal',
                    duplex: false,
                    offsetLeft: 1,
                    offsetTop: 1,
                    needTopLogo: false,
                    needBottomLogo: false
                }
            };
            waitForSocketConnection(socket, function () {
                socket.send(JSON.stringify(config))
            });
        }

        function doPrint(request) {
            //doConnect();
            //doSetPrinterConfig();

            printTaskId = parseInt(100000 * Math.random());
            (request["task"])["taskID"] = '' + printTaskId;

            waitForSocketConnection(socket, function () {
                socket.send(JSON.stringify(request))
            });

            //getDocumentStatus();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="documentIDs" />
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 100px" align="right">
                    快递公司
                </td>
                <td style="width: 200px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlExpressList" runat="server" Width="97%">
                    </asp:DropDownList>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="确定" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
