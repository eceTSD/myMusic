$(document).ready(function () {

    search('1');
    messageSearch();

});

var goodsVue = new Vue({
    el: '#songlist',
    data: {
        songList: ''
    },
    methods: {
        playonesong: function (song) {
            playsong(song)
        },
        playall: function () {
            playsong(goodsVue.songList)
        },
        toalbum: function (song) {
            getalbumsong(song.albumid)
        }

    }

})

var albumVue = new Vue({
    el: '#albumlist',
    data: {
        appList: ''
    },
    methods: {
        tosong: function (app) {
            getalbumsong(app.Id)
        }
    }
})

var appVue = new Vue({
    el: '#applist',
    data: {
        appList: ''
    },
    methods: {
        toappsong: function (app) {
            getappsong(app.Id)
        }
    }
})

var messVue = new Vue({
    el: '#messagelist',
    data: {
        messList: ''
    }
})

function messageSearch() {
    $.ajax({
        type: "post",
        url: "../../webservice/GetMessage.ashx",
        dataType: "json",       
        success: function (data) {
            messVue.messList = data;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
           
            alert(errorThrown);
        }
    });
}

function search(type) {
    $('#loading').show();
    NProgress.start();
    $.ajax({
        type: "post",
        url: "../../webservice/MyMusic.ashx",
        dataType: "json",
        data: {
            s: $("#searchvalue").val(),
            type: type
        },
        success: function (data) {
            if (type == '1' || type == '0') {
                $("#songlist").show();
                $("#applist").hide();
                $("#albumlist").hide();

                $.each(data, function (i, item) {
                    if (item.lrc != null) { item.lrc = item.lrc.replace(/\"/g, "'"); }
                })
                goodsVue.songList = data;
            } else if (type == '10') {
                $("#songlist").hide();
                $("#applist").hide();
                $("#albumlist").show();
                albumVue.appList = data
            } else {
                $("#songlist").hide();
                $("#applist").show();
                $("#albumlist").hide();
                appVue.appList = data
            }
            NProgress.done();
            $('#loading').hide();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            NProgress.done();
            $('#loading').hide();
            alert(errorThrown);
        }
    });
}

function getalbumsong(id) {
    $('#loading').show();
    NProgress.start();
    $.ajax({
        type: "post",
        url: "../../webservice/GetAlbum.ashx",
        dataType: "json",
        data: {
            id: id
        },
        success: function (data) {
            $("#songlist").show();
            $("#applist").hide();
            $("#albumlist").hide();

            $.each(data, function (i, item) {
                if (item.lrc != null) { item.lrc = item.lrc.replace(/\"/g, "'"); }
            })
            goodsVue.songList = data;
            NProgress.done();
            $('#loading').hide();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            NProgress.done();
            $('#loading').hide();
            alert(errorThrown);
        }
    });
}

function getappsong(id) {
    $('#loading').show();
    NProgress.start();
    $.ajax({
        type: "post",
        url: "../../webservice/GetApplist.ashx",
        dataType: "json",
        data: {
            id: id
        },
        success: function (data) {
            $("#songlist").show();
            $("#applist").hide();
            $("#albumlist").hide();

            $.each(data, function (i, item) {
                if (item.lrc != null) { item.lrc = item.lrc.replace(/\"/g, "'"); }
            })
            goodsVue.songList = data;
            NProgress.done();
            $('#loading').hide();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            NProgress.done();
            $('#loading').hide();
            alert(errorThrown);
        }
    });
}




function playsong(data) {
    var ap4 = new APlayer({
        element: document.getElementById('player4'),
        narrow: false,
        autoplay: true,
        showlrc: 1,
        mutex: true,
        theme: '#ad7a86',
        mode: 'random',
        music: data
    });
}

function come() {
    alert("coming soon");
}

function message() {
    bootbox.setLocale("zh_CN");
    bootbox.prompt({
        title: "你的意见是我们最大的动力！！！！",
        inputType: 'textarea',
        callback: function (result) {
            if (result != "" && result !=null) {
                $.ajax({
                    type: "post",
                    url: "../../webservice/Message.ashx",
                    dataType: "json",
                    data: {
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