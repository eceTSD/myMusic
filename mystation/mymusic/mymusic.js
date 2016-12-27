$(document).ready(function () {
   
    search();
   

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
        }
   }
    
})

function search() {
    $.ajax({
        type: "post",
        url: "../../webservice/MyMusic.ashx",
        dataType: "json",
        data: {
            s: $("#searchvalue").val()
        },
        success: function (data) {
            $.each(data, function (i, item) {
                if (item.lrc != null) { item.lrc = item.lrc.replace(/\"/g, "'"); }
            })         
            goodsVue.songList = data;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
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
