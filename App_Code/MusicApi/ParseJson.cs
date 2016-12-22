using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ParseJson 的摘要说明
/// </summary>
public class ParseJson
{

    /// <summary>
    /// 解析单个歌曲
    /// </summary>
    /// <param name="songJson"></param>
    /// <returns></returns>
    public static Song GetSong(string songJson)
    {

        dynamic songJ = JsonConvert.DeserializeObject(songJson);
        Song song = new Song();
        song.Id = songJ.id;
        song.Name = songJ.name;
        song.Artist = GetArtistL(songJ.artists);
        song.Album = GetAlbum(songJ.album.ToString());
        song.Mp3Url = songJ.mp3Url;
        return song;
    }

    /// <summary>
    /// 解析歌曲列表
    /// </summary>
    /// <param name="jarry"></param>
    /// <returns></returns>
    public static List<Song> GetSongL(JArray jarry)
    {
        List<Song> SongList = new List<Song>();
        for (int i = 0; i < jarry.Count; i++)
        {
            SongList.Add(GetSong(jarry.ElementAt(i).ToString()));
        }

        return SongList;
    }

    /// <summary>
    /// 解析单个歌单
    /// </summary>
    /// <param name="appListJson"></param>
    /// <returns></returns>
    public static AppList GetAppList(string appListJson)
    {
        dynamic appListj = JsonConvert.DeserializeObject(appListJson);
        AppList appList = new AppList();
        appList.Id = appListj.id;
        appList.Name = appListj.name;
        appList.PlayCount = appListj.playCount;
        appList.TrackCount = appListj.trackCount;
        try
        {
            appList.TrackNumberUpdateTime = appListj.trackNumberUpdateTime;
            appList.Tracks = GetSongL(appListj.tracks);
        }
        catch (Exception)
        {

            appList.TrackNumberUpdateTime = 0;
            appList.Tracks = new List<Song>();
        }


        return appList;
    }

    /// <summary>
    /// 解析歌单列表
    /// </summary>
    /// <param name="jarry"></param>
    /// <returns></returns>
    public static List<AppList> GetAppListL(JArray jarry)
    {
        List<AppList> appList = new List<AppList>();
        for (int i = 0; i < jarry.Count; i++)
        {
            appList.Add(GetAppList(jarry.ElementAt(i).ToString()));
        }

        return appList;
    }

    /// <summary>
    /// 解析专辑
    /// </summary>
    /// <param name="albumJson"></param>
    /// <returns></returns>
    public static Album GetAlbum(string albumJson)
    {
        dynamic albumj = JsonConvert.DeserializeObject(albumJson);
        Album album = new Album();
        album.Id = albumj.id;
        album.Name = albumj.name;
        album.PictureUrl = albumj.picUrl;
        album.BlurPicture = albumj.blurPicUrl;
        album.Company = albumj.company;
        album.PublishTime = albumj.publishTime;
        album.SubType = albumj.subType;
        album.Size = albumj.size;
        album.Artist = GetArtistL(albumj.artists);
        album.Songs = GetSongL(albumj.songs);




        return album;
    }

    /// <summary>
    /// 解析专辑列表
    /// </summary>
    /// <param name="jarry"></param>
    /// <returns></returns>
    public static List<Album> GetAlbumL(JArray jarry)
    {
        List<Album> albumList = new List<Album>();
        for (int i = 0; i < jarry.Count; i++)
        {
            albumList.Add(GetAlbum(jarry.ElementAt(i).ToString()));
        }

        return albumList;
    }


    /// <summary>
    /// 解析艺术家
    /// </summary>
    /// <param name="artistJson"></param>
    /// <returns></returns>
    public static Artist GetArtist(string artistJson)
    {
        dynamic artistj = JsonConvert.DeserializeObject(artistJson);
        Artist artist = new Artist();
        artist.Id = artistj.id;
        artist.Name = artistj.name;
        artist.PicUrl = artistj.picUrl;
        artist.AlbumSize = artistj.albumSize;
        try
        {
            artist.HotAlbums = GetAlbumL(artistj.hotAlbums);
        }
        catch (Exception)
        {
            artist.HotAlbums = new List<Album>();
        }
        return artist;
    }


    /// <summary>
    /// 解析艺术家列表
    /// </summary>
    /// <param name="jarry"></param>
    /// <returns></returns>
    public static List<Artist> GetArtistL(JArray jarry)
    {
        List<Artist> artistList = new List<Artist>();
        for (int i = 0; i < jarry.Count; i++)
        {
            artistList.Add(GetArtist(jarry.ElementAt(i).ToString()));
        }

        return artistList;
    }

}