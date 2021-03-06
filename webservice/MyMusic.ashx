﻿<%@ WebHandler Language="C#" Class="MyMusic" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;


public class MyMusic : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string s = context.Request.Params["s"] == null ? "" : context.Request.Params["s"].ToString();
        string type = context.Request.Params["type"] == null ? "1" : context.Request.Params["type"].ToString();

        if (s == "") { s = "陈奕迅"; }


        if(MyDB.Query("select * from searchcode where searchcode = \"" + s + "\"").Tables[0].Rows.Count == 0)
        {
            MyDB.ExecuteSql("insert into searchcode (username,searchcode) values (\"匿名者\",\""+s+"\")");
        }

        if(type == "1") {
            HashOperator hashOperatoer = new HashOperator();
           
            context.Response.ContentType = "text/json";
            if(hashOperatoer.Exist<string>("0001", s))
            {
                context.Response.Write(hashOperatoer.Get<string>("0001",s));
            }else {
                List<Song> songlist = MusicApis.SearchApi(s, type, "0", "50").Cast<Song>().ToList();
                List<onesongnew> songl = new List<onesongnew>();
                foreach (Song song in songlist)
                {
                    if (Utils.IsURLOK(song.Mp3Url)) {
                        onesongnew onesong = new onesongnew();
                        onesong.id = song.Id;
                        onesong.albumid = song.Album.Id;
                        onesong.album = song.Album.Name.Length>10?song.Album.Name.Substring(0,10)+"...":song.Album.Name;
                        onesong.title = song.Name;
                        onesong.author = song.Artist[0].Name;
                        onesong.url = song.Mp3Url;
                        onesong.pic = song.Album.PictureUrl;
                        onesong.lrc = MusicApis.LyricInfo(song.Id.ToString()).Lyr;
                        songl.Add(onesong);}

                }
                hashOperatoer.Set<string>("0001", s, Utils.ObjectToJson(songl));
                hashOperatoer.Dispose();
                context.Response.Write(Utils.ObjectToJson(songl));}}

        else if(type == "10")
        {
            List<Album> albums = MusicApis.SearchApi(s, type, "0", "15").Cast<Album>().ToList();
            foreach(Album album in albums)
            {
                album.Name = album.Name.Length > 10 ? album.Name.Substring(0, 10) + "..." : album.Name;
            }
            context.Response.Write(Utils.ObjectToJson(albums));
        }
        else if(type == "1000")
        {
            List<AppList> AppList = MusicApis.SearchApi(s, type, "0", "15").Cast<AppList>().ToList();
            foreach(AppList applist in AppList)
            {
                applist.Name = applist.Name.Length > 10 ? applist.Name.Substring(0, 10) + "..." : applist.Name;
            }
            context.Response.Write(Utils.ObjectToJson(AppList));
        }





    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}