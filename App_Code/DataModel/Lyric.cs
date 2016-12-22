using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Lyric 的摘要说明
/// </summary>
public class Lyric : DataBase
{
    private string lyr;

    public string Lyr
    {
        get
        {
            return lyr;
        }

        set
        {
            lyr = value;
        }
    }
}