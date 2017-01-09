<%@ WebHandler Language="C#" Class="RecordPlay" %>

using System;
using System.Web;
using System.Collections;
using System.Linq;

public class RecordPlay : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string sidList = context.Request.Params["sidList"] == null ? "" : context.Request.Params["sidList"];

        if (sidList == "")
        {
            return;
        }
        else
        {
            string realIP = "匿名者";
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            ArrayList sal = new ArrayList();
            string[] sidListA = sidList.Split(',');
            sidListA = sidListA.Where(v => !string.IsNullOrEmpty(v)).ToArray();
            foreach (var sid in sidListA)
            {
                string sql = "insert into playingrecords (SONGID, UIP, PLAYDATE) values(\"" + sid.ToString() + "\",\"" + realIP + "\",\"" + datatime + "\");";
                sal.Add(sql);
            }

            MyDB.ExecuteSqlTran(sal);
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