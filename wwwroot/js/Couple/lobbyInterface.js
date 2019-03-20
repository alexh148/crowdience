"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

document.getElementById("joinGame").addEventListener("click", function (event) {
    event.preventDefault();
    let username = document.getElementById("username").value;
    localStorage.setItem("couple", username);
    
    if (!username) {
        username = "[anonymous]";
        //need to change so it's a must to be entered
    }

    connection.invoke("SendCouple", username).catch(function (err) {
        return console.error(err.toString());
    });

    $(location).attr('href', '/Couple/Vote')
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

