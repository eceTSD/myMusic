using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AppList 的摘要说明
/// </summary>
public class AppList : DataBase
{

    private long id;

    private string name;

    private int playCount;

    private int trackCount;

    private List<Song> tracks;

    private long trackNumberUpdateTime;

    private string coverImgUrl;


    /// <summary>
    /// 歌单id
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
    /// 歌单名称
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
    /// 播放次数
    /// </summary>
    public int PlayCount
    {
        get
        {
            return playCount;
        }

        set
        {
            playCount = value;
        }
    }


    /// <summary>
    /// 歌单歌曲数目
    /// </summary>
    public int TrackCount
    {
        get
        {
            return trackCount;
        }

        set
        {
            trackCount = value;
        }
    }

    /// <summary>
    /// 歌单歌曲列表
    /// </summary>
    public List<Song> Tracks
    {
        get
        {
            return tracks;
        }

        set
        {
            tracks = value;
        }
    }

    /// <summary>
    /// 创建时间
    /// </summary>
    public long TrackNumberUpdateTime
    {
        get
        {
            return trackNumberUpdateTime;
        }

        set
        {
            trackNumberUpdateTime = value;
        }
    }

    /// <summary>
    /// 封面
    /// </summary>
    public string CoverImgUrl
    {
        get
        {
            return coverImgUrl;
        }

        set
        {
            coverImgUrl = value;
        }
    }
}