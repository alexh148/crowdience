"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});

$("#startAsHost").click(function (event){
    event.preventDefault()
    $(location).attr('href', '/Host')
});

$("#startAsCouple").click(function (event){
    event.preventDefault()
    $(location).attr('href', '/Couple/Lobby')
});


$("#startAsPlayer").click(function (event){
    event.preventDefault()
    $(location).attr('href', '/Player/Lobby')
});