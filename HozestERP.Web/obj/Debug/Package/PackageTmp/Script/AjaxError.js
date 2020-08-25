// JScript 文件

var basepath= "";
function ClearErrorState() {    
    try
    {
        $get(messageElem).innerHTML = '';   
     }  
     catch(err)
       {}
}

function EndRequestHandler(sender, args)
{

   if (args.get_error() != undefined)
   {
       var errorMessage;

        if (args.get_response().get_statusCode() == '200')
       {
           //errorMessage = "闲置时间过久，请重新登录!";
           errorMessage = args.get_error().message;
       }
       else if ((args.get_response().get_statusCode() == '503') || (args.get_response().get_statusCode() == '500') || (args.get_response().get_statusCode() == '12029') || (args.get_response().get_statusCode() == '12031') || (args.get_response().get_statusCode() == '12007'))
       {
               errorMessage = "闲置时间过久，请重新登录!";
       }
       else
       {
           // Error occurred somewhere other than the server page.
           errorMessage = '执行过程中遇到错误，请重新登录，\n 如仍遇到错误请联系管理员！ 错误编号：' + args.get_response().get_statusCode();
       }

       args.set_errorHandled(true);

       alert(errorMessage);
       
       if(errorMessage=="系统在执行中遇到错误,原因如下：您的帐号已经在别处登录,要继续请重新登录!" )
       {

            parent.parent.location.href = basepath;
       }
       
       
       
       if (args.get_error() != undefined)
   {
       
   }



    try
    {
       $get(messageElem).innerHTML = errorMessage;
       }
       catch(err)
       {}

   }

}
