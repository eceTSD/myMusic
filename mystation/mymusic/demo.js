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
            $.each(data, function (i, item) {
                if (item.lrc != null) { item.lrc = item.lrc.replace(/\"/g, "'"); }   
            })

            var ap4 = new APlayer({
                element: document.getElementById('player4'),
                narrow: false,
                autoplay: false,
                showlrc: 1,
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