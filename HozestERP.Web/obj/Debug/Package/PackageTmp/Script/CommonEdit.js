// JScript 文件


function CheckNumInput(text, Type, Remark)
{
    var txtValue = document.getElementById(text).value;
    if(txtValue != "")
    {
        if(Type == "FLOAT")
        {
            if(!InputIsDigit(txtValue)  || isNaN(txtValue) )
            {
                alert('请在 '+Remark + ' 处输入数字');
                document.getElementById(text).select();
                return false;
            }
            return true;
        }
        else if(Type == "INT")
        {
            if(!InputIsInt(txtValue))
            {
                alert('请在 '+Remark + ' 处输入整数');
                document.getElementById(text).select();
                return false;
            }
            return true;
        }
        else
        {
            return true;
        }
    }
    else
    {
        alert('请输入' + Remark);
        document.getElementById(text).select();
        return false;
    }
}

function round(a,b){
var Temp = Math.pow(10,b);
var value =Math.round(a * Temp)/Temp;
return(value);
}

// 加法
function accAdd(arg1,arg2){
    var r1,r2,m;
    try{r1=arg1.toString().split(".")[1].length}catch(e){r1=0}
    try{r2=arg2.toString().split(".")[1].length}catch(e){r2=0}
    m=Math.pow(10,Math.max(r1,r2))
    return (arg1*m+arg2*m)/m
}

// 乘法
function accMul(arg1,arg2)
{
    var m=0,s1=arg1.toString(),s2=arg2.toString();
    try{m+=s1.split(".")[1].length}catch(e){}
    try{m+=s2.split(".")[1].length}catch(e){}
    return Number(s1.replace(".",""))*Number(s2.replace(".",""))/Math.pow(10,m)
}

// 除法
function accDiv(arg1,arg2){
    var t1=0,t2=0,r1,r2;
    try{t1=arg1.toString().split(".")[1].length}catch(e){}
    try{t2=arg2.toString().split(".")[1].length}catch(e){}
    with(Math){
        r1=Number(arg1.toString().replace(".",""))
        r2=Number(arg2.toString().replace(".",""))
        return (r1/r2)*pow(10,t2-t1);
    }
}


function CheckEmpty(text, Remark)
{
    var txtValue = document.getElementById(text).value;
    if(txtValue == "")
    {
        alert('请输入 ' + Remark);
        try
        {
            document.getElementById(text).select();
        }
        catch(err)
        {

        }
        return false;
    }
    return true;
}

function CheckEmptyddl(text, Remark)
{
    var txtValue = document.getElementById(text).value;
    if(txtValue == "-1")
    {
        alert('请输入 ' + Remark);
        try
        {
            document.getElementById(text).select();
        }
        catch(err)
        {

        }
        return false;
    }
    return true;
}
//校验是否全由数字组成
function InputIsDigit(s)
{
    var patrn=/^[+-]?[0-9.]*$/;
    if (!patrn.exec(s)) return false;
    return true;
}

//校验是否全由数字组成
function InputIsInt(s)
{
    var patrn=/^[+]?[0-9]*$/;
    if (!patrn.exec(s)) return false;
    return true;
}

//校验是否全由数字组成
function InputIsRightDigit(s)
{
    var patrn=/^[+]?[0-9.]*$/;
    if (!patrn.exec(s)) return false;
    return true;
}

var imgOpenExpandSrc,imgCloseExpandSrc;

function Expand(Content, Content01, Img)
{

    var Control = document.getElementById(Content);
    var Control01 = document.getElementById(Content01);
    if(Img.src== imgOpenExpandSrc)
    {
        Control.style.display = "none";
        Control01.style.display="none";
        Img.src = imgCloseExpandSrc;
    }
    else
    {
        Control.style.display = "";
        Control01.style.display="";
        Img.src = imgOpenExpandSrc;
    }
}