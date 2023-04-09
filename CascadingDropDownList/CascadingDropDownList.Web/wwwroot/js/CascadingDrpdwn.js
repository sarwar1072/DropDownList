$(document).ready(function () {
    GetCountry();
    $("#country").change(function () {
        var id = $(this).val();
        $("#state").empty();
        $("#state").append('<Option >--select state--</Option>');
        $.ajax({
            url: 'DropDown/State?id='+id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $("#state").append('<Option value=' + data.id + '>' + data.name + '</Option>');

                });
            }
          
        });
    });

    $("#state").change(function () {
        var id = $(this).val();
        $("#city").empty();
        $("#city").append('<Option >--select city--</Option>');
        $.ajax({
            url: 'DropDown/City?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $("#city").append('<Option value=' + data.id + '>' + data.name + '</Option>');

                });
            }

        });
    });

});


function GetCountry() {
    $.ajax({
        url: 'DropDown/Country',
        success: function (result) {
            $.each(result, function (i,data) {
                $("#country").append('<Option value=' + data.id + '>' + data.name + '</Option>');
                 
            });

        }
     
    });
}