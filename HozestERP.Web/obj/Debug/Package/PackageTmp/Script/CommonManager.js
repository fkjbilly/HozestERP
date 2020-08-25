
var CheckRowColor = "#FAE4E3";
var SelectRowColor = "#F6C4C3";

function SelectAll(tempControl, paramTabIndex) {
    var theBox = tempControl;
    xState = theBox.checked;

    elem = theBox.form.elements;
    for (i = 0; i < elem.length; i++)
        if (elem[i].type == "checkbox" && elem[i].id != theBox.id && elem[i].tabIndex == paramTabIndex) {
            if (elem[i].checked != xState)
                try {
                    elem[i].click();
                }
                catch (err)
               { }
        }
}

function SelectCheckBoxAll(tempControl, gridControl) {
    var theBox = tempControl;
    xState = theBox.checked;
    var elem = document.getElementById(gridControl).getElementsByTagName("input");
    for (i = 0; i < elem.length; i++)
        if (elem[i].type == "checkbox" && elem[i].id != theBox.id) {
            if (elem[i].checked != xState)
                try {
                    elem[i].click();
                }
                catch (err)
               { }
        }
}

function round(a, b) {
    var Temp = Math.pow(10, b);
    var value = Math.round(a * Temp) / Temp;
    return (value);
}

function accAdd(arg1, arg2) {
    var r1, r2, m;
    try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
    m = Math.pow(10, Math.max(r1, r2))
    return (arg1 * m + arg2 * m) / m
}

function accMul(arg1, arg2) {
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try { m += s1.split(".")[1].length } catch (e) { }
    try { m += s2.split(".")[1].length } catch (e) { }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)
}

function CheckSelect(tempControl, paramTabIndex) {
    var objForm = tempControl.form;
    var objLen = objForm.length;
    var anyone = false;
    for (var i = 0; i < objLen; i++) {
        if (objForm.elements[i].type == "checkbox" & objForm.elements[i].tabIndex == paramTabIndex) {
            if (objForm.elements[i].checked == true) {
                anyone = true;
            }
        }
    }
    if (anyone == true) {
        var OK = confirm("您确认要删除吗？");
        if (OK) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        alert("您没有选择任何记录！");
        return false;
    }
}

function CheckGridSelect(tempControl, gridControl) {
    var objForm = document.getElementById(gridControl).getElementsByTagName("input");
    var objLen = objForm.length;
    var anyone = false;
    for (var i = 0; i < objLen; i++) {
        if (objForm[i].type == "checkbox") {
            if (objForm[i].checked == true) {
                anyone = true;
            }
        }
    }
    if (anyone == true) {
        var OK = confirm("您确认要删除吗？");
        if (OK) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        alert("您没有选择任何记录！");
        return false;
    }
}

function CheckSelectByAlert(tempControl, paramTabIndex, paramMessage) {
    var objForm = tempControl.form;
    var objLen = objForm.length;
    var anyone = false;
    for (var i = 0; i < objLen; i++) {
        if (objForm.elements[i].type == "checkbox" & objForm.elements[i].tabIndex == paramTabIndex) {
            if (objForm.elements[i].checked == true) {
                anyone = true;
            }
        }
    }
    if (anyone == true) {
        if (paramMessage.toString().length == 0) {
            return true;
        }
        var OK = confirm(paramMessage);
        if (OK) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        alert("您没有选择任何记录！");
        return false;
    }
}

function CheckSelectAny(tempControl, paramTabIndex) {
    var objForm = tempControl.form;
    var objLen = objForm.length;
    var anyone = false;
    for (var i = 0; i < objLen; i++) {
        if (objForm.elements[i].type == "checkbox" & objForm.elements[i].tabIndex == paramTabIndex) {
            if (objForm.elements[i].checked == true) {
                anyone = true;
            }
        }
    }
    if (anyone == true) {
        return true;
    }
    else {
        alert("您没有选择任何记录！");
        return false;
    }
}
var myColor;
var ActiveRow;
var oldChk;
function RowColorIn(chk, myRow) {
    if (ActiveRow != null && oldChk != null) {
        // 前一个复选框如果选中那就把前一行颜色设成选中的颜色
        if (document.getElementById(oldChk) != null && document.getElementById(oldChk).checked == true) {
            //复选框选中的颜色
            ActiveRow.style.backgroundColor = CheckRowColor; //'#FFFDD7';                
        }
        else {
            // 没选中就恢复原来的颜色
            var OldColor = "";
            OldColor = ActiveRow.getAttribute("OldColor");
            ActiveRow.style.backgroundColor = OldColor;
        }
    }
    if (myRow.style.backgroundColor != 'Red') {
        // 把当前的行,复选框设成前一个
        ActiveRow = myRow;
        oldChk = chk;
        //设置鼠标放上去的颜色
        myRow.style.backgroundColor = SelectRowColor; //'#DFE8F6';
    }
}
function RowColorOut(myRow) {

    var OldColor = "";
    OldColor = myRow.getAttribute("OldColor");
    alert(OldColor);
    myRow.style.backgroundColor = OldColor;
}

function SetHeadCss() {
    var Check = document.getElementById("chkAll");
    if (Check == null) {
        return;
    }
    var gridHead = Check.parentNode.parentNode;
    if (this.scrollTop == 0) {
        gridHead.className = "";
    }
    else {
        gridHead.className = "Freezing";
    }
}

function SetHeadCellsCss(Flag, Cell) {
    if (Flag == "Over") {
        Cell.className = "GridOverHeard";
    }
    else {
        Cell.className = "GridHeard";
    }
}

function SetHeadCellsCssNoTop(Flag, Cell) {
    if (Flag == "Over") {
        Cell.className = "GridOverHeardNoTop";
    }
    else {
        Cell.className = "GridHeardNoTop";
    }
}

// 选中行改变事件 
function SelectChange(chk) {
    var CurrentRow = chk.parentNode.parentNode.parentNode;
    if (CurrentRow.style.backgroundColor != 'Red') {
        if (chk.checked == true) {
            CurrentRow.style.backgroundColor = CheckRowColor;
        }
        else {
            var OldColor = "";
            OldColor = CurrentRow.getAttribute("OldColor");
            if (OldColor != null) {
                CurrentRow.style.backgroundColor = String(OldColor);
            }
        }
    }
}

function HeadClick(SortExp, btnHeadClickid, txtSortFieldid) {
    var txtSortFieldid = document.getElementById(txtSortFieldid);
    var btn = document.getElementById(btnHeadClickid);
    txtSortFieldid.value = SortExp;
    btn.click();
}

function PageLoad(width, height) {
    if (BodyHeight == "" || BodyHeight == undefined) {
        if (width == undefined || width == "") {
            var AllFuns = document.getElementsByTagName("table");
            for (i = 0; i < AllFuns.length; i++) {
                if (AllFuns[i].id.indexOf("SearchTab") > -1) {
                    BodyWidth = AllFuns[i].offsetWidth;
                    break;
                }
            }
        }
        else {
            BodyWidth = width;
        }
    }
    if (BodyHeight == "" || BodyHeight == undefined) {
        if (height == undefined || height == "") {
            BodyHeight = document.body.scrollHeight;
        }
        else {
            BodyHeight = height;
        }
    }

}

var BodyHeight;

function AutoDivHeight(GridTable, tdGrid, tablework, DivGrid, tdtdGrid) {
    // 当现在的页面高度比第一次的页面高度要高时就用百分比
    if (document.body.scrollHeight > BodyHeight) {
        //DivGrid.style.height="100%";

        document.getElementById(GridTable).style.height = "100%";
        document.getElementById(tdGrid).style.height = "100%";
        document.getElementById(tablework).style.height = "100%";
        document.getElementById(DivGrid).style.height = "100%";
        document.getElementById(tdtdGrid).style.height = "100%";
    }
    else {
        //DivGrid.style.height="";
        document.getElementById(GridTable).style.height = "";
        document.getElementById(GridTable).style.offsetHeight = document.getElementById(GridTable).style.offsetHeight + 100;
        document.getElementById(GridTable).style.offsetWidth = document.getElementById(GridTable).style.offsetWidth + 100;
        document.getElementById(tdGrid).style.height = "";
        document.getElementById(tablework).style.height = "";
        document.getElementById(DivGrid).style.height = "";
        document.getElementById(tdtdGrid).style.height = "";
    }
}

var BodyWidth;

function AutoDivWidth(DivGrid, Grid) {
    if (document.getElementById(Grid) != null) {
        if (BodyWidth > 0) {
            // 当现在的页面宽度比第一次的页面宽度要高时就用百分比
            if (document.getElementById(Grid).offsetWidth > BodyWidth) {
                //DivGrid.style.height="100%";
                document.getElementById(DivGrid).style.width = BodyWidth;
            }
            else {
                document.getElementById(DivGrid).style.width = "100%";
            }
        }
        else {
            document.getElementById(DivGrid).style.width = "100%";
        }
    }
}

//
// 弹出对话框
//
function ShowWindowDetail(title, url, width, height, paramThis, paramFunction) {
    if (window.top.ExtWindowDetail != undefined) {
        var showWindowDetail = new window.top.ExtWindowDetail(title, url, width, height, paramThis, paramFunction);
        return false;
    }
    else {

        var returnValue = window.showModalDialog(url, title, "status:no;help:no;dialogWidth:" + width + "px;dialogHeight:" + height + "px;center:yes;");

        if (paramFunction != undefined) {
            paramFunction();
        }
        return false;
    }
}

function CkeckShowWindowDetail(CheckparamFunction, title, url, width, height, paramThis, paramFunction) {
    if (CheckparamFunction != undefined) {
        var a = CheckparamFunction;
        if (a == false) {
            return false;
        }
    }

    if (window.top.ExtWindowDetail != undefined) {
        var showWindowDetail = new window.top.ExtWindowDetail(title, url, width, height, paramThis, paramFunction);
        return false;
    }
    else {

        var returnValue = window.showModalDialog(url, title, "status:no;help:no;dialogWidth:" + width + "px;dialogHeight:" + height + "px;center:yes;");

        if (paramFunction != undefined) {
            paramFunction();
        }
        return false;
    }
}

function ShowWindowDetail1(id, title, url, width, height, paramThis, paramFunction) {
    if (window.top.ExtWindowDetail != undefined) {
        var showWindowDetail = new window.top.ExtWindowDetail1(id, title, url, width, height, paramThis, paramFunction);
        return false;
    }
    else {

        var returnValue = window.showModalDialog(url, title, "status:no;help:no;dialogWidth:" + width + "px;dialogHeight:" + height + "px;center:yes;");

        if (paramFunction != undefined) {
            paramFunction();
        }
        return false;
    }
}

PopClose = function () { window.top.PopClose() };

function closewin() {
    var win = parent.Ext.getCmp('b-win');
    if (win) { win.close(); }
}


 //弹出对话提示框

window.alert = function (paramMessage) {
    if (window.top.Ext != null)
        window.top.Ext.MessageBox.show({ title: '提示信息', msg: paramMessage, icon: window.top.Ext.MessageBox.INFO, buttons: window.top.Ext.Msg.OK });
    else
        alert(paramMessage);
}

//
// 以对话框形式显示
// 
function ShowNewTabDetail(URL, id, title) {
    if (window.top.newTab != undefined) {
        window.top.newTab(id, URL, title);
    }
    else {
        window.location = URL;
    }
    return false;
}