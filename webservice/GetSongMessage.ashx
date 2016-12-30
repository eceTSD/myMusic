<%@ WebHandler Language="C#" Class="GetSongMessage" %>

using System;
using System.Web;
using System.Data;
using System.Collections.Generic;

public class GetSongMessage : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string s = context.Request.Params["s"] == null ? "" : context.Request.Params["s"].ToString();
        if (s == "") { s = "35403523"; }
        context.Response.ContentType = "text/json";

        DataTable dt = MyDB.Query("select * from songmessage where SONGID = '" + s + "'").Tables[0];
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