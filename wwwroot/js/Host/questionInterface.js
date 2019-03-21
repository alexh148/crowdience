"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();
var counter = 0
var questions = localStorage.getItem("questions");
var questions = JSON.parse(questions);

// Broken!!
$( "#nextQuestion" ).click(function(event) {
    event.preventDefault()
    localStorage.setItem("answerOneVotes", document.getElementById("answerOneCounter").innerHTML);
    localStorage.setItem("answerTwoVotes", document.getElementById("answerTwoCounter").innerHTML);

    
    // $(location).attr('href', '/Host/EndOfRound')

    connection.invoke("SendQuestion", questions[counter]).catch(function (err) {
        return console.error(err.toString());
    });
    counter++;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});