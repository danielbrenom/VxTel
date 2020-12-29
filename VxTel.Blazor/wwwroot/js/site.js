// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let oddd = $("#icon_prefix_origin"),
    dddd = $("#icon_prefix_dest"),
    plan = $("#plan"),
    min = $("#icon_prefix_minutes");
$().ready(function () {
    $('select').formSelect();
    //$('#resultArea').hide('fast');
    $(".typeahead").autocomplete({
        data: {
            11: null,
            16: null,
            17: null,
            18: null
        }
    });
    $("#simulate").submit(function (event) {
        event.preventDefault();
        $.get(`/simulate/plan/${plan.val()}/origin/${oddd.val()}/destination/${dddd.val()}/minutes/${min.val()}`
            , {}, function () {
            })
            .done(function (response) {
                showResult(response)
            })
            .fail(function (response) {
                showMessage(response.responseJSON);
            });
    });

    function showResult(response) {
        $("#resultArea").show('fast');
        $("#tableBody").empty()
            .append(`<tr>
            <td>${response.originDDD}</td>
            <td>${response.destinationDDD}</td>
            <td>${response.desiredMinutes}</td>
            <td>${response.selectedPlan}</td>
            <td>${response.priceWith.toLocaleString("pt-BR", {style: 'currency', currency: "BRL"})}</td>
            <td>${response.priceWithout.toLocaleString("pt-BR", {style: 'currency', currency: "BRL"})}</td>
            </tr>`);
    }

    function showMessage(response) {
        Swal.fire({
            icon: 'error',
            title: 'Ops',
            text: response
        });
    }
});



