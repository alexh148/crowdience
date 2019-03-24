"use strict";

// Defines Hub
let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

// Opens Connection to Hub
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// When Document loads listen for Question from Host
// When Vote is clicked send Vote to Host
$(document).ready(function () {
    receiveQuestionFromHost();
    $('#vote').on('click', function () {
        event.preventDefault();
        sendVoteToHost();
    });
})

// Listen for Question from Host
function receiveQuestionFromHost() {
    connection.on("ReceiveQuestion", function (question) {
        $("#questionTitle").html(question);
    });
}

// Send Vote to Host
function sendVoteToHost() {
    var couple = localStorage.getItem("username");
    // If something is selected
    if ($('input:radio[name=myResponse]').is(':checked')) {
        // Assign Values
        var myResponseId = $('input[name=myResponse]:checked').attr('id');
        var myResponseVal = $('input[name=myResponse]:checked').val();
        // Broadcast to Host
        connection.invoke("SendCoupleVote", couple, myResponseId, myResponseVal).catch(function (err) {
            return console.error(err.toString());
        });
    } else {
        return console.log("No response selected.");
    }
}