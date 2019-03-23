"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});

$(document).ready(function () {
    // $('#joinGame').on('click', function () {
    //     console.log("Click Confirmed")
    //     if ($('#lobby').css('display') != 'none') {
    //         $('#playerJoined').html('Here is my dynamic content').show().siblings('div').hide();
    //     } else if ($('#playerJoined').css('display') != 'none') {
    //         $('#lobby').show().siblings('div').hide();
    //     }
    // });

    $('#joinGame').on('click', function () {
        if ($('#lobby').css('display') != 'none') {
            $('#playerJoined').show().siblings('div').hide();
        } else if ($('#playerJoined').css('display') != 'none') {
            $('#lobby').show().siblings('div').hide();
        }
    });
})

document.getElementById("joinGame").addEventListener("click", function (event) {
    event.preventDefault();
    let username = document.getElementById("username").value;
    localStorage.setItem("user", username);

    if (!username) {
        username = "[anonymous]";
    }

    connection.invoke("SendUser", username).catch(function (err) {
        return console.error(err.toString());
    });

    // $(location).attr('href', '/Player/Vote')
});