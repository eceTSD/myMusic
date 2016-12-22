using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Song 的摘要说明
/// </summary>
public class Song : DataBase
{
    private long id;

    private string name;

    private List<Artist> artist;

    private Album album;

    private string mp3Url;


    /// <summary>
    /// 歌曲id
    /// </summary>
    public long Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    /// <summary>
    /// 歌曲名
    /// </summary>
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }


    /// <summary>
    /// 歌曲所在专辑
    /// </summary>
    public Album Album
    {
        get
        {
            return album;
        }

        set
        {
            album = value;
        }
    }

    /// <summary>
    /// 歌曲播放地址
    /// </summary>
    public string Mp3Url
    {
        get
        {
            return mp3Url;
        }

        set
        {
            mp3Url = value;
        }
    }

    /// <summary>
    /// 歌曲作者列表
    /// </summary>
    public List<Artist> Artist
    {
        get
        {
            return artist;
        }

        set
        {
            artist = value;
        }
    }
}
