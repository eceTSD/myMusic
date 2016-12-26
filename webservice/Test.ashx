<%@ WebHandler Language="C#" Class="Test" %>

using System;
using System.Web;

public class Test : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        context.Response.Write(MusicApis.MVInfo("319076"));
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}