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
    $('select').on("change", function () {
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
    $('input').on("change", function () {
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