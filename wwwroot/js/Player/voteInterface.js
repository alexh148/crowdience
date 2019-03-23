"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();
var counter = 0;

connection.on("ReceiveQuestion", function (question) {
    console.log(question);
    $("#questionTitle").html(question);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = localStorage.getItem("user");
    // Not needed?
    var message = "";

    // Change to required field in HTML?
    if (!user) {
        user = "[anonymous]";
    }

    if ($('input:radio[name=myResponse]').is(':checked')) {
        var myResponseId = $('input[name=myResponse]:checked').attr('id');
        var myResponseVal = $('input[name=myResponse]:checked').val();
        connection.invoke("SendMessage", user, message, myResponseId, myResponseVal).catch(function (err) {
            return console.error(err.toString());
        });
    } else {
        return console.log("No response selected.");
    }
    event.preventDefault();
});