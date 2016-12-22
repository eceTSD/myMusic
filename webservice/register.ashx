<%@ WebHandler Language="C#" Class="register" %>

using System;
using System.Web;

public class register : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        SqlHelper sqlhelp = new SqlHelper(System.Configuration.ConfigurationManager.ConnectionStrings["userbase"].ConnectionString);
        sqlhelp.GetTables();
        
        context.Response.Write("Hello World");
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}