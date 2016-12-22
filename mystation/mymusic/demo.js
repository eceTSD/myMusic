$(document).ready(function () {
    search();
});

function search() {
    $.ajax({
        type: "post",
        url: "../../webservice/MyMusic.ashx",
        dataType: "json",
        data: {
            s: $("#searchvalue").val()
        },
        success: function (data) {
            var ap4 = new APlayer({
                element: document.getElementById('player4'),
                narrow: false,
                autoplay: false,
                showlrc: false,
                mutex: true,
                theme: '#ad7a86',
                mode: 'random',
                music: data
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

var ap5 = new APlayer({
    element: document.getElementById('player5'),
    narrow: false,
    autoplay: false,
    showlrc: 3,
    mutex: true,
    theme: '#ad7a86',
    mode: 'random',
    listmaxheight: '80px',
    music: [
        {
            title: 'あっちゅ～ま青春!',
            author: '七森中☆ごらく部',
            url: 'http://devtest.qiniudn.com/あっちゅ～ま青春!.mp3',
            pic: 'http://devtest.qiniudn.com/あっちゅ～ま青春!.jpg',
            lrc: 'あっちゅ～ま青春!.lrc'
        },
        {
            title: 'secret base~君がくれたもの~',
            author: '茅野愛衣',
            url: 'http://devtest.qiniudn.com/secret base~.mp3',
            pic: 'http://devtest.qiniudn.com/secret base~.jpg',
            lrc: 'secret base~君がくれたもの~.lrc'
        },
        {
            title: '回レ！雪月花',
            author: '小倉唯',
            url: 'http://devtest.qiniudn.com/回レ！雪月花.mp3',
            pic: 'http://devtest.qiniudn.com/回レ！雪月花.jpg',
            lrc: '回レ！雪月花.lrc'
        }
    ]
});