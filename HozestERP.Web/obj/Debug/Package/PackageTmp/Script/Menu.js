// JScript 文件

function Hide() {
    var AllFuns = document.getElementById("grdSub").getElementsByTagName("TR");
    for (i = 0; i < AllFuns.length; i++) {
        if (AllFuns[i].name != "Functions")
            continue;
            AllFuns[i].style.display = "none";
            if (AllFuns[i].parentNode != null) {
                AllFuns[i].parentNode.parentNode.parentNode.parentNode.style.height = "";
                AllFuns[i].parentNode.parentNode.parentNode.style.height = "";
                AllFuns[i].parentNode.style.height = "";
                AllFuns[i].parentNode.parentNode.style.height = "";
            }
            document.getElementById("grdSub").style.height = "";
            AllFuns[i].children[0].style.height = "";
            AllFuns[i].style.height = "";

    }

}

var TreeHeight = 0;

function PageLoad() {
    TreeHeight = document.body.scrollHeight;
}


function showFun(trFunctions) {
    Hide();

    document.getElementById(trFunctions).style.display = "";
    if (TreeHeight < document.body.scrollHeight) {
        document.getElementById("grdSub").style.height = "100%";
        document.getElementById(trFunctions).style.height = "100%";
        document.getElementById(trFunctions).parentNode.parentNode.parentNode.parentNode.style.height = "100%";
        if (navigator.userAgent.indexOf("Chrome") > 0) {
        }
        else {
            document.getElementById(trFunctions).parentNode.parentNode.style.height = "100%";
        }
    }
}

function ChangeBg(btn) {
    var AllFuns = document.getElementsByTagName("input")
    for (i = 0; i < AllFuns.length; i++) {
        if (AllFuns[i].type == "submit" && AllFuns[i].id.indexOf("btnMenu") > -1) {
            AllFuns[i].className = "menuBar";
        }
    }
    btn.className = "CurrentmenuBar";
}

function HideMenu() {
    var tdTree = document.getElementById("tdTree");
    var tdContent = document.getElementById("tdContent");
    if (tdTree.style.display == "") {
        tdTree.style.display = "none";
        tdContent.style.width = "100%";
    }
    else {
        tdTree.style.display = "";
        tdContent.style.width = "100%";
    }
}

function showSplit_V() {
    var trMainMenu = document.getElementById("trMainMenu");
    if (trMainMenu.style.display == "") {
        trMainMenu.style.display = "none";
    }
    else {
        trMainMenu.style.display = "";
    }
}