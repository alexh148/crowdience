"use strict";

// Defines Hub
let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

// Opens Connection to Hub
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// Listens for GameStarted, routes to Vote page
connection.on("GameStarted", function(user) {
    $(location).attr('href', '/Player/Vote')
  });

// On Click, if Username, show waiting room and broadcast username
$(document).ready(function () {
    $('#joinGame').on('click', function () {
        let username = $('#username').val() 
        if (username) {
            // Set Username
            localStorage.setItem("username", username);
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

// Sends Username to Hub
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