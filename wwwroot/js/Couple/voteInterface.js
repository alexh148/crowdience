"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

document.getElementById("sendButton").addEventListener("click", function (event) {
    event.preventDefault();
    var couple = localStorage.getItem("couple");
    var message = ""; //document.getElementById("messageInput").value;

    if (!couple) {
        couple = "[anonymous]";
    }
    if ($('input:radio[name=myResponse]').is(':checked')) {
        var myResponseId = $('input[name=myResponse]:checked').attr('id');
        var myResponseVal = $('input[name=myResponse]:checked').val();

        connection.invoke("SendCoupleVote", couple, message, myResponseId, myResponseVal).catch(function (err) {
            return console.error(err.toString());
        });
    } else {
        return console.log("No response selected.");
    }
});

connection.on("ReceiveQuestion", function (question) {
    console.log(question);
    document.getElementById("questionTitle").innerHTML = question;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});