<%@ WebHandler Language="C#" Class="SongMessage" %>

using System;
using System.Web;

public class SongMessage : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string songid = context.Request.Params["id"] == null ? "" : context.Request.Params["id"].ToString();
        string message = context.Request.Params["message"] == null ? "" : context.Request.Params["message"].ToString();
        context.Response.ContentType = "text/json";        
        if (songid == "") { songid = "35403523"; }
        if (!Utils.IsSafeSqlString(message) || message == "")
        {
            context.Response.Write("{\"statue\":0}");
        }
        else
        {
            
            string realIP = "匿名者";
            string guid = System.Guid.NewGuid().ToString("N").ToUpper();
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "insert into songmessage (ID, SONGID,UIP,CREATDATE,UMESSAGE) values(\""+guid+"\",\""+songid+"\",\""+realIP+"\",\""+datatime+"\",\""+message+"\")";
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