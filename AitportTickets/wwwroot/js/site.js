// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//GetFlightsByCityDA departure and arrival
    $(document).ready(function () {
        $('select').on("change", function () {
            var city = $("#city").val();
            var city1 = $("#city1").val();
            if (city === city1) {
                alert("You can not go from " + city + " to " + city);
                $("#search").prop('disabled', true);
            }
            else {
                //если пункты из выпадающих списков выбраны "правильные"
                $("#search").prop('disabled', false);
                //отправляем запрос в контролер для обновления таблицы
                $.ajax({
                    url: '/Flights/_GetFlightsByCityDA/',
                    type: "POST",
                    //dataType: "json",
                    data: {
                        city: city,
                        city1: city1
                    },
                    success: function (data) {
                        //Fill div with results
                        $("#flights").html(data);
                    },
                    error: function () {
                        alert('Нет связи с базой данных');
                    }
                })
            }
        });
    });

//GetFlightsByCity of Departure
$(document).ready(function () {
    $("#cityDep").on("change", function () {
        var cityDep = $("#cityDep").val();
        $.ajax({
            url: '/Flights/GetFlightsByCity/',
            type: "POST",
            //dataType: "json",
            data: { cityDep: cityDep },
            success: function (data) {
                //Fill div with results
                $("#flights").html(data);
            },
            error: function () {
                alert('Нет связи с базой данных');
            }
        })
    });
});

//GetFlightsByDate
$(document).ready(function () {
    $('#dateOfDep').on("change", function () {
        var dateOfDep = $("#dateOfDep").val();
        $.ajax({
            url: '/Flights/GetFlightsByDate/',
            type: "POST",
            //dataType: "json",
            data: { dateOfDep: dateOfDep },
            success: function (data) {
                //Fill div with results
                $("#flights").html(data);
            },
            error: function () {
                alert('Нет связи с базой данных');
            }
        })
    });
});


//Change cities on click 
function change() {
    let city = $("#city").val();
    let city1 = $("#city1").val();
    let x = city;
    city = city1;
    city1 = x;
    $("#city").val(city).change();
    $("#city1").val(city1).change();

}

//GetFlightsByNumber
$(document).ready(function () {
    $('#getFlightByNumber').on("change", function () {
        var number = $("#number").val();
        var date = $("#date").val();
        $.ajax({
            url: '/Flights/GetFlightByNumber/',
            type: "POST",
            //dataType: "json",
            data: {
                number: number,
                date: date
            },
            success: function (data) {
                //Fill div with results
                $("#flights").html(data);
            },
            error: function () {
                alert('Нет связи с базой данных');
            }
        })
    });
});