<%@ WebHandler Language="C#" Class="Test" %>

using System;
using System.Web;
using System.Collections.Generic;

public class Test : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        string id = context.Request.Params["id"] == null ? "" : context.Request.Params["id"].ToString();
        context.Response.ContentType = "text/json";
        Album album = MusicApis.AlbumInfo(id,"0,","20");
        List<Song> songlist = album.Songs;
        List<onesongnew> songl = new List<onesongnew>();
            foreach (Song song in songlist)
            {
                onesongnew onesong = new onesongnew();
                onesong.title = song.Name;
                onesong.author = album.Artist[0].Name;
                onesong.url = song.Mp3Url;
                onesong.pic = album.PictureUrl;
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