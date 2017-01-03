﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MyInit 的摘要说明
/// </summary>
public class MyInit
{
   public static void initHome()
    {
        List<Song> songlist = MusicApis.SearchApi("陈奕迅", "1", "0", "20").Cast<Song>().ToList();
        List<onesongnew> songl = new List<onesongnew>();
        foreach (Song song in songlist)
        {
            if (Utils.IsURLOK(song.Mp3Url))
            {
                onesongnew onesong = new onesongnew();
                onesong.id = song.Id;
                onesong.albumid = song.Album.Id;
                onesong.album = song.Album.Name.Length > 10 ? song.Album.Name.Substring(0, 10) + "..." : song.Album.Name;
                onesong.title = song.Name;
                onesong.author = song.Artist[0].Name;
                onesong.url = song.Mp3Url;
                onesong.pic = song.Album.PictureUrl;
                onesong.lrc = MusicApis.LyricInfo(song.Id.ToString()).Lyr;
                songl.Add(onesong);
            }

        }
        HashOperator hashOperatoer = new HashOperator();
        hashOperatoer.Set<string>("0001", "home", Utils.ObjectToJson(songl));
    }
}