<%@ WebHandler Language="C#" Class="RecordPlay" %>

using System;
using System.Web;

public class RecordPlay : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string songid = context.Request.Params["sid"] == null ? "" : context.Request.Params["sid"].ToString();

        if (songid == "")
        {
            return;
        }
        else
        {
            string realIP = "匿名者";
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "insert into playingrecords (SONGID, UIP, PLAYDATE) values(\"" + songid + "\",\"" + realIP + "\",\"" + datatime + "\")";
            MyDB.ExecuteSql(sql);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}