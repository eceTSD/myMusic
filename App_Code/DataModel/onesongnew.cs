using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// onesongnew 的摘要说明
/// </summary>
public class onesongnew
{
    private string _title;

    private string _author;

    private string _url;

    private string _pic;

    private string _lrc;

    public string title
    {
        get
        {
            return _title;
        }

        set
        {
            _title = value;
        }
    }

    public string author
    {
        get
        {
            return _author;
        }

        set
        {
            _author = value;
        }
    }

    public string url
    {
        get
        {
            return _url;
        }

        set
        {
            _url = value;
        }
    }

    public string pic
    {
        get
        {
            return _pic;
        }

        set
        {
            _pic = value;
        }
    }

    public string lrc
    {
        get
        {
            return _lrc;
        }

        set
        {
            _lrc = value;
        }
    }
}