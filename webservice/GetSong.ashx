<%@ WebHandler Language="C#" Class="GetSong" %>

using System;
using System.Web;
using System.Collections.Generic;

public class GetSong : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string id = context.Request.Params["id"] == null ? "" : context.Request.Params["id"].ToString();
        List<Song> songlist = MusicApis.SongInfo(id);
          List<onesongnew> songl = new List<onesongnew>();
            foreach (Song song in songlist)
            {
                onesongnew onesong = new onesongnew();
                onesong.id = song.Id;
                onesong.albumid = song.Album.Id;
                onesong.album = song.Album.Name;
                onesong.title = song.Name;
                onesong.author = song.Artist[0].Name;
                onesong.url = song.Mp3Url;
                onesong.pic = song.Album.PictureUrl;
                onesong.lrc = MusicApis.LyricInfo(song.Id.ToString()).Lyr;
                songl.Add(onesong);
            }
        context.Response.ContentType = "text/json";
        context.Response.Write(Utils.ObjectToJson(songl));
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}