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
    receiveIcons();
    $('#vote').on('click', function () {
        // event.preventDefault();
        sendVoteToHost();
    });
})

// Listen for Question from Host
function receiveQuestionFromHost() {
    connection.on("ReceiveQuestion", function (question) {
        $("#questionTitle").html(question);
    });
}

// Listen for Icons from Host
function receiveIcons(){
    console.log("Receiving Icons");
    connection.on("ReceiveIconId", function (icon1, icon2) {
        $('#answerOne').html(`<input id="${icon1}2" type="radio" name="creditcard" value="He Did" />
        <label class="drinkcard-cc ${icon1}" for="${icon1}2"></label>`);
        $('#answerTwo').html(`<input id="${icon2}2" type="radio" name="creditcard" value="He Did" />
        <label class="drinkcard-cc ${icon2}" for="${icon2}2"></label>`);
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

