<%@ WebHandler Language="C#" Class="GetApplist" %>

using System;
using System.Web;
using System.Collections.Generic;

public class GetApplist : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string id = context.Request.Params["id"] == null ? "" : context.Request.Params["id"].ToString();
        context.Response.ContentType = "text/json";
        AppList applist = MusicApis.AppList(id);
        List<Song> songlist = applist.Tracks;
        List<onesongnew> songl = new List<onesongnew>();
            foreach (Song song in songlist)
            {
                onesongnew onesong = new onesongnew();
                onesong.id = song.Id;
                onesong.title = song.Name;
                onesong.author = song.Artist[0].Name;
                onesong.url = song.Mp3Url;
                onesong.albumid = song.Album.Id;
                onesong.album = song.Album.Name.Length>10?song.Album.Name.Substring(0,10)+"...":song.Album.Name;
                onesong.pic = song.Album.PictureUrl;
                onesong.lrc = MusicApis.LyricInfo(song.Id.ToString()).Lyr;
                songl.Add(onesong);
            }

        context.Response.Write(Utils.ObjectToJson(songl));
    }
    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}