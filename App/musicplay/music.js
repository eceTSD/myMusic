$(document).ready(function () {

    var searchvalue = GetQueryString("songid");

    songid = searchvalue;

    search(songid);
    messageSearch(songid);
})

var musV = new Vue({
    el: '#player',
    data: {
        song: ''
    }
})

var songid = '';

function GetQueryString(namea) {
    var reg = new RegExp("(^|&)" + namea + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return decodeURIComponent(r[2]); return null;
}

function search(searchvalue) {
    $.ajax({
        type: "post",
        url: "../../webservice/MusicPlay.ashx",
        dataType: "json",
        data: {
            s: searchvalue
        },
        success: function (data) {
            /*$.each(data, function (i, item) {
                if (item.lrc != null) { item.lrc = item.lrc.replace(/\"/g, "'"); }
            })*/
            musV.song = data[0];
            document.getElementById("audio").src = musV.song.url;//歌曲链接

            var lrcText = new Lyrics(musV.song.lrc);

            $player.bind("playing", function () {
                renderLyric(lrcText);
            });
            //loadLrc(musV.song.lrc, $("#out"), $('audio')[0]);//歌词链接
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

//歌词处理
var $player = $("#audio"),
    player = $player.get(0),
    lyric_wrap = $(".lyric_wrap"),
    lyric = lyric_wrap.find("#lyric");

function renderLyric(lrcText) {
    lyric.html("");
    var lyricLineHeight = 27,
        offset = lyric_wrap.offset().height * 0.4;
    lrcText.fetch(function (data) {
        lrcText.parsed = {};
        var i = 0;
        for (var k in data) {
            var txt = data[k];
            if (!txt) txt = "&nbsp;";
            lrcText.parsed[k] = {
                index: i++,
                text: txt,
                top: i * lyricLineHeight - offset
            };
            var li = $("<li>" + txt + "</li>");
            lyric.append(li);
        }
    }, function () {
        lyric.html("<li style='text-align: center'>歌词加载失败</li>");
    });
}

function Lyrics(url) {
    this.url = url;
    this.fetch = function (success, error) {
        /*
        $.ajax({
            url:this.url,
            headers:{
                contentType:"application/x-www-form-urlencoded"
            },
            success:function(lrc){*/
        var lyric = parseLyric(url);
        if (success) success(lyric);
        /*},
        error:function(e){
            if(error)error(e);
        }
    });*/
    };
}

function parseLyric(lrc) {
    var lyrics = lrc.split("\n");
    var lrcObj = {};
    for (var i = 0; i < lyrics.length; i++) {
        var lyric = decodeURIComponent(lyrics[i]);
        var timeReg = /\[\d*:\d*((\.|\:)\d*)*\]/g;
        var timeRegExpArr = lyric.match(timeReg);
        if (!timeRegExpArr) continue;
        var clause = lyric.replace(timeReg, '');

        for (var k = 0, h = timeRegExpArr.length; k < h; k++) {
            var t = timeRegExpArr[k];
            var min = Number(String(t.match(/\[\d*/i)).slice(1)),
                sec = Number(String(t.match(/\:\d*/i)).slice(1));
            var time = min * 60 + sec;
            lrcObj[time] = clause;
        }
    }
    return lrcObj;
}


var messVue = new Vue({
    el: '#messagelist',
    data: {
        messList: ''
    }
})

function messageSearch(searchvalue) {
    $.ajax({
        type: "post",
        url: "../../webservice/GetSongMessage.ashx",
        dataType: "json",
        data: {
            s: searchvalue
        },
        success: function (data) {
            messVue.messList = data;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alert(errorThrown);
        }
    });
}

function message() {
    bootbox.setLocale("zh_CN");
    bootbox.prompt({
        title: "歌曲评论",
        inputType: 'textarea',
        callback: function (result) {
            if (result != "" && result != null) {
                $.ajax({
                    type: "post",
                    url: "../../webservice/SongMessage.ashx",
                    dataType: "json",
                    data: {
                        id: songid,
                        message: result
                    },
                    success: function (data) {
                        if (data.statue == 0) {
                            alert("输入非法字符请重新输入ε=( o｀ω′)ノ")
                        }
                        else if (data.statue == 200) {
                            alert("提交成功感谢有你O(∩_∩)O")
                            messageSearch();

                        } else if (data.statue == 400) {
                            alert("提交失败请稍后再试/(ㄒoㄒ)/~~")
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                })
            }

        }
    });
}