$(document).ready(function() {
    loadData();
});



//Load Data function

function loadData() {
    $.ajax({
        url: "/admin/users/listall",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function(result) {
            var html = '';
            $.each(result,
                function(key, item) {
                    html += '<tr>';
                    html += '<td>' + item.username + '</td>';
                    html += '<td>' + item.email + '</td>';
                    html += '</tr>';
                });
            $('#ajaxResponse').html(html);
        },
        error: function(errormessage) {
            alert(errormessage.responseText);
        }
    });
}