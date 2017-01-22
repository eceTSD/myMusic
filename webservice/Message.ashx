<%@ WebHandler Language="C#" Class="Message" %>

using System;
using System.Web;

public class Message : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string message = context.Request.Params["message"] == null ? "" : context.Request.Params["message"].ToString();
        context.Response.ContentType = "text/json";        
        if (!Utils.IsSafeSqlString(message) || message == "")
        {
            context.Response.Write("{\"statue\":0}");
        }
        else
        {
            
            string realIP = context.Request.UserHostName.ToString();
            string guid = System.Guid.NewGuid().ToString("N").ToUpper();
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "insert into message (ID,UIP,CREATDATE,UMESSAGE) values(\""+guid+"\",\""+realIP+"\",\""+datatime+"\",\""+message+"\")";
            if (MyDB.ExecuteSql(sql) > 0)
            {
                context.Response.Write("{\"statue\":200}");
            }
            else
            {
                context.Response.Write("{\"statue\":400}");
            }
        }



    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}