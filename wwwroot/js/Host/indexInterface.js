"use strict";

// Defines Hub
let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

// Opens Connection to Hub
connection.start().catch(function (err) {
    return console.error(err.toString());
});

$(document).ready(function () {
    // Prevents more than 2 icons being selected
    var limit = 2;
    $('input.form-check-input').on('change', function (evt) {
        if ($(this).siblings(':checked').length >= limit) {
            this.checked = false;
        }
    });

    // On Click adds Icons to Local Storage
    $('#create').click(function () {
        var counter = 1;
        $('.cc-selector-2 input:checked').each(function () {
            localStorage.setItem(`IconId${counter}`, $(this).attr('value'));
            counter++;
        });
    })
})