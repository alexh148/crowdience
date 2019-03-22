"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});

$("#startGame").click(function (event) {
    event.preventDefault()
    let uid = document.getElementById("uid").value;
    localStorage.setItem("uid", uid);
    
    var data = {
        inProgress: true,
        uniqueId: uid
    };

    console.log(uid)
    console.log(data)

    fetch("/api/Game", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    }).then($(location).attr('href', '/Host'))
    
    connection.invoke("SendUid", uid).catch(function (err) {
        return console.error(err.toString());
    });

});
