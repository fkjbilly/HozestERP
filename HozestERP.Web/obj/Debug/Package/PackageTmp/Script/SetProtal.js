function ShowEditPortel() {
    CompanyX.ShowWindow();
    new Ext.dd.DropTarget(Ext.getCmp("gdPrimary").container, {
        ddGroup: 'firstGridDDGroup',
        copy: false,
        notifyDrop: notifyDropPrimary
    });

    new Ext.dd.DropTarget(Ext.getCmp("GridPanel1").container, {
        ddGroup: 'secondGridDDGroup',
        copy: false,
        notifyDrop: notifyDrop1
    });

    new Ext.dd.DropTarget(Ext.getCmp("GridPanel2").container, {
        ddGroup: 'secondGridDDGroup',
        copy: false,
        notifyDrop: notifyDrop2
    });

    new Ext.dd.DropTarget(Ext.getCmp("GridPanel3").container, {
        ddGroup: 'secondGridDDGroup',
        copy: false,
        notifyDrop: notifyDrop3
    });

    new Ext.dd.DropTarget(Ext.getCmp("GridPanel4").container, {
        ddGroup: 'secondGridDDGroup',
        copy: false,
        notifyDrop: notifyDrop4
    });
}

// Generic function to add records.
var addRow = function (store, record, ddSource) {
    // Search for duplicates
    var foundItem = store.findExact('Name', record.data.Name);

    // if not found
    if (foundItem == -1) {
        //Remove Record from the source
        ddSource.grid.store.remove(record);

        store.add(record);

        // Call a sort dynamically
        store.sort('Name', 'ASC');
    }
};

var notifyDropPrimary = function (ddSource, e, data) {
    // Loop through the selections
    Ext.each(ddSource.dragData.selections, function (record) {
        addRow(CompanyX.SPrimarySource, record, ddSource);
    });

    return true;
};

var notifyDrop1 = function (ddSource, e, data) {
    // Loop through the selections
    Ext.each(ddSource.dragData.selections, function (record) {
        addRow(CompanyX.SDataSource1, record, ddSource);
    });

    return true;
};


var notifyDrop2 = function (ddSource, e, data) {
    // Loop through the selections
    Ext.each(ddSource.dragData.selections, function (record) {
        addRow(CompanyX.SDataSource2, record, ddSource);
    });

    return true;
};

var notifyDrop3 = function (ddSource, e, data) {
    // Loop through the selections
    Ext.each(ddSource.dragData.selections, function (record) {
        addRow(CompanyX.SDataSource3, record, ddSource);
    });

    return true;
};
var notifyDrop4 = function (ddSource, e, data) {
    // Loop through the selections
    Ext.each(ddSource.dragData.selections, function (record) {
        addRow(CompanyX.SDataSource4, record, ddSource);
    });

    return true;
};
function SelectColumnIndex(a, b, c, d) {
    switch (b.data.value) {
        case "1":
            {
                Ext.getCmp("pnlColumn1").show();
                Ext.getCmp("pnlColumn2").hide();
                Ext.getCmp("pnlColumn3").hide();
                Ext.getCmp("pnlColumn4").hide();
            }
            break;
        case "2":
            {
                Ext.getCmp("pnlColumn1").show();
                Ext.getCmp("pnlColumn2").show();
                Ext.getCmp("pnlColumn3").hide();
                Ext.getCmp("pnlColumn4").hide();
            }
            break;
        case "3":
            {
                Ext.getCmp("pnlColumn1").show();
                Ext.getCmp("pnlColumn2").show();
                Ext.getCmp("pnlColumn3").show();
                Ext.getCmp("pnlColumn4").hide();
            }
            break;
        case "4":
            {
                Ext.getCmp("pnlColumn1").show();
                Ext.getCmp("pnlColumn2").show();
                Ext.getCmp("pnlColumn3").show();
                Ext.getCmp("pnlColumn4").show();
            }
            break;

    }
}

function Save() {

    if (Ext.getCmp("fpnlColumn").getForm().isValid()) {
        CompanyX.SaveColumn(GetStoreValues("GridPanel1"), GetStoreValues("GridPanel2")
            , GetStoreValues("GridPanel3"), GetStoreValues("GridPanel4"));
    }
}

function Search() {
    var year = Ext.getCmp('cbYear').getValue();
    var month = Ext.getCmp('cbMonth').getValue();
    var date = year + "-" + month + "-" + "01";
    window.frames["portletRelatedContractPayment_IFrame"].location = 'ManagePortlet/RelatedContractPayment.aspx?date=' + date;
}

function GetStoreValues(paramGridPanel) {
    var store = Ext.getCmp(paramGridPanel).store;
    var values = [];

    store.each(function (r) {

        if (!Ext.isEmptyObj(r)) {
            values.push(r.data);
        }
    });
    return values;
}


function ShowModalDialog(Url) {
    window.showModalDialog(Url, null, "dialogwidth:800px; dialogheight:500px;status:0;help:0;certer:1");
}
function ShowMeetModalDialog(Url) {
    window.showModalDialog(Url, null, "dialogwidth:660px; dialogheight:450px;status:0;help:0;certer:1");
}

var CompanyX = {
    Drop: function (e) {
        CompanyX.EventDrop(e.panel.id.replace("myPortlet", ""), e.position, e.column.id.replace("PortalColumn", ""));
    }
};
function SetParotal() {
    window.location = "SetProtal.aspx";
}
function Collapse() {
    Ext.getCmp("Portal1").items.each(function (items) {
        items.items.each(function (paramItems) { paramItems.collapse(true); });
    });
}
function Expand() {
    Ext.getCmp("Portal1").items.each(function (items) {
        items.items.each(function (paramItems) { paramItems.expand(true); });
    });
}
function ToggleCollapse() {
    Ext.getCmp("Portal1").items.each(function (items) {
        items.items.each(function (paramItems) { paramItems.toggleCollapse(true); });
    });
}