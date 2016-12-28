<%@ WebHandler Language="C#" Class="GetMessage" %>

using System;
using System.Web;
using System.Data;
using System.Collections.Generic;

public class GetMessage : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/json";

        DataTable dt = MyDB.Query("select * from message").Tables[0];
        List<Message> messagel = new List<Message>();
        foreach(DataRow dr in dt.Rows)
        {
            Message message = new Message();
            message.Uip = dr["UIP"].ToString();
            message.Creatdate = dr["CREATDATE"].ToString();
            message.Messageinfo = dr["UMESSAGE"].ToString();
            messagel.Add(message);
        }


        context.Response.Write(Utils.ObjectToJson(messagel));
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}