using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Message 的摘要说明
/// </summary>
public class Message:DataBase
{
    private string uip;

    private string creatdate;

    private string messageinfo;

    public string Uip
    {
        get
        {
            return uip;
        }

        set
        {
            uip = value;
        }
    }

    public string Creatdate
    {
        get
        {
            return creatdate;
        }

        set
        {
            creatdate = value;
        }
    }

    public string Messageinfo
    {
        get
        {
            return messageinfo;
        }

        set
        {
            messageinfo = value;
        }
    }
}