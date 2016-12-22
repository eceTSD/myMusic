using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Album 的摘要说明
/// </summary>
public class Album : DataBase
{

    private long id;

    private string name;

    private List<Artist> artist;

    private List<Song> songs;

    private int size;

    private string company;

    private string subType;

    private string pictureUrl;

    private string blurPicture;

    private long publishTime;

    /// <summary>
    /// 专辑id
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
    /// 专辑名称
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
    /// 专辑作者
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

    /// <summary>
    /// 专辑歌曲
    /// </summary>
    public List<Song> Songs
    {
        get
        {
            return songs;
        }

        set
        {
            songs = value;
        }
    }

    /// <summary>
    /// 歌曲数量
    /// </summary>
    public int Size
    {
        get
        {
            return size;
        }

        set
        {
            size = value;
        }
    }

    /// <summary>
    /// 发行公司
    /// </summary>
    public string Company
    {
        get
        {
            return company;
        }

        set
        {
            company = value;
        }
    }


    /// <summary>
    /// 发行类型
    /// </summary>
    public string SubType
    {
        get
        {
            return subType;
        }

        set
        {
            subType = value;
        }
    }


    /// <summary>
    /// 清晰图片地址
    /// </summary>
    public string PictureUrl
    {
        get
        {
            return pictureUrl;
        }

        set
        {
            pictureUrl = value;
        }
    }


    /// <summary>
    /// 模糊图片地址
    /// </summary>
    public string BlurPicture
    {
        get
        {
            return blurPicture;
        }

        set
        {
            blurPicture = value;
        }
    }

    /// <summary>
    /// 发布时间
    /// </summary>
    public long PublishTime
    {
        get
        {
            return publishTime;
        }

        set
        {
            publishTime = value;
        }
    }
}