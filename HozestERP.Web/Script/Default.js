
function nodeLoad(node) {
    CompanyX.NodeLoad(node.id, {
        success: function (result) {
            var data = eval("(" + result + ")");
            node.loadNodes(data);
        },

        failure: function (errorMsg) {
            Ext.Msg.alert('Failure', errorMsg);
        }
    });
}
var addTab = function (tabPanel, id, url, title, iconCls) {
    var tab = tabPanel.getComponent(id);

    if (!tab) {
        tab = tabPanel.add({
            id: id,
            title: title,
            closable: true,
            iconCls: iconCls,
            autoLoad: {
                showMask: true,
                url: url,
                mode: "iframe",
                maskMsg: "正在初始化 " + title + "，请稍等..."
            }
        });
    }
    tabPanel.setActiveTab(tab);
}

var newTab = function (id, url, title) {
    var tabPanel = Ext.getCmp("TabPanel1");
    var tab = tabPanel.getComponent(id);
    if (!tab) {
        tab = tabPanel.add({
            id: id,
            title: title,
            closable: true,
            iconCls: "filesw",
            autoLoad: {
                showMask: true,
                url: url,
                mode: "iframe",
                maskMsg: "正在初始化 " + title + "，请稍等..."
            }
        });
    }
    tabPanel.setActiveTab(tab);
}

var newTabShort = function (id, url, title, iconCls) {
    var tabPanel = Ext.getCmp("TabPanel1");
    var tab = tabPanel.getComponent(id);
    if (!tab) {
        tab = tabPanel.add({
            id: id,
            title: title,
            closable: true,
            iconCls: iconCls,
            autoLoad: {
                showMask: true,
                url: url,
                mode: "iframe",
                maskMsg: "正在初始化 " + title + "，请稍等..."
            }
        });
    }
    tabPanel.setActiveTab(tab);
}


function Go(tag) {
    if (tag == "refresh") {
        Ext.getCmp("TabPanel1").getActiveTab().reload(true);
    }
    else if (tag == "full") {

        window.open(Ext.getCmp("TabPanel1").getActiveTab().autoLoad.url);
    }
}

var OnlineUserStatusWindow;
/// <summary>
/// 显示在线状态层
/// </summary>
var SetOnlineUserStatus = function () {
    if (OnlineUserStatusWindow == undefined) {
        OnlineUserStatusWindow = new Ext.Window({
            title: '在线人员列表',
            bodyStyle: 'background:#fff;',
            closeAction: 'hide',
            iconCls: "online",
            layout: "border",
            closable: true,
            width: 206,
            height: 409,
            resizable: false,
            autoScroll: false,
            plain: true,
            border: false,
            autoLoad: { showMask: true, scripts: true, url: 'ShowOnlineUser.aspx?rnd=' + Math.round(), mode: 'iframe', maskMsg: '正在初始化 在线人员列表，请稍等...' }
        });
    }
    else {
        OnlineUserStatusWindow.reload(true);
    }
    OnlineUserStatusWindow.show(document.body);
    return false;
};

var OnlineUserTask = function () {
    try {
        var result = CompanyX.OnlineUserService({
            success: function (result) {

                var noteLnk = document.getElementById('lnkOnlineUser');
                if (result > 0) {
                    noteLnk.style.color = "Red";
                    noteLnk.innerHTML = "在线(" + result + ")";
                }
                else {
                    noteLnk.style.color = "#EDD8D5";
                    noteLnk.innerHTML = "在线(" + result + ")";
                }
            },

            failure: function (errorMsg) {
                //Ext.Msg.alert('Failure', errorMsg);
            }
        });
    }
    catch (e) {
    }
}

var contractApprovalTask = function () {
    try {
        var result = CompanyX.contractApprovalService();
    }
    catch (e) {
    }
}
//
// 弹出对话框
//
var PoPWindowDetail;
function ExtWindowDetail(title, url, width, height, paramThis, paramFunction) {
    PoPWindowDetail = new window.top.Ext.Window({
        title: title,
        bodyStyle: 'background:#fff;',
        closeAction: 'close',
        layout: "border",
        closable: true,
        width: width,
        height: height,
        modal: true,
        resizable: true,
        maximizable: true,
        autoScroll: false,
        plain: true,
        autoLoad: { showMask: true, scripts: true, url: url, mode: 'iframe', maskMsg: '正在初始化 ' + title + '，请稍等...' }
    });

    PoPWindowDetail.on("close", function () {
        if (paramFunction != undefined) {
            paramFunction();
        }
    });
    PoPWindowDetail.on("hide", function () {
        if (paramFunction != undefined) {
            paramFunction();
        }
    });
    PoPWindowDetail.show(paramThis);
    return false;
}

function ExtWindowDetail1(id,title, url, width, height, paramThis, paramFunction) {
    PoPWindowDetail = new window.top.Ext.Window({
        id:id,
        title: title,
        bodyStyle: 'background:#fff;',
        closeAction: 'close',
        layout: "border",
        closable: true,
        width: width,
        height: height,
        modal: true,
        resizable: true,
        maximizable: true,
        autoScroll: false,
        plain: true,
        autoLoad: { showMask: true, scripts: true, url: url, mode: 'iframe', maskMsg: '正在初始化 ' + title + '，请稍等...' }
    });

    PoPWindowDetail.on("close", function () {
        if (paramFunction != undefined) {
            paramFunction();
        }
    });
    PoPWindowDetail.on("hide", function () {
        if (paramFunction != undefined) {
            paramFunction();
        }
    });
    PoPWindowDetail.show(paramThis);
    return false;
}

//
// 关闭弹出对话框
//
function PopClose() {
    if (PoPWindowDetail != null) {
        PoPWindowDetail.hide();
    }
    else {
        window.close();
    }
    return false;
}

//
// 弹出对话提示框
//
window.alert = function (paramMessage) {
    if (window.top.Ext != null)
        window.top.Ext.MessageBox.show({ title: '提示信息', msg: paramMessage, icon: window.top.Ext.MessageBox.INFO, buttons: window.top.Ext.Msg.OK });
    else
        alert(paramMessage);
}