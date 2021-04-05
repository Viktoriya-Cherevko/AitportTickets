// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


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

