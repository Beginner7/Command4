
function Makemove(moveFrom, moveTo) {
    var Figure = $("#" + moveFrom + " img").attr("src");
    $("#" + moveTo + " img").attr("src", Figure);
    $("#" + moveFrom + " img").attr("src", "");
};


function MakeTable(divtable) {
    alert(divtable);
    $('#'+divtable).append('<table>');
    for (i = 0; i < 8; i++) {
        $('#'+divtable).append('<tr>'+'</tr>');
        for (j = 0; j < 8; j++) {
            $('#'+divtable).append('<td>' + i + j + '</td>');
        }
        
    }

}


