using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.Caching
{
    public partial class GetToken : IGetToken
    {
        public void GetSuningToken() 
        {
        //    String uri = "https://oauth.suning.com/oauth/token";
        //    OutputStream dos = null; 
        //    InputStream dis = null; 
        //    URL url = newURL(uri); 
        //    HttpsURLConnection connection = (HttpsURLConnection) url.openConnection(); 
        //    connection.setRequestMethod("POST"); 
        //    connection.setDoOutput(true); 
        //    connection.setDoInput(true); 
        //    connection.setAllowUserInteraction(true); 
        //    connection.setRequestProperty("Content-Length", String.valueOf(params.getBytes().length)); 
        //    Set<Entry<String, Object>> entrySet = headers.entrySet();
        //    for(Map.Entry<String, Object> entry : entrySet) {
        //    String key = (String) entry.getKey();
        //    Object obj = entry.getValue();
        //    connection.setRequestProperty(key, (String) obj);
        //    }
        //    dos = connection.getOutputStream(); 
        //    dos.write(params.getBytes("utf-8"));
        //    dos.flush();
        //    int code= connection.getResponseCode();
        //    dis = connection.getInputStream(); 
        //    ByteArrayOutputStream out = new ByteArrayOutputStream();  
        //    String data2 = new String(out.toByteArray()); 
        }
    }
}
