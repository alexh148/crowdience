"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});

$(document).ready(function () {
    $('#joinGame').on('click', function () {
        let username = $('#username').val() 
        if (username) {
            showWaitingRoom();
            sendUsernameToHost(username);
        }
    });
})

// Hides Lobby, shows Waiting Room
function showWaitingRoom() {
    if ($('#lobby').css('display') != 'none') {
        $('#waitingRoom').show().siblings('div').hide();
    }
}

function sendUsernameToHost(username) {
    connection.invoke("SendUser", username).catch(function (err) {
        return console.error(err.toString());
    });
}

// document.getElementById("joinGame").addEventListener("click", function (event) {
//     event.preventDefault();
//     let username = document.getElementById("username").value;
//     localStorage.setItem("user", username);

//     if (!username) {
//         username = "[anonymous]";
//     }

//     connection.invoke("SendUser", username).catch(function (err) {
//         return console.error(err.toString());
//     });

//     // $(location).attr('href', '/Player/Vote')
// });