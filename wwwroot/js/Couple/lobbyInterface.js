"use strict";

// Defines Hub
let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

// Opens Connection to Hub
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// Listens for GameStarted, routes to COUPLE Vote page
connection.on("GameStarted", function(user) {
    $(location).attr('href', '/Couple/Vote')
  });

// On Click, if Username, show waiting room and broadcast username
$(document).ready(function () {
    $('#joinGame').on('click', function () {
        let username = $('#username').val() 
        console.log(username);
        if (username) {
            // Set Username
            localStorage.setItem("username", username);
            showWaitingRoom();
            sendCoupleNameToHost(username);
        }
    });
})

// Hides Lobby, shows Waiting Room
function showWaitingRoom() {
    if ($('#lobby').css('display') != 'none') {
        $('#waitingRoom').show().siblings('div').hide();
    }
}

// Sends Couple Name to Hub
function sendCoupleNameToHost(username) {
    console.log("Sending Couple");
    connection.invoke("SendCouple", username).catch(function (err) {
        return console.error(err.toString());
    });   
}

// Is this needed?
connection.on("ReceiveUid", function(uid) {
    console.log(uid);
  });
