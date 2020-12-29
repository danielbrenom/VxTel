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


    function showMessage(response) {
        Swal.fire({
            icon: 'error',
            title: 'Ops',
            text: response
        });
    }
});



