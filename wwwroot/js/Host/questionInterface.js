"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();
var counter = 0
var questions = localStorage.getItem("questions");
var questions = JSON.parse(questions);

connection.start().catch(function (err) {
    return console.error(err.toString());
});

// Broken!!
$( "#nextQuestion" ).click(function(event) {
    event.preventDefault()

    // Change to C# functionality, save to DB?
    localStorage.setItem("answerOneVotes", document.getElementById("answerOneCounter").innerHTML);
    localStorage.setItem("answerTwoVotes", document.getElementById("answerTwoCounter").innerHTML);

    // Change to C# functionality, get Q from DB
    connection.invoke("SendQuestion", questions[counter]).catch(function (err) {
        return console.error(err.toString());
    });
    counter++;
});

