"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

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

    $(location).attr('href', '/Player/Vote')
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

